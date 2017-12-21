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
            BtnCrear.Enabled = false;
            BtnModificar.Enabled = false;
            BtnEliminar.Enabled = false;
            BtnBuscar.Enabled = true;

            TBInDocumento.Enabled = true;
        }

        private void ActivoBotonesBM()
        {
            //Activo botones solo para Baja y Modificacion
            BtnCrear.Enabled = false;
            BtnModificar.Enabled = true;
            BtnEliminar.Enabled = true;
            BtnBuscar.Enabled = false;

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
                    this.ActivoBotonesBM();


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


        protected void BtnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente cli_m = (Cliente)Session["ClienteModificado"];

                //modifico el objeto
                cli_m.Nombre=TBNombre.Text;
                cli_m.Cedula=Convert.ToInt32(TBInDocumento.Text);
                cli_m.Tarjeta = Convert.ToInt64(TBTarjeta.Text);
                cli_m.Direccion = TBDireccion.Text;
                cli_m.FechaNac = Convert.ToDateTime(TBFechaNac.Text);
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