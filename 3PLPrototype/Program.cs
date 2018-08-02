using System;
using System.Net.Mail;
using ValidationRuleEngine.Implementations;
using ValidationRuleEngine.Interfaces;
using System.Xml.Linq;
using Newtonsoft.Json;
using System.Configuration;
using ValidationRuleEngine;

namespace _3PLPrototype
{
    class Program
    {
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static void Main(string[] args)
        {
            //SalesOrders salesOrders = new SalesOrders();
            //XMLHelper<SalesOrders>.Instance.UnMarshalingFromXML("../../DataFiles/SalesOrder/Sample_SO[8303].xml", out salesOrders);
            //XMLHelper<SalesOrders>.Instance.MarshalingToXML(salesOrders, "../../DataFiles/SalesOrder/SalesOrderOutput.xml");

            //XMLHelper<SalesOrders>.Instance.UnMarshalingFromXML("../../SalesOrder1.xml", out salesOrders);
            //XMLHelper<SalesOrders>.Instance.MarshalingToXML(salesOrders, "../../SalesOrder1Output.xml");

            //string path = System.Reflection.Assembly.GetExecutingAssembly().Location;

            ////To get the location the assembly normally resides on disk or the install directory
            //string path1 = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;

            ////once you have the path you get the directory with:
            //var directory = System.IO.Path.GetDirectoryName(path);
            //directory = System.IO.Path.GetDirectoryName(path1);
            //SendEmail();
            //STEInterfacesEntities entities = new STEInterfacesEntities();
            //LocationRepository locRepository = new LocationRepository(entities);

            //IGenericRepository<Location_SYD> locationRepository = new GenericRepository<Location_SYD>();
            //IEnumerable<Location_SYD> locations = locationRepository.SelectAll();
            //LocationCustomRepository locCustomRepo = new LocationCustomRepository();


            //Location_SYD obj = locCustomRepo.SelectByLocationAndPostCodeAndState("CALLIGNEE SOUTH", "3844", "VIC");
            //Console.WriteLine(obj.location);
            //List<Location_SYD> list = locRepository.GetLocation("4817", "WILLOWS (TOWNSVILLE)", "QLD");

            try
            {
                //Customizations.XsdValidation instance = (Customizations.XsdValidation)Activator.CreateInstance(type);
                //Validation val = new Validation();
                //throw new Exception("testing Logger");
                string source_file_path = "../../DataFiles/SalesOrder/Sample_SO[8303].xml";
                XDocument doc = XDocument.Load(source_file_path);
                IEngine validatorEngine = new ValidatorEngine(doc);
                validatorEngine.Validation();
                Console.ReadKey();
                //Console.WriteLine(Constants.EventType.Validation_Engine_Configured);
                //Console.WriteLine(Constants.EventType.Validation_Engine_Started);
                //Console.WriteLine(Constants.EventType.Validation_Engine_Stopped);

                //Console.WriteLine(Constants.EventType.Standard_Xml_Validation_Started);
                //Console.WriteLine(Constants.EventType.Standard_Xml_Validation_Succeeded);
                //Console.WriteLine(Constants.EventType.Standard_Xml_Validation_Failed);

                //Console.WriteLine(Constants.LocationMatch.WithoutModification);
                //Console.WriteLine(Constants.LocationMatch.StripParenthesis);
                //Console.WriteLine(Constants.LocationMatch.MatchStringAfterSpace);
                //Console.WriteLine(Constants.LocationMatch.MatchFirst5Chars);

                //Console.WriteLine(Constants.ApplicationId);

                //Console.WriteLine(Constants.ExecuteOn.success); 
                //Console.WriteLine(Constants.ExecuteOn.failure);

                //Console.WriteLine(Constants.Suggestions.InvalidSuburb);
                //Console.WriteLine(Constants.Suggestions.InvalidPostCode);
                //Console.WriteLine(Constants.Suggestions.InvalidState);
                //Console.WriteLine(Constants.Suggestions.InvalidSuburbPostCodeState);

                //Console.WriteLine(Constants.Suggestions.XSD_Invalid_Integer);
                //Console.WriteLine(Constants.Suggestions.XSD_Invalid_Float);
                //Console.WriteLine(Constants.Suggestions.XSD_Invalid_DateTime);
                //Console.WriteLine(Constants.Suggestions.XSD_Invalid_Boolean);
                //Console.WriteLine(Constants.Suggestions.XSD_Duplicate_Element);
                //Console.WriteLine(Constants.Suggestions.XSD_Invalid_String);

                //Console.WriteLine(Constants.MandatoryField_NameTags.WarehouseCode);
                //Console.WriteLine(Constants.MandatoryField_NameTags.ClientCode);
                //Console.WriteLine(Constants.MandatoryField_NameTags.CompanyCode);
                //Console.WriteLine(Constants.MandatoryField_NameTags.OrderNumber);
                //Console.WriteLine(Constants.MandatoryField_NameTags.OrderDate);
                //Console.WriteLine(Constants.MandatoryField_NameTags.DocumentType);

                //Console.WriteLine(Constants.LengthValidation_CustomFields.OrderNumber);
                //Console.WriteLine(Constants.AddressValidator_CustomFields.postCode);
                //Console.WriteLine(Constants.AddressValidator_CustomFields.location);
                //Console.WriteLine(Constants.AddressValidator_CustomFields.state);

                //Console.WriteLine(Constants.XsdValidator_CustomFields.xsd_file_path);
                //Console.WriteLine(Constants.XsdValidator_CustomFields.xsd_ns);



            }
            catch (Exception ex)
            {
                Logger.Instance.GetLogInstance().Error(JsonConvert.SerializeObject(ex));
            }
            

            //var configFilePath = ConfigurationManager.AppSettings["ConfigXmlPath"];
            //if (String.IsNullOrEmpty(configFilePath))
            //{
            //    throw new Exception(@"XML Configuration file path is not set in ""ConfigXmlPath"" configuration");
            //}
            //var configXml = XDocument.Load(configFilePath);

            //Console.WriteLine("Configuring CustomValidatorEngineObsolete....");
            //ruleEngine.Configure();
            //Console.WriteLine("CustomValidatorEngineObsolete Configurtion finished.");

            //// read sample xml to validate
            //var sampleXml = XDocument.Load("SampleXml1.xml");

            //Console.WriteLine("Starting CustomValidatorEngineObsolete....");
            //ruleEngine.StartValidation(sampleXml);
            //Console.WriteLine("CustomValidatorEngineObsolete start finished.");

            //Console.WriteLine("Stopping CustomValidatorEngineObsolete....");
            //ruleEngine.Stop();

            //Console.WriteLine("CustomValidatorEngineObsolete stopped.");
            //Console.ReadLine();


            //Console.ReadKey();
        }


        


