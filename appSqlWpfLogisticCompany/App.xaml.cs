using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace appSqlWpfLogisticCompany
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var langCode = appSqlWpfLogisticCompany.Properties.Settings.Default.languageApp;
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(langCode);

            base.OnStartup(e);
        }
    }
}
