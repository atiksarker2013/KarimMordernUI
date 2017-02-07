using Data;
using Data.DC;
using FirstFloor.ModernUI.Windows.Controls;
using System.Windows;
using System.Windows.Controls;
using System;
using Models;
using System.Collections.Generic;
using System.Windows.Data;
using System.Globalization;

namespace KarimModernUINavigationApp
{
    /// <summary>
    /// Interaction logic for UpdateKarimBookInfo.xaml
    /// </summary>
    public partial class UpdateKarimBookInfo : ModernWindow
    {
        BookContext objmangaer = new BookContext();
        KarimBookContext bookContext = new KarimBookContext();
        public UpdateKarimBookInfo()
        {
            InitializeComponent();
            LoadGrid();
        }

        private void LoadGrid()
        {
            List<KarimBook> list = objmangaer.GetAllKarimBookListForUpdateLookup("");

            foreach (KarimBook item in list)
            {
                bookGrid.Items.Add(item);
            }
        }

        private void updateBookButton_Click(object sender, RoutedEventArgs e)
        {
            GlobalVar.UpdateKarimBookList = new List<KarimBook>();
            for (int i = 0; i < bookGrid.Items.Count; i++)
            {
                KarimBook obj = bookGrid.Items[i] as KarimBook;

                //if (!string.IsNullOrEmpty(obj.Barcode))
                //{
                GlobalVar.UpdateKarimBookList.Add(obj);
                // }
            }

            foreach (KarimBook item in GlobalVar.UpdateKarimBookList)
            {
                bookContext.Update(item);
            }


            MessageBox.Show("Book Barcode Update Successfully..", "Book Barcode Update", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void searchTextBox_TextChanged(object sender, TextChangedEventArgs e)
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
                List<KarimBook> list = objmangaer.GetAllKarimBookListForUpdateLookup("");

                foreach (KarimBook item in list)
                {
                    bookGrid.Items.Add(item);
                }
            }
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
