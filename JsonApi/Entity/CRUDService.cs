namespace JsonApi.Entity
{
    public class CRUDService
    {
        private JsonApiDbContext JsonApiContext { get; set; }
        public CRUDService(JsonApiDbContext jsonApiDb)
        {
            JsonApiContext = jsonApiDb;
        }
        public List<KnownHost> GetAllHosts()
        {
            return JsonApiContext.KnownHosts.ToList();
        }
        public List<Request> GetAllRequests()
        {
            return JsonApiContext.Requests.ToList();
        }
        public KnownHost AddKnownHost(KnownHost knownHost)
        {
            if (JsonApiContext.KnownHosts.FirstOrDefault(host => host.NameHost == knownHost.NameHost) == null)
            {
                JsonApiContext.KnownHosts.Add(knownHost);
                JsonApiContext.SaveChanges();
                return knownHost;
            }
            return null;
        }
        public Request AddRequest(Request request)
        {
            JsonApiContext.Requests.Add(request);
            JsonApiContext.SaveChanges();
            return request;
        }
    }
}
