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
using System.Data.OleDb;
using System.Data;


namespace Tissue_Dashboard
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class MainPage : System.Windows.Controls.Page
    {

        private void data_grid_constructor(object sender, EventArgs e)
        {
            try
            {

                String sheet = "Sheet1";
                String connectionstring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + TheTracker.TissueTracker.myWorkbook + ";Extended Properties='Excel 12.0 Xml;HDR=YES;';";

                OleDbConnection connection = new OleDbConnection(connectionstring);
                OleDbCommand oconnection = new OleDbCommand("Select `Patient Name`, `Date of Birth` From [" + sheet + "$] Where Status=\"Requested\"", connection);
                connection.Open();

                OleDbDataAdapter connectiondataAdapter = new OleDbDataAdapter(oconnection);
                DataTable data = new DataTable();
                connectiondataAdapter.Fill(data);
                Recent_Requests.ItemsSource = data.DefaultView;

            }
            catch (OleDbException lolex)
            {
                ReportException(lolex);
            }
            catch (Exception ex)
            {
                ReportException(ex);
            }

        }

        private void ReportException(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }


        private void ReportException(OleDbException oleex)
        {

            StringBuilder errorbuilder = new StringBuilder();
            errorbuilder.Append(oleex.ErrorCode + Environment.NewLine);
            errorbuilder.Append(oleex.Message + Environment.NewLine);
            MessageBox.Show(errorbuilder.ToString());
        }

        private void ReportMessage(string msg)
        {
            MessageBox.Show(msg);
        }
    }
}
