using Dashboard.Services;

namespace Dashboard.Models
{
    public class SessionState
    {
        public Dictionary<ServiceType, OAuthTransitory> OAuthStates;

        public SessionState()
        {
            this.OAuthStates = new Dictionary<ServiceType, OAuthTransitory>();
        }
    }
}
