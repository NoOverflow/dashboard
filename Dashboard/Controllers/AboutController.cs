using Dashboard.Models;
using Dashboard.Models.Widgets;
using Dashboard.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Controllers
{
    [Route("about.json")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly ServicesFactoryService _ServicesFactory;

        public AboutController(ServicesFactoryService servicesFactory)
        {
            this._ServicesFactory = servicesFactory;
        }

        [HttpGet]
        public ObjectResult Get()
        {
            AboutModel about = new AboutModel();
            List<AboutServiceModel> aboutServiceModels = new List<AboutServiceModel>();

            foreach (var kvp in _ServicesFactory.ServicesTypesList)
            {
                List<AboutWidgetModel> widgetModels = new List<AboutWidgetModel>();

                foreach (var widgetType in kvp.Value)
                {
                    WidgetModel wm = (WidgetModel)Activator.CreateInstance(widgetType)!;
                    
                    widgetModels.Add((AboutWidgetModel)wm);
                }
                aboutServiceModels.Add(
                    new AboutServiceModel(
                        ServiceModel.ServicesNames[kvp.Key],
                        widgetModels.Cast<AboutWidgetModel>().ToArray()
                    ));
            }
            about.Server = new Server()
            {
                CurrentTime = DateTimeOffset.Now.ToUnixTimeSeconds(),
                Services = aboutServiceModels.ToArray()
            };
            about.Client = new Client()
            {
                HostIp = HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString(),
            };
            return Ok(about);
        }
    }
}
