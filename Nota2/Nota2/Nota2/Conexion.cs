using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Nota2
{
    class Conexion
    {
        static string connectionString = @"Server=DESKTOP-3FLS338; Database=REGISTRO; Trusted_Connection=True;";

        public static int VerificarUsuario(string rut, string contraseña)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(null, connection);
                command.CommandText = "SELECT id_usuario FROM REGISTRO WHERE rut_usuario = @rut AND contraseña_usuario = @contraseña";

                command.Parameters.AddWithValue("@rut", rut);
                command.Parameters.AddWithValue("@contraseña", contraseña);



                //Abrir conexión y ejecutar query
                connection.Open();
                Int32 rowsAffected = command.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(command);

                DataTable dt = new DataTable();

                dt.Clear();
                da.Fill(dt);


                int number = 0;
                do
                {
                    if (dt.Rows[0][0].ToString() != null)
                    {
                        if (int.Parse(dt.Rows[0][0].ToString()) > 0)
                        {
                            int id = int.Parse(dt.Rows[0][0].ToString());
                            number = id;
                            MessageBoxResult result = MessageBox.Show("Iniciando sesión...");
                            Console.WriteLine(result);

                        }
                        connection.Close();

                        return number;
                    }
                } while (true);
            }
        }

        public static void NombreUsuario(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(null, connection);
                command.CommandText = "SELECT rut_usuario, nombre_usuario FROM REGISTRO WHERE id_usuario = @id";

                command.Parameters.AddWithValue("@id", id);


                //Abrir conexión y ejecutar query
                connection.Open();
                Int32 rowsAffected = command.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(command);

                DataTable dt = new DataTable();

                dt.Clear();
                da.Fill(dt);

                string nombre = dt.Rows[0][0].ToString();
                string rut = dt.Rows[0][1].ToString();

                Window1.win1.Status = nombre.ToUpper();
                Window1.win1.Status1 = rut.ToUpper();

                connection.Close();
            }
        }
    }
}
