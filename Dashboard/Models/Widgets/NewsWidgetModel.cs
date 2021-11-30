using Dashboard.Shared.Widgets;

namespace Dashboard.Models.Widgets
{
    public class NewsWidgetModel : WidgetModel
    {
        public NewsWidgetModel()
        {
            this.SubRendererType = typeof(NewsWidget);
            this.FriendlyName = "Live news";
            this.Description = "Live news from the New York Times";
        }
    }
}
