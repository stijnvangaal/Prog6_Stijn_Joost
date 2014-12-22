using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using AppieApp.Boodschappen;

namespace AppieApp {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        void App_Startup(object sender, StartupEventArgs e) {
            Boodschappen.MainWindow mainWindow = new Boodschappen.MainWindow();
            mainWindow.Top = 100;
            mainWindow.Left = 400;
            mainWindow.Show();
        }
    }
}
