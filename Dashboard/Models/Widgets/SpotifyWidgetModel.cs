using Dashboard.Shared.Widgets;
using Newtonsoft.Json;

namespace Dashboard.Models.Widgets
{
    public class SpotifyWidgetModel : WidgetModel
    {
        public SpotifyWidgetModel()
        {
            this.SubRendererType = typeof(SpotifyWidget);
            this.SubSettingsType = typeof(SpotifyWidgetSettings);
            this.FriendlyName = "Spotify (Small)";
            this.Description = "A reduced version of the spotify widget. See what you're listening to.";
            this.Settings = new Dictionary<string, object>();
            this.Settings["ShowAlbumName"] = false;
        }
    }
}
