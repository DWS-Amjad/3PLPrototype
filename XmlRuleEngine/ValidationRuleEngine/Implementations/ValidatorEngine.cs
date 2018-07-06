using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using ValidationRuleEngine.Interfaces;

namespace ValidationRuleEngine.Implementations
{
    public class ValidatorEngine : IEngine
    {
        private ConfigurationStore configurationStore = new ConfigurationStore();
        private List<IEngine> validatorList = new List<IEngine>();
        void IEngine.Configure()
        {
            Helper.XMLHelper<ConfigurationStore>.Instance.UnMarshalingFromXML("../../DataFiles/RuleEngine/RuleEngine.xml", out configurationStore);
            Helper.XMLHelper<ConfigurationStore>.Instance.MarshalingToXML(configurationStore, "../../DataFiles/RuleEngine/RuleEngineOutput.xml");

            if (configurationStore.Items.Count() > 0)
            {
                foreach (var item in configurationStore.Items)
                {
                    if(item.enabled)
                    {
                        if (item.xsd_validation_enabled)
                        {
                            Console.WriteLine("Xsd based Validation configured ===>");
                            validatorList.Add(new XsdValidatorEngine(item));
                        }
                        if (item.custom_validation_enabled)
                        {
                            Console.WriteLine("Custom Validation configured ===>");
                            var configXml = XDocument.Load(item.source_file_path);
                            validatorList.Add(new CustomValidatorEngine(configXml));
                        }
                    }
                }
            }
        }
        
        void IEngine.Start()
        {
            if (validatorList.Count > 0)
            {
                foreach (var item in validatorList)
                {
                    item.Start();
                }
            }
        }

        void IEngine.Stop()
        {
            this.configurationStore = null;
            foreach (var item in this.validatorList)
            {
                item.Stop();
            }
            this.validatorList = null;
        }
    }
}
