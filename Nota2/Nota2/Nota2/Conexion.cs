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

                string rut = dt.Rows[0][0].ToString();
                
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

                string nombre = dt.Rows[0][0].ToString();

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

        public static void AgregarCliente(string rut, string nombre, string apellido, string estado_civil, string fecha_nacimiento, char sexo)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(null, connection);

                command.CommandText = "INSERT INTO DBO.CLIENTE (rut_cliente, nombre_cliente, apellido_cliente, estado_civil, fecha_nacimiento, sexo)" + " VALUES (@rut, @nombre, @apellido, @estado_civil, @fecha_nacimiento, @sexo)";
                command.Parameters.AddWithValue("@rut", rut);
                command.Parameters.AddWithValue("@nombre", nombre);
                command.Parameters.AddWithValue("@apellido", apellido);
                command.Parameters.AddWithValue("@estado_civil", estado_civil);
                command.Parameters.AddWithValue("@fecha_nacimiento", fecha_nacimiento);
                command.Parameters.AddWithValue("@sexo", sexo);

                //Abrir conexión y ejecutar query
                try
                {
                    connection.Open();
                    Int32 rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine(rowsAffected);
                }
                catch (Exception)
                {
                    throw;
                }

                connection.Close();
            }
        }

        /*public static int EncuentraRut(string rut) 
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(null, connection);
                command.CommandText = "SELECT id_cliente FROM DBO.CLIENTE WHERE rut_cliente = @rut";
                command.Parameters.AddWithValue("@rut", rut);

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
                            connection.Close();
                            return number;

                        }
                        else
                        {
                            connection.Close();
                            return 0;
                        }
                        
                    }
                } while (true);
            }
        }*/
        public static string Date()
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(null, connection);

                command.CommandText = "SELECT CONVERT(DATE,SYSDATETIME())";

                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);

                DataTable dt = new DataTable();

                da.Fill(dt);

                string fecha = dt.Rows[0][0].ToString();

                connection.Close();
                return fecha;
            }
        }
        public static string Date1()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(null, connection);

                command.CommandText = "SELECT DATEADD(YEAR,1,CONVERT(DATE,SYSDATETIME()));";

                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);

                DataTable dt = new DataTable();

                da.Fill(dt);

                string fecha = dt.Rows[0][0].ToString();

                connection.Close();
                return fecha;
            }
        }

        public static string Date2()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(null, connection);

                command.CommandText = "SELECT DATEADD(YEAR,2,CONVERT(DATE,SYSDATETIME()));";

                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);

                DataTable dt = new DataTable();

                da.Fill(dt);

                string fecha = dt.Rows[0][0].ToString();

                connection.Close();
                return fecha;
            }
        }

        public static string Date3()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(null, connection);

                command.CommandText = "SELECT DATEADD(YEAR,3,CONVERT(DATE,SYSDATETIME()));";

                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);

                DataTable dt = new DataTable();

                da.Fill(dt);

                string fecha = dt.Rows[0][0].ToString();

                connection.Close();
                return fecha;
            }
        }

        public static void GuardarContrato(string rut, string plan, string poliza, string fechaInicio, string fechaTermino, char declaracionMedica, int primaMensual, int primaAnual, string observacion)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(null, connection);

                command.CommandText = "INSERT INTO DBO.CONTRATO (rut_contrato, plan_asociado, poliza, fecha_inicio, fecha_termino, declaracion_medica, prima_mensual, prima_anual, observacion)"+
                                        "VALUES(@rut, @plan, @poliza, @fechaInicio, @fechaTermino, @declaracionMedica, @primaMensual, @primaAnual, @observacion)";

                command.Parameters.AddWithValue("@rut", rut);
                command.Parameters.AddWithValue("@plan",plan);
                command.Parameters.AddWithValue("@poliza",poliza);
                command.Parameters.AddWithValue("@fechaInicio",fechaInicio);
                command.Parameters.AddWithValue("@fechaTermino",fechaTermino);
                command.Parameters.AddWithValue("@declaracionMedica",declaracionMedica);
                command.Parameters.AddWithValue("@primaMensual", primaMensual);
                command.Parameters.AddWithValue("@primaAnual", primaAnual);
                command.Parameters.AddWithValue("@observacion", observacion);

                Console.WriteLine("Pasa la entrada de variables temporales");
                try
                {
                    Console.WriteLine("caca");
                    connection.Open();
                    Int32 rowsAffected = command.ExecuteNonQuery();
                    
                    Console.WriteLine(rowsAffected);
                    
                }
                catch (Exception)
                {
                    throw;
                }

                connection.Close();
            }
        }
    }
}
