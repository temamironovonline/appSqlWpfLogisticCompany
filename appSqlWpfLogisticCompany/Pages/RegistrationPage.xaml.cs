using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;


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

            // https://www.codeproject.com/Articles/14537/The-Art-Science-of-Storing-Passwords

            int roleId = roleCB.SelectedIndex + 1;
            int genderId = 0;
            Regex checkPassword = new Regex("(?=.*[0-9]{2,})(?=.*[!@#$%^&*]{1,})(?=.*[a-z]{3,})(?=.*[A-Z]{1,})[0-9a-zA-Z!@#$%^&*]{8,}");
            string password = passwordUserRegistrationTB.Password;

            if (nameUserRegistrationTB.Text == "") MessageBox.Show("Поле \"Имя\" не может быть пустым!");

            else if (surnameUserRegistrationTB.Text == "") MessageBox.Show("Поле \"Фамилия\" не может быть пустым!");

            else if (midnameUserRegistrationTB.Text == "") MessageBox.Show("Поле \"Отчество\" не может быть пустым!");

            else if (loginUserRegistrationTB.Text == "") MessageBox.Show("Поле \"Логин\" не может быть пустым!");

            else if (genderRBFemale.IsChecked == false && genderRBMale.IsChecked == false) MessageBox.Show("Выберете пол!");

            else if (userBirthdayRegistrationDP.ToString() == "") MessageBox.Show("Укажите дату рождения!");

            else if (!checkPassword.IsMatch(password))
            {
                //РЕДАКТИРОВАТЬ. ВСТАВИТЬ БЛОК ТЕКСТА В РАЗМЕТКУ, В КОТОРОМ БУДЕТ ОПИСАНО ПРАВИЛО ВВОДА ПАРОЛЯ!
                //ВЫДАВАТЬ СООТВЕТСТВУЮЩУЮ ОШИБКУ
                MessageBox.Show("Ахтунг");
            }
            else
            {

                Users registratedUser = DataBaseConnection.LogisticCompanyDB.Users.FirstOrDefault(z => z.Login_User == loginUserRegistrationTB.Text);
                if (registratedUser == null)
                {
                    if (genderRBMale.IsChecked == false) genderId = 2;
                    else genderId = 1;

                    Users RegistrationUser = new Users()
                    {

                        Name_User = nameUserRegistrationTB.Text,
                        Surname_User = surnameUserRegistrationTB.Text,
                        Midname_User = midnameUserRegistrationTB.Text,
                        Login_User = loginUserRegistrationTB.Text,
                        Password_User = Convert.ToInt32(passwordUserRegistrationTB.Password.GetHashCode().ToString()),
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
                    MessageBox.Show("Пользователь с таким логином уже зарегистрирован!");
                } 
            }
        }
    }
}
