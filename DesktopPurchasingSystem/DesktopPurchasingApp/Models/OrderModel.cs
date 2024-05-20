using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

namespace DesktopPurchasingApp.Models
{
    public partial class OrderModel : ObservableObject
    {
        [Key]
        [ObservableProperty]
        public Guid id;

        [ObservableProperty]
        public Guid user_ID;

        [ObservableProperty]
        public Guid supplier_ID;

        [ObservableProperty]
        public ObservableCollection<Product>? productModels;
    }
}
