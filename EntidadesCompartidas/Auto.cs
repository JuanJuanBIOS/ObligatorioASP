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
                if (value.ToLower() == "latch" || value.ToLower() == "isofix" || value.ToLower() == "cinturon")
                {
                    _TipoA = value;
                }
                else 
                {
                    throw new Exception("Error: tipo de silla");
                }
                
            }
        }

        //Constructor
        public Auto(string pMatricula, string pMarca, string pModelo, int pAño, int pCantPuerta, int pCostoAlquiler, string pSillaTipo)
            :base(pMatricula, pMarca, pModelo, pAño, pCantPuerta, pCostoAlquiler)
        {
            TipoA = pSillaTipo;
        }

        public override string ToString()
        {
            return (base.ToString() + " | Tipo de silla: " + TipoA);
        }
    }

}
