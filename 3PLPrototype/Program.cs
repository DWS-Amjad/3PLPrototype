using System;
using ValidationRuleEngine.Implementations;
using ValidationRuleEngine.Interfaces;

namespace _3PLPrototype
{
    class Program
    {

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

            IEngine validatorEngine = new ValidatorEngine();
            validatorEngine.Configure();
            validatorEngine.Start();
            validatorEngine.Stop();
            Console.ReadKey();

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
            //ruleEngine.Start(sampleXml);
            //Console.WriteLine("CustomValidatorEngineObsolete start finished.");

            //Console.WriteLine("Stopping CustomValidatorEngineObsolete....");
            //ruleEngine.Stop();

            //Console.WriteLine("CustomValidatorEngineObsolete stopped.");
            //Console.ReadLine();
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

