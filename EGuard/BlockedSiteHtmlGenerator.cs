using System;
using System.IO;
using System.Windows;

namespace EGuard
{
    public class BlockedSiteHtmlGenerator
    {
        public string GetHtml()
        {
            var uri = new Uri("pack://application:,,,/Resources/blocked.html");
            var resourceStream = Application.GetResourceStream(uri);

            using (var reader = new StreamReader(resourceStream.Stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
