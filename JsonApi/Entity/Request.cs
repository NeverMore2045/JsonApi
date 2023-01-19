namespace JsonApi.Entity
{
    public class Request
    {
        public int Id { get; set; }
        public string Time { get; set; }
        public string NameRequest { get; set; }
        public Request()
        {
            Id = 0;
            Time = string.Empty;
            NameRequest = string.Empty;
        }
        public Request(string time,string nameRequest)
        {
            Time = time;
            NameRequest = nameRequest;
        }
    }
}
