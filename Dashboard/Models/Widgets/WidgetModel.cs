using Newtonsoft.Json;

namespace Dashboard.Models.Widgets
{
    public class WidgetModel
    {
        /// <summary>
        /// The widget "renderer" type name, obtained through reflection
        /// </summary>
        public Type? SubRendererType { get; set; }

        /// <summary>
        /// The widget settings panel type
        /// </summary>
        public Type? SubSettingsType { get; set; }

        /// <summary>
        /// The friendly name displayed to an user on the widget list
        /// </summary>
        public string? FriendlyName { get; set; }

        /// <summary>
        /// The widgets description presented to the user
        /// </summary>
        public string? Description { get; set; }

        public Dictionary<string, object> Settings { get; set; }
    }
}
