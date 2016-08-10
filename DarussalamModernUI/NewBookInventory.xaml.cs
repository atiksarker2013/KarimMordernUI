using DarussalamModernUI.Report.Model;
using Data.DC;
using FirstFloor.ModernUI.Windows.Controls;
using Models;
using System;
using System.Collections.Generic;
using System.Windows;

namespace DarussalamModernUI
{
    /// <summary>
    /// Interaction logic for POSUI.xaml
    /// </summary>
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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PopupNewBookEntryList obj = new PopupNewBookEntryList();
            obj.Show();

        }

        //private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    DarusSalamBook chalan = new DarusSalamBook();
        //    chalan = posDatagrid.SelectedItem as DarusSalamBook;// get selected item  
        //    //                                                       // Other i am summarizing grid cell value in a combobox  
        //    decimal TGBP = 0;
        //    for (int i = 0; i < posDatagrid.Items.Count; i++)
        //    {
        //        DarusSalamBook obj = posDatagrid.Items[i] as DarusSalamBook;
        //        obj.TotalUnitPrice = obj.Price * obj.OrderQty;
        //        TGBP += Convert.ToDecimal(obj.TotalUnitPrice); // getting cell value   
        //    }
        //    totalTextBox.Text = TGBP.ToString("F");

        //    grandTotalTextBox.Text = TGBP.ToString("F");
        //}

        //private void discountTextBox_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(discountTextBox.Text))
        //    {
        //        decimal finalDiscount = 0;
        //        decimal orginalPrice = Convert.ToDecimal(totalTextBox.Text);
        //        decimal discount = Convert.ToDecimal(discountTextBox.Text);
        //        var calculateDiscount = Convert.ToDecimal(orginalPrice / 100);
        //        finalDiscount = calculateDiscount * discount;
        //        discountAmountTextBox.Text = finalDiscount.ToString("F");
        //    }
        //}

        //private void discountAmountTextBox_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(discountAmountTextBox.Text))
        //    {
        //        decimal finalDiscount = 0;
        //        decimal orginalPrice = Convert.ToDecimal(totalTextBox.Text);
        //        decimal  discount = Convert.ToDecimal(discountTextBox.Text);
        //        decimal otherdiscount = Convert.ToDecimal(discountAmountTextBox.Text);
        //        var calculateGrandTotal = Convert.ToDecimal(orginalPrice- (otherdiscount+ discount));

        //        grandTotalTextBox.Text = calculateGrandTotal.ToString("F");
        //    }
        //}

        //private void receiveTextBox_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(receiveTextBox.Text))
        //    {
        //        decimal finalDiscount = 0;
        //        decimal orginalPrice = Convert.ToDecimal(grandTotalTextBox.Text);
        //        decimal discount = Convert.ToDecimal(receiveTextBox.Text);
        //        var calculateDue = Convert.ToDecimal(orginalPrice - discount);

        //        dueTextBox.Text = calculateDue.ToString("F");
        //    }
        //}

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
                salesDetails.EntryDate = DateTime.Now;
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

        }

        private void textBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        //private void discountTextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        //{
        //    Discounts obj = new Discounts();
        //    obj = discountDatagrid.SelectedItem as Discounts;// get selected item  
        //    if (obj!=null)
        //    {
        //        decimal finalDiscount = 0;
        //        decimal orginalPrice = Convert.ToDecimal(obj.TotalAmount);
        //        decimal discount = Convert.ToDecimal(obj.DiscountPercentage);
        //        var calculateDiscount = Convert.ToDecimal(orginalPrice / 100);
        //        finalDiscount = calculateDiscount * discount;
        //        obj.DiscountAmount = finalDiscount;
        //    }


        //    // Total Discount

        //    if (discountDatagrid.Items.Count>0)
        //    {
        //        decimal TGBP = 0;
        //        decimal GT = 0;
        //        for (int i = 0; i < discountDatagrid.Items.Count; i++)
        //        {
        //            Discounts discountobj = discountDatagrid.Items[i] as Discounts;
        //            //obj.TotalDiscountAmount = obj.Price * obj.OrderQty;
        //            TGBP += Convert.ToDecimal(discountobj.DiscountAmount); // getting cell value   
        //        }
        //        GT = Convert.ToDecimal(totalTextBox.Text)- TGBP;
        //        discountTextBox.Text = TGBP.ToString("F");
        //        grandTotalTextBox.Text = GT.ToString("F");
        //    }


        //}
    }
}
