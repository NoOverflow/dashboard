using Dashboard.Models.YouTube;
using Newtonsoft.Json;

namespace Dashboard.Services.Widget
{
    public class YouTubeService
    {
        private readonly string _youtubeApiKey;
        private readonly string _youtubeApiBaseUrl;

        private HttpClient HttpClient { get; set; }

        public YouTubeService(IHttpClientFactory httpClientFactory, string apiBaseUrl, string apiKey)
        {
            this.HttpClient = httpClientFactory.CreateClient();
            this._youtubeApiKey = apiKey;
            this._youtubeApiBaseUrl = apiBaseUrl;
        }

        public async Task<SearchResult?> SearchAsync(string query, string type)
        {
            HttpResponseMessage response = await HttpClient.GetAsync(_youtubeApiBaseUrl + 
                $"/search?part=id%2Csnippet&key={_youtubeApiKey}&q={query}&type={type}");

            if (!response.IsSuccessStatusCode)
                return null;
            return JsonConvert.DeserializeObject<SearchResult?>(await response.Content.ReadAsStringAsync());
        }

        public async Task<ChannelListResult?> ListChannelAsync(string channelId)
        {
            HttpResponseMessage response = await HttpClient.GetAsync(_youtubeApiBaseUrl +
                $"/channels?part=id%2Cstatistics&key={_youtubeApiKey}&id={channelId}");

            if (!response.IsSuccessStatusCode)
                return null;
            return JsonConvert.DeserializeObject<ChannelListResult?>(await response.Content.ReadAsStringAsync());
        }
    }
}
