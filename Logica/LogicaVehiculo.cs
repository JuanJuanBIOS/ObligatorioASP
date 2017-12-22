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
    }
}
