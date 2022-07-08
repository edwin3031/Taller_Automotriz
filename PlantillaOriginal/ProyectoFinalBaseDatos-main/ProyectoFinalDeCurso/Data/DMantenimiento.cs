using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinalDeCurso.Data
{
    public class DMantenimiento
    {
        public static DataTable Mostrar_Mantenimientos()
        {
            DataTable dt = new DataTable("Mostrar_Mantenimientos");

            try
            {
                SqlConnection conexion = new SqlConnection() {
                    ConnectionString = Conexion.conexion
                };

                SqlCommand comando = new SqlCommand()
                {
                    Connection = conexion,
                    CommandText = "Mostrar_Mantenimientos",
                    CommandType = CommandType.StoredProcedure
                };

                SqlDataAdapter reader = new SqlDataAdapter(comando);
                reader.Fill(dt);

            }catch(Exception e)
            {
                dt = null;
                MessageBox.Show("Error :" + e.Message, "Error interno BD",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }

        public static DataTable Buscar_Mantenimientos( string dato)
        {
            DataTable DtResultado = new DataTable("InsertarCliente");
            SqlConnection SqlCon = new SqlConnection();
            try
            {    // Cargando el conexión al servidor
                SqlCon.ConnectionString = Conexion.conexion;
                // Creando un objeto SQLCommand que llamará al procedimiento almacenado
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "Buscar_Mantenimientos";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //   Cargando el parámetro de búsqueda en el procedimiento almacenado
                SqlParameter Partexto = new SqlParameter();
                Partexto.ParameterName = "@dato";
                Partexto.SqlDbType = SqlDbType.VarChar;
                Partexto.Size = 100;
                Partexto.Value = dato;
                SqlCmd.Parameters.Add(Partexto);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }

        public static string Insertar_Mantenimiento(int idVehiculo,int idMecanico,int idServicio,string fechaeEntrada,string fechaSalida)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Código
                SqlCon.ConnectionString = Conexion.conexion;
                SqlCon.Open();
                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "Insertar_Mantenimiento";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // Parámetros del Procedimiento Almacenad

                SqlParameter ParIdVehiculo = new SqlParameter();
                ParIdVehiculo.ParameterName = "@IdVehiculo";
                ParIdVehiculo.SqlDbType = SqlDbType.Int;

                ParIdVehiculo.Value = idVehiculo;
                SqlCmd.Parameters.Add(ParIdVehiculo);

                SqlParameter ParIdMecanico = new SqlParameter();
                ParIdMecanico.ParameterName = "@IdMecanico";
                ParIdMecanico.SqlDbType = SqlDbType.Int;
                ParIdMecanico.Value = idMecanico;
                SqlCmd.Parameters.Add(ParIdMecanico);

                SqlParameter ParIdServicio = new SqlParameter();
                ParIdServicio.ParameterName = "@IdServicio";
                ParIdServicio.SqlDbType = SqlDbType.Int;
                ParIdServicio.Value = idServicio;
                SqlCmd.Parameters.Add(ParIdServicio);

                SqlParameter ParFechaEntrada = new SqlParameter();
                ParFechaEntrada.ParameterName = "@FechaEntrada";
                ParFechaEntrada.SqlDbType = SqlDbType.Date;
                ParFechaEntrada.Value = fechaeEntrada;
                SqlCmd.Parameters.Add(ParFechaEntrada);

                SqlParameter ParFechaSalida = new SqlParameter();
                ParFechaSalida.ParameterName = "@FechaSalida";
                ParFechaSalida.SqlDbType = SqlDbType.Date;
                ParFechaSalida.Value = fechaSalida;
                SqlCmd.Parameters.Add(ParFechaSalida);



                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;

        }


        public static string Aignar_Servicio(int idMantenimiento, int idMecanico, int idServicio)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Código
                SqlCon.ConnectionString = Conexion.conexion;
                SqlCon.Open();
                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "Asignar_Servicio";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // Parámetros del Procedimiento Almacenad

                SqlParameter ParIdMantenimiento = new SqlParameter();
                ParIdMantenimiento.ParameterName = "@IdMantenimiento";
                ParIdMantenimiento.SqlDbType = SqlDbType.Int;

                ParIdMantenimiento.Value = idMantenimiento;
                SqlCmd.Parameters.Add(ParIdMantenimiento);

                SqlParameter ParIdMecanico = new SqlParameter();
                ParIdMecanico.ParameterName = "@IdMecanico";
                ParIdMecanico.SqlDbType = SqlDbType.Int;
                ParIdMecanico.Value = idMecanico;
                SqlCmd.Parameters.Add(ParIdMecanico);

                SqlParameter ParIdServicio = new SqlParameter();
                ParIdServicio.ParameterName = "@IdServicio";
                ParIdServicio.SqlDbType = SqlDbType.Int;
                ParIdServicio.Value = idServicio;
                SqlCmd.Parameters.Add(ParIdServicio);



                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;

        }

        public static DataTable Historial_De_Servicios(int idVehiculo)
        {
            DataTable DtResultado = new DataTable("Historial_Vehiculo_Servicios");
            SqlConnection SqlCon = new SqlConnection();
            try
            {    // Cargando el conexión al servidor
                SqlCon.ConnectionString = Conexion.conexion;
                // Creando un objeto SQLCommand que llamará al procedimiento almacenado
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "Historial_Vehiculo_Servicios";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //   Cargando el parámetro de búsqueda en el procedimiento almacenado
                SqlParameter Partexto = new SqlParameter();
                Partexto.ParameterName = "@IdVehiculo";
                Partexto.SqlDbType = SqlDbType.Int;
                Partexto.Value = idVehiculo;
                SqlCmd.Parameters.Add(Partexto);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }
    }
}
