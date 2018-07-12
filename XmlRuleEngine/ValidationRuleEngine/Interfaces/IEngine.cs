namespace ValidationRuleEngine.Interfaces
{
    public interface IEngine
    {
        //XDocument ConfigXmlDocument { get; }

        //IEnumerable<IRule> Rules { get; }

        void Configure();
        void Start();
        //void Start(XDocument xmlDocument);

        void Stop();
    }
}
