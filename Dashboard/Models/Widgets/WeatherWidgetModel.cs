﻿using Dashboard.Shared.Widgets;
using Newtonsoft.Json;

namespace Dashboard.Models.Widgets
{
    public class WeatherWidgetModel : WidgetModel
    {
        public WeatherWidgetModel()
        {
            this.SubRendererType = typeof(WeatherWidget);
            this.SubSettingsType = typeof(WeatherWidgetSettings);
            this.FriendlyName = "Weather";
            this.Description = "A weather widget using WeatherAPI";
            this.Settings = new Dictionary<string, object>();
            this.Settings["City"] = "Toulouse";
            this.RefreshRate = TimeSpan.FromMinutes(5);
            this.AllowedSizes = new WidgetSize[1]
            {
                WidgetSize.Large
            };
        }
    }
}
