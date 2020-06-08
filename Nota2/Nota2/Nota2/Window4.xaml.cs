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
    /// Lógica de interacción para Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        public Window4()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            win4 = this;
        }
        
        public SqlConnection conexion = new SqlConnection(@"Server=DESKTOP-3FLS338; Database=REGISTRO; Trusted_Connection=True;");
        

        private void DataGrid_Initialized(object sender, EventArgs e)
        {
            Actualizar();
        }

        public void Actualizar()
        {
            using (SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM DBO.CONTRATO", conexion))
            {

                try
                {
                    DataTable dt = new DataTable();
                    dt.Clear();
                    da.Fill(dt);
                    tabla.ItemsSource = dt.DefaultView;
                }
                catch
                {
                    throw;
                }
            }
        }

        
        internal static Window4 win4;
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

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            tabla.ItemsSource = Conexion.BuscarContrato(txtBuscar.Text); 
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            Window1 win1 = new Window1();

            Window1.win1.Status = lblRut.Content.ToString();
            Window1.win1.Status1 = lblUser.Content.ToString();

            win1.Show();
            this.Close();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            tabla.ItemsSource = Conexion.ActualizarVigencia(); 
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            tabla.ItemsSource = Conexion.ActualizarExpiracion();
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            Actualizar();
        }
    }
}

