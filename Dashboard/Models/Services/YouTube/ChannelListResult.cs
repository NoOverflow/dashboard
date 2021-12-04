namespace Dashboard.Models.YouTube
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class ChannelListResult
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("etag")]
        public string Etag { get; set; }

        [JsonProperty("pageInfo")]
        public PageInfo PageInfo { get; set; }

        [JsonProperty("items")]
        public Channel[] Items { get; set; }
    }

    public partial class Channel
    {
        [JsonProperty("statistics")]
        public Statistics Statistics { get; set; }
    }

    public partial class Statistics
    {
        [JsonProperty("viewCount")]
        public long ViewCount { get; set; }

        [JsonProperty("subscriberCount")]
        public long SubscriberCount { get; set; }

        [JsonProperty("hiddenSubscriberCount")]
        public bool HiddenSubscriberCount { get; set; }

        [JsonProperty("videoCount")]
        public long VideoCount { get; set; }
    }
}
