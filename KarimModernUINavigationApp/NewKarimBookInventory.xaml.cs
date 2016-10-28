using Data.DC;
using FirstFloor.ModernUI.Windows.Controls;
using Models;
using System.Windows;
using System.Windows.Controls;

namespace KarimModernUINavigationApp
{
    /// <summary>
    /// Interaction logic for NewKarimBookInventory.xaml
    /// </summary>
    public partial class NewKarimBookInventory : ModernWindow
    {
        KarimBookContext bookContext = new KarimBookContext();
        BookStockUpdateContext _bookStockContext = new BookStockUpdateContext();
        public NewKarimBookInventory()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PopupKarimNewBookEntryList obj = new PopupKarimNewBookEntryList();
            obj.Show();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            //// Insert New Book Qty

            for (int i = 0; i < posDatagrid.Items.Count; i++)
            {
                KarimBook obj = posDatagrid.Items[i] as KarimBook;

                KarimNewBookStockUpdate salesDetails = new KarimNewBookStockUpdate();
                salesDetails.BookId = obj.Id;
                salesDetails.OldStock = obj.InStock;
                salesDetails.NewEntryQty = obj.NewEntryQty;
                salesDetails.EntryDate = salesDateDatepicker.SelectedDate;
                _bookStockContext.Insert(salesDetails);
            }




            // Update Stock

            for (int i = 0; i < posDatagrid.Items.Count; i++)
            {
                KarimBook obj = posDatagrid.Items[i] as KarimBook;
                obj.InStock = obj.InStock + obj.NewEntryQty;
                //  obj.Qty = obj.Qty + obj.NewEntryQty;
                bookContext.Update(obj);
            }

            posDatagrid.Items.Clear();

            MessageBox.Show("Stock update successfully.", "Stock Update", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
