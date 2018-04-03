using System;

namespace EGuard.Rules
{
    public class TimeRule : IRule
    {
        public bool Check()
        {
            var primary = new MainWindow();
            var startTime = TimeSpan.Parse(primary.cboStartTime.SelectedValue.ToString());
            var endTime = TimeSpan.Parse(primary.cboEndTime.SelectedValue.ToString());
            var currentTime = DateTime.Now.TimeOfDay;

            var withinAllowedTime = currentTime >= startTime && currentTime <= endTime;

            return withinAllowedTime;
        }
    }
}
