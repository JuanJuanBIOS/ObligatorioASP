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
            return PersistenciaVehiculo.Buscar(matricula);
        }
    }
}
