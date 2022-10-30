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

namespace appSqlWpfLogisticCompany.Pages
{
    /// <summary>
    /// Логика взаимодействия для personalAccount.xaml
    /// </summary>
    public partial class personalAccount : Page
    {
        private string emailUser;
        private string loginUser;
        private string passwordUser;
        public personalAccount(string forEmail, string forLogin, string forPassword)
        {
            InitializeComponent();
            emailUser = forEmail;
            loginUser = forLogin;
            passwordUser = forPassword;
        }

        private void completeRegisterButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (surnameTextBox.Text == "") MessageBox.Show("Поле 'Фамилия' не может быть пустым!");
            else if (nameTextBox.Text == "") MessageBox.Show("Поле 'Имя' не может быть пустым!");
            else if (midnameTextBox.Text == "") MessageBox.Show("Поле 'Отчество' не может быть пустым!");
            else if (maleGender.IsChecked == false && femaleGender.IsChecked == false) MessageBox.Show("Выберете пол!");
            else if (maleGender.IsChecked == false && femaleGender.IsChecked == false) MessageBox.Show("Выберете пол!");
            else if (birthdayDataPicker.Text == "") MessageBox.Show("Укажите Дату Рождения!");
            else
            {
                int gender;
                if (maleGender.IsChecked == true) gender = 1;
                else gender = 2;
                Users newUser = new Users()
                {
                    Name_User = nameTextBox.Text,
                    Surname_User = surnameTextBox.Text,
                    Midname_User = midnameTextBox.Text,
                    Login_User = loginUser,
                    Password_User = passwordUser.GetHashCode(),
                    Code_Gender = gender,
                    Date_Birthday_User = birthdayDataPicker.DisplayDate,
                    Code_Role = roleComboBox.SelectedIndex+2,
                    Mail_User = emailUser
                };
                DataBaseConnection.LogisticCompanyDB.Users.Add(newUser);
                DataBaseConnection.LogisticCompanyDB.SaveChanges();
                MessageBox.Show("Здесь будет подтверждение почты, а пока что просто нажмите ОК");
                MessageBox.Show("Пользователь добавлен");
                forFrameClass.publicFrame.Navigate(new RegistrationAuthorizationPage());
            }    
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            forFrameClass.publicFrame.Navigate(new RegistrationPage());
        }
    }
}
