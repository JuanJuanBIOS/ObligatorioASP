using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;

namespace ObligatorioASPNET
{
    public partial class Realizar_Alquiler : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnRealizarAlquiler_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente oCliente = Logica.LogicaCliente.Buscar(Convert.ToInt32(TBClienteAlquiler.Text));
                Vehiculo oVehiculo = Logica.LogicaVehiculo.Buscar(TBMatriculaAlquiler.Text);
                DateTime oFechaIni = CalInicioAlquiler.SelectedDate;
                DateTime oFechaFin = CalFinAlquiler.SelectedDate;
                int oCosto = 0;

                Alquiler unAlquiler = new Alquiler(oCliente, oVehiculo, oFechaIni, oFechaFin, oCosto);

                LogicaAlquiler.Realizar_Alquiler(unAlquiler);
                LblErrorAlquiler.ForeColor = System.Drawing.Color.Blue;
                LblErrorAlquiler.Text = "El alquiler se realizó correctamente";
            }

            catch (Exception ex)
            {
                LblErrorAlquiler.ForeColor = System.Drawing.Color.Red;
                LblErrorAlquiler.Text = ex.Message;
            }

        }

        protected void BtnConfirmarAlquiler_Click(object sender, EventArgs e)
        {

        }

        protected void CalInicioAlquiler_SelectionChanged(object sender, EventArgs e)
        {
            LblErrorAlquiler.Text = "";
            TBInicioAlquiler.Text = CalInicioAlquiler.SelectedDate.ToShortDateString();
            if (CalInicioAlquiler.SelectedDate >= CalFinAlquiler.SelectedDate && TBFinAlquiler.Text != "")
                LblErrorAlquiler.Text = "La fecha de Fin debe ser mayor a la fecha de Inicio";
        }

        protected void CalFinAlquiler_SelectionChanged(object sender, EventArgs e)
        {
            LblErrorAlquiler.Text = "";
            TBFinAlquiler.Text = CalFinAlquiler.SelectedDate.ToShortDateString();
            if (CalInicioAlquiler.SelectedDate >= CalFinAlquiler.SelectedDate && TBInicioAlquiler.Text != "")
                LblErrorAlquiler.Text = "La fecha de Fin debe ser mayor a la fecha de Inicio";
        }
    }
}