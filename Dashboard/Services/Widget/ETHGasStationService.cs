using Dashboard.Models.ETH;
using Newtonsoft.Json;

namespace Dashboard.Services.Widget
{
    public class ETHGasStationService
    {
        private readonly string _ethGasStationApiKey;
        private readonly string _ethGasStationApiBaseUrl;

        private HttpClient HttpClient { get; set; }

        public ETHGasStationService(IHttpClientFactory httpClientFactory, string apiBaseUrl, string apiKey)
        {
            this.HttpClient = httpClientFactory.CreateClient();
            this._ethGasStationApiKey = apiKey;
            this._ethGasStationApiBaseUrl = apiBaseUrl;
        }

        public async Task<GasPrice?> GetGasPriceAsync()
        {
            HttpResponseMessage response = await HttpClient.GetAsync(_ethGasStationApiBaseUrl +
                $"/api/ethgasAPI.json?api-key={_ethGasStationApiKey}");

            if (!response.IsSuccessStatusCode)
                return null;
            return JsonConvert.DeserializeObject<GasPrice?>(await response.Content.ReadAsStringAsync());
        }
    }
}
