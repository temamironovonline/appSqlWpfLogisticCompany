using appSqlWpfLogisticCompany.Pages;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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
        }

        private void userEmailTextBox_GotFocus(object sender, RoutedEventArgs e) //При фокусе на поле почты
        {
            if(existingUserMailTextBox.Visibility == Visibility.Visible) //Если видна ошибка существующего пользователя
            {
                existingUserMailTextBox.Visibility = Visibility.Collapsed;
                registerButton.Margin = new Thickness(0, 30, 0, 0);
            }
            if (errorEmail.Visibility == Visibility.Visible) //Если видна ошибка неправильно введенной почты
            {
                errorEmail.Visibility = Visibility.Collapsed;
                loginPanel.Margin = new Thickness(0, 30, 0, 0);
            }
            if (emptyEmail.Visibility == Visibility.Visible) //Если видна ошибка пустой почты
            {
                emptyEmail.Visibility = Visibility.Collapsed;
                loginPanel.Margin = new Thickness(0, 30, 0, 0);
            }

            if (userEmailTextBox.Text == Properties.Languages.Language.textEmail) userEmailTextBox.Text = "";
            var brushConverter = new BrushConverter();
            userEmailTextBox.Foreground = (Brush)brushConverter.ConvertFrom("#FF6F97EE");
            polylineEmail.Stroke = (Brush)brushConverter.ConvertFrom("#FF6F97EE");
            userEmailIcon.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/emailUserBlue.png"));
        }

        private void userEmailTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (userEmailTextBox.Text == "") userEmailTextBox.Text = Properties.Languages.Language.textEmail;
            var brushConverter = new BrushConverter();
            userEmailTextBox.Foreground = (Brush)brushConverter.ConvertFrom("#C7C9C7");
            polylineEmail.Stroke = (Brush)brushConverter.ConvertFrom("#C7C9C7");
            userEmailIcon.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/emailUserGray.png"));

        }

        private void userLoginTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (existingUserLoginTextBox.Visibility == Visibility.Visible) //Если видна ошибка существующего пользователя
            {
                existingUserLoginTextBox.Visibility = Visibility.Collapsed;
                registerButton.Margin = new Thickness(0, 30, 0, 0);
            }

            if (emptyLogin.Visibility == Visibility.Visible) //Если ошибка пустого логина видна, то отключаем
            {
                emptyLogin.Visibility = Visibility.Collapsed;
                passwordPanel.Margin = new Thickness(0, 30, 0, 0);
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
                registerButton.Margin = new Thickness(0, 30, 0, 0);
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
           
            if (errorPassword.Visibility == Visibility.Visible) //Если ошибка неверных данных включена, то отключаем
            {
                errorPassword.Visibility = Visibility.Collapsed;
                registerButton.Margin = new Thickness(0, 30, 0, 0);
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

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            if (errorPassword.Visibility == Visibility.Visible)
            {
                errorPassword.Visibility = Visibility.Collapsed;
                registerButton.Margin = new Thickness(0, 30, 0, 0);
            }
            if (errorEmail.Visibility == Visibility.Visible)
            {
                errorEmail.Visibility = Visibility.Collapsed;
                registerButton.Margin = new Thickness(0, 30, 0, 0);
            }
            if(existingUserLoginTextBox.Visibility == Visibility.Visible)
            {
                existingUserLoginTextBox.Visibility = Visibility.Collapsed;
                registerButton.Margin = new Thickness(0, 30, 0, 0);
            }
            if (existingUserMailTextBox.Visibility == Visibility.Visible)
            {
                existingUserLoginTextBox.Visibility = Visibility.Collapsed;
                registerButton.Margin = new Thickness(0, 30, 0, 0);
            }


            if (userEmailTextBox.Text == Properties.Languages.Language.textEmail || userLoginTextBox.Text == Properties.Languages.Language.textLogin || userPasswordPasswordBox.Password == "")
            {
                if (userEmailTextBox.Text == Properties.Languages.Language.textEmail)
                {
                    emptyEmail.Visibility = Visibility.Visible;
                    loginPanel.Margin = new Thickness(0, 15, 0, 0);
                }
                if (userLoginTextBox.Text == Properties.Languages.Language.textLogin)
                {
                    emptyLogin.Visibility = Visibility.Visible;
                    passwordPanel.Margin = new Thickness(0, 15, 0, 0);
                }
                if (userPasswordPasswordBox.Password == "")
                {
                    emptyPassword.Visibility = Visibility.Visible;
                    registerButton.Margin = new Thickness(0, 15, 0, 0);
                }
            }
            else
            {
                Regex checkEmail = new Regex(".*@mail[.]ru$");
                if (checkEmail.IsMatch(userEmailTextBox.Text))
                {
                    if (DataBaseConnection.LogisticCompanyDB.Users.FirstOrDefault(x => x.Mail_User == userEmailTextBox.Text) == null)
                    {
                        if(DataBaseConnection.LogisticCompanyDB.Users.FirstOrDefault(x => x.Login_User == userLoginTextBox.Text) == null)
                        {
                            Regex checkPassword = new Regex("(?=.*[A-Z]{1,})[A-Z]{1,}");
                            if(checkPassword.IsMatch(userPasswordPasswordBox.Password))
                            {
                                checkPassword = new Regex("(?=.*[a-z]{3,})[a-z]{3,}");
                                if (checkPassword.IsMatch(userPasswordPasswordBox.Password))
                                {
                                    checkPassword = new Regex("(?=.*[0-9]{2,})[0-9]{2,}");
                                    if (checkPassword.IsMatch(userPasswordPasswordBox.Password))
                                    {
                                        checkPassword = new Regex("(?=.*[!@#$%^&*]{1,})[!@#$%^&*]{1,}");
                                        if (checkPassword.IsMatch(userPasswordPasswordBox.Password))
                                        {
                                            forFrameClass.publicFrame.Navigate(new personalAccount(userEmailTextBox.Text, userLoginTextBox.Text, userPasswordPasswordBox.Password));
                                        }
                                        else
                                        {
                                            errorPassword.Text = Properties.Languages.Language.errorPassword_MinSpecSymbols;
                                            errorPassword.Visibility = Visibility.Visible;
                                            registerButton.Margin = new Thickness(0, 15, 0, 0);
                                        }
                                    }
                                    else
                                    {
                                        errorPassword.Text = Properties.Languages.Language.errorPassword_MinNumber;
                                        errorPassword.Visibility = Visibility.Visible;
                                        registerButton.Margin = new Thickness(0, 15, 0, 0);
                                    }
                                }
                                else
                                {
                                    errorPassword.Text = Properties.Languages.Language.errorPassword_MinLoweraseLetter;
                                    errorPassword.Visibility = Visibility.Visible;
                                    registerButton.Margin = new Thickness(0, 15, 0, 0);
                                }
                            }
                            else
                            {
                                errorPassword.Text = Properties.Languages.Language.errorPassword_MinCapitalLetter;
                                errorPassword.Visibility = Visibility.Visible;
                                registerButton.Margin = new Thickness(0, 15, 0, 0);
                            }
                        }
                        else
                        {
                            existingUserLoginTextBox.Visibility = Visibility.Visible;
                            registerButton.Margin = new Thickness(0, 10, 0, 0);
                        }
                    }
                    else
                    {
                        existingUserMailTextBox.Visibility = Visibility.Visible;
                        registerButton.Margin = new Thickness(0, 10, 0, 0);
                    }
                }
                else
                {
                    errorEmail.Visibility = Visibility.Visible;
                    loginPanel.Margin = new Thickness(0, 15, 0, 0);
                }
                
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            forFrameClass.publicFrame.Navigate(new RegistrationAuthorizationPage());
        }
    }
}
