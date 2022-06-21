using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalDeCurso.Data
{
    class DServicio
    {
        public static DataTable Mostrar_Servicio()
        {
            DataTable DtResultado = new DataTable("MostrarServicio");
            SqlConnection SqlCon = new SqlConnection();
            try
            {    // Cargando el conexión al servidor
                SqlCon.ConnectionString = Conexion.conexion;
                // Creando un objeto SQLCommand que llamará al procedimiento almacenado
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "Mostrar_Servicios";
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

        public static DataTable Buscar_Servicios(string texto)
        {
            DataTable DtResultado = new DataTable("BuscarServicio");
            SqlConnection SqlCon = new SqlConnection();
            try
            {    // Cargando el conexión al servidor
                SqlCon.ConnectionString = Conexion.conexion;
                // Creando un objeto SQLCommand que llamará al procedimiento almacenado
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "Buscar_Servicio";
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

        public static string Insertar_Servicio(string descripcion, decimal precio, string tipo)
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
                SqlCmd.CommandText = "Insertar_Servicio";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // Parámetros del Procedimiento Almacenado


                SqlParameter ParDescipcion = new SqlParameter();
                ParDescipcion.ParameterName = "@descripcion";
                ParDescipcion.SqlDbType = SqlDbType.VarChar;
                ParDescipcion.Size = 60;
                ParDescipcion.Value = descripcion;
                SqlCmd.Parameters.Add(ParDescipcion);

                SqlParameter ParPrecio = new SqlParameter();
                ParPrecio.ParameterName = "@precio";
                ParPrecio.SqlDbType = SqlDbType.Money;
                ParPrecio.Value = precio;
                SqlCmd.Parameters.Add(ParPrecio);


                SqlParameter ParTipo = new SqlParameter();
                ParTipo.ParameterName = "@tipo";
                ParTipo.SqlDbType = SqlDbType.VarChar;
                ParDescipcion.Size = 20;
                ParTipo.Value = tipo;
                SqlCmd.Parameters.Add(ParTipo);


                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se actualizó el Registro";

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

        public static string Actualizar_Servicio(int IdServicio, string descripcion, decimal precio, string tipo)
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
                SqlCmd.CommandText = "Editar_Servicio";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // Parámetros del Procedimiento Almacenado

                SqlParameter ParIdServicio = new SqlParameter();
                ParIdServicio.ParameterName = "@IdServicio";
                ParIdServicio.SqlDbType = SqlDbType.Int;
                ParIdServicio.Value = IdServicio;
                SqlCmd.Parameters.Add(ParIdServicio);


                SqlParameter ParDescipcion = new SqlParameter();
                ParDescipcion.ParameterName = "@descripcion";
                ParDescipcion.SqlDbType = SqlDbType.VarChar;
                ParDescipcion.Size = 60;
                ParDescipcion.Value = descripcion;
                SqlCmd.Parameters.Add(ParDescipcion);

                SqlParameter ParPrecio = new SqlParameter();
                ParPrecio.ParameterName = "@precio";
                ParPrecio.SqlDbType = SqlDbType.Money;
                ParPrecio.Value = precio;
                SqlCmd.Parameters.Add(ParPrecio);


                SqlParameter ParTipo = new SqlParameter();
                ParTipo.ParameterName = "@tipo";
                ParTipo.SqlDbType = SqlDbType.VarChar;
                ParDescipcion.Size = 20;
                ParTipo.Value = tipo;
                SqlCmd.Parameters.Add(ParTipo);


                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se actualizó el Registro";

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

        public static string Actualizar_Estado(int IdServicio)
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
                SqlCmd.CommandText = "Cambiar_Estado_Servicio";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // Parámetros del Procedimiento Almacenado

                SqlParameter ParIdCliente = new SqlParameter();
                ParIdCliente.ParameterName = "@IdServicio";
                ParIdCliente.SqlDbType = SqlDbType.Int;

                ParIdCliente.Value = IdServicio;
                SqlCmd.Parameters.Add(ParIdCliente);



                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "El estado no se actualizó";

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
