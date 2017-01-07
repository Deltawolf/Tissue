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
using UsingTheTracker = Tissue_Dashboard.TheTracker;


namespace Tissue_Dashboard
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Request_Window : Window
    {
        internal Request_Window()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            UsingTheTracker.TissueTracker.archivalTracker.Rows[3].Insert();
            UsingTheTracker.TissueTracker.archivalTracker.Cells[3, 1].value = patientText.Text; //Textbox value as Text. Exception occurrs without .Text
            UsingTheTracker.TissueTracker.archivalTracker.Cells[3, 2].value = accessionText.Text; //Would like to house Cell reference for every field in one area. May need class or see if extension can be added to archivalTracker
            UsingTheTracker.TissueTracker.archivalTracker.Cells[3, 3].value = requestorText.Text;
            UsingTheTracker.TissueTracker.archivalTracker.Cells[3, 4].value = physicianText.Text;
            UsingTheTracker.TissueTracker.archivalTracker.Cells[3, 5].value = enrollmentText.Text;
            UsingTheTracker.TissueTracker.archivalTracker.Cells[3, 6].value = dateofbirthText.Text;

            Window parentwin = Request_Window.GetWindow(this);
            parentwin.Close();
            UsingTheTracker.TissueTracker.main_window.Visibility = Visibility.Visible;
            

        }
    }
}
