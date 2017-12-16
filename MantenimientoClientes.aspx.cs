﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;



namespace ObligatorioASPNET
{
    public partial class MantenimientoClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        //FALTA ESTO!!!!!!!!!!!!!!!!!1
        private void DesactivoBotones()
        {
            //.Enabled = false;
            //BtnModificar.Enabled = false;
            //btnBaja.Enabled = false;

            //btnBuscar.Enabled = true;
        }



        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            int cedula = 0;

            try
            {
                cedula = Convert.ToInt32(TBInDocumento.Text);
            }
            catch
            {
                LblError.Text = "Ingrese un numero";
                return;
            }

            try
            {
                Cliente Cli = LogicaCliente.Buscar(cedula);

                if (Cli != null)
                {
                    TBNombre.Text = Cli.Nombre;
                    TBTarjeta.Text = Convert.ToString(Cli.Tarjeta);
                    TBTelefono.Text = Convert.ToString(Cli.Telefono);
                    TBDireccion.Text = Cli.Direccion;
                    TBFechaNac.Text = Convert.ToString(Cli.FechaNac);

                }
                else
                {
                    LblError.Text = "Objeto es nulo";
                }
            }
            catch (Exception ex)
            {
                LblError.Text = ex.Message;
            }
        }

    }
}