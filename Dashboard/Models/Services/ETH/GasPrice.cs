namespace Dashboard.Models.ETH
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class GasPrice
    {
        [JsonProperty("fast")]
        public long Fast { get; set; }

        [JsonProperty("fastest")]
        public long Fastest { get; set; }

        [JsonProperty("safeLow")]
        public long SafeLow { get; set; }

        [JsonProperty("average")]
        public long Average { get; set; }

        [JsonProperty("block_time")]
        public double BlockTime { get; set; }

        [JsonProperty("blockNum")]
        public long BlockNum { get; set; }

        [JsonProperty("speed")]
        public double Speed { get; set; }

        [JsonProperty("safeLowWait")]
        public double SafeLowWait { get; set; }

        [JsonProperty("avgWait")]
        public double AvgWait { get; set; }

        [JsonProperty("fastWait")]
        public double FastWait { get; set; }

        [JsonProperty("fastestWait")]
        public double FastestWait { get; set; }

        [JsonProperty("gasPriceRange")]
        public Dictionary<string, double> GasPriceRange { get; set; }
    }
}
