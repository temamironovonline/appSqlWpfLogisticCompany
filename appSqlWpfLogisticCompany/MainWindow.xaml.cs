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
using System.Xml.Linq;

namespace appSqlWpfLogisticCompany
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            DataBaseConnection.LogisticCompanyDB = new LogisticCompanyDB2Entities();
            forFrameClass.publicFrame = MainFraim;
            forFrameClass.publicFrame.Navigate(new RegistrationAuthorizationPage());
            //forFrameClass.publicFrame.Navigate(new addRequestPage());
        }
    }
}
