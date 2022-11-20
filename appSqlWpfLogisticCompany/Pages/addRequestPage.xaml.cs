using System.Linq;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace appSqlWpfLogisticCompany
{
    /// <summary>
    /// Логика взаимодействия для addRequestPage.xaml
    /// </summary>
    public partial class addRequestPage : Page
    {
        
        public addRequestPage()
        {
            InitializeComponent();

            //Заполняем combo box исполнителей
            executorsComboBox.Items.Add("Не выбрано");
            executorsComboBox.Items.Add("Добавить нового исполнителя");
            List<Executors> executorsList = DataBaseConnection.LogisticCompanyDB.Executors.ToList();
            for(int i = 0; i < executorsList.Count; i++)
            {
                string fullNameExecutor = $"{executorsList[i].Surname_Executor} {executorsList[i].Name_Executor} {executorsList[i].Midname_Executor}";
                executorsComboBox.Items.Add(fullNameExecutor);
            }

            executorsComboBox.SelectedIndex = 0;


            //Заполняем combo box водителей
            driversComboBox.Items.Add("Не выбрано");
            driversComboBox.Items.Add("Добавить нового водителя");
            List<Drivers> driversList = DataBaseConnection.LogisticCompanyDB.Drivers.ToList();
            for (int i = 0; i < driversList.Count; i++)
            {
                string fullNameDriver = $"{driversList[i].Surname_Driver} {driversList[i].Name_Driver} {driversList[i].Midname_Driver}";
                driversComboBox.Items.Add(fullNameDriver);
            }

            driversComboBox.SelectedIndex = 0;

            //Заполняем combo box автомобилей
            vehiclesComboBox.Items.Add("Не выбрано");
            vehiclesComboBox.Items.Add("Добавить новый автомобиль");
            List<Vehicles> vehiclesList = DataBaseConnection.LogisticCompanyDB.Vehicles.ToList();
            for (int i = 0; i < vehiclesList.Count; i++)
            {
                string dataVehicle = $"{vehiclesList[i].Brand_Vehicle} {vehiclesList[i].Model_Vehicle} {vehiclesList[i].Number_Vehicle}";
                vehiclesComboBox.Items.Add(dataVehicle);
            }

            vehiclesComboBox.SelectedIndex = 0;
            

            //Заполняем combo box грузоотправителей
            shippersComboBox.Items.Add("Не выбрано");
            shippersComboBox.Items.Add("Добавить нового грузоотправителя");
            List<Shippers> shippersList = DataBaseConnection.LogisticCompanyDB.Shippers.ToList();
            for (int i = 0; i < shippersList.Count; i++)
            {
                string companyShipper = $"{shippersList[i].Name_Company}";
                shippersComboBox.Items.Add(companyShipper);
            }

            shippersComboBox.SelectedIndex = 0;

            //Заполняем combo box грузополучателей
            consigneesComboBox.Items.Add("Не выбрано");
            consigneesComboBox.Items.Add("Добавить нового грузополучателя");
            List<Consignees> consigneesList = DataBaseConnection.LogisticCompanyDB.Consignees.ToList();
            for (int i = 0; i < consigneesList.Count; i++)
            {
                string companyConsignee = $"{consigneesList[i].Name_Company}";
                consigneesComboBox.Items.Add(companyConsignee);
            }

            consigneesComboBox.SelectedIndex = 0;

            paymentStatusComboBox.SelectedIndex = 0;

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

        private void executorsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) //Событие при изменении ComboBox исполнителей
        {
            //Если нет исполнителя, то также нет водителя и автомобиля, зарегистрированных на исполнителя,
            //Поэтому при добавлении исполнителя нужно добавить автомобиль и водителя
            if (executorsComboBox.SelectedIndex == 1) 
            {
                addExecutorPanel.Visibility = Visibility.Visible;

                driversComboBox.SelectedIndex = 1;
                driversComboBox.IsEnabled = false;

                vehiclesComboBox.SelectedIndex = 1;
                vehiclesComboBox.IsEnabled = false;
            }
            else
            {
                addExecutorPanel.Visibility = Visibility.Collapsed;

                driversComboBox.SelectedIndex = 0;
                driversComboBox.IsEnabled = true;

                vehiclesComboBox.SelectedIndex = 0;
                vehiclesComboBox.IsEnabled = true;
            }
        }

        private void driversComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) // Событие при изменении ComboBox водителей
        {
            if (driversComboBox.SelectedIndex == 1) addDriverPanel.Visibility = Visibility.Visible;
            else addDriverPanel.Visibility = Visibility.Collapsed;
        }

        private void vehiclesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) // Событие при изменении ComboBox автомобилей
        {
            if (vehiclesComboBox.SelectedIndex == 1) addVehiclePanel.Visibility = Visibility.Visible; 
            else addVehiclePanel.Visibility = Visibility.Hidden;
        }

        private void shippersComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) // Событие при изменении ComboBox грузоотправителей
        {
            if (shippersComboBox.SelectedIndex == 1) addShipperPanel.Visibility = Visibility.Visible;
            else addShipperPanel.Visibility= Visibility.Collapsed;
        }

        private void consigneesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) // Событие при изменении ComboBox грузополучателей
        {
            if (consigneesComboBox.SelectedIndex == 1) addConsigneePanel.Visibility = Visibility.Visible;
            else addConsigneePanel.Visibility = Visibility.Collapsed;
        }

        private void addRequestButton_Click(object sender, RoutedEventArgs e)
        {
            if (executorsComboBox.SelectedIndex != 0) // Если в ComboBox исполнителей выбрано любое значение, кроме "Не выбрано"
            {
                if (executorsComboBox.SelectedIndex != 1) // Если не выбрано "Добавить нового исполнителя"
                {
                    if (driversComboBox.SelectedIndex != 0) // Если в ComboBox водителей выбрано любое значение, кроме "Не выбрано"
                    {
                        if (driversComboBox.SelectedIndex != 1) // Если не выбрано "Добавить нового водителя"
                        {

                        }
                        else //
                        {

                        }
                    }
                    else // Если в ComboBox исполнителей выбрано значение "Не выбрано"
                    {

                    }
                }
                else // Если выбрано "Добавить нового исполнителя"
                {
                    //ЛОГИКА
                }
            }
            else // Если в ComboBox исполнителей выбрано значение "Не выбрано"
            {
                //ЛОГИКА
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            forFrameClass.publicFrame.Navigate(new RequestsPage());
        }
    }
}
