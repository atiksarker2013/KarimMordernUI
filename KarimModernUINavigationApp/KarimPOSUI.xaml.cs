using FirstFloor.ModernUI.Windows.Controls;
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
    }
}
