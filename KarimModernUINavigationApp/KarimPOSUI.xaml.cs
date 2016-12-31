using Data;
using Data.DC;
using FirstFloor.ModernUI.Windows.Controls;
using Models;
using System;
using System.Collections.Generic;
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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            KarimPopupBookList obj = new KarimPopupBookList();
            obj.Show();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

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
                        quotationDetailsManagerObj.Insert(salesDetails);
                    }

                }

               

                MessageBox.Show("Invoice generatesuccessfully.", "POS", MessageBoxButton.OK, MessageBoxImage.Information);

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

                throw ex;
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
                                    
                                salesDetailsManagerObj.Insert(salesDetails);
                            }

                        }

                        // Discount Insert

                        //for (int i = 0; i < discountDatagrid.Items.Count; i++)
                        //{
                        //    Discounts obj = discountDatagrid.Items[i] as Discounts;

                        //    Discounts discountObj = new Discounts();
                        //    discountObj.InvoiceId = pk;
                        //    discountObj.PublisherName = obj.PublisherName;
                        //    discountObj.TotalAmount = obj.TotalAmount;
                        //    discountObj.DiscountPercentage = obj.DiscountPercentage;
                        //    discountObj.DiscountAmount = obj.DiscountAmount;
                        //    discountContext.Insert(discountObj);

                        //    RDarussalamSalesDiscount discuntobj = new RDarussalamSalesDiscount();
                        //    discuntobj.PublisherName = obj.PublisherName;
                        //    discuntobj.TotalAmount = obj.TotalAmount;
                        //    discuntobj.DiscountPercentage = obj.DiscountPercentage;
                        //    discuntobj.DiscountAmount = obj.DiscountAmount;
                        //    SalesDiscountInfoList.Add(discuntobj);

                        //}


                        // Update Stock
                        //SalesInfoList = new List<RDarusSalamBook>();

                        for (int i = 0; i < posDatagrid.Items.Count; i++)
                        {

                            KarimBook obj = posDatagrid.Items[i] as KarimBook;

                            if (obj.OrderQty > 0)
                            {
                                obj.InStock = obj.InStock - obj.OrderQty;
                                obj.OutOfStock = obj.OutOfStock + obj.OrderQty;
                                bookContext.Update(obj);

                                //RDarusSalamBook reportObj = new RDarusSalamBook();
                                //reportObj.Id = obj.Id;
                                //reportObj.Title = obj.Title;
                                //reportObj.OrderQty = obj.OrderQty;
                                //reportObj.Price = (decimal)obj.Price;
                                //reportObj.Name = salesObj.Name;
                                //reportObj.Mobile = salesObj.Mobile;
                                //reportObj.Address = salesObj.Address;
                                //reportObj.Date = (DateTime)salesObj.Date;
                                //reportObj.PayType = salesObj.PayType;
                                //reportObj.PayNo = salesObj.PayNo;
                                //reportObj.Total = salesObj.Total;
                                //reportObj.Discount = salesObj.Discount;
                                //reportObj.GrandTotal = salesObj.GrandTotal;
                                //reportObj.Receive = salesObj.Receive;
                                //reportObj.Due = salesObj.Due;
                                //reportObj.InvoiceNo = pk;
                                //reportObj.CuriarCharg = salesObj.CuriarCharg;
                                //reportObj.OtherDiscount = salesObj.OtherDiscount;
                                //reportObj.Publisher = obj.Publisher;
                                //reportObj.Writer = obj.Writer;
                                //SalesInfoList.Add(reportObj);
                            }

                        }

                        MessageBox.Show("Invoice generatesuccessfully.", "POS", MessageBoxButton.OK, MessageBoxImage.Information);

                        //if (SalesInfoList.Count > 0)
                        //{
                        //    salesInvoiceCrystalReport employeeInfoCrystalReport = new salesInvoiceCrystalReport();
                        //    ReportUtility.Display_report(employeeInfoCrystalReport, SalesInfoList, this);

                        //}
                        //else
                        //{
                        //    MessageBox.Show("Don't have any records.", "Employee Info", MessageBoxButton.OK, MessageBoxImage.Information);
                        //}

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
    }
}
