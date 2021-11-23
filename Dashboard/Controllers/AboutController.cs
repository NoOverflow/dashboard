using Dashboard.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Controllers
{
    [Route("about.json")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        [HttpGet]
        public ObjectResult Get()
        {
            About about = new About();

            about.Server = new Server()
            {
                CurrentTime = DateTimeOffset.Now.ToUnixTimeSeconds(),
                Services = new Service[0]
            };
            about.Client = new Client()
            {
                HostIp = HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString(),
            };
            return Ok(about);
        }
    }
}