        static public bool SendEmail()
        {
            bool retVal = true;
            try
            {
                String userName = "Amjad.Leghari@ncat.nsw.gov.au";//"Amjad.Leghari@startrack.com.au";
                String password = "June2018";//"Welcome34452";
                MailMessage msg = new MailMessage("Amjad.Leghari@ncat.nsw.gov.au", "amjadleghari@hotmail.com");
                msg.Subject = "test email";
                msg.IsBodyHtml = true;
                msg.Body = "Hello World";

                SmtpClient SmtpClient = new SmtpClient();
                SmtpClient.UseDefaultCredentials = false;
                SmtpClient.Credentials = new System.Net.NetworkCredential(userName, password);
                SmtpClient.Host = "smtp.office365.com";
                SmtpClient.Port = 587;

                SmtpClient.EnableSsl = true;

                SmtpClient.Send(msg);
            }
            catch (Exception)
            {
                retVal = false;
                throw;
                //Logger.Instance.GetLogInstance().Error(JsonConvert.SerializeObject(ex));
            }
            return retVal;
        }

        /*static void Main()
        {
            Console.WriteLine("Hello World");
            
            using (STEInterfacesEntities context = new STEInterfacesEntities())
            {
                ApplicationEventMasterRepository repo1 = new ApplicationEventMasterRepository(context);
                ApplicationMasterRepository repo2 = new ApplicationMasterRepository(context);
                ApplicationLogRepository repo3 = new ApplicationLogRepository(context);


                List<ApplicationEventMaster> eventMasters = repo1.SelectAll();
                List<ApplicationMaster> applicationMaster = repo2.SelectAll();
                //ApplicationMaster obj1 = new ApplicationMaster();
                //obj1.Name = "application-5";
                //obj1.IsActive = true;
                //obj1.LastUpdatedBy = "amjad.leghari";
                //obj1.LastUpdatedDate = DateTime.Now;
                //obj1.CreatedBy = "amjad.leghari";
                //obj1.CreatedDate = DateTime.Now;
                //ApplicationMasterRepository.Instance.Create(obj1);
                //ApplicationMasterRepository.Instance.Save();
                //ApplicationMaster obj = ApplicationMasterRepository.Instance.SelectById(2);
                //obj.Name = "application-1";
                //obj.IsActive = true;

                //ApplicationMasterRepository.Instance.Update(obj);
                //ApplicationMasterRepository.Instance.Save();

                //ApplicationMasterRepository.Instance.Delete(2);
                //ApplicationMasterRepository.Instance.Save();

                ApplicationLog log = new ApplicationLog();
                for (int i = 0; i < 4; i++)
                {
                    log = new ApplicationLog();
                    log.Id = Guid.NewGuid();
                    log.ApplicationMaster = applicationMaster[i];
                    log.ApplicationEventMaster = eventMasters[i];

                    log.Message = String.Format("Message-{0}", i + 1);
                    log.TimeStamp = DateTime.Now;
                    log.UserId = "Amjad";
                    repo3.Create(log);
                    repo3.Save();
                }
            }
            
            
            //List<ApplicationLog> logs = repo3.SelectAll();



            //StartXsdValidator(@"..\..\DataFiles\books.xsd", @"..\..\DataFiles\books.xml", booksSettingsValidationEventHandler);
            //bookstore xmlObject;
            //XmlDocument xmlDocument;
            //XMLHelper<bookstore>.Instance.UnMarshalingFromXML(@"..\..\DataFiles\books.xml", out xmlObject);
            //XMLHelper<bookstore>.Instance.MarshalingToXMLDocument(xmlObject, out xmlDocument);
            //XmlSchemaSet schemas = new XmlSchemaSet();
            //schemas.Add("http://www.contoso.com/books", @"..\..\DataFiles\books.xsd");
            //bool errors = false;
            ////XDocument 
            //XDocument xDocument = new XDocument();
            //xmlDocument.Validate((o, e) => 
            //{
            //    Console.WriteLine("{0}",e.Message);
            //    errors = true;
            //});
            Console.ReadKey();
        }
        */


    }
}

