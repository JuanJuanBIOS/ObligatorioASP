using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Auto: Vehiculo
    { 
        //Atributo
        private string _TipoA;

        //Propiedades
        public string TipoA
        {
            get 
            {
                return _TipoA;
            }
            set 
            {
                if (value.ToLower() == "latch" || value.ToLower() == "isofix" || value.ToLower() == "cinturón")
                {
                    _TipoA = value;
                }
                else 
                {
                    throw new Exception("ERROR: El tipo de anclaje debe ser 'Cinturón', 'ISOFIX' o 'Latch'");
                }
                
            }
        }

        //Constructor
        public Auto(string pMatricula, string pMarca, string pModelo, int pAño, int pCantPuerta, int pCostoAlquiler,string pCategoria, string pSillaTipo)
            :base(pMatricula, pMarca, pModelo, pAño, pCantPuerta, pCostoAlquiler, pCategoria)
        {
            TipoA = pSillaTipo;
        }

        public override string ToString()
        {
            return (base.ToString() + " | Tipo de silla: " + TipoA);
        }
    }

}
