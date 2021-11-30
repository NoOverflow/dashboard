namespace Dashboard.Models
{
    public class WidgetModel
    {
        /// <summary>
        /// The widget "renderer" type name, obtained through reflection
        /// </summary>
        public Type? SubRendererType { get; set; }

        public string? FriendlyName { get; set; }

        /// <summary>
        /// The widgets description presented to the user
        /// </summary>
        public string? Description { get; set; }

        public WidgetModel()
        {
        }
    }
}
