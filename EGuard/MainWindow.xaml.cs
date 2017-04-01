using System.Windows;
using StructureMap;
using EGuard.Data;
using EGuard.Data.Models;
using System;
using System.Windows.Controls;

namespace EGuard
{
    public partial class MainWindow : Window
    {
        private readonly IContainer _container;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IKeywordRepository _keywordRepository;

        public MainWindow()
        {
            InitializeComponent();

            _container = Container.For<MainRegistry>();
            _categoryRepository = _container.GetInstance<CategoryRepository>();
            _keywordRepository = _container.GetInstance<KeywordRepository>();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var proxy = _container.GetInstance<ProxyFacade>();

            cboBlockableCategories.ItemsSource = _categoryRepository.GetAllCategories();
            lstBlockedCategories.ItemsSource = _categoryRepository.GetBlockedCategories();
            cboAssignableCategories.ItemsSource = _categoryRepository.GetAllCategories();
            lstKeywords.ItemsSource = _keywordRepository.GetAllKeywords();

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
            var selectedCategory = (Category)cboBlockableCategories.SelectedItem;
            _categoryRepository.BlockCategory(selectedCategory);

            lstBlockedCategories.ItemsSource = _categoryRepository.GetBlockedCategories();
        }

        private void btnBlockKeyword_Click(object sender, RoutedEventArgs e)
        {
            var keyword = new Keyword
            {
                Description = txtKeyword.Text
            };

            _keywordRepository.Add(keyword);
            txtKeyword.Clear();

            lstKeywords.ItemsSource = _keywordRepository.GetAllKeywords();
        }

        private void btnUnblockKeyword_Click(object sender, RoutedEventArgs e)
        {
            var selectedKeyword = (Keyword)lstKeywords.SelectedItem;
            _keywordRepository.Delete(selectedKeyword);

            lstKeywords.ItemsSource = _keywordRepository.GetAllKeywords();
        }

        private void btnAssignCategory_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btnLock_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
