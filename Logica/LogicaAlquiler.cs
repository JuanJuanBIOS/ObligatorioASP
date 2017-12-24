﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistencia;
using EntidadesCompartidas;

namespace Logica
{
    public class LogicaAlquiler
    {
        public static void Consultar_Alquiler(Alquiler Alq)
        {
            PersistenciaAlquiler.Consultar_Alquiler(Alq);
        }

        public static void Confirmar_Alquiler(Alquiler Alq)
        {
            PersistenciaAlquiler.Confirmar_Alquiler(Alq);
        }
    }
}