using System.Windows;
using StructureMap;
using EGuard.Data;

namespace EGuard
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var container = Container.For<MainRegistry>();

            var proxy = container.GetInstance<ProxyFacade>();
            var categories = container.GetInstance<CategoryRepository>();

            lstAllCategories.ItemsSource = categories.GetAllCategories();

            //proxy.Start();
        }
    }
}
