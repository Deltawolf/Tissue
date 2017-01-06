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
using Excel = Microsoft.Office.Interop.Excel;

namespace Tissue_Dashboard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// 
    /// </summary>
    /// 


    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();
            TheTracker.TissueTracker.PrepareTheChopper();
        }

        //private void InitializeComponent()
        //{
        //    throw new NotImplementedException();
        //}


        internal class TheTracker
        {
            public Window main_window { get; set; }
            public Excel.Application oXL { get; set; }
            public Excel.Workbook oWB { get; set; }
            public Excel.Worksheets oWS { get; set; }
            public Excel.Worksheet archivalTracker { get; set; }
            public Excel.Worksheet freshTracker { get; set; }
            public Excel.Worksheet sourceTracker { get; set; }
            public Excel._Worksheet oSheet { get; set; }
            public Excel.Range oRng { get; set; }

            private static TheTracker Tissuetracker = new TheTracker();
            private TheTracker() { }

            internal static TheTracker TissueTracker
            {
                get
                {
                    if (Tissuetracker == null)
                        Tissuetracker = new TheTracker();

                    return Tissuetracker;
                }
            }

            internal void PrepareTheChopper()
            {
                oXL = new Excel.Application();

                string myWorkbook = @"C:\Users\Zach\Desktop\New1.xlsx";
                bool wbOpened = ((Excel.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application")).Workbooks.Cast<Excel.Workbook>().FirstOrDefault(x => x.Name == myWorkbook) != null;
                if (wbOpened == false)
                    oWB = oXL.Workbooks.Open(myWorkbook);
                else
                {
                    MessageBox.Show("Please close the tracker before continuing.", "Close the tracker!", MessageBoxButton.OK, MessageBoxImage.Error);
                    Environment.Exit(0);
                }
                archivalTracker = oWB.Worksheets[1];
                oXL.Visible = true;
                oXL.UserControl = true;
            }
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {

            Window1 tissueRequest = new Window1();
            tissueRequest.Show();
            TheTracker.TissueTracker.main_window = this;
            TheTracker.TissueTracker.main_window.Visibility = Visibility.Collapsed;
        }

    }
}