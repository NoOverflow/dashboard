using Dashboard.Shared.Widgets;
using Newtonsoft.Json;

namespace Dashboard.Models.Widgets
{
    public class AddWidgetModel : WidgetModel
    {
        public AddWidgetModel()
        {
            this.SubRendererType = typeof(AddWidget);
        }
    }
}
