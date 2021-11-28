namespace Dashboard.Models
{
    public class OAuthTransitory
    {
        /// <summary>
        /// The OAuth 2.0 state for the ongoing authentication
        /// </summary>
        public string ServiceAuthenticationState { get; set; }

        /// <summary>
        /// Is an OAuth 2.0 service authentication ongoing
        /// </summary>
        public bool ServiceAuthenticationOngoing { get; set; }
    }
}
