using System.Windows;
using StructureMap;

namespace EGuard
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var container = Container.For<MainRegistry>();
            var proxy = container.GetInstance<ProxyFacade>();

            proxy.Start();
        }
    }
}
