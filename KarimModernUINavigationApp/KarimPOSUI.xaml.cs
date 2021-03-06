﻿using Data;
using Data.DC;
using FirstFloor.ModernUI.Windows.Controls;
using KarimModernUINavigationApp.Report.Crystal;
using KarimModernUINavigationApp.Report.Model;
using Models;
using ReportApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace KarimModernUINavigationApp
{
    /// <summary>
    /// Interaction logic for KarimPOSUI.xaml
    /// </summary>
    public partial class KarimPOSUI : ModernWindow
    {

        KarimQuotationContext quotationManagerObj = new KarimQuotationContext();
        KarimSalesContext salesManagerObj = new KarimSalesContext();
        KarimSalesDetailsContext salesDetailsManagerObj = new KarimSalesDetailsContext();
        KarimQuotationDetailsContext quotationDetailsManagerObj = new KarimQuotationDetailsContext();

        
        KarimBookContext bookContext = new KarimBookContext();
        public KarimPOSUI()
        {
            InitializeComponent();
            salesDateDatepicker.SelectedDate = DateTime.Now;
            effectOnStock.IsChecked = true;
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

            cashPaytype.IsChecked = true;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                KarimPopupBookList obj = new KarimPopupBookList();
                obj.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
           
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            KarimBook chalan = new KarimBook();
            chalan = posDatagrid.SelectedItem as KarimBook;// get selected item  
            //                                                       // Other i am summarizing grid cell value in a combobox  
           // decimal TGBP = 0;
            for (int i = 0; i < posDatagrid.Items.Count; i++)
            {
                KarimBook obj = posDatagrid.Items[i] as KarimBook;
                obj.TotalUnitPrice = obj.Price * obj.OrderQty;
               // TGBP += Convert.ToDecimal(obj.TotalUnitPrice); // getting cell value   
            }


            if (posDatagrid.Items.Count > 0)
            {
                decimal TTGBP = 0;
                decimal TGBP = 0;
                decimal GT = 0;
                for (int i = 0; i < posDatagrid.Items.Count; i++)
                {
                    KarimBook discountobj = posDatagrid.Items[i] as KarimBook;
                    //obj.TotalDiscountAmount = obj.Price * obj.OrderQty;
                    TGBP += Convert.ToDecimal(discountobj.UnitWiseDiscountAmount); // getting cell value  
                    GT += Convert.ToDecimal(discountobj.UnitWiseNetTaka);
                    TTGBP += Convert.ToDecimal(discountobj.TotalUnitPrice);
                }
                //totalTextBox.Text=
                discountTextBox.Text = TGBP.ToString("F");
                grandTotalTextBox.Text = GT.ToString("F");
                totalTextBox.Text = TTGBP.ToString("F");
            }

        }

        private void discountTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void discountAmountTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (!string.IsNullOrEmpty(discountAmountTextBox.Text))
            {
                decimal finalDiscount = 0;
                decimal orginalPrice = Convert.ToDecimal(totalTextBox.Text);
                decimal discount = Convert.ToDecimal(discountTextBox.Text);
                decimal otherdiscount = Convert.ToDecimal(discountAmountTextBox.Text);
                var calculateGrandTotal = Convert.ToDecimal(orginalPrice - (otherdiscount + discount));

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

        private void quatationButton_Click(object sender, RoutedEventArgs e)
        {
            //

            try
            {
                KarimSales salesObj = new KarimSales();
                salesObj.Name = customerNameTextBox.Text;
                salesObj.Mobile = MobileTextBox.Text;
                salesObj.Address = addressTextBox.Text;
                salesObj.Date = salesDateDatepicker.SelectedDate;
                salesObj.CustomerRefNo = customerRefNoTextBox.Text;
                salesObj.KarimRefNo = karimRefNoTextBox.Text;

                if (cashPaytype.IsChecked == true)
                {
                    salesObj.PayType = "Cash";
                }
                if (bikshPaytype.IsChecked == true)
                {
                    salesObj.PayType = "Bikas";
                    salesObj.PayNo = bikashNoTextBox.Text;
                }
                if (chequePaytype.IsChecked == true)
                {
                    salesObj.PayType = "Cheque";
                    salesObj.PayNo = chequeNoTextBox.Text;
                }

                salesObj.Total = Convert.ToDecimal(totalTextBox.Text);
                salesObj.Discount = Convert.ToDecimal(discountTextBox.Text);
                if (!string.IsNullOrEmpty(discountAmountTextBox.Text))
                {
                    salesObj.OtherDiscount = Convert.ToDecimal(discountAmountTextBox.Text);
                }
                else
                {
                    salesObj.OtherDiscount = 0;
                }
                if (!string.IsNullOrEmpty(curiarTextBox.Text))
                {
                    salesObj.CuriarCharg = Convert.ToDecimal(curiarTextBox.Text);
                }
                else
                {
                    salesObj.CuriarCharg = 0;
                }

                if (!string.IsNullOrEmpty(grandTotalTextBox.Text))
                {
                    salesObj.GrandTotal = Convert.ToDecimal(grandTotalTextBox.Text);
                }
                else
                {
                    salesObj.GrandTotal = 0;
                }


                if (!string.IsNullOrEmpty(receiveTextBox.Text))
                {
                    salesObj.Receive = Convert.ToDecimal(receiveTextBox.Text);
                }
                else
                {
                    salesObj.Receive = 0;
                }

                if (!string.IsNullOrEmpty(dueTextBox.Text))
                {
                    salesObj.Due = Convert.ToDecimal(dueTextBox.Text);
                }
                else
                {
                    salesObj.Due = 0;
                }


                int pk = 0;
                pk = quotationManagerObj.Insert(salesObj);

                // Insert Book Details

                for (int i = 0; i < posDatagrid.Items.Count; i++)
                {
                    KarimBook obj = posDatagrid.Items[i] as KarimBook;
                    if (obj.OrderQty > 0)
                    {
                        KarimSalesDetails salesDetails = new KarimSalesDetails();
                        salesDetails.BookId = obj.Id;
                        salesDetails.Price = (decimal)obj.Price;
                        salesDetails.OrderQty = obj.OrderQty;
                        salesDetails.SalesId = pk;
                        salesDetails.CustomerSlNo = obj.CustomerSlNo;
                        salesDetails.UnitDiscountPercent = obj.DiscountPercentage;
                        salesDetails.DiscountTaka = obj.UnitWiseDiscountAmount;
                        salesDetails.NetTaka = obj.UnitWiseNetTaka;
                        salesDetails.DeliveryTime = obj.DeliveryTime;

                        quotationDetailsManagerObj.Insert(salesDetails);
                    }

                }

                List<KarimInvoice> _karimInvoiceList = new List<KarimInvoice>();
                _karimInvoiceList = quotationManagerObj.GetQuotationInvoiceDetailsById(pk);


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
                    RKarimInvoice inv = new  RKarimInvoice();
                    inv.Id = item.Id;
                    inv.Name = item.Name;
                    inv.Mobile = item.Mobile;
                    inv.Address = item.Address;
                    inv.CustomerRefNo = item.CustomerRefNo;
                    inv.KarimRefNo = item.KarimRefNo;
                    inv.PayType = item.PayType;
                    inv.PayNo = item.PayNo;
                    inv.Total =  item.Total;
                    if (item.Discount!=null)
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


                MessageBox.Show("Quotation generate successfully.", "POS", MessageBoxButton.OK, MessageBoxImage.Information);


                if (_karimInvoiceReportList.Count > 0)
                {
                    QuotationCrystalReport employeeInfoCrystalReport = new QuotationCrystalReport();
                    ReportUtility.Display_report(employeeInfoCrystalReport, _karimInvoiceReportList, this);

                }
                else
                {
                    MessageBox.Show("Don't have any records.", "Employee Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                totalTextBox.Text = "";
                grandTotalTextBox.Text = "";
                discountTextBox.Text = "";
                discountAmountTextBox.Text = "";
                customerNameTextBox.Text = "";
                MobileTextBox.Text = "";
                addressTextBox.Text = "";
                cashPaytype.IsChecked = true;
                receiveTextBox.Text = "";
                dueTextBox.Text = "";
                curiarTextBox.Text = "";
                posDatagrid.Items.Clear();
                // discountDatagrid.Items.Clear();
                GlobalVar.TempOrderBookList = new List<KarimBook>();


                //dbContextTransaction.Commit();
            }
            catch (Exception ex)
            {

                MessageBox.Show( ex.Message.ToString());
            }




        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new KARIM_INT_HOUSTONEEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {


                        KarimSales salesObj = new KarimSales();
                        salesObj.Name = customerNameTextBox.Text;
                        salesObj.Mobile = MobileTextBox.Text;
                        salesObj.Address = addressTextBox.Text;
                        salesObj.Date = salesDateDatepicker.SelectedDate;
                        salesObj.CustomerRefNo = customerRefNoTextBox.Text;
                        salesObj.KarimRefNo = karimRefNoTextBox.Text;

                        if (cashPaytype.IsChecked == true)
                        {
                            salesObj.PayType = "Cash";
                        }
                        if (bikshPaytype.IsChecked == true)
                        {
                            salesObj.PayType = "Bikas";
                            salesObj.PayNo = bikashNoTextBox.Text;
                        }
                        if (chequePaytype.IsChecked == true)
                        {
                            salesObj.PayType = "Cheque";
                            salesObj.PayNo = chequeNoTextBox.Text;
                        }

                        salesObj.Total = Convert.ToDecimal(totalTextBox.Text);
                        salesObj.Discount = Convert.ToDecimal(discountTextBox.Text);
                        if (!string.IsNullOrEmpty(discountAmountTextBox.Text))
                        {
                            salesObj.OtherDiscount = Convert.ToDecimal(discountAmountTextBox.Text);
                        }
                        else
                        {
                            salesObj.OtherDiscount = 0;
                        }
                        if (!string.IsNullOrEmpty(curiarTextBox.Text))
                        {
                            salesObj.CuriarCharg = Convert.ToDecimal(curiarTextBox.Text);
                        }
                        else
                        {
                            salesObj.CuriarCharg = 0;
                        }

                        if (!string.IsNullOrEmpty(grandTotalTextBox.Text))
                        {
                            salesObj.GrandTotal = Convert.ToDecimal(grandTotalTextBox.Text);
                        }
                        else
                        {
                            salesObj.GrandTotal = 0;
                        }


                        if (!string.IsNullOrEmpty(receiveTextBox.Text))
                        {
                            salesObj.Receive = Convert.ToDecimal(receiveTextBox.Text);
                        }
                        else
                        {
                            salesObj.Receive = 0;
                        }

                        if (!string.IsNullOrEmpty(dueTextBox.Text))
                        {
                            salesObj.Due = Convert.ToDecimal(dueTextBox.Text);
                        }
                        else
                        {
                            salesObj.Due = 0;
                        }

                        int pk = 0;
                        pk = salesManagerObj.Insert(salesObj);

                        // Insert Book Details

                        for (int i = 0; i < posDatagrid.Items.Count; i++)
                        {
                            KarimBook obj = posDatagrid.Items[i] as KarimBook;
                            if (obj.OrderQty > 0)
                            {
                                KarimSalesDetails salesDetails = new KarimSalesDetails();
                                salesDetails.BookId = obj.Id;
                                salesDetails.Price = (decimal)obj.Price;
                                salesDetails.OrderQty = obj.OrderQty;
                                salesDetails.SalesId = pk;
                                salesDetails.CustomerSlNo = obj.CustomerSlNo;
                                salesDetails.UnitDiscountPercent = obj.DiscountPercentage;
                                salesDetails.DiscountTaka = obj.UnitWiseDiscountAmount;
                                salesDetails.NetTaka = obj.UnitWiseNetTaka;
                                salesDetails.DeliveryTime = obj.DeliveryTime;

                                salesDetailsManagerObj.Insert(salesDetails);
                            }

                        }




                        // Update Stock
                        //SalesInfoList = new List<RDarusSalamBook>();

                        if (effectOnStock.IsChecked==true)
                        {
                            for (int i = 0; i < posDatagrid.Items.Count; i++)
                            {

                                KarimBook obj = posDatagrid.Items[i] as KarimBook;

                                if (obj.OrderQty > 0)
                                {
                                    obj.InStock = obj.InStock - obj.OrderQty;
                                    obj.OutOfStock = obj.OutOfStock + obj.OrderQty;
                                    bookContext.Update(obj);

                                }
                            }
                        }

                       

                        List<KarimInvoice> _karimInvoiceList = new List<KarimInvoice>();
                        _karimInvoiceList = quotationManagerObj.GetSalesInvoiceDetailsById(pk);

                        MessageBox.Show("Invoice generatesuccessfully.", "POS", MessageBoxButton.OK, MessageBoxImage.Information);


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
                        //foreach (KarimInvoice item in _karimInvoiceList)
                        //{
                        //    RKarimInvoice inv = new RKarimInvoice();
                        //    inv.Id = item.Id;
                        //    inv.Name = item.Name;
                        //    inv.Mobile = item.Mobile;
                        //    inv.Address = item.Address;
                        //    inv.CustomerRefNo = item.CustomerRefNo;
                        //    inv.KarimRefNo = item.KarimRefNo;
                        //    inv.PayType = item.PayType;
                        //    inv.PayNo = item.PayNo;
                        //    inv.Total = item.Total;
                        //    inv.Discount = (decimal)item.Discount;
                        //    inv.OtherDiscount = (decimal)item.OtherDiscount;
                        //    inv.GrandTotal = (decimal)item.GrandTotal;
                        //    inv.Receive = (decimal)item.Receive;
                        //    inv.Due = (decimal)item.Due;
                        //    inv.OrderQty = (int)item.OrderQty;
                        //    inv.Price = (decimal)item.Price;
                        //    inv.TotalUnitPrice = (decimal)(item.OrderQty * item.Price);
                        //    inv.CustomerSlNo = item.CustomerSlNo;
                        //    inv.UnitDiscountPercent = (decimal)item.UnitDiscountPercent;
                        //    inv.DiscountTaka = (decimal)item.DiscountTaka;
                        //    inv.NetTaka = (decimal)item.NetTaka;
                        //    inv.Date = (DateTime)item.Date;

                        //    inv.Title = item.Title;
                        //    inv.Writer = item.Writer;
                        //    inv.Publisher = item.Publisher;
                        //    inv.Qty = (int)item.Qty;
                        //    inv.PublisherPrice = (decimal)item.PublisherPrice;
                        //    inv.OutOfStock = (int)item.OutOfStock;
                        //    inv.InStock = (int)item.InStock;
                        //    inv.Barcode = item.Barcode;
                        //    inv.PublishYear = item.PublishYear.ToString();
                        //    inv.PayNo = item.DeliveryTime;  // Temp Solution
                        //    inv.Edition = item.Edition;
                        //    inv.BookBinding = item.BookBinding;
                        //    inv.PublisherUnit = item.PublisherUnit;
                        //    inv.BookType = item.BookType;
                        //    inv.IsCustomerSlNo = item.IsCustomerSlNo;
                        //    inv.IsTitle = item.IsTitle;
                        //    inv.IsWriter = item.IsWriter;
                        //    inv.IsPublisher = item.IsPublisher;
                        //    inv.IsBarcode = item.IsBarcode;
                        //    inv.IsBookType = item.IsBookType;
                        //    inv.IsPublisherPrice = item.IsPublisherPrice;
                        //    inv.IsPublisherUnit = item.IsPublisherUnit;
                        //    inv.IsPrice = item.IsPrice;
                        //    inv.IsInStock = item.IsInStock;
                        //    inv.IsOrderQty = item.IsOrderQty;
                        //    inv.IsTotalUnitPrice = item.IsTotalUnitPrice;
                        //    inv.IsUnitDiscountPercent = item.IsUnitDiscountPercent;
                        //    inv.IsDiscountTaka = item.IsDiscountTaka;
                        //    _karimInvoiceReportList.Add(inv);
                        //}

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



                        if (_karimInvoiceReportList.Count > 0)
                        {
                            InvoiceCrystalReport employeeInfoCrystalReport = new InvoiceCrystalReport();
                            ReportUtility.Display_report(employeeInfoCrystalReport, _karimInvoiceReportList, this);

                        }
                        else
                        {
                            MessageBox.Show("Don't have any records.", "Employee Info", MessageBoxButton.OK, MessageBoxImage.Information);
                        }


                       

                       

                        totalTextBox.Text = "";
                        grandTotalTextBox.Text = "";
                        discountTextBox.Text = "";
                        discountAmountTextBox.Text = "";
                        customerNameTextBox.Text = "";
                        MobileTextBox.Text = "";
                        addressTextBox.Text = "";
                        cashPaytype.IsChecked = true;
                        receiveTextBox.Text = "";
                        dueTextBox.Text = "";
                        curiarTextBox.Text = "";
                        posDatagrid.Items.Clear();
                       // discountDatagrid.Items.Clear();
                        GlobalVar.TempOrderBookList = new List<KarimBook>();


                        dbContextTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback(); //Required according to MSDN article 
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

     
        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            KarimBook obj = new KarimBook();
            obj = posDatagrid.SelectedItem as KarimBook;// get selected item  
            if (obj != null)
            {
                decimal finalDiscount = 0;
                decimal orginalPrice = Convert.ToDecimal(obj.TotalUnitPrice);
                decimal discount = Convert.ToDecimal(obj.DiscountPercentage);
                var calculateDiscount = Convert.ToDecimal(orginalPrice / 100);
                finalDiscount = calculateDiscount * discount;
                obj.UnitWiseDiscountAmount = finalDiscount;

                obj.UnitWiseNetTaka = (orginalPrice - obj.UnitWiseDiscountAmount);
            }


            // Total Discount

            if (posDatagrid.Items.Count > 0)
            {
                decimal TTGBP = 0;
                decimal TGBP = 0;
                decimal GT = 0;
                for (int i = 0; i < posDatagrid.Items.Count; i++)
                {
                    KarimBook discountobj = posDatagrid.Items[i] as KarimBook;
                    //obj.TotalDiscountAmount = obj.Price * obj.OrderQty;
                    TGBP += Convert.ToDecimal(discountobj.UnitWiseDiscountAmount); // getting cell value  
                    GT += Convert.ToDecimal(discountobj.UnitWiseNetTaka);
                    TTGBP += Convert.ToDecimal(discountobj.TotalUnitPrice);
                }
                //totalTextBox.Text=
                discountTextBox.Text = TGBP.ToString("F");
                grandTotalTextBox.Text = GT.ToString("F");
                totalTextBox.Text = TTGBP.ToString("F");
            }
        }

        private void textBox2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void salesDateDatepicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            KarimBook obj = new KarimBook();
            obj = posDatagrid.SelectedItem as KarimBook;// get selected item  
            if (obj != null)
            {
                obj.DeliveryDate = Convert.ToDateTime(sender.ToString());
               
            }

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            KarimBook obj = new KarimBook();
            obj = posDatagrid.SelectedItem as KarimBook;// get selected item  
            if (obj != null)
            {
                posDatagrid.Items.RemoveAt(posDatagrid.Items.IndexOf(posDatagrid.SelectedItem));


                var itemToRemove = GlobalVar.TempOrderBookList.Single(r => r.Id == obj.Id);
                GlobalVar.TempOrderBookList.Remove(itemToRemove);

                //GlobalVar.TempOrderBookList.RemoveAt(obj.Id);

                if (posDatagrid.Items.Count > 0)
                {
                    decimal TTGBP = 0;
                    decimal TGBP = 0;
                    decimal GT = 0;
                    for (int i = 0; i < posDatagrid.Items.Count; i++)
                    {
                        KarimBook discountobj = posDatagrid.Items[i] as KarimBook;
                        //obj.TotalDiscountAmount = obj.Price * obj.OrderQty;
                        TGBP += Convert.ToDecimal(discountobj.UnitWiseDiscountAmount); // getting cell value  
                        GT += Convert.ToDecimal(discountobj.UnitWiseNetTaka);
                        TTGBP += Convert.ToDecimal(discountobj.TotalUnitPrice);
                    }
                    //totalTextBox.Text=
                    discountTextBox.Text = TGBP.ToString("F");
                    grandTotalTextBox.Text = GT.ToString("F");
                    totalTextBox.Text = TTGBP.ToString("F");
                }

            }




            
        }

        private void discountAmountTextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            bool approvedDecimalPoint = false;

            if (e.Text == ".")
            {
                if (!((TextBox)sender).Text.Contains("."))
                    approvedDecimalPoint = true;
            }

            if (!(char.IsDigit(e.Text, e.Text.Length - 1) || approvedDecimalPoint))
                e.Handled = true;
        }

        private void receiveTextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            bool approvedDecimalPoint = false;

            if (e.Text == ".")
            {
                if (!((TextBox)sender).Text.Contains("."))
                    approvedDecimalPoint = true;
            }

            if (!(char.IsDigit(e.Text, e.Text.Length - 1) || approvedDecimalPoint))
                e.Handled = true;
        }
    }
}
