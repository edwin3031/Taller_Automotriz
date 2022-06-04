using ProyectoFinalDeCurso.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalDeCurso.Controller
{
    class CVehiculo
    {
        public static DataTable Mostrar_Vehiculo()
        {
            return DVehiculo.Mostrar_Vehiculo();
        }

        public static DataTable Buscar_Vehiculo(string texto)
        {
            return DVehiculo.Buscar_Vehiculo(texto);
        }

        public static string Insertar_Vehiculo(int id, string marca, string modelo,int año)
        {

            return DVehiculo.Insertar_Vehiculo(id,marca,modelo,año);
        }

        public static string Actualizar_Vehiculo(int IdVehiculo ,int IdCliente, string marca, string modelo, int año)
        {

            return DVehiculo.Actualizar_Vehiculo(IdVehiculo, IdCliente, marca, modelo, año);
        }
    }
}
