using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ThunleiCore.LixianApi.TaskQuery
{
    public class Info
    {
        [JsonProperty("tasks")]
        public List<DownloadTask> Tasks { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("show_arc")]
        public int ShowArc { get; set; }

        [JsonProperty("total_num")]
        public string TotalNum { get; set; }
    }
}
