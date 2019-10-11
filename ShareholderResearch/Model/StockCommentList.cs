﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using ShareholderResearch;
//
//    var stockCommentList = StockCommentList.FromJson(jsonString);

namespace ShareholderResearch.Model
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class StockCommentList
    {
        [JsonProperty("TRADECODE")]
        public string Tradecode { get; set; }

        [JsonProperty("STOCKNAME")]
        public string Stockname { get; set; }

        [JsonProperty("TRADEDATE")]
        public DateTimeOffset Tradedate { get; set; }

        [JsonProperty("PCTBUYXL")]
        public double Pctbuyxl { get; set; }

        [JsonProperty("PCTBUYL")]
        public double Pctbuyl { get; set; }

        [JsonProperty("ZB")]
        public double Zb { get; set; }

        [JsonProperty("ZB3RAVG")]
        public double Zb3Ravg { get; set; }

        [JsonProperty("ZB50RAVG")]
        public double Zb50Ravg { get; set; }

        [JsonProperty("JGCYD")]
        public double Jgcyd { get; set; }

        [JsonProperty("FLOWINXL")]
        public long Flowinxl { get; set; }

        [JsonProperty("FLOWOUTXL")]
        public long Flowoutxl { get; set; }

        [JsonProperty("FLOWINL")]
        public long Flowinl { get; set; }

        [JsonProperty("FLOWOUTL")]
        public long Flowoutl { get; set; }

        [JsonProperty("ZLJLR")]
        public long Zljlr { get; set; }
    }

    public partial class StockCommentList
    {
        public static List<StockCommentList> FromJson(string json) => JsonConvert.DeserializeObject<List<StockCommentList>>(json, StockCommentListConverter.Settings);
    }

    public static class StockCommentListSerialize
    {
        public static string ToJson(this List<StockCommentList> self) => JsonConvert.SerializeObject(self, StockCommentListConverter.Settings);
    }

    internal static class StockCommentListConverter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }
}
