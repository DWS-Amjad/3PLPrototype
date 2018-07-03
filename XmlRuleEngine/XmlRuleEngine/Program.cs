using System;
using System.Configuration;
using System.Xml.Linq;
using ValidationRuleEngine;

namespace XmlRuleEngine.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configFilePath = ConfigurationManager.AppSettings["ConfigXmlPath"];
            if (String.IsNullOrEmpty(configFilePath))
            {
                throw new Exception(@"XML Configuration file path is not set in ""ConfigXmlPath"" configuration");
            }

            var configXml = XDocument.Load(configFilePath);

            var ruleEngine = new Engine(configXml);
            Console.WriteLine("Configuring Engine....");
            ruleEngine.Configure();
            Console.WriteLine("Engine Configurtion finished.");

            // read sample xml to validate
            var sampleXml = XDocument.Load("SampleXml1.xml");

            Console.WriteLine("Starting Engine....");
            ruleEngine.Start(sampleXml);
            Console.WriteLine("Engine start finished.");

            Console.WriteLine("Stopping Engine....");
            ruleEngine.Stop();

            Console.WriteLine("Engine stopped.");
            Console.ReadLine();
        }
    }
}
