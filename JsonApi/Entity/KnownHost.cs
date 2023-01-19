namespace JsonApi.Entity
{
    public class KnownHost
    {
        public int Id { get; set; }
        public string NameHost { get; set; }
        public KnownHost() 
        {
            Id = 0;
            NameHost = string.Empty;
        }
        public KnownHost(string nameHost)
        {
            NameHost = nameHost;
        }
    }
}
