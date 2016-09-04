using DarussalamModernUI.Report.Model;
using Data.DC;
using FirstFloor.ModernUI.Windows.Controls;
using Models;
using System;
using System.Collections.Generic;
using System.Windows;

namespace DarussalamModernUI
{
    
    public partial class AddNewBook : ModernWindow
    {
        SalesContext salesManagerObj = new SalesContext();
        SalesDetailsContext salesDetailsManagerObj = new SalesDetailsContext();
        DarussalamBookContext bookContext = new DarussalamBookContext();
        DiscountContext discountContext = new DiscountContext();

        List<RDarusSalamBook> SalesInfoList = new List<RDarusSalamBook>();
        List<DarusSalamBook> newbookList = new List<DarusSalamBook>();
        
        public AddNewBook()
        {
            InitializeComponent();
            entryDateDatepicker.SelectedDate = DateTime.Today;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PopupBookList obj = new PopupBookList();
            obj.Show();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            
            DarusSalamBook obj = new DarusSalamBook();
            obj.Title = bookTitleTextBox.Text;
            obj.Writer = writerTextBox.Text;
            obj.Publisher = publisherTextBox.Text;

            if (!string.IsNullOrEmpty(priceTextBox.Text))
            {
                obj.Price = Convert.ToDecimal(priceTextBox.Text); 
            }
            else
            {
                obj.Price = 0;
            }


            if (!string.IsNullOrEmpty(priceTextBox.Text))
            {
                obj.Qty = Convert.ToInt32(openingQtyTextBox.Text);
            }
            else
            {
                obj.Qty = 0;
            }

            if (!string.IsNullOrEmpty(priceTextBox.Text))
            {
                obj.InStock = Convert.ToInt32(openingQtyTextBox.Text);
            }
            else
            {
                obj.InStock = 0;
            }

            
            obj.EntryDate = entryDateDatepicker.SelectedDate;
            if (bookContext.DoesExist(obj))
            {
                MessageBox.Show("This Book Already Exist in to your stock.", "New Book", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                posDatagrid.Items.Add(obj);
            }

           
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            List<DarusSalamBook> _bookList = new List<DarusSalamBook>();
            for (int i = 0; i < posDatagrid.Items.Count; i++)
            {
                DarusSalamBook obj = posDatagrid.Items[i] as DarusSalamBook;
                _bookList.Add(obj);
            }

            if (_bookList.Count>0)
            {
                foreach (DarusSalamBook item in _bookList)
                {
                    bookContext.Insert(item);
                }
            }

            MessageBox.Show("New Book Add successfully.", "New Book", MessageBoxButton.OK, MessageBoxImage.Information);

            // Clear UI
            posDatagrid.Items.Clear();
            bookTitleTextBox.Text = "";
            publisherTextBox.Text = "";
            openingQtyTextBox.Text = "";
            writerTextBox.Text = "";
            priceTextBox.Text = "";
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       
    }
}
