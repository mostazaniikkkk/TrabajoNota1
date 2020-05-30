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
        }
        Window1 win1 = new Window1();
        Conexion cx = new Conexion();
        public int[] user = new int[1];
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                //lblID.Content = user[0] = cx.VerificarUsuario(txtUsuario.Text, txtContraseña.Text);
                user[0] = cx.VerificarUsuario(txtUsuario.Text, txtContraseña.Text);
                //lblID.Content = cx.VerificarUsuario(txtUsuario.Text, txtContraseña.Text);
                //this.Close();
                //cx.NombreUsuario(user[0]); 

                win1.Show();
            }
            catch (Exception)
            {
                MessageBoxResult result = MessageBox.Show("Error, usuario inválido...");
                Console.WriteLine(result);
            }
        }
    }
}
