using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalDeCurso.Data
{
    class DUsuario
    {

        //falta el implementar el ingresar usuario
        public static DataTable Validar_Acceso(string usuario, string contraseña)
        {
            DataTable DtResultado = new DataTable("Inicio_Sesión");
            SqlConnection SqlCon = new SqlConnection();
            try
            {    // Cargando la conexión del servidor
                SqlCon.ConnectionString = Conexion.conexion;
                // Creando un objeto SQLCommand que llamará al procedimiento almacenado
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "Validar_Acceso";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                //   Cargando los parámetros del procedimiento almacenado
                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@Usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 60;
                ParUsuario.Value = usuario;
                SqlCmd.Parameters.Add(ParUsuario);

                SqlParameter ParContraseña = new SqlParameter();
                ParContraseña.ParameterName = "@Contraseña";
                ParContraseña.SqlDbType = SqlDbType.VarChar;
                ParContraseña.Size = 100;
                ParContraseña.Value = contraseña;
                SqlCmd.Parameters.Add(ParContraseña);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;

        }

        public static DataTable Mostrar_Usuarios()
        {
            DataTable DtResultado = new DataTable("Mostrar_Usuario");
            SqlConnection SqlCon = new SqlConnection();
            try
            {    // Cargando la conexión del servidor
                SqlCon.ConnectionString = Conexion.conexion;
                // Creando un objeto SQLCommand que llamará al procedimiento almacenado
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "Mostrar_Usuarios";
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

        public static DataTable Buscar_Usuario(string dato)
        {
            DataTable DtResultado = new DataTable("Buscar_Usuario");
            SqlConnection SqlCon = new SqlConnection();
            try
            {    // Cargando la conexión del servidor
                SqlCon.ConnectionString = Conexion.conexion;
                // Creando un objeto SQLCommand que llamará al procedimiento almacenado
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "Buscar_Usuario";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                //   Cargando los parámetros del procedimiento almacenado
              

                SqlParameter Pardato = new SqlParameter();
                Pardato.ParameterName = "@dato";
                Pardato.SqlDbType = SqlDbType.VarChar;
                Pardato.Size = 100;
                Pardato.Value = dato;
                SqlCmd.Parameters.Add(Pardato);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;

        }

        public static string Insertar_Usuario(string primerNombre, string primerApellido,
                                       string especialidad, string telefono,string rol,string contraseña,string username)
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
                SqlCmd.CommandText = "Crear_Usuario";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // Parámetros del Procedimiento Almacenado

                SqlParameter ParPrimerNombre = new SqlParameter();
                ParPrimerNombre.ParameterName = "@FirstName";
                ParPrimerNombre.SqlDbType = SqlDbType.VarChar;
                ParPrimerNombre.Size = 60;
                ParPrimerNombre.Value = primerNombre;
                SqlCmd.Parameters.Add(ParPrimerNombre);


                SqlParameter ParPrimerApellido = new SqlParameter();
                ParPrimerApellido.ParameterName = "@LastName";
                ParPrimerApellido.SqlDbType = SqlDbType.VarChar;
                ParPrimerApellido.Size = 60;
                ParPrimerApellido.Value = primerApellido;
                SqlCmd.Parameters.Add(ParPrimerApellido);


                SqlParameter ParEspecialidad = new SqlParameter();
                ParEspecialidad.ParameterName = "@Especialidad";
                ParEspecialidad.SqlDbType = SqlDbType.VarChar;
                ParEspecialidad.Size = 100;
                ParEspecialidad.Value = especialidad;
                SqlCmd.Parameters.Add(ParEspecialidad);


                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@Telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 60;
                ParTelefono.Value = telefono;
                SqlCmd.Parameters.Add(ParTelefono);

                SqlParameter ParUsername = new SqlParameter();
                ParUsername.ParameterName = "@username";
                ParUsername.SqlDbType = SqlDbType.VarChar;
                ParUsername.Size = 60;
                ParUsername.Value = username;
                SqlCmd.Parameters.Add(ParUsername);

                SqlParameter ParContraseña = new SqlParameter();
                ParContraseña.ParameterName = "@contraseña";
                ParContraseña.SqlDbType = SqlDbType.VarChar;
                ParContraseña.Size = 60;
                ParContraseña.Value = contraseña;
                SqlCmd.Parameters.Add(ParContraseña);

                SqlParameter ParRol = new SqlParameter();
                ParRol.ParameterName = "@rol";
                ParRol.SqlDbType = SqlDbType.VarChar;
                ParRol.Size = 60;
                ParRol.Value = rol;
                SqlCmd.Parameters.Add(ParRol);


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

        public static string Actualizar_Estado(int IdUsuario)
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
                SqlCmd.CommandText = "Cambiar_Estado_Usuario";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // Parámetros del Procedimiento Almacenado

                SqlParameter ParIdCliente = new SqlParameter();
                ParIdCliente.ParameterName = "@IdUsuario";
                ParIdCliente.SqlDbType = SqlDbType.Int;

                ParIdCliente.Value = IdUsuario;
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
