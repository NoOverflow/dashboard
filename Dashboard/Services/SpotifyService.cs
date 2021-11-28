using Dashboard.Areas.Identity.Data;
using Dashboard.Models;
using Dashboard.Models.Spotify;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace Dashboard.Services
{
    public struct OAuthCodeTokenData
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("redirect_uri")]
        public string RedirectUri { get; set; }

        [JsonProperty("grant_type")]
        public string GrantType { get; set; }
    }

    public class SpotifyOAuthSettings
    {
        public string Secret { get; set; }
        public string Id { get; set; }
        public string RedirectUrl { get; set; }
        public IEnumerable<string> Scopes { get; set; }
    }

    public class SpotifyService
    {
        private const Services.ServiceType SERVICE = ServiceType.Spotify;

        private readonly SessionState SessionState;
        private readonly UserManager<DashboardUser> _userManager;
        private readonly NavigationManager _navManager;

        private const string AUTHORIZE_URL = "https://accounts.spotify.com/authorize";
        private const string TOKEN_URL = "https://accounts.spotify.com/api/token";
        SpotifyOAuthSettings Settings { get; set; }
        private OAuthSession OAuthSession { get; set; }


        private HttpClient ApiHttpClient { get; set; }

        public SpotifyService(
            NavigationManager navManager,
            UserManager<DashboardUser> userManager, 
            IHttpClientFactory factory, 
            SessionState sessionState, 
            SpotifyOAuthSettings settings)
        {
            sessionState.OAuthStates[ServiceType.Spotify] = new OAuthTransitory();
            sessionState.OAuthStates[ServiceType.Spotify].ServiceAuthenticationState = "test";
            this.SessionState = sessionState;
            this.Settings = settings;
            this.ApiHttpClient = factory.CreateClient("spotify");
            this._userManager = userManager;
            this._navManager = navManager;
        }

        public async Task LoadSavedToken(ClaimsPrincipal claims)
        {
            DashboardUser user = await _userManager.GetUserAsync(claims);
            // TODO: Add refresh, etc
            this.ApiHttpClient.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue("Bearer", user.SpotifyAccessToken);
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

        public async Task RefreshToken(ClaimsPrincipal claims)
        {
            DashboardUser user = await _userManager.GetUserAsync(claims);
            var formParams = new Dictionary<string, string>();

            formParams.Add("refresh_token", user.SpotifyRefreshToken);
            formParams.Add("grant_type", "refresh_token");

            FormUrlEncodedContent content = new FormUrlEncodedContent(formParams);
            this.ApiHttpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(Settings.Id + ":" + Settings.Secret)));
            var response = await this.ApiHttpClient.PostAsync(TOKEN_URL, content);
            var res = await response.Content.ReadAsStringAsync();
            OAuthSession session = JsonConvert.DeserializeObject<OAuthSession>(res);

            ApiHttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", session.AccessToken);
        }

        public string GetAuthenticationUrl(NavigationManager manager)
        {
            if (Settings.Secret == null || Settings.RedirectUrl == null || Settings.Scopes == null)
                throw new Exception("OAuth parameters not set.");
            string url = AUTHORIZE_URL + "?";
            string state = GenerateRandomString(15);

            url += "response_type=code&";
            url += "client_id=" + Settings.Id + "&";
            url += "scope=";
            foreach(string scope in Settings.Scopes)
                url += scope + " ";
            url = url.Substring(0, url.LastIndexOf(" "));
            url += "&redirect_uri=" + manager.ToAbsoluteUri(Settings.RedirectUrl) + "&";
            url += "state=" + state;
            SessionState.OAuthStates[ServiceType.Spotify].ServiceAuthenticationOngoing = true;
            SessionState.OAuthStates[ServiceType.Spotify].ServiceAuthenticationState = state;
            return url;
        }

        public async Task<string> TestRequest()
        {
            var response = await ApiHttpClient.GetAsync("https://api.spotify.com/v1/me");
            
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<CurrentlyPlayingTrack> GetCurrentlyPlayingTrack()
        {
            var response = await ApiHttpClient.GetAsync("https://api.spotify.com/v1/me/player/currently-playing");
            var strRes = await response.Content.ReadAsStringAsync();
            CurrentlyPlayingTrack track = JsonConvert.DeserializeObject<CurrentlyPlayingTrack>(strRes);

            return track == null ? null : (track.Item == null ? null : track);
        }

        public async Task Pause()
        {
            await ApiHttpClient.PutAsync("https://api.spotify.com/v1/me/player/pause", null);
        }

        public async Task PlayOrResume()
        {
             await ApiHttpClient.PutAsync("https://api.spotify.com/v1/me/player/play", null);
        }

        public async Task<OAuthSession> HandleAuthorizationCallback(string queryData)
        {
            var queryDictionary = System.Web.HttpUtility.ParseQueryString(queryData);

            if (queryDictionary["state"] == null || queryDictionary["code"] == null)
                throw new Exception("Invalid OAuth response.");  
            this.ApiHttpClient.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(Settings.Id + ":" + Settings.Secret)));

            var formParams = new Dictionary<string, string>();
            formParams.Add("code", queryDictionary["code"]);
            formParams.Add("redirect_uri", "https://localhost:7267" + Settings.RedirectUrl);
            formParams.Add("grant_type", "authorization_code");

            FormUrlEncodedContent content = new FormUrlEncodedContent(formParams);
        
            var response = await ApiHttpClient.PostAsync(TOKEN_URL, content);
            var res = await response.Content.ReadAsStringAsync();
            OAuthSession session = JsonConvert.DeserializeObject<OAuthSession>(res);

            this.ApiHttpClient.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue("Bearer", session.AccessToken);
            return session;
        }
    }
}
