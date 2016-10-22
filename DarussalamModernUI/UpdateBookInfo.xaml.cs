using Data;
using Data.DC;
using FirstFloor.ModernUI.Windows.Controls;
using Models;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace DarussalamModernUI
{
    /// <summary>
    /// Interaction logic for PopupBookList.xaml
    /// </summary>
    public partial class UpdateBookInfo : ModernWindow
    {
        BookContext objmangaer = new BookContext();
        DarussalamBookContext bookContext = new DarussalamBookContext();
        public UpdateBookInfo()
        {
            InitializeComponent();
           LoadGrid();
        }

        private void LoadGrid()
        {
            List<DarusSalamBook> list = objmangaer.GetAllBookListForUpdateLookup("");

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
                List<DarusSalamBook> list = objmangaer.GetAllBookListForUpdateLookup("");

                foreach (DarusSalamBook item in list)
                {
                    bookGrid.Items.Add(item);
                }
            }
        }

        private void updateBookButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            GlobalVar.UpdateBookList = new List<DarusSalamBook>();
            for (int i = 0; i < bookGrid.Items.Count; i++)
            {
                DarusSalamBook obj = bookGrid.Items[i] as DarusSalamBook;

                //if (!string.IsNullOrEmpty(obj.Barcode))
                //{
                    GlobalVar.UpdateBookList.Add(obj);
               // }
            }

            foreach (DarusSalamBook item in GlobalVar.UpdateBookList)
            {
                bookContext.Update(item);
            }


            MessageBox.Show("Book Barcode Update Successfully..", "Book Barcode Update", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void closeButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Close();
        }

        //private void bookAddButton_Click(object sender, RoutedEventArgs e)
        //{
        //    for (int i = 0; i < bookGrid.Items.Count; i++)
        //    {
        //        DarusSalamBook obj = bookGrid.Items[i] as DarusSalamBook;

        //        var result = GlobalVar.TempOrderBookList.Find(x => x.Id == obj.Id);
        //        if (result == null && obj.OrderQty > 0)
        //        {
        //            GlobalVar.TempOrderBookList.Add(obj);
        //        }

        //    }


        //    GlobalVar.DiscountsList = new List<Discounts>();
        //    GlobalVar.DiscountsList = GlobalVar.TempOrderBookList
        //    .GroupBy(l => l.Publisher)
        //    .Select(cl => new Discounts
        //    {
        //        PublisherName = cl.First().Publisher,

        //        TotalAmount = cl.Sum(c => c.Price)
        //    }).ToList();

        //}

        //private void closeButton_Click(object sender, RoutedEventArgs e)
        //{
        //    LoadMainWindow();
        //    this.Close();
        //}

        //private void LoadMainWindow()
        //{


        //    try
        //    {
        //        POSUI obj;
        //        foreach (Window objWindow in Application.Current.Windows)
        //        {
        //            string[] splitedNamespace = (objWindow.ToString()).Split('.');
        //            string aClassNameFromCollection = splitedNamespace[splitedNamespace.Length - 1];
        //            if (aClassNameFromCollection == "POSUI")
        //            {
        //                obj = (POSUI)objWindow;
        //                obj.posDatagrid.Items.Clear();

        //                foreach (DarusSalamBook item in GlobalVar.TempOrderBookList)
        //                {
        //                    item.TotalUnitPrice = (item.Price * item.OrderQty);
        //                    obj.posDatagrid.Items.Add(item);
        //                }

        //                // Publisher Info
        //                obj.discountDatagrid.Items.Clear();
        //                foreach (Discounts item in GlobalVar.DiscountsList)
        //                {
        //                    obj.discountDatagrid.Items.Add(item);
        //                }
        //                break;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Combobox reloading problem", "Client Info", MessageBoxButton.OK, MessageBoxImage.Information);
        //    }

        //}
    }
}
