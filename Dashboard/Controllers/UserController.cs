using Dashboard.Areas.Identity.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly SignInManager<DashboardUser> _signInManager;

        public UserController(SignInManager<DashboardUser> signInManager)
        {
            this._signInManager = signInManager;
        }

        [HttpGet]
        [Route("logout")]
        public async Task<ActionResult> OnGet()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/");
        }
    }
}
