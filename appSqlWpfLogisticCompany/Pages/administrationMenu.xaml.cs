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

namespace appSqlWpfLogisticCompany
{
    /// <summary>
    /// Логика взаимодействия для administrationMenu.xaml
    /// </summary>
    public partial class administrationMenu : Page
    {
        public administrationMenu()
        {
            InitializeComponent();
        }

        private void buttonViewRegistratedUsers_Click(object sender, RoutedEventArgs e)
        {
            forFrameClass.publicFrame.Navigate(new listOfRegistratedUsers());
        }
    }
}
