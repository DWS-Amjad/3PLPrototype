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

        public static readonly int ApplicationId = 1;

        public static class ExecuteOn
        {
            public static readonly string success = "success";
            public static readonly string failure = "failure";
        }
    }
}