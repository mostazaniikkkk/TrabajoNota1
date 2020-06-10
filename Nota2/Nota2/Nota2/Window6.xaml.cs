using System;
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
    /// Lógica de interacción para Window6.xaml
    /// </summary>
    public partial class Window6 : Window
    {
        public Window6()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            win6 = this;
            estadoCivil.SelectedIndex = 0;
            estadoCivil.Items.Add("Seleccionar");
            estadoCivil.Items.Add("Soltero");
            estadoCivil.Items.Add("Casado");
            estadoCivil.Items.Add("Viudo");
            estadoCivil.Items.Add("Cónyuge");

        }
        internal static Window6 win6;
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
            Window5 win5 = new Window5();

            Window5.win5.Status = lblRut.Content.ToString();
            Window5.win5.Status1 = lblUser.Content.ToString();

            this.Close();
            win5.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                txtNombreCliente.Tag = Conexion.devolverNombreCliente(txtRutCliente.Text);
                txtApellidoCliente.Tag = Conexion.devolverApellidoCliente(txtRutCliente.Text);
                fechaNacimiento.Text = Conexion.devolverFechaCliente(txtRutCliente.Text);
                string estado = Conexion.devolverEstadoCivilCliente(txtRutCliente.Text);
                if (estado == "Soltero")
                {
                    estadoCivil.SelectedIndex = estadoCivil.SelectedIndex + 1;

                }
                if (estado == "Casado")
                {
                    estadoCivil.SelectedIndex = estadoCivil.SelectedIndex + 2;
                }
                if (estado == "Viudo")
                {
                    estadoCivil.SelectedIndex = estadoCivil.SelectedIndex + 3;
                }
                if (estado == "Cónyuge")
                {
                    estadoCivil.SelectedIndex = estadoCivil.SelectedIndex + 4;
                }

                string genero = Conexion.devolverGeneroCliente(txtRutCliente.Text);
                if (genero.Equals("F "))
                {
                    rFemenino.IsChecked = true;
                }
                else if (genero.Equals("M "))
                {
                    rMasculino.IsChecked = true;
                }

                tablax.ItemsSource = Conexion.BuscarContrato(txtRutCliente.Text);

                estadoCivil.IsEnabled = true;
            }
            catch(Exception)
            {
                MessageBoxResult result = MessageBox.Show("Error, rut ingresado no existe en la base de datos...");
                Console.WriteLine(result);
            }


        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Conexion.eliminarCliente(txtRutCliente.Text);
            Conexion.eliminarContrato(txtRutCliente.Text);

            MessageBoxResult result = MessageBox.Show("Cliente y contratos vinculados eliminados correctamente!");
            Console.WriteLine(result);

            tablax.ItemsSource = Conexion.BuscarContrato(txtRutCliente.Text);

            txtRutCliente.Text = "";
            txtNombreCliente.Text = "";
            txtApellidoCliente.Text = "";
            fechaNacimiento.Text = "";
            estadoCivil.SelectedIndex = 0;
            if (rFemenino.IsChecked == true)
            {
                rFemenino.IsChecked = false;
            }
            else if (rMasculino.IsChecked == true)
            {
                rMasculino.IsChecked = false;
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtNombreCliente.Text != "")
                {
                    Conexion.modificarClienteNombre(txtRutCliente.Text, txtNombreCliente.Text);
                }
                if (txtApellidoCliente.Text != "")
                {
                    Conexion.modificarClienteApellido(txtRutCliente.Text, txtApellidoCliente.Text);
                }
                if (estadoCivil.SelectedItem.ToString() != "Seleccionar")
                {
                    Conexion.modificarClienteEstado(txtRutCliente.Text, estadoCivil.SelectedItem.ToString());
                }
                MessageBoxResult result = MessageBox.Show("Datos modificados correctamente!");
                Console.WriteLine(result);
            }
            catch(Exception)
            {
                MessageBoxResult result = MessageBox.Show("Error, no se pudieron modificar los datos...");
                Console.WriteLine(result);
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            txtRutCliente.Text = "";
            txtNombreCliente.Tag = "";
            txtApellidoCliente.Tag = "";
            fechaNacimiento.Text = "";
            estadoCivil.SelectedIndex = 0;
            if (rFemenino.IsChecked == true)
            {
                rFemenino.IsChecked = false;
            }
            else if (rMasculino.IsChecked == true)
            {
                rMasculino.IsChecked = false;
            }
        }
    }
}
