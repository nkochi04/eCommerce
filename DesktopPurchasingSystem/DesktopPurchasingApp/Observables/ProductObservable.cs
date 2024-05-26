using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using DesktopPurchasingApp.Observables;

namespace DesktopPurchasingApp.Models
{
    public partial class ProductObservable : ObservableObject
    {
        [ObservableProperty]
        public Guid id;

        [ObservableProperty]
        public SellerObservable seller;

        [ObservableProperty]
        public string name = string.Empty;

        [ObservableProperty]
        public float price;

        [ObservableProperty]
        public int amount = 1;

        public string PriceString => $"${(decimal)Price * Pieces.Count}";

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(PiecesAvailable))]
        public ObservableCollection<PieceObservable> pieces = [];

        public int PiecesAvailable
        {
            get
            {
                var count = pieces.Where(x => x.sold == false).Count();
                if (count == 0)
                {
                    Visibility = Visibility.Collapsed;
                }
                return count;
            }
        }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(PiecesAvailable))]
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
