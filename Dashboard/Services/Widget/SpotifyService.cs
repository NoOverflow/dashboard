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
        private const ServiceType SERVICE = ServiceType.Spotify;

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

        public async Task<CurrentlyPlayingTrack?> GetCurrentlyPlayingTrack(ClaimsPrincipal claims)
        {
            try
            {
                await _oauthManagerService.RefreshToken(ServiceType.Spotify, claims);
                var response = await ApiHttpClient.GetAsync("https://api.spotify.com/v1/me/player/currently-playing");

                if (!response.IsSuccessStatusCode)
                    return null;
                var strRes = await response.Content.ReadAsStringAsync();
                CurrentlyPlayingTrack? track = JsonConvert.DeserializeObject<CurrentlyPlayingTrack>(strRes);

                return track == null ? null : (track.Item == null ? null : track);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<UserProfile?> GetUserProfile(ClaimsPrincipal claims)
        {
            try
            {
                await _oauthManagerService.RefreshToken(ServiceType.Spotify, claims);
                HttpResponseMessage response = await ApiHttpClient.GetAsync("https://api.spotify.com/v1/me");

                if (!response.IsSuccessStatusCode)
                    return null;
                string raw = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<UserProfile>(raw);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> IsConnected(ClaimsPrincipal claims)
        {
            try
            {
                await _oauthManagerService.RefreshToken(ServiceType.Spotify, claims);
                UserProfile? userProfile = await GetUserProfile(claims);

                return userProfile != null && userProfile.Email != null;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task Pause(ClaimsPrincipal claims)
        {
            await _oauthManagerService.RefreshToken(ServiceType.Spotify, claims);
            await ApiHttpClient.PutAsync("https://api.spotify.com/v1/me/player/pause", null);
        }

        public async Task PlayOrResume(ClaimsPrincipal claims)
        {
            await _oauthManagerService.RefreshToken(ServiceType.Spotify, claims);
            await ApiHttpClient.PutAsync("https://api.spotify.com/v1/me/player/play", null);
        }
    }
}
