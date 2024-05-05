﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DesktopPurchasingApp.Models;
using Newtonsoft.Json;

namespace DesktopPurchasingApp.ViewModels
{
    public partial class ProductsShoppingcartViewModel : ObservableObject
    {
        public ProductsShoppingcartViewModel()
        {
            LoadProducts();
        }

        [ObservableProperty]
        private ObservableCollection<Product> productList = [];

        [ObservableProperty]
        private string filter = string.Empty;

        partial void OnFilterChanged(string? oldValue, string newValue)
        {
            if(newValue == "")
            {
                foreach (var item in ProductList)
                {
                    item.Visibility = Visibility.Visible;
                }
            }
            else
            {
                foreach (var item in ProductList)
                {
                    if (!item.Name.Contains(newValue))
                    {
                        item.Visibility = Visibility.Collapsed;
                    }
                    else
                    {
                        item.Visibility = Visibility.Visible;
                    }
                }
            }
        }

        [RelayCommand]
        private void AddItem(object obj)
        {
            throw new NotImplementedException();
        }

        private async void LoadProducts()
        {
            try
            {
                //Send dto to server
                HttpClient client = new()
                {
                    BaseAddress = new Uri("http://localhost:5000/")
                };
                var response = await client.GetAsync("api/Products");

                //Check response
                if (response.IsSuccessStatusCode)
                {
                    ProductList =  JsonConvert.DeserializeObject<ObservableCollection<Product>>(response.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    MessageBox.Show(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

   

    public partial class Product : ObservableObject
    {
        [ObservableProperty]
        public Guid id;

        [ObservableProperty]
        public Guid seller_ID;

        [ObservableProperty]
        public string name = string.Empty;

        [ObservableProperty]
        public float price;

        [ObservableProperty]
        public int piecesAvailable;

        [ObservableProperty]
        public Visibility visibility = Visibility.Visible;
    }
}
