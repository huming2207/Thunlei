using System.Net;

namespace ThunleiCore.Login
{
    public class InitialCsrfToken
    {
        public bool IsSuccessful { get; set; }
        public string CsrfToken { get; set; }
        public string ErrorMessage { get; set; }
    }
}