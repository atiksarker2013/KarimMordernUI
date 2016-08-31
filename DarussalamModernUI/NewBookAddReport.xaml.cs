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
    public partial class NewBookAddReport : ModernWindow
    {
        BookStockUpdateContext _stockContext = new BookStockUpdateContext();

          List<DarusSalamBook> _stockUpdateList = new List<DarusSalamBook>();
        DarussalamBookContext bookContext = new DarussalamBookContext();
        List<RNewBookStockUpdate> stockReportModel = new List<RNewBookStockUpdate>();

        public NewBookAddReport()
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
            _stockUpdateList = bookContext.GetNewBookAddBookListByDateRange(fromdate,toDate);

            posDatagrid.Items.Clear();
            foreach (DarusSalamBook item in _stockUpdateList)
            {
                posDatagrid.Items.Add(item);
            }

           
        }

        private void previewButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime fromdate = (DateTime)fromDateDatepicker.SelectedDate;

            DateTime toDate = (DateTime)toDateDatepicker.SelectedDate;
            stockReportModel = new List<RNewBookStockUpdate>();

            for (int i = 0; i < posDatagrid.Items.Count; i++)
            {
                DarusSalamBook obj = posDatagrid.Items[i] as DarusSalamBook;


                RNewBookStockUpdate reportObj = new RNewBookStockUpdate();
                reportObj.Id = obj.Id;
                reportObj.Title = obj.Title;
                reportObj.NewEntryQty = (int)obj.Qty;
                reportObj.NewPrice = (decimal)obj.Price;
                reportObj.Publisher = obj.Publisher;
                reportObj.Writer = obj.Writer;
                reportObj.FromDate = fromdate;
                reportObj.ToDate = toDate;
                reportObj.EntryDate = (DateTime)obj.EntryDate;
                stockReportModel.Add(reportObj);
            }


            if (stockReportModel.Count > 0)
            {
                newBookEntryCrystalReport employeeInfoCrystalReport = new newBookEntryCrystalReport();
                ReportUtility.Display_report(employeeInfoCrystalReport, stockReportModel, this);

            }
            else
            {
                MessageBox.Show("Don't have any records.", "New Book Entry", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
