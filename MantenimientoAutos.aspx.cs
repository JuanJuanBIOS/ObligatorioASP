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
            BtnCrearAutos.Enabled = false;
            BtnModificarAutos.Enabled = false;
            BtnEliminarAutos.Enabled = false;
            BtnBuscarAutos.Enabled = true;

            TBInMatriculaAutos.Enabled = true;
            LblErrorAutos.Text = "";
            TBMarcaAutos.Text = "";
            TBModeloAutos.Text = "";
            TBAnioAutos.Text = "";
            TBCantPuertasAutos.Text = "";
            TBCostoDiarioAutos.Text = "";
            TBCategoriaAutos.Text = "";
            TBTipoAutos.Text = "";
        }

        private void ActivoBotonesA()
        {
            BtnModificarAutos.Enabled = false;
            BtnEliminarAutos.Enabled = false;

            BtnCrearAutos.Enabled = true;
            BtnBuscarAutos.Enabled = false;
        }

        private void ActivoBotonesBM()
        {
            //Activo botones solo para Baja y Modificacion
            BtnCrearAutos.Enabled = false;
            BtnModificarAutos.Enabled = true;
            BtnEliminarAutos.Enabled = true;
            BtnBuscarAutos.Enabled = false;

        }

        protected void BtnBuscarAutos_Click(object sender, EventArgs e)
        {
            string matricula;
            this.LimpioFormulario();

            try
            {
                matricula = Convert.ToString(TBInMatriculaAutos.Text);
            }
            catch
            {
                LblErrorAutos.Text = "Ingrese una matrícula válida";
                return;
            }

            try
            {
                Vehiculo Veh = LogicaVehiculo.Buscar(matricula);

                if (Veh == null)
                {
                    LblErrorAutos.Text = "La matrícula ingresada no existe en la base de datos. Ingrese los datos y presione 'Crear'";
                    this.ActivoBotonesA();
                }

                else if (Veh is Utilitario)
                {
                    throw new Exception("La matrícula ingresada corresponde a un Utilitario");
                }
                else if (Veh is Auto)
                {
                    TBMarcaAutos.Text = Veh.Marca;
                    TBModeloAutos.Text = Veh.Modelo;
                    TBAnioAutos.Text = Convert.ToString(Veh.Año);
                    TBCantPuertasAutos.Text = Convert.ToString(Veh.CantPuertas);
                    TBCostoDiarioAutos.Text = Convert.ToString(Veh.CostoAlquiler);
                    TBCategoriaAutos.Text = Convert.ToString(Veh.Categoria);
                    TBTipoAutos.Text = ((Auto)Veh).TipoA;
                }
            }
            catch (Exception ex)
            {
                LblErrorAutos.Text = ex.Message;
            }
        }
    }
}