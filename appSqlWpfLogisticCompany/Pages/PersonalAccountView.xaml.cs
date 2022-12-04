using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Windows;
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
            selectPhotoPanel.Visibility = Visibility.Collapsed;
            try
            {
                Users_Photo userPhotoObject = DataBaseConnection.LogisticCompanyDB.Users_Photo.FirstOrDefault(x => x.Code_User == user.Code_User && x.Current_Photo == true);
                if (userPhotoObject != null)
                {
                    byte[] photoUserArray = userPhotoObject.Photo_User;
                    BitmapImage bitmapImage = new BitmapImage();

                    using (MemoryStream ms = new MemoryStream(photoUserArray))
                    {
                        bitmapImage.BeginInit();
                        bitmapImage.StreamSource = ms;
                        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                        bitmapImage.EndInit();
                    }
                    photoUser.Source = bitmapImage;
                    photoUser.Stretch = System.Windows.Media.Stretch.Uniform;
                }
                
            }
            catch
            {
                MessageBox.Show("При загрузке изображения произошла ошибка...");
            }
            

            if (user.Code_Role == 2)
            {
                backButton.Visibility = Visibility.Collapsed;
            }
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
            forFrameClass.publicFrame.Navigate(new PersonalAccountView(user));
        }

        private void updateRegButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ChangeRegistrationData crd = new ChangeRegistrationData(user);
            crd.ShowDialog();
            forFrameClass.publicFrame.Navigate(new PersonalAccountView(user));
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            forFrameClass.publicFrame.Navigate(new administrationMenu(user));
        }

        private void updatePhoto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Users_Photo usersPhoto = new Users_Photo();
                List <Users_Photo> userPhotos = DataBaseConnection.LogisticCompanyDB.Users_Photo.Where(x => x.Code_User == user.Code_User).ToList();
                OpenFileDialog OFD = new OpenFileDialog();
                OFD.ShowDialog();
                string path = OFD.FileName;
                System.Drawing.Image SDI = System.Drawing.Image.FromFile(path);
                ImageConverter IC = new ImageConverter();
                byte[] photoForDB = (byte[])IC.ConvertTo(SDI, typeof(byte[]));

                string pathApp = Directory.GetCurrentDirectory();
                pathApp = pathApp.Replace("\\bin\\Debug", "");
                path = path.Replace(pathApp, "");

                foreach(Users_Photo userPhoto in userPhotos)
                {
                    userPhoto.Current_Photo = false;
                }
                usersPhoto.Code_User = user.Code_User;
                usersPhoto.Path_Photo = path;
                usersPhoto.Photo_User = photoForDB;
                usersPhoto.Current_Photo = true;
                DataBaseConnection.LogisticCompanyDB.Users_Photo.Add(usersPhoto);
                DataBaseConnection.LogisticCompanyDB.SaveChanges();
                forFrameClass.publicFrame.Navigate(new PersonalAccountView(user));
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так...");
            }
            

        }

        private void addMorePhoto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == true)
                {
                    foreach (string file in openFileDialog.FileNames)
                    {
                        Users_Photo usersPhoto = new Users_Photo();
                        string path = file;
                        System.Drawing.Image SDI = System.Drawing.Image.FromFile(file);
                        ImageConverter imageConverter = new ImageConverter();
                        byte[] photoForDB = (byte[])imageConverter.ConvertTo(SDI, typeof(byte[]));

                        string pathApp = Directory.GetCurrentDirectory();
                        pathApp = pathApp.Replace("\\bin\\Debug", "");
                        path = path.Replace(pathApp, "");
                        usersPhoto.Code_User = user.Code_User;
                        usersPhoto.Path_Photo = path;
                        usersPhoto.Photo_User = photoForDB;
                        usersPhoto.Current_Photo = false;
                        DataBaseConnection.LogisticCompanyDB.Users_Photo.Add(usersPhoto);
                    }
                    DataBaseConnection.LogisticCompanyDB.SaveChanges();
                    forFrameClass.publicFrame.Navigate(new PersonalAccountView(user));
                    MessageBox.Show("Фото добавлены");
                }
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так...");
            }
            
        }

        List<Users_Photo> usersPhotos;
        int currentSelectedPhoto = 0;
        private void selectPhoto()
        {
            try
            {
                if (currentSelectedPhoto < 0) currentSelectedPhoto = usersPhotos.Count - 1;

                if (currentSelectedPhoto > usersPhotos.Count - 1) currentSelectedPhoto = 0;

                byte[] photoUserArray = usersPhotos[currentSelectedPhoto].Photo_User;
                BitmapImage bitmapImage = new BitmapImage();

                using (MemoryStream ms = new MemoryStream(photoUserArray))
                {
                    bitmapImage.BeginInit();
                    bitmapImage.StreamSource = ms;
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.EndInit();
                }
                newImageUser.Source = bitmapImage;
                newImageUser.Stretch = System.Windows.Media.Stretch.Uniform;
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так");
            }
            

            
        }
        private void selectPhoto_Click(object sender, RoutedEventArgs e)
        {
            usersPhotos = DataBaseConnection.LogisticCompanyDB.Users_Photo.Where(x => x.Code_User == user.Code_User).ToList();
            if (usersPhotos.Count > 0)
            {
                selectPhotoPanel.Visibility = Visibility.Visible;
                selectPhoto();
            }
            else MessageBox.Show("Кроликов нет(( НО НЕ ОТЧАИВАЙТЕСЬ! ДОБАВЬТЕ НОВОГО!");
            
        }

        private void backPhotoButton_Click(object sender, RoutedEventArgs e)
        {
            currentSelectedPhoto--;
            selectPhoto();
        }

        private void nextPhotoButton_Click(object sender, RoutedEventArgs e)
        {
            currentSelectedPhoto++;
            selectPhoto();
        }

        private void selectPhotoFromDB_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Users_Photo currentUserPhoto = usersPhotos[currentSelectedPhoto];
                foreach (Users_Photo users_Photo in usersPhotos)
                {
                    users_Photo.Current_Photo = false;
                }
                currentUserPhoto.Current_Photo = true;
                DataBaseConnection.LogisticCompanyDB.SaveChanges();
                forFrameClass.publicFrame.Navigate(new PersonalAccountView(user));
                MessageBox.Show("Фото установлено");
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так");
            }


        }
    }
}
