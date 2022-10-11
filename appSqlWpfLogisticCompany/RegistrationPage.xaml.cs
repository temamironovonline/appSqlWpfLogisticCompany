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
            int genderId = genderCB.SelectedIndex + 1;
            int roleId = roleCB.SelectedIndex + 1;


            Users RegistrationUser = new Users()
            {
                Name_User = nameUserRegistrationTB.Text,
                Surname_User = surnameUserRegistrationTB.Text,
                Midname_User = midnameUserRegistrationTB.Text,
                Login_User = loginUserRegistrationTB.Text,
                Code_Gender = genderId,

            }
        }
    }
}
