using DesktopAppAPI.DTO;
using DesktopPurchasingApp.ViewModels;
using System.Windows.Controls;

namespace DesktopPurchasingApp.pages
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        private HomeViewModel ViewModel => (HomeViewModel)DataContext;
        public Home(UserDto? user)
        {
            InitializeComponent();
        }
    }
}
