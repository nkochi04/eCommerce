using System.Windows.Input;
namespace DesktopPurchasingApp.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            //LoginCommand = new RelayCommand(Login);
        }

        private void Login()
        {
            // Your login logic here
            MainWindow mainWindow = new(null);
            mainWindow.Show();

            // Close the login window
            //this.Close();
        }
    }
}
