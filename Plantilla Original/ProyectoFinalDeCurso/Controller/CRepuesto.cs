using ProyectoFinalDeCurso.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalDeCurso.Controller
{
    class CRepuesto
    {
        public static DataTable Mostrar_Repuesto()
        {
            return DRepuesto.Mostrar_Repuesto();
        }

        public static DataTable Buscar_Repuesto(string texto)
        {
            return DRepuesto.Buscar_Repuesto(texto);
        }

        public static string Insertar_Repuesto(string marca, string modelo, int cantidad, string descripcion, decimal precio)
        {
            return DRepuesto.Insertar_Repuesto(marca, modelo, cantidad, descripcion, precio);
        }

        public static string Actualizar_Repuesto(int IdRepuesto, string marca, string modelo, int cantidad, string descripcion, decimal precio)
        {
            return DRepuesto.Actualizar_Repuesto(IdRepuesto, marca, modelo, cantidad, descripcion, precio);
        }
        public static string Actualizar_Estado(int IdRepuesto)
        {
            return DRepuesto.Actualizar_Estado(IdRepuesto);
        }
        
    }
}
