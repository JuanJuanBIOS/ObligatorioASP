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
                                throw new Exception("Error en el formato de la matricula");
                            }
                        }
                        else 
                        {
                            //Ultimos cuatro lugares, comprueba si son numeros
                            if (!Char.IsDigit(Convert.ToChar(value.Substring(i, 1)))) 
                            {
                                throw new Exception("Error en el formato de la matricula");
                            }
                        }
                    }

                    _Matricula = value;

                }
                else 
                {
                    throw new Exception("Error: Matricula: Longitud incorrecta (Son 7 digitos ABC1234)");
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
                    throw new Exception("Error: Marca de vehiculo");
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
                    throw new Exception("Error: Modelo de vehiculo");
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
                if (value > 1980)
                {
                    _Año = value;
                }
                else
                {
                    throw new Exception("Error: Año del vehiculo");
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
                    throw new Exception("Error: Cantidad de puertas");
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
                    throw new Exception("Error: Costo alquiler");

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
                    throw new Exception("Error: la categoría debe ser 'Auto' o 'Utilitario'");
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
