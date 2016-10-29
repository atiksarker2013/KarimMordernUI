using Data;
using Data.DC;
using FirstFloor.ModernUI.Windows.Controls;
using Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace KarimModernUINavigationApp
{
    /// <summary>
    /// Interaction logic for UpdateKarimBookPrice.xaml
    /// </summary>
    public partial class UpdateKarimBookPrice : ModernWindow
    {
        BookContext objmangaer = new BookContext();
        KarimBookContext bookContext = new KarimBookContext();

        KarimBookPriceUpdateContext bookPriceContext = new KarimBookPriceUpdateContext();
        public UpdateKarimBookPrice()
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

        private void updateBookButton_Click(object sender, RoutedEventArgs e)
        {
            GlobalVar.UpdateBookPriceList = new List<KarimBook>();
            for (int i = 0; i < bookGrid.Items.Count; i++)
            {
                KarimBook obj = bookGrid.Items[i] as KarimBook;
                if (obj.NewPrice > 0)
                {
                    GlobalVar.UpdateBookPriceList.Add(obj);
                }
            }

            // Book price info Insert record
            GlobalVar.BookPriceUpdateList = new List<KarimBook>();
            foreach (KarimBook item in GlobalVar.UpdateBookPriceList)
            {
                KarimBookPriceUpdate obj = new KarimBookPriceUpdate();
                obj.BookId = item.Id;
                obj.OldPrice = item.Price;
                obj.NewPrice = item.NewPrice;
                obj.UpdateDate = DateTime.Now;
                bookPriceContext.Insert(obj);
            }

            // Update Book Price
            foreach (KarimBook item in GlobalVar.UpdateBookPriceList)
            {
                item.Price = item.NewPrice;
                bookContext.Update(item);
            }

            MessageBox.Show("Book Price Update Successfully..", "Book Price Update", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
