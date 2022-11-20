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
    /// Логика взаимодействия для listOfExecutors.xaml
    /// </summary>
    public partial class listOfExecutors : Page
    {
        public listOfExecutors()
        {
            InitializeComponent();
            listExecutors.ItemsSource = DataBaseConnection.LogisticCompanyDB.Executors.ToList();
            int count = DataBaseConnection.LogisticCompanyDB.Requests.Count(x => x.Drivers.Code_Executor == x.Code_Executor);
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            forFrameClass.publicFrame.Navigate(new administrationMenu());
        }

        private void addExecutor_Click(object sender, RoutedEventArgs e)
        {
            forFrameClass.publicFrame.Navigate(new addExecutor());
        }

        private void deleteExecutorButton_Click(object sender, RoutedEventArgs e)
        {
            Button buttonDelete = (Button)sender;
            int index = Convert.ToInt32(buttonDelete.Uid);
            Executors executors = DataBaseConnection.LogisticCompanyDB.Executors.FirstOrDefault(x => x.Code_Executor == index);
            DataBaseConnection.LogisticCompanyDB.Executors.Remove(executors);
            DataBaseConnection.LogisticCompanyDB.SaveChanges();
            forFrameClass.publicFrame.Navigate(new listOfExecutors());

        }

        private void updateExecutorButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
