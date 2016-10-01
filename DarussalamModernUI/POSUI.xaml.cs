using DarussalamModernUI.Report.Crystal;
using DarussalamModernUI.Report.Model;
using Data;
using Data.DC;
using FirstFloor.ModernUI.Windows.Controls;
using Models;
using ReportApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DarussalamModernUI
{
    /// <summary>
    /// Interaction logic for POSUI.xaml
    /// </summary>
    public partial class POSUI : ModernWindow
    {
        SalesContext salesManagerObj = new SalesContext();
        SalesDetailsContext salesDetailsManagerObj = new SalesDetailsContext();
        DarussalamBookContext bookContext = new DarussalamBookContext();
        DiscountContext discountContext = new DiscountContext();

        List<RDarusSalamBook> SalesInfoList = new List<RDarusSalamBook>();

        List<RDarussalamSalesDiscount> SalesDiscountInfoList = new List<RDarussalamSalesDiscount>();
        public POSUI()
        {
            InitializeComponent();
            salesDateDatepicker.SelectedDate = DateTime.Now;
            cashPaytype.IsChecked = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PopupBookList obj = new PopupBookList();
            obj.Show();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            DarusSalamBook chalan = new DarusSalamBook();
            chalan = posDatagrid.SelectedItem as DarusSalamBook;// get selected item  
            //                                                       // Other i am summarizing grid cell value in a combobox  
            decimal TGBP = 0;
            for (int i = 0; i < posDatagrid.Items.Count; i++)
            {
                DarusSalamBook obj = posDatagrid.Items[i] as DarusSalamBook;
                obj.TotalUnitPrice = obj.Price * obj.OrderQty;
                TGBP += Convert.ToDecimal(obj.TotalUnitPrice); // getting cell value   
            }
            totalTextBox.Text = TGBP.ToString("F");

            grandTotalTextBox.Text = TGBP.ToString("F");

            // Discount Calculation

            GlobalVar.DiscountsList = new List<Discounts>();
            GlobalVar.DiscountsList = GlobalVar.TempOrderBookList.GroupBy(l => l.Publisher)
            .Select(cl => new Discounts
            {
                PublisherName = cl.First().Publisher,
                TotalAmount = cl.Sum(c => c.Price * c.OrderQty),
            }).ToList();

            discountDatagrid.Items.Clear();
            foreach (Discounts item in GlobalVar.DiscountsList)
            {
                discountDatagrid.Items.Add(item);
            }
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
            //try
            //{
            using (var context = new KARIM_INT_HOUSTONEEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {


                        Sales salesObj = new Sales();

                        salesObj.Name = customerNameTextBox.Text;
                        salesObj.Mobile = MobileTextBox.Text;
                        salesObj.Address = addressTextBox.Text;
                        salesObj.Date = salesDateDatepicker.SelectedDate;

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
                            DarusSalamBook obj = posDatagrid.Items[i] as DarusSalamBook;
                            if (obj.OrderQty>0)
                            {
                                SalesDetails salesDetails = new SalesDetails();
                                salesDetails.BookId = obj.Id;
                                salesDetails.Price = (decimal)obj.Price;
                                salesDetails.OrderQty = obj.OrderQty;
                                salesDetails.SalesId = pk;
                                salesDetailsManagerObj.Insert(salesDetails);
                            }
                           
                        }

                        // Discount Insert

                        for (int i = 0; i < discountDatagrid.Items.Count; i++)
                        {
                            Discounts obj = discountDatagrid.Items[i] as Discounts;

                            Discounts discountObj = new Discounts();
                            discountObj.InvoiceId = pk;
                            discountObj.PublisherName = obj.PublisherName;
                            discountObj.TotalAmount = obj.TotalAmount;
                            discountObj.DiscountPercentage = obj.DiscountPercentage;
                            discountObj.DiscountAmount = obj.DiscountAmount;
                            discountContext.Insert(discountObj);

                            RDarussalamSalesDiscount discuntobj = new RDarussalamSalesDiscount();
                            discuntobj.PublisherName = obj.PublisherName;
                            discuntobj.TotalAmount = obj.TotalAmount;
                            discuntobj.DiscountPercentage = obj.DiscountPercentage;
                            discuntobj.DiscountAmount = obj.DiscountAmount;
                            SalesDiscountInfoList.Add(discuntobj);

                        }


                        // Update Stock
                        SalesInfoList = new List<RDarusSalamBook>();

                        for (int i = 0; i < posDatagrid.Items.Count; i++)
                        {

                            DarusSalamBook obj = posDatagrid.Items[i] as DarusSalamBook;

                            if (obj.OrderQty>0)
                            {
                                obj.InStock = obj.InStock - obj.OrderQty;
                                obj.OutOfStock = obj.OutOfStock + obj.OrderQty;
                                bookContext.Update(obj);

                                RDarusSalamBook reportObj = new RDarusSalamBook();
                                reportObj.Id = obj.Id;
                                reportObj.Title = obj.Title;
                                reportObj.OrderQty = obj.OrderQty;
                                reportObj.Price = (decimal)obj.Price;
                                reportObj.Name = salesObj.Name;
                                reportObj.Mobile = salesObj.Mobile;
                                reportObj.Address = salesObj.Address;
                                reportObj.Date = (DateTime)salesObj.Date;
                                reportObj.PayType = salesObj.PayType;
                                reportObj.PayNo = salesObj.PayNo;
                                reportObj.Total = salesObj.Total;
                                reportObj.Discount = salesObj.Discount;
                                reportObj.GrandTotal = salesObj.GrandTotal;
                                reportObj.Receive = salesObj.Receive;
                                reportObj.Due = salesObj.Due;
                                reportObj.InvoiceNo = pk;
                                reportObj.CuriarCharg = salesObj.CuriarCharg;
                                reportObj.OtherDiscount = salesObj.OtherDiscount;
                                reportObj.Publisher = obj.Publisher;
                                reportObj.Writer = obj.Writer;
                                SalesInfoList.Add(reportObj);
                            }
                            
                        }

                        MessageBox.Show("Invoice generatesuccessfully.", "POS", MessageBoxButton.OK, MessageBoxImage.Information);

                        if (SalesInfoList.Count > 0)
                        {
                            salesInvoiceCrystalReport employeeInfoCrystalReport = new salesInvoiceCrystalReport();
                            ReportUtility.Display_report(employeeInfoCrystalReport, SalesInfoList, this);

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
                        discountDatagrid.Items.Clear();
                        GlobalVar.TempOrderBookList = new List<DarusSalamBook>();


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


            

            //}
            //catch (ApplicationException ae)
            //{
            //    Log.Instance.ErrorException("Error doing something...", ae);
            //}

      //  }

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

        private void quatationButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Sales salesObj = new Sales();

                salesObj.Name = customerNameTextBox.Text;
                salesObj.Mobile = MobileTextBox.Text;
                salesObj.Address = addressTextBox.Text;
                salesObj.Date = salesDateDatepicker.SelectedDate;

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

                //salesObj.Total = Convert.ToDecimal(totalTextBox.Text);
                if (!string.IsNullOrEmpty(totalTextBox.Text))
                {
                    salesObj.Total = Convert.ToDecimal(totalTextBox.Text);
                }
                else
                {
                    salesObj.Total = 0;
                }
                //salesObj.Discount = Convert.ToDecimal(discountTextBox.Text);
                if (!string.IsNullOrEmpty(discountTextBox.Text))
                {
                    salesObj.Discount = Convert.ToDecimal(discountTextBox.Text);
                }
                else
                {
                    salesObj.Discount = 0;
                }
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


                //int pk = 0;
                //pk = salesManagerObj.Insert(salesObj);

                // Insert Book Details

                for (int i = 0; i < posDatagrid.Items.Count; i++)
                {
                    DarusSalamBook obj = posDatagrid.Items[i] as DarusSalamBook;

                    SalesDetails salesDetails = new SalesDetails();
                    salesDetails.BookId = obj.Id;
                    salesDetails.Price = (decimal)obj.Price;
                    salesDetails.OrderQty = obj.OrderQty;
                    //salesDetails.SalesId = pk;
                    //salesDetailsManagerObj.Insert(salesDetails);
                }

                // Discount Insert

                for (int i = 0; i < discountDatagrid.Items.Count; i++)
                {
                    Discounts obj = discountDatagrid.Items[i] as Discounts;

                    Discounts discountObj = new Discounts();
                    // discountObj.InvoiceId = pk;
                    discountObj.PublisherName = obj.PublisherName;
                    discountObj.TotalAmount = obj.TotalAmount;
                    discountObj.DiscountPercentage = obj.DiscountPercentage;
                    discountObj.DiscountAmount = obj.DiscountAmount;
                    // discountContext.Insert(discountObj);

                    RDarussalamSalesDiscount discuntobj = new RDarussalamSalesDiscount();
                    discuntobj.PublisherName = obj.PublisherName;
                    discuntobj.TotalAmount = obj.TotalAmount;
                    discuntobj.DiscountPercentage = obj.DiscountPercentage;
                    discuntobj.DiscountAmount = obj.DiscountAmount;
                    SalesDiscountInfoList.Add(discuntobj);

                }


                // Update Stock

                SalesInfoList = new List<RDarusSalamBook>();

                for (int i = 0; i < posDatagrid.Items.Count; i++)
                {
                    DarusSalamBook obj = posDatagrid.Items[i] as DarusSalamBook;
                    if (obj.OrderQty>0)
                    {
                        obj.Qty = obj.Qty - obj.OrderQty;
                        obj.OutOfStock = obj.OutOfStock + obj.OrderQty;
                        //  bookContext.Update(obj);

                        RDarusSalamBook reportObj = new RDarusSalamBook();
                        reportObj.Id = obj.Id;
                        reportObj.Title = obj.Title;
                        reportObj.OrderQty = obj.OrderQty;
                        reportObj.Price = (decimal)obj.Price;
                        reportObj.Name = salesObj.Name;
                        reportObj.Mobile = salesObj.Mobile;
                        reportObj.Address = salesObj.Address;
                        reportObj.Date = (DateTime)salesObj.Date;
                        reportObj.PayType = salesObj.PayType;
                        reportObj.PayNo = salesObj.PayNo;
                        reportObj.Total = salesObj.Total;
                        reportObj.Discount = salesObj.Discount;
                        reportObj.GrandTotal = salesObj.GrandTotal;
                        reportObj.Receive = salesObj.Receive;
                        reportObj.Due = salesObj.Due;
                        reportObj.Publisher = obj.Publisher;
                        reportObj.Writer = obj.Writer;
                        reportObj.CuriarCharg = salesObj.CuriarCharg;
                        reportObj.OtherDiscount = salesObj.OtherDiscount;
                        SalesInfoList.Add(reportObj);
                    }
                    
                }



                if (SalesInfoList.Count > 0)
                {
                    priceQuotationCrystalReport employeeInfoCrystalReport = new priceQuotationCrystalReport();
                    //salesInvoiceCrystalReport discountReport = new salesInvoiceCrystalReport();
                    // employeeInfoCrystalReport.Subreports["salesInvoiceCrystalReport.rpt"].SetDataSource(SalesDiscountInfoList);
                    ReportUtility.Display_report(employeeInfoCrystalReport, SalesInfoList, this);


                    //  ReportUtility.Display_report(discountReport, SalesDiscountInfoList, this);
                }
                else
                {
                    MessageBox.Show("Don't have any records.", "Employee Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show( ex.ToString());
            }
        }
    }
}
