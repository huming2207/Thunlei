using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ThunleiCore.LixianApi.TaskResponse
{
    public class ThunderLixianResponse
    {
        [JsonProperty("rtcode")]
        public int Rtcode { get; set; }

        [JsonProperty("info")]
        public Info Info { get; set; }

        [JsonProperty("global_new")]
        public GlobalNew GlobalNew { get; set; }

        [JsonProperty("userinfo")]
        public UserInfo Userinfo { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }
    }
}
