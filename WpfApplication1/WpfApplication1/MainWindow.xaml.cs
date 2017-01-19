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

//Main Functions and Objects
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();
            TheTracker.TissueTracker.ExcelStartup();
            this.Closed += new EventHandler(MainWindow_Closed); //This is an event used to save and close excel
            MouseDown += Window_MouseDown;

        }

        
    }

//Events handled in Main
    public partial class MainWindow : Window
    {
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        private void Back_Button(object sender, MouseButtonEventArgs e)
        {
            if (BrowserMain.NavigationService.CanGoBack)
            {
                BrowserMain.NavigationService.GoBack();
            }
        }

        private void Main_Frame_MouseClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("You clicked on Main");
            BrowserMain.Source = new Uri("MainPage.xaml", UriKind.RelativeOrAbsolute);
        }

        private void Archival_Frame_MouseClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("You clicked on Archival");
            BrowserMain.Source = new Uri("ArchivalPage.xaml", UriKind.RelativeOrAbsolute);
        }

        private void Fresh_Frame_MouseClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("You clicked on Fresh");
            BrowserMain.Source = new Uri("FreshPage.xaml", UriKind.RelativeOrAbsolute);
        }

        private void Reports_Frame_MouseClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("You clicked on Reports");
            BrowserMain.Source = new Uri("ReportsPage.xaml", UriKind.RelativeOrAbsolute);
        }


        void MainWindow_Closed(object sender, EventArgs e) //Called in MainWindow()
        {
            TheTracker.TissueTracker.oWB.Save(); //if you don't save. Throws exception
            TheTracker.TissueTracker.oWB.Close(0);
            TheTracker.TissueTracker.oXL.Quit();
        }
    }

//Excel Instance Class
    internal class TheTracker
    {
        
        public string myWorkbook { get; set; }
        public Excel.Application oXL { get; set; }
        public Excel.Workbook oWB { get; set; }
        public Excel.Worksheets oWS { get; set; } //This is a collection
        public Excel.Range oRng { get; set; }
        public Excel._Worksheet oSheet { get; set; }
        public Excel.Worksheet archivalTracker { get; private set; } //Worksheet object        
        public Excel.Worksheet freshTracker { get; private set; } //Worksheet object
        public Excel.Worksheet sourceTracker { get; private set; } //Worksheet object
        private static TheTracker Tissuetracker = new TheTracker();
        private TheTracker() { }

        internal static TheTracker TissueTracker //This verifies we have only one instantiated TissueTracker class and assignments.
        {
            get
            {
                if (Tissuetracker == null)
                    Tissuetracker = new TheTracker();

                return Tissuetracker;
            }
        }

        internal void ExcelStartup()
        {
            oXL = new Excel.Application();
            
            myWorkbook = @"C:\Users\Zach\Desktop\New1.xlsx";
            if (Environment.UserName == "LZU7764")
                myWorkbook = @"C:\Users\LZU7764\Desktop\New.xlsx";

            oWB = oXL.Workbooks.Open(myWorkbook);


            //Set sheets by index. Show Excel workbook that we opened above
            archivalTracker = oWB.Worksheets[1];
            freshTracker = oWB.Worksheets[2];
            sourceTracker = oWB.Worksheets[3];
            oXL.Visible = true;
            oXL.UserControl = true;
        }
    }
}




//Attempting to detect and hook to an opened workbook to either close the previous one or read/write from it.
/*bool wbOpened = ((Excel.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application")).Workbooks.Cast<Excel.Workbook>().FirstOrDefault(x => x.Name == myWorkbook) != null;
if (wbOpened == false)
    oWB = oXL.Workbooks.Open(myWorkbook);
else
{
    MessageBox.Show("Please close the tracker before continuing.", "Close the tracker!", MessageBoxButton.OK, MessageBoxImage.Error);
    Environment.Exit(0);





How do I append an extension variable to each object?
Goal: TissueTracker.archivalTracker.PatientName = [rowx, 1]
If I can append the variable, I can use a method to pass the values needed in. Research needed.

public Excel.Worksheet archivalTracker
{
get

{

    Excel.Range PatientName = this.oRng.Cells[3, 1].value;
    Excel.Range AccessionText = this.oRng.Cells[3, 2].value;
    Excel.Range RequestorText = this.oRng.Cells[3, 3].value;
    Excel.Range PhysicianText = this.oRng.Cells[3, 4].value;
    Excel.Range EnrollmentText = this.oRng.Cells[3, 5].value;
    Excel.Range DateofBirthText = this.oRng.Cells[3, 6].value;

    if (something == oWB.Worksheets[1])
        return something;
    else
        return oWB.Worksheets[1].something;
}



private set
{
    something = value;
}

} 

}*/
