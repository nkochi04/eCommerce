using System.Net.Http;
using System.Text;
using System.Windows;
using DesktopPurchasingApp.DTO;
using DesktopPurchasingApp.Models;
using Newtonsoft.Json;

namespace DesktopPurchasingApp
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private async void Login(object sender, RoutedEventArgs e)
        {
            //Build dto
            LoginModel loginModel = new LoginModel
            {
                Username = usernameBox.Text,
                Password = passwordBox.Password
            };

            //Send dto to server
            HttpClient client = new();
            client.BaseAddress = new Uri("http://localhost:5000/api/Authenticate");
            var json = JsonConvert.SerializeObject(loginModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("api/login", content);

            //Check response
            if (response.IsSuccessStatusCode)
            {
                UserModel? user = JsonConvert.DeserializeObject<UserModel>(response.Content.ReadAsStringAsync().Result);
                // Open the main window
                MainWindow mainWindow = new(user);
                mainWindow.Show();

                // Close the login window
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            // Close the login window
            this.Close();
        }
    }
}
