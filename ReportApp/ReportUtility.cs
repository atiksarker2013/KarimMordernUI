using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
using System.Data.SqlClient;

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

        public static void DataTableDisplay_report(ReportClass rc, SqlDataAdapter objDataSource, ParameterFields paramFields, Window parentWindow)
        {
            try
            {
               // rc.SetDataSource(objDataSource);
                MainWindow Viewer = new MainWindow();
                //Viewer.crystalReportsViewer.para = paramFields;
                Viewer.setDataTableReportSource(rc, paramFields);
                Viewer.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       
    }
}
