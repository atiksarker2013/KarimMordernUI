using Data;
using Data.DC;
using KarimModernUINavigationApp.Report.Crystal;
using KarimModernUINavigationApp.Report.Model;
using Microsoft.Office.Interop.Excel;
using Models;
using ReportApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace KarimModernUINavigationApp
{
    /// <summary>
    /// Interaction logic for PopupKarimBookListReport.xaml
    /// </summary>
    public partial class PopupKarimBookListSelectedReport
    {
        BookContext objmangaer = new BookContext();
       List<KarimBookSubject> _subjectList = new List<KarimBookSubject>();
        public PopupKarimBookListSelectedReport()
        {
            InitializeComponent();
            selectedBook.IsChecked = true;
          

            titleChkBox.IsChecked = true;
            writerChkBox.IsChecked = true;
            publisherChkBox.IsChecked = true;
            isbnChkBox.IsChecked = true;
           // bookTypeChkBox.IsChecked = true;
            publisherPriceChkBox.IsChecked = true;
            publisherUnitChkBox.IsChecked = true;
            priceChkBox.IsChecked = true;
            stockQtyChkBox.IsChecked = true;
 
            LoadGrid();
            LoadSubject();
            ZoneBranchIDcomboBox.SelectedIndex = 5;

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
                bookGridFrom.Items.Add(item);
            }
            int cont = list.Count;
            itemCountLabel.Content = cont.ToString();
        }


        private void Row_DoubleFromClick(object sender, MouseButtonEventArgs e)
        {
            RKarimBook chalan = new RKarimBook();
            chalan = bookGridFrom.SelectedItem as RKarimBook;// get selected item
        }

        private void previewButton_Click(object sender, RoutedEventArgs e)
        {
            List<RKarimBook> SalesInfoList = new List<RKarimBook>();

            for (int i = 0; i < bookGridTo.Items.Count; i++)
            {
                KarimBook entity = bookGridTo.Items[i] as KarimBook;

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
                 
                    karimBookCrystalReport employeeInfoCrystalReport = new karimBookCrystalReport();
                    ReportUtility.Display_report(employeeInfoCrystalReport, SalesInfoList, this);
               
            }
        }

           
        

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void searchTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            try
            {
                if (IsAllBook == true)
                {
                    List<KarimBook> list = objmangaer.GetKarimBookWithTakaLookupList(searchTextBox.Text);

                    bookGridFrom.Items.Clear();
                    foreach (KarimBook item in list)
                    {
                        bookGridFrom.Items.Add(item);
                    }
                    int cont = list.Count;
                    itemCountLabel.Content = cont.ToString();
                }
                else
                {
                    string suject = ((KarimBookSubject)ZoneBranchIDcomboBox.SelectedItem).SubjectName;

                    if (!string.IsNullOrEmpty(searchTextBox.Text))
                    {
                        List<KarimBook> list = objmangaer.GetKarimBookWithTakaLookupListAll(searchTextBox.Text, suject);

                        bookGridFrom.Items.Clear();
                        foreach (KarimBook item in list)
                        {
                            bookGridFrom.Items.Add(item);
                        }
                        int cont = list.Count;
                        itemCountLabel.Content = cont.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            
        }

        private bool IsAllBook = false;
        private void selectedBook_Click(object sender, RoutedEventArgs e)
        {
            bookGridFrom.Items.Clear();

            IsAllBook = false;
        }

        private void allBook_Click(object sender, RoutedEventArgs e)
        {
            List<KarimBook> list = objmangaer.GetKarimBookWithTakaLookupListAll("");
            bookGridFrom.Items.Clear();
            foreach (KarimBook item in list)
            {
                bookGridFrom.Items.Add(item);
            }
            int cont = list.Count;
            itemCountLabel.Content = cont.ToString();

            IsAllBook = true;
        }

        private void ZoneBranchIDcomboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            int stockQty = 0;

            if (!string.IsNullOrEmpty(stockQtyGreatherThanTextBox.Text))
            {
                stockQty = Convert.ToInt32(stockQtyGreatherThanTextBox.Text);

                string suject = ((KarimBookSubject)ZoneBranchIDcomboBox.SelectedItem).SubjectName;
                List<KarimBook> list = objmangaer.GetKarimBookWithTakaLookupListAllSubjectWise(suject);

                bookGridFrom.Items.Clear();

                foreach (KarimBook item in list)
                {
                    if (item.InStock>=stockQty)
                    {
                        bookGridFrom.Items.Add(item);
                    }
                    
                }
                int cont = list.Count;
                itemCountLabel.Content = cont.ToString();
            }
            else
            {
                string suject = ((KarimBookSubject)ZoneBranchIDcomboBox.SelectedItem).SubjectName;
                List<KarimBook> list = objmangaer.GetKarimBookWithTakaLookupListAllSubjectWise(suject);

                bookGridFrom.Items.Clear();

                foreach (KarimBook item in list)
                {
                    bookGridFrom.Items.Add(item);
                }
                int cont = list.Count;
                itemCountLabel.Content = cont.ToString();
            }

           
          
        }

        private void RemoveZoneInfoContextMenu_Click(object sender, RoutedEventArgs e)
        {
            if (bookGridFrom.SelectedIndex > -1)
            {
                //KarimBook bookObj = new KarimBook();
                //bookObj = (KarimBook)bookGridFrom.SelectedItem;

                bookGridFrom.Items.Remove(bookGridFrom.SelectedItem);

            
          
            }
        }

        private void bookGridFrom_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            IInputElement element = e.MouseDevice.DirectlyOver;
            if (element != null && element is FrameworkElement)
            {
                if (((FrameworkElement)element).Parent is DataGridCell)
                {
                    var grid = sender as DataGrid;
                    if (grid != null && grid.SelectedItems != null && grid.SelectedItems.Count == 1)
                    {
                        //var rowView = grid.SelectedItem as DataRowView;
                        try
                        {
                            KarimBook chalan = new KarimBook();
                            chalan = (KarimBook)bookGridFrom.SelectedItem;

                            List<KarimBook> _bookList = new List<KarimBook>();

                            for (int i = 0; i < bookGridTo.Items.Count; i++)
                            {
                                KarimBook entity = bookGridTo.Items[i] as KarimBook;
                                _bookList.Add(entity);
                            }


                            if (_bookList.Any(cus => cus.Id == chalan.Id))
                            {
                                //TODO CODE
                            }
                            else
                            {
                                bookGridTo.Items.Add(chalan);
                            }

                            
                        }
                        catch
                        {

                        }
                    }
                }
            }
        }

        private void bookGridTo_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            IInputElement element = e.MouseDevice.DirectlyOver;
            if (element != null && element is FrameworkElement)
            {
                if (((FrameworkElement)element).Parent is DataGridCell)
                {
                    var grid = sender as DataGrid;
                    if (grid != null && grid.SelectedItems != null && grid.SelectedItems.Count == 1)
                    {
                        //var rowView = grid.SelectedItem as DataRowView;
                        try
                        {
                            KarimBook chalan = new KarimBook();
                            chalan = (KarimBook)bookGridTo.SelectedItem;

                            bookGridTo.Items.Remove(chalan);
                             
                        }
                        catch
                        {

                        }
                    }
                }
            }
        }

        private void previewButton2_Click(object sender, RoutedEventArgs e)
        {
            List<RKarimBook> SalesInfoList = new List<RKarimBook>();

            for (int i = 0; i < bookGridTo.Items.Count; i++)
            {
                KarimBook entity = bookGridTo.Items[i] as KarimBook;

                RKarimBook model = new RKarimBook();



                model.Title = entity.Title;
                model.Writer = entity.Writer;
                model.Publisher = entity.Publisher;
                model.Barcode = entity.Barcode;
                model.Qty = entity.Qty ?? 0;
                model.Price = entity.Price ?? 0;
                model.PublisherPrice = entity.PublisherPrice;
                model.PublisherUnit = entity.PublisherUnit;
                if (entity.PublishYear == null)
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

            if (SalesInfoList.Count > 0)
            {
                karimBookCrystalReportWithoutGroup employeeInfoCrystalReport = new karimBookCrystalReportWithoutGroup();
                ReportUtility.Display_report(employeeInfoCrystalReport, SalesInfoList, this);
            }
        }

        private void previewButton3_Click(object sender, RoutedEventArgs e)
        {
            List<RKarimBook> SalesInfoList = new List<RKarimBook>();

            for (int i = 0; i < bookGridTo.Items.Count; i++)
            {
                KarimBook entity = bookGridTo.Items[i] as KarimBook;

                RKarimBook model = new RKarimBook();
                model.Title = entity.Title;
                model.Writer = entity.Writer;
                model.Publisher = entity.Publisher;
                model.Barcode = entity.Barcode;
                model.Qty = entity.Qty ?? 0;
                model.Price = entity.Price ?? 0;
                model.PublisherPrice = entity.PublisherPrice;
                model.PublisherUnit = entity.PublisherUnit;
                if (entity.PublishYear == null)
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

            ExcelUtlity objjj = new ExcelUtlity();
            System.Data.DataTable dtttt = ConvertToDataTable(SalesInfoList);

            objjj.WriteDataTableToExcel(dtttt, "Book Details", "D:\\BookList.xlsx", "Details");
        }
        public System.Data.DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            System.Data.DataTable table = new System.Data.DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;

        }
    }
}
