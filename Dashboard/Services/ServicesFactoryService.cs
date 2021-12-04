using Dashboard.Models;
using System.Linq;

namespace Dashboard.Services
{
    public class ServicesFactoryService
    {
        public Dictionary<ServiceType, List<Type>> ServicesTypesList { get; private set; } = new Dictionary<ServiceType, List<Type>>();

        public ServicesFactoryService()
        {
            this.ServicesTypesList = new Dictionary<ServiceType, List<Type>>();
        }

        public ServicesFactoryService RegisterServiceType(ServiceType type, params Type[] widgets)
        {
            this.ServicesTypesList[type] = widgets.ToList();
            return this;
        }
    }
}
