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
    /// Логика взаимодействия для addExecutor.xaml
    /// </summary>
    public partial class addExecutor : Page
    {
        public addExecutor()
        {
            InitializeComponent();

            //Заполняем combo box категорий прицепов
            listDriversTextBox.Visibility = Visibility.Collapsed;
            listVehiclesTextBox.Visibility = Visibility.Collapsed;
            listDrivers.Visibility = Visibility.Collapsed;
            listVehicles.Visibility = Visibility.Collapsed;
            categoryTrailerComboBox.Items.Add("Не выбрано");
            List<Category_Trailer> trailersList = DataBaseConnection.LogisticCompanyDB.Category_Trailer.ToList();
            for (int i = 0; i < trailersList.Count; i++)
            {
                string nameTrailer = $"{trailersList[i].Name_Trailer}";
                categoryTrailerComboBox.Items.Add(nameTrailer);
            }

            categoryTrailerComboBox.SelectedIndex = 0;
        }

        Executors executors;
        bool checkExisitingExecutor = false;
        public addExecutor(Executors executors)
        {
            InitializeComponent();
            headingPage.Text = "Изменение";
            addExecutorButton.Content = "Изменить";
            this.executors = executors;

            surnameExecutorTextBox.Text = executors.Surname_Executor;
            nameExecutorTextBox.Text = executors.Name_Executor;
            midnameExecutorTextBox.Text = executors.Midname_Executor;
            telephoneExecutorTextBox.Text = executors.Telephone_Executor;

            checkExisitingExecutor = true;
            addDriverPanel.Visibility = Visibility.Collapsed;
            addVehiclePanel.Visibility = Visibility.Collapsed;
            int codeExecutor = executors.Code_Executor;
            listDrivers.ItemsSource = DataBaseConnection.LogisticCompanyDB.Drivers.Where(x => x.Code_Executor == codeExecutor).ToList();
            listVehicles.ItemsSource = DataBaseConnection.LogisticCompanyDB.Vehicles.Where(x => x.Code_Executor == codeExecutor).ToList();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            forFrameClass.publicFrame.Navigate(new listOfExecutors());
        }

        private void addExecutorButton_Click(object sender, RoutedEventArgs e)
        {
            //Заглушка на проверку пустых полей, переделать
            if (!checkExisitingExecutor)
            {
                if (surnameExecutorTextBox.Text == "" || nameExecutorTextBox.Text == "" || midnameDriverTextBox.Text == "" || telephoneExecutorTextBox.Text == "" || surnameDriverTextBox.Text == "" || nameDriverTextBox.Text == "" || midnameDriverTextBox.Text == "" || categoryTrailerComboBox.SelectedIndex == 0 || brandVehicleTextBox.Text == "" || modelVehicleTextBox.Text == "" || lengthVehicleTextBox.Text == "" || widthVehicleTextBox.Text == "" || heightVehicleTextBox.Text == "" || volumeVehicleTextBox.Text == "" || tonnageVehicleTextBox.Text == "" || numberVehicleTextBox.Text == "")
                    MessageBox.Show("Есть пустые поля", "Обидненько, да?))))");
                else
                {
                    Executors executors = new Executors()
                    {
                        Surname_Executor = surnameExecutorTextBox.Text,
                        Name_Executor = nameExecutorTextBox.Text,
                        Midname_Executor = midnameExecutorTextBox.Text,
                        Telephone_Executor = telephoneExecutorTextBox.Text
                    };
                    DataBaseConnection.LogisticCompanyDB.Executors.Add(executors);

                    Drivers drivers = new Drivers()
                    {
                        Code_Executor = executors.Code_Executor,
                        Surname_Driver = surnameDriverTextBox.Text,
                        Name_Driver = nameDriverTextBox.Text,
                        Midname_Driver = midnameDriverTextBox.Text,
                        Telephone_Driver = telephoneDriverTextBox.Text
                    };
                    DataBaseConnection.LogisticCompanyDB.Drivers.Add(drivers);

                    Vehicles vehicles = new Vehicles()
                    {
                        Code_Executor = executors.Code_Executor,
                        Code_Category = categoryTrailerComboBox.SelectedIndex,
                        Brand_Vehicle = brandVehicleTextBox.Text,
                        Model_Vehicle = modelVehicleTextBox.Text,
                        Length_Vehicle = Convert.ToSingle(lengthVehicleTextBox.Text),
                        Width_Vehicle = Convert.ToSingle(widthVehicleTextBox.Text),
                        Height_Vehicle = Convert.ToSingle(heightVehicleTextBox.Text),
                        Volume_Vehicle = Convert.ToSingle(volumeVehicleTextBox.Text),
                        Tonnage_Vehicle = Convert.ToSingle(tonnageVehicleTextBox.Text),
                        Number_Vehicle = numberVehicleTextBox.Text
                    };
                    DataBaseConnection.LogisticCompanyDB.Vehicles.Add(vehicles);
                }



                DataBaseConnection.LogisticCompanyDB.SaveChanges();
            }
            else
            {
                if (surnameExecutorTextBox.Text == "" || nameExecutorTextBox.Text == "" || midnameExecutorTextBox.Text == "" || telephoneExecutorTextBox.Text == "")
                    MessageBox.Show("Есть пустые поля", "Обидненько, да?))))");
                else
                {
                    executors.Surname_Executor = surnameExecutorTextBox.Text;
                    executors.Name_Executor = nameExecutorTextBox.Text;
                    executors.Midname_Executor = midnameExecutorTextBox.Text;
                    executors.Telephone_Executor = telephoneExecutorTextBox.Text;

                    DataBaseConnection.LogisticCompanyDB.SaveChanges();
                    forFrameClass.publicFrame.Navigate(new listOfExecutors());
                }
            }
        }

        private void deleteDriverButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Удаление пока не работает, потому что не настраивается каскадное удаление");
        }

        private void updateDriverButton_Click(object sender, RoutedEventArgs e)
        {
            Button getDriverIndex = (Button)sender;
            int driverIndex = Convert.ToInt32(getDriverIndex.Uid);
            Drivers drivers = DataBaseConnection.LogisticCompanyDB.Drivers.FirstOrDefault(x => x.Code_Driver == driverIndex);
            forFrameClass.publicFrame.Navigate(new updateDriver(drivers, executors));
        }

        private void deleteVehicleButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Удаление пока не работает, потому что не настраивается каскадное удаление");
        }

        private void updateVehicleButton_Click(object sender, RoutedEventArgs e)
        {
            Button getVehicleIndex = (Button)sender;
            int vehicleIndex = Convert.ToInt32(getVehicleIndex.Uid);
            Vehicles vehicles = DataBaseConnection.LogisticCompanyDB.Vehicles.FirstOrDefault(x => x.Code_Vehicle == vehicleIndex);
            forFrameClass.publicFrame.Navigate(new updateVehicle(vehicles, executors));
        }
    }
}
