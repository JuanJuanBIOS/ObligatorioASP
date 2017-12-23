using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistencia;
using EntidadesCompartidas;

namespace Logica
{
    public class LogicaVehiculo
    {
        public static Vehiculo Buscar(string matricula)
        {
            Vehiculo V = null;

            V = PersistenciaAuto.Buscar(matricula);

            if (V==null)
            {
                V = PersistenciaUtilitario.Buscar(matricula);
            }

            return V;
        }

        public static void Crear(Vehiculo Veh)
        {
            if (Veh is Auto)
            {
                PersistenciaAuto.Crear((Auto)Veh);
            }
            else if (Veh is Utilitario)
            {
                PersistenciaUtilitario.Crear((Utilitario)Veh);
            }
            else
            {
                throw new Exception ("No se indicó un vehículo para dar de alta");
            }
        }

        public static void Modificar(Vehiculo Veh)
        {
            if (Veh is Auto)
            {
                PersistenciaAuto.Modificar((Auto)Veh);
            }
            else if (Veh is Utilitario)
            {
                PersistenciaUtilitario.Modificar((Utilitario)Veh);
            }
            else
            {
                throw new Exception("No se indicó un vehículo para modificar");
            }
        }

        public static void Eliminar(Vehiculo Veh)
        {
            if (Veh is Auto)
            {
                PersistenciaAuto.Eliminar((Auto)Veh);
            }
            else if (Veh is Utilitario)
            {
                PersistenciaUtilitario.Eliminar((Utilitario)Veh);
            }
            else
            {
                throw new Exception("No se indicó un vehículo para eliminar");
            }
        }
    }
}
