using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Nota2
{
    class Conexion
    {
        static string connectionString = @"Server=DESKTOP-3FLS338; Database=REGISTRO; Trusted_Connection=True;";
        public static List<User> lista;
        public static List<Contrato> listaContrato;
        public static List<Cliente> listaCliente;
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

        public static List<Cliente> BuscarUsuario(string rut)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(null, connection);

                command.CommandText = "SELECT * FROM DBO.CLIENTE WHERE rut_cliente = @rut";
                command.Parameters.AddWithValue("@rut", rut);

                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                da.Fill(dt);

                listaCliente = new List<Cliente>();

                foreach (DataRow row in dt.Rows)
                {
                    Cliente cliente = new Cliente();
                    cliente.Id_cliente = row["ID_CLIENTE"].ToString();
                    cliente._Rut = row["RUT_CLIENTE"].ToString();
                    cliente._Nombre_cliente = row["NOMBRE_CLIENTE"].ToString();
                    cliente.Apellido_cliente = row["APELLIDO_CLIENTE"].ToString();
                    cliente.Fecha_nacimiento = row["FECHA_NACIMIENTO"].ToString();
                    cliente.Sexo = row["SEXO"].ToString();
                    cliente.Estado_civil = row["ESTADO_CIVIL"].ToString();
                    listaCliente.Add(cliente);

                }
                return listaCliente;
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

        public static string TraerPenultimosNombres()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(null, connection);

                command.CommandText = "SELECT rut_cliente, nombre_cliente FROM dbo.cliente where id_cliente = (select max(id_cliente) from dbo.cliente)";

                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                da.Fill(dt);

                string nombres = "Rut: "+dt.Rows[0][0].ToString() +"  -  Nombre: "+ dt.Rows[0][1].ToString();

                return nombres;
            }
        }

        public static string TraerUltimosNombres()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(null, connection);

                command.CommandText = "SELECT rut_cliente, nombre_cliente FROM dbo.cliente where id_cliente = (select max(id_cliente)-1 from dbo.cliente)";

                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                da.Fill(dt);

                string nombres = "Rut: " + dt.Rows[0][0].ToString() + "  -  Nombre: " + dt.Rows[0][1].ToString();

                return nombres;
            }
        }
        public static string TraerUltimosContrato()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(null, connection);

                command.CommandText = "SELECT rut_cliente, nombre_cliente FROM dbo.cliente where id_cliente = (select max(id_cliente)-1 from dbo.cliente)";

                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                da.Fill(dt);

                string nombres = "Rut: " + dt.Rows[0][0].ToString() + "  -  Nombre: " + dt.Rows[0][1].ToString();

                return nombres;
            }
        }

        public static string TraerPenultimoContrato()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(null, connection);

                command.CommandText = "SELECT rut_cliente, nombre_cliente FROM dbo.cliente where id_cliente = (select max(id_cliente) from dbo.cliente)";

                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                da.Fill(dt);

                string nombres = "Rut: " + dt.Rows[0][0].ToString() + "  -  Nombre: " + dt.Rows[0][1].ToString();

                return nombres;
            }
        }

        public static string Date()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
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

                command.CommandText = "INSERT INTO DBO.CONTRATO (rut_contrato, plan_asociado, poliza, fecha_inicio, fecha_termino, declaracion_medica, prima_mensual, prima_anual, observacion)" +
                                        "VALUES(@rut, @plan, @poliza, @fechaInicio, @fechaTermino, @declaracionMedica, @primaMensual, @primaAnual, @observacion)";

                command.Parameters.AddWithValue("@rut", rut);
                command.Parameters.AddWithValue("@plan", plan);
                command.Parameters.AddWithValue("@poliza", poliza);
                command.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                command.Parameters.AddWithValue("@fechaTermino", fechaTermino);
                command.Parameters.AddWithValue("@declaracionMedica", declaracionMedica);
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

        public static List<Contrato> BuscarContrato(string rut)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(null, connection);

                command.CommandText = "SELECT * FROM DBO.CONTRATO WHERE rut_contrato = @rut";
                command.Parameters.AddWithValue("@rut", rut);

                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                da.Fill(dt);

                listaContrato = new List<Contrato>();

                foreach (DataRow row in dt.Rows)
                {
                    Contrato contrato = new Contrato();
                    contrato.Nro_contrato = row["NRO_CONTRATO"].ToString();
                    contrato._Rut_contrato = row["RUT_CONTRATO"].ToString();
                    contrato.Plan_asociado = row["PLAN_ASOCIADO"].ToString();
                    contrato.Poliza = row["POLIZA"].ToString();
                    contrato.Fecha_inicio = row["FECHA_INICIO"].ToString();
                    contrato.Fecha_termino = row["FECHA_TERMINO"].ToString();
                    contrato.Declaracion_medica = row["DECLARACION_MEDICA"].ToString();
                    contrato.Prima_mensual = row["PRIMA_MENSUAL"].ToString();
                    contrato.Prima_anual = row["PRIMA_ANUAL"].ToString();
                    contrato.Observacion = row["OBSERVACION"].ToString();

                    listaContrato.Add(contrato);


                }
                return listaContrato;
            }
        }

        public static List<Contrato> ActualizarVigencia()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(null, connection);

                command.CommandText = "SELECT * FROM DBO.CONTRATO WHERE DATEDIFF(DAY, CONVERT(DATE, SYSDATETIME()), fecha_termino) > 0";

                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                da.Fill(dt);

                listaContrato = new List<Contrato>();

                foreach (DataRow row in dt.Rows)
                {
                    Contrato contrato = new Contrato();
                    contrato.Nro_contrato = row["NRO_CONTRATO"].ToString();
                    contrato._Rut_contrato = row["RUT_CONTRATO"].ToString();
                    contrato.Plan_asociado = row["PLAN_ASOCIADO"].ToString();
                    contrato.Poliza = row["POLIZA"].ToString();
                    contrato.Fecha_inicio = row["FECHA_INICIO"].ToString();
                    contrato.Fecha_termino = row["FECHA_TERMINO"].ToString();
                    contrato.Declaracion_medica = row["DECLARACION_MEDICA"].ToString();
                    contrato.Prima_mensual = row["PRIMA_MENSUAL"].ToString();
                    contrato.Prima_anual = row["PRIMA_ANUAL"].ToString();
                    contrato.Observacion = row["OBSERVACION"].ToString();

                    listaContrato.Add(contrato);
                }
                return listaContrato;
            }
        }

        public static List<Contrato> ActualizarExpiracion()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(null, connection);

                command.CommandText = "SELECT * FROM DBO.CONTRATO WHERE DATEDIFF(DAY, CONVERT(DATE, SYSDATETIME()), fecha_termino) <= 0";

                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                da.Fill(dt);

                listaContrato = new List<Contrato>();

                foreach (DataRow row in dt.Rows)
                {
                    Contrato contrato = new Contrato();
                    contrato.Nro_contrato = row["NRO_CONTRATO"].ToString();
                    contrato._Rut_contrato = row["RUT_CONTRATO"].ToString();
                    contrato.Plan_asociado = row["PLAN_ASOCIADO"].ToString();
                    contrato.Poliza = row["POLIZA"].ToString();
                    contrato.Fecha_inicio = row["FECHA_INICIO"].ToString();
                    contrato.Fecha_termino = row["FECHA_TERMINO"].ToString();
                    contrato.Declaracion_medica = row["DECLARACION_MEDICA"].ToString();
                    contrato.Prima_mensual = row["PRIMA_MENSUAL"].ToString();
                    contrato.Prima_anual = row["PRIMA_ANUAL"].ToString();
                    contrato.Observacion = row["OBSERVACION"].ToString();

                    listaContrato.Add(contrato);
                }
                return listaContrato;
            }
        }

        public static string BuscarRutContrato(string rut)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(null, connection);
                command.CommandText = "SELECT rut_cliente FROM DBO.CLIENTE WHERE rut_cliente = @rut";
                command.Parameters.AddWithValue("@rut", rut);

                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);

                Console.WriteLine("comando:"+command);
                DataTable dt = new DataTable();

                da.Fill(dt);

                if (dt.Rows[0][0].ToString().Length > 0){
                    string rutComprobar = dt.Rows[0][0].ToString();
                    Console.WriteLine(rutComprobar);

                    connection.Close();
                    return rutComprobar;
                }
                else
                {
                    connection.Close();
                    return "";
                }
                
            }
        }

        public static string BuscarRutCliente(string rut)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(null, connection);
                command.CommandText = "SELECT rut_cliente FROM DBO.CLIENTE WHERE rut_cliente = @rut";
                command.Parameters.AddWithValue("@rut", rut);

                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                //DataTable dt = new DataTable();

                //da.Fill(dt);

                int RecordCount = Convert.ToInt32(command.ExecuteScalar());
                if (RecordCount > 0)
                {
                    //string rutComprobar = dt.Rows[0][0].ToString();
                    //Console.WriteLine(rutComprobar);

                    connection.Close();
                    return "1";
                }
                else
                {
                    return "0";
                }

            }
        }

        public static void GuardarUltimaConexion(string rut, string contraseña)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(null, connection);

                command.CommandText = "INSERT INTO DBO.ULTIMA_CONEXION (recordar_conexion_rut, recordar_contraseña)" + " VALUES (@rut, @contraseña)";
                command.Parameters.AddWithValue("@rut", rut);
                command.Parameters.AddWithValue("@contraseña", contraseña);

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

        public static int DevolverCount()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(null, connection);

                command.CommandText = "SELECT COUNT(*) FROM DBO.ULTIMA_CONEXION";

                //Abrir conexión y ejecutar query
                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);

                DataTable dt = new DataTable();

                da.Fill(dt);

                int count = int.Parse(dt.Rows[0][0].ToString());


                connection.Close();
                return count;
                
            }
        }

        public static void EliminarPrimerGuardado()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(null, connection);

                command.CommandText = "DELETE FROM DBO.ULTIMA_CONEXION";

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

        public static string SeleccionarUltimoRut()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(null, connection);

                command.CommandText = "SELECT recordar_conexion_rut FROM DBO.ULTIMA_CONEXION";

                //Abrir conexión y ejecutar query
                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);

                DataTable dt = new DataTable();

                da.Fill(dt);

                string rut = dt.Rows[0][0].ToString();


                connection.Close();
                return rut;

            }
        }

        public static string SeleccionarUltimaContraseña()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(null, connection);

                command.CommandText = "SELECT recordar_contraseña FROM DBO.ULTIMA_CONEXION";

                //Abrir conexión y ejecutar query
                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);

                DataTable dt = new DataTable();

                da.Fill(dt);

                string contraseña = dt.Rows[0][0].ToString();


                connection.Close();
                return contraseña;

            }
        }
    }
}