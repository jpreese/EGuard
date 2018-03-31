using System.Windows;
using StructureMap;
using EGuard.Data;
using EGuard.Data.Models;

namespace EGuard
{
    public partial class MainWindow : Window
    {
        private readonly IContainer _container;
        private readonly ICategoryRepository _categoryRepository;

        public MainWindow()
        {
            InitializeComponent();

            _container = Container.For<MainRegistry>();
            _categoryRepository = _container.GetInstance<CategoryRepository>();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var proxy = _container.GetInstance<ProxyFacade>();

            lstAllCategories.ItemsSource = _categoryRepository.GetAllCategories();
            lstBlockedCategories.ItemsSource = _categoryRepository.GetBlockedCategories();
            cboAssignableCategories.ItemsSource = _categoryRepository.GetAllCategories();

            //proxy.Start();
        }

        private void btnUnblockCategory_Click(object sender, RoutedEventArgs e)
        {
            var selectedCategory = (Category)lstBlockedCategories.SelectedItem;
            _categoryRepository.UnblockCategory(selectedCategory);

            lstBlockedCategories.ItemsSource = _categoryRepository.GetBlockedCategories();
        }

        private void btnBlockCategory_Click(object sender, RoutedEventArgs e)
        {
            var selectedCategory = (Category)lstAllCategories.SelectedItem;
            _categoryRepository.BlockCategory(selectedCategory);

            lstBlockedCategories.ItemsSource = _categoryRepository.GetBlockedCategories();
        }
    }
}
