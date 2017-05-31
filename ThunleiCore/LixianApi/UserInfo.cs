using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ThunleiCore.LixianApi
{
    public class UserInfo
    {
        [JsonProperty("all_space")]
        public string AllSpace { get; set; }

        [JsonProperty("all_used_store")]
        public long AllUsedStore { get; set; }

        [JsonProperty("all_space_format")]
        public string AllSpaceFormat { get; set; }

        [JsonProperty("all_used_format")]
        public string AllUsedFormat { get; set; }

        [JsonProperty("isp")]
        public bool Isp { get; set; }

        [JsonProperty("percent")]
        public string Percent { get; set; }
    }
}
