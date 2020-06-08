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
using System.Windows.Shapes;

namespace Nota2
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            win1 = this;
        }
        User usuario = new User();

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            Window5 win5 = new Window5();

            Window5.win5.Status = lblRut.Content.ToString();
            Window5.win5.Status1 = lblUser.Content.ToString();

            win5.Show();
            this.Close();
        }

        internal static Window1 win1;
        internal string Status
        {
            get { return lblRut.Content.ToString(); }
            set { Dispatcher.Invoke(new Action(() => { lblRut.Content = value; })); }
        }
        internal string Status1
        {
            get { return lblUser.Content.ToString(); }
            set { Dispatcher.Invoke(new Action(() => { lblUser.Content = value; })); }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window3 win3 = new Window3();

            Window3.win3.Status = lblRut.Content.ToString();
            Window3.win3.Status1 = lblUser.Content.ToString();

            win3.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window2 win2 = new Window2();

            Window2.win2.Status = lblRut.Content.ToString();
            Window2.win2.Status1 = lblUser.Content.ToString();

            this.Close();
            win2.Show();
        }
    }
}
