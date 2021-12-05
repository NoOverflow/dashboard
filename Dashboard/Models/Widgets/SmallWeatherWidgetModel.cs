using Dashboard.Shared.Widgets;

namespace Dashboard.Models.Widgets
{
    public class SmallWeatherWidgetModel : WidgetModel
    {
        public SmallWeatherWidgetModel()
        {
            this.SubRendererType = typeof(SmallWeatherWidget);
            this.SubSettingsType = typeof(WeatherWidgetSettings);
            this.FriendlyName = "Weather (Small)";
            this.Description = "A weather widget using WeatherAPI";
            this.Settings = new Dictionary<string, object>();
            this.Settings["City"] = "Toulouse";
            this.RefreshRate = TimeSpan.FromMinutes(5);
            this.AllowedSizes = new WidgetSize[1]
            {
                WidgetSize.Square
            };
        }
    }
}
