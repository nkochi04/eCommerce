using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

namespace DesktopPurchasingApp.Models
{
    public partial class OrderObservable : ObservableObject
    {
        [Key]
        [ObservableProperty]
        public Guid id;

        [ObservableProperty]
        public Guid user_ID;

        [ObservableProperty]
        public Guid supplier_ID;

        [ObservableProperty]
        public ObservableCollection<ProductObservable> products;

        [ObservableProperty]
        public string totalPriceOfOrderString = $"Total price: {0} €";
    }
}
