using System.Diagnostics;

namespace Dashboard.Services
{
    public class UpdateService
    {
        private TimeSpan Rate { get; set; }
        private Timer RefreshTimer { get; set; }

        public delegate void OnUpdateWidgetDelegate();
        public event OnUpdateWidgetDelegate? OnUpdateWidget;

        public UpdateService(TimeSpan rate)
        {
            this.Rate = rate;
            this.RefreshTimer = new Timer(TimerCallback, null, 0, Timeout.Infinite);  
        }

        private void TimerCallback(object? state)
        {
            OnUpdateWidget?.Invoke();
            RefreshTimer.Change((long)Rate.TotalMilliseconds, Timeout.Infinite);
        }
    }
}
