using Dashboard.Shared.Widgets;

namespace Dashboard.Models.Widgets
{
    public class YouTubeWidgetModel : WidgetModel
    {
        public YouTubeWidgetModel()
        {
            this.FriendlyName = "YouTube Channel Statistics";
            this.Description = "Check your favorite channel statistics in real time";
            this.AllowedSizes = new WidgetSize[1]
            {
                WidgetSize.Small
            };
            this.SubSettingsType = typeof(YoutubeWidgetSettings);
            this.SubRendererType = typeof(YouTubeWidget);
            this.RefreshRate = TimeSpan.FromMinutes(2);
            this.Settings = new Dictionary<string, object?>()
            {
                {"ChannelName", "YouTube" }
            };
        }
    }
}
