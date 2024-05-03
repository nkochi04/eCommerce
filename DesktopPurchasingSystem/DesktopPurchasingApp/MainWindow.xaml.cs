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

namespace DesktopPurchasingApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(UserModel user)
        {
            InitializeComponent();

        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void GoToSC(object sender, RoutedEventArgs e)
        {
            navframe.Navigate(new Uri("pages/Home.xaml", UriKind.Relative));
        }
    }
}