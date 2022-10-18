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
    /// Логика взаимодействия для RegistrationAuthorizationPage.xaml
    /// </summary>
    public partial class RegistrationAuthorizationPage : Page
    {
        public RegistrationAuthorizationPage()
        {
            InitializeComponent();
        }

      

        private void registrationButton_Click(object sender, RoutedEventArgs e)
        {
            forFrameClass.publicFrame.Navigate(new RegistrationPage());
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            int checkPassword = userPasswordPB.Password.GetHashCode();
            Users registratedUser = DataBaseConnection.LogisticCompanyDB.Users.FirstOrDefault(z => z.Login_User == userLoginTB.Text && z.Password_User == checkPassword);
            if (registratedUser == null)
            {
                MessageBox.Show("Неверный логин или пароль");
            }
            else
            {
                if (registratedUser.Code_Role == 2)
                {
                    MessageBox.Show("Добро пожаловать!");
                }
                else
                {
                    MessageBox.Show("Добро пожаловать, Господин!");
                }

            }
        }
    }
}
