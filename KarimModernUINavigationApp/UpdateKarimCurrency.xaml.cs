using Data.DC;
using FirstFloor.ModernUI.Windows.Controls;
using Models;
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

namespace KarimModernUINavigationApp
{
    /// <summary>
    /// Interaction logic for UpdateKarimCurrency.xaml
    /// </summary>
    public partial class UpdateKarimCurrency : ModernWindow
    {
        KarimCurrencyContext bookContext = new KarimCurrencyContext();
        public UpdateKarimCurrency()
        {
            InitializeComponent();
            LoadGird();
        }

        private void LoadGird()
        {
            List<KarimCurrency> list = bookContext.GetAllCurrency();

            foreach (KarimCurrency item in list)
            {
                bookGrid.Items.Add(item);
            }
        }

        private void updateBookButton_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < bookGrid.Items.Count; i++)
            {
                KarimCurrency obj = bookGrid.Items[i] as KarimCurrency;

                bookContext.Update(obj);

            }
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
