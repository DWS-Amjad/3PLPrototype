using System;
using System.Xml.Linq;

namespace ValidationRuleEngine.Interfaces
{
    public interface IValidation
    {
        string Name { get; set; }

        string validator_type { get; set; }

        bool enabled { get; set; }
        
        bool Validate(Object obj, XDocument currXDocument, string documentType, string orderNumber, string orderDate);

        void LoadOrderVariables(XDocument currXDocument, string DocumentType, string order_number_path, string order_date_path);
    }
}
