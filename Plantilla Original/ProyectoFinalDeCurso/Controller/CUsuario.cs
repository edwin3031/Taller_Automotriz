using ProyectoFinalDeCurso.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalDeCurso.Controller
{
    class CUsuario
    {
        public static DataTable Validar_Acceso(string usuario, string contraseña)
        {

            return DUsuario.Validar_Acceso(usuario, contraseña);
        }

        public static string Insertar_Usuario(string primerNombre, string primerApellido,
                                     string especialidad, string telefono, string rol, string contraseña, string username)
        {
            return DUsuario.Insertar_Usuario(primerNombre, primerApellido, especialidad, telefono, rol, contraseña, username);
        }

        public static DataTable Mostrar_Usuarios()
        {
            return DUsuario.Mostrar_Usuarios();
        }

        public static DataTable Buscar_Usuarios(string dato)
        {
            return DUsuario.Buscar_Usuario(dato);
        }

        public static string Actualizar_Estado(int IdUsuario)
        {
            return DUsuario.Actualizar_Estado(IdUsuario);
        }
    }
}
