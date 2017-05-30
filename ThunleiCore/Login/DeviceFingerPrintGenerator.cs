using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Security.Cryptography;

using Jint;

namespace ThunleiCore.Login
{
    public class DeviceFingerPrintGenerator
    {
        public async Task<DeviceFingerPrint> GenerateDeviceFingerPrint()
        {
            string deviceFingerPrintRaw = _GenerateDeviceFingerPrintRaw();
            
            return new DeviceFingerPrint(deviceFingerPrintRaw, 
                await _GetFingerPrintSignature(deviceFingerPrintRaw), _GetMD5(deviceFingerPrintRaw));
        }

        private string _GenerateDeviceFingerPrintRaw()
        {
            string userAgent = RandomDeviceInfo.GetRandomUserAgent();
            string screenRes = RandomDeviceInfo.GetRandomResolution();
            string colorDepth = RandomDeviceInfo.GetRandomColorDepth();
            string userPlatform = RandomDeviceInfo.GetPlatform(userAgent);
            
            var fingerPrintList = new List<string>()
            {
                userAgent,        // User agent
                "zh-CN",          // Language
                colorDepth,       // Color depth
                screenRes,        // Screen resolution
                "-480",           // Timezone offset (Anyway, let's pretend to be in China lol)
                "true",           // (Pretend to have) session storage
                "true",           // (Pretend to have) local storage
                "true",           // (Pretend to have) indexed database
                "undefined",      // typeof document.body.addBehavior
                "function",       // typeof window.openDatabase()
                "undefined",      // navigator.cpuClass
                userPlatform,     // navigator.platform
                "1",              // "Do Not Track" flag (but the Big Brother is still watching you anyway...)
                
                // List of browser plugin, just make a FAKE NEWS and return.
                "Widevine Content Decryption Module::Enables Widevine " +        
                "licenses for playback of HTML audio/video content. (ver" +
                "sion: 1.4.8.970)::application/x-ppapi-widevine-cdm~;" +
                "Chrome PDF Viewer::::application/pdf~pdf;Native Client:" +
                ":::application/x-nacl~,application/x-pnacl~;Chrome PDF " +
                "Viewer::Portable Document Format::application/x-google-chrome-pdf~pdf"
                
            };

            
            // Encode the string to UTF-8 Base64 string and return.
            var fingerPrintBytes = Encoding.UTF8.GetBytes(string.Join("###", fingerPrintList.ToArray()));
            return Convert.ToBase64String(fingerPrintBytes);
        

        private async Task<string> _GetFingerPrintSignature(string fingerPrint)
        {
            // Initialize HTTP client and set base URL
            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://login.xunlei.com")
            };
            
            // Get the Javascript to string
            string magicJavaScript = await httpClient.GetStringAsync(
                string.Format("/risk?cmd=algorithm&t={0}", DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString()));
            
            // Parse and run this magic JavaScript...
            var javaScriptMethod = new Engine().Execute(magicJavaScript);
            var javaScriptResult = javaScriptMethod.Invoke("xl_al", fingerPrint);
            
            // Return the signature
            return javaScriptResult.AsString();
        }
        
        private string _GetMD5(string fingerPrint)
        {
            var md5 = MD5.Create();
            
            // Get string byte and then return
            byte[] textToHash = Encoding.UTF8.GetBytes(fingerPrint);
            byte[] md5Byte = md5.ComputeHash(textToHash);
            
            // Convert back to string
            return BitConverter.ToString(md5Byte);
        }

     }
}