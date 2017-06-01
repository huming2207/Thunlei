using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ThunleiCore.LixianApi.TaskResponse
{
    public class DownloadTask
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("flag")]
        public string Flag { get; set; }

        [JsonProperty("database")]
        public string Database { get; set; }

        [JsonProperty("class_value")]
        public string ClassValue { get; set; }

        [JsonProperty("global_id")]
        public string GlobalId { get; set; }

        [JsonProperty("restype")]
        public string Restype { get; set; }

        [JsonProperty("filesize")]
        public string Filesize { get; set; }

        [JsonProperty("filetype")]
        public string Filetype { get; set; }

        [JsonProperty("cid")]
        public string Cid { get; set; }

        [JsonProperty("gcid")]
        public string Gcid { get; set; }

        [JsonProperty("taskname")]
        public string Taskname { get; set; }

        [JsonProperty("download_status")]
        public string DownloadStatus { get; set; }

        [JsonProperty("speed")]
        public string Speed { get; set; }

        [JsonProperty("progress")]
        public int Progress { get; set; }

        [JsonProperty("used_time")]
        public string UsedTime { get; set; }

        [JsonProperty("left_live_time")]
        public string LeftLiveTime { get; set; }

        [JsonProperty("lixian_url")]
        public string LixianUrl { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("refer_url")]
        public string ReferUrl { get; set; }

        [JsonProperty("cookie")]
        public string Cookie { get; set; }

        [JsonProperty("vod")]
        public string Vod { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("dt_committed")]
        public string DtCommitted { get; set; }

        [JsonProperty("dt_deleted")]
        public string DtDeleted { get; set; }

        [JsonProperty("list_sum")]
        public string ListSum { get; set; }

        [JsonProperty("finish_sum")]
        public string FinishSum { get; set; }

        [JsonProperty("flag_killed_in_a_second")]
        public string FlagKilledInASecond { get; set; }

        [JsonProperty("res_count")]
        public string ResCount { get; set; }

        [JsonProperty("using_res_count")]
        public string UsingResCount { get; set; }

        [JsonProperty("verify_flag")]
        public string VerifyFlag { get; set; }

        [JsonProperty("verify_time")]
        public string VerifyTime { get; set; }

        [JsonProperty("gcid_real")]
        public string GcidReal { get; set; }

        [JsonProperty("progress_class")]
        public string ProgressClass { get; set; }

        [JsonProperty("left_time")]
        public string LeftTime { get; set; }

        [JsonProperty("userid")]
        public int Userid { get; set; }

        [JsonProperty("openformat")]
        public string Openformat { get; set; }

        [JsonProperty("vod_url2")]
        public string VodUrl2 { get; set; }

        [JsonProperty("taskname_show")]
        public string TasknameShow { get; set; }

        [JsonProperty("ext")]
        public string Ext { get; set; }

        [JsonProperty("ext_show")]
        public string ExtShow { get; set; }

        [JsonProperty("tasktype")]
        public int Tasktype { get; set; }

        [JsonProperty("format_img")]
        public string FormatImg { get; set; }

        [JsonProperty("res_count_degree")]
        public int ResCountDegree { get; set; }

        [JsonProperty("ysfilesize")]
        public string Ysfilesize { get; set; }

        [JsonProperty("file_size")]
        public string FileSize { get; set; }

        [JsonProperty("verify")]
        public string Verify { get; set; }

        [JsonProperty("res_type")]
        public string ResType { get; set; }

        [JsonProperty("bt_movie")]
        public int BtMovie { get; set; }

        [JsonProperty("user_type")]
        public string UserType { get; set; }

        [JsonProperty("is_blocked")]
        public int IsBlocked { get; set; }
    }
}
