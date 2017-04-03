using EGuard.Data.Models;
using System;

namespace EGuard.Rules
{
    public class TimeRule : IRule
    {
        public bool Check(Site site)
        {
            var primary = new MainWindow();
            var startTime = TimeSpan.Parse(primary.cboStartTime.SelectedValue.ToString());
            var endTime = TimeSpan.Parse(primary.cboEndTime.SelectedValue.ToString());
            var requestTime = TimeSpan.Parse(site.Date);

            var withinAllowedTime = requestTime >= startTime && requestTime <= endTime;

            return withinAllowedTime;
        }
    }
}
