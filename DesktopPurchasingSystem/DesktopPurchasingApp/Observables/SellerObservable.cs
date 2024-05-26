using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DesktopPurchasingApp.Observables
{
    public partial class SellerObservable : ObservableObject
    {
        [ObservableProperty]
        public Guid id;
        [ObservableProperty]
        public string name;
        [ObservableProperty]
        public string email;
        [ObservableProperty]
        public Guid addressId;
    }
}
