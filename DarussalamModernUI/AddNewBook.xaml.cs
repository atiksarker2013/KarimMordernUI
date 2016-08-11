using DarussalamModernUI.Report.Model;
using Data.DC;
using FirstFloor.ModernUI.Windows.Controls;
using Models;
using System;
using System.Collections.Generic;
using System.Windows;

namespace DarussalamModernUI
{
    
    public partial class AddNewBook : ModernWindow
    {
        SalesContext salesManagerObj = new SalesContext();
        SalesDetailsContext salesDetailsManagerObj = new SalesDetailsContext();
        DarussalamBookContext bookContext = new DarussalamBookContext();
        DiscountContext discountContext = new DiscountContext();

        List<RDarusSalamBook> SalesInfoList = new List<RDarusSalamBook>();
        List<DarusSalamBook> newbookList = new List<DarusSalamBook>();
        
        public AddNewBook()
        {
            InitializeComponent();
            entryDateDatepicker.SelectedDate = DateTime.Today;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PopupBookList obj = new PopupBookList();
            obj.Show();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            
            DarusSalamBook obj = new DarusSalamBook();
            obj.Title = bookTitleTextBox.Text;
            obj.Writer = writerTextBox.Text;
            obj.Publisher = publisherTextBox.Text;
            obj.Price = Convert.ToDecimal(priceTextBox.Text);;
            obj.InStock = Convert.ToInt32(openingQtyTextBox.Text);
            obj.EntryDate = entryDateDatepicker.SelectedDate;
            posDatagrid.Items.Add(obj);
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

        //private void closeButton_Click(object sender, RoutedEventArgs e)
        //{
        //    this.Close();
        //}

        //private void saveButton_Click(object sender, RoutedEventArgs e)
        //{
        //    Sales salesObj = new Sales();

        //    salesObj.Name = customerNameTextBox.Text;
        //    salesObj.Mobile = MobileTextBox.Text;
        //    salesObj.Address = addressTextBox.Text;
        //    salesObj.Date = salesDateDatepicker.SelectedDate;

        //    if (cashPaytype.IsChecked==true)
        //    {
        //        salesObj.PayType = "Cash";
        //    }
        //    if (bikshPaytype.IsChecked == true)
        //    {
        //        salesObj.PayType = "Bikas";
        //        salesObj.PayNo=bikashNoTextBox.Text;
        //    }
        //    if (chequePaytype.IsChecked == true)
        //    {
        //        salesObj.PayType = "Cheque";
        //        salesObj.PayNo = chequeNoTextBox.Text;
        //    }

        //    salesObj.Total = Convert.ToDecimal(totalTextBox.Text);
        //    salesObj.Discount = Convert.ToDecimal(discountTextBox.Text);
        //    salesObj.OtherDiscount = Convert.ToDecimal(discountAmountTextBox.Text);
        //    salesObj.GrandTotal = Convert.ToDecimal(grandTotalTextBox.Text);
        //    salesObj.Receive = Convert.ToDecimal(receiveTextBox.Text);
        //    salesObj.Due = Convert.ToDecimal(dueTextBox.Text);

        //    int pk = 0;
        //    pk=salesManagerObj.Insert(salesObj);

        //    // Insert Book Details

        //    for (int i = 0; i < posDatagrid.Items.Count; i++)
        //    {
        //        DarusSalamBook obj = posDatagrid.Items[i] as DarusSalamBook;

        //        SalesDetails salesDetails = new SalesDetails();
        //        salesDetails.BookId = obj.Id;
        //        salesDetails.Price = (decimal)obj.Price;
        //        salesDetails.OrderQty = obj.OrderQty;
        //        salesDetails.SalesId = pk;
        //        salesDetailsManagerObj.Insert(salesDetails);
        //    }

        //    // Discount Insert

        //    for (int i = 0; i < discountDatagrid.Items.Count; i++)
        //    {
        //        Discounts obj = discountDatagrid.Items[i] as Discounts;

        //        Discounts discountObj = new Discounts();
        //        discountObj.InvoiceId = pk;
        //        discountObj.PublisherName =  obj.PublisherName;
        //        discountObj.TotalAmount = obj.TotalAmount;
        //        discountObj.DiscountPercentage = obj.DiscountPercentage;
        //        discountObj.DiscountAmount = obj.DiscountAmount;
        //        discountContext.Insert(discountObj);
        //    }


        //    // Update Stock

        //    for (int i = 0; i < posDatagrid.Items.Count; i++)
        //    {
        //        DarusSalamBook obj = posDatagrid.Items[i] as DarusSalamBook;
        //        obj.Qty = obj.Qty - obj.OrderQty;
        //        obj.OutOfStock = obj.OutOfStock + obj.OrderQty;
        //        bookContext.Update(obj);

        //        RDarusSalamBook reportObj = new RDarusSalamBook();
        //        reportObj.Id = obj.Id;
        //        reportObj.Title = obj.Title;
        //        reportObj.OrderQty = obj.OrderQty;
        //        reportObj.Price = (decimal)obj.Price;
        //        reportObj.Name = salesObj.Name;
        //        reportObj.Mobile = salesObj.Mobile;
        //        reportObj.Address = salesObj.Address;
        //        reportObj.Date = (DateTime)salesObj.Date;
        //        reportObj.PayType = salesObj.PayType;
        //        reportObj.PayNo = salesObj.PayNo;
        //        reportObj.Total =salesObj.Total  ;
        //        reportObj.Discount= salesObj.Discount  ;
        //        reportObj.GrandTotal = salesObj.GrandTotal  ;
        //        reportObj.Receive = salesObj.Receive ;
        //        reportObj.Due = salesObj.Due ;
        //        reportObj.InvoiceNo = pk;
        //        SalesInfoList.Add(reportObj);
        //    }



        //    if (SalesInfoList.Count > 0)
        //    {
        //        salesInvoiceCrystalReport employeeInfoCrystalReport = new salesInvoiceCrystalReport();
        //        ReportUtility.Display_report(employeeInfoCrystalReport, SalesInfoList, this);
        //    }
        //    else
        //    {
        //        MessageBox.Show("Don't have any records.", "Employee Info", MessageBoxButton.OK, MessageBoxImage.Information);
        //    }

        //    totalTextBox.Text = "";
        //    grandTotalTextBox.Text = "";
        //    discountTextBox.Text = "";
        //    discountAmountTextBox.Text = "";
        //    customerNameTextBox.Text = "";
        //    MobileTextBox.Text = "";
        //    addressTextBox.Text = "";
        //    cashPaytype.IsChecked = true;
        //    receiveTextBox.Text = "";
        //    dueTextBox.Text = "";
        //    posDatagrid.Items.Clear();
        //    discountDatagrid.Items.Clear();



        //}

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
