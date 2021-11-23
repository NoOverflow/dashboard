using System.Text.Json.Serialization;

namespace Dashboard.Models
{
    [Serializable]
    public class Client
    {
        [JsonPropertyName("host")]
        public string? HostIp { get; set; }
    }

    [Serializable]
    public class Server
    {
        [JsonPropertyName("current_time")]
        public long CurrentTime { get; set; }

        [JsonPropertyName("services")]
        public Service[] Services { get; set; }
    }

    [Serializable]
    public class About
    {
        [JsonPropertyName("client")]
        public Client Client { get; set; }

        [JsonPropertyName("server")]
        public Server Server { get; set; }
    }
}
