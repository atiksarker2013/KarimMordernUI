using FirstFloor.ModernUI.Windows.Controls;
using System.Windows;
using System.Windows.Controls;
using System;
using Models;
using System.Collections.Generic;
using Data;

namespace KarimModernUINavigationApp
{
    /// <summary>
    /// Interaction logic for KarimPopupBookList.xaml
    /// </summary>
    public partial class KarimPopupBookList : ModernWindow
    {
        BookContext objmangaer = new BookContext();
        public KarimPopupBookList()
        {
            InitializeComponent();
            LoadGrid();
        }

        private void LoadGrid()
        {
            List<KarimBook> list = objmangaer.GetAllKarimBookListLookup("");

            foreach (KarimBook item in list)
            {
                bookGrid.Items.Add(item);
            }
        }

        private void bookAddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                for (int i = 0; i < bookGrid.Items.Count; i++)
                {
                    KarimBook obj = bookGrid.Items[i] as KarimBook;

                    var result = GlobalVar.TempOrderBookList.Find(x => x.Id == obj.Id);
                    if (result == null && obj.OrderQty > 0)
                    {
                        GlobalVar.TempOrderBookList.Add(obj);
                    }

                }


                //GlobalVar.DiscountsList = new List<Discounts>();
                //GlobalVar.DiscountsList = GlobalVar.TempOrderBookList.GroupBy(l => l.Publisher)
                //.Select(cl => new Discounts
                //{
                //    PublisherName = cl.First().Publisher,
                //    TotalAmount = cl.Sum(c => c.Price * c.OrderQty),
                //}).ToList();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
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
                KarimPOSUI obj;
                foreach (Window objWindow in Application.Current.Windows)
                {
                    string[] splitedNamespace = (objWindow.ToString()).Split('.');
                    string aClassNameFromCollection = splitedNamespace[splitedNamespace.Length - 1];
                    if (aClassNameFromCollection == "KarimPOSUI")
                    {
                        obj = (KarimPOSUI)objWindow;
                        obj.posDatagrid.Items.Clear();

                        foreach (KarimBook item in GlobalVar.TempOrderBookList)
                        {
                            item.TotalUnitPrice = (item.Price * item.OrderQty);
                            obj.posDatagrid.Items.Add(item);
                        }

                        // Publisher Info
                        //obj.discountDatagrid.Items.Clear();
                        //foreach (Discounts item in GlobalVar.DiscountsList)
                        //{
                        //    obj.discountDatagrid.Items.Add(item);
                        //}
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Combobox reloading problem", "Client Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        private void searchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(searchTextBox.Text))
                {
                    List<KarimBook> list = objmangaer.GetKarimBookLookupList(searchTextBox.Text);
                    bookGrid.Items.Clear();
                    foreach (KarimBook item in list)
                    {
                        bookGrid.Items.Add(item);
                    }
                }
                else
                {
                    List<KarimBook> list = objmangaer.GetKarimBookLookupList("");
                    foreach (KarimBook item in list)
                    {
                        bookGrid.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
    }
}
