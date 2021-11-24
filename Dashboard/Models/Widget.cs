namespace Dashboard.Models
{
    public class Widget
    {
        /// <summary>
        /// The widget "renderer" type name, obtained through reflection
        /// </summary>
        public string SubRendererTypeName { get; set; }

        public Widget(string SubRendererTypeName)
        {
            this.SubRendererTypeName = SubRendererTypeName;
        }
    }
}
