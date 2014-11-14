﻿using System;
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

            //OAuthWebSecurity.RegisterTwitterClient(
            //    consumerKey: "",
            //    consumerSecret: "");

            //OAuthWebSecurity.RegisterFacebookClient(
            //    appId: "",
            //    appSecret: "");

            OAuthWebSecurity.RegisterGoogleClient();
	   

		 OAuthWebSecurity.RegisterClient(
       client: new VKontakteAuthenticationClient(
              appId: "4588730", appSecret: "B6hJ3rq76cR4vZgZB7SF"),
       displayName: "ВКонтакте", // надпись на кнопке
       extraData: null);
        }
    }
}
