using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Lógica de interacción para Window5.xaml
    /// </summary>
    public partial class Window5 : Window
    {
        public Window5()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            win5 = this;
        }
        public SqlConnection conexion = new SqlConnection(@"Server=DESKTOP-3FLS338; Database=REGISTRO; Trusted_Connection=True;");
        

        public void Actualizar()
        {
            using (SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM DBO.CLIENTE ORDER BY id_cliente", conexion))
            {

                try
                {
                    DataTable dt1 = new DataTable();
                    dt1.Clear();
                    da.Fill(dt1);
                    tablax.ItemsSource = dt1.DefaultView;
                }
                catch
                {
                    throw;
                }
            }
        }

        internal static Window5 win5;
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

        private void btnBuscar_Click_1(object sender, RoutedEventArgs e)
        {

            tablax.ItemsSource = Conexion.BuscarUsuario(txtBuscar.Text);
            
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            Window1 win1 = new Window1();

            Window1.win1.Status = lblRut.Content.ToString();
            Window1.win1.Status1 = lblUser.Content.ToString();
            win1.Show();
            this.Close();
        }

        private void tabla_Initialized_1(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void btnMostrar_Click(object sender, RoutedEventArgs e)
        {
            Actualizar();
        }
    }
}
