using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistencia;
using EntidadesCompartidas;

namespace Logica
{
    public class LogicaCliente
    {
        public static Cliente Buscar(int cedula)
        {
            return PersistenciaCliente.Buscar(cedula);
        }


        public static void Modificar(Cliente unCli)
        {
            PersistenciaCliente.Modificar(unCli);
        }

        public static void Eliminar(Cliente unCli)
        {
            PersistenciaCliente.Eliminar(unCli);
        }

    }
}
