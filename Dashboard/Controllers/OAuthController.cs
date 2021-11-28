using Dashboard.Areas.Identity.Data;
using Dashboard.Data;
using Dashboard.Models;
using Dashboard.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Dashboard.Controllers
{
    [Route("spotify-service-callback")]
    [ApiController]
    public class OAuthController : ControllerBase
    {
        private readonly SpotifyService _spotifyService;
        private readonly UserManager<DashboardUser> _userManager;
        private readonly IUserStore<DashboardUser> _userStore;
        private readonly DashboardContext _dbContext;

        public OAuthController(SpotifyService spotifyService, UserManager<DashboardUser> userManager, IUserStore<DashboardUser> userStore, DashboardContext dbContext)
        {
            this._spotifyService = spotifyService;
            this._userManager = userManager;
            this._userStore = userStore;
            this._dbContext = dbContext;
        }

        private async Task UpdateOAuthSession(OAuthSession session)
        {
            DashboardUser u = await _userManager.GetUserAsync(User);
            DashboardUser user = await _userManager.FindByIdAsync(u.Id);

            user.SpotifyAccessToken = session.AccessToken;
            user.SpotifyRefreshToken = session.RefreshToken;
            /*if (user.AuthSessions == null)
                user.AuthSessions = new List<OAuthSession>();
            foreach (var sess in user.AuthSessions)
            {
                if (sess.ServiceType == session.ServiceType)
                {
                    sess.AccessToken = session.AccessToken;
                    sess.RefreshToken = session.RefreshToken;
                    sess.ServiceType = session.ServiceType;
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                var fuck = user.AuthSessions.ToList();
                fuck.Add(session);
                user.AuthSessions = fuck;
                user.AuthSessions.Append(session);
                Console.WriteLine("xd");
            }*/
            var wgat = await _userManager.UpdateAsync(user);
            await _userStore.UpdateAsync(user, new CancellationToken());
            _dbContext.Update(user);
            _dbContext.SaveChanges();
        }

        [HttpPut]
        public async Task<OkResult> Put()
        {
            
            return Ok();
        }

        [HttpGet]
        public async Task<RedirectResult> Get()
        {
            OAuthSession session = await _spotifyService.HandleAuthorizationCallback(Request.QueryString.Value);

            await UpdateOAuthSession(session);
            return Redirect("/dashboard");
        }
    }
}
