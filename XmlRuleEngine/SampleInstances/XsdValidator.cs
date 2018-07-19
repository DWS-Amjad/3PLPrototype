using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using ValidationRuleEngine;
using ValidationRuleEngine.Interfaces;

namespace SampleInstances
{
    [Serializable]
    [XmlRoot(ElementName = "validation")]
    public class XsdValidator : IValidation
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("validator_type")]
        public string validator_type { get; set; }

        [XmlAttribute("enabled")]
        public bool enabled { get; set; }

        #region Custom Properties
        [XmlElement("xsd_ns")]
            public string xsd_ns { get; set; }

            [XmlElement("xsd_file_path")]
            public string xsd_file_path { get; set; }
        #endregion

        #region privateMembers
        private string inProcessXML;
            private ErrorXml currentErrorXml;
            private bool errorDetected = false;
            private Stack<string> xpath = new Stack<string>();
        #endregion

        #region RepositoryObjectDeclaration
            private IGenericRepository<ApplicationLog> repoAppLog;
            private IGenericRepository<ApplicationEventMaster> repoEventMaster;
            private IGenericRepository<ApplicationMaster> repoApplicationMaster;
            private IGenericRepository<ErrorInboundData> repoErrInbound;
            private IGenericRepository<ErrorXml> repoErrorXml;
            private IGenericRepository<ErrorSuggestion> repoErrSuggestion;
        #endregion

        void Initialize()
        {
            repoAppLog = new GenericRepository<ApplicationLog>();
            repoEventMaster = new GenericRepository<ApplicationEventMaster>();
            repoApplicationMaster = new GenericRepository<ApplicationMaster>();
            repoErrInbound = new GenericRepository<ErrorInboundData>();
            repoErrorXml = new GenericRepository<ErrorXml>();
            repoErrSuggestion = new GenericRepository<ErrorSuggestion>();
        }

        public XsdValidator()
        {
            Initialize();
        }

        bool IValidation.Validate(Object obj)
        {         
            string xmlFilePath = ((string)obj);
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.Schemas.Add(xsd_ns, xsd_file_path);
            settings.ValidationType = ValidationType.Schema;
            settings.ValidationEventHandler += new ValidationEventHandler(ValidationEventHandler);

            XmlReader reader = XmlReader.Create(xmlFilePath, settings);
            XDocument doc = XDocument.Load(xmlFilePath);

            //inProcessXML = doc.Declaration.ToString() + doc.ToString(SaveOptions.DisableFormatting);
            inProcessXML = doc.ToString();

            #region ApplicationLogEntries DB Entry
                ApplicationLog objApplicationLog = new ApplicationLog();
                objApplicationLog.Id = Guid.NewGuid();
                objApplicationLog.Message = "LoremIpsumMessage";
                objApplicationLog.TimeStamp = DateTime.Now;
                objApplicationLog.UserId = "amjad.leghari";
                objApplicationLog.ApplicationMaster = repoApplicationMaster.SelectByID(Constants.ApplicationId);
                objApplicationLog.ApplicationEventMaster = repoEventMaster.SelectByID(Constants.EventType.Standard_Xml_Validation_Started);
                repoAppLog.Insert(objApplicationLog);
                repoAppLog.Save();
            #endregion

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    xpath.Push(reader.Name);
                    //Console.WriteLine("Push ==> " + reader.Name);
                }
                if (reader.NodeType == XmlNodeType.EndElement ||
                    (reader.NodeType == XmlNodeType.Element && reader.IsEmptyElement))
                {
                    xpath.Pop();
                    //Console.WriteLine("Pop ==> " + reader.Name);
                }
            }

            if (!errorDetected)
            {
                #region ApplicationLogEntries DB Entry
                ApplicationLog obj1 = new ApplicationLog();

                obj1.Id = Guid.NewGuid();
                obj1.Message = "LoremIpsumMessage";
                obj1.TimeStamp = DateTime.Now;
                obj1.UserId = "amjad.leghari";
                obj1.ApplicationMaster = repoApplicationMaster.SelectByID(Constants.ApplicationId);
                obj1.ApplicationEventMaster = repoEventMaster.SelectByID(Constants.EventType.Standard_Xml_Validation_Succeeded);
                repoAppLog.Insert(objApplicationLog);
                repoAppLog.Save();
                #endregion
            }
            currentErrorXml = null;
            return !errorDetected;
        }

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
                    #region ApplicationLogEntries DB Entry
                        ApplicationLog objAppLog = new ApplicationLog();
                        objAppLog.Id = Guid.NewGuid();
                        objAppLog.Message = "LoremIpsumMessage";
                        objAppLog.TimeStamp = DateTime.Now;
                        objAppLog.UserId = "amjad.leghari";
                        objAppLog.ApplicationMaster = repoApplicationMaster.SelectByID(Constants.ApplicationId);
                        objAppLog.ApplicationEventMaster = repoEventMaster.SelectByID(Constants.EventType.Standard_Xml_Validation_Failed);
                        repoAppLog.Insert(objAppLog);
                        repoAppLog.Save();
                    #endregion
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
                    Console.WriteLine(obj.SchemaInfo.SchemaElement.ElementSchemaType.Datatype.TypeCode);
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
                        currentErrorXml.XmlContent = inProcessXML;
                        currentErrorXml.Client_Code = "dummyClientCode";
                        currentErrorXml.DocumentUniqueId = "dummyId";
                        repoErrorXml.Insert(currentErrorXml);
                        repoErrorXml.Save();
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
                    objErrInbound.DataType = "not available";
                    objErrInbound.ErrorType = "not available";
                    objErrInbound.ErrorXml = repoErrorXml.SelectByID(currentErrorXml.Id);

                    repoErrInbound.Insert(objErrInbound);
                    repoErrInbound.Save();
                #endregion
            }

            //if (sender is XObject)
            {
                //Console.WriteLine(((XObject)sender).GetXPath());
            }            
        }

    }
}
