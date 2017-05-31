using System.Dynamic;

namespace ThunleiCore.Login
{
    public class RandomDeviceInfo
    {
        public RandomDeviceInfo(string userAgent, string screenRes, string colorDepth, string platform, string referrer)
        {
            this.userAgent = userAgent;
            this.screenRes = screenRes;
            this.colorDepth = colorDepth;
            this.platform = platform;
            this.referrer = referrer;
        }
       

        public string userAgent { get; set; }
        public string screenRes { get; set; }
        public string colorDepth { get; set; }
        public string platform { get; set; }
        public string referrer { get; set; }
    }
}