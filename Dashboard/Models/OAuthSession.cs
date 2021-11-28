using Dashboard.Areas.Identity.Data;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Dashboard.Models
{
    public class OAuthSession
    {
        [Key]
        public Guid SessionId { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonIgnore]
        public Services.ServiceType ServiceType { get; set; }

        [JsonIgnore]
        public string DashboardUserId { get; set; }

        [JsonIgnore]
        public virtual DashboardUser User { get; set; }
    }
}
