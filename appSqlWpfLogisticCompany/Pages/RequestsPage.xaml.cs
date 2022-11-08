﻿using System;
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
    /// Логика взаимодействия для RequestsPage.xaml
    /// </summary>
    public partial class RequestsPage : Page
    {
        public RequestsPage()
        {
            InitializeComponent();
            listRequests.ItemsSource = DataBaseConnection.LogisticCompanyDB.Requests.ToList();
            int count = DataBaseConnection.LogisticCompanyDB.Requests.Count(x => x.Date_Request.Value.Month == DateTime.Now.Month && x.Date_Request.Value.Year == DateTime.Now.Year);
            countRequest.Text = Convert.ToString(count);
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            forFrameClass.publicFrame.Navigate(new administrationMenu());
        }

        private void createRequestButton_Click(object sender, RoutedEventArgs e)
        {
            forFrameClass.publicFrame.Navigate(new addRequestPage());
        }
    }
}
