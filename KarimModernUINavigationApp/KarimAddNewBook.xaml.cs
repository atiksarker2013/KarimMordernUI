using Data.DC;
using FirstFloor.ModernUI.Windows.Controls;
using Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

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
            entryDateDatepicker.SelectedDate = DateTime.Now;
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            KarimBook obj = new KarimBook();
            //obj.Title = bookTitleTextBox.Text;
            //obj.Writer = writerTextBox.Text;
            //obj.Publisher = publisherTextBox.Text;
            //obj.Barcode = bookBarCodeTextBox.Text;

            //if (!string.IsNullOrEmpty(priceTextBox.Text))
            //{
            //    obj.PublisherPrice = Convert.ToDecimal(priceTextBox.Text);
            //}
            //else
            //{
            //    obj.PublisherPrice = 0;
            //}

            /////
            ////string

            //if (!string.IsNullOrEmpty(bookOpeningQtyTextBox.Text))
            //{
            //    obj.Qty = Convert.ToInt32(bookOpeningQtyTextBox.Text);
            //}
            //else
            //{
            //    obj.Qty = 0;
            //}

            //if (!string.IsNullOrEmpty(bookOpeningQtyTextBox.Text))
            //{
            //    obj.InStock = Convert.ToInt32(bookOpeningQtyTextBox.Text);
            //}
            //else
            //{
            //    obj.InStock = 0;
            //}


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
            //bookTitleTextBox.Text = "";
            //publisherTextBox.Text = "";
            //bookOpeningQtyTextBox.Text = "";
            //writerTextBox.Text = "";
            //priceTextBox.Text = "";
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        [ValueConversion(typeof(object), typeof(string))]
        public class StringFormatConverter : IValueConverter, IMultiValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return Convert(new object[] { value }, targetType, parameter, culture);
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                System.Diagnostics.Trace.TraceError("StringFormatConverter: does not support TwoWay or OneWayToSource bindings.");
                return DependencyProperty.UnsetValue;
            }

            public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
            {
                try
                {
                    string format = (parameter == null) ? null : parameter.ToString();
                    if (String.IsNullOrEmpty(format))
                    {
                        System.Text.StringBuilder builder = new System.Text.StringBuilder();
                        for (int index = 0; index < values.Length; ++index)
                        {
                            builder.Append("{" + index + "}");
                        }
                        format = builder.ToString();
                    }
                    return String.Format(/*culture,*/ format, values);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.TraceError("StringFormatConverter({0}): {1}", parameter, ex.Message);
                    return DependencyProperty.UnsetValue;
                }
            }

            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            {
                System.Diagnostics.Trace.TraceError("StringFormatConverter: does not support TwoWay or OneWayToSource bindings.");
                return null;
            }
        }
    }
}
