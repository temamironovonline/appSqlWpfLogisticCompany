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
        
        private void userEmailTextBox_GotFocus(object sender, RoutedEventArgs e) //Событие при фокусе на поле почты
        {
            if(existingUserMailTextBox.Visibility == Visibility.Visible) //Если видна ошибка существующего пользователя, то скрываем ее
            {
                existingUserMailTextBox.Visibility = Visibility.Collapsed;
                registerButton.Margin = new Thickness(0, 30, 0, 0);
            }
            if (errorEmail.Visibility == Visibility.Visible) //Если видна ошибка неправильно введенной почты, то скрываем ее
            {
                errorEmail.Visibility = Visibility.Collapsed;
                loginPanel.Margin = new Thickness(0, 30, 0, 0);
            }
            if (emptyEmail.Visibility == Visibility.Visible) //Если видна ошибка пустой почты, то скрываем ее
            {
                emptyEmail.Visibility = Visibility.Collapsed;
                loginPanel.Margin = new Thickness(0, 30, 0, 0);
            }

            if (userEmailTextBox.Text == Properties.Languages.Language.textEmail) userEmailTextBox.Text = ""; //Убираем "эффект" hint для поля
            var brushConverter = new BrushConverter();
            userEmailTextBox.Foreground = (Brush)brushConverter.ConvertFrom("#FF6F97EE");
            polylineEmail.Stroke = (Brush)brushConverter.ConvertFrom("#FF6F97EE");
            userEmailIcon.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/emailUserBlue.png"));
        }

        private void userEmailTextBox_LostFocus(object sender, RoutedEventArgs e) //Событие при потере фокуса с поля почты
        {
            if (userEmailTextBox.Text == "") userEmailTextBox.Text = Properties.Languages.Language.textEmail; //Включаем "эффект" hint, если пользователь ничего не ввел в поле
            var brushConverter = new BrushConverter();
            userEmailTextBox.Foreground = (Brush)brushConverter.ConvertFrom("#C7C9C7");
            polylineEmail.Stroke = (Brush)brushConverter.ConvertFrom("#C7C9C7");
            userEmailIcon.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/emailUserGray.png"));

        }

        private void userLoginTextBox_GotFocus(object sender, RoutedEventArgs e) //Событие при фокусе на поле логина
        {
            if (existingUserLoginTextBox.Visibility == Visibility.Visible) //Если видна ошибка существующего пользователя, то скрываем ее
            {
                existingUserLoginTextBox.Visibility = Visibility.Collapsed;
                registerButton.Margin = new Thickness(0, 30, 0, 0);
            }

            if (emptyLogin.Visibility == Visibility.Visible) //Если ошибка пустого логина видна, то скрываем ее
            {
                emptyLogin.Visibility = Visibility.Collapsed;
                passwordPanel.Margin = new Thickness(0, 30, 0, 0);
            }
            var brushConverter = new BrushConverter();
            if (userLoginTextBox.Text == Properties.Languages.Language.textLogin) userLoginTextBox.Text = ""; //Убираем "эффект" hint для поля
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

        private void userPasswordTextBox_GotFocus(object sender, RoutedEventArgs e) //Событие при фокусе на поле пароль, если в поле написано "Пароль" (т.е. поле пустое) (TEXTBOX)
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

        private void userPasswordPasswordBox_GotFocus(object sender, RoutedEventArgs e) //Событие при фокусе на поле пароль, если в поле введены какие-то значения (PASSWORDBOX)
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
            if (userPasswordPasswordBox.Password.ToString() == "") //Если PasswordBox пустой, то выключаем его и включаем TextBox
            {
                userPasswordPasswordBox.Visibility = Visibility.Collapsed;
                userPasswordTextBox.Visibility = Visibility.Visible;
            }
            userPasswordTextBox.Foreground = (Brush)brushConverter.ConvertFrom("#C7C9C7");
            polylinePassword.Stroke = (Brush)brushConverter.ConvertFrom("#C7C9C7");
            userPasswordIcon.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/passwordlogin.png"));
        }

        private void registerButton_Click(object sender, RoutedEventArgs e) //Событие при нажатии кнопки регистрации
        {
            //Данные условия внесены для того, чтобы не вылезло несколько ошибок,
            //потому что эти ошибки исчезают только, если нажать на то поле, в котором они появились,
            //а если пользователь не нажмет на него и изменит другое поле, которое также повлечет за собой ошибку,
            //то будет видно две ошибки, что не является правильным
            
            if (errorPassword.Visibility == Visibility.Visible) //Если ошибка пароля видна, то скрываем ее
            {
                errorPassword.Visibility = Visibility.Collapsed;
                registerButton.Margin = new Thickness(0, 30, 0, 0);
            }
            if (errorEmail.Visibility == Visibility.Visible) //Если ошибка почты видна, то скрываем ее
            {
                errorEmail.Visibility = Visibility.Collapsed;
                registerButton.Margin = new Thickness(0, 30, 0, 0);
            }
            if (existingUserLoginTextBox.Visibility == Visibility.Visible) //Если ошибка существующего пользователя по логину видна, то скрываем ее
            {
                existingUserLoginTextBox.Visibility = Visibility.Collapsed;
                registerButton.Margin = new Thickness(0, 30, 0, 0);
            }
            if (existingUserMailTextBox.Visibility == Visibility.Visible) //Если ошибка существующего пользователя по почте видна, то скрываем ее
            {
                existingUserLoginTextBox.Visibility = Visibility.Collapsed;
                registerButton.Margin = new Thickness(0, 30, 0, 0);
            }

            //Если пользователь оставил все поля пустыми
            if (userEmailTextBox.Text == Properties.Languages.Language.textEmail || userLoginTextBox.Text == Properties.Languages.Language.textLogin || userPasswordPasswordBox.Password == "")
            {
                if (userEmailTextBox.Text == Properties.Languages.Language.textEmail) //Показываем ошибку пустой почты
                {
                    emptyEmail.Visibility = Visibility.Visible;
                    loginPanel.Margin = new Thickness(0, 15, 0, 0);
                }
                if (userLoginTextBox.Text == Properties.Languages.Language.textLogin) //Показываем ошибку пустого логина
                {
                    emptyLogin.Visibility = Visibility.Visible;
                    passwordPanel.Margin = new Thickness(0, 15, 0, 0);
                }
                if (userPasswordPasswordBox.Password == "") //Показываем ошибку пустого пароля
                {
                    emptyPassword.Visibility = Visibility.Visible;
                    registerButton.Margin = new Thickness(0, 15, 0, 0);
                }
            }
            else
            {
                Regex checkEmail = new Regex(".*[\\w]{1,}@mail[.]ru$"); //Регулярное выражение, чтобы в поле почты было @mail.ru
                if (checkEmail.IsMatch(userEmailTextBox.Text)) //Проверка на совпадение с регулярным выражением
                {
                    //Проверка на существующий аккаунт по введенной почте
                    if (DataBaseConnection.LogisticCompanyDB.Users.FirstOrDefault(x => x.Mail_User == userEmailTextBox.Text) == null)
                    {
                        //Проверка на существующий аккаунт по введенному логину
                        if(DataBaseConnection.LogisticCompanyDB.Users.FirstOrDefault(x => x.Login_User == userLoginTextBox.Text) == null)
                        {
                            //Регулярное выражение на наличие хотя-бы одной заглавной буквы и проверка
                            Regex checkPassword = new Regex("(?=.*[A-Z]{1,})[A-Z]{1,}");
                            if(checkPassword.IsMatch(userPasswordPasswordBox.Password))
                            {
                                //Регулярное выражение на наличие минимум трех строчных букв и проврека
                                checkPassword = new Regex("(?=.*[a-z]{3,})[a-z]{3,}");
                                if (checkPassword.IsMatch(userPasswordPasswordBox.Password))
                                {
                                    //Регулярное выражение на наличие минимум двух цифр и проверка
                                    checkPassword = new Regex("(?=.*[0-9]{2,})[0-9]{2,}");
                                    if (checkPassword.IsMatch(userPasswordPasswordBox.Password))
                                    {
                                        //Регулярное выражение на наличие минимум одного спец. символа и проверка
                                        checkPassword = new Regex("(?=.*[!@#$%^&*]{1,})[!@#$%^&*]{1,}");
                                        if (checkPassword.IsMatch(userPasswordPasswordBox.Password))
                                        {
                                            //Если все условия соблюдены, то продолжаем регистрацию в личном кабинете
                                            forFrameClass.publicFrame.Navigate(new personalAccount(userEmailTextBox.Text, userLoginTextBox.Text, userPasswordPasswordBox.Password));
                                        }
                                        else //Если в поле пароль нет спец. символа
                                        {
                                            errorPassword.Text = Properties.Languages.Language.errorPassword_MinSpecSymbols;
                                            errorPassword.Visibility = Visibility.Visible;
                                            registerButton.Margin = new Thickness(0, 15, 0, 0);
                                        }
                                    }
                                    else //Если в поле пароль нет минимум двух цифр
                                    {
                                        errorPassword.Text = Properties.Languages.Language.errorPassword_MinNumber;
                                        errorPassword.Visibility = Visibility.Visible;
                                        registerButton.Margin = new Thickness(0, 15, 0, 0);
                                    }
                                }
                                else //Если в поле пароль нет минимум трех строчных букв
                                {
                                    errorPassword.Text = Properties.Languages.Language.errorPassword_MinLoweraseLetter;
                                    errorPassword.Visibility = Visibility.Visible;
                                    registerButton.Margin = new Thickness(0, 15, 0, 0);
                                }
                            }
                            else //Если в поле пароль нет хотя-бы одной заглавной буквы
                            {
                                errorPassword.Text = Properties.Languages.Language.errorPassword_MinCapitalLetter;
                                errorPassword.Visibility = Visibility.Visible;
                                registerButton.Margin = new Thickness(0, 15, 0, 0);
                            }
                        }
                        else //Если аккаунт с введенным логином существует
                        {
                            existingUserLoginTextBox.Visibility = Visibility.Visible;
                            registerButton.Margin = new Thickness(0, 10, 0, 0);
                        }
                    }
                    else //Если аккаунт с введенной почтой существует
                    {
                        existingUserMailTextBox.Visibility = Visibility.Visible;
                        registerButton.Margin = new Thickness(0, 10, 0, 0);
                    }
                }
                else //Если не прошла проверка на регулярное выражение с почтой
                {
                    errorEmail.Visibility = Visibility.Visible;
                    loginPanel.Margin = new Thickness(0, 15, 0, 0);
                }
                
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e) //Событие на кнопку назад для перехода на предыдущую страницу
        {
            forFrameClass.publicFrame.Navigate(new RegistrationAuthorizationPage());
        }
    }
}
