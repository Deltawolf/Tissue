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
using System.Windows.Shapes;
using Excel = Microsoft.Office.Interop.Excel;
using Ta = Tissue_Dashboard.MainWindow.TheTracker;


namespace Tissue_Dashboard
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        internal Window1()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Ta.TissueTracker.archivalTracker.Rows[3].Insert();
            string patientName = patientText.Text;
            string accessionText1 = accessionText.Text;
            string requestorText1 = requestorText.Text;
            string physicianText1 = physicianText.Text ;
            string enrollmentText1 = enrollmentText.Text;
            string dateofbirthText1 = dateofbirthText.Text;
            Ta.TissueTracker.archivalTracker.Cells[3, 1].value = patientName;
            Ta.TissueTracker.archivalTracker.Cells[3, 2].value = accessionText1;
            Ta.TissueTracker.archivalTracker.Cells[3, 3].value = requestorText1;
            Ta.TissueTracker.archivalTracker.Cells[3, 4].value = physicianText1;
            Ta.TissueTracker.archivalTracker.Cells[3, 5].value = enrollmentText1;
            Ta.TissueTracker.archivalTracker.Cells[3, 6].value = dateofbirthText1;

            Window parentwin = Window1.GetWindow(this);
            parentwin.Close();
            Ta.TissueTracker.main_window.Visibility = Visibility.Visible;
            

        }
    }
}
