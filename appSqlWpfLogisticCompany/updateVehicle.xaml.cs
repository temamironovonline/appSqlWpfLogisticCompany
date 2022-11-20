using System;
using System.CodeDom.Compiler;
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
    /// Логика взаимодействия для updateVehicle.xaml
    /// </summary>
    public partial class updateVehicle : Page
    {
        public updateVehicle()
        {
            InitializeComponent();
        }

        Vehicles vehicle;
        Executors executor;
        public updateVehicle(Vehicles vehicle, Executors executor)
        {
            InitializeComponent();
            this.vehicle = vehicle;
            this.executor = executor;

            //Заполняем combo box категорий прицепов
            categoryTrailerComboBox.Items.Add("Не выбрано");
            List<Category_Trailer> trailersList = DataBaseConnection.LogisticCompanyDB.Category_Trailer.ToList();
            for (int i = 0; i < trailersList.Count; i++)
            {
                string nameTrailer = $"{trailersList[i].Name_Trailer}";
                categoryTrailerComboBox.Items.Add(nameTrailer);
            }

            categoryTrailerComboBox.SelectedIndex = vehicle.Code_Vehicle;
            brandVehicleTextBox.Text = vehicle.Brand_Vehicle;
            modelVehicleTextBox.Text = vehicle.Model_Vehicle;
            lengthVehicleTextBox.Text = Convert.ToString(vehicle.Length_Vehicle);
            widthVehicleTextBox.Text = Convert.ToString(vehicle.Width_Vehicle);
            heightVehicleTextBox.Text = Convert.ToString(vehicle.Height_Vehicle);
            volumeVehicleTextBox.Text = Convert.ToString(vehicle.Volume_Vehicle);
            tonnageVehicleTextBox.Text = Convert.ToString(vehicle.Tonnage_Vehicle);
            numberVehicleTextBox.Text = vehicle.Number_Vehicle;

        }

        private void updateVehicleButton_Click(object sender, RoutedEventArgs e)
        {
            if(categoryTrailerComboBox.SelectedIndex == 0 || brandVehicleTextBox.Text == "" || modelVehicleTextBox.Text == "" || lengthVehicleTextBox.Text == "" || widthVehicleTextBox.Text == "" || heightVehicleTextBox.Text == "" || volumeVehicleTextBox.Text == "" || tonnageVehicleTextBox.Text == "" || numberVehicleTextBox.Text == "")
                MessageBox.Show("Есть пустые поля", "Обидненько, да?))))");
            else
            {
                vehicle.Code_Category = categoryTrailerComboBox.SelectedIndex;
                vehicle.Brand_Vehicle = brandVehicleTextBox.Text;
                vehicle.Model_Vehicle = modelVehicleTextBox.Text;
                vehicle.Length_Vehicle = Convert.ToSingle(lengthVehicleTextBox.Text);
                vehicle.Width_Vehicle = Convert.ToSingle(widthVehicleTextBox.Text);
                vehicle.Height_Vehicle = Convert.ToSingle(heightVehicleTextBox.Text);
                vehicle.Volume_Vehicle = Convert.ToSingle(volumeVehicleTextBox.Text);
                vehicle.Tonnage_Vehicle = Convert.ToSingle(tonnageVehicleTextBox.Text);
                vehicle.Number_Vehicle = numberVehicleTextBox.Text;
                DataBaseConnection.LogisticCompanyDB.SaveChanges();
                forFrameClass.publicFrame.Navigate(new addExecutor(executor));
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            forFrameClass.publicFrame.Navigate(new addExecutor(executor));
        }
    }
}
