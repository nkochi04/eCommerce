using System.Collections.ObjectModel;
using System.Net.Http;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using DesktopAppAPI.DTO;
using DesktopPurchasingApp.Models;
using Newtonsoft.Json;

namespace DesktopPurchasingApp.ViewModels
{
    public partial class OrderViewModel : ObservableObject
    { 
        private UserDto? user;
        public OrderViewModel(UserDto user) 
        {
            this.user = user;
            LoadOrders();
        }

        

        [ObservableProperty]
        public ObservableCollection<OrderObservable> orderList= [];

        //Load the orders of the user
        public async void LoadOrders()
        {
            try
            {
                HttpClient client = new()
                {
                    BaseAddress = new Uri("http://localhost:5000/")
                };
                var response = await client.GetAsync($"api/Orders/{user.Id}");

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show(response.ReasonPhrase);
                    return;
                }

                var deserializedProductList = JsonConvert.DeserializeObject<ObservableCollection<OrderObservable>>(await response.Content.ReadAsStringAsync());

                if (deserializedProductList == null)
                {
                    MessageBox.Show("Failed to deserialize the product list.");
                    return;
                }
                OrderList = deserializedProductList;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
