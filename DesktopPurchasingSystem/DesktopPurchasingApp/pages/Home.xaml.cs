using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

namespace DesktopPurchasingApp.pages
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        private UserModel user;
        public Home()
        {
            InitializeComponent();
        }

        public void Logout(object sender, RoutedEventArgs e)
        {
            // Close the main window
            //this.Close();
        }

        public async void Email(object sender, RoutedEventArgs e)
        {
            var psi = new ProcessStartInfo
            {
                FileName = "mailto:nkochi04@gmail.com",
                UseShellExecute = true
            };
            Process.Start(psi);
        }

        private void GitHub(object sender, RoutedEventArgs e)
        {
            string url = "https://github.com/nkochi04/eCommerce";

            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(url) { UseShellExecute = true });
            }
            catch (Exception)
            {
                // Handle the exception if the web browser can't be opened
            }
        }
    }
}
