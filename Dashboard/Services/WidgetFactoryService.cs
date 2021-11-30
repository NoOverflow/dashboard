using System.ComponentModel;

namespace Dashboard.Services
{
    public class WidgetFactoryService
    {
        public List<Type> WidgetsTypesList { get; private set; } = new List<Type>();

        public WidgetFactoryService()
        {
            this.WidgetsTypesList = new List<Type>();
        }

        public WidgetFactoryService RegisterWidgetType<T>()
        {
            this.WidgetsTypesList.Add(typeof(T));
            return this;
        }
    }
}
