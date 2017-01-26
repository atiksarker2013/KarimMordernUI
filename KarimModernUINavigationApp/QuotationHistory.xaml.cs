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
                var obj = _karimInvoiceList.FirstOrDefault(d => d.IsCustomerSlNo == false);
                if (obj != null) obj.IsCustomerSlNo = true;
            }
            if (titleChkBox.IsChecked == true)
            {
                var obj = _karimInvoiceList.FirstOrDefault(d => d.IsTitle == false);
                if (obj != null) obj.IsTitle = true;
            }

            if (writerChkBox.IsChecked == true)
            {
                var obj = _karimInvoiceList.FirstOrDefault(d => d.IsWriter == false);
                if (obj != null) obj.IsWriter = true;
            }

            if (publisherChkBox.IsChecked == true)
            {
                var obj = _karimInvoiceList.FirstOrDefault(d => d.IsPublisher == false);
                if (obj != null) obj.IsPublisher = true;
            }

            if (isbnChkBox.IsChecked == true)
            {
                var obj = _karimInvoiceList.FirstOrDefault(d => d.IsBarcode == false);
                if (obj != null) obj.IsBarcode = true;
            }

            if (bookTypeChkBox.IsChecked == true)
            {
                var obj = _karimInvoiceList.FirstOrDefault(d => d.IsBookType == false);
                if (obj != null) obj.IsBookType = true;
            }

            if (publisherPriceChkBox.IsChecked == true)
            {

                var obj = _karimInvoiceList.FirstOrDefault(d => d.IsPublisherPrice == false);
                if (obj != null) obj.IsPublisherPrice = true;
            }

            if (publisherUnitChkBox.IsChecked == true)
            {
                var obj = _karimInvoiceList.FirstOrDefault(d => d.IsPublisherUnit == false);
                if (obj != null) obj.IsPublisherUnit = true;
            }

            if (priceChkBox.IsChecked == true)
            {
                var obj = _karimInvoiceList.FirstOrDefault(d => d.IsPrice == false);
                if (obj != null) obj.IsPrice = true;
            }

            if (stockQtyChkBox.IsChecked == true)
            {
                var obj = _karimInvoiceList.FirstOrDefault(d => d.IsInStock == false);
                if (obj != null) obj.IsInStock = true;
            }

            if (orderQtyChkBox.IsChecked == true)
            {
                var obj = _karimInvoiceList.FirstOrDefault(d => d.IsOrderQty == false);
                if (obj != null) obj.IsOrderQty = true;
            }

            if (totalUnitPriceChkBox.IsChecked == true)
            {
                var obj = _karimInvoiceList.FirstOrDefault(d => d.IsTotalUnitPrice == false);
                if (obj != null) obj.IsTotalUnitPrice = true;
            }

            if (discountChkBox.IsChecked == true)
            {
                var obj = _karimInvoiceList.FirstOrDefault(d => d.IsUnitDiscountPercent == false);
                if (obj != null) obj.IsUnitDiscountPercent = true;
            }

            if (discountTakaChkBox.IsChecked == true)
            {
                var obj = _karimInvoiceList.FirstOrDefault(d => d.IsDiscountTaka == false);
                if (obj != null) obj.IsDiscountTaka = true;
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
