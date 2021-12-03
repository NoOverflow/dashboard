using Dashboard.Models.Widgets;
using Newtonsoft.Json;

namespace Dashboard.Models
{
    [Serializable]
    public class AboutWidgetModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        public static explicit operator AboutWidgetModel(WidgetModel widgetModel)
        {
            AboutWidgetModel widget = new AboutWidgetModel();

            widget.Name = widgetModel.FriendlyName;
            widget.Description = widgetModel.Description;
            return widget;
        }
    }
}
