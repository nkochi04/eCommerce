﻿using DesktopAppAPI.DTO;
using DesktopPurchasingApp.Pages;
using DesktopPurchasingApp.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace DesktopPurchasingApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel ViewModel => (MainViewModel)DataContext;
        private readonly UserDto? user;

        public MainWindow(UserDto? user)
        {
            InitializeComponent();
            DataContext = new MainViewModel(user);
            navframe.Navigate(ViewModel.activePages[MainViewModel.PageType.HomePage]);
            this.user = user;
            ViewModel.HomePageSelectedEvent += HomePageSelected;
            ViewModel.ProductsSelectedEvent += ProductsSelected;
            ViewModel.ShoppingCartSelectedEvent += ShoppingCartSelected;
            ViewModel.OrdersSelectedEvent += OrdersSelected;
        }

        private void HomePageSelected()
        {
            navframe.Navigate(ViewModel.activePages[MainViewModel.PageType.HomePage]);
        }

        private void ProductsSelected()
        {
            navframe.Navigate(ViewModel.activePages[MainViewModel.PageType.Products]);
        }

        private void ShoppingCartSelected()
        {
            navframe.Navigate(ViewModel.activePages[MainViewModel.PageType.ShoppingCart]);
        }

        private void OrdersSelected()
        {
            ((Orders)ViewModel.activePages[MainViewModel.PageType.Orders]).ViewModel.LoadOrders();
            navframe.Navigate(ViewModel.activePages[MainViewModel.PageType.Orders]);
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        private void Logout(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new();
            loginWindow.Show();
            Close();
        }
    }
}