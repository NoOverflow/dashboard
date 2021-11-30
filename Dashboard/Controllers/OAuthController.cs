using Dashboard.Areas.Identity.Data;
using Dashboard.Data;
using Dashboard.Models;
using Dashboard.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Dashboard.Controllers
{
    [Route("{ServiceName}-service-callback")]
    [ApiController]
    public class OAuthController : ControllerBase
    {
        private readonly OAuthManagerService _oAuthManagerService;
        private readonly AuthenticationStateProvider _oAuthenticationStateProvider;

        private Dictionary<string, ServiceType> ServicesName = new Dictionary<string, ServiceType>()
        {
            {"spotify", ServiceType.Spotify }
        };

        public OAuthController(OAuthManagerService oAuthManagerService, AuthenticationStateProvider authenticationStateProvider)
        {
            this._oAuthManagerService = oAuthManagerService;
            this._oAuthenticationStateProvider = authenticationStateProvider;
        }

        [HttpGet]
        public async Task<RedirectResult> Get(string ServiceName)
        {
            await _oAuthManagerService.HandleAuthorizationCallback(ServicesName[ServiceName], Request.QueryString.Value, User,
                HttpContext.Request.Scheme + "://" + HttpContext.Request.Host);
            return Redirect("/dashboard");
        }
    }
}
