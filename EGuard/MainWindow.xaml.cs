using System.Windows;
using EGuard.Data.Repositories;
using EGuard.Data.Models;
using EGuard.Reporting;
using System.ComponentModel;

namespace EGuard
{
    public partial class MainWindow : Window
    {
        private readonly StructureMap.IContainer _container;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IKeywordRepository _keywordRepository;
        private readonly ISiteCategoryRepository _siteCategoryRepository;
        private readonly PasswordValidator _passwordValidator;
        private readonly ReportGenerator _reportGenerator;
        private readonly ReportViewer _reportViewer;

        public MainWindow()
        {
            InitializeComponent();

            _container = StructureMap.Container.For<MainRegistry>();
            _categoryRepository = _container.GetInstance<CategoryRepository>();
            _keywordRepository = _container.GetInstance<KeywordRepository>();
            _siteCategoryRepository = _container.GetInstance<SiteCategoryRepository>();
            _reportGenerator = _container.GetInstance<ReportGenerator>();
            _passwordValidator = _container.GetInstance<PasswordValidator>();
            _reportViewer = _container.GetInstance<ReportViewer>();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var proxy = _container.GetInstance<ProxyFacade>();

            cboBlockableCategories.ItemsSource = _categoryRepository.GetAllCategories();
            lstBlockedCategories.ItemsSource = _categoryRepository.GetBlockedCategories();
            cboAssignableCategories.ItemsSource = _categoryRepository.GetAllCategories();
            lstKeywords.ItemsSource = _keywordRepository.GetAllKeywords();
            lstPendingSites.ItemsSource = _siteCategoryRepository.GetPendingSites();


            //Primary.IsEnabled = false;
            //proxy.Start();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if(_passwordValidator.Validate())
            {
                base.OnClosing(e);
                return;
            }

            e.Cancel = true;
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
            var selectedUrl = (Site)lstPendingSites.SelectedItem;
            var selectedCategory = (Category)cboAssignableCategories.SelectedItem;

            var updatedSite = new Site
            {
                Url = selectedUrl.Url,
                Category = selectedCategory.Name
            };

            _siteCategoryRepository.UpdateWithCategory(updatedSite);
            lstPendingSites.ItemsSource = _siteCategoryRepository.GetPendingSites();
        }

        private void btnLock_Click(object sender, RoutedEventArgs e)
        {
            Primary.IsEnabled = false;
        }

        private void btnCreateReport_Click(object sender, RoutedEventArgs e)
        {
            _reportGenerator.Generate();
            _reportViewer.View();
        }

        private void btnUnlock_Click(object sender, RoutedEventArgs e)
        {
            if(_passwordValidator.Validate())
            {
                Primary.IsEnabled = true;
            }
        }
    }
}
