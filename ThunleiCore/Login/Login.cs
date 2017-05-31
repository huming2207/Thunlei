using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ThunleiCore.Login
{
    public class Login
    {
        private CookieContainer _cookieContainer;

        public Login()
        {
            _cookieContainer = new CookieContainer();
        }

        public Login(CookieContainer container)
        {
            _cookieContainer = container;
        }

        public async Task<LoginResult> RunLogin(string userName, string userPassword)
        {
            
        }

        /// <summary>
        /// Get the CSRF token (Cross Site Reference Token?)
        /// </summary>
        /// <param name="cookieContainer"></param>
        /// <param name="deviceFingerPrint"></param>
        /// <returns>csrf token in 32-char string</returns>
        private async Task<InitialCsrfToken> _GetCsrfToken(CookieContainer cookieContainer, DeviceFingerPrint deviceFingerPrint)
        {
            // Declare HttpClient
            var httpHandler = new HttpClientHandler()
            {
                CookieContainer = cookieContainer
            };

            var httpClient = new HttpClient(httpHandler)
            {
                BaseAddress = new Uri("https://login.xunlei.com")
            };

            // Prepare the signature and submit
            string stringContent = string.Format("xl_fp_raw={0}&xl_fp={1}&xl_fp_sign={2}}&cachetime={3}",
                deviceFingerPrint.DeviceFingerPrintRaw, deviceFingerPrint.DeviceFingerPrintChecksum,
                deviceFingerPrint.DeviceFingerPrintSingature, DateTimeOffset.Now.ToUnixTimeMilliseconds());
            
            // Merge into a POST content
            var postContent = new StringContent(stringContent, Encoding.UTF8, "text/plain");
            
            // Fire the hole!
            var httpResponse = await httpClient.PostAsync(string.Format("/risk?cmd=report", 
                DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString()), postContent);

            // If not successful, return an empty string (to shut up the compiler!)
            if (!httpResponse.IsSuccessStatusCode)
            {
                return new InitialCsrfToken()
                {
                    ErrorMessage = string.Format("HTTP {0} - {1}", ((int) httpResponse.StatusCode).ToString(),
                        httpResponse.ReasonPhrase),

                    IsSuccessful = false
                };
            }
            
            // Get device ID from cookie container
            // The device ID will be granted by Thunder's server (https://login.xunlei.com/risk?cmd=report)
            // The format of a device ID is something like this: 
            //         wdi10.abcabcabcabcabbabcabccabcabceeabcabcaabcabcabcaabcabcaaabcabcabc
            string deviceId = LoginUtils.FindCookieValue(cookieContainer, "deviceid", ".xunlei.com");

            // Then we need to get its MD5 hash, substring from it with length 32 (i.e. get the first 32 chars)
            string csrfToken = LoginUtils.GetMD5(deviceId.Substring(0, 32));

            return new InitialCsrfToken()
            {
                IsSuccessful = true,
                CookieContainer = cookieContainer,
                CsrfToken = csrfToken,
                ErrorMessage = string.Empty
            };
        }
        
    }
}