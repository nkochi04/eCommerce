using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesktopPurchasingApp.UserControls
{
    /// <summary>
    /// Interaction logic for Header.xaml
    /// </summary>
    public partial class Header : UserControl
    {
        public event RoutedEventHandler? CloseClick;
        public event RoutedEventHandler? MinimizeClick;
        public event RoutedEventHandler? MaximizeClick;

        public Header()
        {
            InitializeComponent();
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            MinimizeClick?.Invoke(this, e);
        }

        private void Maximize_Click(object sender, RoutedEventArgs e)
        {
            MaximizeClick?.Invoke(this, e);
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            CloseClick?.Invoke(this, e);
        }
    }
}
