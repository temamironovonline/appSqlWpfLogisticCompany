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
            executorsComboBox.Items.Add("Не выбрано");
            List<Executors> executorsList = DataBaseConnection.LogisticCompanyDB.Executors.ToList();
            for(int i = 0; i < executorsList.Count; i++)
            {
                string fullName = $"{executorsList[i].Surname_Executor} {executorsList[i].Name_Executor} {executorsList[i].Midname_Executor}";
                executorsComboBox.Items.Add(fullName);
            }
            executorsComboBox.Items.Add("Добавить нового исполнителя");
        }
        
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            forFrameClass.publicFrame.Navigate(new RequestsPage());
        }
    }
}
