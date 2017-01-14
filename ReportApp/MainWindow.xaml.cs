using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace ReportApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var sidepanel = crystalReportsViewer.FindName("btnToggleSidePanel") as ToggleButton;
            if (sidepanel != null)
            {
                crystalReportsViewer.ViewChange += (x, y) => sidepanel.IsChecked = false;
            }

        }

        public void setReportSource(CrystalDecisions.CrystalReports.Engine.ReportDocument aReport)
        {
            this.crystalReportsViewer.ViewerCore.ReportSource = aReport;
        }


        public void setDataTableReportSource(ReportClass rc, ParameterFields paramFields)
        {
            this.crystalReportsViewer.ViewerCore.ReportSource = rc;
            this.crystalReportsViewer.ViewerCore.ParameterFieldInfo = paramFields;
        }
    }
}


 