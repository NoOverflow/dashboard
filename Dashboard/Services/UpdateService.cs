using Dashboard.Models.Widgets;
using System.Diagnostics;

namespace Dashboard.Services
{
    public class UpdateService
    {
        private TimeSpan Rate { get; set; }
        private Timer RefreshTimer { get; set; }

        private Dictionary<Guid, (WidgetModel widget, TimeSpan incr, Action callback)> Actions = new Dictionary<Guid, (WidgetModel, TimeSpan, Action)>();

        public UpdateService(TimeSpan rate)
        {
            this.Rate = rate;
            this.RefreshTimer = new Timer(TimerCallback, null, 0, Timeout.Infinite);  
        }

        public void Subscribe(WidgetModel widget, Action callback)
        {
            if (Actions.ContainsKey(widget.Id))
            {
                Actions[widget.Id] = (widget, TimeSpan.Zero, callback);
            } 
            else
            {
                Actions.Add(widget.Id, (widget, TimeSpan.Zero, callback));
            }
        }

        private void TimerCallback(object? state)
        {
            foreach (var kvp in Actions.ToList())
            {
                Actions[kvp.Key] = (Actions[kvp.Key].widget, Actions[kvp.Key].incr + Rate, Actions[kvp.Key].callback);

                if (Actions[kvp.Key].incr >= Actions[kvp.Key].widget.RefreshRate)
                {
                    Actions[kvp.Key] = (Actions[kvp.Key].widget, TimeSpan.Zero, Actions[kvp.Key].callback);
                    Actions[kvp.Key].callback.Invoke();
                }
            }
            RefreshTimer.Change((long)Rate.TotalMilliseconds, Timeout.Infinite);
        }
    }
}
