using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoFinalDeCurso.Data
{
    class DRepuesto
    {
        public static DataTable Mostrar_Repuesto()
        {
            DataTable DtResultado = new DataTable("MostrarRepuesto");
            SqlConnection SqlCon = new SqlConnection();
            try
            {    // Cargando el conexión al servidor
                SqlCon.ConnectionString = Conexion.conexion;
                // Creando un objeto SQLCommand que llamará al procedimiento almacenado
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "Mostrar_Repuestos";
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

        public static DataTable Buscar_Repuesto(string texto)
        {
            DataTable DtResultado = new DataTable("BuscarRepuesto");
            SqlConnection SqlCon = new SqlConnection();
            try
            {    // Cargando el conexión al servidor
                SqlCon.ConnectionString = Conexion.conexion;
                // Creando un objeto SQLCommand que llamará al procedimiento almacenado
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "Buscar_Repuesto";
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

        public static string Insertar_Repuesto(string marca, string modelo,int cantidad ,string descripcion, decimal precio)
        {

            //falta el precio y cambiar los nombre de los parametros
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
                SqlCmd.CommandText = "Insertar_Repuesto";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // Parámetros del Procedimiento Almacenado
                SqlParameter ParMarca = new SqlParameter();
                ParMarca.ParameterName = "@marca";
                ParMarca.SqlDbType = SqlDbType.VarChar;
                ParMarca.Size = 60;
                ParMarca.Value = marca;
                SqlCmd.Parameters.Add(ParMarca);

                SqlParameter ParModelo = new SqlParameter();
                ParModelo.ParameterName = "@modelo";
                ParModelo.SqlDbType = SqlDbType.VarChar;
                ParModelo.Size = 60;
                ParModelo.Value = modelo;
                SqlCmd.Parameters.Add(ParModelo);


                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@cantidad";
                ParCantidad.SqlDbType = SqlDbType.Int;

                ParCantidad.Value = cantidad;
                SqlCmd.Parameters.Add(ParCantidad);


                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 60;
                ParDescripcion.Value = descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                SqlParameter ParPrecio = new SqlParameter();
                ParPrecio.ParameterName = "@precio";
                ParPrecio.SqlDbType = SqlDbType.Money;
                ParPrecio.Value = precio;
                SqlCmd.Parameters.Add(ParPrecio);

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

        public static string Actualizar_Repuesto(int IdRepuesto,string marca, string modelo, int cantidad, string descripcion, decimal precio)
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
                SqlCmd.CommandText = "Editar_Repuesto";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // Parámetros del Procedimiento Almacenado

                SqlParameter ParIdRepuesto = new SqlParameter();
                ParIdRepuesto.ParameterName = "@IdRepuesto";
                ParIdRepuesto.SqlDbType = SqlDbType.Int;

                ParIdRepuesto.Value = IdRepuesto;
                SqlCmd.Parameters.Add(ParIdRepuesto);


                SqlParameter ParMarca = new SqlParameter();
                ParMarca.ParameterName = "@marca";
                ParMarca.SqlDbType = SqlDbType.VarChar;
                ParMarca.Size = 60;
                ParMarca.Value = marca;
                SqlCmd.Parameters.Add(ParMarca);

                SqlParameter ParModelo = new SqlParameter();
                ParModelo.ParameterName = "@modelo";
                ParModelo.SqlDbType = SqlDbType.VarChar;
                ParModelo.Size = 60;
                ParModelo.Value = modelo;
                SqlCmd.Parameters.Add(ParModelo);


                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@cantidad";
                ParCantidad.SqlDbType = SqlDbType.Int;

                ParCantidad.Value = cantidad;
                SqlCmd.Parameters.Add(ParCantidad);


                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 60;
                ParDescripcion.Value = descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                SqlParameter ParPrecio = new SqlParameter();
                ParPrecio.ParameterName = "@precio";
                ParPrecio.SqlDbType = SqlDbType.Money;
                ParPrecio.Value = precio;
                SqlCmd.Parameters.Add(ParPrecio);


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

        public static string Actualizar_Estado(int IdRepuesto)
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
                SqlCmd.CommandText = "Cambiar_Estado_Repuesto";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // Parámetros del Procedimiento Almacenado

                SqlParameter ParIdRepuesto = new SqlParameter();
                ParIdRepuesto.ParameterName = "@IdRepuesto";
                ParIdRepuesto.SqlDbType = SqlDbType.Int;

                ParIdRepuesto.Value = IdRepuesto;
                SqlCmd.Parameters.Add(ParIdRepuesto);



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
