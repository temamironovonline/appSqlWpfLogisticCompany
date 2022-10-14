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
            genderCB.ItemsSource = DataBaseConnection.LogisticCompanyDB.Users_Gender.ToList();
            genderCB.SelectedValuePath = "Code_Gender";
            genderCB.DisplayMemberPath = "Name_Gender";

            roleCB.ItemsSource = DataBaseConnection.LogisticCompanyDB.Users_Roles.ToList();
            roleCB.SelectedValuePath = "Code_Role";
            roleCB.DisplayMemberPath = "Name_Role";
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            forFrameClass.publicFrame.Navigate(new RegistrationAuthorizationPage());
            


            

            
        }

        private void registrationButton_Click(object sender, RoutedEventArgs e)
        {
            //(?=.*[0-9]{2,})(?=.*[!@#$%^&*]{1,})(?=.*[a-z]{3,})(?=.*[A-Z]{1,})[0-9a-zA-Z!@#$%^&*]{8,}

            // https://www.codeproject.com/Articles/14537/The-Art-Science-of-Storing-Passwords
            int genderId = genderCB.SelectedIndex + 1;
            int roleId = roleCB.SelectedIndex + 1;
            Regex checkPassword = new Regex("(?=.*[0-9]{2,})(?=.*[!@#$%^&*]{1,})(?=.*[a-z]{3,})(?=.*[A-Z]{1,})[0-9a-zA-Z!@#$%^&*]{8,}");
            string password = passwordUserRegistrationTB.Text;

            if (checkPassword.IsMatch(password))
            {
                int passwordForSql = Convert.ToInt32(passwordUserRegistrationTB.GetHashCode().ToString());
                Users RegistrationUser = new Users()
                {

                    Name_User = nameUserRegistrationTB.Text,
                    Surname_User = surnameUserRegistrationTB.Text,
                    Midname_User = midnameUserRegistrationTB.Text,
                    Login_User = loginUserRegistrationTB.Text,
                    Password_User = Convert.ToInt32(passwordUserRegistrationTB.GetHashCode().ToString()),
                    Code_Gender = genderId,
                    Date_Birthday_User = Convert.ToDateTime(userBirthdayRegistrationDP),
                    Code_Role = roleId,
                };
                DataBaseConnection.LogisticCompanyDB.Users.Add(RegistrationUser);
                DataBaseConnection.LogisticCompanyDB.SaveChanges();
                MessageBox.Show("Пользователь добавлен");

            }
            else
            {
                MessageBox.Show("Ахтунг");
            }
        }
    }
}
