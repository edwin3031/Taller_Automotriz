using ProyectoFinalDeCurso.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalDeCurso.Controller
{
    class CMantenimiento
    {
        public static DataTable Mostrar_Mantenimiento()
        {
            return DMantenimiento.Mostrar_Mantenimientos();
        }

        public static string Insertar_Mantenimiento(int idVehiculo, int idMecanico, int idServicio, string fechaeEntrada, string fechaSalida)
        {
            return DMantenimiento.Insertar_Mantenimiento(idVehiculo, idMecanico, idServicio, fechaeEntrada, fechaSalida);
        }

        public static string Aignar_Servicio(int idMantenimiento, int idMecanico, int idServicio)
        {
            return DMantenimiento.Aignar_Servicio(idMantenimiento, idMecanico, idServicio);
        }

        public static DataTable Historial_De_Servicios(int idVehiculo)
        {
            return DMantenimiento.Historial_De_Servicios(idVehiculo);
        }

        public static DataTable Buscar_Mantenimientos(string dato)
        {
            return DMantenimiento.Buscar_Mantenimientos(dato);
        }
    }
}
