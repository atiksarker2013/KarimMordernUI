using Data;
using FirstFloor.ModernUI.Windows.Controls;
using Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace DarussalamModernUI
{
    /// <summary>
    /// Interaction logic for PopupBookList.xaml
    /// </summary>
    public partial class PopupNewBookEntryList : ModernWindow
    {
        BookContext objmangaer = new BookContext();
        public PopupNewBookEntryList()
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

                var result = GlobalVar.TempNewBookEntryList.Find(x => x.Id == obj.Id);
                if (result == null && obj.NewEntryQty > 0)
                {
                    GlobalVar.TempNewBookEntryList.Add(obj);
                }

            }
            
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
                NewBookInventory obj;
                foreach (Window objWindow in Application.Current.Windows)
                {
                    string[] splitedNamespace = (objWindow.ToString()).Split('.');
                    string aClassNameFromCollection = splitedNamespace[splitedNamespace.Length - 1];
                    if (aClassNameFromCollection == "NewBookInventory")
                    {
                        obj = (NewBookInventory)objWindow;
                        obj.posDatagrid.Items.Clear();

                        foreach (DarusSalamBook item in GlobalVar.TempNewBookEntryList)
                        {
                           // item.TotalUnitPrice = (item.Price * item.OrderQty);
                            obj.posDatagrid.Items.Add(item);
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
