using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    public class XsdValidator : ValidationRuleEngine.Implementations.Validation
    {
        #region Custom Properties

            [XmlElement("xsd_ns")]
            public string Xsd_ns { get; set; }

            [XmlElement("xsd_file_path")]
            public string Xsd_file_path { get; set; }

        #endregion

        #region privateMembers
            private ErrorXml currentErrorXml;
            private bool errorDetected = false;
            private Stack<string> xpath = new Stack<string>();
        #endregion

        #region RepositoryObjectDeclaration
            private UnitOfWork unitOfWork = new UnitOfWork();
        #endregion

        void Initialize()
        {
        }

        public XsdValidator()
        {
            Initialize();
        }
        
        public override bool Validate(Object obj, XDocument currXDocument, string DocumentType, string orderNumberPath, string orderDatePath)
        {
            base.Validate(obj, currXDocument, DocumentType, orderNumberPath, orderDatePath);

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.Schemas.Add(Xsd_ns, Xsd_file_path);
            settings.ValidationType = ValidationType.Schema;
            settings.ValidationEventHandler += new ValidationEventHandler(ValidationEventHandler);

            XmlReader reader = XmlReader.Create(currXDocument.CreateReader(), settings);

            #region ApplicationLogEntries DB Entry
                ApplicationLog objApplicationLog = new ApplicationLog();
                objApplicationLog.Id = Guid.NewGuid();
                objApplicationLog.Message = "LoremIpsumMessage";
                objApplicationLog.TimeStamp = DateTime.Now;
                objApplicationLog.UserId = "amjad.leghari";
                objApplicationLog.ApplicationMaster = unitOfWork.ApplicationMasterRepository.SelectByID(Constants.ApplicationId);
                objApplicationLog.ApplicationEventMaster = unitOfWork.ApplicationEventMasterRepository.SelectByID(Constants.EventType.Standard_Xml_Validation_Started);
                unitOfWork.ApplicationLogRepository.Insert(objApplicationLog);
                unitOfWork.Save();
            #endregion

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    xpath.Push(reader.Name);
                }
                if (reader.NodeType == XmlNodeType.EndElement ||
                    (reader.NodeType == XmlNodeType.Element && reader.IsEmptyElement))
                {
                    xpath.Pop();
                }
            }

            if (!errorDetected)
            {
                #region ApplicationLogEntries DB Entry
                    objApplicationLog = new ApplicationLog();

                    objApplicationLog.Id = Guid.NewGuid();
                    objApplicationLog.Message = "LoremIpsumMessage";
                    objApplicationLog.TimeStamp = DateTime.Now;
                    objApplicationLog.UserId = "amjad.leghari";
                    objApplicationLog.ApplicationMaster = unitOfWork.ApplicationMasterRepository.SelectByID(Constants.ApplicationId);
                    objApplicationLog.ApplicationEventMaster = unitOfWork.ApplicationEventMasterRepository.SelectByID(Constants.EventType.Standard_Xml_Validation_Succeeded);
                    unitOfWork.ApplicationLogRepository.Insert(objApplicationLog);
                    unitOfWork.Save();
                #endregion
            }

            currentErrorXml = null;

            return !errorDetected;
        }

        private void ValidationEventHandler(object sender, ValidationEventArgs e)
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
                        ApplicationLog objAppLog = new ApplicationLog();
                        objAppLog.Id = Guid.NewGuid();
                        objAppLog.Message = "LoremIpsumMessage";
                        objAppLog.TimeStamp = DateTime.Now;
                        objAppLog.UserId = "amjad.leghari";
                        objAppLog.ApplicationMaster = unitOfWork.ApplicationMasterRepository.SelectByID(Constants.ApplicationId);
                        objAppLog.ApplicationEventMaster = unitOfWork.ApplicationEventMasterRepository.SelectByID(Constants.EventType.Standard_Xml_Validation_Failed);
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
                var xPath = xpath.Reverse().Aggregate(string.Empty, (x, y) => x + "/" + y);
                if (!xPath.Contains(obj.Name))
                    xPath += String.Format("/{0}", obj.Name);
                Console.Write("XPath: ");
                Console.WriteLine(xPath);

                #region ErrorXml DB Entry
                    if (currentErrorXml == null)
                    {
                        currentErrorXml = new ErrorXml();
                        currentErrorXml.Id = Guid.NewGuid();
                        currentErrorXml.TimeStamp = DateTime.Now;
                        currentErrorXml.Warehouse_Code = "dummyWHCode";
                        currentErrorXml.XmlContent = this.inProcessXML;
                        currentErrorXml.Client_Code = "dummyClientCode";
                        currentErrorXml.DocumentUniqueId = String.IsNullOrEmpty(this.varOrderNumber) ? "dummy order number" : this.varOrderNumber;
                        currentErrorXml.OrderDate = DateTime.ParseExact("20180503", "yyyyMMdd", CultureInfo.InvariantCulture);
                        currentErrorXml.DocumentType = this.varDocumentType;
                        unitOfWork.ErrorXmlRepository.Insert(currentErrorXml);
                        unitOfWork.Save();
                    }
                #endregion

                #region ErrorInboundData DB Entry
                    ErrorInboundData objErrInbound = new ErrorInboundData();
                    objErrInbound.Id = Guid.NewGuid();
                    objErrInbound.IsRectifiable = false;
                    objErrInbound.SysErrorMsg = e.Message;
                    objErrInbound.CustomErrorMsg = "not available";
                    objErrInbound.TimeStamp = DateTime.Now;
                    objErrInbound.DataKey = obj.Name;
                    objErrInbound.DataValue = obj.Value;
                    objErrInbound.DataPath = xpath.Reverse().Aggregate(string.Empty, (x, y) => x + "/" + y);
                    objErrInbound.DataType = dataType;
                    objErrInbound.ErrorType = "not available";
                    objErrInbound.ErrorXml = unitOfWork.ErrorXmlRepository.SelectByID(currentErrorXml.Id);

                    unitOfWork.ErrorInboundRepository.Insert(objErrInbound);
                    unitOfWork.Save();
                #endregion

                #region ErrorSuggestion DB Entry
                
                Error_Suggestion_InboundData_Mapper esidmapObj = new Error_Suggestion_InboundData_Mapper();
                    esidmapObj.Id = Guid.NewGuid();
                    switch (objErrInbound.DataType.ToLower())
                    {
                       case "integer":      esidmapObj.ErrorSuggestionId = Constants.Suggestions.XSD_Invalid_Integer;
                                            break;
                        case "float":       esidmapObj.ErrorSuggestionId = Constants.Suggestions.XSD_Invalid_Float;
                                            break;
                        case "datetime":    esidmapObj.ErrorSuggestionId = Constants.Suggestions.XSD_Invalid_DateTime;
                                            break;
                        case "boolean":     esidmapObj.ErrorSuggestionId = Constants.Suggestions.XSD_Invalid_Boolean;
                                            break;
                        case "duplicate elements":  esidmapObj.ErrorSuggestionId = Constants.Suggestions.XSD_Duplicate_Element;
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
    }
}
