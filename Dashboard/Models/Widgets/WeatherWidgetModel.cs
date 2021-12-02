using Dashboard.Shared.Widgets;
using Newtonsoft.Json;

namespace Dashboard.Models.Widgets
{
    public class WeatherWidgetModel : WidgetModel
    {
        public WeatherWidgetModel()
        {
            this.SubRendererType = typeof(WeatherWidget);
            this.SubRendererType = typeof(WeatherWidgetSettings);
            this.FriendlyName = "Weather";
            this.Description = "A weather widget using WeatherAPI";
            this.Settings = new Dictionary<string, object>();
            this.Settings["City"] = "Toulouse";
        }
    }
}
