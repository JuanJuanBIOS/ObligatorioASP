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
            if (!IsPostBack)
                this.LimpioFormulario();
        }

        private void LimpioFormulario()
        {
            TBClienteAlquiler.Enabled = true;
            TBMatriculaAlquiler.Enabled = true;
            CalInicioAlquiler.Enabled = true;
            CalFinAlquiler.Enabled = true;
            BtnRealizarAlquiler.Enabled = true;
            BtnConfirmarAlquiler.Enabled = false;
            BtnCancelarAlquiler.Enabled = false;
            BtnOkAlquiler.Visible = false;

            LblErrorAlquiler.ForeColor = System.Drawing.Color.Red;
            LblErrorAlquiler.Text = "";
            TBClienteAlquiler.Text = "";
            TBMatriculaAlquiler.Text = "";
            TBInicioAlquiler.Text = "";
            TBFinAlquiler.Text = "";
        }

        protected void BtnRealizarAlquiler_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente oCliente = Logica.LogicaCliente.Buscar(Convert.ToInt32(TBClienteAlquiler.Text));
                Vehiculo oVehiculo = Logica.LogicaVehiculo.Buscar(TBMatriculaAlquiler.Text);
                DateTime oFechaIni = CalInicioAlquiler.SelectedDate;
                DateTime oFechaFin = CalFinAlquiler.SelectedDate;
                

                if (oCliente == null)
                {
                    LblErrorAlquiler.ForeColor = System.Drawing.Color.Red;
                    LblErrorAlquiler.Text = "El cliente ingresado no existe en la base de datos";
                }
                else if (oVehiculo == null)
                {
                    LblErrorAlquiler.ForeColor = System.Drawing.Color.Red;
                    LblErrorAlquiler.Text = "El vehículo ingresado no existe en la base de datos";
                }
                else
                {
                    int oCosto = (oFechaFin.Subtract(oFechaIni)).Days * oVehiculo.CostoAlquiler;

                    Alquiler unAlquiler = new Alquiler(oCliente, oVehiculo, oFechaIni, oFechaFin, oCosto);

                    LogicaAlquiler.Consultar_Alquiler(unAlquiler);
                    LblErrorAlquiler.ForeColor = System.Drawing.Color.Blue;
                    LblErrorAlquiler.Text = "El costo del alquiler será de $" + unAlquiler.Costo + ". ¿Desea confirmar el alquiler?";
                    TBClienteAlquiler.Enabled = false;
                    TBMatriculaAlquiler.Enabled = false;
                    CalInicioAlquiler.Enabled = false;
                    CalFinAlquiler.Enabled = false;
                    BtnRealizarAlquiler.Enabled = false;
                    BtnConfirmarAlquiler.Enabled = true;
                    BtnCancelarAlquiler.Enabled = true;
                }
            }

            catch (Exception ex)
            {
                LblErrorAlquiler.ForeColor = System.Drawing.Color.Red;
                LblErrorAlquiler.Text = ex.Message;
            }

        }

        protected void BtnConfirmarAlquiler_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente oCliente = Logica.LogicaCliente.Buscar(Convert.ToInt32(TBClienteAlquiler.Text));
                Vehiculo oVehiculo = Logica.LogicaVehiculo.Buscar(TBMatriculaAlquiler.Text);
                DateTime oFechaIni = CalInicioAlquiler.SelectedDate;
                DateTime oFechaFin = CalFinAlquiler.SelectedDate;


                if (oCliente == null)
                {
                    LblErrorAlquiler.ForeColor = System.Drawing.Color.Red;
                    LblErrorAlquiler.Text = "El cliente ingresado no existe en la base de datos";
                }
                else if (oVehiculo == null)
                {
                    LblErrorAlquiler.ForeColor = System.Drawing.Color.Red;
                    LblErrorAlquiler.Text = "El vehículo ingresado no existe en la base de datos";
                }
                else
                {
                    int oCosto = (oFechaFin.Subtract(oFechaIni)).Days * oVehiculo.CostoAlquiler;

                    Alquiler unAlquiler = new Alquiler(oCliente, oVehiculo, oFechaIni, oFechaFin, oCosto);

                    LogicaAlquiler.Confirmar_Alquiler(unAlquiler);
                    LblErrorAlquiler.ForeColor = System.Drawing.Color.Blue;
                    LblErrorAlquiler.Text = "El alquiler se realizó correctamente";
                    BtnConfirmarAlquiler.Enabled = false;
                    BtnCancelarAlquiler.Enabled = false;
                    BtnOkAlquiler.Visible = true;
                }
            }

            catch (Exception ex)
            {
                LblErrorAlquiler.ForeColor = System.Drawing.Color.Red;
                LblErrorAlquiler.Text = ex.Message;
            }
        }

        protected void CalInicioAlquiler_SelectionChanged(object sender, EventArgs e)
        {
            LblErrorAlquiler.Text = "";
            TBInicioAlquiler.Text = CalInicioAlquiler.SelectedDate.ToShortDateString();
            if (CalInicioAlquiler.SelectedDate.Date < DateTime.Now.Date)
                LblErrorAlquiler.Text = "La fecha de Inicio no puede ser anterior al día de hoy";
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

        protected void BtnVolverAlquiler_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void BtnCancelarAlquiler_Click(object sender, EventArgs e)
        {
            LimpioFormulario();
        }

        protected void BtnOkAlquiler_Click(object sender, EventArgs e)
        {
            LimpioFormulario();
        }
    }
}