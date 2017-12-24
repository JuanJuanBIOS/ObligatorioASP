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
            BtnConfirmarAutos.Enabled = false;
            BtnEliminarAutos.Enabled = false;

            LblErrorAutos.ForeColor = System.Drawing.Color.Red;
            LblErrorAutos.Text = "";
            TBMarcaAutos.Text = "";
            TBModeloAutos.Text = "";
            TBAnioAutos.Text = "";
            TBCantPuertasAutos.Text = "";
            TBCostoDiarioAutos.Text = "";
            TBCategoriaAutos.Text = "";
            DDLTipoAutos.ClearSelection();

            BloqueoCampos();
        }

        private void BloqueoCampos()
        {
            TBMarcaAutos.Enabled = false;
            TBModeloAutos.Enabled = false;
            TBAnioAutos.Enabled = false;
            TBCantPuertasAutos.Enabled = false;
            TBCostoDiarioAutos.Enabled = false;
            TBCategoriaAutos.Enabled = false;
            DDLTipoAutos.Enabled = false;
        }

        private void HabilitoCampos()
        {
            TBMarcaAutos.Enabled = true;
            TBModeloAutos.Enabled = true;
            TBAnioAutos.Enabled = true;
            TBCantPuertasAutos.Enabled = true;
            TBCostoDiarioAutos.Enabled = true;
            DDLTipoAutos.Enabled = true;
        }

        private void ActivoBotonesA()
        {
            BtnCrearAutos.Enabled = true;
            BtnModificarAutos.Enabled = false;
            BtnConfirmarAutos.Enabled = false;
            BtnEliminarAutos.Enabled = false;

            TBCategoriaAutos.Text = "Auto";

            HabilitoCampos();
        }

        private void ActivoBotonesBM()
        {
            //Activo botones solo para Baja y Modificacion
            BtnCrearAutos.Enabled = false;
            BtnModificarAutos.Enabled = true;
            BtnConfirmarAutos.Enabled = false;
            BtnEliminarAutos.Enabled = true;

            BloqueoCampos();
        }

        private void ActivoCamposM()
        {
            BtnCrearAutos.Enabled = false;
            BtnModificarAutos.Enabled = false;
            BtnConfirmarAutos.Enabled = true;
            BtnEliminarAutos.Enabled = false;

            HabilitoCampos();
            TBInMatriculaAutos.Enabled = false;
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
                LblErrorAutos.ForeColor = System.Drawing.Color.Red;
                LblErrorAutos.Text = "Ingrese una matrícula válida";
                return;
            }

            try
            {
                Vehiculo Veh = LogicaVehiculo.Buscar(matricula);

                if (Veh == null)
                {
                    LblErrorAutos.ForeColor = System.Drawing.Color.Red;
                    LblErrorAutos.Text = "La matrícula ingresada no existe en la base de datos. Ingrese los datos y presione 'Crear'";
                    this.ActivoBotonesA();
                    TBAnioAutos.Text = "0";
                    TBCantPuertasAutos.Text = "0";
                    TBCostoDiarioAutos.Text = "0";
                }

                else if (Veh is Utilitario)
                {
                    LblErrorAutos.ForeColor = System.Drawing.Color.Red;
                    throw new Exception("La matrícula ingresada corresponde a un Utilitario");
                    this.LimpioFormulario();
                }
                else if (Veh is Auto)
                {
                    TBMarcaAutos.Text = Veh.Marca;
                    TBModeloAutos.Text = Veh.Modelo;
                    TBAnioAutos.Text = Convert.ToString(Veh.Año);
                    TBCantPuertasAutos.Text = Convert.ToString(Veh.CantPuertas);
                    TBCostoDiarioAutos.Text = Convert.ToString(Veh.CostoAlquiler);
                    TBCategoriaAutos.Text = Veh.Categoria;
                    DDLTipoAutos.SelectedValue = ((Auto)Veh).TipoA;
                    ActivoBotonesBM();
                }
            }
            catch (Exception ex)
            {
                LblErrorAutos.ForeColor = System.Drawing.Color.Red;
                LblErrorAutos.Text = ex.Message;
            }
        }

        protected void BtnCrearAutos_Click(object sender, EventArgs e)
        {
            try
            {
                string oMatricula = Convert.ToString(TBInMatriculaAutos.Text);
                string oMarca = Convert.ToString(TBMarcaAutos.Text);
                string oModelo = Convert.ToString(TBModeloAutos.Text);
                int oAnio = Convert.ToInt32(TBAnioAutos.Text);
                int oCantPuertas = Convert.ToInt32(TBCantPuertasAutos.Text);
                int oCostoDiario = Convert.ToInt32(TBCostoDiarioAutos.Text);
                string oCateogria = Convert.ToString(TBCategoriaAutos.Text);
                string oTipo = Convert.ToString(DDLTipoAutos.SelectedValue);

                Auto unAuto = new Auto(oMatricula, oMarca, oModelo, oAnio, oCantPuertas, oCostoDiario, oCateogria, oTipo);

                LogicaVehiculo.Crear(unAuto);
                LblErrorAutos.ForeColor = System.Drawing.Color.Blue;
                LblErrorAutos.Text = "El Auto ha sido ingresado a la base de datos correctamente.";
                BloqueoCampos();
            }

            catch (Exception ex)
            {
                LblErrorAutos.ForeColor = System.Drawing.Color.Red;
                LblErrorAutos.Text = ex.Message;
            }
        }

        protected void BtnVolverAuto_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void BtnModificarAutos_Click(object sender, EventArgs e)
        {
            ActivoCamposM();
        }

        protected void BtnConfirmarAutos_Click(object sender, EventArgs e)
        {
            try
            {
                string oMatricula = Convert.ToString(TBInMatriculaAutos.Text);
                string oMarca = Convert.ToString(TBMarcaAutos.Text);
                string oModelo = Convert.ToString(TBModeloAutos.Text);
                int oAnio = Convert.ToInt32(TBAnioAutos.Text);
                int oCantPuertas = Convert.ToInt32(TBCantPuertasAutos.Text);
                int oCostoDiario = Convert.ToInt32(TBCostoDiarioAutos.Text);
                string oCateogria = Convert.ToString(TBCategoriaAutos.Text);
                string oTipo = Convert.ToString(DDLTipoAutos.SelectedValue);

                Auto unAuto = new Auto(oMatricula, oMarca, oModelo, oAnio, oCantPuertas, oCostoDiario, oCateogria, oTipo);

                LogicaVehiculo.Modificar(unAuto);
                LblErrorAutos.ForeColor = System.Drawing.Color.Blue;
                LblErrorAutos.Text = "El Auto ha sido modificaro correctamente.";
                BloqueoCampos();
                TBInMatriculaAutos.Enabled = true;
            }

            catch (Exception ex)
            {
                LblErrorAutos.ForeColor = System.Drawing.Color.Red;
                LblErrorAutos.Text = ex.Message;
            }
        }

        protected void BtnEliminarAutos_Click(object sender, EventArgs e)
        {

            try
            {
                string oMatricula = Convert.ToString(TBInMatriculaAutos.Text);
                string oMarca = Convert.ToString(TBMarcaAutos.Text);
                string oModelo = Convert.ToString(TBModeloAutos.Text);
                int oAnio = Convert.ToInt32(TBAnioAutos.Text);
                int oCantPuertas = Convert.ToInt32(TBCantPuertasAutos.Text);
                int oCostoDiario = Convert.ToInt32(TBCostoDiarioAutos.Text);
                string oCateogria = Convert.ToString(TBCategoriaAutos.Text);
                string oTipo = Convert.ToString(DDLTipoAutos.SelectedValue);

                Auto unAuto = new Auto(oMatricula, oMarca, oModelo, oAnio, oCantPuertas, oCostoDiario, oCateogria, oTipo);

                BtnBuscarAutos_Click(unAuto, e);
                LogicaVehiculo.Eliminar(unAuto);
                LimpioFormulario();
                LblErrorAutos.ForeColor = System.Drawing.Color.Blue;
                LblErrorAutos.Text = "El Auto ha sido eliminado correctamente.";
            }

            catch (Exception ex)
            {
                LblErrorAutos.ForeColor = System.Drawing.Color.Red;
                LblErrorAutos.Text = ex.Message;
            }
        }
    }
}