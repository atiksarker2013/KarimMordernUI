using Data.DC;
using FirstFloor.ModernUI.Windows.Controls;
using Models;
using System;
using System.Collections.Generic;
using System.Windows;

namespace KarimModernUINavigationApp
{
    /// <summary>
    /// Interaction logic for KarimAddNewBook.xaml
    /// </summary>
    public partial class KarimAddNewBook : ModernWindow
    {
        KarimBookContext bookContext = new KarimBookContext();
        public KarimAddNewBook()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            KarimBook obj = new KarimBook();
            obj.Title = bookTitleTextBox.Text;
            obj.Writer = writerTextBox.Text;
            obj.Publisher = publisherTextBox.Text;
            obj.Barcode = bookBarCodeTextBox.Text;

            if (!string.IsNullOrEmpty(priceTextBox.Text))
            {
                obj.Price = Convert.ToDecimal(priceTextBox.Text);
            }
            else
            {
                obj.Price = 0;
            }

            ///
            //string

            if (!string.IsNullOrEmpty(bookOpeningQtyTextBox.Text))
            {
                obj.Qty = Convert.ToInt32(bookOpeningQtyTextBox.Text);
            }
            else
            {
                obj.Qty = 0;
            }

            if (!string.IsNullOrEmpty(bookOpeningQtyTextBox.Text))
            {
                obj.InStock = Convert.ToInt32(bookOpeningQtyTextBox.Text);
            }
            else
            {
                obj.InStock = 0;
            }


            obj.EntryDate = entryDateDatepicker.SelectedDate;
            //if (bookContext.DoesExist(obj))
            //{
            //    MessageBox.Show("This Book Already Exist in to your stock.", "New Book", MessageBoxButton.OK, MessageBoxImage.Information);
            //}
            //else
            //{
                posDatagrid.Items.Add(obj);
            //}
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            List<KarimBook> _bookList = new List<KarimBook>();
            for (int i = 0; i < posDatagrid.Items.Count; i++)
            {
                KarimBook obj = posDatagrid.Items[i] as KarimBook;
                _bookList.Add(obj);
            }

            if (_bookList.Count > 0)
            {
                foreach (KarimBook item in _bookList)
                {
                    bookContext.Insert(item);
                }
            }

            MessageBox.Show("New Book Add successfully.", "New Book", MessageBoxButton.OK, MessageBoxImage.Information);

            // Clear UI
            posDatagrid.Items.Clear();
            bookTitleTextBox.Text = "";
            publisherTextBox.Text = "";
            bookOpeningQtyTextBox.Text = "";
            writerTextBox.Text = "";
            priceTextBox.Text = "";
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
