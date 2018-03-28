using System.Windows;
using EGuard.Data;

namespace EGuard
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var c = new SiteInformationService();
            var t = c.GetSiteInfoAsJson("http://www.reddit.com");



            //ProxyFacade.Start();
        }
    }
}
