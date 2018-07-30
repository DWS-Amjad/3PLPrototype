using System;
using System.Xml.Linq;
namespace ValidationRuleEngine.Interfaces
{
    public interface IEngine
    {
        void Configure();

        Boolean Validation();
     
        void Stop();
    }
}
