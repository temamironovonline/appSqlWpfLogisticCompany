using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace appSqlWpfLogisticCompany
{
    /// <summary>
    /// Логика взаимодействия для RequestsPage.xaml
    /// </summary>
    public partial class RequestsPage : Page
    {
        PaginationRequest paginationRequest = new PaginationRequest();
        List<Requests> requests = new List<Requests>();
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

            requests = DataBaseConnection.LogisticCompanyDB.Requests.ToList();
            listRequests.ItemsSource = DataBaseConnection.LogisticCompanyDB.Requests.ToList();
            int count = DataBaseConnection.LogisticCompanyDB.Requests.Count(x => x.Date_Request.Month == DateTime.Now.Month && x.Date_Request.Year == DateTime.Now.Year);
            countRequest.Text = Convert.ToString(count);

            paginationRequest.CountPage = DataBaseConnection.LogisticCompanyDB.Requests.ToList().Count;
            DataContext = paginationRequest;
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

        private void txtPageCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                paginationRequest.CountPage = Convert.ToInt32(txtPageCount.Text); // если в текстовом поле есnь значение, присваиваем его свойству объекта, которое хранит количество записей на странице
            }
            catch
            {
                paginationRequest.CountPage = requests.Count; // если в текстовом поле значения нет, присваиваем свойству объекта, которое хранит количество записей на странице количество элементов в списке
            }
            paginationRequest.Countlist = requests.Count;  // присваиваем новое значение свойству, которое в объекте отвечает за общее количество записей
            listRequests.ItemsSource = requests.Skip(0).Take(paginationRequest.CountPage).ToList();  // отображаем первые записи в том количестве, которое равно CountPage
            paginationRequest.CurrentPage = 1; // текущая страница - это страница 1
        }

        private void GoPage_MouseDown(object sender, MouseButtonEventArgs e)  // обработка нажатия на один из Textblock в меню с номерами страниц
        {
            TextBlock tb = (TextBlock)sender;

            switch (tb.Uid)  // определяем, куда конкретно было сделано нажатие
            {
                case "prev":
                    paginationRequest.CurrentPage--;
                    break;
                case "next":
                    paginationRequest.CurrentPage++;
                    break;
                default:
                    paginationRequest.CurrentPage = Convert.ToInt32(tb.Text);
                    break;
            }
            listRequests.ItemsSource = requests.Skip(paginationRequest.CurrentPage * paginationRequest.CountPage - paginationRequest.CountPage).Take(paginationRequest.CountPage).ToList();  // оображение записей постранично с определенным количеством на каждой странице
            // Skip(pc.CurrentPage* pc.CountPage - pc.CountPage) - сколько пропускаем записей
            // Take(pc.CountPage) - сколько записей отображаем на странице
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            paginationRequest.CurrentPage = 1;

            try
            {
                paginationRequest.CountPage = Convert.ToInt32(txtPageCount.Text); // если в текстовом поле есnь значение, присваиваем его свойству объекта, которое хранит количество записей на странице
            }
            catch
            {
                paginationRequest.CountPage = requests.Count; // если в текстовом поле значения нет, присваиваем свойству объекта, которое хранит количество записей на странице количество элементов в списке
            }
            paginationRequest.Countlist = requests.Count;  // присваиваем новое значение свойству, которое в объекте отвечает за общее количество записей
            listRequests.ItemsSource = requests.Skip(0).Take(paginationRequest.CountPage).ToList();  // отображаем первые записи в том количестве, которое равно CountPage
        }
    }
}
