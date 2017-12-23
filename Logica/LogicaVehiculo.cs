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
    }
}
