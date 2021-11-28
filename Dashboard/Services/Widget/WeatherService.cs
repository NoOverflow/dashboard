using Dashboard.Models.WeatherApi;
using Newtonsoft.Json;

namespace Dashboard.Services.Widget
{
    public class WeatherService
    {
        private readonly string _weatherApiKey;
        private readonly string _weatherApiBaseUrl;

        private HttpClient HttpClient { get; set; }

        public WeatherService(IHttpClientFactory httpClientFactory, string weatherApiBaseUrl, string weatherApiKey)
        {
            this.HttpClient = httpClientFactory.CreateClient();
            this._weatherApiKey = weatherApiKey;
            this._weatherApiBaseUrl = weatherApiBaseUrl;
        }

        public async Task<Weather?> GetWeatherAsync(string city)
        {
            HttpResponseMessage response = await HttpClient.GetAsync(_weatherApiBaseUrl + $"/v1/current.json?key={_weatherApiKey}&q={city}&aqi=no");
            
            if (!response.IsSuccessStatusCode)
                return null;
            return JsonConvert.DeserializeObject<Weather?>(await response.Content.ReadAsStringAsync());
        }
    }
}
