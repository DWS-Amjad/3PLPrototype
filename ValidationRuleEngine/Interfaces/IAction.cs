using System;

namespace ValidationRuleEngine.Interfaces
{
    public interface IAction
    {
        string Name { get; set; }

        string executeOn { get; set; }

        bool Execute(Object obj);

        bool enabled { get; set; }
    }
}
