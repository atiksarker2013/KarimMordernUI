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
    public partial class QuotationHistory  
    {
        KarimQuotationContext quatationObj = new KarimQuotationContext();
        KarimQuotationContext quotationManagerObj = new KarimQuotationContext();
        public QuotationHistory()
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
            List<KarimInvoice> karimInvoiceList = new List<KarimInvoice>();
            karimInvoiceList = quatationObj.GetQuatationHistoryByDateRange(fromDate, toDate);


            posDatagrid.Items.Clear();

            foreach (KarimInvoice item in karimInvoiceList)
            {
                posDatagrid.Items.Add(item);
            }
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void printInfoContextMenu_Click(object sender, RoutedEventArgs e)
        {
            KarimInvoice chalan = new KarimInvoice();
            chalan = posDatagrid.SelectedItem as KarimInvoice;

            List<KarimInvoice> _karimInvoiceList = new List<KarimInvoice>();
            _karimInvoiceList = quotationManagerObj.GetQuotationInvoiceDetailsById(chalan.Id);

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
                if (item.Discount != null)
                {
                    inv.Discount = (decimal)item.Discount;
                }
                else
                {
                    inv.Discount = 0;
                }

                if (item.OtherDiscount != null)
                {
                    inv.OtherDiscount = (decimal)item.OtherDiscount;
                }
                else
                {
                    inv.OtherDiscount = 0;
                }

                if (item.GrandTotal != null)
                {
                    inv.GrandTotal = (decimal)item.GrandTotal;
                }
                else
                {
                    inv.GrandTotal = 0;
                }

                if (item.Receive != null)
                {
                    inv.Receive = (decimal)item.Receive;
                }
                else
                {
                    inv.Receive = 0;
                }

                if (item.Due != null)
                {
                    inv.Due = (decimal)item.Due;
                }
                else
                {
                    inv.Due = 0;
                }

                if (item.OrderQty != null)
                {
                    inv.OrderQty = (int)item.OrderQty;
                }
                else
                {
                    inv.OrderQty = 0;
                }

                if (item.Price != null)
                {
                    inv.Price = (decimal)item.Price;
                }
                else
                {
                    inv.Price = 0;
                }


                inv.TotalUnitPrice = (decimal)(item.OrderQty * item.Price);

                inv.CustomerSlNo = item.CustomerSlNo;

                if (item.UnitDiscountPercent != null)
                {
                    inv.UnitDiscountPercent = (decimal)item.UnitDiscountPercent;
                }
                else
                {
                    inv.UnitDiscountPercent = 0;
                }

                if (item.DiscountTaka != null)
                {
                    inv.DiscountTaka = (decimal)item.DiscountTaka;
                }
                else
                {
                    inv.DiscountTaka = 0;
                }


                if (item.NetTaka != null)
                {
                    inv.NetTaka = (decimal)item.NetTaka;
                }
                else
                {
                    inv.NetTaka = 0;
                }


                if (item.Date != null)
                {
                    inv.Date = (DateTime)item.Date;
                }
                else
                {
                    inv.Date = DateTime.Now;
                }


                inv.Title = item.Title;
                inv.Writer = item.Writer;
                inv.Publisher = item.Publisher;

                if (item.Qty != null)
                {
                    inv.Qty = (int)item.Qty;
                }
                else
                {
                    inv.Qty = 0;
                }


                if (item.PublisherPrice != null)
                {
                    inv.PublisherPrice = (decimal)item.PublisherPrice;
                }
                else
                {
                    inv.PublisherPrice = 0;
                }


                if (item.OutOfStock != null)
                {
                    inv.OutOfStock = (int)item.OutOfStock;
                }
                else
                {
                    inv.OutOfStock = 0;
                }


                if (item.InStock != null)
                {
                    inv.InStock = (int)item.InStock;
                }
                else
                {
                    inv.InStock = 0;
                }

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


            // MessageBox.Show("Invoice generatesuccessfully.", "POS", MessageBoxButton.OK, MessageBoxImage.Information);


            if (_karimInvoiceReportList.Count > 0)
            {
                QuotationCrystalReport employeeInfoCrystalReport = new QuotationCrystalReport();
                ReportUtility.Display_report(employeeInfoCrystalReport, _karimInvoiceReportList, this);

            }
            else
            {
                MessageBox.Show("Don't have any records.", "Karim Quotation", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            // LoadInvoiceDetails(chalan);
        }
    }
}
