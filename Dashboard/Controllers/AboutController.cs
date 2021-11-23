using Dashboard.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dashboard.Controllers
{
    [Route("about.json")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        // GET: api/<AboutController>
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

        // GET api/<AboutController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AboutController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AboutController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AboutController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
