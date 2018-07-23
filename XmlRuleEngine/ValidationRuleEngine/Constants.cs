using System;
namespace ValidationRuleEngine
{
    public static class Constants
    {
        public static class EventType
        {
            public static readonly int Validation_Engine_Configured = 1;
            public static readonly int Validation_Engine_Started = 2;
            public static readonly int Validation_Engine_Stopped = 3;
            public static readonly int Standard_Xml_Validation_Started = 4;
            public static readonly int Standard_Xml_Validation_Succeeded = 5;
            public static readonly int Standard_Xml_Validation_Failed = 9;
        }

        public static class LocationMatch
        {
            public static readonly int WithoutModification = 0;
            public static readonly int StripParenthesis = 1;
            public static readonly int MatchStringAfterSpace = 2;
            public static readonly int MatchFirst5Chars = 3;
        }

        public static readonly int ApplicationId = 1;

        public static class ExecuteOn
        {
            public static readonly string success = "success";
            public static readonly string failure = "failure";
        }

        public static class Suggestions
        {
            public static readonly Guid InvalidSuburb = Guid.Parse("5a61d5c0-398e-e811-8aa2-3cf862661632");
            public static readonly Guid InvalidPostCode = Guid.Parse("493f0ace-398e-e811-8aa2-3cf862661632");
            public static readonly Guid InvalidState = Guid.Parse("cd7803e4-398e-e811-8aa2-3cf862661632");
            public static readonly Guid InvalidSuburbPostCodeState = Guid.Parse("5947d7ae-398e-e811-8aa2-3cf862661632");
            public static readonly Guid XSD_Invalid_Integer = Guid.Parse("8bd1ae88-3a8e-e811-8aa2-3cf862661632");
            public static readonly Guid XSD_Invalid_Float = Guid.Parse("2850b2d5-3a8e-e811-8aa2-3cf862661632");
            public static readonly Guid XSD_Invalid_DateTime = Guid.Parse("1b43d9c0-3a8e-e811-8aa2-3cf862661632");
            public static readonly Guid XSD_Invalid_Boolean = Guid.Parse("05f4369e-3a8e-e811-8aa2-3cf862661632");
            public static readonly Guid XSD_Duplicate_Element = Guid.Parse("31a5811d-3b8e-e811-8aa2-3cf862661632");
        }
    }
}