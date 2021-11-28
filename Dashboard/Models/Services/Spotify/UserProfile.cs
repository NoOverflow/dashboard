namespace Dashboard.Models.Spotify
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class UserProfile
    {
        [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
        public string Country { get; set; }

        [JsonProperty("display_name", NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayName { get; set; }

        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }

        [JsonProperty("explicit_content", NullValueHandling = NullValueHandling.Ignore)]
        public ExplicitContent ExplicitContent { get; set; }

        [JsonProperty("followers", NullValueHandling = NullValueHandling.Ignore)]
        public Followers Followers { get; set; }

        [JsonProperty("href", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Href { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("images", NullValueHandling = NullValueHandling.Ignore)]
        public object[] Images { get; set; }

        [JsonProperty("product", NullValueHandling = NullValueHandling.Ignore)]
        public string Product { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("uri", NullValueHandling = NullValueHandling.Ignore)]
        public string Uri { get; set; }
    }

    public partial class ExplicitContent
    {
        [JsonProperty("filter_enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? FilterEnabled { get; set; }

        [JsonProperty("filter_locked", NullValueHandling = NullValueHandling.Ignore)]
        public bool? FilterLocked { get; set; }
    }

    public partial class Followers
    {
        [JsonProperty("href")]
        public object Href { get; set; }

        [JsonProperty("total", NullValueHandling = NullValueHandling.Ignore)]
        public long? Total { get; set; }
    }
}
