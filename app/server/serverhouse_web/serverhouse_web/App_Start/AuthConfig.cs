using Microsoft.Web.WebPages.OAuth;
using serverhouse_web.Auth;

namespace serverhouse_web {
    public static class AuthConfig {
        public static void RegisterAuth() {
            OAuthWebSecurity.RegisterTwitterClient("YuTRQLvOer8LWzLez0UHnii7R",
                "QT9oeodb1GSDhH5oUXsK5C3vHf9F8LgBgQvRlHlwFvULvbPrPu");

            OAuthWebSecurity.RegisterClient(
                client: new VKontakteAuthenticationClient("4635100", "6ImFiGdKxmfVTUgimKyO"),
                displayName: "ВКонтакте", // надпись на кнопке
                extraData: null);
        }
    }
}