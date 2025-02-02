﻿using System.Net.Http;
using System.Text;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DesktopAppAPI.DTO;
using DesktopPurchasingApp.DTO;
using DesktopPurchasingApp.Models;
using Newtonsoft.Json;

namespace DesktopPurchasingApp.ViewModels
{

    public partial class LoginViewModel : ObservableObject
    {
        public event Action? LoggedIn;

        public event Action? NotLoggedIn;

        public UserDto? User { get => user; private set => user = value; }

        private UserDto? user;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
        private string? username;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
        private string? password;


        [RelayCommand(CanExecute = nameof(CanLogin))]
        private async Task Login()
        {
            try
            {
                //Build dto
                LoginModel loginModel = new()
                {
                    Username = Username,
                    Password = Password
                };

                //Send dto to server
                HttpClient client = new()
                {
                    BaseAddress = new Uri("http://localhost:5000/")
                };
                var json = JsonConvert.SerializeObject(loginModel);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("api/Sessions", content);

                //Check response
                if (response.IsSuccessStatusCode)
                {
                    user = JsonConvert.DeserializeObject<UserDto>(response.Content.ReadAsStringAsync().Result);
                    LoggedIn?.Invoke();
                }
                else
                {
                    NotLoggedIn?.Invoke();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool CanLogin()
        => !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);
    }
}
