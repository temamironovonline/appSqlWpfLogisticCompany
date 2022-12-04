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
        Users user;
        public administrationMenu()
        {
            InitializeComponent();
        }
        public administrationMenu(Users user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void buttonViewRegistratedUsers_Click(object sender, RoutedEventArgs e)
        {
            forFrameClass.publicFrame.Navigate(new listOfRegistratedUsers());
        }

        private void buttonViewRequests_Click(object sender, RoutedEventArgs e)
        {
            forFrameClass.publicFrame.Navigate(new RequestsPage());
        }

        private void buttonViewExecutors_Click(object sender, RoutedEventArgs e)
        {
            forFrameClass.publicFrame.Navigate(new listOfExecutors());
        }

        private void buttonPersonalAccount_Click(object sender, RoutedEventArgs e)
        {
            forFrameClass.publicFrame.Navigate(new PersonalAccountView(user));
        }
    }
}
