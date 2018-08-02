using System;
using System.Linq;
using System.Xml.Serialization;
using ValidationRuleEngine;

namespace Customizations
{
    [Serializable]
    [XmlRoot(ElementName = "validation")]
    public class AccelosLookupValidation : ValidationRuleEngine.Implementations.Validation
    {
        public AccelosLookupValidation(string name, string validatorType, bool Enabled, bool on_failure_halt) : base(name, validatorType, Enabled, on_failure_halt)
        {

        }
        public AccelosLookupValidation()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override bool Validate()
        {
            bool retVal = false;
            var companyCode = this.LocalAttributes
                        .Where(item => item.name == Constants.AccellosLookup_Validator.companyCode)
                        .First<ValidationRuleEngine.Configuration.Attribute>().value;

            var orderNumber = this.LocalAttributes
                        .Where(item => item.name == Constants.AccellosLookup_Validator.orderNumber)
                        .First<ValidationRuleEngine.Configuration.Attribute>().value;

            Console.WriteLine("Stay Tuned Folks: AccelosLookupValidation To be implemented soon");
            //var accellosItem = new AccellosDataAccess.Order(companyCode, Convert.ToDecimal(orderNumber));
            //if (accellosItem.IsActive)
            //{
            //    retVal = true;
            //}
            //else
            //{
            //    retVal = false;
            //}
            return (retVal);
        }
    }
}
