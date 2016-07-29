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

                // TGBP += Convert.ToDecimal(obj.FeesAmount); // getting cell value   
            }
            //DarusSalamBook obj = new DarusSalamBook();
            //obj = bookGrid.SelectedItem as DarusSalamBook;
            //GlobalVar.TempOrderBookList.Add(obj);
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
