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
    /// Interaction logic for KarimPOSUI.xaml
    /// </summary>
    public partial class KarimPOSUI : ModernWindow
    {
        public KarimPOSUI()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            KarimPopupBookList obj = new KarimPopupBookList();
            obj.Show();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void discountTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void discountAmountTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void receiveTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void quatationButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {

        }

     
        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            KarimBook obj = new KarimBook();
            obj = posDatagrid.SelectedItem as KarimBook;// get selected item  
            if (obj != null)
            {
                decimal finalDiscount = 0;
                decimal orginalPrice = Convert.ToDecimal(obj.TotalUnitPrice);
                decimal discount = Convert.ToDecimal(obj.DiscountPercentage);
                var calculateDiscount = Convert.ToDecimal(orginalPrice / 100);
                finalDiscount = calculateDiscount * discount;
                obj.UnitWiseDiscountAmount = finalDiscount;

                obj.UnitWiseNetTaka = (orginalPrice - obj.UnitWiseDiscountAmount);
            }


            // Total Discount

            if (posDatagrid.Items.Count > 0)
            {
                decimal TTGBP = 0;
                decimal TGBP = 0;
                decimal GT = 0;
                for (int i = 0; i < posDatagrid.Items.Count; i++)
                {
                    KarimBook discountobj = posDatagrid.Items[i] as KarimBook;
                    //obj.TotalDiscountAmount = obj.Price * obj.OrderQty;
                    TGBP += Convert.ToDecimal(discountobj.UnitWiseDiscountAmount); // getting cell value  
                    GT += Convert.ToDecimal(discountobj.UnitWiseNetTaka);
                    TTGBP += Convert.ToDecimal(discountobj.TotalUnitPrice);
                }
                //totalTextBox.Text=
                discountTextBox.Text = TGBP.ToString("F");
                grandTotalTextBox.Text = GT.ToString("F");
                totalTextBox.Text = TTGBP.ToString("F");
            }
        }

        private void textBox2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
