using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DesktopPurchasingApp.Models
{
    public partial class PieceModel : ObservableObject
    {
        [ObservableProperty]
        public int serial_Number ;
        [ObservableProperty]
        public bool sold;
        [ObservableProperty]
        public Guid? orderId;
        [ObservableProperty]
        public Guid productId;
    }
}
