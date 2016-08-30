using DarussalamModernUI.Report.Crystal;
using DarussalamModernUI.Report.Model;
using Data.DC;
using FirstFloor.ModernUI.Windows.Controls;
using Models;
using ReportApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace DarussalamModernUI
{
    /// <summary>
    /// Interaction logic for SalesHistory.xaml
    /// </summary>
    public partial class SalesHistory : ModernWindow
    {
        SalesContext salesContext = new SalesContext();
        DarussalamBookContext _bookContext = new DarussalamBookContext();

        SalesContext salesManagerObj = new SalesContext();
        SalesDetailsContext salesDetailsManagerObj = new SalesDetailsContext();
        DarussalamBookContext bookContext = new DarussalamBookContext();
        DiscountContext discountContext = new DiscountContext();

        List<RDarusSalamBook> SalesInfoList = new List<RDarusSalamBook>();

         

        decimal total = 0;
        decimal totalDiscount = 0;
        decimal totalOtherDiscount = 0;
        decimal totalGrandTotal = 0;
        decimal totalReceive = 0;
        decimal totalDue = 0;

        public SalesHistory()
        {
            InitializeComponent();
            fromDateDatepicker.SelectedDate = DateTime.Today;
            toDateDatepicker.SelectedDate = DateTime.Today;
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            DateTime fromDate = Convert.ToDateTime(fromDateDatepicker.SelectedDate);
            DateTime toDate = Convert.ToDateTime(toDateDatepicker.SelectedDate);
            List<Sales> salesList = new List<Sales>();
            salesList = salesContext.GetSalesHistoryByDateRange(fromDate, toDate);

            foreach (Sales item in salesList) 
            {
                item.SalesDetailsList = _bookContext.GetBookDetailsByInvoiceNo(item.Id);
                if (item.Due==0)
                {
                    item.Status = "Paid";
                }
                else
                {
                    item.Status = "Un Paid";
                }
            }

            posDatagrid.Items.Clear();

            foreach (Sales item in salesList)
            {
                total = total + item.Total;
                totalDiscount = totalDiscount + item.Discount;
                totalOtherDiscount = totalOtherDiscount + item.OtherDiscount;
                totalGrandTotal = totalGrandTotal + item.GrandTotal;
                totalReceive = totalReceive + item.Receive;
                totalDue = totalDue + item.Due;
                totalTextBox.Text = total.ToString("F");
                totalDiscountTextBox.Text = totalDiscount.ToString("F");
                totalOtherDiscountTextBox.Text = totalOtherDiscount.ToString("F");
                totalGrandTotaltTextBox.Text = totalGrandTotal.ToString("F");
                totalReceiveTextBox.Text = totalReceive.ToString("F");
                totalDueTextBox.Text = totalDue.ToString("F");

                posDatagrid.Items.Add(item);
            }
        }

        private void closeButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Close();
        }

        private void printInfoContextMenu_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Sales chalan = new Sales();
            chalan = posDatagrid.SelectedItem as Sales;
            LoadInvoiceDetails(chalan);
        }

        private void LoadInvoiceDetails(Sales chalan)
        {
            foreach (SalesDetails item in chalan.SalesDetailsList)
            {
                List<DarusSalamBook> bookInfo = new List<DarusSalamBook>();
                bookInfo = bookContext.GetBookInfoByBookId(item.BookId);
                foreach (var book in bookInfo)
                {
                    item.Title = book.Title;
                    item.Publisher = book.Publisher;
                    item.Writer = book.Writer;
                }
            }
            List<Discounts> discountList = new List<Discounts>();
            discountList = discountContext.GetBookDiscountByInvoiceNo(chalan.Id);

            // Print Data
            SalesInfoList = new List<RDarusSalamBook>();

            foreach (var item in chalan.SalesDetailsList)
            {
                RDarusSalamBook reportObj = new RDarusSalamBook();
               // reportObj.Id = obj.Id;
                reportObj.Title = item.Title;
                reportObj.OrderQty = item.OrderQty;
                reportObj.Price = (decimal)item.Price;
                reportObj.Name = chalan.Name;
                reportObj.Mobile = chalan.Mobile;
                reportObj.Address = chalan.Address;
                reportObj.Date = (DateTime)chalan.Date;
                reportObj.PayType = chalan.PayType;
                reportObj.PayNo = chalan.PayNo;
                reportObj.Total = chalan.Total;
                reportObj.Discount = chalan.Discount;
                reportObj.GrandTotal = chalan.GrandTotal;
                reportObj.Receive = chalan.Receive;
                reportObj.Due = chalan.Due;
                 reportObj.InvoiceNo = chalan.Id;
                reportObj.Publisher = item.Publisher;
                reportObj.Writer = item.Writer;
                reportObj.CuriarCharg = chalan.CuriarCharg;
                reportObj.OtherDiscount = chalan.OtherDiscount;
                SalesInfoList.Add(reportObj);
            }

            if (SalesInfoList.Count > 0)
            {
                salesInvoiceCrystalReport employeeInfoCrystalReport = new salesInvoiceCrystalReport();
                ReportUtility.Display_report(employeeInfoCrystalReport, SalesInfoList, this);

            }
            else
            {
                MessageBox.Show("Don't have any records.", "Employee Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void generateInvoiceButton_Click(object sender, RoutedEventArgs e)
        {
            GenerateAllInvoiceReport();
            if (SalesInfoList.Count > 0)
            {
                salesInvoiceCrystalReport employeeInfoCrystalReport = new salesInvoiceCrystalReport();
                ReportUtility.Display_report(employeeInfoCrystalReport, SalesInfoList, this);

            }
            else
            {
                MessageBox.Show("Don't have any records.", "Employee Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void GenerateAllInvoiceReport()
        {
            SalesInfoList = new List<RDarusSalamBook>();
            for (int i = 0; i < posDatagrid.Items.Count; i++)
            {
                Sales salesObj = posDatagrid.Items[i] as Sales;

                ////////////
                foreach (SalesDetails item in salesObj.SalesDetailsList)
                {
                    List<DarusSalamBook> bookInfo = new List<DarusSalamBook>();
                    bookInfo = bookContext.GetBookInfoByBookId(item.BookId);
                    foreach (var book in bookInfo)
                    {
                        item.Title = book.Title;
                        item.Publisher = book.Publisher;
                        item.Writer = book.Writer;
                        item.InvoiceNo = salesObj.Id;
                    }
                   
                }
                List<Discounts> discountList = new List<Discounts>();
                discountList = discountContext.GetBookDiscountByInvoiceNo(salesObj.Id);

                // Print Data
               

                foreach (var item in salesObj.SalesDetailsList)
                {

                    RDarusSalamBook reportObj = new RDarusSalamBook();
                    // reportObj.Id = obj.Id;
                    reportObj.Title = item.Title;
                    reportObj.OrderQty = item.OrderQty;
                    reportObj.Price = (decimal)item.Price;
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
                    reportObj.InvoiceNo = item.InvoiceNo;
                    reportObj.Publisher = item.Publisher;
                    reportObj.Writer = item.Writer;
                    reportObj.CuriarCharg = salesObj.CuriarCharg;
                    reportObj.OtherDiscount = salesObj.OtherDiscount;

                    reportObj.FromDate = (DateTime)fromDateDatepicker.SelectedDate;
                    reportObj.ToDate = (DateTime)toDateDatepicker.SelectedDate;

                    SalesInfoList.Add(reportObj);
                }
               
            }

           
        }

        private void GenerateDueAllInvoiceReport()
        {
            SalesInfoList = new List<RDarusSalamBook>();
            for (int i = 0; i < posDatagrid.Items.Count; i++)
            {
                Sales salesObj = posDatagrid.Items[i] as Sales;

                // Print Data

                if (salesObj.Status == "Un Paid")
                {
                    RDarusSalamBook reportObj = new RDarusSalamBook();
                   
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
                    reportObj.InvoiceNo = salesObj.Id;
                  
                    reportObj.CuriarCharg = salesObj.CuriarCharg;
                    reportObj.OtherDiscount = salesObj.OtherDiscount;

                    reportObj.FromDate = (DateTime)fromDateDatepicker.SelectedDate;
                    reportObj.ToDate = (DateTime)toDateDatepicker.SelectedDate;

                    SalesInfoList.Add(reportObj);
                }

            }


        }

        private void GenerateAllSummaryInvoiceReport()
        {
            SalesInfoList = new List<RDarusSalamBook>();
            for (int i = 0; i < posDatagrid.Items.Count; i++)
            {
                Sales salesObj = posDatagrid.Items[i] as Sales;

                // Print Data

                
                    RDarusSalamBook reportObj = new RDarusSalamBook();

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
                    reportObj.InvoiceNo = salesObj.Id;
               // reportObj.Date = (DateTime)salesObj.Date;

                reportObj.CuriarCharg = salesObj.CuriarCharg;
                    reportObj.OtherDiscount = salesObj.OtherDiscount;

                    reportObj.FromDate = (DateTime)fromDateDatepicker.SelectedDate;
                    reportObj.ToDate = (DateTime)toDateDatepicker.SelectedDate;

                    SalesInfoList.Add(reportObj);
               

            }


        }

        private void summaryReportButton_Click(object sender, RoutedEventArgs e)
        {
            //salesSummaryCrystalReport

            GenerateAllSummaryInvoiceReport();
            if (SalesInfoList.Count > 0)
            {
                salesSummaryCrystalReport employeeInfoCrystalReport = new salesSummaryCrystalReport();
                ReportUtility.Display_report(employeeInfoCrystalReport, SalesInfoList, this);

            }
            else
            {
                MessageBox.Show("Don't have any records.", "Employee Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void bookSummaryReportButton_Click(object sender, RoutedEventArgs e)
        {
            GenerateAllInvoiceReport();
            if (SalesInfoList.Count > 0)
            {
                bookSalesSummaryCrystalReport employeeInfoCrystalReport = new bookSalesSummaryCrystalReport();
                ReportUtility.Display_report(employeeInfoCrystalReport, SalesInfoList, this);

            }
            else
            {
                MessageBox.Show("Don't have any records.", "Employee Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void receiveDueContextMenu_Click(object sender, RoutedEventArgs e)
        {
            Sales chalan = new Sales();
            chalan = posDatagrid.SelectedItem as Sales;
            if (chalan.Due>0)
            {
                SalesReturn obj = new SalesReturn(chalan);
                obj.Show();
            }
            else
            {
                MessageBox.Show("There is no pending payment.", "Sales History", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        private void allDueReportButton_Click(object sender, RoutedEventArgs e)
        {
            GenerateDueAllInvoiceReport();
            if (SalesInfoList.Count > 0)
            {
                List<RDarusSalamBook> dueList = SalesInfoList.Distinct().ToList(); ;
                salesSummaryCrystalReport employeeInfoCrystalReport = new salesSummaryCrystalReport();
                ReportUtility.Display_report(employeeInfoCrystalReport, dueList, this);

            }
            else
            {
                MessageBox.Show("Don't have any records.", "Employee Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
