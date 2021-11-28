using Dashboard.Services;

namespace Dashboard.Models
{
    public class SessionState
    {
        public Dictionary<Services.ServiceType, OAuthTransitory> OAuthStates;

        public SessionState()
        {
            this.OAuthStates = new Dictionary<ServiceType, OAuthTransitory>();
        }
    }
}
