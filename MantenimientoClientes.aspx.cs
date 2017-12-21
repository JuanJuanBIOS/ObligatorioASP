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
    public partial class MantenimientoClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                this.LimpioFormulario();
        }


        private void LimpioFormulario()
        {
            //Bloqueo botones si no hay registro
            BtnCrearClientes.Enabled = false;
            BtnModificarClientes.Enabled = false;
            BtnEliminarClientes.Enabled = false;
            BtnBuscarClientes.Enabled = true;

            TBInDocumento.Enabled = true;
        }

        private void ActivoBotonesBM()
        {
            //Activo botones solo para Baja y Modificacion
            BtnCrearClientes.Enabled = false;
            BtnModificarClientes.Enabled = true;
            BtnEliminarClientes.Enabled = true;
            BtnBuscarClientes.Enabled = false;

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
                LblErrorClientes.Text = "Ingrese un numero";
                return;
            }

            try
            {
                Cliente Cli = LogicaCliente.Buscar(cedula);

                if (Cli != null)
                {
                    TBNombreClientes.Text = Cli.Nombre;
                    TBTarjetaClientes.Text = Convert.ToString(Cli.Tarjeta);
                    TBTelefonoClientes.Text = Convert.ToString(Cli.Telefono);
                    TBDireccionClientes.Text = Cli.Direccion;
                    TBFechaNacClientes.Text = Convert.ToString(Cli.FechaNac);
                    this.ActivoBotonesBM();


                }
                else
                {
                    LblErrorClientes.Text = "Objeto es nulo";
                }
            }
            catch (Exception ex)
            {
                LblErrorClientes.Text = ex.Message;
            }
        }


        protected void BtnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente cli_m = (Cliente)Session["ClienteModificado"];

                //modifico el objeto
                cli_m.Nombre = TBNombreClientes.Text;
                cli_m.Cedula=Convert.ToInt32(TBInDocumento.Text);
                cli_m.Tarjeta = Convert.ToInt64(TBTarjetaClientes.Text);
                cli_m.Direccion = TBDireccionClientes.Text;
                cli_m.FechaNac = Convert.ToDateTime(TBFechaNacClientes.Text);
                this.ActivoBotonesBM();
                //Cliente.Modificar(cli_m);
                //lblError.Text = "Modificacion con éxito";
                //this.LimpioFormulario();
            }
            catch (Exception ex)
            {
               // lblError.Text = ex.Message;
            }
        }


    }
}