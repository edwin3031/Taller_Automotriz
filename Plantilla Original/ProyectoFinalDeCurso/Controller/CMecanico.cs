using ProyectoFinalDeCurso.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalDeCurso.Controller
{
    class CMecanico
    {
        public static DataTable Mostrar_Mecanico()
        {
            return DMecanico.Mostrar_Mecanico();
        }

        public static DataTable Buscar_Mecanico(string texto)
        {
            return DMecanico.Buscar_Mecanico(texto);
        }

        public static string Insertar_Mecanico(string primerNombre, string segundoNombre, string primerApellido
                                      , string segundoApellido, string especialidad, string direccion, string correo, string telefono, decimal salario)
        {

            return DMecanico.Insertar_Mecanico(primerNombre, segundoNombre, primerApellido
                                        , segundoApellido, especialidad, direccion, correo, telefono, salario);
        }

        public static string Actualizar_Mecanico(int IdMecanico, string primerNombre, string segundoNombre, string primerApellido
                                      , string segundoApellido, string especialidad, string direccion, string correo, string telefono, decimal salario)
        {

            return DMecanico.Actualizar_Mecanico(IdMecanico, primerNombre, segundoNombre, primerApellido
                                        , segundoApellido, especialidad, direccion, correo, telefono, salario);
        }
        public static string Actualizar_Estado(int IdMecanico)
        {
            return DMecanico.Actualizar_Estado(IdMecanico);
        }
    }
}
