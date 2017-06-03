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
       List<KarimBookSubject> _subjectList = new List<KarimBookSubject>();
        public PopupKarimBookListReport()
        {
            InitializeComponent();
            selectedBook.IsChecked = true;
          

            titleChkBox.IsChecked = true;
            writerChkBox.IsChecked = true;
            publisherChkBox.IsChecked = true;
            isbnChkBox.IsChecked = true;
            bookTypeChkBox.IsChecked = true;
            publisherPriceChkBox.IsChecked = true;
            publisherUnitChkBox.IsChecked = true;
            priceChkBox.IsChecked = true;
            stockQtyChkBox.IsChecked = true;
 
            LoadGrid();
            LoadSubject();

        }

        private void LoadSubject()
        {
            ZoneBranchIDcomboBox.Items.Clear();
            ZoneBranchIDcomboBox.ItemsSource = objmangaer.GetAllSubject();
            //foreach (KarimBookSubject floorSetupObj in _subjectList)
            //{
            //    ZoneBranchIDcomboBox.ItemsSource = _subjectList;
            //}
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

           
            if (titleChkBox.IsChecked == true)
            {
                foreach (var obj in SalesInfoList)
                {
                    obj.IsTitle = true;
                }

            }

            if (writerChkBox.IsChecked == true)
            {
                foreach (var obj in SalesInfoList)
                {
                    obj.IsWriter = true;
                }

            }

            if (publisherChkBox.IsChecked == true)
            {
                foreach (var obj in SalesInfoList)
                {
                    obj.IsPublisher = true;
                }

            }








            if (isbnChkBox.IsChecked == true)
            {
                foreach (var obj in SalesInfoList)
                {
                    obj.IsBarcode = true;
                }

            }

            if (bookTypeChkBox.IsChecked == true)
            {
                foreach (var obj in SalesInfoList)
                {
                    obj.IsBookType = true;
                }

            }

            if (publisherPriceChkBox.IsChecked == true)
            {
                foreach (var obj in SalesInfoList)
                {
                    obj.IsPublisherPrice = true;
                }

            }

            if (publisherUnitChkBox.IsChecked == true)
            {
                foreach (var obj in SalesInfoList)
                {
                    obj.IsPublisherUnit = true;
                }

            }

            if (priceChkBox.IsChecked == true)
            {
                foreach (var obj in SalesInfoList)
                {
                    obj.IsPrice = true;
                }


            }

            if (stockQtyChkBox.IsChecked == true)
            {
                foreach (var obj in SalesInfoList)
                {
                    obj.IsInStock = true;
                }

            }

           

            if (SalesInfoList.Count>0)
            {
            //    if (allBook.IsChecked==true)
            //    {
            //        karimBookListCrystalReport employeeInfoCrystalReport = new karimBookListCrystalReport();
            //        ReportUtility.Display_report(employeeInfoCrystalReport, SalesInfoList, this);
            //    }
            //    else

            //    {
                    karimBookCrystalReport employeeInfoCrystalReport = new karimBookCrystalReport();
                    ReportUtility.Display_report(employeeInfoCrystalReport, SalesInfoList, this);
               // }
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
                string suject = ((KarimBookSubject)ZoneBranchIDcomboBox.SelectedItem).SubjectName;

                if (!string.IsNullOrEmpty(searchTextBox.Text))
                {
                    List<KarimBook> list = objmangaer.GetKarimBookWithTakaLookupListAll(searchTextBox.Text, suject);

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
                    List<KarimBook> list = objmangaer.GetKarimBookWithTakaLookupListAllSubjectWise(suject);

                    bookGrid.Items.Clear();
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

        private void ZoneBranchIDcomboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            int stockQty = 0;

            if (!string.IsNullOrEmpty(stockQtyGreatherThanTextBox.Text))
            {
                stockQty = Convert.ToInt32(stockQtyGreatherThanTextBox.Text);

                string suject = ((KarimBookSubject)ZoneBranchIDcomboBox.SelectedItem).SubjectName;
                List<KarimBook> list = objmangaer.GetKarimBookWithTakaLookupListAllSubjectWise(suject);

                bookGrid.Items.Clear();

                foreach (KarimBook item in list)
                {
                    if (item.InStock>=stockQty)
                    {
                        bookGrid.Items.Add(item);
                    }
                    
                }
                int cont = list.Count;
                itemCountLabel.Content = cont.ToString();
            }
            else
            {
                string suject = ((KarimBookSubject)ZoneBranchIDcomboBox.SelectedItem).SubjectName;
                List<KarimBook> list = objmangaer.GetKarimBookWithTakaLookupListAllSubjectWise(suject);

                bookGrid.Items.Clear();

                foreach (KarimBook item in list)
                {
                    bookGrid.Items.Add(item);
                }
                int cont = list.Count;
                itemCountLabel.Content = cont.ToString();
            }

           
          
        }

        private void RemoveZoneInfoContextMenu_Click(object sender, RoutedEventArgs e)
        {
            if (bookGrid.SelectedIndex > -1)
            {
                //KarimBook bookObj = new KarimBook();
                //bookObj = (KarimBook)bookGrid.SelectedItem;

                bookGrid.Items.Remove(bookGrid.SelectedItem);

            
          
            }
        }
    }
}
