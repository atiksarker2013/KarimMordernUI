using Data;
using Data.DC;
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
    public partial class UpdateBookPrice : ModernWindow
    {
        BookContext objmangaer = new BookContext();
        DarussalamBookContext bookContext = new DarussalamBookContext();

        BookPriceUpdateContext bookPriceContext = new BookPriceUpdateContext();
        public UpdateBookPrice()
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

        private void updateBookButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            GlobalVar.UpdateBookPriceList = new List<DarusSalamBook>();
            for (int i = 0; i < bookGrid.Items.Count; i++)
            {
                DarusSalamBook obj = bookGrid.Items[i] as DarusSalamBook;
                if (obj.NewPrice!=0)
                {
                    GlobalVar.UpdateBookPriceList.Add(obj);
                }
            }

            // Book price info Insert record
            GlobalVar.BookPriceUpdateList = new List<BookPriceUpdate>();
            foreach (DarusSalamBook item in GlobalVar.UpdateBookPriceList)
            {
                BookPriceUpdate obj = new BookPriceUpdate();
                obj.BookId = item.Id;
                obj.OldPrice = item.Price;
                obj.NewPrice = item.NewPrice;
                obj.UpdateDate =DateTime.Now;
                bookPriceContext.Insert(obj);
            }

            // Update Book Price
            foreach (DarusSalamBook item in GlobalVar.UpdateBookPriceList)
            {
                item.Price = item.NewPrice;
                bookContext.Update(item);
            }

            MessageBox.Show("Book Price Update Successfully..", "Book Price Update", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void closeButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Close();
        }

        
    }
}
