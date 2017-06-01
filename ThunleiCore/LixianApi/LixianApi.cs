using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ThunleiCore.Login;
using ThunleiCore.LixianApi.TaskResponse;

namespace ThunleiCore.LixianApi
{
    public class LixianApi
    {
        private CookieContainer _CookieContainer;
        private RandomDeviceInfo _RandomDeviceInfo;

        public LixianApi(LoginResult loginResult)
        {
            _CookieContainer = loginResult.CookieContainer;
            _RandomDeviceInfo = loginResult.DeviceInfo;
        }

        public async Task<ThunderLixianResponse> QueryResponse(int taskToGet = 100)
        {
            return await _GetData<ThunderLixianResponse>(
                string.Format("/interface/showtask_unfresh?callback=&type_id=4&page=1&tasknum={0}&p=1&interfrom=task", 
                taskToGet.ToString()));
        }

        private async Task<T> _GetData<T>(string queryPath)
        {
            var httpHandler = new HttpClientHandler()
            {
                CookieContainer = _CookieContainer
            };

            var httpClient = new HttpClient(httpHandler)
            {
                BaseAddress = new Uri("http://dynamic.cloud.vip.xunlei.com")
            };

            // Prepare the header
            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(_RandomDeviceInfo.userAgent);

            // Run GET
            var httpResponse = await httpClient.GetAsync(queryPath);

            string jsonStr = await httpResponse.Content.ReadAsStringAsync();

            // Prepare to parse JSON
            var jsonSettings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Include
            };

            // Convert JSON string to JSON object
            var jsonObject = JsonConvert.DeserializeObject<T>(jsonStr, jsonSettings);
            return jsonObject;
        }
    }
}
