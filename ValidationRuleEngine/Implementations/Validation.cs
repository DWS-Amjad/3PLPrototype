using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.XPath;
using ValidationRuleEngine.Interfaces;
using ValidationRuleEngine.Configuration;

namespace ValidationRuleEngine.Implementations
{
    [Serializable]
    [XmlRoot(ElementName = "validation")]
    public class Validation: IValidation
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("validator_type")]
        public string validator_type { get; set; }

        [XmlAttribute("enabled")]
        public bool enabled { get; set; }

        [XmlAttribute("on_failure_halt")]
        public bool onFailureHalt { get; set; }

        [XmlArray("actions")]
        [XmlArrayItem("action")]
        public IEnumerable<IAction> Actions
        {
            get;
            set;
        }
        
        #region Local Attributes
            [XmlArray("attributes")]
            [XmlArrayItem("attribute")]
            public List<ValidationRuleEngine.Configuration.Attribute> LocalAttributes;
        #endregion

        protected string inProcessXML;
        protected XDocument currentXml;
        public List<ValidationRuleEngine.Configuration.Attribute> globalAttributesCopy;
        protected string orderNumber;
        protected DateTime orderDate;
        protected string warehouseCode;
        protected string clientCode;
        protected string companyCode;
        protected string varDocumentType;

        public Validation()
        {
            this.LocalAttributes = new List<ValidationRuleEngine.Configuration.Attribute>();
            this.globalAttributesCopy = new List<ValidationRuleEngine.Configuration.Attribute>();
        }
        /// <summary>
        /// 
        /// </summary>
        public Validation(string name, string validatorType, bool Enabled, bool on_failure_halt)
        {
            this.Name = name;
            this.validator_type = validatorType;
            this.enabled = Enabled;
            this.onFailureHalt = on_failure_halt;

            this.LocalAttributes = new List<ValidationRuleEngine.Configuration.Attribute>();
            this.globalAttributesCopy = new List<ValidationRuleEngine.Configuration.Attribute>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ClientCode"></param>
        /// <param name="CompanyCode"></param>
        /// <param name="WarehouseCode"></param>
        /// <param name="OrderNumber"></param>
        /// <param name="OrderDate"></param>
        /// <param name="DocumentType"></param>
        public void setupMandatoryFields(string ClientCode, string CompanyCode, 
            string WarehouseCode, string OrderNumber, string OrderDate, string DocumentType)
        {
            try
            {
                this.varDocumentType = DocumentType;
                this.globalAttributesCopy.Clear();
                ValidationRuleEngine.Configuration.Attribute customVariable = new ValidationRuleEngine.Configuration.Attribute();
                this.clientCode = ClientCode;
                customVariable.enabled = true;
                customVariable.name = Constants.MandatoryField_NameTags.ClientCode;
                customVariable.path = "";
                customVariable.value = this.clientCode;
                customVariable.is_rectifiable = false;
                this.globalAttributesCopy.Add(customVariable);

                customVariable = new ValidationRuleEngine.Configuration.Attribute();
                this.companyCode = CompanyCode;
                customVariable.enabled = true;
                customVariable.name = Constants.MandatoryField_NameTags.CompanyCode;
                customVariable.path = "";
                customVariable.value = this.companyCode;
                customVariable.is_rectifiable = false;
                this.globalAttributesCopy.Add(customVariable);

                customVariable = new ValidationRuleEngine.Configuration.Attribute();
                this.warehouseCode = WarehouseCode;
                customVariable.enabled = true;
                customVariable.name = Constants.MandatoryField_NameTags.WarehouseCode;
                customVariable.path = "";
                customVariable.value = this.warehouseCode;
                customVariable.is_rectifiable = false;
                this.globalAttributesCopy.Add(customVariable);

                customVariable = new ValidationRuleEngine.Configuration.Attribute();
                this.orderNumber = OrderNumber;
                customVariable.enabled = true;
                customVariable.name = Constants.MandatoryField_NameTags.OrderNumber;
                customVariable.path = "";
                customVariable.value = this.orderNumber;
                customVariable.is_rectifiable = false;
                this.globalAttributesCopy.Add(customVariable);

                customVariable = new ValidationRuleEngine.Configuration.Attribute();
                this.orderDate = (this.globalAttributesCopy.Where(field => field.name == Constants.MandatoryField_NameTags.OrderDate).Count() == 0)
                            ? DateTime.Now
                            : DateTime.ParseExact(this.globalAttributesCopy
                                                    .Where(field => field.name == Constants.MandatoryField_NameTags.OrderDate)
                                                    .First<ValidationRuleEngine.Configuration.Attribute>().value, "yyyyMMdd", CultureInfo.InvariantCulture);
                customVariable.enabled = true;
                customVariable.name = Constants.MandatoryField_NameTags.OrderDate;
                customVariable.path = "";
                customVariable.value = this.orderDate.ToShortDateString();
                customVariable.is_rectifiable = false;
                this.globalAttributesCopy.Add(customVariable);
            }
            catch (Exception ex)
            {
                Logger.Instance.GetLogInstance().Error(JsonConvert.SerializeObject(ex));
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual bool Validate()
        {  
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xpathNavigator"></param>
        public void LoadLocalAttributesValues(XPathNavigator xpathNavigator)
        {
            XPathNodeIterator xPathIterator;
            foreach (var item in this.LocalAttributes)
            {
                if (String.IsNullOrEmpty(item.value))
                {
                    if (!String.IsNullOrEmpty(item.path))
                    { 
                        xPathIterator = xpathNavigator.Select(item.path);
                        if (xPathIterator.Count > 0)
                        {
                            while (xPathIterator.MoveNext())
                            {
                                this.LocalAttributes.Where(field => field.name == item.name)
                                    .First<ValidationRuleEngine.Configuration.Attribute>().value = xPathIterator.Current.Value.Trim();
                            }
                        }
                        else
                        {
                            Console.WriteLine(String.Format("\"{0}\" path found in XML Document.", item.path));
                        }
                    }
                }                
            }
        }

        /// <summary>
        /// This method takes 2 attributes. 
        /// Firstly creates a local copy of globalAttributes and then populates its values.
        /// Secondly it populates localAttributeValues
        /// </summary>
        /// <param name="globalAttributes"></param>
        /// <param name="currXDocument"></param>
        public void LoadGlobalAttributeValues(List<ValidationRuleEngine.Configuration.Attribute> globalAttributes, XDocument currXDocument)
        {
            try
            {
                this.currentXml = currXDocument;
                this.globalAttributesCopy = globalAttributes;
                //this.varDocumentType = DocumentType;
                XDocument doc = currXDocument;
                this.inProcessXML = doc.ToString();
                var xpathNavigator = doc.CreateNavigator();

                LoadLocalAttributesValues(xpathNavigator);

                XPathNodeIterator xPathIterator;
                foreach (var item in globalAttributesCopy)
                {
                    if(String.IsNullOrEmpty(item.value))
                    {
                        if (!String.IsNullOrEmpty(item.path))
                        {
                            xPathIterator = xpathNavigator.Select(item.path);
                            if (xPathIterator.Count > 0)
                            {
                                while (xPathIterator.MoveNext())
                                {
                                    this.globalAttributesCopy.First(field => field.name == item.name).value = xPathIterator.Current.Value.Trim();
                                }
                            }
                            else
                            {
                                Console.WriteLine(String.Format("\"{0}\" path found in XML Document.", item.path));
                            }
                        }
                    }
                }
                this.companyCode = this.globalAttributesCopy
                                    .Where(field => field.name == Constants.MandatoryField_NameTags.CompanyCode)
                                    .First<ValidationRuleEngine.Configuration.Attribute>().value;
                this.warehouseCode = this.globalAttributesCopy
                                    .Where(field => field.name == Constants.MandatoryField_NameTags.WarehouseCode)
                                    .First<ValidationRuleEngine.Configuration.Attribute>().value;
                this.clientCode = this.globalAttributesCopy
                                  .Where(field => field.name == Constants.MandatoryField_NameTags.ClientCode)
                                  .First<ValidationRuleEngine.Configuration.Attribute>().value;
                this.varDocumentType = this.globalAttributesCopy
                                        .Where(field => field.name == Constants.MandatoryField_NameTags.DocumentType)
                                        .First<ValidationRuleEngine.Configuration.Attribute>().value;
                this.orderNumber = this.globalAttributesCopy
                                    .Where(field => field.name == Constants.MandatoryField_NameTags.OrderNumber)
                                    .First<ValidationRuleEngine.Configuration.Attribute>().value;
                this.orderDate = this.orderDate = (this.globalAttributesCopy.Where(field => field.name == Constants.MandatoryField_NameTags.OrderDate).Count() == 0)
                            ? DateTime.Now
                            : DateTime.ParseExact(this.globalAttributesCopy
                                                    .Where(field => field.name == Constants.MandatoryField_NameTags.OrderDate)
                                                    .First<ValidationRuleEngine.Configuration.Attribute>().value, "yyyyMMdd", CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                Logger.Instance.GetLogInstance().Error(JsonConvert.SerializeObject(ex));
            }
            
        }
    }
}
