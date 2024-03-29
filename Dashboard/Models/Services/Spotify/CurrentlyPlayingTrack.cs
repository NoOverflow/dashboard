﻿namespace Dashboard.Models.Spotify
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class CurrentlyPlayingTrack
    {
        [JsonProperty("timestamp", NullValueHandling = NullValueHandling.Ignore)]
        public long? Timestamp { get; set; }

        [JsonProperty("context", NullValueHandling = NullValueHandling.Ignore)]
        public Context? Context { get; set; }

        [JsonProperty("progress_ms", NullValueHandling = NullValueHandling.Ignore)]
        public long? ProgressMs { get; set; }

        [JsonProperty("item", NullValueHandling = NullValueHandling.Ignore)]
        public Item? Item { get; set; }

        [JsonProperty("currently_playing_type", NullValueHandling = NullValueHandling.Ignore)]
        public string? CurrentlyPlayingType { get; set; }

        [JsonProperty("actions", NullValueHandling = NullValueHandling.Ignore)]
        public Actions? Actions { get; set; }

        [JsonProperty("is_playing", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsPlaying { get; set; }
    }

    public partial class Actions
    {
        [JsonProperty("disallows", NullValueHandling = NullValueHandling.Ignore)]
        public Disallows? Disallows { get; set; }
    }

    public partial class Disallows
    {
        [JsonProperty("resuming", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Resuming { get; set; }
    }

    public partial class Context
    {
        [JsonProperty("external_urls", NullValueHandling = NullValueHandling.Ignore)]
        public ExternalUrls? ExternalUrls { get; set; }

        [JsonProperty("href", NullValueHandling = NullValueHandling.Ignore)]
        public Uri? Href { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string? Type { get; set; }

        [JsonProperty("uri", NullValueHandling = NullValueHandling.Ignore)]
        public string? Uri { get; set; }
    }

    public partial class ExternalUrls
    {
        [JsonProperty("spotify", NullValueHandling = NullValueHandling.Ignore)]
        public Uri? Spotify { get; set; }
    }

    public partial class Item
    {
        [JsonProperty("album", NullValueHandling = NullValueHandling.Ignore)]
        public Album? Album { get; set; }

        [JsonProperty("artists", NullValueHandling = NullValueHandling.Ignore)]
        public Artist[]? Artists { get; set; }

        [JsonProperty("available_markets", NullValueHandling = NullValueHandling.Ignore)]
        public string[]? AvailableMarkets { get; set; }

        [JsonProperty("disc_number", NullValueHandling = NullValueHandling.Ignore)]
        public long? DiscNumber { get; set; }

        [JsonProperty("duration_ms", NullValueHandling = NullValueHandling.Ignore)]
        public long? DurationMs { get; set; }

        [JsonProperty("explicit", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Explicit { get; set; }

        [JsonProperty("external_ids", NullValueHandling = NullValueHandling.Ignore)]
        public ExternalIds? ExternalIds { get; set; }

        [JsonProperty("external_urls", NullValueHandling = NullValueHandling.Ignore)]
        public ExternalUrls? ExternalUrls { get; set; }

        [JsonProperty("href", NullValueHandling = NullValueHandling.Ignore)]
        public Uri? Href { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string? Id { get; set; }

        [JsonProperty("is_local", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsLocal { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string? Name { get; set; }

        [JsonProperty("popularity", NullValueHandling = NullValueHandling.Ignore)]
        public long? Popularity { get; set; }

        [JsonProperty("preview_url", NullValueHandling = NullValueHandling.Ignore)]
        public Uri? PreviewUrl { get; set; }

        [JsonProperty("track_number", NullValueHandling = NullValueHandling.Ignore)]
        public long? TrackNumber { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string? Type { get; set; }

        [JsonProperty("uri", NullValueHandling = NullValueHandling.Ignore)]
        public string? Uri { get; set; }
    }

    public partial class Album
    {
        [JsonProperty("album_type", NullValueHandling = NullValueHandling.Ignore)]
        public string? AlbumType { get; set; }

        [JsonProperty("artists", NullValueHandling = NullValueHandling.Ignore)]
        public Artist[]? Artists { get; set; }

        [JsonProperty("available_markets", NullValueHandling = NullValueHandling.Ignore)]
        public string[]? AvailableMarkets { get; set; }

        [JsonProperty("external_urls", NullValueHandling = NullValueHandling.Ignore)]
        public ExternalUrls? ExternalUrls { get; set; }

        [JsonProperty("href", NullValueHandling = NullValueHandling.Ignore)]
        public Uri? Href { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string? Id { get; set; }

        [JsonProperty("images", NullValueHandling = NullValueHandling.Ignore)]
        public Image[]? Images { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string? Name { get; set; }

        [JsonProperty("release_date", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? ReleaseDate { get; set; }

        [JsonProperty("release_date_precision", NullValueHandling = NullValueHandling.Ignore)]
        public string? ReleaseDatePrecision { get; set; }

        [JsonProperty("total_tracks", NullValueHandling = NullValueHandling.Ignore)]
        public long? TotalTracks { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string? Type { get; set; }

        [JsonProperty("uri", NullValueHandling = NullValueHandling.Ignore)]
        public string? Uri { get; set; }
    }

    public partial class Artist
    {
        [JsonProperty("external_urls", NullValueHandling = NullValueHandling.Ignore)]
        public ExternalUrls? ExternalUrls { get; set; }

        [JsonProperty("href", NullValueHandling = NullValueHandling.Ignore)]
        public Uri? Href { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string? Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string? Name { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string? Type { get; set; }

        [JsonProperty("uri", NullValueHandling = NullValueHandling.Ignore)]
        public string? Uri { get; set; }
    }

    public partial class Image
    {
        [JsonProperty("height", NullValueHandling = NullValueHandling.Ignore)]
        public long? Height { get; set; }

        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public Uri? Url { get; set; }

        [JsonProperty("width", NullValueHandling = NullValueHandling.Ignore)]
        public long? Width { get; set; }
    }

    public partial class ExternalIds
    {
        [JsonProperty("isrc", NullValueHandling = NullValueHandling.Ignore)]
        public string? Isrc { get; set; }
    }
}
