using EGuard.Data;
using EGuard.Data.Models;
using System.IO;

namespace EGuard
{
    public class ReportGenerator : Report
    {
        private readonly SiteLogger _siteLogger;

        public ReportGenerator(SiteLogger siteLogger)
        {
            _siteLogger = siteLogger;
        }

        public void Generate()
        {
            var logs = _siteLogger.GetLogs();
            using (var sw = new StreamWriter(FileName))
            {
                foreach (var log in logs)
                {
                    sw.WriteLine(FormatReportLine(log));
                }
            }
        }

        private string FormatReportLine(Site site)
        {
            return string.Format("[{0}] {1}", site.Date, site.Url);
        }
    }
}
