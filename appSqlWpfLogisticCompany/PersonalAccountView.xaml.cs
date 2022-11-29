using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace appSqlWpfLogisticCompany
{
    /// <summary>
    /// Логика взаимодействия для PersonalAccountView.xaml
    /// </summary>
    public partial class PersonalAccountView : Page
    {
        Users user;
        public PersonalAccountView(Users user)
        {
            InitializeComponent();
            this.user = user;
            surnameUser.Text = user.Surname_User;
            nameUser.Text = user.Name_User;
            midnameUser.Text = user.Midname_User;
            Users_Gender gender = DataBaseConnection.LogisticCompanyDB.Users_Gender.FirstOrDefault(x => x.Code_Gender == user.Code_Gender);
            genderUser.Text = gender.Name_Gender;
            birthdayUser.Text = Convert.ToString(user.Date_Birthday_User.Date.ToShortDateString());
            Users_Roles role = DataBaseConnection.LogisticCompanyDB.Users_Roles.FirstOrDefault(x => x.Code_Role == user.Code_Role);
            roleUser.Text = role.Name_Role;
            mailUser.Text = user.Mail_User;
        }

        private void updateButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ChangePersonalData cpd = new ChangePersonalData(user);
            cpd.ShowDialog();
        }
    }
}
