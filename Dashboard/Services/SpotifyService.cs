namespace Dashboard.Services
{
    public class SpotifyService
    {
        private string AppSecret { get; set; }
        private string AppId { get; set; }
        private string AppRedirectUrl { get; set; }
        private IEnumerable<string> AppScopes { get; set;}
        private const string AUTHORIZE_URL = "https://accounts.spotify.com/authorize";

        public SpotifyService(string AppSecret, string AppId, string AppRedirectUrl, IEnumerable<string> AppScopes)
        {
            this.AppSecret = AppSecret;
            this.AppId = AppId;
            this.AppRedirectUrl = AppRedirectUrl;
            this.AppScopes = AppScopes;
        }

        public static string GenerateRandomString(uint size)
        {
            Random random = new Random();
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            string ret = "";

            for (int i = 0; i < size; i++)
            {
                ret += alphabet[random.Next(alphabet.Length)];
            }
            return ret;
        }

        public string GetAuthenticationUrl()
        {
            string url = AUTHORIZE_URL + "?";

            url += "response_type=code&";
            url += "client_id=" + AppId + "&";
            url += "scope=";
            foreach(string scope in AppScopes)
            {
                url += scope + " ";
            }
            url = url.Substring(0, url.LastIndexOf(" ") - 1);
            url += "&redirect_uri=" + AppRedirectUrl + "&";
            url += "state=" + GenerateRandomString(15);
            return url;
        }
    }
}
