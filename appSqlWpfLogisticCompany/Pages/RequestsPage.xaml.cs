using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace appSqlWpfLogisticCompany
{
    /// <summary>
    /// Логика взаимодействия для RequestsPage.xaml
    /// </summary>
    public partial class RequestsPage : Page
    {
        public RequestsPage()
        {
            InitializeComponent();
            listRequests.ItemsSource = DataBaseConnection.LogisticCompanyDB.Requests.ToList();
            int count = DataBaseConnection.LogisticCompanyDB.Requests.Count(x => x.Date_Request.Month == DateTime.Now.Month && x.Date_Request.Year == DateTime.Now.Year);
            countRequest.Text = Convert.ToString(count);
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            forFrameClass.publicFrame.Navigate(new administrationMenu());
        }

        private void createRequestButton_Click(object sender, RoutedEventArgs e)
        {
            forFrameClass.publicFrame.Navigate(new addRequestPage());
        }
    }
}
