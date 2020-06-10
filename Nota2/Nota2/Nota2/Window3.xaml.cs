using System;
using System.Windows;

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
            estadoCivil.SelectedIndex = estadoCivil.SelectedIndex + 1;
            estadoCivil.Items.Add("Seleccionar");
            estadoCivil.Items.Add("Soltero");
            estadoCivil.Items.Add("Casado");
            estadoCivil.Items.Add("Viudo");
            estadoCivil.Items.Add("Cónyuge");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtRut.Text != "" && txtNombre.Text != "" && txtApellido.Text != "" && estadoCivil.SelectedIndex > -1 && fechaNacimiento.Text != "" && rMasculino.IsChecked != false || rFemenino.IsChecked != false)
            {
                try
                {
                    int entero = Conexion.BuscarRutCliente(txtRut.Text);
                    Console.WriteLine(entero+".enteroxd");

                    if (entero == 0)
                    {

                        if (rFemenino.IsChecked == true)
                        {
                            Console.WriteLine("Haliox");
                            Conexion.AgregarCliente(txtRut.Text, txtNombre.Text, txtApellido.Text, estadoCivil.SelectedItem.ToString(), fechaNacimiento.Text, 'F');
                            MessageBoxResult result = MessageBox.Show("Datos ingresados exitosamente!");

                            Console.WriteLine(result);
                        }
                        else if (rMasculino.IsChecked == true)
                        {
                            Console.WriteLine("Haloxexfsad");
                            Conexion.AgregarCliente(txtRut.Text, txtNombre.Text, txtApellido.Text, estadoCivil.SelectedItem.ToString(), fechaNacimiento.Text, 'M');
                            MessageBoxResult result = MessageBox.Show("Datos ingresados exitosamente!");

                            Console.WriteLine(result);
                        }

                        txtRut.Text = "";
                        txtNombre.Text = "";
                        txtApellido.Text = "";
                        estadoCivil.SelectedIndex = 0;
                        fechaNacimiento.Text = "";
                        if (rFemenino.IsChecked == true)
                        {
                            rFemenino.IsChecked = false;
                        }
                        if (rMasculino.IsChecked == true)
                        {
                            rMasculino.IsChecked = false;
                        }
                    }
                    else
                    {
                        MessageBoxResult result = MessageBox.Show("Error, rut ingresado ya existe en la base de datos...");
                        Console.WriteLine(result);
                    }
                    
                }


                catch (Exception)
                {
                    MessageBoxResult result = MessageBox.Show("Error, rut ingresado ya existe en la base de datos...");
                    Console.WriteLine(result);
                }
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Error, rellene todos los campos...");
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

            Window1.win1.Status2 = Conexion.TraerUltimosNombres();
            Window1.win1.Status3 = Conexion.TraerPenultimosNombres();

            Window1.win1.Status4 = Conexion.TraerUltimoContrato();
            Window1.win1.Status5 = Conexion.TraerPenultimoContrato();

            this.Close();
            win1.Show();
        }
    }
}


