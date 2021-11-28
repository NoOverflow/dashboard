using Dashboard.Areas.Identity.Data;
using Dashboard.Data;
using Dashboard.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
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

    public class OAuthManagerService
    {
        private readonly NavigationManager _navManager;
        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly UserManager<DashboardUser> _userManager;
        private readonly IUserStore<DashboardUser> _userStore;
        private readonly DashboardContext _dbContext;

        private IHttpClientFactory _httpFactory;

        private Dictionary<ServiceType, OAuthConfiguration> Configurations;
        private Dictionary<ServiceType, HttpClient> HttpClients;

        public OAuthManagerService(
            NavigationManager navManager,
            IHttpClientFactory factory,
            AuthenticationStateProvider authenticationStateProvider,
            UserManager<DashboardUser> userManager,
            IUserStore<DashboardUser> userStore,
            DashboardContext dbContext
        )
        {
            this.Configurations = new Dictionary<ServiceType, OAuthConfiguration>();
            this.HttpClients = new Dictionary<ServiceType, HttpClient>();
            this._navManager = navManager;
            this._httpFactory = factory;
            this._authStateProvider = authenticationStateProvider;
            this._userManager = userManager;
            this._userStore = userStore;
            this._dbContext = dbContext;    
        }

        public OAuthManagerService RegisterOAuth(ServiceType type, OAuthConfiguration configuration)
        {
            Configurations[type] = configuration;
            HttpClients[type] = _httpFactory.CreateClient();
            return this;
        }

        public string BuildAuthenticationUrl(ServiceType type)
        {
            OAuthConfiguration configuration = Configurations[type];
            string url = configuration.AuthorizeUrl + "?";
            string state = GenerateRandomString(15);

            url += "response_type=code&";
            url += "client_id=" + configuration.Id + "&";
            url += "scope=";
            foreach (string scope in configuration.Scopes)
                url += scope + " ";
            url = url.Substring(0, url.LastIndexOf(" "));
            url += "&redirect_uri=" + _navManager.ToAbsoluteUri(configuration.RedirectUrl) + "&";
            url += "state=" + state;
            return url;
        }

        public HttpClient GetApiClient(ServiceType type)
        {
            // Make sure to preload the client with the right token

            return HttpClients[type];
        }

        private async Task UpdateOAuthSession(ServiceType type, OAuthSession session, ClaimsPrincipal claims)
        {
            DashboardUser u = await _userManager.GetUserAsync(claims);
            DashboardUser user = await _userManager.FindByIdAsync(u.Id);

            if (user == null)
                return;
            if (user.Sessions.Count(x => x.ServiceType == type) == 0)
                user.Sessions.Add(session);
            OAuthSession userSession = user.Sessions.First(x => x.ServiceType == type);

            userSession.AccessToken = session.AccessToken;
            userSession.RefreshToken = session.RefreshToken;

            var wgat = await _userManager.UpdateAsync(user);
            await _userStore.UpdateAsync(user, new CancellationToken());
            _dbContext.Update(user);
            _dbContext.SaveChanges();
            HttpClients[type].DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", session.AccessToken);
        }

        public async Task<OAuthSession> RefreshToken(ServiceType type, ClaimsPrincipal claims)
        {
            // BLAZOR IS UTTER TRASH var claims = await _authStateProvider.GetAuthenticationStateAsync();
            DashboardUser u = await _userManager.GetUserAsync(claims);
            DashboardUser user = await _userManager.FindByIdAsync(u.Id);

            if (user == null || user.Sessions.Count(x => x.ServiceType == type) == 0)
                return null;
            OAuthSession userSession = user.Sessions.First(x => x.ServiceType == type);
            var formParams = new Dictionary<string, string>();
            var httpClient = GetApiClient(type);
            var configuration = Configurations[type];

            formParams.Add("refresh_token", userSession.RefreshToken);
            formParams.Add("grant_type", "refresh_token");

            FormUrlEncodedContent content = new FormUrlEncodedContent(formParams);
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(configuration.Id + ":" + configuration.Secret)));
            var response = await httpClient.PostAsync(configuration.TokenUrl, content);
            var res = await response.Content.ReadAsStringAsync();
            OAuthSession session = JsonConvert.DeserializeObject<OAuthSession>(res);

            userSession.AccessToken = session.AccessToken;
            HttpClients[type].DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", session.AccessToken);
            await UpdateOAuthSession(type, userSession, claims);
            return session;
        }

        public async Task<OAuthSession> HandleAuthorizationCallback(ServiceType type, string queryData, ClaimsPrincipal claims)
        {
            OAuthConfiguration configuration = Configurations[type];
            HttpClient httpClient = HttpClients[type];
            var queryDictionary = System.Web.HttpUtility.ParseQueryString(queryData);

            if (queryDictionary["state"] == null || queryDictionary["code"] == null)
                throw new Exception("Invalid OAuth response.");
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Basic", 
                Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(configuration.Id + ":" + configuration.Secret)));

            var formParams = new Dictionary<string, string>();
            formParams.Add("code", queryDictionary["code"]);
            formParams.Add("redirect_uri", "https://localhost:7267" + configuration.RedirectUrl);
            formParams.Add("grant_type", "authorization_code");

            FormUrlEncodedContent content = new FormUrlEncodedContent(formParams);

            var response = await httpClient.PostAsync(configuration.TokenUrl, content);
            var res = await response.Content.ReadAsStringAsync();
            OAuthSession session = JsonConvert.DeserializeObject<OAuthSession>(res);

            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", session.AccessToken);
            await UpdateOAuthSession(type, session, claims);
            return session;
        }

        private static string GenerateRandomString(uint size)
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
    }
}
