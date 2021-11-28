namespace Dashboard.Models.NYTimes
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Content
    {
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        [JsonProperty("copyright", NullValueHandling = NullValueHandling.Ignore)]
        public string Copyright { get; set; }

        [JsonProperty("num_results", NullValueHandling = NullValueHandling.Ignore)]
        public long? NumResults { get; set; }

        [JsonProperty("results", NullValueHandling = NullValueHandling.Ignore)]
        public Result[] Results { get; set; }
    }

    public partial class Result
    {
        [JsonProperty("slug_name", NullValueHandling = NullValueHandling.Ignore)]
        public string SlugName { get; set; }

        [JsonProperty("section", NullValueHandling = NullValueHandling.Ignore)]
        public string Section { get; set; }

        [JsonProperty("subsection", NullValueHandling = NullValueHandling.Ignore)]
        public string Subsection { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("abstract", NullValueHandling = NullValueHandling.Ignore)]
        public string Abstract { get; set; }

        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Url { get; set; }

        [JsonProperty("byline", NullValueHandling = NullValueHandling.Ignore)]
        public string Byline { get; set; }

        [JsonProperty("thumbnail_standard", NullValueHandling = NullValueHandling.Ignore)]
        public Uri ThumbnailStandard { get; set; }


        [JsonProperty("source", NullValueHandling = NullValueHandling.Ignore)]
        public string? Source { get; set; }

        [JsonProperty("updated_date", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? UpdatedDate { get; set; }

        [JsonProperty("created_date", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? CreatedDate { get; set; }

        [JsonProperty("published_date", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? PublishedDate { get; set; }

        [JsonProperty("first_published_date", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? FirstPublishedDate { get; set; }


        [JsonProperty("kicker", NullValueHandling = NullValueHandling.Ignore)]
        public string Kicker { get; set; }

        [JsonProperty("subheadline", NullValueHandling = NullValueHandling.Ignore)]
        public string Subheadline { get; set; }

        [JsonProperty("des_facet")]
        public string[] DesFacet { get; set; }

        [JsonProperty("org_facet")]
        public string[] OrgFacet { get; set; }

        [JsonProperty("per_facet")]
        public string[] PerFacet { get; set; }

        [JsonProperty("geo_facet")]
        public string[] GeoFacet { get; set; }

        [JsonProperty("related_urls")]
        public object RelatedUrls { get; set; }

    }

    public partial class Multimedia
    {
        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Url { get; set; }

        [JsonProperty("format", NullValueHandling = NullValueHandling.Ignore)]
        public Format? Format { get; set; }

        [JsonProperty("height", NullValueHandling = NullValueHandling.Ignore)]
        public long? Height { get; set; }

        [JsonProperty("width", NullValueHandling = NullValueHandling.Ignore)]
        public long? Width { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public TypeEnum? Type { get; set; }

        [JsonProperty("subtype", NullValueHandling = NullValueHandling.Ignore)]
        public Subtype? Subtype { get; set; }

        [JsonProperty("caption", NullValueHandling = NullValueHandling.Ignore)]
        public string Caption { get; set; }

        [JsonProperty("copyright", NullValueHandling = NullValueHandling.Ignore)]
        public string Copyright { get; set; }
    }

    public enum ItemType { Article };

    public enum MaterialTypeFacet { Letter, LiveBlogPost, News, OpEd };

    public enum Format { MediumThreeByTwo210, MediumThreeByTwo440, Normal, StandardThumbnail };

    public enum Subtype { Photo };

    public enum TypeEnum { Image };

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                ItemTypeConverter.Singleton,
                MaterialTypeFacetConverter.Singleton,
                FormatConverter.Singleton,
                SubtypeConverter.Singleton,
                TypeEnumConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ItemTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(ItemType) || t == typeof(ItemType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "Article")
            {
                return ItemType.Article;
            }
            throw new Exception("Cannot unmarshal type ItemType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (ItemType)untypedValue;
            if (value == ItemType.Article)
            {
                serializer.Serialize(writer, "Article");
                return;
            }
            throw new Exception("Cannot marshal type ItemType");
        }

        public static readonly ItemTypeConverter Singleton = new ItemTypeConverter();
    }

    internal class MaterialTypeFacetConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(MaterialTypeFacet) || t == typeof(MaterialTypeFacet?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Letter":
                    return MaterialTypeFacet.Letter;
                case "Live Blog Post":
                    return MaterialTypeFacet.LiveBlogPost;
                case "News":
                    return MaterialTypeFacet.News;
                case "Op-Ed":
                    return MaterialTypeFacet.OpEd;
            }
            throw new Exception("Cannot unmarshal type MaterialTypeFacet");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (MaterialTypeFacet)untypedValue;
            switch (value)
            {
                case MaterialTypeFacet.Letter:
                    serializer.Serialize(writer, "Letter");
                    return;
                case MaterialTypeFacet.LiveBlogPost:
                    serializer.Serialize(writer, "Live Blog Post");
                    return;
                case MaterialTypeFacet.News:
                    serializer.Serialize(writer, "News");
                    return;
                case MaterialTypeFacet.OpEd:
                    serializer.Serialize(writer, "Op-Ed");
                    return;
            }
            throw new Exception("Cannot marshal type MaterialTypeFacet");
        }

        public static readonly MaterialTypeFacetConverter Singleton = new MaterialTypeFacetConverter();
    }

    internal class FormatConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Format) || t == typeof(Format?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Normal":
                    return Format.Normal;
                case "Standard Thumbnail":
                    return Format.StandardThumbnail;
                case "mediumThreeByTwo210":
                    return Format.MediumThreeByTwo210;
                case "mediumThreeByTwo440":
                    return Format.MediumThreeByTwo440;
            }
            throw new Exception("Cannot unmarshal type Format");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Format)untypedValue;
            switch (value)
            {
                case Format.Normal:
                    serializer.Serialize(writer, "Normal");
                    return;
                case Format.StandardThumbnail:
                    serializer.Serialize(writer, "Standard Thumbnail");
                    return;
                case Format.MediumThreeByTwo210:
                    serializer.Serialize(writer, "mediumThreeByTwo210");
                    return;
                case Format.MediumThreeByTwo440:
                    serializer.Serialize(writer, "mediumThreeByTwo440");
                    return;
            }
            throw new Exception("Cannot marshal type Format");
        }

        public static readonly FormatConverter Singleton = new FormatConverter();
    }

    internal class SubtypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Subtype) || t == typeof(Subtype?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "photo")
            {
                return Subtype.Photo;
            }
            throw new Exception("Cannot unmarshal type Subtype");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Subtype)untypedValue;
            if (value == Subtype.Photo)
            {
                serializer.Serialize(writer, "photo");
                return;
            }
            throw new Exception("Cannot marshal type Subtype");
        }

        public static readonly SubtypeConverter Singleton = new SubtypeConverter();
    }

    internal class TypeEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TypeEnum) || t == typeof(TypeEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "image")
            {
                return TypeEnum.Image;
            }
            throw new Exception("Cannot unmarshal type TypeEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (TypeEnum)untypedValue;
            if (value == TypeEnum.Image)
            {
                serializer.Serialize(writer, "image");
                return;
            }
            throw new Exception("Cannot marshal type TypeEnum");
        }

        public static readonly TypeEnumConverter Singleton = new TypeEnumConverter();
    }
}
