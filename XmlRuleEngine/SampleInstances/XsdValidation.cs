using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using ValidationRuleEngine;

namespace Customizations
{
    [Serializable]
    [XmlRoot(ElementName = "validation")]
    public class XsdValidation : ValidationRuleEngine.Implementations.Validation
    {
        #region privateMembers
            private ErrorXml currentErrorXml;
            private bool errorDetected = false;
            private Stack<string> elementStack = new Stack<string>();
        #endregion

        #region RepositoryObjectDeclaration
            private UnitOfWork unitOfWork = new UnitOfWork();
        #endregion

        void Initialize()
        {
            
        }

        public XsdValidation()
        {
            Initialize();
        }

        public void setupXsdValidator(string clientCode, string companyCode, string warehouseCode, string orderNumber, string orderDate, string documentType, string xsd_ns, string xsd_path)
        {
            try
            {
                base.setupMandatoryFields(clientCode, companyCode, warehouseCode, orderNumber, orderDate, documentType);
                this.setupCustomFields(xsd_ns, xsd_path);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void setupCustomFields(string xsd_ns, string xsd_file_path)
        {
            try
            {
                Attribute customVariable = new Attribute();
                customVariable.enabled = true;
                customVariable.name = Constants.XsdValidator_CustomFields.xsd_ns;
                customVariable.path = "";
                customVariable.value = xsd_ns;
                customVariable.is_rectifiable = false;
                this.LocalAttributes.Add(customVariable);

                customVariable = new Attribute();
                customVariable.enabled = true;
                customVariable.name = Constants.XsdValidator_CustomFields.xsd_file_path;
                customVariable.path = "";
                customVariable.value = xsd_file_path;
                customVariable.is_rectifiable = false;
                this.LocalAttributes.Add(customVariable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        

        public override bool Validate(/*Object obj*/)
        {
            try
            {
                //IValidationContext context = (IValidationContext)obj;
                //XDocument CurrentXmlDocument = new XDocument();
                //XPathDocument xPathDoc = new XPathDocument(context.ParentElement.CreateReader());
                //var xpathNavigator = xPathDoc.CreateNavigator();

                //LoadCustomVariables(xpathNavigator);
                //base.Validate(obj, currXDocument, /*DocumentType, */mandatoryFields);
                XmlReaderSettings settings = new XmlReaderSettings();

                settings.Schemas.Add(
                    this.LocalAttributes.Where(item => item.name == Constants.XsdValidator_CustomFields.xsd_ns).First<Attribute>().value,
                    this.LocalAttributes.Where(item => item.name == Constants.XsdValidator_CustomFields.xsd_file_path).First<Attribute>().value);
                settings.ValidationType = ValidationType.Schema;
                settings.ValidationEventHandler += new ValidationEventHandler(ValidationEventHandler);

                XmlReader reader = XmlReader.Create(this.currentXml.CreateReader(), settings);

                #region ApplicationLogEntries DB Entry
                ApplicationEventMaster Event = unitOfWork.ApplicationEventMasterRepository
                    .SelectByID(Constants.EventType.Standard_Xml_Validation_Started);

                ApplicationMaster Application = unitOfWork.ApplicationMasterRepository
                    .SelectByID(Constants.ApplicationId);

                ApplicationLog objApplicationLog = unitOfWork.CreateApplicationLogObject(Event,
                    Application, "LoremIpsumMessage", "amjad.leghari");

                unitOfWork.ApplicationLogRepository.Insert(objApplicationLog);
                unitOfWork.Save();
                #endregion

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        elementStack.Push(reader.Name);
                    }
                    if (reader.NodeType == XmlNodeType.EndElement ||
                        (reader.NodeType == XmlNodeType.Element && reader.IsEmptyElement))
                    {
                        elementStack.Pop();
                    }
                }

                if (!errorDetected)
                {
                    #region ApplicationLogEntries DB Entry
                    Event = unitOfWork.ApplicationEventMasterRepository.SelectByID(Constants.EventType.Standard_Xml_Validation_Succeeded);
                    Application = unitOfWork.ApplicationMasterRepository.SelectByID(Constants.ApplicationId);

                    objApplicationLog = unitOfWork.CreateApplicationLogObject(Event, Application,
                        "LoremIpsumMessage", "amjad.leghari");

                    unitOfWork.ApplicationLogRepository.Insert(objApplicationLog);
                    unitOfWork.Save();
                    #endregion
                }

                currentErrorXml = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return !errorDetected;
        }

        private void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            try
            {
                var dataType = "";
                if (e.Severity == XmlSeverityType.Warning)
                {
                    Console.Write("WARNING: ");
                    Console.WriteLine(e.Message);
                }
                else if (e.Severity == XmlSeverityType.Error)
                {
                    if (!errorDetected)
                    {
                        this.errorDetected = true;
                        #region ApplicationLogEntries DB Entry
                        ApplicationEventMaster Event = unitOfWork.ApplicationEventMasterRepository
                            .SelectByID(Constants.EventType.Standard_Xml_Validation_Failed);

                        ApplicationMaster Application = unitOfWork.ApplicationMasterRepository
                            .SelectByID(Constants.ApplicationId);

                        ApplicationLog objAppLog = unitOfWork.CreateApplicationLogObject(Event, Application,
                            "LoremIpsumMessage", "amjad.leghari");

                        unitOfWork.ApplicationLogRepository.Insert(objAppLog);
                        unitOfWork.Save();
                        #endregion
                    }

                    IXmlLineInfo node = sender as IXmlLineInfo;
                    if (node != null && node.HasLineInfo())
                    {
                        Console.WriteLine(node.LinePosition);
                        Console.WriteLine(node.LineNumber);
                    }

                    Console.Write("ERROR: ");
                    Console.WriteLine(e.Message);

                    Console.Write("DataKey: ");
                    var obj = sender as XmlReader;
                    Console.WriteLine(obj.Name);
                    Console.Write("DataValue: ");
                    Console.WriteLine(obj.Value);

                    if (obj.SchemaInfo.SchemaElement != null)
                    {
                        Console.Write("DataType: ");
                        dataType = obj.SchemaInfo.SchemaElement.ElementSchemaType.Datatype.TypeCode.ToString();
                        Console.WriteLine(obj.SchemaInfo.SchemaElement.ElementSchemaType.Datatype.TypeCode);
                    }
                    if (String.IsNullOrEmpty(dataType))
                    {
                        if (e.Message.Contains("cannot appear more than once"))
                        {
                            dataType = "duplicate elements";
                        }
                    }
                    var xPath = elementStack.Reverse().Aggregate(string.Empty, (x, y) => x + "/" + y);
                    if (!xPath.Contains(obj.Name))
                        xPath += String.Format("/{0}", obj.Name);
                    Console.Write("XPath: ");
                    Console.WriteLine(xPath);

                    #region ErrorXml DB Entry
                    if (currentErrorXml == null)
                    {
                        currentErrorXml = unitOfWork.CreateErrorXml(
                            clientCode,
                            warehouseCode,
                            String.IsNullOrEmpty(orderNumber)
                                ? "dummy order number"
                                : orderNumber,
                            this.varDocumentType,
                            orderDate,
                            DateTime.Now, this.inProcessXML);

                        unitOfWork.ErrorXmlRepository.Insert(currentErrorXml);
                        unitOfWork.Save();
                    }
                    #endregion

                    #region ErrorInboundData DB Entry
                    ErrorInboundData objErrInbound = unitOfWork.CreateErrorInboundData(obj.Name,
                        elementStack.Reverse().Aggregate(string.Empty, (x, y) => x + "/" + y),
                        dataType, obj.Value, "not available", e.Message, "not available",
                        unitOfWork.ErrorXmlRepository.SelectByID(currentErrorXml.Id), false);

                    unitOfWork.ErrorInboundRepository.Insert(objErrInbound);
                    unitOfWork.Save();
                    #endregion

                    #region ErrorSuggestion DB Entry

                    Error_Suggestion_InboundData_Mapper esidmapObj = new Error_Suggestion_InboundData_Mapper();
                    esidmapObj.Id = Guid.NewGuid();
                    switch (objErrInbound.DataType.ToLower())
                    {
                        case "integer":
                            esidmapObj.ErrorSuggestionId = Constants.Suggestions.XSD_Invalid_Integer;
                            break;
                        case "float":
                            esidmapObj.ErrorSuggestionId = Constants.Suggestions.XSD_Invalid_Float;
                            break;
                        case "datetime":
                            esidmapObj.ErrorSuggestionId = Constants.Suggestions.XSD_Invalid_DateTime;
                            break;
                        case "boolean":
                            esidmapObj.ErrorSuggestionId = Constants.Suggestions.XSD_Invalid_Boolean;
                            break;
                        case "duplicate elements":
                            esidmapObj.ErrorSuggestionId = Constants.Suggestions.XSD_Duplicate_Element;
                            break;
                        default: break;
                    }

                    esidmapObj.ErrorInboundDataId = objErrInbound.Id;
                    esidmapObj.DateTime = DateTime.Now;
                    unitOfWork.ErrorSuggestion_InboundDataRepository.Insert(esidmapObj);
                    unitOfWork.Save();
                    #endregion
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }       
        }
    }
}
