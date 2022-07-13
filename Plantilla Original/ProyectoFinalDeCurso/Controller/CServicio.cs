using ProyectoFinalDeCurso.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalDeCurso.Controller
{
    class CServicio
    {
        public static DataTable Mostrar_Servicio()
        {
            return DServicio.Mostrar_Servicio();
        }

        public static DataTable Buscar_Servicio(string texto)
        {
            return DServicio.Buscar_Servicios(texto);
        }


        public static string Insertar_Servicio(string descripcion, decimal precio, string tipo)
        {
            return DServicio.Insertar_Servicio(descripcion,precio,tipo);
        }

        public static string Actualizar_Servicio(int IdServicio, string descripcion, decimal precio, string tipo)
        {
            return DServicio.Actualizar_Servicio(IdServicio,descripcion,precio,tipo);
        }
        public static string Actualizar_Estado(int IdServicio)
        {
            return DServicio.Actualizar_Estado(IdServicio);
        }
    }
}
