using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
   public class Alquiler
    {
        //Atributos
        private int _Codigo;
        private Cliente _Cliente;
        private Vehiculo _Vehiculo;
        private DateTime _FechaIni;
        private DateTime _FechaFin;
        private int _Costo;

        //Propiedades
        public Cliente Cliente
        {
            get
            {
                return _Cliente;
            }
            set
            {
                if (value != null)
                {
                    _Cliente = value;
                }
                else
                {
                    throw new Exception("Error en el cliente");
                }
            }
        }

        public Vehiculo Vehiculo
        {
            get
            {
                return _Vehiculo;
            }
            set
            {
                if (value != null)
                {
                    _Vehiculo = value;
                }
                else
                {
                    throw new Exception("Error en el vehiculo");
                }
            }
        }

        public DateTime FechaInicio
        {
            get
            {
                return _FechaIni;
            }
            set
            {
                if (value.Date >= DateTime.Now.Date)
                {
                    _FechaIni = value;
                }
                else
                {
                    throw new Exception("La fecha de inicio no puede ser anterior al día de hoy");
                }
            }
        }

        public DateTime FechaFin
        {
            get
            {
                return _FechaFin;
            }
            set
            {
                TimeSpan dif = value.Subtract(FechaInicio);

                if (dif.TotalDays > 0)
                {
                    _FechaFin = value;
                }
                else
                {
                    throw new Exception("La fecha de fin debe ser mayor a la fecha de inicio");
                }
            }
        }

        public int Costo
        {
            get
            {
                /*int cantDias = (_FechaFin.Subtract(_FechaIni)).Days;
                return (this._Vehiculo.CostoAlquiler * cantDias);*/
                return _Costo;
            }
            set
            {
                if (value > 0)
                    _Costo = value;
                else
                    throw new Exception("Error: Costo de Alquiler");
            }
        }

        public int Codigo
        {
            get { return _Codigo; }
            set
            {
                if (value >= 0)
                    _Codigo = value;
                else
                    throw new Exception("Error: Codigo de Alquiler");
            }
        }


       //Constructor
        public Alquiler(Cliente pCliente, Vehiculo pVehiculo, DateTime pFechainicio, DateTime pFechafin, int pCosto)
        {
            Cliente = pCliente;
            Vehiculo = pVehiculo;
            FechaInicio = pFechainicio;
            FechaFin = pFechafin;
            Costo = pCosto;
        }

    }
}
