﻿using System.Windows;
using StructureMap;
using EGuard.Data;

namespace EGuard
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var container = Container.For<MainRegistry>();

            var proxy = container.GetInstance<ProxyFacade>();
            var categories = container.GetInstance<CategoryRepository>();

            lstAllCategories.ItemsSource = categories.GetAllCategories();
            lstBlockedCategories.ItemsSource = categories.GetBlockedCategories();
            cboAssignableCategories.ItemsSource = categories.GetAllCategories();

            //proxy.Start();
        }
    }
}
