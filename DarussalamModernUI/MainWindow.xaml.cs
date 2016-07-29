using FirstFloor.ModernUI.Windows.Controls;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ModernWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            POSUI obj = new POSUI();
            obj.Show();
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            POSUI obj = new POSUI();
            obj.Show();
        }

        private void salesHistoryButton_Click(object sender, RoutedEventArgs e)
        {
            SalesHistory obj = new SalesHistory();
            obj.Show();
        }
    }
}
