using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();

            roleCB.ItemsSource = DataBaseConnection.LogisticCompanyDB.Users_Roles.ToList();
            roleCB.SelectedValuePath = "Code_Role";
            roleCB.DisplayMemberPath = "Name_Role";

            roleCB.SelectedIndex = 1;
            roleCB.IsEnabled = false;
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            forFrameClass.publicFrame.Navigate(new RegistrationAuthorizationPage());
        }

        private void registrationButton_Click(object sender, RoutedEventArgs e)
        {
            //(?=.*[0-9]{2,})(?=.*[!@#$%^&*]{1,})(?=.*[a-z]{3,})(?=.*[A-Z]{1,})[0-9a-zA-Z!@#$%^&*]{8,}

            // https://www.codeproject.com/Articles/14537/The-Art-Science-of-Storing-Passwords
            int roleId = roleCB.SelectedIndex + 1;
            Regex checkPassword = new Regex("(?=.*[0-9]{2,})(?=.*[!@#$%^&*]{1,})(?=.*[a-z]{3,})(?=.*[A-Z]{1,})[0-9a-zA-Z!@#$%^&*]{8,}");
            string password = passwordUserRegistrationTB.Text;

            if (nameUserRegistrationTB.Text == "") MessageBox.Show("Поле \"Имя\" не может быть пустым!");
            else if (surnameUserRegistrationTB.Text == "") MessageBox.Show("Поле \"Фамилия\" не может быть пустым!");
            else if (midnameUserRegistrationTB.Text == "") MessageBox.Show("Поле \"Отчество\" не может быть пустым!");
            else if (loginUserRegistrationTB.Text == "") MessageBox.Show("Поле \"Логин\" не может быть пустым!");
            else if (genderRBFemale.IsChecked == false && genderRBMale.IsChecked == false) MessageBox.Show("Выберете пол!");
            else if (userBirthdayRegistrationDP.ToString() == "") MessageBox.Show("Укажите дату рождения!");
            
            int genderId;
            if (genderRBMale.IsChecked == false) genderId = 2;
            else genderId = 1;
            if (checkPassword.IsMatch(password))
            {
                Users RegistrationUser = new Users()
                {

                    Name_User = nameUserRegistrationTB.Text,
                    Surname_User = surnameUserRegistrationTB.Text,
                    Midname_User = midnameUserRegistrationTB.Text,
                    Login_User = loginUserRegistrationTB.Text,
                    Password_User = Convert.ToInt32(passwordUserRegistrationTB.GetHashCode().ToString()),
                    Code_Gender = genderId,
                    Date_Birthday_User = userBirthdayRegistrationDP.DisplayDate,
                    Code_Role = roleId,
                };
                DataBaseConnection.LogisticCompanyDB.Users.Add(RegistrationUser);
                DataBaseConnection.LogisticCompanyDB.SaveChanges();
                MessageBox.Show("Пользователь добавлен");
                forFrameClass.publicFrame.Navigate(new RegistrationAuthorizationPage());
                

            }
            else
            {
                MessageBox.Show("Ахтунг");
            }
        }
    }
}
