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
    public partial class StockUpdateReport : ModernWindow
    {
        BookStockUpdateContext _stockContext = new BookStockUpdateContext();

          List<NewBookStockUpdate> _stockUpdateList = new List<NewBookStockUpdate>();
        DarussalamBookContext bookContext = new DarussalamBookContext();
        List<RNewBookStockUpdate> stockReportModel = new List<RNewBookStockUpdate>();

        public StockUpdateReport()
        {
            InitializeComponent();
            fromDateDatepicker.SelectedDate = DateTime.Today;
            toDateDatepicker.SelectedDate = DateTime.Today;
        }

   

        private void closeButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Close();
        }

        private void bookSearchButton_Click(object sender, RoutedEventArgs e)
        {

            DateTime fromdate = (DateTime)fromDateDatepicker.SelectedDate;

            DateTime toDate = (DateTime)toDateDatepicker.SelectedDate;
            _stockUpdateList = _stockContext.GetStockUpdateBookListByDateRange(fromdate,toDate);

            foreach (var item in _stockUpdateList)
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

            posDatagrid.Items.Clear();
            foreach (NewBookStockUpdate item in _stockUpdateList)
            {
                posDatagrid.Items.Add(item);
            }

            // Report Data
            stockReportModel = new List<RNewBookStockUpdate>();

            foreach (NewBookStockUpdate item in _stockUpdateList)
            {
                RNewBookStockUpdate obj = new RNewBookStockUpdate();
                obj.EntryDate = (DateTime)item.EntryDate;
                obj.Title = item.Title;
                obj.Writer = item.Writer;
                obj.Publisher = item.Publisher;
                obj.OldStock = (int)item.OldStock;
                obj.NewEntryQty = item.NewEntryQty;
                stockReportModel.Add(obj);
            }
        }

        private void previewButton_Click(object sender, RoutedEventArgs e)
        {
            if (stockReportModel.Count > 0)
            {
                newStockUpdateReportCrystalReport employeeInfoCrystalReport = new newStockUpdateReportCrystalReport();
                ReportUtility.Display_report(employeeInfoCrystalReport, stockReportModel, this);

            }
            else
            {
                MessageBox.Show("Don't have any records.", "Employee Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
