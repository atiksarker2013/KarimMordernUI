using Data;
using Data.DC;
using KarimModernUINavigationApp.Report.Crystal;
using KarimModernUINavigationApp.Report.Model;
using Models;
using ReportApp;
using System;
using System.Collections.Generic;
using System.Windows;

namespace KarimModernUINavigationApp
{
    /// <summary>
    /// Interaction logic for PopupKarimBookListReport.xaml
    /// </summary>
    public partial class PopupKarimBookListReport  
    {
        BookContext objmangaer = new BookContext();
       // List<RNewBookStockUpdate> SalesInfoList = new List<RNewBookStockUpdate>();
        public PopupKarimBookListReport()
        {
            InitializeComponent();
            selectedBook.IsChecked = true;
            showStockBookReport.IsChecked = true;
            LoadGrid();
        }

        private void LoadGrid()
        {
            List<KarimBook> list = objmangaer.GetKarimBookWithTakaLookupList("");

            foreach (KarimBook item in list)
            {
                bookGrid.Items.Add(item);
            }
            int cont = list.Count;
            itemCountLabel.Content = cont.ToString();
        }

        private void previewButton_Click(object sender, RoutedEventArgs e)
        {
            List<RKarimBook> SalesInfoList = new List<RKarimBook>();

            for (int i = 0; i < bookGrid.Items.Count; i++)
            {
                KarimBook entity = bookGrid.Items[i] as KarimBook;

                RKarimBook model = new RKarimBook();

                //reportObj.Title = obj.Title;
                //if (obj.Price != null)
                //{
                //    reportObj.NewPrice = (decimal)obj.Price;
                //}
                //else
                //{
                //    reportObj.NewPrice = 0;
                //}


                //if (obj.NewEntryQty != null)
                //{
                //    reportObj.NewEntryQty = Convert.ToInt32(obj.InStock);
                //}
                //else
                //{
                //    reportObj.NewEntryQty = 0;
                //}

                //reportObj.Publisher = obj.Publisher;
                //reportObj.Writer = obj.Writer;

                model.Title = entity.Title;
                model.Writer = entity.Writer;
                model.Publisher = entity.Publisher;
                model.Barcode = entity.Barcode;
                model.Qty = entity.Qty ?? 0;
                model.Price = entity.Price ?? 0;
                model.PublisherPrice = entity.PublisherPrice;
                model.PublisherUnit = entity.PublisherUnit;
                if (entity.PublishYear ==null)
                {
                    model.PublishYear = 0;
                }
                else
                {
                    model.PublishYear = (int)entity.PublishYear;
                }
               
                model.BookType = entity.BookType;
                model.OutOfStock = entity.OutOfStock ?? 0;
                model.InStock = entity.InStock ?? 0;
                //model.EntryDate = entity.EntryDate;
                model.Edition = entity.Edition;
                model.BookBinding = entity.BookBinding;

                SalesInfoList.Add(model);
            }

            if (SalesInfoList.Count>0)
            {
                if (allBook.IsChecked==true)
                {
                    karimBookListCrystalReport employeeInfoCrystalReport = new karimBookListCrystalReport();
                    ReportUtility.Display_report(employeeInfoCrystalReport, SalesInfoList, this);
                }
                else
                {
                    subjectWiseKarimBookBookListCrystalReport employeeInfoCrystalReport = new subjectWiseKarimBookBookListCrystalReport();
                    ReportUtility.Display_report(employeeInfoCrystalReport, SalesInfoList, this);
                }
                //subjectWiseKarimBookBookListCrystalReport

              
            }
        }

            //karimBookListCrystalReport
        

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void searchTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(searchTextBox.Text))
                {
                    List<KarimBook> list = objmangaer.GetKarimBookWithTakaLookupListAll(searchTextBox.Text);

                    bookGrid.Items.Clear();
                    foreach (KarimBook item in list)
                    {
                        bookGrid.Items.Add(item);
                    }
                    int cont = list.Count;
                    itemCountLabel.Content = cont.ToString();
                }
                else
                {
                    List<KarimBook> list = objmangaer.GetKarimBookWithTakaLookupListAll("");

                    foreach (KarimBook item in list)
                    {
                        bookGrid.Items.Add(item);
                    }
                    int cont = list.Count;
                    itemCountLabel.Content = cont.ToString();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void selectedBook_Click(object sender, RoutedEventArgs e)
        {
            bookGrid.Items.Clear();
        }

        private void allBook_Click(object sender, RoutedEventArgs e)
        {
            List<KarimBook> list = objmangaer.GetKarimBookWithTakaLookupListAll("");
            bookGrid.Items.Clear();
            foreach (KarimBook item in list)
            {
                bookGrid.Items.Add(item);
            }
            int cont = list.Count;
            itemCountLabel.Content = cont.ToString();
        }
    }
}
