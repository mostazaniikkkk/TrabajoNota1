using Microsoft.VisualBasic.ApplicationServices;
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
        public static List<User> lista;
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

        public static string RutUsuario(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(null, connection);
                command.CommandText = "SELECT rut_usuario FROM REGISTRO WHERE id_usuario = @id";

                command.Parameters.AddWithValue("@id", id);


                //Abrir conexión y ejecutar query
                connection.Open();
                Int32 rowsAffected = command.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(command);

                DataTable dt = new DataTable();

                dt.Clear();
                da.Fill(dt);

                //string nombre = dt.Rows[0][0].ToString();
                string rut = dt.Rows[0][0].ToString();

                //Window1.win1.Status = nombre.ToUpper();
                //Window1.win1.Status1 = rut.ToUpper();
                
                connection.Close();
                return rut;
            }
        }

        public static string NombreUsuario(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(null, connection);
                command.CommandText = "SELECT nombre_usuario FROM REGISTRO WHERE id_usuario = @id";

                command.Parameters.AddWithValue("@id", id);


                //Abrir conexión y ejecutar query
                connection.Open();
                Int32 rowsAffected = command.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(command);

                DataTable dt = new DataTable();

                dt.Clear();
                da.Fill(dt);

                //string nombre = dt.Rows[0][0].ToString();
                string nombre = dt.Rows[0][0].ToString();

                //Window1.win1.Status = nombre.ToUpper();
                //Window1.win1.Status1 = rut.ToUpper();

                connection.Close();
                return nombre;
            }
        }

        public static List<User> BuscarUsuario(string rut)
        {
            using (SqlConnection connection = new SqlConnection(connectionString)){

                SqlCommand command = new SqlCommand(null, connection);

                command.CommandText = "SELECT * FROM DBO.REGISTRO WHERE rut_usuario = @rut";
                command.Parameters.AddWithValue("@rut", rut);

                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                da.Fill(dt);

                lista = new List<User>();

                foreach (DataRow row in dt.Rows)
                {
                    User user = new User();
                    user.Id = row["id_usuario"].ToString();
                    user._Rut = row["rut_usuario"].ToString();
                    user._Usuario = row["nombre_usuario"].ToString();
                    user.Contraseña = row["contraseña_usuario"].ToString();
                    user.Foto = row["foto_usuario"].ToString();
                    lista.Add(user);

                    
                }
                return lista;
            }
        }
    }
}
