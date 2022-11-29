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
        public ChangePersonalData(Users user)
        {
            InitializeComponent();
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
            
        }
    }
}
