using FirstFloor.ModernUI.Windows.Controls;
using System.Windows;

namespace DarussalamModernUI
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            POSUI obj = new POSUI();
            obj.Show();
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            POSUI obj = new POSUI();
            obj.Show();
        }

        private void salesHistoryButton_Click(object sender, RoutedEventArgs e)
        {
            SalesHistory obj = new SalesHistory();
            obj.Show();
        }

        private void updateBookButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateBookInfo obj = new UpdateBookInfo();
            obj.Show();
        }

        private void updateBookPriceButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateBookPrice obj = new UpdateBookPrice();
            obj.Show();
        }

        private void receiveBookButton_Click(object sender, RoutedEventArgs e)
        {
            NewBookInventory obj = new NewBookInventory();
            obj.Show();
        }

        private void addnewBookButto_Click(object sender, RoutedEventArgs e)
        {
            AddNewBook obj = new AddNewBook();
            obj.Show();
        }

        private void stockUpdate_Click(object sender, RoutedEventArgs e)
        {
            StockUpdateReport obj = new StockUpdateReport();
            obj.Show();
          //  Update Stock Report
        }
    }
}
