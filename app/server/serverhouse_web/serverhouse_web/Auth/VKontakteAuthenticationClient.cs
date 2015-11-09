using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace serverhouse_web.Auth {
    public class VKontakteAuthenticationClient : IAuthenticationClient {
        public string appId;
        public string appSecret;
        private string redirectUri;

        public VKontakteAuthenticationClient(string appId, string appSecret) {
            this.appId = appId;
            this.appSecret = appSecret;
        }

        string IAuthenticationClient.ProviderName
        {
            get { return "vkontakte"; }
        }

        void IAuthenticationClient.RequestAuthentication(HttpContextBase context, Uri returnUrl) {
            var APP_ID = appId;
            redirectUri = context.Server.UrlEncode(returnUrl.ToString());
            var address = string.Format(
                "https://oauth.vk.com/authorize?client_id={0}&redirect_uri={1}&response_type=code",
                APP_ID, redirectUri
                );
            HttpContext.Current.Response.Redirect(address, false);
        }

        AuthenticationResult IAuthenticationClient.VerifyAuthentication(HttpContextBase context) {
            try {
                var code = context.Request["code"];
                var address = string.Format(
                    "https://oauth.vk.com/access_token?client_id={0}&client_secret={1}&code={2}&redirect_uri={3}",
                    appId, appSecret, code, redirectUri);
                var response = Load(address);
                var accessToken = DeserializeJson<AccessToken>(response);
                address = string.Format(
                    "https://api.vk.com/method/users.get?uids={0}&fields=photo_50",
                    accessToken.user_id);
                response = Load(address);
                var usersData = DeserializeJson<UsersData>(response);
                var userData = usersData.response.First();
                return new AuthenticationResult(
                    true, (this as IAuthenticationClient).ProviderName, accessToken.user_id,
                    userData.first_name + " " + userData.last_name,
                    new Dictionary<string, string>());
            }
            catch (Exception ex) {
                return new AuthenticationResult(ex);
            }
        }

        public static string Load(string address) {
            var request = WebRequest.Create(address) as HttpWebRequest;
            using (var response = request.GetResponse() as HttpWebResponse) {
                using (var reader = new StreamReader(response.GetResponseStream())) {
                    return reader.ReadToEnd();
                }
            }
        }

        public static T DeserializeJson<T>(string input) {
            var serializer = new JavaScriptSerializer();
            return serializer.Deserialize<T>(input);
        }

        private class AccessToken {
            public string access_token = null;
            public readonly string user_id = null;
        }

        private class UserData {
            public readonly string first_name = null;
            public readonly string last_name = null;
            public string photo_50 = null;
            public string uid = null;
        }

        private class UsersData {
            public readonly UserData[] response = null;
        }
    }
}