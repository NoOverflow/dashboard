using Dashboard.Shared.Widgets;

namespace Dashboard.Models.Widgets
{
    public class GasPriceWidgetModel : WidgetModel
    {
        public GasPriceWidgetModel()
        {
            this.SubRendererType = typeof(ETHGasWidget);
            this.SubSettingsType = typeof(SpotifyWidgetSettings);
            this.FriendlyName = "ETH Gas Price";
            this.Description = "Display Ethereum transfer gas prices in realtime";
            this.Settings = new Dictionary<string, object?>();
            this.AllowedSizes = new WidgetSize[1]
            {
                WidgetSize.Square
            };
        }
    }
}
