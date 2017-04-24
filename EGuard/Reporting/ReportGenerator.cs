using EGuard.Data;
using EGuard.Data.Models;
using System;
using System.Diagnostics;
using System.IO;

namespace EGuard.Reporting
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
                sw.WriteLine("======= Sites =======");
                foreach (var log in logs)
                {
                    sw.WriteLine(FormatReportLine(log));
                }

                sw.WriteLine("======= Keys =======");
                sw.Write(FormatNewLines(MainWindow.ViewModel.KeyPresses));

                sw.WriteLine("");

                sw.WriteLine("======= Processes =======");
                foreach(var process in Process.GetProcesses())
                {
                    sw.WriteLine(process.ProcessName);
                }

            }
        }

        private string FormatReportLine(Site site)
        {
            return string.Format("[{0}] {1}", site.Date, site.Url);
        }

        private string FormatNewLines(string keys)
        {
            return keys.Replace("\r", Environment.NewLine);
        }
    }
}
