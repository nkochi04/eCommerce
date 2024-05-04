using System.Windows.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DesktopPurchasingApp.Models;
using DesktopPurchasingApp.pages;

namespace DesktopPurchasingApp.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        public MainViewModel(UserModel? user)
        {
            activePages[PageType.HomePage] = new Home(user);
            //TODO: other pages
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

        [ObservableProperty]
        public bool isHomePageSelected = true;
        [ObservableProperty]
        public bool isProductsSelected = false;
        [ObservableProperty]
        public bool isShoppingCartSelected = false;
        [ObservableProperty]
        public bool isOrdersSelected = false;

        partial void OnIsHomePageSelectedChanged(bool oldValue, bool newValue)
        {
            if(newValue == true)
            {
                HomePageSelectedEvent?.Invoke();
                
            }
        }

        partial void OnIsProductsSelectedChanged(bool oldValue, bool newValue)
        {
            if (newValue == true)
            {
                ProductsSelectedEvent?.Invoke();
            }
        }

        partial void OnIsShoppingCartSelectedChanged(bool oldValue, bool newValue)
        {
            if (newValue == true)
            {
                ShoppingCartSelectedEvent?.Invoke();
            }
        }

        partial void OnIsOrdersSelectedChanged(bool oldValue, bool newValue)
        {
            if (newValue == true)
            {
                OrdersSelectedEvent?.Invoke();
            }
        }

        [RelayCommand]
        private void HomePageSelected()
        {
            ResetSelection();
            IsHomePageSelected = true;
        }

        [RelayCommand]
        private void ProductsSelected() 
        {
            ResetSelection();
            IsProductsSelected = true;
        }

        [RelayCommand]
        private void ShoppingCartSelected()
        {
            ResetSelection();
            IsShoppingCartSelected = true;
        }

        [RelayCommand]
        private void OrdersSelected()
        {
            ResetSelection();
            IsOrdersSelected = true;
        }

        private void ResetSelection() 
        {
            IsHomePageSelected = false;
            IsProductsSelected = false;
            IsShoppingCartSelected = false;
            IsOrdersSelected = false;
        }
    }
}
