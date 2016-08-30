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
    public partial class PopupBookListReport : ModernWindow
    {
        BookContext objmangaer = new BookContext();
        public PopupBookListReport()
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
                List<DarusSalamBook> list = objmangaer.GetAllBookListREportLookup(searchTextBox.Text);

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

        private void allBook_Click(object sender, RoutedEventArgs e)
        {
            List<DarusSalamBook> list = objmangaer.GetAllBookListLookup();
            bookGrid.Items.Clear();
            foreach (DarusSalamBook item in list)
            {
                bookGrid.Items.Add(item);
            }
        }

        private void selectedBook_Click(object sender, RoutedEventArgs e)
        {
            bookGrid.Items.Clear();
        }

        private void closeButton_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void previewButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
