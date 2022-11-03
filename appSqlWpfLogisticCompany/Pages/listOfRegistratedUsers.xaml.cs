using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace appSqlWpfLogisticCompany
{
    /// <summary>
    /// Логика взаимодействия для listOfRegistratedUsers.xaml
    /// </summary>
    public partial class listOfRegistratedUsers : Page
    {
        public listOfRegistratedUsers()
        {
            InitializeComponent();
            registratedUsersDataGrid.ItemsSource = DataBaseConnection.LogisticCompanyDB.Users.ToList();
            sortingBySurnameComboBox.SelectedIndex = 0;
            filterByGenderComboBox.SelectedIndex = 0;
        }

        List<Users> Users = DataBaseConnection.LogisticCompanyDB.Users.ToList();
        Regex regexGender = new Regex(".*");
        Regex regexLogin = new Regex(".*");
        Regex regexSurname = new Regex(".*");

        private void sortingData()
        {
            Users = DataBaseConnection.LogisticCompanyDB.Users.ToList();
            if (sortingBySurnameComboBox.SelectedIndex == 1)
                registratedUsersDataGrid.ItemsSource = Users.Where(x => regexGender.IsMatch(x.Users_Gender.Name_Gender) && regexLogin.IsMatch(x.Login_User) && regexSurname.IsMatch(x.Surname_User)).OrderBy(x => x.Surname_User);

            else if (sortingBySurnameComboBox.SelectedIndex == 2)
                registratedUsersDataGrid.ItemsSource = Users.Where(x => regexGender.IsMatch(x.Users_Gender.Name_Gender) && regexLogin.IsMatch(x.Login_User) && regexSurname.IsMatch(x.Surname_User)).OrderByDescending(x => x.Surname_User);

            else
                registratedUsersDataGrid.ItemsSource = Users.Where(x => regexGender.IsMatch(x.Users_Gender.Name_Gender) && regexLogin.IsMatch(x.Login_User) && regexSurname.IsMatch(x.Surname_User));
        }

        private void sortingBySurnameComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            sortingData();   
        }

        private void filterByGenderComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (filterByGenderComboBox.SelectedIndex == 1)
                regexGender = new Regex("Мужской");

            else if (filterByGenderComboBox.SelectedIndex == 2)
                regexGender = new Regex("Женский");

            else regexGender = new Regex(".*");
            
            sortingData();

        }

        private void searchByLoginTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            regexLogin = new Regex("^" + searchByLoginTextBox.Text);
            sortingData();
        }

        private void searchBySurnameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            regexSurname = new Regex("^" + searchBySurnameTextBox.Text);
            sortingData();
        }

        private void clearButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            sortingBySurnameComboBox.SelectedIndex = 0;
            filterByGenderComboBox.SelectedIndex = 0;
            searchByLoginTextBox.Text = "";
            searchBySurnameTextBox.Text = "";   

            sortingData();
        }

        private void backButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            forFrameClass.publicFrame.Navigate(new administrationMenu());
        }
    }
}
