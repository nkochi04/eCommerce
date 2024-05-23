using System.Diagnostics;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DesktopAppAPI.DTO;
using DesktopPurchasingApp.Models;

namespace DesktopPurchasingApp.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        public HomeViewModel(UserDto? user)
        {
            User = user;
        }

        [ObservableProperty]
        private UserDto? user;

        [RelayCommand]
        private static void Email()
        {
            try
            {
                var psi = 
                Process.Start(new ProcessStartInfo { FileName = "mailto:nkochi04@gmail.com", UseShellExecute = true });
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
           
        }

        [RelayCommand]
        private static void GitHub()
        {
            try
            {
                Process.Start(new ProcessStartInfo("https://github.com/nkochi04/eCommerce") { UseShellExecute = true });
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
