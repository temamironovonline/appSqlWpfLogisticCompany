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
            MessageBox.Show("У исполнителя может быть много водителей и автомобилей");
            headingPage.Text = "Изменение";
            this.executors = executors;
            checkExisitingExecutor = true;
            addDriverPanel.Visibility = Visibility.Collapsed;
            addVehiclePanel.Visibility = Visibility.Collapsed;
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            forFrameClass.publicFrame.Navigate(new listOfExecutors());
        }

        private void addExecutorButton_Click(object sender, RoutedEventArgs e)
        {
            //Заглушка на проверку пустых полей, переделать
            if (checkExisitingExecutor)
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
                if (surnameExecutorTextBox.Text == "" || nameExecutorTextBox.Text == "" || midnameDriverTextBox.Text == "" || telephoneExecutorTextBox.Text == "")
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

                    DataBaseConnection.LogisticCompanyDB.SaveChanges();
                    forFrameClass.publicFrame.Navigate(new listOfExecutors());
                }
        }
    }
}
