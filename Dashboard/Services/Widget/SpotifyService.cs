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
    public class SpotifyService
    {
        private const Services.ServiceType SERVICE = ServiceType.Spotify;

        private readonly SessionState SessionState;
        private readonly UserManager<DashboardUser> _userManager;
        private readonly NavigationManager _navManager;
        private readonly OAuthManagerService _oauthManagerService;

        private HttpClient ApiHttpClient => _oauthManagerService.GetApiClient(SERVICE);

        public SpotifyService(
            NavigationManager navManager,
            UserManager<DashboardUser> userManager, 
            OAuthManagerService oAuthManagerService, 
            SessionState sessionState)
        {
            this.SessionState = sessionState;
            this._userManager = userManager;
            this._navManager = navManager;
            this._oauthManagerService = oAuthManagerService;
        }

        public async Task<CurrentlyPlayingTrack> GetCurrentlyPlayingTrack(ClaimsPrincipal claims)
        {
            var response = await ApiHttpClient.GetAsync("https://api.spotify.com/v1/me/player/currently-playing");
            var strRes = await response.Content.ReadAsStringAsync();
            CurrentlyPlayingTrack track = JsonConvert.DeserializeObject<CurrentlyPlayingTrack>(strRes);

            await _oauthManagerService.RefreshToken(ServiceType.Spotify, claims);
            return track == null ? null : (track.Item == null ? null : track);
        }

        public async Task Pause(ClaimsPrincipal claims)
        {
            await ApiHttpClient.PutAsync("https://api.spotify.com/v1/me/player/pause", null);
            await _oauthManagerService.RefreshToken(ServiceType.Spotify, claims);
        }

        public async Task PlayOrResume(ClaimsPrincipal claims)
        {
            await ApiHttpClient.PutAsync("https://api.spotify.com/v1/me/player/play", null);
            await _oauthManagerService.RefreshToken(ServiceType.Spotify, claims);
        }
    }
}
