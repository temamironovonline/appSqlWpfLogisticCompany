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
using System.Windows.Shapes;

namespace appSqlWpfLogisticCompany
{
    /// <summary>
    /// Логика взаимодействия для ChangePersonalData.xaml
    /// </summary>
    public partial class ChangePersonalData : Window
    {
        Users user;
        public ChangePersonalData(Users user)
        {
            InitializeComponent();
            this.user = user;
            surnameTextBox.Text = user.Surname_User;
            nameTextBox.Text = user.Name_User;
            midnameTextBox.Text = user.Midname_User;
            if (user.Code_Gender == 1) 
                maleGender.IsChecked = true;
            else femaleGender.IsChecked = true;
            birthdayDataPicker.SelectedDate = user.Date_Birthday_User;
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void completeUpdateButton_Click(object sender, RoutedEventArgs e)
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
                user.Name_User = nameTextBox.Text;
                user.Surname_User = surnameTextBox.Text;
                user.Midname_User = midnameTextBox.Text;
                user.Code_Gender = gender;
                user.Date_Birthday_User = birthdayDataPicker.DisplayDate;
                user.Code_Role = roleComboBox.SelectedIndex + 2;
               
                DataBaseConnection.LogisticCompanyDB.SaveChanges();
                MessageBox.Show("Пользователь изменен");
                this.Close();
            }
        }
    }
}
