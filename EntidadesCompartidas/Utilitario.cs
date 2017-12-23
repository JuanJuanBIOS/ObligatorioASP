using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Utilitario:Vehiculo
    {
        //Atributos
        private int _CapCarga;
        private string _Tipo;

        //Propiedades
        public int CapCarga
        {
            get 
            {
                return _CapCarga;
            }
            set 
            {
                if (value > 0)
                {
                    _CapCarga = value;
                }
                else
                {
                    throw new Exception("ERROR: La capacidad de carga debe ser mayor a 0");
                }
            }
        }

        public string Tipo
        {
            get 
            {
                return _Tipo;
            }
            set 
            {
                if (value.ToLower() == "furgoneta" || value.ToLower() == "pickup")
                {
                    _Tipo = value;
                }
                else 
                {
                    throw new Exception("ERROR: El tipo de utilitario debe ser 'Furgoneta' o 'Pickup'");
                }
                
            }
        }

        //Constructor
        public Utilitario(string pMatricula, string pMarca, string pModelo, int pAño, int pCantPuerta, int pCostoAlquiler, string pCategoria, int pCapCarga, string pTipoUti)
            :base (pMatricula, pMarca, pModelo, pAño, pCantPuerta, pCostoAlquiler, pCategoria)
        {
            CapCarga = pCapCarga;
            Tipo = pTipoUti; 
        }

        public override string ToString()
        {
            return (base.ToString() + " | Capacidad de carga: " + CapCarga + " | \nTipo de utilitario: " + Tipo);
        }

    }
}
