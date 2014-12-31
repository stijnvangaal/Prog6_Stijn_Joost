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

        public Boodschappen Boodschappen { get; set; }
        public MainWindow Mainwindow { get; set; }

        void App_Startup(object sender, StartupEventArgs e) {
            Boodschappen = new Boodschappen();
            MainWindow = new MainWindow { bsView = Boodschappen };

            Boodschappen.Top = 150;
            Boodschappen.Left = 1100;

            MainWindow.Show();
            Boodschappen.Show();
        }
    }
}
