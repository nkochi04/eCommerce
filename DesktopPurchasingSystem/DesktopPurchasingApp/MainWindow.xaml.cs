using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DesktopPurchasingApp.Models;
using DesktopPurchasingApp.pages;
using DesktopPurchasingApp.ViewModels;

namespace DesktopPurchasingApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel ViewModel => (MainViewModel)DataContext;
        private readonly UserModel? user;

        public MainWindow(UserModel? user)
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
            throw new NotImplementedException();
        }

        private void OrdersSelected()
        {
            throw new NotImplementedException();
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