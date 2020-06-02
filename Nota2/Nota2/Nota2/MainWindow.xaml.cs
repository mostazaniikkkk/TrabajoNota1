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
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }
        Window1 win1 = new Window1();

        public int[] user = new int[1];
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                user[0] = Conexion.VerificarUsuario(txtRut.Text, txtContraseña.Text);
                
                Conexion.NombreUsuario(user[0]);

                this.Close();
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
