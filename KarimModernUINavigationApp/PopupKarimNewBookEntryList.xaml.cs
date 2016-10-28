using Data;
using FirstFloor.ModernUI.Windows.Controls;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KarimModernUINavigationApp
{
    /// <summary>
    /// Interaction logic for PopupKarimNewBookEntryList.xaml
    /// </summary>
    public partial class PopupKarimNewBookEntryList : ModernWindow
    {
        BookContext objmangaer = new BookContext();
        public PopupKarimNewBookEntryList()
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

        private void searchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(searchTextBox.Text))
                {
                    List<KarimBook> list = objmangaer.GetAllKarimBookListLookup(searchTextBox.Text);

                    bookGrid.Items.Clear();
                    foreach (KarimBook item in list)
                    {
                        bookGrid.Items.Add(item);
                    }
                }
                else
                {
                    List<KarimBook> list = objmangaer.GetAllKarimBookListLookup("");

                    foreach (KarimBook item in list)
                    {
                        bookGrid.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void bookAddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                for (int i = 0; i < bookGrid.Items.Count; i++)
                {
                    KarimBook obj = bookGrid.Items[i] as KarimBook;

                    var result = GlobalVar.TempNewKarimBookEntryList.Find(x => x.Id == obj.Id);
                    if (result == null && obj.NewEntryQty > 0)
                    {
                        GlobalVar.TempNewKarimBookEntryList.Add(obj);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                throw;
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
                NewKarimBookInventory obj;
                foreach (Window objWindow in Application.Current.Windows)
                {
                    string[] splitedNamespace = (objWindow.ToString()).Split('.');
                    string aClassNameFromCollection = splitedNamespace[splitedNamespace.Length - 1];
                    if (aClassNameFromCollection == "NewKarimBookInventory")
                    {
                        obj = (NewKarimBookInventory)objWindow;
                        obj.posDatagrid.Items.Clear();

                        foreach (KarimBook item in GlobalVar.TempNewKarimBookEntryList)
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
