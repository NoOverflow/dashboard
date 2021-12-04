using Newtonsoft.Json;

namespace Dashboard.Models
{
    [Serializable]
    public class AboutServiceModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    
        [JsonProperty("widgets")]
        public AboutWidgetModel[] Widgets { get; set; }

        public AboutServiceModel(string name, AboutWidgetModel[] widgets)
        {
            this.Name = name;
            this.Widgets = widgets;
        }
    }
}
