using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Web.WebPages.OAuth;
using serverhouse_web.Models;
using serverhouse_web.Auth;

namespace serverhouse_web
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            OAuthWebSecurity.RegisterTwitterClient(
                consumerKey: "YuTRQLvOer8LWzLez0UHnii7R",
                consumerSecret: "QT9oeodb1GSDhH5oUXsK5C3vHf9F8LgBgQvRlHlwFvULvbPrPu");

		    OAuthWebSecurity.RegisterClient(
                client: new VKontakteAuthenticationClient(
                                appId: "4635100", appSecret: "6ImFiGdKxmfVTUgimKyO"),
                displayName: "ВКонтакте", // надпись на кнопке
                extraData: null);
        }
    }
}
