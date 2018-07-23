using System;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.XPath;
using ValidationRuleEngine.Interfaces;

namespace ValidationRuleEngine.Implementations
{
    [Serializable]
    [XmlRoot(ElementName = "validation")]
    public abstract class Validation: IValidation
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("validator_type")]
        public string validator_type { get; set; }

        [XmlAttribute("enabled")]
        public bool enabled { get; set; }

        protected string inProcessXML;
        protected string varOrderNumber;
        protected string varOrderDate;
        protected string varDocumentType;

        public Validation()
        {
        }

        public virtual bool Validate(Object obj, XDocument currXDocument, string documentType, string orderNumber, string orderDate)
        {
            
            LoadOrderVariables(currXDocument, documentType, orderNumber, orderDate);
            return true;
        }


        public void LoadOrderVariables(XDocument currXDocument, string DocumentType, string order_number_path, string order_date_path)
        {
            this.varDocumentType = DocumentType;
            XDocument doc = currXDocument;
            this.inProcessXML = doc.ToString();
            var xpathNavigator = doc.CreateNavigator();

            XPathNodeIterator xPathOrderNumber = xpathNavigator.Select(order_number_path);
            if (xPathOrderNumber.Count > 0)
            {
                while (xPathOrderNumber.MoveNext())
                {
                    this.varOrderNumber = xPathOrderNumber.Current.Value.Trim();
                }
            }

            XPathNodeIterator xPathOrderDate = xpathNavigator.Select(order_date_path);
            if (xPathOrderDate.Count > 0)
            {
                while (xPathOrderDate.MoveNext())
                {
                    this.varOrderDate = xPathOrderDate.Current.Value.Trim();
                }
            }
        }

    }
}
