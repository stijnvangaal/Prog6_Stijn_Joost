using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace AppieProducten {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        void App_Startup(object sender, StartupEventArgs e) {
            Boodschappen boodschappen = new Boodschappen();
            boodschappen.Top = 100;
            boodschappen.Left = 1100;
            boodschappen.Show();
        }
    }
}
