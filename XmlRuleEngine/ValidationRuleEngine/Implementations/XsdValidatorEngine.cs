using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using DAL.Repository;
using DAL.Models;
using ValidationRuleEngine.Interfaces;

namespace ValidationRuleEngine.Implementations
{
    public class XsdValidatorEngine : IEngine
    {
        private STEInterfacesEntities entities = new STEInterfacesEntities();
        private bool errorDetected = false;
        private ErrorXml currentErrorXml;
        private string inProcessXML;
        private Config config = new Config();

        private ApplicationLogRepository repoAppLog;
        private ApplicationEventMasterRepository repoEventMaster;
        private ApplicationMasterRepository repoApplicationMaster;
        private ErrorInboundDataRepository repoErrInbound;
        private ErrorXmlRepository repoErrorXml;
        private ErrorSuggestionRepository repoErrSuggestion;

        public XsdValidatorEngine(Config configObj)
        {
            this.config = configObj;
            repoAppLog = new ApplicationLogRepository(entities);
            repoEventMaster = new ApplicationEventMasterRepository(entities);
            repoApplicationMaster = new ApplicationMasterRepository(entities);
            repoErrInbound = new ErrorInboundDataRepository(entities);
            repoErrorXml = new ErrorXmlRepository(entities);
            repoErrSuggestion = new ErrorSuggestionRepository(entities);
        }

        void IEngine.Configure()
        {
            #region ApplicationLogEntries
                

                ApplicationLog obj = new ApplicationLog();
            
                obj.Id = Guid.NewGuid();
                obj.Message = "LoremIpsumMessage";
                obj.TimeStamp = DateTime.Now;
                obj.UserId = "amjad.leghari";
                obj.ApplicationMaster = repoApplicationMaster.SelectById(Constants.ApplicationId);
                obj.ApplicationEventMaster = repoEventMaster.SelectById(Constants.EventType.Validation_Engine_Configured);
                repoAppLog.Create(obj);
                repoAppLog.Save();
            #endregion
        }

        void IEngine.Start()
        {
            //if (this.configStore.Items.Count() > 0)
            {
                //foreach (var item in configStore.Items)
                {
                    Console.WriteLine("Xsd based Validation started ===>");
                                        
                    if (config.xsd_validation_enabled)
                    {
                        //XSD_Based_Validation("http://www.contoso.com/books", @"..\..\DataFiles\books.xsd", @"..\..\DataFiles\books.xml");
                        XSD_Based_Validation("", config.xsd_file_path, config.source_file_path);
                    }
                    Console.WriteLine("<=== routine ended.");
                }
            }

            #region ApplicationLogEntries
                ApplicationLog obj = new ApplicationLog();
                obj.Id = Guid.NewGuid();
                obj.Message = "LoremIpsumMessage";
                obj.TimeStamp = DateTime.Now;
                obj.UserId = "amjad.leghari";
                obj.ApplicationMaster = repoApplicationMaster.SelectById(Constants.ApplicationId);
                obj.ApplicationEventMaster = repoEventMaster.SelectById(Constants.EventType.Validation_Engine_Started);
                repoAppLog.Create(obj);
                repoAppLog.Save();
            #endregion

        }
        

        public void XSD_Based_Validation(string xmlNamespace, string xsdFilePath, string xmlFilePath/*, Action<object, ValidationEventArgs> validationEventHandler*/)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.Schemas.Add(xmlNamespace, xsdFilePath);
            settings.ValidationType = ValidationType.Schema;
            settings.ValidationEventHandler += new ValidationEventHandler(ValidationEventHandler);

            XmlReader reader = XmlReader.Create(xmlFilePath, settings);
            XDocument doc = XDocument.Load(xmlFilePath);

            //inProcessXML = doc.Declaration.ToString() + doc.ToString(SaveOptions.DisableFormatting);
            inProcessXML = doc.ToString();

            #region ApplicationLogEntries
                ApplicationLog obj = new ApplicationLog();
                obj.Id = Guid.NewGuid();
                obj.Message = "LoremIpsumMessage";
                obj.TimeStamp = DateTime.Now;
                obj.UserId = "amjad.leghari";
                obj.ApplicationMaster = repoApplicationMaster.SelectById(Constants.ApplicationId);
                obj.ApplicationEventMaster = repoEventMaster.SelectById(Constants.EventType.Standard_Xml_Validation_Started);
                repoAppLog.Create(obj);
                repoAppLog.Save();

                currentErrorXml = new ErrorXml();
                currentErrorXml.Id = Guid.NewGuid();
                currentErrorXml.TimeStamp = DateTime.Now;
                currentErrorXml.Warehouse_Code = "dummyWHCode";
                currentErrorXml.XmlContent = inProcessXML;
                currentErrorXml.Client_Code = "dummyClientCode";
                currentErrorXml.DocumentUniqueId = "dummyId";
                repoErrorXml.Create(currentErrorXml);
                repoErrorXml.Save();

            #endregion

