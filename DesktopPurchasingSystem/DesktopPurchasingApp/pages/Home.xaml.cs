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
using DesktopPurchasingApp.ViewModels;

namespace DesktopPurchasingApp.pages
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        private HomeViewModel ViewModel => (HomeViewModel) DataContext;
        public Home(UserModel? user)
        {
            InitializeComponent();
            DataContext = new HomeViewModel(user);
        }
    }
}
