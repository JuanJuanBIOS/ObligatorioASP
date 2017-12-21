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
    public partial class MantenimientoAutos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                this.LimpioFormulario();
        }

        private void LimpioFormulario()
        {
            //Bloqueo botones si no hay registro
            //BtnCrearAutos.Enabled = false;
            //BtnModificarAutos.Enabled = false;
            //BtnEliminarAutos.Enabled = false;
            BtnBuscarAutos.Enabled = true;

            TBInMatriculaAutos.Enabled = true;
        }

        private void ActivoBotonesBM()
        {
            //Activo botones solo para Baja y Modificacion
            //BtnCrearAutos.Enabled = false;
            //BtnModificarAutos.Enabled = true;
            //BtnEliminarAutos.Enabled = true;
            BtnBuscarAutos.Enabled = false;

        }

    }
}