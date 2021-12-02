namespace Dashboard.Models.NYTimes
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Sections
    {
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        [JsonProperty("copyright", NullValueHandling = NullValueHandling.Ignore)]
        public string Copyright { get; set; }

        [JsonProperty("num_results", NullValueHandling = NullValueHandling.Ignore)]
        public long? NumResults { get; set; }

        [JsonProperty("results", NullValueHandling = NullValueHandling.Ignore)]
        public SectionResult[] Results { get; set; }
    }

    public partial class SectionResult
    {
        [JsonProperty("section", NullValueHandling = NullValueHandling.Ignore)]
        public string Section { get; set; }

        [JsonProperty("display_name", NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayName { get; set; }
    }
}
