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
    public partial class PriceUpdateReport : ModernWindow
    {
        BookPriceUpdateContext _priceContext = new BookPriceUpdateContext();

          List<BookPriceUpdate> _priceUpdateList = new List<BookPriceUpdate>();
        DarussalamBookContext bookContext = new DarussalamBookContext();
        List<RNewBookStockUpdate> stockReportModel = new List<RNewBookStockUpdate>();

        public PriceUpdateReport()
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
            _priceUpdateList = _priceContext.GetBookPriceUpdateListByDateRange(fromdate,toDate);

            foreach (var item in _priceUpdateList)
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
            foreach (BookPriceUpdate item in _priceUpdateList)
            {
                posDatagrid.Items.Add(item);
            }

            // Report Data
            stockReportModel = new List<RNewBookStockUpdate>();

            foreach (BookPriceUpdate item in _priceUpdateList)
            {
                RNewBookStockUpdate obj = new RNewBookStockUpdate();
                obj.EntryDate = (DateTime)item.UpdateDate;
                obj.Title = item.Title;
                obj.Writer = item.Writer;
                obj.Publisher = item.Publisher;
                obj.OldPrice = (int)item.OldPrice;
                obj.NewPrice = (decimal)item.NewPrice;
                stockReportModel.Add(obj);
            }
        }

        private void previewButton_Click(object sender, RoutedEventArgs e)
        {
            if (stockReportModel.Count > 0)
            {
                priceUpdateCrystalReport employeeInfoCrystalReport = new priceUpdateCrystalReport();
                ReportUtility.Display_report(employeeInfoCrystalReport, stockReportModel, this);

            }
            else
            {
                MessageBox.Show("Don't have any records.", "Employee Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
