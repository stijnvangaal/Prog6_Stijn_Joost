using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AppieProducten {
    /// <summary>
    /// Interaction logic for Beheer.xaml
    /// </summary>
    public partial class Beheer : Window {

        public Boodschappen bsView { get; set; }
        public Beheer() {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e) {
            Environment.Exit(0);
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e) {
            var view = new MainWindow { bsView = this.bsView };
            view.Top = 200;
            view.Left = 400;
            this.Close();
            view.Show();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e) {
            var view = new Recepten { bsView = this.bsView };
            view.Top = 200;
            view.Left = 400;
            this.Close();
            view.Show();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e) {
            var view = new Beheer { bsView = this.bsView };
            view.Top = 200;
            view.Left = 400;
            this.Close();
            view.Show();
        }
    }
}
