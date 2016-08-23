using DarussalamModernUI.Report.Model;
using Data.DC;
using FirstFloor.ModernUI.Windows.Controls;
using Models;
using System;
using System.Collections.Generic;
using System.Windows;

namespace DarussalamModernUI
{
  
    public partial class NewBookInventory : ModernWindow
    {
        SalesContext salesManagerObj = new SalesContext();
        SalesDetailsContext salesDetailsManagerObj = new SalesDetailsContext();
        DarussalamBookContext bookContext = new DarussalamBookContext();
        DiscountContext discountContext = new DiscountContext();

        BookStockUpdateContext _bookStockContext = new BookStockUpdateContext();

        List<RDarusSalamBook> SalesInfoList = new List<RDarusSalamBook>();
        public NewBookInventory()
        {
            InitializeComponent();
            salesDateDatepicker.SelectedDate = DateTime.Today;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PopupNewBookEntryList obj = new PopupNewBookEntryList();
            obj.Show();

        }

      
        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {

            //// Insert New Book Qty

            for (int i = 0; i < posDatagrid.Items.Count; i++)
            {
                DarusSalamBook obj = posDatagrid.Items[i] as DarusSalamBook;

                NewBookStockUpdate salesDetails = new NewBookStockUpdate();
                salesDetails.BookId = obj.Id;
                salesDetails.OldStock = obj.InStock;
                salesDetails.NewEntryQty = obj.NewEntryQty;
                salesDetails.EntryDate = salesDateDatepicker.SelectedDate;
                _bookStockContext.Insert(salesDetails);
            }




            // Update Stock

            for (int i = 0; i < posDatagrid.Items.Count; i++)
            {
                DarusSalamBook obj = posDatagrid.Items[i] as DarusSalamBook;
                obj.InStock = obj.InStock + obj.NewEntryQty;
                obj.Qty = obj.Qty + obj.NewEntryQty;
                bookContext.Update(obj);
            }

            posDatagrid.Items.Clear();

            MessageBox.Show("Stock update successfully.", "Stock Update", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void textBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            
        }

       
    }
}
