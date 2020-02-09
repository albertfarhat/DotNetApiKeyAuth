using System;
using System.Collections.Generic;
using System.Text;

namespace ApiKeyAuth
{
    internal static class GlobalSettings
    {
        public static string HeaderKey { get; set; }
        public static string AuthController { get; set; } = "Auth";
        public static string NotAuthorizedAction { get; set; } = "NotAuthorized";
        public static string NoApiKeyAction { get; set; } = "Forbidden";
        public static string NoApiKeyReasonPhrase { get; set; } = "NoApiKey";
        public static string NotAuthorizedReasonPhrase = "NotAuthorized";
    }
}
