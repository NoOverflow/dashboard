using Dashboard.Models.Widgets;

namespace Dashboard.Models
{
    public enum ServiceType
    {
        Spotify,
        NYTimes,
        WeatherApi,
        YouTube
    }

    public static class ServiceModel
    {
        public static Dictionary<ServiceType, string> ServicesNames = new Dictionary<ServiceType, string>()
        {
            { ServiceType.Spotify, "Spotify" },
            { ServiceType.NYTimes, "New York Times" },
            { ServiceType.WeatherApi, "Weather API" },
            { ServiceType.YouTube, "YouTube" }
        };
    }
}
