namespace Dashboard.Models
{
    public class OAuthConfiguration
    {
        public string Secret { get; set; }
        public string Id { get; set; }
        public string RedirectUrl { get; set; }
        public IEnumerable<string> Scopes { get; set; }
        public string AuthorizeUrl { get; set; }
        public string TokenUrl { get; set; }
    }
}
