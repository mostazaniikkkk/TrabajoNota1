using System;
using System.Collections.Generic;
using System.Data;
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

namespace Nota2
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            main = this;
        }
        User usuario = new User();

        public int[] user = new int[1];
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Window1 win1 = new Window1();
                user[0] = Conexion.VerificarUsuario(txtRut.Text, txtContraseña.Password);

                string usuariox = Conexion.NombreUsuario(user[0]);
                string rut = Conexion.RutUsuario(user[0]);

                usuario._Rut = rut;
                usuario._Usuario = usuariox;

                Window1.win1.Status = usuario._Usuario;
                Window1.win1.Status1 = usuario._Rut;

                Window1.win1.Status2 = Conexion.TraerUltimosNombres();
                Window1.win1.Status3 = Conexion.TraerPenultimosNombres();

                this.Close();

                Window1.win1.Show();

            }
            catch (Exception)
            {
                txtRut.Text = "";
                txtContraseña.Password = "";
                MessageBoxResult result = MessageBox.Show("Error, usuario inválido...");
                Console.WriteLine(result);
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if(txtRut.Text != null && txtContraseña.Password != null) 
            {
                for(int i = 0; i < 2; i++)
                {
                    if (Conexion.DevolverCount() == 0)
                    {
                        Conexion.GuardarUltimaConexion(txtRut.Text, txtContraseña.Password);
                        Console.WriteLine("insertados");
                        break;
                    }
                    else if (Conexion.DevolverCount() >= 1)
                    {
                        Conexion.EliminarPrimerGuardado();
                        Console.WriteLine("borrado el primero");
                    }
                }
            }
        }
        internal static MainWindow main;
        internal string Status
        {
            get { return txtRut.Text; }
            set { Dispatcher.Invoke(new Action(() => { txtRut.Text = value; })); }
        }
        internal string Status1
        {
            get { return txtContraseña.Password; }
            set { Dispatcher.Invoke(new Action(() => { txtContraseña.Password = value; })); }
        }
    }
}
