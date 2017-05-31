using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ThunleiCore.Login
{
    public class Login
    {
        private CookieContainer _cookieContainer { get; set; }

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
            // Get a random fake device information
            var deviceInfo = RandomDeviceInfoGenerator.GetAllDeviceInfo();
            
            // Get the device fingerprint, it may takes a while.
            var fingerPrintGenerator = new DeviceFingerPrintGenerator();
            var initialResult = await _GetCsrfToken(
                await fingerPrintGenerator.GenerateDeviceFingerPrint(deviceInfo), deviceInfo);
            
            // If it returns a fatal initial result, return a fatal login result too (and then terminate the process)
            if (!initialResult.IsSuccessful)
            {
                return new LoginResult()
                {
                    HasLoggedIn = false,
                    CookieContainer = null,
                    ErrorMessage = initialResult.ErrorMessage
                };
            }
            
            // If process continues, declare HttpClient.
            var httpHandler = new HttpClientHandler()
            {
                CookieContainer = _cookieContainer
            };

            var httpClient = new HttpClient(httpHandler)
            {
                BaseAddress = new Uri("https://login.xunlei.com")
            };
            
            // Prepare the header
            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(deviceInfo.userAgent);
            httpClient.DefaultRequestHeaders.Add("Referer", deviceInfo.referrer);

            // Prepare the POST content
            string stringContent = string.Format("p={0}&u={1}&verifycode=&login_enable=0&business_type=108&v=101&cachetime={2}", 
                userPassword, userName, DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString());

            var postContent = new StringContent(stringContent, Encoding.UTF8, "application/x-www-form-urlencoded");

            // Prepare the query address
            string queryAddress = string.Format("/sec2login/?csrf_token={0}", initialResult.CsrfToken);

            // ...then run POST
            var httpResponse = await httpClient.PostAsync(queryAddress, postContent);

            // Terminate the process if it is not successful.
            if(!httpResponse.IsSuccessStatusCode)
            {
                httpClient.Dispose();
                return new LoginResult()
                {
                    CookieContainer = _cookieContainer,
                    ErrorMessage = httpResponse.ReasonPhrase,
                    HasLoggedIn = false
                };
            }
            else
            {
                httpClient.Dispose();
                return new LoginResult()
                {
                    CookieContainer = _cookieContainer,
                    ErrorMessage = httpResponse.ReasonPhrase,
                    HasLoggedIn = true
                };
            }
            
        }

        private async Task<InitialCsrfToken> _GetCsrfToken(DeviceFingerPrint deviceFingerPrint, RandomDeviceInfo randomDeviceInfo)
        {
            // Declare HttpClient
            var httpHandler = new HttpClientHandler()
            {
                CookieContainer = _cookieContainer
            };

            var httpClient = new HttpClient(httpHandler)
            {
                BaseAddress = new Uri("https://login.xunlei.com")
            };
            
            // Prepare the header
            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(randomDeviceInfo.userAgent);
            httpClient.DefaultRequestHeaders.Add("Referer", randomDeviceInfo.referrer);

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
                httpClient.Dispose();
                
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
            string deviceId = LoginUtils.FindCookieValue(_cookieContainer, "deviceid", ".xunlei.com");

            // Then we need to get its MD5 hash, substring from it with length 32 (i.e. get the first 32 chars)
            string csrfToken = LoginUtils.GetMD5(deviceId.Substring(0, 32));

            // Dispose the http client and return
            httpClient.Dispose();
            
            return new InitialCsrfToken()
            {
                IsSuccessful = true,
                CsrfToken = csrfToken,
                ErrorMessage = string.Empty
            };
        }
        
    }
}