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
    public partial class MantenimientoUtilitarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                this.LimpioFormulario();
        }

        private void LimpioFormulario()
        {
            //Bloqueo botones si no hay registro
            BtnCrearUtilitario.Enabled = false;
            BtnModificarUtilitario.Enabled = false;
            BtnEliminarUtilitario.Enabled = false;
            BtnBuscarUtilitario.Enabled = true;

            TBInMatriculaUtilitario.Enabled = true;
            LblErrorUtilitario.Text = "";
            TBMarcaUtilitario.Text = "";
            TBModeloUtilitario.Text = "";
            TBAnioUtilitario.Text = "";
            TBCantPuertasUtilitario.Text = "";
            TBCostoDiarioUtilitario.Text = "";
            TBCategoriaUtilitario.Text = "";
            TBCapacidadUtilitario.Text = "";
            TBTipoUtilitario.Text = "";
        }

        private void ActivoBotonesA()
        {
            BtnModificarUtilitario.Enabled = false;
            BtnEliminarUtilitario.Enabled = false;

            BtnCrearUtilitario.Enabled = true;
            BtnBuscarUtilitario.Enabled = true;
        }

        private void ActivoBotonesBM()
        {
            //Activo botones solo para Baja y Modificacion
            BtnCrearUtilitario.Enabled = false;
            BtnModificarUtilitario.Enabled = true;
            BtnEliminarUtilitario.Enabled = true;
            BtnBuscarUtilitario.Enabled = false;

        }

        protected void BtnBuscarUtilitario_Click1(object sender, EventArgs e)
        {
            string matricula;
            this.LimpioFormulario();

            try
            {
                matricula = Convert.ToString(TBInMatriculaUtilitario.Text);
            }
            catch
            {
                LblErrorUtilitario.Text = "Ingrese una matrícula válida";
                return;
            }

            try
            {
                Vehiculo Veh = LogicaVehiculo.Buscar(matricula);

                if (Veh == null)
                {
                    LblErrorUtilitario.Text = "La matrícula ingresada no existe en la base de datos. Ingrese los datos y presione 'Crear'";
                    this.ActivoBotonesA();
                }

                else if (Veh is Auto)
                {
                    throw new Exception("La matrícula ingresada corresponde a un Auto");
                }
                else if (Veh is Utilitario)
                {
                    TBMarcaUtilitario.Text = Veh.Marca;
                    TBModeloUtilitario.Text = Veh.Modelo;
                    TBAnioUtilitario.Text = Convert.ToString(Veh.Año);
                    TBCantPuertasUtilitario.Text = Convert.ToString(Veh.CantPuertas);
                    TBCostoDiarioUtilitario.Text = "$ " + Convert.ToString(Veh.CostoAlquiler);
                    TBCategoriaUtilitario.Text = Convert.ToString(Veh.Categoria);
                    TBCapacidadUtilitario.Text = Convert.ToString(((Utilitario)Veh).CapCarga) + " kg";
                    TBTipoUtilitario.Text = ((Utilitario)Veh).Tipo;
                    ActivoBotonesBM();
                }
            }
            catch (Exception ex)
            {
                LblErrorUtilitario.Text = ex.Message;
            }
        }
        
        protected void BtnVolverUtilitario_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}