            while (reader.Read()) {
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
                #region ApplicationLogEntries
                    ApplicationLog obj1 = new ApplicationLog();

                    obj1.Id = Guid.NewGuid();
                    obj1.Message = "LoremIpsumMessage";
                    obj1.TimeStamp = DateTime.Now;
                    obj1.UserId = "amjad.leghari";
                    obj1.ApplicationMaster = repoApplicationMaster.SelectById(Constants.ApplicationId);
                    obj1.ApplicationEventMaster = repoEventMaster.SelectById(Constants.EventType.Standard_Xml_Validation_Succeeded);
                    repoAppLog.Create(obj);
                    repoAppLog.Save();
                #endregion
            }
        }
        private Stack<string> xpath = new Stack<string>();
        private void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
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
                    #region ApplicationLogEntries
                        
                        ApplicationLog objAppLog = new ApplicationLog();
                        objAppLog.Id = Guid.NewGuid();
                        objAppLog.Message = "LoremIpsumMessage";
                        objAppLog.TimeStamp = DateTime.Now;
                        objAppLog.UserId = "amjad.leghari";
                        objAppLog.ApplicationMaster = repoApplicationMaster.SelectById(Constants.ApplicationId);
                        objAppLog.ApplicationEventMaster = repoEventMaster.SelectById(Constants.EventType.Standard_Xml_Validation_Failed);
                        repoAppLog.Create(objAppLog);
                        repoAppLog.Save();
                    #endregion

                }
                Console.Write("ERROR: ");
                Console.WriteLine(e.Message);
                Console.Write("DataKey: ");
                var obj = sender as XmlReader;
                Console.WriteLine(obj.Name);
                //Console.WriteLine(BuildQualifiedElementName(obj, (e.Exception as XmlSchemaValidationException)));
                Console.Write("DataValue: ");
                Console.WriteLine(obj.Value);
                Console.Write("XPath: ");
                Console.WriteLine(xpath.Reverse().Aggregate(string.Empty, (x, y) => x + "/" + y));
                
                ErrorInboundData objErrInbound = new ErrorInboundData();
                objErrInbound.Id = Guid.NewGuid();
                objErrInbound.IsRectifiable = false;
                objErrInbound.SysErrorMsg = e.Message;
                objErrInbound.CustomErrorMsg = "not available";
                objErrInbound.TimeStamp = DateTime.Now;
                objErrInbound.DataKey = obj.Name;
                objErrInbound.DataValue = obj.Value;
                objErrInbound.DataPath = xpath.Reverse().Aggregate(string.Empty, (x, y) => x + "/" + y);
                objErrInbound.DataType = "not available";
                objErrInbound.ErrorType = "not available";
                objErrInbound.ErrorXml = repoErrorXml.SelectById(currentErrorXml.Id);
                
                repoErrInbound.Create(objErrInbound);
                repoErrInbound.Save();
            }            

            //if (sender is XObject)
            {
                //Console.WriteLine(((XObject)sender).GetXPath());
            }
        }

        //private static string BuildQualifiedElementName(XmlReader currentNode, XmlSchemaValidationException exception)
        //{
        //    List<string> path = new List<string>();
        //    XmlNode currNode = exception.SourceObject as XmlNode;
        //    path.Add(currentNode.Name);
        //    //currentNode.pa
        //    while (currNode.ParentNode != null)
        //    {
        //        currNode = currNode.ParentNode;
        //        if (currNode.ParentNode != null)
        //        {
        //            path.Add(currentNode.Name);
        //        }
        //    }
        //    path.Reverse();
        //    return string.Join(".", path.ToArray<string>());
        //}

        void IEngine.Stop()
        {
            #region ApplicationLogEntries
                ApplicationLog obj = new ApplicationLog();
                
                obj.Id = Guid.NewGuid();
                obj.Message = "LoremIpsumMessage";
                obj.TimeStamp = DateTime.Now;
                obj.UserId = "amjad.leghari";
                obj.ApplicationMaster = repoApplicationMaster.SelectById(Constants.ApplicationId);
                obj.ApplicationEventMaster = repoEventMaster.SelectById(Constants.EventType.Validation_Engine_Stopped);
                repoAppLog.Create(obj);
                repoAppLog.Save();
            #endregion

            this.config = null;
        }
    }
}


/*
 var xpath = new Stack<string>();

var settings = new XmlReaderSettings
               {
                   ValidationType = ValidationType.Schema,
                   ValidationFlags = XmlSchemaValidationFlags.ReportValidationWarnings,
               };
MyXmlValidationError error = null;
settings.ValidationEventHandler += (sender, args) => error = ValidationCallback(sender, args);
foreach (var schema in schemas)
{
    settings.Schemas.Add(schema);
}

using (var reader = XmlReader.Create(xmlDocumentStream, settings))
{
    // validation
    while (reader.Read())
    {
        if (reader.NodeType == XmlNodeType.Element)
        {
            xpath.Push(reader.Name);
        }

        if (error != null)
        {
            // set "failing XPath"
            error.XPath = xpath.Reverse().Aggregate(string.Empty, (x, y) => x + "/" + y);

            // your error with XPath now

            error = null;
        }

        if (reader.NodeType == XmlNodeType.EndElement ||
            (reader.NodeType == XmlNodeType.Element && reader.IsEmptyElement))
        {
            xpath.Pop();
        }
    }
}
     */
