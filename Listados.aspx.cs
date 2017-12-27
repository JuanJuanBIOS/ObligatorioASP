using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using EntidadesCompartidas;
using Logica;

namespace ObligatorioASPNET
{
    public partial class Listados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                this.LimpioFormulario();
        }

        private void LimpioFormulario()
        {
            CalInicioListado.Enabled = true;
            CalFinListado.Enabled = true;

            LblErrorListado.ForeColor = System.Drawing.Color.Red;
            LblErrorListado.Text = "";
        }

        protected void CalInicioListado_SelectionChanged(object sender, EventArgs e)
        {
            LblErrorListado.Text = "";
            TBInicioListado.Text = CalInicioListado.SelectedDate.ToShortDateString();
            if (CalInicioListado.SelectedDate.Date < DateTime.Now.Date)
            {
                LblErrorListado.ForeColor = System.Drawing.Color.Red;
                LblErrorListado.Text = "La fecha de Inicio no puede ser anterior al día de hoy";
            }
            if (CalInicioListado.SelectedDate >= CalFinListado.SelectedDate && TBFinListado.Text != "")
            {
                LblErrorListado.ForeColor = System.Drawing.Color.Red;
                LblErrorListado.Text = "La fecha de Fin debe ser mayor a la fecha de Inicio";
            }
            if (LblErrorListado.Text == "" && TBFinListado.Text != "")
                BtnVerListado.Enabled = true;
        }

        protected void CalFinListado_SelectionChanged(object sender, EventArgs e)
        {
            LblErrorListado.Text = "";
            TBFinListado.Text = CalFinListado.SelectedDate.ToShortDateString();
            if (CalInicioListado.SelectedDate.Date < DateTime.Now.Date)
            {
                LblErrorListado.ForeColor = System.Drawing.Color.Red;
                LblErrorListado.Text = "La fecha de Inicio no puede ser anterior al día de hoy";
            }
            if (CalInicioListado.SelectedDate >= CalFinListado.SelectedDate && TBInicioListado.Text != "")
            {
                LblErrorListado.Text = "La fecha de Fin debe ser mayor a la fecha de Inicio";
                LblErrorListado.ForeColor = System.Drawing.Color.Red;
            }
            if (LblErrorListado.Text == "" && TBInicioListado.Text != "")
                BtnVerListado.Enabled = true;
        }

        protected void BtnVolverListado_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void BtnVerListado_Click(object sender, EventArgs e)
        {
            try
            {
                if ((TBInicioListado.Text == "") || (TBFinListado.Text == ""))
                {
                    LblErrorListado.ForeColor = System.Drawing.Color.Red;
                    LblErrorListado.Text = "Se debe seleccionar una fecha de inicio y una fecha de fin para ver el listado";
                }
                else
                {
                    GVDisponiblesListado.DataSource = LogicaVehiculo.Dispoibles_por_periodo(Convert.ToDateTime(TBInicioListado.Text), Convert.ToDateTime(TBFinListado.Text));
                    GVDisponiblesListado.DataBind();
                }
            }
            catch (Exception ex)
            {
                LblErrorListado.ForeColor = System.Drawing.Color.Red;
                LblErrorListado.Text = ex.Message;
            }
        }


    }
}