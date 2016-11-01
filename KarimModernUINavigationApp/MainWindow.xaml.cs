using FirstFloor.ModernUI.Windows.Controls;
using System.Windows;

namespace KarimModernUINavigationApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ModernWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            UpdateKarimBookInfo obj = new UpdateKarimBookInfo();
            obj.Show();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            NewKarimBookInventory obj = new NewKarimBookInventory();
            obj.Show();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            UpdateKarimBookPrice obj = new UpdateKarimBookPrice();
            obj.Show();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            KarimAddNewBook obj = new KarimAddNewBook();
            obj.Show();
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            UpdateKarimCurrency obj = new UpdateKarimCurrency();
            obj.Show();
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            KarimPOSUI obj = new KarimModernUINavigationApp.KarimPOSUI();
            obj.Show();
        }
    }
}
