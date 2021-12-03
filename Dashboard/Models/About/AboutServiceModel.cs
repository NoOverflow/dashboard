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

        public static explicit operator AboutServiceModel(ServiceModel service)
        {
            AboutServiceModel aboutService = new AboutServiceModel();

            aboutService.Name = service.Name;
            aboutService.Widgets = (AboutWidgetModel[])service.Widgets.Cast<AboutWidgetModel>();
            return aboutService;
        }
    }
}
