using Data.DC;
using KarimModernUINavigationApp.Report.Crystal;
using KarimModernUINavigationApp.Report.Model;
using Models;
using ReportApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace KarimModernUINavigationApp
{
    /// <summary>
    /// Interaction logic for QuotationHistory.xaml
    /// </summary>
    public partial class InvoiceHistory
    {
        KarimQuotationContext quatationObj = new KarimQuotationContext();
        KarimQuotationContext quotationManagerObj = new KarimQuotationContext();
        public InvoiceHistory()
        {
            InitializeComponent();
            fromDateDatepicker.SelectedDate = DateTime.Today;
            toDateDatepicker.SelectedDate = DateTime.Today;
            cusNoChkBox.IsChecked = true;
            titleChkBox.IsChecked = true;
            writerChkBox.IsChecked = true;
            publisherChkBox.IsChecked = true;
            isbnChkBox.IsChecked = true;
            bookTypeChkBox.IsChecked = true;
            publisherPriceChkBox.IsChecked = true;
            publisherUnitChkBox.IsChecked = true;
            priceChkBox.IsChecked = true;
            stockQtyChkBox.IsChecked = true;
            orderQtyChkBox.IsChecked = true;
            totalUnitPriceChkBox.IsChecked = true;
            discountChkBox.IsChecked = true;
            discountTakaChkBox.IsChecked = true;

           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DateTime fromDate = Convert.ToDateTime(fromDateDatepicker.SelectedDate);
            DateTime toDate = Convert.ToDateTime(toDateDatepicker.SelectedDate);
            List<KarimSales> karimInvoiceList = new List<KarimSales>();
            karimInvoiceList = quatationObj.GetInvoiceHistoryByDateRange(fromDate, toDate);

          

            posDatagrid.Items.Clear();

            foreach (KarimSales item in karimInvoiceList)
            {
                if (item.Due == 0)
                {
                    item.Status = "Paid";
                }
                else
                {
                    item.Status = "Un Paid";
                }

                posDatagrid.Items.Add(item);
            }
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void printInfoContextMenu_Click(object sender, RoutedEventArgs e)
        {
            KarimSales chalan = new KarimSales();
            chalan = posDatagrid.SelectedItem as KarimSales;

            List<KarimInvoice> _karimInvoiceList = new List<KarimInvoice>();
            _karimInvoiceList = quotationManagerObj.GetSalesInvoiceDetailsById(chalan.Id);

            if (cusNoChkBox.IsChecked == true)
            {
                foreach (var obj in _karimInvoiceList)
                {
                    obj.IsCustomerSlNo = true;
                }
 
            }
            if (titleChkBox.IsChecked == true)
            {
                foreach (var obj in _karimInvoiceList)
                {
                    obj.IsTitle = true;
                }
                 
            }

            if (writerChkBox.IsChecked == true)
            {
                foreach (var obj in _karimInvoiceList)
                {
                    obj.IsWriter = true;
                }
               
            }

            if (publisherChkBox.IsChecked == true)
            {
                foreach (var obj in _karimInvoiceList)
                {
                    obj.IsPublisher = true;
                }
                
            }

            if (isbnChkBox.IsChecked == true)
            {
                foreach (var obj in _karimInvoiceList)
                {
                    obj.IsBarcode = true;
                }
                 
            }

            if (bookTypeChkBox.IsChecked == true)
            {
                foreach (var obj in _karimInvoiceList)
                {
                    obj.IsBookType = true;
                }
                
            }

            if (publisherPriceChkBox.IsChecked == true)
            {
                foreach (var obj in _karimInvoiceList)
                {
                    obj.IsPublisherPrice = true;
                }
               
            }

            if (publisherUnitChkBox.IsChecked == true)
            {
                foreach (var obj in _karimInvoiceList)
                {
                    obj.IsPublisherUnit = true;
                }
                 
            }

            if (priceChkBox.IsChecked == true)
            {
                foreach (var obj in _karimInvoiceList)
                {
                    obj.IsPrice = true;
                }

                
            }

            if (stockQtyChkBox.IsChecked == true)
            {
                foreach (var obj in _karimInvoiceList)
                {
                    obj.IsInStock = true;
                }
                
            }

            if (orderQtyChkBox.IsChecked == true)
            {
                foreach (var obj in _karimInvoiceList)
                {
                    obj.IsOrderQty = true;
                }
               
            }

            if (totalUnitPriceChkBox.IsChecked == true)
            {
                foreach (var obj in _karimInvoiceList)
                {
                    obj.IsTotalUnitPrice = true;
                }
               
            }

            if (discountChkBox.IsChecked == true)
            {
                foreach (var obj in _karimInvoiceList)
                {
                    obj.IsUnitDiscountPercent = true;
                }
                
            }

            if (discountTakaChkBox.IsChecked == true)
            {
                foreach (var obj in _karimInvoiceList)
                {
                    obj.IsDiscountTaka = true;
                }
                
            }


            List<RKarimInvoice> _karimInvoiceReportList = new List<RKarimInvoice>();
            foreach (KarimInvoice item in _karimInvoiceList)
            {
                RKarimInvoice inv = new RKarimInvoice();
                inv.Id = item.Id;
                inv.Name = item.Name;
                inv.Mobile = item.Mobile;
                inv.Address = item.Address;
                inv.CustomerRefNo = item.CustomerRefNo;
                inv.KarimRefNo = item.KarimRefNo;
                inv.PayType = item.PayType;
                inv.PayNo = item.PayNo;
                inv.Total = item.Total;
                inv.Discount = (decimal)item.Discount;
                inv.OtherDiscount = (decimal)item.OtherDiscount;
                inv.GrandTotal = (decimal)item.GrandTotal;
                inv.Receive = (decimal)item.Receive;
                inv.Due = (decimal)item.Due;
                inv.OrderQty = (int)item.OrderQty;
                inv.Price = (decimal)item.Price;
                inv.TotalUnitPrice = (decimal)(item.OrderQty * item.Price);
                inv.CustomerSlNo = item.CustomerSlNo;
                inv.UnitDiscountPercent = (decimal)item.UnitDiscountPercent;
                inv.DiscountTaka = (decimal)item.DiscountTaka;
                inv.NetTaka = (decimal)item.NetTaka;
                inv.Date = (DateTime)item.Date;

                inv.Title = item.Title;
                inv.Writer = item.Writer;
                inv.Publisher = item.Publisher;
                inv.Qty = (int)item.Qty;
                inv.PublisherPrice = (decimal)item.PublisherPrice;
                inv.OutOfStock = (int)item.OutOfStock;
                inv.InStock = (int)item.InStock;
                inv.Barcode = item.Barcode;
                inv.PublishYear = item.PublishYear.ToString();
                inv.PayNo = item.DeliveryTime;  // Temp Solution
                inv.Edition = item.Edition;
                inv.BookBinding = item.BookBinding;
                inv.PublisherUnit = item.PublisherUnit;
                inv.BookType = item.BookType;
                inv.IsCustomerSlNo = item.IsCustomerSlNo;
                inv.IsTitle = item.IsTitle;
                inv.IsWriter = item.IsWriter;
                inv.IsPublisher = item.IsPublisher;
                inv.IsBarcode = item.IsBarcode;
                inv.IsBookType = item.IsBookType;
                inv.IsPublisherPrice = item.IsPublisherPrice;
                inv.IsPublisherUnit = item.IsPublisherUnit;
                inv.IsPrice = item.IsPrice;
                inv.IsInStock = item.IsInStock;
                inv.IsOrderQty = item.IsOrderQty;
                inv.IsTotalUnitPrice = item.IsTotalUnitPrice;
                inv.IsUnitDiscountPercent = item.IsUnitDiscountPercent;
                inv.IsDiscountTaka = item.IsDiscountTaka;
                _karimInvoiceReportList.Add(inv);
            }

            if (_karimInvoiceReportList.Count > 0)
            {
                InvoiceCrystalReport employeeInfoCrystalReport = new InvoiceCrystalReport();
                ReportUtility.Display_report(employeeInfoCrystalReport, _karimInvoiceReportList, this);

            }
            else
            {
                MessageBox.Show("Don't have any records.", "Employee Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void receiveDueContextMenu_Click(object sender, RoutedEventArgs e)
        {
            KarimSales chalan = new KarimSales();
            chalan = posDatagrid.SelectedItem as KarimSales;
            if (chalan.Due > 0)
            {
                SalesReturn obj = new SalesReturn(chalan);
                obj.Show();
            }
            else
            {
                MessageBox.Show("There is no pending payment.", "Sales History", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }
    }
}
