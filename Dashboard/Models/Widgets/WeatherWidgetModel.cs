using Dashboard.Shared.Widgets;

namespace Dashboard.Models.Widgets
{
    public class WeatherWidgetModel : WidgetModel
    {
        public WeatherWidgetModel()
        {
            this.SubRendererType = typeof(WeatherWidget);
            this.FriendlyName = "Weather";
            this.Description = "A weather widget using WeatherAPI";
        }
    }
}
