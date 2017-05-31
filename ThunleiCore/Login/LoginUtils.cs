using System;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Collections;
using System.Reflection;
using System.Linq;

namespace ThunleiCore.Login
{
    public class LoginUtils
    {
        public static string GetMD5(string fingerPrint)
        {
            var md5 = MD5.Create();
            
            // Get string byte and then return
            byte[] textToHash = Encoding.UTF8.GetBytes(fingerPrint);
            byte[] md5Byte = md5.ComputeHash(textToHash);
            
            // Convert back to string
            return BitConverter.ToString(md5Byte);
        }

        public static string FindCookieValue(CookieContainer cookieContainer, string cookieName, string uri)
        {
            var cookieEnumerables = cookieContainer.GetCookies(new Uri(uri)).Cast<Cookie>();

            foreach (var cookie in cookieEnumerables)
            {
                if (cookie.Name.Equals(cookieName))
                {
                    return cookie.Value;
                }
            }

            return string.Empty;
        }
    }
}