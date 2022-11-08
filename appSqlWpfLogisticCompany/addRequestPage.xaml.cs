using System.Linq;
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
            executorsComboBox.ItemsSource = DataBaseConnection.LogisticCompanyDB.Executors.ToList();
            executorsComboBox.SelectedValuePath = "Code_Executor";
            executorsComboBox.DisplayMemberPath = "Surname_Executor";
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            forFrameClass.publicFrame.Navigate(new RequestsPage());
        }
    }
}
