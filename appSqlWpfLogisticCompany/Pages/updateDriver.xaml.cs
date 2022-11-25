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
    /// Логика взаимодействия для updateDriver.xaml
    /// </summary>
    public partial class updateDriver : Page
    {
        public updateDriver()
        {
            InitializeComponent();
        }

        Drivers driver;
        Executors executor;

        public updateDriver(Drivers driver, Executors executor)
        {
            InitializeComponent();
            this.driver = driver;
            this.executor = executor;
            surnameDriverTextBox.Text = driver.Surname_Driver;
            nameDriverTextBox.Text = driver.Surname_Driver;
            midnameDriverTextBox.Text = driver.Midname_Driver;
            telephoneDriverTextBox.Text = driver.Telephone_Driver;
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            if (surnameDriverTextBox.Text == "" || nameDriverTextBox.Text == "" || midnameDriverTextBox.Text == "" || telephoneDriverTextBox.Text == "")
                MessageBox.Show("Есть пустые поля", "Обидненько, да?))))");
            else
            {
                driver.Surname_Driver = surnameDriverTextBox.Text;
                driver.Name_Driver = nameDriverTextBox.Text;
                driver.Midname_Driver = midnameDriverTextBox.Text;
                driver.Telephone_Driver = telephoneDriverTextBox.Text;

                DataBaseConnection.LogisticCompanyDB.SaveChanges();
                forFrameClass.publicFrame.Navigate(new addExecutor(executor));
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            forFrameClass.publicFrame.Navigate(new addExecutor(executor));
        }
    }
}
