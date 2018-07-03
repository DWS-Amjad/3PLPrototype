using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using ValidationRuleEngine.Rules;

namespace ValidationRuleEngine
{
    public class XsdValidatorEngine : IEngine
    {
        //XDocument IEngine.ConfigXml => throw new NotImplementedException();

        //IEnumerable<IRule> IEngine.Rules => throw new NotImplementedException();

        private Config config = new Config();
        public XsdValidatorEngine(Config configObj)
        {
            this.config = configObj;
        }
        void IEngine.Configure()
        {
            
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
        }
        

        public void XSD_Based_Validation(string xmlNamespace, string xsdFilePath, string xmlFilePath/*, Action<object, ValidationEventArgs> validationEventHandler*/)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.Schemas.Add(xmlNamespace, xsdFilePath);
            settings.ValidationType = ValidationType.Schema;
            settings.ValidationEventHandler += new ValidationEventHandler(ValidationEventHandler);

            XmlReader reader = XmlReader.Create(xmlFilePath, settings);

            while (reader.Read()) { }
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
                Console.Write("ERROR: ");
                Console.WriteLine(e.Message);
            }
        }
        
        void IEngine.Stop()
        {
            this.config = null;
        }
    }
}
