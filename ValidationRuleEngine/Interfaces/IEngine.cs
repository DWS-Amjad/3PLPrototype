using System;
namespace ValidationRuleEngine.Interfaces
{
    public interface IEngine
    {
        void Configure();

        Boolean Validation();
     
        void Stop();
    }
}
