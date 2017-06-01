using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ThunleiCore.LixianApi.TaskResponse
{
    public class GlobalNew
    {
        [JsonProperty("speed")]
        public int Speed { get; set; }

        [JsonProperty("page")]
        public string Page { get; set; }

        [JsonProperty("download_all_task_ids")]
        public string DownloadAllTaskIds { get; set; }

        [JsonProperty("download_task_ids")]
        public string DownloadTaskIds { get; set; }

        [JsonProperty("download_nm_task_ids")]
        public string DownloadNmTaskIds { get; set; }

        [JsonProperty("download_bt_task_ids")]
        public string DownloadBtTaskIds { get; set; }
    }
}
