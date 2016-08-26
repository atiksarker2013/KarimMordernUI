using DarussalamModernUI.Report.Crystal;
using DarussalamModernUI.Report.Model;
using Data.DC;
using FirstFloor.ModernUI.Windows.Controls;
using Models;
using ReportApp;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace DarussalamModernUI
{
    /// <summary>
    /// Interaction logic for POSUI.xaml
    /// </summary>
    public partial class SalesReturn : ModernWindow
    {
        SalesContext salesManagerObj = new SalesContext();
        SalesDetailsContext salesDetailsManagerObj = new SalesDetailsContext();
        DarussalamBookContext bookContext = new DarussalamBookContext();
        DiscountContext discountContext = new DiscountContext();

        List<RDarusSalamBook> SalesInfoList = new List<RDarusSalamBook>();
        private int id;
        private Sales salesObj;

        public SalesReturn()
        {
            InitializeComponent();
        }

      
        public SalesReturn(Sales salesObj) : this()
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

            foreach (SalesDetails item in salesObj.SalesDetailsList)
            {
                List<DarusSalamBook> bookInfo = new List<DarusSalamBook>();
                bookInfo = bookContext.GetBookInfoByBookId(item.BookId);

                foreach (DarusSalamBook _bbok in bookInfo)
                {
                    item.Title = _bbok.Title;
                    item.Publisher = _bbok.Publisher;
                    item.Writer = _bbok.Writer;
                }
                // SalesDetails obj = new SalesDetails();
                posDatagrid.Items.Add(item);


            }

            // Load Discount Details

            List<Discounts> discountList = new List<Discounts>();
            discountList = discountContext.GetBookDiscountByInvoiceNo(salesObj.Id);
            foreach (Discounts item in discountList)
            {
                discountDatagrid.Items.Add(item);
            }


        }

      

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //DarusSalamBook chalan = new DarusSalamBook();
            //chalan = posDatagrid.SelectedItem as DarusSalamBook;// get selected item  
            ////                                                       // Other i am summarizing grid cell value in a combobox  
            //decimal TGBP = 0;
            //for (int i = 0; i < posDatagrid.Items.Count; i++)
            //{
            //    DarusSalamBook obj = posDatagrid.Items[i] as DarusSalamBook;
            //    obj.TotalUnitPrice = obj.Price * obj.OrderQty;
            //    TGBP += Convert.ToDecimal(obj.TotalUnitPrice); // getting cell value   
            //}
            //totalTextBox.Text = TGBP.ToString("F");

            //grandTotalTextBox.Text = TGBP.ToString("F");
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

            salesManagerObj.InsertDueReceive(salesreceiveObj);

            salesObj.Receive = Convert.ToDecimal(receiveTextBox.Text);
            salesObj.Due = salesObj.Due- salesObj.Receive;
            salesManagerObj.UpdateDue(salesObj);
            MessageBox.Show("Due Receive.", "Due Collection.", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();

        }

        private void discountTextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            Discounts obj = new Discounts();
            obj = discountDatagrid.SelectedItem as Discounts;// get selected item  
            if (obj!=null)
            {
                decimal finalDiscount = 0;
                decimal orginalPrice = Convert.ToDecimal(obj.TotalAmount);
                decimal discount = Convert.ToDecimal(obj.DiscountPercentage);
                var calculateDiscount = Convert.ToDecimal(orginalPrice / 100);
                finalDiscount = calculateDiscount * discount;
                obj.DiscountAmount = finalDiscount;
            }


            // Total Discount

            if (discountDatagrid.Items.Count>0)
            {
                decimal TGBP = 0;
                decimal GT = 0;
                for (int i = 0; i < discountDatagrid.Items.Count; i++)
                {
                    Discounts discountobj = discountDatagrid.Items[i] as Discounts;
                    //obj.TotalDiscountAmount = obj.Price * obj.OrderQty;
                    TGBP += Convert.ToDecimal(discountobj.DiscountAmount); // getting cell value   
                }
                GT = Convert.ToDecimal(totalTextBox.Text)- TGBP;
                discountTextBox.Text = TGBP.ToString("F");
                grandTotalTextBox.Text = GT.ToString("F");
            }
            

        }
    }
}
