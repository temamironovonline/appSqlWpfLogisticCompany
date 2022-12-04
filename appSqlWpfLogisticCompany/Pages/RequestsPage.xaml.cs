using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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

            sortingComboBox.SelectedIndex = 0;
            typeSortingComboBox.SelectedIndex = 0;
            typeSortingPanel.Visibility = Visibility.Collapsed;

            
            
            List <Executors> executorsList = DataBaseConnection.LogisticCompanyDB.Executors.ToList();
            executorsComboBox.Items.Add("Не выбрано");
            foreach(Executors executor in executorsList)
            {
                executorsComboBox.Items.Add($"{executor.Surname_Executor} {executor.Name_Executor} {executor.Midname_Executor}");
            }
            executorsComboBox.SelectedIndex = 0;

            listRequests.ItemsSource = DataBaseConnection.LogisticCompanyDB.Requests.ToList();
            int count = DataBaseConnection.LogisticCompanyDB.Requests.Count(x => x.Date_Request.Month == DateTime.Now.Month && x.Date_Request.Year == DateTime.Now.Year);
            countRequest.Text = Convert.ToString(count);
        }

        private void filtrationInformation()
        {
            List<Requests> requestsList;
            
            if(executorsComboBox.SelectedIndex > 0)
            {
                requestsList = DataBaseConnection.LogisticCompanyDB.Requests.Where(x => x.Code_Executor == executorsComboBox.SelectedIndex).ToList();
            }
            else
            {
                requestsList = DataBaseConnection.LogisticCompanyDB.Requests.ToList();
            }

            Regex regexCityLoading = new Regex($@".*{loadingCityTextBox.Text.ToLower()}.*");
            Regex regexCityUnoading = new Regex($@".*{unloadingCityTextBox.Text.ToLower()}.*");

            requestsList = requestsList.Where(x => regexCityLoading.IsMatch(x.Place_Loading.ToLower()) && regexCityUnoading.IsMatch(x.Place_Unloading.ToLower())).ToList();

            if (closedRequestCheckBox.IsChecked == true)
            {
                requestsList = requestsList.Where(x => x.Request_Status == "Закрыта").ToList();
            }

            if (sortingComboBox.SelectedIndex == 1)
            {
                if (typeSortingComboBox.SelectedIndex == 1)
                {
                    requestsList = requestsList.OrderBy(x => x.Amount_Payment).ToList();
                }
                else if (typeSortingComboBox.SelectedIndex == 2)
                {
                    requestsList = requestsList.OrderByDescending(x => x.Amount_Payment).ToList();
                }
            }
            else if (sortingComboBox.SelectedIndex == 2)
            {
                if (typeSortingComboBox.SelectedIndex == 1)
                {
                    requestsList = requestsList.OrderBy(x => x.Route_Towns).ToList();
                }
                else if (typeSortingComboBox.SelectedIndex == 2)
                {
                    requestsList = requestsList.OrderByDescending(x => x.Route_Towns).ToList();
                }
            }
            else if (sortingComboBox.SelectedIndex == 3)
            {
                if (typeSortingComboBox.SelectedIndex == 1)
                {
                    requestsList = requestsList.OrderBy(x => x.Date_Request).ToList();
                }
                else if (typeSortingComboBox.SelectedIndex == 2)
                {
                    requestsList = requestsList.OrderByDescending(x => x.Date_Request).ToList();
                }
            }

            listRequests.ItemsSource = requestsList;
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            forFrameClass.publicFrame.Navigate(new administrationMenu());
        }

        private void createRequestButton_Click(object sender, RoutedEventArgs e)
        {
            forFrameClass.publicFrame.Navigate(new addRequestPage());
        }

        private void loadingCityTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            filtrationInformation();
        }

        private void unloadingCityTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            filtrationInformation();
        }

        private void executorsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            filtrationInformation();
        }

        private void closedRequestCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            filtrationInformation();
        }

        private void sortingComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sortingComboBox.SelectedIndex > 0)
            {
                typeSortingPanel.Visibility = Visibility.Visible;
            }
            else
            {
                typeSortingPanel.Visibility = Visibility.Collapsed;
            }
            filtrationInformation();
        }

        private void typeSortingComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            filtrationInformation();
        }
    }
}
