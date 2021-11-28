using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Dashboard.Models
{
    public class OAuthSession
    {
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [Key, JsonIgnore]
        public Services.ServiceType ServiceType { get; set; }
    }
}
