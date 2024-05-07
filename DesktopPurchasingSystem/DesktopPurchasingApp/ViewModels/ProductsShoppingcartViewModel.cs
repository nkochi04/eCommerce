using System.Collections.ObjectModel;
using System.ComponentModel;
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
            Product product = (Product)obj;
            if (ShoppingCartList.Contains(product))
            {
                ShoppingCartList.Remove(product);
                ProductList.Add(product);
                product.Pieces = 1;
            }
        }

        [RelayCommand]
        private void IncreaseCount(object obj)
        {
            if (((Product)obj).Pieces  >= ((Product)obj).PiecesAvailable)
            {
                return;
            }
            var product = (Product)obj;
            product.Pieces++;
        }

        [RelayCommand]
        private void DecreaseCount(object obj)
        {
            if (((Product)obj).Pieces <= 1)
            {
                return;
            }
            var product = (Product)obj;
            product.Pieces--;
        }

        [RelayCommand]
        private void AddItem(object obj)
        {
            var product = (Product)obj;
            if (!ShoppingCartList.Contains(product))
            {
                ShoppingCartList.Add(product);
                ProductList.Remove(product);
            }
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
