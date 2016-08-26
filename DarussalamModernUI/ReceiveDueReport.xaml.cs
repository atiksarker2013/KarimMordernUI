using DarussalamModernUI.Report.Crystal;
using DarussalamModernUI.Report.Model;
using Data.DC;
using FirstFloor.ModernUI.Windows.Controls;
using Models;
using ReportApp;
using System;
using System.Collections.Generic;
using System.Windows;

namespace DarussalamModernUI
{
    /// <summary>
    /// Interaction logic for SalesHistory.xaml
    /// </summary>
    public partial class ReceiveDueReport : ModernWindow
    {
        SalesContext salesContext = new SalesContext();
        DarussalamBookContext _bookContext = new DarussalamBookContext();

        SalesContext salesManagerObj = new SalesContext();
        SalesDetailsContext salesDetailsManagerObj = new SalesDetailsContext();
        DarussalamBookContext bookContext = new DarussalamBookContext();
        DiscountContext discountContext = new DiscountContext();

        List<RNewBookStockUpdate> SalesInfoList = new List<RNewBookStockUpdate>();
        List<SalesReceiveDue> salesList = new List<SalesReceiveDue>();




        decimal total = 0;
        decimal totalDiscount = 0;
        decimal totalOtherDiscount = 0;
        decimal totalGrandTotal = 0;
        decimal totalReceive = 0;
        decimal totalDue = 0;

        public ReceiveDueReport()
        {
            InitializeComponent();
            fromDateDatepicker.SelectedDate = DateTime.Today;
            toDateDatepicker.SelectedDate = DateTime.Today;
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            DateTime fromDate = Convert.ToDateTime(fromDateDatepicker.SelectedDate);
            DateTime toDate = Convert.ToDateTime(toDateDatepicker.SelectedDate);
            salesList = new List<SalesReceiveDue>();
            salesList = salesContext.GetReceiveDueHistoryByDateRange(fromDate, toDate);

            foreach (var item in salesList)
            {
                List<Sales> bookInfo = new List<Sales>();
                bookInfo = salesManagerObj.GetSalesInfoByBookId(item.SalesInvoiceId);
                foreach (var book in bookInfo)
                {
                    item.CustomerName = book.Name;
                    item.Mobile = book.Mobile;
                    item.InvoiceDate = book.Date;
                }
            }


            posDatagrid.Items.Clear();

            foreach (SalesReceiveDue item in salesList)
            {
               // total = total + item.ReceiveAmount;
                posDatagrid.Items.Add(item);
            }
        }

        private void closeButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Close();
        }

     
            

      

        private void GenerateAllInvoiceReport()
        {
            SalesInfoList = new List<RNewBookStockUpdate>();
            //for (int i = 0; i < posDatagrid.Items.Count; i++)
            //{
              
                // Print Data
               

                foreach (var item in salesList)
                {
                    RNewBookStockUpdate reportObj = new RNewBookStockUpdate();
                    // reportObj.Id = obj.Id;
                    reportObj.SalesInvoiceId = item.SalesInvoiceId;
                    reportObj.InvoiceDate = (DateTime)item.InvoiceDate;
                    reportObj.CustomerName = item.CustomerName;
                    reportObj.CustomerMobile = item.Mobile;
                    reportObj.CustomerInvoiceId = item.CustomerInvoiceId;
                    reportObj.ReceiveAmount = item.ReceiveAmount;
                    reportObj.ReceiveDate = (DateTime)item.ReceiveDate;
                    reportObj.FromDate = (DateTime)fromDateDatepicker.SelectedDate;
                    reportObj.ToDate = (DateTime)toDateDatepicker.SelectedDate;

                    SalesInfoList.Add(reportObj);
                }
               
            //}

           
        }

        private void summaryReportButton_Click(object sender, RoutedEventArgs e)
        {
            //salesSummaryCrystalReport

            this.Close();
        }

        private void bookSummaryReportButton_Click(object sender, RoutedEventArgs e)
        {
           GenerateAllInvoiceReport();
            if (SalesInfoList.Count > 0)
            {
                receiveDueCrystalReport employeeInfoCrystalReport = new receiveDueCrystalReport();
                ReportUtility.Display_report(employeeInfoCrystalReport, SalesInfoList, this);

            }
            else
            {
                MessageBox.Show("Don't have any records.", "Receive Due", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

     
    }
}
