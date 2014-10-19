using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Web.WebPages.OAuth;
using OpenId.Models;
using MvcApplication.Code;

namespace OpenId
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

            //OAuthWebSecurity.RegisterTwitterClient(
            //    consumerKey: "",
            //    consumerSecret: "");

            OAuthWebSecurity.RegisterFacebookClient(
                appId: "552056558273465",
                appSecret: "57290f3fe29d47b3a04b2fc90bbf86b6");

            //OAuthWebSecurity.RegisterGoogleClient();
            OAuthWebSecurity.RegisterClient(
       client: new VKontakteAuthenticationClient(
					appId: "4588877", appSecret: "q5bKoYMwpcXYgQtftJIB"),
       displayName: "ВКонтакте", // надпись на кнопке
       extraData: null);
        }
    }
}
