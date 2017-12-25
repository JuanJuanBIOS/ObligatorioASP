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
            BtnCrearUtilitarios.Enabled = false;
            BtnModificarUtilitarios.Enabled = false;
            BtnConfirmarUtilitarios.Enabled = false;
            BtnEliminarUtilitarios.Enabled = false;

            LblErrorUtilitarios.ForeColor = System.Drawing.Color.Red;
            LblErrorUtilitarios.Text = "";
            TBMarcaUtilitarios.Text = "";
            TBModeloUtilitarios.Text = "";
            TBAnioUtilitarios.Text = "";
            TBCantPuertasUtilitarios.Text = "";
            TBCostoDiarioUtilitarios.Text = "";
            TBCategoriaUtilitarios.Text = "";
            TBCapacidadUtilitarios.Text = "";
            DDLTipoUtilitario.ClearSelection();

            BloqueoCampos();
        }

        private void BloqueoCampos()
        {
            TBMarcaUtilitarios.Enabled = false;
            TBModeloUtilitarios.Enabled = false;
            TBAnioUtilitarios.Enabled = false;
            TBCantPuertasUtilitarios.Enabled = false;
            TBCostoDiarioUtilitarios.Enabled = false;
            TBCategoriaUtilitarios.Enabled = false;
            TBCapacidadUtilitarios.Enabled = false;
            DDLTipoUtilitario.Enabled = false;
        }

        private void HabilitoCampos()
        {
            TBMarcaUtilitarios.Enabled = true;
            TBModeloUtilitarios.Enabled = true;
            TBAnioUtilitarios.Enabled = true;
            TBCantPuertasUtilitarios.Enabled = true;
            TBCostoDiarioUtilitarios.Enabled = true;
            TBCapacidadUtilitarios.Enabled = true;
            DDLTipoUtilitario.Enabled = true;
        }

        private void ActivoBotonesA()
        {
            BtnCrearUtilitarios.Enabled = true;
            BtnModificarUtilitarios.Enabled = false;
            BtnConfirmarUtilitarios.Enabled = false;
            BtnEliminarUtilitarios.Enabled = false;

            TBCategoriaUtilitarios.Text = "Utilitario";

            HabilitoCampos();
        }

        private void ActivoBotonesBM()
        {
            //Activo botones solo para Baja y Modificacion
            BtnCrearUtilitarios.Enabled = false;
            BtnModificarUtilitarios.Enabled = true;
            BtnConfirmarUtilitarios.Enabled = false;
            BtnEliminarUtilitarios.Enabled = true;

            BloqueoCampos();
        }

        private void ActivoCamposM()
        {
            BtnCrearUtilitarios.Enabled = false;
            BtnModificarUtilitarios.Enabled = false;
            BtnConfirmarUtilitarios.Enabled = true;
            BtnEliminarUtilitarios.Enabled = false;

            HabilitoCampos();
            TBInMatriculaUtilitarios.Enabled = false;
        }

        protected void BtnBuscarUtilitario_Click1(object sender, EventArgs e)
        {
            string matricula;
            this.LimpioFormulario();

            try
            {
                matricula = Convert.ToString(TBInMatriculaUtilitarios.Text);
            }
            catch
            {
                LblErrorUtilitarios.ForeColor = System.Drawing.Color.Red;
                LblErrorUtilitarios.Text = "Ingrese una matrícula válida";
                return;
            }

            try
            {
                Vehiculo Veh = LogicaVehiculo.Buscar(matricula);

                if (Veh == null)
                {
                    LblErrorUtilitarios.ForeColor = System.Drawing.Color.Red;
                    LblErrorUtilitarios.Text = "La matrícula ingresada no existe en la base de datos. Ingrese los datos y presione 'Crear'";
                    this.ActivoBotonesA();
                    TBAnioUtilitarios.Text = "0";
                    TBCantPuertasUtilitarios.Text = "0";
                    TBCostoDiarioUtilitarios.Text = "0";
                    TBCapacidadUtilitarios.Text = "0";
                }

                else if (Veh is Auto)
                {
                    LblErrorUtilitarios.ForeColor = System.Drawing.Color.Red;
                    throw new Exception("La matrícula ingresada corresponde a un Auto");
                    this.LimpioFormulario();
                }
                else if (Veh is Utilitario)
                {
                    TBMarcaUtilitarios.Text = Veh.Marca;
                    TBModeloUtilitarios.Text = Veh.Modelo;
                    TBAnioUtilitarios.Text = Convert.ToString(Veh.Año);
                    TBCantPuertasUtilitarios.Text = Convert.ToString(Veh.CantPuertas);
                    TBCostoDiarioUtilitarios.Text = Convert.ToString(Veh.CostoAlquiler);
                    TBCategoriaUtilitarios.Text = Convert.ToString(Veh.Categoria);
                    TBCapacidadUtilitarios.Text = Convert.ToString(((Utilitario)Veh).CapCarga);
                    DDLTipoUtilitario.SelectedValue = ((Utilitario)Veh).Tipo;
                    ActivoBotonesBM();
                }
            }
            catch (Exception ex)
            {
                LblErrorUtilitarios.ForeColor = System.Drawing.Color.Red;
                LblErrorUtilitarios.Text = ex.Message;
            }
        }

        protected void BtnCrearUtilitarios_Click1(object sender, EventArgs e)
        {
            try
            {
                string oMatricula = Convert.ToString(TBInMatriculaUtilitarios.Text);
                string oMarca = Convert.ToString(TBMarcaUtilitarios.Text);
                string oModelo = Convert.ToString(TBModeloUtilitarios.Text);
                int oAnio = Convert.ToInt32(TBAnioUtilitarios.Text);
                int oCantPuertas = Convert.ToInt32(TBCantPuertasUtilitarios.Text);
                int oCostoDiario = Convert.ToInt32(TBCostoDiarioUtilitarios.Text);
                string oCateogria = Convert.ToString(TBCategoriaUtilitarios.Text);
                int oCapacidad = Convert.ToInt32(TBCapacidadUtilitarios.Text);
                string oTipo = Convert.ToString(DDLTipoUtilitario.SelectedValue);

                Utilitario unUtilitario = new Utilitario(oMatricula, oMarca, oModelo, oAnio, oCantPuertas, oCostoDiario, oCateogria, oCapacidad, oTipo);

                LogicaVehiculo.Crear(unUtilitario);
                LblErrorUtilitarios.ForeColor = System.Drawing.Color.Blue;
                LblErrorUtilitarios.Text = "El Utilitario ha sido ingresado a la base de datos correctamente.";
                BloqueoCampos();
            }

            catch (Exception ex)
            {
                LblErrorUtilitarios.ForeColor = System.Drawing.Color.Red;
                LblErrorUtilitarios.Text = ex.Message;
            }
        }


        protected void BtnVolverUtilitario_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void BtnModificarUtilitarios_Click(object sender, EventArgs e)
        {
            ActivoCamposM();
        }

        protected void BtnConfirmarUtilitarios_Click(object sender, EventArgs e)
        {
            try
            {
                string oMatricula = Convert.ToString(TBInMatriculaUtilitarios.Text);
                string oMarca = Convert.ToString(TBMarcaUtilitarios.Text);
                string oModelo = Convert.ToString(TBModeloUtilitarios.Text);
                int oAnio = Convert.ToInt32(TBAnioUtilitarios.Text);
                int oCantPuertas = Convert.ToInt32(TBCantPuertasUtilitarios.Text);
                int oCostoDiario = Convert.ToInt32(TBCostoDiarioUtilitarios.Text);
                string oCateogria = Convert.ToString(TBCategoriaUtilitarios.Text);
                int oCapacidad = Convert.ToInt32(TBCapacidadUtilitarios.Text);
                string oTipo = Convert.ToString(DDLTipoUtilitario.SelectedValue);

                Utilitario unUtilitario = new Utilitario(oMatricula, oMarca, oModelo, oAnio, oCantPuertas, oCostoDiario, oCateogria, oCapacidad, oTipo);

                LogicaVehiculo.Modificar(unUtilitario);
                LblErrorUtilitarios.ForeColor = System.Drawing.Color.Blue;
                LblErrorUtilitarios.Text = "El Utilitario ha sido modificado correctamente.";
                BloqueoCampos();
                TBInMatriculaUtilitarios.Enabled = true;
            }

            catch (Exception ex)
            {
                LblErrorUtilitarios.ForeColor = System.Drawing.Color.Red;
                LblErrorUtilitarios.Text = ex.Message;
            }
        }

        protected void BtnEliminarUtilitarios_Click(object sender, EventArgs e)
        {
            try
            {
                string oMatricula = Convert.ToString(TBInMatriculaUtilitarios.Text);
                string oMarca = Convert.ToString(TBMarcaUtilitarios.Text);
                string oModelo = Convert.ToString(TBModeloUtilitarios.Text);
                int oAnio = Convert.ToInt32(TBAnioUtilitarios.Text);
                int oCantPuertas = Convert.ToInt32(TBCantPuertasUtilitarios.Text);
                int oCostoDiario = Convert.ToInt32(TBCostoDiarioUtilitarios.Text);
                string oCateogria = Convert.ToString(TBCategoriaUtilitarios.Text);
                int oCapacidad = Convert.ToInt32(TBCapacidadUtilitarios.Text);
                string oTipo = Convert.ToString(DDLTipoUtilitario.SelectedValue);

                Utilitario unUtilitario = new Utilitario(oMatricula, oMarca, oModelo, oAnio, oCantPuertas, oCostoDiario, oCateogria, oCapacidad, oTipo);

                LogicaVehiculo.Eliminar(unUtilitario);
                LimpioFormulario();
                LblErrorUtilitarios.ForeColor = System.Drawing.Color.Blue;
                LblErrorUtilitarios.Text = "El Utilitario ha sido eliminado correctamente.";
            }

            catch (Exception ex)
            {
                LblErrorUtilitarios.ForeColor = System.Drawing.Color.Red;
                LblErrorUtilitarios.Text = ex.Message;
            }
        }

    }
}