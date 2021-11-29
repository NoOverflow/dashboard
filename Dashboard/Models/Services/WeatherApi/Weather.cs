namespace Dashboard.Models.WeatherApi
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Weather
    {
        [JsonProperty("location", NullValueHandling = NullValueHandling.Ignore)]
        public Location Location { get; set; }

        [JsonProperty("current", NullValueHandling = NullValueHandling.Ignore)]
        public Current Current { get; set; }
    }

    public partial class Current
    {
        [JsonProperty("last_updated_epoch", NullValueHandling = NullValueHandling.Ignore)]
        public long? LastUpdatedEpoch { get; set; }

        [JsonProperty("last_updated", NullValueHandling = NullValueHandling.Ignore)]
        public string LastUpdated { get; set; }

        [JsonProperty("temp_c", NullValueHandling = NullValueHandling.Ignore)]
        public long? TempC { get; set; }

        [JsonProperty("temp_f", NullValueHandling = NullValueHandling.Ignore)]
        public double? TempF { get; set; }

        [JsonProperty("is_day", NullValueHandling = NullValueHandling.Ignore)]
        public long? IsDay { get; set; }

        [JsonProperty("condition", NullValueHandling = NullValueHandling.Ignore)]
        public Condition Condition { get; set; }

        [JsonProperty("wind_mph", NullValueHandling = NullValueHandling.Ignore)]
        public double? WindMph { get; set; }

        [JsonProperty("wind_kph", NullValueHandling = NullValueHandling.Ignore)]
        public long? WindKph { get; set; }

        [JsonProperty("wind_degree", NullValueHandling = NullValueHandling.Ignore)]
        public long? WindDegree { get; set; }

        [JsonProperty("wind_dir", NullValueHandling = NullValueHandling.Ignore)]
        public string WindDir { get; set; }

        [JsonProperty("pressure_mb", NullValueHandling = NullValueHandling.Ignore)]
        public long? PressureMb { get; set; }

        [JsonProperty("pressure_in", NullValueHandling = NullValueHandling.Ignore)]
        public double? PressureIn { get; set; }

        [JsonProperty("precip_mm", NullValueHandling = NullValueHandling.Ignore)]
        public double? PrecipMm { get; set; }

        [JsonProperty("precip_in", NullValueHandling = NullValueHandling.Ignore)]
        public long? PrecipIn { get; set; }

        [JsonProperty("humidity", NullValueHandling = NullValueHandling.Ignore)]
        public long? Humidity { get; set; }

        [JsonProperty("cloud", NullValueHandling = NullValueHandling.Ignore)]
        public long? Cloud { get; set; }

        [JsonProperty("feelslike_c", NullValueHandling = NullValueHandling.Ignore)]
        public double? FeelslikeC { get; set; }

        [JsonProperty("feelslike_f", NullValueHandling = NullValueHandling.Ignore)]
        public long? FeelslikeF { get; set; }

        [JsonProperty("vis_km", NullValueHandling = NullValueHandling.Ignore)]
        public long? VisKm { get; set; }

        [JsonProperty("vis_miles", NullValueHandling = NullValueHandling.Ignore)]
        public long? VisMiles { get; set; }

        [JsonProperty("uv", NullValueHandling = NullValueHandling.Ignore)]
        public long? Uv { get; set; }

        [JsonProperty("gust_mph", NullValueHandling = NullValueHandling.Ignore)]
        public double? GustMph { get; set; }

        [JsonProperty("gust_kph", NullValueHandling = NullValueHandling.Ignore)]
        public double? GustKph { get; set; }
    }

    public partial class Condition
    {
        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }

        [JsonProperty("icon", NullValueHandling = NullValueHandling.Ignore)]
        public string Icon { get; set; }

        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public long? Code { get; set; }
    }

    public partial class Location
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("region", NullValueHandling = NullValueHandling.Ignore)]
        public string Region { get; set; }

        [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
        public string Country { get; set; }

        [JsonProperty("lat", NullValueHandling = NullValueHandling.Ignore)]
        public double? Lat { get; set; }

        [JsonProperty("lon", NullValueHandling = NullValueHandling.Ignore)]
        public double? Lon { get; set; }

        [JsonProperty("tz_id", NullValueHandling = NullValueHandling.Ignore)]
        public string TzId { get; set; }

        [JsonProperty("localtime_epoch", NullValueHandling = NullValueHandling.Ignore)]
        public long? LocaltimeEpoch { get; set; }

        [JsonProperty("localtime", NullValueHandling = NullValueHandling.Ignore)]
        public string Localtime { get; set; }
    }
}
