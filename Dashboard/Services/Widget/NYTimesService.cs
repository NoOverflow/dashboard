using Dashboard.Models.NYTimes;
using Newtonsoft.Json;

namespace Dashboard.Services.Widget
{
    public class NYTimesService
    {
        private readonly string _apiKey;
        private readonly string _baseUrl;

        private HttpClient HttpClient { get; set; }

        public NYTimesService(IHttpClientFactory httpClientFactory, string baseUrl, string apiKey)
        {
            this._apiKey = apiKey;
            this._baseUrl = baseUrl;
            this.HttpClient = httpClientFactory.CreateClient();
        }

        public async Task<Content?> GetLiveContentAsync(string source, string section)
        {
            string url = _baseUrl + $"/content/{source}/{section}.json?api-key={_apiKey}";
            HttpResponseMessage response = await HttpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return null;
            return JsonConvert.DeserializeObject<Content>(await response.Content.ReadAsStringAsync());
        }

        public async Task<Sections?> GetContentsAsync()
        {
            string url = _baseUrl + $"/content/section-list.json?api-key={_apiKey}";
            HttpResponseMessage response = await HttpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return null;
            return JsonConvert.DeserializeObject<Sections>(await response.Content.ReadAsStringAsync());
        }
    }
}
