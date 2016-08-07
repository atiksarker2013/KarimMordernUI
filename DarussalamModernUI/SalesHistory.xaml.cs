using FirstFloor.ModernUI.Windows.Controls;
using Models;
using System.Collections.Generic;

namespace DarussalamModernUI
{
    /// <summary>
    /// Interaction logic for SalesHistory.xaml
    /// </summary>
    public partial class SalesHistory : ModernWindow
    {
        public SalesHistory()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            List<Sales> salesList = new List<Sales>();
        }
    }
}
