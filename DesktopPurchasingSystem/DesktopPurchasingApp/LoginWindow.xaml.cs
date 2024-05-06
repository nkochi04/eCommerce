using System.Windows;
using System.Windows.Input;
using DesktopPurchasingApp.ViewModels;

namespace DesktopPurchasingApp
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private LoginViewModel ViewModel => (LoginViewModel)DataContext;
        public LoginWindow()
        {
            InitializeComponent();
            DataContext = new LoginViewModel();
            ViewModel.LoggedIn += LoggedIn;
            ViewModel.NotLoggedIn += NotLoggedIn;
        }

        private void NotLoggedIn()
        {
            MessageBox.Show("Invalid username or password");
        }

        private void LoggedIn()
        {
            MainWindow mainWindow = new(ViewModel.User);
            mainWindow.Show();

            // Close the login window
            Close();
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            // Close the login window
            Close();
        }

        private void PasswordChanged(object sender, RoutedEventArgs e)
        {
            ViewModel.Password = passwordBox.Password;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.Key == Key.Enter && loginButton.IsEnabled)
            {
                ViewModel.LoginCommand.Execute(null);
            }   
        }

        protected override void OnClosed(System.EventArgs e)
        {
            base.OnClosed(e);
            ViewModel.LoggedIn -= LoggedIn;
            ViewModel.NotLoggedIn -= NotLoggedIn;
        }
    }
}
