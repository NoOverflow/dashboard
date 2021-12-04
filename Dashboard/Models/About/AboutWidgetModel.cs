using Dashboard.Models.Widgets;
using Newtonsoft.Json;

namespace Dashboard.Models
{
    public struct Param
    {

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        public Param(string type, string name)
        {
            this.Type = type;
            this.Name = name;
        }
    }

    [Serializable]
    public class AboutWidgetModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("params")]
        public List<Param> Params { get; set; }

        public static explicit operator AboutWidgetModel(WidgetModel widgetModel)
        {
            AboutWidgetModel widget = new AboutWidgetModel();

            widget.Name = widgetModel.FriendlyName;
            widget.Description = widgetModel.Description;
            widget.Params = new List<Param>();
            foreach (var kvp in widgetModel.Settings)
            {
                // TODO Check type
                widget.Params.Add(new Param("string", kvp.Key));
            }
            return widget;
        }
    }
}
