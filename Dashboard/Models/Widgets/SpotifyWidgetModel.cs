using Dashboard.Shared.Widgets;

namespace Dashboard.Models.Widgets
{
    public class SpotifyWidgetModel : WidgetModel
    {
        public SpotifyWidgetModel()
        {
            this.SubRendererType = typeof(SpotifyWidget);
            this.FriendlyName = "Spotify (Small)";
            this.Description = "A reduced version of the spotify widget. See what you're listening to.";
        }
    }
}
