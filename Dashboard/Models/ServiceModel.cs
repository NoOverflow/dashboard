using Dashboard.Models.Widgets;

namespace Dashboard.Models
{
    public enum ServiceType
    {
        Spotify
    }

    public class ServiceModel
    {

        /// <summary>
        /// The display name of the service
        /// </summary>
        public string Name { get; set; }

        public WidgetModel[] Widgets { get; set; }

    }
}
