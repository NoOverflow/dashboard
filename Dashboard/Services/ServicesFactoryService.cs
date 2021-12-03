using System.Linq;

namespace Dashboard.Services
{
    public class ServicesFactoryService
    {
        public Dictionary<Type, List<Type>> ServicesTypesList { get; private set; } = new Dictionary<Type, List<Type>>();

        public ServicesFactoryService()
        {
            this.ServicesTypesList = new Dictionary<Type, List<Type>>();
        }

        public ServicesFactoryService RegisterServiceType<T>(params T[] Widgets)
        {
            List<Type> types = new List<Type>();

            foreach (var widget in Widgets)
                types.Add(widget.GetType());
            this.ServicesTypesList[typeof(T)] = types;
            return this;
        }
    }
}
