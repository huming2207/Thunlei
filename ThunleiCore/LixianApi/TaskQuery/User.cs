using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ThunleiCore.LixianApi.TaskQuery
{
    public class User
    {
        [JsonProperty("expire_date")]
        public string ExpireDate { get; set; }

        [JsonProperty("max_task_num")]
        public string MaxTaskNum { get; set; }

        [JsonProperty("max_store")]
        public string MaxStore { get; set; }

        [JsonProperty("vip_store")]
        public string VipStore { get; set; }

        [JsonProperty("buy_store")]
        public string BuyStore { get; set; }

        [JsonProperty("xz_store")]
        public string XzStore { get; set; }

        [JsonProperty("buy_num_task")]
        public string BuyNumTask { get; set; }

        [JsonProperty("buy_num_connection")]
        public string BuyNumConnection { get; set; }

        [JsonProperty("buy_bandwidth")]
        public string BuyBandwidth { get; set; }

        [JsonProperty("buy_task_live_time")]
        public string BuyTaskLiveTime { get; set; }

        [JsonProperty("experience_expire_date")]
        public string ExperienceExpireDate { get; set; }

        [JsonProperty("available_space")]
        public string AvailableSpace { get; set; }

        [JsonProperty("total_num")]
        public string TotalNum { get; set; }

        [JsonProperty("history_task_total_num")]
        public string HistoryTaskTotalNum { get; set; }

        [JsonProperty("suspending_num")]
        public string SuspendingNum { get; set; }

        [JsonProperty("downloading_num")]
        public string DownloadingNum { get; set; }

        [JsonProperty("waiting_num")]
        public string WaitingNum { get; set; }

        [JsonProperty("complete_num")]
        public string CompleteNum { get; set; }

        [JsonProperty("store_period")]
        public string StorePeriod { get; set; }

        [JsonProperty("cookie")]
        public string Cookie { get; set; }

        [JsonProperty("vip_level")]
        public string VipLevel { get; set; }

        [JsonProperty("user_type")]
        public string UserType { get; set; }

        [JsonProperty("goldbean_num")]
        public string GoldbeanNum { get; set; }

        [JsonProperty("convert_flag")]
        public string ConvertFlag { get; set; }

        [JsonProperty("silverbean_num")]
        public string SilverbeanNum { get; set; }

        [JsonProperty("special_net")]
        public string SpecialNet { get; set; }

        [JsonProperty("total_filter_num")]
        public string TotalFilterNum { get; set; }

        [JsonProperty("used_space_gb")]
        public string UsedSpaceGb { get; set; }

        [JsonProperty("used_space")]
        public long UsedSpace { get; set; }

        [JsonProperty("isp")]
        public bool Isp { get; set; }

        [JsonProperty("experience_left_days")]
        public int ExperienceLeftDays { get; set; }

        [JsonProperty("vip_expiredate")]
        public string VipExpiredate { get; set; }

        [JsonProperty("vip_left_days")]
        public int VipLeftDays { get; set; }

        [JsonProperty("expire_date_show")]
        public string ExpireDateShow { get; set; }
    }
}
