using DarussalamModernUI.Report.Crystal;
using DarussalamModernUI.Report.Model;
using Data;
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
    /// Interaction logic for PopupBookList.xaml
    /// </summary>
    public partial class PopupBookListReport : ModernWindow
    {
        BookContext objmangaer = new BookContext();
        List<RNewBookStockUpdate> SalesInfoList = new List<RNewBookStockUpdate>();
        public PopupBookListReport()
        {
            InitializeComponent();
            LoadGrid();
            selectedBook.IsChecked = true;
            showStockBookReport.IsChecked = true;
        }

        private void LoadGrid()
        {
            List<DarusSalamBook> list = objmangaer.GetAllBookListLookup("");

            foreach (DarusSalamBook item in list)
            {
                bookGrid.Items.Add(item);
            }
        }

        private void searchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(searchTextBox.Text))
            {
                List<DarusSalamBook> list = objmangaer.GetDarusSalamBookLookupList(searchTextBox.Text);

                bookGrid.Items.Clear();
                foreach (DarusSalamBook item in list)
                {
                    bookGrid.Items.Add(item);
                }
            }
            else
            {
                List<DarusSalamBook> list = objmangaer.GetAllBookListLookup("");

                foreach (DarusSalamBook item in list)
                {
                    bookGrid.Items.Add(item);
                }
            }
        }

        private void allBook_Click(object sender, RoutedEventArgs e)
        {
            List<DarusSalamBook> list = objmangaer.GetAllBookListLookup();
            bookGrid.Items.Clear();
            foreach (DarusSalamBook item in list)
            {
                bookGrid.Items.Add(item);
            }
        }

        private void selectedBook_Click(object sender, RoutedEventArgs e)
        {
            bookGrid.Items.Clear();
        }

        private void closeButton_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void previewButton_Click(object sender, RoutedEventArgs e)
        {
            SalesInfoList = new List<RNewBookStockUpdate>();

            for (int i = 0; i < bookGrid.Items.Count; i++)
            {
                DarusSalamBook obj = bookGrid.Items[i] as DarusSalamBook;

                RNewBookStockUpdate reportObj = new RNewBookStockUpdate();
               
               reportObj.Title = obj.Title;
                if (obj.Price!=null)
                {
                    reportObj.NewPrice = (decimal)obj.Price;
                }
                else
                {
                    reportObj.NewPrice = 0;
                }


                if (obj.NewEntryQty != null)
                {
                    reportObj.NewEntryQty = Convert.ToInt32(obj.InStock);
                }
                else
                {
                    reportObj.NewEntryQty = 0;
                }
                
                reportObj.Publisher = obj.Publisher;
                reportObj.Writer = obj.Writer;
                SalesInfoList.Add(reportObj);
            }

            if (SalesInfoList.Count > 0)
            {
                if (showStockBookReport.IsChecked==true)
                {
                    bookListReportCrystalReport employeeInfoCrystalReport = new bookListReportCrystalReport();
                    ReportUtility.Display_report(employeeInfoCrystalReport, SalesInfoList, this);
                }
                if (withoutStockBookReport.IsChecked == true)
                {
                    bookListWithoutStockCrystalReport employeeInfoCrystalReport = new bookListWithoutStockCrystalReport();
                    ReportUtility.Display_report(employeeInfoCrystalReport, SalesInfoList, this);
                }
                if (showlessThanQtyBookReport.IsChecked == true)
                {
                    int qty = 0;
                    qty = Convert.ToInt32(lessThanQtyTextBox.Text);
                    List<RNewBookStockUpdate> bookList = new List<RNewBookStockUpdate>();

                    foreach (RNewBookStockUpdate item in SalesInfoList)
                    {

                        if (item.NewEntryQty<= qty)
                        {
                          bookList.Add(item);
                        }
                       
                    }
                    bookListReportCrystalReport employeeInfoCrystalReport = new bookListReportCrystalReport();
                    ReportUtility.Display_report(employeeInfoCrystalReport, bookList, this);
                }

                if (showGreaterThanQtyBookReport.IsChecked == true)
                {
                    int qty = 0;
                    qty = Convert.ToInt32(greatherThanQtyTextBox.Text);
                    List<RNewBookStockUpdate> bookList = new List<RNewBookStockUpdate>();

                    foreach (RNewBookStockUpdate item in SalesInfoList)
                    {

                        if (item.NewEntryQty >= qty)
                        {
                            bookList.Add(item);
                        }

                    }
                    bookListReportCrystalReport employeeInfoCrystalReport = new bookListReportCrystalReport();
                    ReportUtility.Display_report(employeeInfoCrystalReport, bookList, this);
                }

                





            }
            else
            {
                MessageBox.Show("Don't have any records.", "Employee Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }
    }
}
