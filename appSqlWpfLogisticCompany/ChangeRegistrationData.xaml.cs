using appSqlWpfLogisticCompany.Pages;
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
using System.Windows.Shapes;

namespace appSqlWpfLogisticCompany
{
    /// <summary>
    /// Логика взаимодействия для ChangeRegistrationData.xaml
    /// </summary>
    public partial class ChangeRegistrationData : Window
    {
        Users user;
        public ChangeRegistrationData(Users user)
        {
            InitializeComponent();
            this.user = user;
            loginUser.Text = user.Login_User;
            mailUser.Text = user.Mail_User;

        }

        private void changeButton_Click(object sender, RoutedEventArgs e)
        {
            if (mailUser.Text == "" || loginUser.Text == "" || passwordUser.Password == "")
            {
                if (loginUser.Text == "") //Показываем ошибку пустого логина
                {
                    MessageBox.Show("Поле с логином пустое");
                }
                else if (mailUser.Text == "") //Показываем ошибку пустой почты
                {
                    MessageBox.Show("Поле с почтой пустое");
                }
                else if (passwordUser.Password == "") //Показываем ошибку пустого пароля
                {
                    MessageBox.Show("Поле с паролем пустое");
                }
            }
            else
            {
                Regex checkEmail = new Regex(".*[\\w]{1,}@mail[.]ru$"); //Регулярное выражение, чтобы в поле почты было @mail.ru

                if (checkEmail.IsMatch(mailUser.Text)) //Проверка на совпадение с регулярным выражением
                {
                    //Проверка на существующий аккаунт по введенной почте
                    if (DataBaseConnection.LogisticCompanyDB.Users.FirstOrDefault(x => x.Mail_User == mailUser.Text) == null || mailUser.Text == user.Mail_User)
                    {
                        //Проверка на существующий аккаунт по введенному логину
                        if (DataBaseConnection.LogisticCompanyDB.Users.FirstOrDefault(x => x.Login_User == loginUser.Text) == null || loginUser.Text == user.Login_User)
                        {
                            //Регулярное выражение на наличие хотя-бы одной заглавной буквы и проверка
                            Regex checkPassword = new Regex("(?=.*[A-Z]{1,})[A-Z]{1,}");
                            if (checkPassword.IsMatch(passwordUser.Password))
                            {
                                //Регулярное выражение на наличие минимум трех строчных букв и проврека
                                checkPassword = new Regex("(?=.*[a-z]{3,})[a-z]{3,}");
                                if (checkPassword.IsMatch(passwordUser.Password))
                                {
                                    //Регулярное выражение на наличие минимум двух цифр и проверка
                                    checkPassword = new Regex("(?=.*[0-9]{2,})[0-9]{2,}");
                                    if (checkPassword.IsMatch(passwordUser.Password))
                                    {
                                        //Регулярное выражение на наличие минимум одного спец. символа и проверка
                                        checkPassword = new Regex("(?=.*[!@#$%^&*]{1,})[!@#$%^&*]{1,}");
                                        if (checkPassword.IsMatch(passwordUser.Password))
                                        {
                                            //Если все условия соблюдены, то продолжаем регистрацию в личном кабинете
                                            MessageBox.Show("Данные изменены");
                                            user.Login_User = loginUser.Text;
                                            user.Mail_User = mailUser.Text;
                                            user.Password_User = passwordUser.Password.GetHashCode();
                                            DataBaseConnection.LogisticCompanyDB.SaveChanges();
                                            this.Close();
                                        }
                                        else //Если в поле пароль нет спец. символа
                                        {
                                            MessageBox.Show("В пароле должен содержаться минимум один спец. символ");
                                        }
                                    }
                                    else //Если в поле пароль нет минимум двух цифр
                                    {
                                        MessageBox.Show("В пароле должны содержаться минимум две цифры");
                                    }
                                }
                                else //Если в поле пароль нет минимум трех строчных букв
                                {
                                    MessageBox.Show("В пароле должны содержаться минимум три строчные буквы");
                                }
                            }
                            else //Если в поле пароль нет хотя-бы одной заглавной буквы
                            {
                                MessageBox.Show("В пароле должна содержаться минимум одна заглавная буква");
                            }
                        }
                        else //Если аккаунт с введенным логином существует
                        {
                            MessageBox.Show("Аккаунт с введенным логином существует");
                        }
                    }
                    else //Если аккаунт с введенной почтой существует
                    {
                        MessageBox.Show("Аккаунт с веденной почтой уже существует");
                    }
                }
                else //Если не прошла проверка на регулярное выражение с почтой
                {
                    MessageBox.Show("Неверно указана почта");
                }

            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
