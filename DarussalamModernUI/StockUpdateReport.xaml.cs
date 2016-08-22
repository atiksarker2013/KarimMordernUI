using DarussalamModernUI.Report.Crystal;
using DarussalamModernUI.Report.Model;
using Data.DC;
using FirstFloor.ModernUI.Windows.Controls;
using Models;
using ReportApp;
using System;
using System.Collections.Generic;
using System.Windows;

namespace DarussalamModernUI
{
    /// <summary>
    /// Interaction logic for SalesHistory.xaml
    /// </summary>
    public partial class StockUpdateReport : ModernWindow
    {
        SalesContext salesContext = new SalesContext();
        DarussalamBookContext _bookContext = new DarussalamBookContext();

        SalesContext salesManagerObj = new SalesContext();
        SalesDetailsContext salesDetailsManagerObj = new SalesDetailsContext();
        DarussalamBookContext bookContext = new DarussalamBookContext();
        DiscountContext discountContext = new DiscountContext();

        List<RDarusSalamBook> SalesInfoList = new List<RDarusSalamBook>();

         

         

        public StockUpdateReport()
        {
            InitializeComponent();
            fromDateDatepicker.SelectedDate = DateTime.Today;
            toDateDatepicker.SelectedDate = DateTime.Today;
        }

   

        private void closeButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Close();
        }
         
         
    }
}
