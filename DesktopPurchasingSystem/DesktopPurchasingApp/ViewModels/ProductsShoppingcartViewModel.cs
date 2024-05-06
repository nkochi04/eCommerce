﻿using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using System.Windows;
using System.Windows.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
        [NotifyCanExecuteChangedFor(nameof(IncreaseCountCommand))]
        [NotifyCanExecuteChangedFor(nameof(DecreaseCountCommand))]
        private ObservableCollection<Product> shoppingCartList = [];

        [ObservableProperty]
        private string filter = string.Empty;

        partial void OnFilterChanged(string? oldValue, string newValue)
        {
            if (newValue == "")
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
                    if (!item.Name.Contains((newValue), StringComparison.CurrentCultureIgnoreCase))
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
        private void RemoveItem(object obj)
        {
            ShoppingCartList.Remove((Product)obj);
        }

        [RelayCommand(CanExecute = nameof(CanIncreaseCount))]
        private void IncreaseCount(object obj)
        {
            var product = (Product)obj;
            product.Pieces++;
        }

        private bool CanIncreaseCount(object obj)
        {
            return obj != null ? ((Product)obj).PiecesAvailable > ((Product)obj).Pieces : true;
        }

        [RelayCommand(CanExecute = nameof(CanDecreaseCount))]
        private void DecreaseCount(object obj)
        {
            var product = (Product)obj;
            product.Pieces--;
        }

        private bool CanDecreaseCount(object obj)
        {
            return obj != null ? ((Product)obj).PiecesAvailable > ((Product)obj).Pieces : true;
        }

        [RelayCommand]
        private void AddItem(object obj)
        {
            ShoppingCartList.Add((Product)obj);
        }

        private async void LoadProducts()
        {
            try
            {
                HttpClient client = new()
                {
                    BaseAddress = new Uri("http://localhost:5000/")
                };
                var response = await client.GetAsync("api/Products");

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show(response.ReasonPhrase);
                    return;
                }

                var deserializedProductList = JsonConvert.DeserializeObject<ObservableCollection<Product>>(await response.Content.ReadAsStringAsync());

                if (deserializedProductList == null)
                {
                    MessageBox.Show("Failed to deserialize the product list.");
                    return;
                }

                ProductList = deserializedProductList;
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
        public int pieces = 1;

        [ObservableProperty]
        public Visibility visibility = Visibility.Visible;

        public byte[]? ImageData { get; set; }

        public BitmapImage? Image
        {
            get
            {
                if (ImageData == null)
                {
                    return null;
                }

                using var ms = new MemoryStream(ImageData);
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad; // Here we set the CacheOption to OnLoad
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
        }

    }
}
