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

namespace DesktopPurchasingApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UserModel user;
        public MainWindow(UserModel user)
        {
            InitializeComponent();
            this.user = user;

        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void GoToSC(object sender, RoutedEventArgs e)
        {
            navframe.Navigate(new Uri("Pages/Home.xaml", UriKind.Relative));
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {

            base.OnMouseLeftButtonDown(e);
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}