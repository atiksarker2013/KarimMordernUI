using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ReportApp
{
   public class ReportUtility
    {
        public static void Display_report(ReportClass rc, object objDataSource, Window parentWindow)
        {
            try
            {
                rc.SetDataSource(objDataSource);
                MainWindow Viewer = new MainWindow();
                Viewer.setReportSource(rc);
                Viewer.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
