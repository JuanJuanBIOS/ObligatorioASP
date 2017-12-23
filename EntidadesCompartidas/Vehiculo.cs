using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public abstract class Vehiculo
    {

        //Atributos
        private string _Matricula;
        private string _Marca;
        private string _Modelo;
        private int _Año;
        private int _CantPuertas;
        private int _CostoAlquiler;
        private string _Categoria;

        //Propiedades
        public string Matricula
        {
            get{ return _Matricula; }
            
            set 
            {               
                if (value.Length == 7)
                {
                    for (int i = 0; i < value.Length; i++) 
                    {
                        if (i < 3) 
                        {
                            //Comprueba los tres primeros lugares, verifica que sean letras
                            if (!Char.IsLetter(Convert.ToChar(value.Substring(i, 1))))
                            {
                                throw new Exception("ERROR: La matrícula debe constar de 3 letras seguidas de 4 números");
                            }
                        }
                        else 
                        {
                            //Ultimos cuatro lugares, comprueba si son numeros
                            if (!Char.IsDigit(Convert.ToChar(value.Substring(i, 1)))) 
                            {
                                throw new Exception("ERROR: La matrícula debe constar de 3 letras seguidas de 4 números");
                            }
                        }
                    }

                    _Matricula = value;

                }
                else 
                {
                    throw new Exception("ERROR: La matrícula debe constar de 3 letras seguidas de 4 números");
                }
            }
        }

        public string Marca
        {
            get
            {
                return _Marca;
            }
            set 
            {
                if (value.Length > 0)
                {
                    _Marca = value;
                }
                else 
                {
                    throw new Exception("ERROR: El campo 'Marca' no puede estar vacío.");
                }
                
            }
        }

        public string Modelo 
        {
            get 
            {
                return _Modelo;
            }
            set 
            {
                if (value.Length > 0)
                {
                    _Modelo = value;
                }
                else
                {
                    throw new Exception("ERROR: El campo 'Modelo' no puede estar vacío.");
                }                
            }

        }

        public int Año        
        {
            get 
            {
                return _Año;
            }
            set 
            {
                if (value > 1900)
                {
                    _Año = value;
                }
                else
                {
                    throw new Exception("ERROR: El año debe ser mayor a 1900");
                }
            }
        }

        public int CantPuertas 
        {
            get 
            {
                return _CantPuertas;
            }
            set 
            {
                if (value > 0 && value <= 5)
                {
                    _CantPuertas = value;
                }
                else
                {
                    throw new Exception("ERROR: La cantidad de puertas debe estar entre 1 y 5");
                }
            }
        }

        public int CostoAlquiler
        {
            get 
            {
                return _CostoAlquiler;
            }
            set 
            {
                if (value > 0)
                {
                    _CostoAlquiler = value;
                }
                else
                {
                    throw new Exception("ERROR: El costo diario debe ser mayor a 0");

                }
            }
        }

        public string Categoria
        {
            get
            {
                return _Categoria;
            }
            set
            {
                if (value.ToLower() == "auto" || value.ToLower() == "utilitario")
                {
                    _Categoria = value;
                }
                else
                {
                    throw new Exception("ERROR: la categoría debe ser 'Auto' o 'Utilitario'");
                }

            }
        }


        //Constructor
        public Vehiculo(string pMatricula, string pMarca, string pModelo, int pAño, int pCantPuerta, int pCostoAlquiler, string pCategoria)
        {
            Matricula = pMatricula;
            Marca = pMarca;
            Modelo = pModelo;
            Año = pAño;
            CantPuertas = pCantPuerta;
            CostoAlquiler = pCostoAlquiler;
            Categoria = pCategoria;
        }

        public override string ToString()
        {
            return ("Matricula: " + Matricula.ToUpper() + " \nMarca: " + Marca + " | Modelo: " + Modelo + " | Año: " + Año + " \nCantidad de puertas: " + CantPuertas + " | Costo de alquiler: " + CostoAlquiler);
        }
    }
}
