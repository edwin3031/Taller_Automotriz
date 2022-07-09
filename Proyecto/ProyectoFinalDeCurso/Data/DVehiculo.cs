using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalDeCurso.Data
{
    class DVehiculo
    {
        public static DataTable Mostrar_Vehiculo()
        {
            DataTable DtResultado = new DataTable("MostrarVehiculo");
            SqlConnection SqlCon = new SqlConnection();
            try
            {    // Cargando el conexión al servidor
                SqlCon.ConnectionString = Conexion.conexion;
                // Creando un objeto SQLCommand que llamará al procedimiento almacenado
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "Mostrar_Vehiculo";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }

        public static DataTable Buscar_Vehiculo(string texto)
        {
            DataTable DtResultado = new DataTable("MostrarVehiculo");
            SqlConnection SqlCon = new SqlConnection();
            try
            {    // Cargando el conexión al servidor
                SqlCon.ConnectionString = Conexion.conexion;
                // Creando un objeto SQLCommand que llamará al procedimiento almacenado
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "Buscar_Vehiculo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //   Cargando el parámetro de búsqueda en el procedimiento almacenado
                SqlParameter Partexto = new SqlParameter();
                Partexto.ParameterName = "@dato";
                Partexto.SqlDbType = SqlDbType.VarChar;
                Partexto.Size = 60;
                Partexto.Value = texto;
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

        public static string Insertar_Vehiculo(int id, string marca, string modelo, int año) 
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
                SqlCmd.CommandText = "Insertar_Vehiculo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // Parámetros del Procedimiento Almacenad

                SqlParameter nombre = new SqlParameter();
                nombre.ParameterName = "@IdCliente";
                nombre.SqlDbType = SqlDbType.Int;
                nombre.Value = id;
                SqlCmd.Parameters.Add(nombre);

                SqlParameter marcaV = new SqlParameter();
                marcaV.ParameterName = "@marca";
                marcaV.SqlDbType = SqlDbType.VarChar;
                marcaV.Size = 20;
                marcaV.Value = marca;
                SqlCmd.Parameters.Add(marcaV);

                SqlParameter modeloV = new SqlParameter();
                modeloV.ParameterName = "@modelo";
                modeloV.SqlDbType = SqlDbType.VarChar;
                modeloV.Size = 20;
                modeloV.Value = modelo;
                SqlCmd.Parameters.Add(modeloV);

                SqlParameter añoV = new SqlParameter();
                añoV.ParameterName = "aAño";
                añoV.SqlDbType = SqlDbType.Int;
                añoV.Value = año;
                SqlCmd.Parameters.Add(añoV);

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

        public static string Actualizar_Vehiculo(int IdVehiculo,int idCliente, string marca, string modelo, int año)
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
                SqlCmd.CommandText = "Editar_Vehiculo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // Parámetros del Procedimiento Almacenad

                SqlParameter ParIdVehiculo = new SqlParameter();
                ParIdVehiculo.ParameterName = "@Idvehiculo";
                ParIdVehiculo.SqlDbType = SqlDbType.Int;

                ParIdVehiculo.Value = IdVehiculo;
                SqlCmd.Parameters.Add(ParIdVehiculo);

                SqlParameter ParIdCliente = new SqlParameter();
                ParIdCliente.ParameterName = "@IdCliente";
                ParIdCliente.SqlDbType = SqlDbType.Int;
                ParIdCliente.Value = idCliente;
                SqlCmd.Parameters.Add(ParIdCliente);

                SqlParameter marcaV = new SqlParameter();
                marcaV.ParameterName = "@Marca";
                marcaV.SqlDbType = SqlDbType.VarChar;
                marcaV.Size = 20;
                marcaV.Value = marca;
                SqlCmd.Parameters.Add(marcaV);

                SqlParameter modeloV = new SqlParameter();
                modeloV.ParameterName = "@Modelo";
                modeloV.SqlDbType = SqlDbType.VarChar;
                modeloV.Size = 20;
                modeloV.Value = modelo;
                SqlCmd.Parameters.Add(modeloV);

                SqlParameter añoV = new SqlParameter();
                añoV.ParameterName = "@Año";
                añoV.SqlDbType = SqlDbType.Int;
                añoV.Value = año;
                SqlCmd.Parameters.Add(añoV);

                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Actualizo el Registro";

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
