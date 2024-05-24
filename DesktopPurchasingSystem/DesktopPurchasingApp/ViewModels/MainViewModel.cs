using System.Windows.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DesktopAppAPI.DTO;
using DesktopPurchasingApp.Models;
using DesktopPurchasingApp.pages;
using DesktopPurchasingApp.Pages;

namespace DesktopPurchasingApp.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        public UserDto? user;

        public MainViewModel(UserDto? user)
        {
            this.User = user;

            //Define shared viewmodel
            ProductsShoppingcartViewModel productsShoppingcartViewModel = new(User);

            //Define pages with viewmodels
            activePages[PageType.HomePage] = new Home(User)
            {
                DataContext = new HomeViewModel(User)
            };
            activePages[PageType.Products] = new Products()
            {
                DataContext = productsShoppingcartViewModel
            };
            activePages[PageType.ShoppingCart] = new ShoppingCart()
            {
                DataContext = productsShoppingcartViewModel
            };
            activePages[PageType.Orders] = new Orders()
            {
                DataContext = new OrderViewModel(User)
            };
        }

        public enum PageType
        {
            HomePage,
            Products,
            ShoppingCart,
            Orders
        }

        public Dictionary<PageType, Page> activePages = [];

        public Action? HomePageSelectedEvent { get; set; }
        public Action? ProductsSelectedEvent { get; set; }
        public Action? ShoppingCartSelectedEvent { get; set; }
        public Action? OrdersSelectedEvent { get; set; }

        [RelayCommand]
        private void HomePageSelected()
        {
            HomePageSelectedEvent?.Invoke();
        }

        [RelayCommand]
        private void ProductsSelected() 
        {
            ProductsSelectedEvent?.Invoke();
        }

        [RelayCommand]
        private void ShoppingCartSelected()
        {
            ShoppingCartSelectedEvent?.Invoke();
        }

        [RelayCommand]
        private void OrdersSelected()
        {
            OrdersSelectedEvent?.Invoke();
        }
    }
}
