﻿ 
using Data.DC;
using FirstFloor.ModernUI.Windows.Controls;
using Models;
using ReportApp;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace KarimModernUINavigationApp
{
    /// <summary>
    /// Interaction logic for POSUI.xaml
    /// </summary>
    public partial class SalesReturn : ModernWindow
    {
        //SalesContext salesManagerObj = new SalesContext();
        //SalesDetailsContext salesDetailsManagerObj = new SalesDetailsContext();
        //DarussalamBookContext bookContext = new DarussalamBookContext();
        //DiscountContext discountContext = new DiscountContext();

        // List<RDarusSalamBook> SalesInfoList = new List<RDarusSalamBook>();

        KarimBookContext bookContext = new KarimBookContext();

        KarimSalesContext samesMager = new KarimSalesContext();


        private int id;
        private KarimSales salesObj;

        public SalesReturn()
        {
            InitializeComponent();
        }

      
        public SalesReturn(KarimSales salesObj) : this()
        {
            this.salesObj = salesObj;
            LoadSalesReturnDetails();
        }

        private void LoadSalesReturnDetails()
        {
            //load Sales Details
            customerNameTextBox.Text = salesObj.Name;
            MobileTextBox.Text = salesObj.Mobile;
             addressTextBox.Text = salesObj.Address;
             salesDateDatepicker.SelectedDate = salesObj.Date;

            if (salesObj.PayType == "Cash" )
            {
                cashPaytype.IsChecked = true;
            }
            if (salesObj.PayType == "Bikas")
            {
                bikshPaytype.IsChecked = true;
                 bikashNoTextBox.Text = salesObj.PayNo;
            }
            if (salesObj.PayType == "Cheque")
            {
                chequePaytype.IsChecked = true;
                 chequeNoTextBox.Text = salesObj.PayNo;
            }

            totalTextBox.Text = salesObj.Total.ToString();
            discountTextBox.Text = salesObj.Discount.ToString();
            discountAmountTextBox.Text = salesObj.OtherDiscount.ToString();
            grandTotalTextBox.Text = salesObj.GrandTotal.ToString();
            receiveTextBox.Text = salesObj.Receive.ToString();
            dueTextBox.Text = salesObj.Due.ToString();
            invoiceNoTextBox.Text = salesObj.Id.ToString();

            // Load Book Details

            foreach (KarimSalesDetails item in salesObj.SalesDetailsList)
            {
                //List<KarimSalesDetails> bookInfo = new List<KarimSalesDetails>();
                //bookInfo = bookContext.GetBookInfoByBookId(item.BookId);

                //foreach (KarimSalesDetails _bbok in bookInfo)
                //{
                //    item.Title = _bbok.Title;
                //    item.Publisher = _bbok.Publisher;
                //    item.Writer = _bbok.Writer;
                //}
                //// SalesDetails obj = new SalesDetails();
                //posDatagrid.Items.Add(item);


            }

            // Load Discount Details




        }

        private void discountAmountTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(discountAmountTextBox.Text))
            {
                decimal finalDiscount = 0;
                decimal orginalPrice = Convert.ToDecimal(totalTextBox.Text);
                decimal  discount = Convert.ToDecimal(discountTextBox.Text);
                decimal otherdiscount = Convert.ToDecimal(discountAmountTextBox.Text);
                var calculateGrandTotal = Convert.ToDecimal(orginalPrice- (otherdiscount+ discount));

                grandTotalTextBox.Text = calculateGrandTotal.ToString("F");
            }
        }

        private void receiveTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(receiveTextBox.Text))
            {
                decimal finalDiscount = 0;
                decimal orginalPrice = Convert.ToDecimal(grandTotalTextBox.Text);
                decimal discount = Convert.ToDecimal(receiveTextBox.Text);
                var calculateDue = Convert.ToDecimal(orginalPrice - discount);

                dueTextBox.Text = calculateDue.ToString("F");
            }
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            SalesReceiveDue salesreceiveObj = new SalesReceiveDue();
            salesreceiveObj.SalesInvoiceId = Convert.ToInt32(invoiceNoTextBox.Text);
            salesreceiveObj.CustomerInvoiceId = customerInvoiceNoTextBox.Text;
            salesreceiveObj.ReceiveAmount = Convert.ToDecimal(receiveTextBox.Text);
            salesreceiveObj.ReceiveDate = DateTime.Now;

            samesMager.InsertDueReceive(salesreceiveObj);

            salesObj.Receive = Convert.ToDecimal(receiveTextBox.Text);
            salesObj.Due = salesObj.Due - salesObj.Receive;
            samesMager.UpdateDue(salesObj);
            MessageBox.Show("Due Receive.", "Due Collection.", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();

        }

     
    }
}
