﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Lógica de interacción para Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            win3 = this;
        }

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            estadoCivil.Items.Add("Soltero");
            estadoCivil.Items.Add("Casado");
            estadoCivil.Items.Add("Viudo");
            estadoCivil.Items.Add("Cónyuge");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (rFemenino.IsChecked == true)
                {
                    Conexion.AgregarCliente(txtRut.Text, txtNombre.Text, txtApellido.Text, estadoCivil.SelectedItem.ToString(), fechaNacimiento.SelectedDate.ToString(), 'F');
                    MessageBoxResult result = MessageBox.Show("Datos ingresados exitosamente!");
                    Console.WriteLine(result);
                }
                else if (rMasculino.IsChecked == true)
                {
                    Conexion.AgregarCliente(txtRut.Text, txtNombre.Text, txtApellido.Text, estadoCivil.SelectedItem.ToString(), fechaNacimiento.SelectedDate.ToString(), 'M');
                    MessageBoxResult result = MessageBox.Show("Datos ingresados exitosamente!");
                    Console.WriteLine(result);
                }

                txtRut.Text = "";
                txtNombre.Text = "";
                txtApellido.Text = "";
                estadoCivil.SelectedIndex = -1;
                //fechaNacimiento.Text = "";
                //rMasculino.IsChecked = false;
                //rFemenino.IsChecked = false;
                
            }
            catch (Exception ex)
            {
                MessageBoxResult result = MessageBox.Show("Error, rellene todos los campos"+ex);
                Console.WriteLine(result);
            }
        }

        internal static Window3 win3;
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window1 win1 = new Window1();

            Window1.win1.Status = lblRut.Content.ToString();
            Window1.win1.Status1 = lblUser.Content.ToString();

            this.Close();
            win1.Show();
        }
    }
}


