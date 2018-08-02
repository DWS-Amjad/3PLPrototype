using System;
using System.Collections.Specialized;
using System.Configuration;

namespace ValidationRuleEngine
{
    public static class Constants
    {
        
        public static class EventType
        {
            public static readonly int Validation_Engine_Configured = int.Parse(ConfigurationManager.AppSettings["Validation_Engine_Configured"]);
            public static readonly int Validation_Engine_Started = int.Parse(ConfigurationManager.AppSettings["Validation_Engine_Started"]);
            public static readonly int Validation_Engine_Stopped = int.Parse(ConfigurationManager.AppSettings["Validation_Engine_Stopped"]);
            public static readonly int Standard_Xml_Validation_Started = int.Parse(ConfigurationManager.AppSettings["Standard_Xml_Validation_Started"]);
            public static readonly int Standard_Xml_Validation_Succeeded = int.Parse(ConfigurationManager.AppSettings["Standard_Xml_Validation_Succeeded"]);
            public static readonly int Standard_Xml_Validation_Failed = int.Parse(ConfigurationManager.AppSettings["Standard_Xml_Validation_Failed"]);
        }

        public static class LocationMatch
        {
            public static readonly int WithoutModification = int.Parse(ConfigurationManager.AppSettings["WithoutModification"]);
            public static readonly int StripParenthesis = int.Parse(ConfigurationManager.AppSettings["StripParenthesis"]);
            public static readonly int MatchStringAfterSpace = int.Parse(ConfigurationManager.AppSettings["MatchStringAfterSpace"]);
            public static readonly int MatchFirst5Chars = int.Parse(ConfigurationManager.AppSettings["MatchFirst5Chars"]);
        }

        public static readonly int ApplicationId = int.Parse(ConfigurationManager.AppSettings["ApplicationId"]);

        public static class ExecuteOn
        {
            public static readonly string success = ConfigurationManager.AppSettings["success"];
            public static readonly string failure = ConfigurationManager.AppSettings["failure"];
        }

        public static class Suggestions
        {
            public static readonly Guid InvalidSuburb = Guid.Parse(ConfigurationManager.AppSettings["InvalidSuburb"]);
            public static readonly Guid InvalidPostCode = Guid.Parse(ConfigurationManager.AppSettings["InvalidPostCode"]);
            public static readonly Guid InvalidState = Guid.Parse(ConfigurationManager.AppSettings["InvalidState"]);
            public static readonly Guid InvalidSuburbPostCodeState = Guid.Parse(ConfigurationManager.AppSettings["InvalidSuburbPostCodeState"]);
            public static readonly Guid XSD_Invalid_Integer = Guid.Parse(ConfigurationManager.AppSettings["XSD_Invalid_Integer"]);
            public static readonly Guid XSD_Invalid_Float = Guid.Parse(ConfigurationManager.AppSettings["XSD_Invalid_Float"]);
            public static readonly Guid XSD_Invalid_DateTime = Guid.Parse(ConfigurationManager.AppSettings["XSD_Invalid_DateTime"]);
            public static readonly Guid XSD_Invalid_Boolean = Guid.Parse(ConfigurationManager.AppSettings["XSD_Invalid_Boolean"]);
            public static readonly Guid XSD_Duplicate_Element = Guid.Parse(ConfigurationManager.AppSettings["XSD_Duplicate_Element"]);
            public static readonly Guid XSD_Invalid_String = Guid.Parse(ConfigurationManager.AppSettings["XSD_Invalid_String"]);
        }


        public static class MandatoryField_NameTags
        {
            public static readonly string WarehouseCode = ConfigurationManager.AppSettings["WarehouseCode"];
            public static readonly string ClientCode = ConfigurationManager.AppSettings["ClientCode"];
            public static readonly string CompanyCode = ConfigurationManager.AppSettings["CompanyCode"];
            public static readonly string OrderNumber = ConfigurationManager.AppSettings["OrderNumber"];
            public static readonly string OrderDate = ConfigurationManager.AppSettings["OrderDate"];
            public static readonly string DocumentType = ConfigurationManager.AppSettings["DocumentType"];
        }

        public static class LengthValidation_CustomFields
        {
            public static readonly string OrderNumber = ConfigurationManager.AppSettings["OrderNumber"];
            public static readonly string Message = ConfigurationManager.AppSettings["lengthValidation_message"];
            public static readonly string Length = ConfigurationManager.AppSettings["lengthValidation_length"];

        }

        public static class AddressValidator_CustomFields
        {
            public static readonly string postCode = ConfigurationManager.AppSettings["postCode"];
            public static readonly string location = ConfigurationManager.AppSettings["location"];
            public static readonly string state = ConfigurationManager.AppSettings["state"];
        }

        public static class EmailAction_CustomFields
        {
            public static readonly string to = ConfigurationManager.AppSettings["to"];
            public static readonly string from = ConfigurationManager.AppSettings["from"];
            public static readonly string subject = ConfigurationManager.AppSettings["subject"];
            public static readonly string message = ConfigurationManager.AppSettings["message"];
            public static readonly string displayName = ConfigurationManager.AppSettings["displayName"];
        }

        public static class AccellosLookup_Validator
        {
            public static readonly string companyCode = ConfigurationManager.AppSettings["companyCode"];
            public static readonly string orderNumber = ConfigurationManager.AppSettings["orderNumber"];
        }

        public static class XsdValidator_CustomFields
        {
            public static readonly string xsd_ns = ConfigurationManager.AppSettings["xsd_ns"];
            public static readonly string xsd_file_path = ConfigurationManager.AppSettings["xsd_file_path"];
        }

    }
}