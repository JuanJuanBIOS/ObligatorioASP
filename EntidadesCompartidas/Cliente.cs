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
                    throw new Exception("Error: el campo 'Nombre' no puede estar vacío");
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
                    int digitoingresado = _Cedula % 10;
                    _Cedula = (_Cedula - digitoingresado) / 10;

                    int dig1 = _Cedula % 10;
                    _Cedula = (_Cedula - dig1) / 10;
                    int dig2 = _Cedula % 10;
                    _Cedula = (_Cedula - dig2) / 10;
                    int dig3 = _Cedula % 10;
                    _Cedula = (_Cedula - dig3) / 10;
                    int dig4 = _Cedula % 10;
                    _Cedula = (_Cedula - dig4) / 10;
                    int dig5 = _Cedula % 10;
                    _Cedula = (_Cedula - dig5) / 10;
                    int dig6 = _Cedula % 10;
                    _Cedula = (_Cedula - dig6) / 10;
                    int dig7 = _Cedula % 10;
                    _Cedula = (_Cedula - dig7) / 10;

                    int aux = (dig7 * 2 % 10 + dig6 * 9 % 10 + dig5 * 8 % 10 + dig4 * 7 % 10 + dig3 * 6 % 10 + dig2 * 3 % 10 + dig1 * 4 % 10);
                    int digitocalculado = (10 - aux % 10) % 10;

                    if (digitoingresado == digitocalculado)
                    {
                        _Cedula = value;

                    }

                    else
                    {
                        throw new Exception("Error, cedula incorrecta");
                    }
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
                    throw new Exception("Error en el numero de tarjeta de credito. El mismo debe contener 16 dígitos");
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
                    throw new Exception("Error: el campo 'Dirección' no puede estar vacío");
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
