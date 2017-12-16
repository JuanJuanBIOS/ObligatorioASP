using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Cliente
    {
        //Atributos
        private int _Cedula; 
        private string _Nombre;
        private long _Tarjeta;
        private string _Telefono;
        private string _Direccion;
        private DateTime _FechaNac;


        //Propiedades
        public string Nombre
        {
            get 
            {
                return _Nombre;
            }
            set
            {                
                if (value.Length != 0)
                {
                    _Nombre = value;
                }
                else 
                {
                    throw new Exception("Error en el nombre de cliente");
                }
            }
        }

        public int Cedula
        {
            get
            {
                return _Cedula;
            }
            set
            {
                if (value >= 100000 && value <= 99999999)
                {
                    _Cedula = value;

                }
                else 
                {
                    throw new Exception("Error, cedula incorrecta");
                }
            }
        }

        public long Tarjeta
        {
            get
            {
                return _Tarjeta;
            }
            set
            {
                if (value > 0)
                {
                    _Tarjeta = value;
                }
                else
                {
                    throw new Exception("Error en el numero de tarjeta de credito");
                }
            }
        }                      

        public string Telefono
        
        {
            get
            {
                return _Telefono;
            }
            set
            {
                if (value.Length > 7)
                {
                    _Telefono = value;
                }
                else 
                {
                    throw new Exception("Error: telefono invalido");
                }
            }
        }

        public string Direccion
        {
            get
            {
                return _Direccion;
            }
            set
            {
                if (value.Length != 0)
                {
                    _Direccion = value;
                }
                else 
                {
                    throw new Exception("Error: Falta direccion");
                }
                
            }
        }

        public DateTime FechaNac        
        {
            get
            {
                return _FechaNac;
            }
            set
            {
                TimeSpan edad = DateTime.Now.Subtract(value);

                if ((edad.Days / 365.25) >= 25)
                {
                    _FechaNac = value;
                }
                else 
                {
                    throw new Exception ("Error - Edad insuficiente");
                }
            }
        }

        //Constructores
        public Cliente(string pNombre, int pCedula, long pTarjeta, string pTelefono, string pDireccion, DateTime pFechanac) 
        {
            Nombre = pNombre;
            Cedula = pCedula;
            Tarjeta = pTarjeta;
            Telefono = pTelefono;
            Direccion = pDireccion;
            FechaNac = pFechanac;
        }

        public override string ToString()
        {
            return ("Nombre: " + Nombre + " Cedula: " + Cedula + " Fecha de nacimiento: " + FechaNac +  " Telefono: " + Telefono + " Direccion: " + Direccion + " Tarjeta de credito: " + Tarjeta);
        }
    }
}
