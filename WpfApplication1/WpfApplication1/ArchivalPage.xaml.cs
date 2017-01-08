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

namespace Tissue_Dashboard
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class ArchivalPage : Page
    {
        public ArchivalPage()
        {
            
        }

        private void Request_Tissue_Button(object sender, RoutedEventArgs e)
        {

            Request_Window tissueRequest = new Request_Window(); //New Request Userform
            tissueRequest.Show();
            Application.Current.MainWindow.Visibility = Visibility.Collapsed; //Hide Main Dashboard
        }
    }
}
