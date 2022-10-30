using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Xml.Linq;

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
            if (Properties.Settings.Default.languageApp == "ru-RU") languageRussianItem.IsSelected = true;
            else languageEnglishItem.IsSelected = true;
        }

        private void registrationButton_Click(object sender, RoutedEventArgs e) //Переход на страницу регистрации при нажатии на кнопку "Регистрация"
        {
            forFrameClass.publicFrame.Navigate(new RegistrationPage());
        }

        private void loginButton_Click(object sender, RoutedEventArgs e) //Проверка пользователя при нажатии на кнопку "Войти"
        {
         
            int checkPassword = userPasswordPasswordBox.Password.GetHashCode();
            if(userLoginTextBox.Text == Properties.Languages.Language.textLogin || userPasswordPasswordBox.Password.ToString() == "") //Проверка на пустые поля "Логин" и "Пароль"
            {
                if (userLoginTextBox.Text == Properties.Languages.Language.textLogin) //Показываем ошибку пустого логина
                {
                    emptyLogin.Visibility = Visibility.Visible;
                    passwordPanel.Margin = new Thickness(0, 20, 0, 0);
                }
                if (userPasswordPasswordBox.Password.ToString() == "") //Показываем ошибку пустого пароля
                {
                    emptyPassword.Visibility = Visibility.Visible; 
                    loginButton.Margin = new Thickness(0, 20, 0, 0);
                }
                
            }
            else 
            {
                Users registratedUser = DataBaseConnection.LogisticCompanyDB.Users.FirstOrDefault(z => z.Login_User == userLoginTextBox.Text && z.Password_User == checkPassword);
                if (registratedUser == null) //Если пользователя не существует (или неверные введенные данные)
                {
                    wrongLoginPassword.Visibility = Visibility.Visible; //Показываем ошибку неверных данных
                    wrongLoginPassword.Margin = new Thickness(0, 20, 0, 0);
                    loginButton.Margin = new Thickness(0, 20, 0, 0);
                }
                else
                {
                    if (registratedUser.Code_Role == 2)
                    {
                        MessageBox.Show("Добро пожаловать!");
                    }
                    else
                    {
                        forFrameClass.publicFrame.Navigate(new administrationMenu());
                    }

                }
            }
            
        }

        private void userLoginTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (wrongLoginPassword.Visibility == Visibility.Visible) //Если ошибка неверных данных включена, то отключаем
            {
                wrongLoginPassword.Visibility = Visibility.Collapsed;
                loginButton.Margin = new Thickness(0, 40, 0, 0);
            }
            if (emptyLogin.Visibility == Visibility.Visible) //Если ошибка пустого логина видна, то отключаем
            {
                emptyLogin.Visibility = Visibility.Collapsed;
                passwordPanel.Margin = new Thickness(0, 35, 0, 0);
            }
            var brushConverter = new BrushConverter();
            if (userLoginTextBox.Text == Properties.Languages.Language.textLogin) userLoginTextBox.Text = "";
            userLoginTextBox.Foreground = (Brush)brushConverter.ConvertFrom("#FF6F97EE");
            polylineLogin.Stroke = (Brush)brushConverter.ConvertFrom("#FF6F97EE");
            userLoginIcon.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/userloginBlue.png"));
        }


        private void userLoginTextBox_LostFocus(object sender, RoutedEventArgs e) //Событие при потере фокуса с поля ввода логина
        {
            var brushConverter = new BrushConverter();
            if (userLoginTextBox.Text == "") userLoginTextBox.Text = Properties.Languages.Language.textLogin;
            userLoginTextBox.Foreground = (Brush)brushConverter.ConvertFrom("#C7C9C7");
            polylineLogin.Stroke = (Brush)brushConverter.ConvertFrom("#C7C9C7");
            userLoginIcon.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/userlogin.png"));
        }

        private void userPasswordTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (emptyPassword.Visibility == Visibility.Visible) //Если ошибка пустого пароля видна, то отключаем
            {
                emptyPassword.Visibility = Visibility.Collapsed;
                loginButton.Margin = new Thickness(0, 40, 0, 0);
            }
            var brushConverter = new BrushConverter();
            userPasswordTextBox.Visibility = Visibility.Collapsed;
            userPasswordPasswordBox.Visibility = Visibility.Visible;
            userPasswordPasswordBox.Focus();
            userPasswordTextBox.Foreground = (Brush)brushConverter.ConvertFrom("#FF6F97EE");
            polylinePassword.Stroke = (Brush)brushConverter.ConvertFrom("#FF6F97EE");
            userPasswordIcon.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/passwordloginBlue.png"));
        }

        private void userPasswordPasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (wrongLoginPassword.Visibility == Visibility.Visible) //Если ошибка неверных данных включена, то отключаем
            {
                wrongLoginPassword.Visibility = Visibility.Collapsed;
                loginButton.Margin = new Thickness(0, 40, 0, 0);
            }
            var brushConverter = new BrushConverter();
            polylinePassword.Stroke = (Brush)brushConverter.ConvertFrom("#FF6F97EE");
            userPasswordIcon.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/passwordloginBlue.png"));
        }

        private void userPasswordPasswordBox_LostFocus(object sender, RoutedEventArgs e) //Событие при потере фокуса с поля ввода логина
        {
            var brushConverter = new BrushConverter();
            if (userPasswordPasswordBox.Password.ToString() == "")
            {
                userPasswordPasswordBox.Visibility = Visibility.Collapsed;
                userPasswordTextBox.Visibility = Visibility.Visible;
            }
            userPasswordTextBox.Foreground = (Brush)brushConverter.ConvertFrom("#C7C9C7");
            polylinePassword.Stroke = (Brush)brushConverter.ConvertFrom("#C7C9C7");
            userPasswordIcon.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/passwordlogin.png"));
        }


        private void languageComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((languageComboBox.SelectedIndex == 0 && Properties.Settings.Default.languageApp != "ru-RU") || (languageComboBox.SelectedIndex == 1 && Properties.Settings.Default.languageApp != "en-EN"))
            {
                //MessageBox.Show("Для применения изменений необходимо перезапустить приложение");
                if (languageComboBox.SelectedIndex == 0) Properties.Settings.Default.languageApp = "ru-RU";
                else Properties.Settings.Default.languageApp = "en-EN";
                Properties.Settings.Default.Save();
                var langCode = appSqlWpfLogisticCompany.Properties.Settings.Default.languageApp;
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(langCode);
                forFrameClass.publicFrame.Navigate(new RegistrationAuthorizationPage());
            }
            
            
        }

    }
}
