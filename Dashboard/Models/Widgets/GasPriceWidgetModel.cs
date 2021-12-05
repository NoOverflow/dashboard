using Dashboard.Shared.Widgets;

namespace Dashboard.Models.Widgets
{
    public class GasPriceWidgetModel : WidgetModel
    {
        public GasPriceWidgetModel()
        {
            this.SubRendererType = typeof(ETHGasWidget);
            this.SubSettingsType = typeof(ETHGasWidgetSettings);
            this.FriendlyName = "ETH Gas Price";
            this.Description = "Display Ethereum transfer gas prices in realtime";
            this.RefreshRate = TimeSpan.FromMinutes(2);
            this.Settings = new Dictionary<string, object?>()
            {
                { "ShowFastest", false }
            };
            this.AllowedSizes = new WidgetSize[1]
            {
                WidgetSize.Square
            };
        }
    }
}
