using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistencia;
using EntidadesCompartidas;

namespace Logica
{
    public class LogicaAuto
    {
        public static Auto Buscar(string matricula)
        {
            return PersistenciaAuto.Buscar(matricula);
        }
    }
}
