using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace EGuard.Reporting
{
    public class ReportViewer : Report
    {
        public void View()
        {
            var directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            var file = Path.Combine(directory, FileName);

            Process.Start(file);
        }
    }
}
