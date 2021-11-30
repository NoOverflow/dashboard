using Dashboard.Shared.Widgets;

namespace Dashboard.Models.Widgets
{
    public class AddWidgetModel : WidgetModel
    {
        public AddWidgetModel()
        {
            this.FriendlyName = "Add";
            this.SubRendererType = typeof(AddWidget);
        }
    }
}
