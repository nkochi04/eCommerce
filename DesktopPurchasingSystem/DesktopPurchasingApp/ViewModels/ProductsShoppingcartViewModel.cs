using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DesktopAppAPI.DTO;
using DesktopPurchasingApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Windows;

namespace DesktopPurchasingApp.ViewModels
{
    public partial class ProductsShoppingcartViewModel : ObservableObject
    {
        readonly UserDto user;

        public ProductsShoppingcartViewModel(UserDto user)
        {
            this.user = user;
            LoadProducts();
        }

        [ObservableProperty]
        private ObservableCollection<ProductObservable> productList = [];

        [ObservableProperty]
        private ObservableCollection<ProductObservable> shoppingCartList = [];

        [ObservableProperty]
        private string filter = string.Empty;

        partial void OnProductListChanged(ObservableCollection<ProductObservable> value)
        {
            foreach (var item in value)
            {
                var x = item.PiecesAvailable;
            }
        }

        [ObservableProperty]
        private string totalPriceOfCartString = $"Total price: {0} €";

        partial void OnFilterChanged(string? oldValue, string newValue)
        {
            if (newValue == "")
            {
                foreach (var item in ProductList)
                {
                    if (item.PiecesAvailable == 0)
                    {
                        item.Visibility = Visibility.Collapsed;
                    }
                    else
                    {
                        item.Visibility = Visibility.Visible;
                    }
                }
            }
            else
            {
                foreach (var item in ProductList)
                {
                    if (!item.Name.Contains((newValue), StringComparison.CurrentCultureIgnoreCase) || item.PiecesAvailable == 0)
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
            ProductObservable product = (ProductObservable)obj;
            ShoppingCartList.Remove(product);
            ProductList.Add(product);
            product.Amount = 1;
            TotalPriceOfCartString = $"Total price: {(decimal)ShoppingCartList.Sum(x => x.Price * x.Amount)} €";
        }

        [RelayCommand]
        private void IncreaseCount(object obj)
        {
            if (((ProductObservable)obj).Amount >= ((ProductObservable)obj).PiecesAvailable)
            {
                return;
            }
            var product = (ProductObservable)obj;
            product.Amount++;
            TotalPriceOfCartString = $"Total price: {(decimal)ShoppingCartList.Sum(x => x.Price * x.Amount)} €";
        }

        [RelayCommand]
        private void DecreaseCount(object obj)
        {
            if (((ProductObservable)obj).Amount <= 1)
            {
                return;
            }
            var product = (ProductObservable)obj;
            product.Amount--;
            TotalPriceOfCartString = $"Total price: {(decimal)ShoppingCartList.Sum(x => x.Price * x.Amount)} €";
        }

        [RelayCommand]
        private void AddItem(object obj)
        {
            var product = (ProductObservable)obj;
            ShoppingCartList.Add(product);
            ProductList.Remove(product);
            TotalPriceOfCartString = $"Total price: {(decimal)ShoppingCartList.Sum(x => x.Price * x.Amount)} €";

        }

        [RelayCommand]
        private async void PlaceOrder(object obj)
        {
            //create function constants
            HttpClient client = new()
            {
                BaseAddress = new Uri("http://localhost:5000/")
            };

            var id = Guid.NewGuid();

            //create order
            OrderDto order = new()
            {
                Id = Guid.NewGuid(),
                User_ID = user.Id,
                Products = ShoppingCartList.Select(p => new ProductDto
                {
                    ID = p.Id,
                    Pieces = p.Pieces.Where(x => x.Sold == false).Take(p.Amount).Select(p => new PieceDto
                    {
                        Serial_Number = p.Serial_Number,
                        ProductId = p.ProductId,
                    }).ToList(),
                }).ToList(),
            };

            var json = JsonConvert.SerializeObject(order);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("api/Orders", httpContent);

            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(response.ReasonPhrase);
                return;
            }

            //reload products
            LoadProducts();
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

                var deserializedProductList = JsonConvert.DeserializeObject<ObservableCollection<ProductObservable>>(await response.Content.ReadAsStringAsync());

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
}
