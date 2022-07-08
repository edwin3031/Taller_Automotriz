using ProyectoFinalDeCurso.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalDeCurso.Controller
{
    class CAsignarRepuesto
    {
        public static DataTable Mostrar_Mantenimiento_Mecanico()
        {
            return DAsignarRepuesto.Mostrar_Mantenimiento_Mecanico();
        }
        public static DataTable Mostrar_Servicios_Repuestos(int idDetalleMantenimiento)
        {
            return DAsignarRepuesto.Mostrar_Servicios_Repuestos(idDetalleMantenimiento);
        }
        public static DataTable Mostrar_Mantenimientos_Servicios(int IdMantenimiento)
        {
            return DAsignarRepuesto.Mostrar_Mantenimientos_Servicios(IdMantenimiento);
        }

        public static string Aignar_Repuesto(int idDetalleMantenimiento, int idRepuesto, int cantidad)
        {
            return DAsignarRepuesto.Aignar_Repuesto(idDetalleMantenimiento, idRepuesto, cantidad);
        }

    }
}
