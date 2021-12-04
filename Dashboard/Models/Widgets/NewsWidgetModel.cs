using Dashboard.Shared.Widgets;
using Newtonsoft.Json;

namespace Dashboard.Models.Widgets
{
    public class NewsWidgetModel : WidgetModel
    {
        public NewsWidgetModel()
        {
            this.SubRendererType = typeof(NewsWidget);
            this.SubSettingsType = typeof(NewsWidgetSettings);
            this.FriendlyName = "Live news";
            this.Description = "Live news from the New York Times";
            this.Settings = new Dictionary<string, object>();
            this.Settings["Source"] = "all";
            this.Settings["Section"] = "all";
            this.AllowedSizes = new WidgetSize[2]
            {
                WidgetSize.Medium,
                WidgetSize.Large
            };
        }    
    }
}
