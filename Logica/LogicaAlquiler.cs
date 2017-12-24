using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistencia;
using EntidadesCompartidas;

namespace Logica
{
    public class LogicaAlquiler
    {
        public static void Realizar_Alquiler(Alquiler Alq)
        {
            PersistenciaAlquiler.Realizar_Alquiler(Alq);
        }
    }
}
