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
    public class DAsignarRepuesto
    {
        public static DataTable Mostrar_Mantenimiento_Mecanico()
        {
            DataTable dt = new DataTable("Mostrar_Mantenimiento_Mecanico");

            try
            {
                SqlConnection conexion = new SqlConnection(Conexion.conexion);
                conexion.Open();

                SqlCommand comando = new SqlCommand()
                {
                    Connection = conexion,
                    CommandText = "Mostrar_Mantenimiento_Mecanico",
                    CommandType = CommandType.StoredProcedure
                };

                

              

                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                adapter.Fill(dt);


            }catch(Exception e)
            {
                dt = null;
                MessageBox.Show("Error: " + e.Message, "Error interno en Data",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }

            return dt;
        }

        public static DataTable Mostrar_Mantenimientos_Servicios(int idMantenimiento)
        {
            DataTable dt = new DataTable("Mostrar_Mantenimientos_Servicios");

            try
            {
                SqlConnection conexion = new SqlConnection(Conexion.conexion);
                conexion.Open();

                SqlCommand comando = new SqlCommand()
                {
                    Connection = conexion,
                    CommandText = "Mostrar_Mantenimientos_Servicios",
                    CommandType = CommandType.StoredProcedure
                };
                SqlParameter ParID = new SqlParameter()
                {
                    ParameterName = "IdMantenimiento",
                    SqlDbType = SqlDbType.Int,
                    Value = idMantenimiento,


                };

                comando.Parameters.Add(ParID);
                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                adapter.Fill(dt);

            }
            catch (Exception e)
            {
                dt = null;
                MessageBox.Show("Error: " + e.Message, "Error interno en Data",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }

        public static DataTable Mostrar_Servicios_Repuestos(int idDetalleMantenimiento)
        {
            DataTable dt = new DataTable("Mostrar_Servicios_Repuestos");

            try
            {
                SqlConnection conexion = new SqlConnection(Conexion.conexion);
                conexion.Open();

                SqlCommand comando = new SqlCommand()
                {
                    Connection = conexion,
                    CommandText = "Mostrar_Servicios_Repuestos",
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter ParID = new SqlParameter()
                {
                    ParameterName="IdDetalleMantenimiento",
                    SqlDbType=SqlDbType.Int,
                    Value=idDetalleMantenimiento,


                };

                comando.Parameters.Add(ParID);
                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                adapter.Fill(dt);


            }
            catch (Exception e)
            {
                dt = null;
                MessageBox.Show("Error: " + e.Message, "Error interno en Data",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;

        }

        public static string Aignar_Repuesto(int idDetalleMantenimiento, int idRepuesto, int cantidad)
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
                SqlCmd.CommandText = "Asignar_Repuesto";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // Parámetros del Procedimiento Almacenad

                SqlParameter ParIdMantenimiento = new SqlParameter();
                ParIdMantenimiento.ParameterName = "@IdDetalleMantenimiento";
                ParIdMantenimiento.SqlDbType = SqlDbType.Int;

                ParIdMantenimiento.Value = idDetalleMantenimiento;
                SqlCmd.Parameters.Add(ParIdMantenimiento);

                SqlParameter ParIdRepuesto = new SqlParameter();
                ParIdRepuesto.ParameterName = "@IdRepuesto";
                ParIdRepuesto.SqlDbType = SqlDbType.Int;
                ParIdRepuesto.Value = idRepuesto;
                SqlCmd.Parameters.Add(ParIdRepuesto);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@Cantidad";
                ParCantidad.SqlDbType = SqlDbType.Int;
                ParCantidad.Value = cantidad;
                SqlCmd.Parameters.Add(ParCantidad);



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
    }
}
