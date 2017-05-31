using System.Net;

namespace ThunleiCore.Login
{
    public class LoginResult
    {
        public bool HasLoggedIn { get; set; }
        public CookieContainer CookieContainer { get; set; }
        public string ErrorMessage { get; set; }
    }
}