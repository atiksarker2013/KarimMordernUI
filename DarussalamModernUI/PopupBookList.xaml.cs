using Data;
using FirstFloor.ModernUI.Windows.Controls;
using Models;
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
    public partial class PopupBookList : ModernWindow
    {
        BookContext objmangaer = new BookContext();
        public PopupBookList()
        {
            InitializeComponent();
            LoadGrid();
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
                List<DarusSalamBook> list = objmangaer.GetAllBookListLookup(searchTextBox.Text);

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

        private void bookAddButton_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < bookGrid.Items.Count; i++)
            {
                DarusSalamBook obj = bookGrid.Items[i] as DarusSalamBook;

                var result = GlobalVar.TempOrderBookList.Find(x => x.Id == obj.Id);
                if (result == null && obj.OrderQty > 0)
                {
                    GlobalVar.TempOrderBookList.Add(obj);
                }

            }


            GlobalVar.DiscountsList = new List<Discounts>();
            GlobalVar.DiscountsList = GlobalVar.TempOrderBookList
            .GroupBy(l => l.Publisher)
            .Select(cl => new Discounts
            {
                PublisherName = cl.First().Publisher,

                TotalAmount = cl.Sum(c => c.Price)
            }).ToList();

        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            LoadMainWindow();
            this.Close();
        }

        private void LoadMainWindow()
        {


            try
            {
                POSUI obj;
                foreach (Window objWindow in Application.Current.Windows)
                {
                    string[] splitedNamespace = (objWindow.ToString()).Split('.');
                    string aClassNameFromCollection = splitedNamespace[splitedNamespace.Length - 1];
                    if (aClassNameFromCollection == "POSUI")
                    {
                        obj = (POSUI)objWindow;
                        obj.posDatagrid.Items.Clear();

                        foreach (DarusSalamBook item in GlobalVar.TempOrderBookList)
                        {
                            item.TotalUnitPrice = (item.Price * item.OrderQty);
                            obj.posDatagrid.Items.Add(item);
                        }

                        // Publisher Info
                        obj.discountDatagrid.Items.Clear();
                        foreach (Discounts item in GlobalVar.DiscountsList)
                        {
                            obj.discountDatagrid.Items.Add(item);
                        }
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Combobox reloading problem", "Client Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }
    }
}
