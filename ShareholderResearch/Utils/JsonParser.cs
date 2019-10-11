using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ShareholderResearch.Utils
{
    public partial class TopTenShareholderJsonPackage
    {
        [JsonProperty("gdrs", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, string>[] Gdrs { get; set; }

        [JsonProperty("sdltgd", NullValueHandling = NullValueHandling.Ignore)]
        public Sdltgd[] Sdltgd { get; set; }

        [JsonProperty("sdgd", NullValueHandling = NullValueHandling.Ignore)]
        public Sdgd[] Sdgd { get; set; }

        [JsonProperty("jjcg", NullValueHandling = NullValueHandling.Ignore)]
        public Jjcg[] Jjcg { get; set; }

        [JsonProperty("sdgdcgbd", NullValueHandling = NullValueHandling.Ignore)]
        public object[] Sdgdcgbd { get; set; }

        [JsonProperty("xsjj", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, string>[] Xsjj { get; set; }

        [JsonProperty("sdltgd_chart", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, string>[] SdltgdChart { get; set; }

        [JsonProperty("zlcc", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, string>[] Zlcc { get; set; }

        [JsonProperty("zlcc_rz", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset[] ZlccRz { get; set; }
    }

    public partial class Jjcg
    {
        [JsonProperty("rq", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? Rq { get; set; }

        [JsonProperty("jjcg", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, string>[] JjcgJjcg { get; set; }
    }

    public partial class Sdgd
    {
        [JsonProperty("rq", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? Rq { get; set; }

        [JsonProperty("sdgd", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, string>[] SdgdSdgd { get; set; }
    }

    public partial class Sdltgd
    {
        [JsonProperty("rq", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? Rq { get; set; }

        [JsonProperty("sdltgd", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, string>[] SdltgdSdltgd { get; set; }
    }

    public partial class TopTenShareholderJsonParser
    {
        public static TopTenShareholderJsonPackage FromJson(string json) => JsonConvert.DeserializeObject<TopTenShareholderJsonPackage>(json, Converter.Settings);
    }

    public class FinancialReportJsonParser
    {
        public static Dictionary<string, string>[] FromJson(string json) => JsonConvert.DeserializeObject<Dictionary<string, string>[]>(json, Converter.Settings);
    }

    public static class TopTenShareholderSerialize
    {
        public static string ToJson(this TopTenShareholderJsonParser self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    public static class FinancialReportSerialize
    {
        public static string ToJson(this FinancialReportJsonParser self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
