using EGuard.Data.Models;
using System;

namespace EGuard.Rules
{
    public class TimeRule : IRule
    {
        public int Priority { get; } = 1;

        public bool Check(Site site)
        {
            var startTime = TimeSpan.Parse(MainWindow.ViewModel.StartTime);
            var endTime = TimeSpan.Parse(MainWindow.ViewModel.EndTime);
            var requestTime = TimeSpan.Parse(site.Date);

            var withinAllowedTime = requestTime >= startTime && requestTime <= endTime;

            return withinAllowedTime;
        }
    }
}
