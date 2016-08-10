using Data.DC;
using FirstFloor.ModernUI.Windows.Controls;
using Models;
using System;
using System.Collections.Generic;

namespace DarussalamModernUI
{
    /// <summary>
    /// Interaction logic for SalesHistory.xaml
    /// </summary>
    public partial class SalesHistory : ModernWindow
    {
        SalesContext salesContext = new SalesContext();

        decimal total = 0;
        decimal totalDiscount = 0;
        decimal totalOtherDiscount = 0;
        decimal totalGrandTotal = 0;
        decimal totalReceive = 0;
        decimal totalDue = 0;

        public SalesHistory()
        {
            InitializeComponent();
            fromDateDatepicker.SelectedDate = DateTime.Today;
            toDateDatepicker.SelectedDate = DateTime.Today;
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            DateTime fromDate = Convert.ToDateTime(fromDateDatepicker.SelectedDate);
            DateTime toDate = Convert.ToDateTime(toDateDatepicker.SelectedDate);
            List<Sales> salesList = new List<Sales>();
            salesList = salesContext.GetSalesHistoryByDateRange(fromDate, toDate);

            posDatagrid.Items.Clear();

            foreach (Sales item in salesList)
            {
                total = total + item.Total;
                totalDiscount = totalDiscount + item.Discount;
                totalOtherDiscount = totalOtherDiscount + item.OtherDiscount;
                totalGrandTotal = totalGrandTotal + item.GrandTotal;
                totalReceive = totalReceive + item.Receive;
                totalDue = totalDue + item.Due;

                totalTextBox.Text = total.ToString("F");
                totalDiscountTextBox.Text = totalDiscount.ToString("F");
                totalOtherDiscountTextBox.Text = totalOtherDiscount.ToString("F");
                totalGrandTotaltTextBox.Text = totalGrandTotal.ToString("F");
                totalReceiveTextBox.Text = totalReceive.ToString("F");
                totalDueTextBox.Text = totalDue.ToString("F");

                posDatagrid.Items.Add(item);
            }
        }

        private void closeButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
