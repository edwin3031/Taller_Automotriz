using ProyectoFinalDeCurso.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalDeCurso.Controller
{
    class CCliente
    {
        public static DataTable Mostrar_Clientes()
        {
            return DCliente.Mostrar_Clientes();
        }

        public static DataTable Buscar_Clientes(string texto)
        {
            return DCliente.Buscar_Clientes(texto);
        }

        public static string Insertar_Clientes(string primerNombre, string segundoNombre, string primerApellido
                                        , string segundoApellido, string direccion, string correo, string telefono)
        {
            
            return DCliente.Insertar_Cliente(primerNombre, segundoNombre, primerApellido
                                        , segundoApellido, direccion, correo, telefono);
        }

        public static string Actualizar_Clientes(int IdCliente, string primerNombre, string segundoNombre, string primerApellido
                                      , string segundoApellido, string direccion, string correo, string telefono)
        {
           
            return DCliente.Actualizar_Clientes(IdCliente, primerNombre, segundoNombre, primerApellido
                                        , segundoApellido, direccion, correo, telefono);
        }
        public static string Actualizar_Estado(int IdCliente)
        {
            return DCliente.Actualizar_Estado(IdCliente);
        }
    }
}
