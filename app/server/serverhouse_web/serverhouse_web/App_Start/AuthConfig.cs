using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Web.WebPages.OAuth;
using serverhouse_web.Models;
using MvcApplication.Code;

namespace serverhouse_web
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            // To let users of this site log in using their accounts from other sites such as Microsoft, Facebook, and Twitter,
            // следует обновить сайт. Дополнительные сведения: http://go.microsoft.com/fwlink/?LinkID=252166

            //OAuthWebSecurity.RegisterMicrosoftClient(
            //    clientId: "",
            //    clientSecret: "");

            OAuthWebSecurity.RegisterTwitterClient(
                consumerKey: "YuTRQLvOer8LWzLez0UHnii7R",
                consumerSecret: "QT9oeodb1GSDhH5oUXsK5C3vHf9F8LgBgQvRlHlwFvULvbPrPu");

            //OAuthWebSecurity.RegisterFacebookClient(
            //    appId: "",
            //    appSecret: "");

            //OAuthWebSecurity.RegisterGoogleClient();
            OAuthWebSecurity.RegisterGoogleClient();
	   

		 OAuthWebSecurity.RegisterClient(
       client: new VKontakteAuthenticationClient(
              appId: "4634918", appSecret: "Qr4ssc9kFrZaoXy8zoLh"),
       displayName: "ВКонтакте", // надпись на кнопке
       extraData: null);
        }
    }
}
