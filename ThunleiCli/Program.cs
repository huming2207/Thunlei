using System;
using System.Collections.Generic;
using System.Net;
using ThunleiCore.Login;
using ThunleiCore.LixianApi;

namespace ThunleiCli
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("User ID: ");
            string userName = Console.ReadLine();
            Console.Write("\nPassword: ");
            string password = Console.ReadLine();
            
            Console.WriteLine("\n\n[INFO] Logging in...");
            var thunleiLogin = new Login(new CookieContainer());
            var loginResult = thunleiLogin.RunLogin(userName, password).Result;

            if (loginResult.HasLoggedIn)
            {
                Console.WriteLine("[INFO] Login command executed successfully.");
            }
            else
            {
                Console.WriteLine("[INFO] Login failed, reason: {0}", loginResult.ErrorMessage);
                Environment.Exit(1);
            }

            var lixianApi = new LixianApi(loginResult);
            var lixianQueryResult = lixianApi.TaskListQuery().Result;

            Console.Read();
        }
    }
}