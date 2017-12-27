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

            LblErrorClientes.ForeColor = System.Drawing.Color.Red;
            LblErrorClientes.Text = "";
            TBNombreClientes.Text = "";
            TBTarjetaClientes.Text = "";
            TBTelefonoClientes.Text = "";
            TBDireccionClientes.Text = "";
            TBFechaNacClientes.Text = "";

            
            
            BloqueoCampos();
        }

        private void BloqueoCampos()
        {
            TBNombreClientes.Enabled = false;
            TBTarjetaClientes.Enabled = false;
            TBTelefonoClientes.Enabled = false;
            TBDireccionClientes.Enabled = false;
            TBFechaNacClientes.Enabled = false;

        }

        private void HabilitoCampos()
        {
            TBNombreClientes.Enabled = true;
            TBTarjetaClientes.Enabled = true;
            TBTelefonoClientes.Enabled = true;
            TBDireccionClientes.Enabled = true;
            TBFechaNacClientes.Enabled = true;
        }

        private void ActivoBotonesA()
        {
            BtnCrearClientes.Enabled = true;
            BtnModificarClientes.Enabled = false;
            BtnConfirmarClientes.Enabled = false;
            BtnEliminarClientes.Enabled = false;
            HabilitoCampos();
        }


        private void ActivoBotonesBM()
        {
            //Activo botones solo para Baja y Modificacion
            BtnCrearClientes.Enabled = false;
            BtnModificarClientes.Enabled = true;
            BtnEliminarClientes.Enabled = true;
            BtnConfirmarClientes.Enabled = true;
            BtnBuscarClientes.Enabled = false;

            BloqueoCampos();

        }

        private void ActivoCamposM()
        {
            BtnCrearClientes.Enabled = false;
            BtnModificarClientes.Enabled = false;
            BtnConfirmarClientes.Enabled = true;
            BtnEliminarClientes.Enabled = false;

            HabilitoCampos();
            TBInDocumento.Enabled = false;
        }




        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            this.LimpioFormulario();

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
                    TBFechaNacClientes.Text = Convert.ToString(Cli.FechaNac.ToShortDateString());
                    this.ActivoBotonesBM();


                }
                else
                {
                    LblErrorClientes.Text = "El Cliente no existe en la base de datos. Ingrese los datos y presione Crear";
                    this.ActivoBotonesA();
                }
            }
            catch (Exception ex)
            {
                LblErrorClientes.Text = ex.Message;
            }
        }


        protected void BtnModificarClientes_Click(object sender, EventArgs e)
        {
            ActivoCamposM();
        }

        protected void BtnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void BtnConfirmarClientes_Click(object sender, EventArgs e)
        {
            try
            {
                string oNombre = TBNombreClientes.Text;
                Int32 oCedula = Convert.ToInt32(TBInDocumento.Text);
                Int64 oTrajeta = Convert.ToInt64(TBTarjetaClientes.Text);
                string oTelefono = TBTelefonoClientes.Text;
                string oDireccion = TBDireccionClientes.Text;
                DateTime oFecaNac = Convert.ToDateTime(TBFechaNacClientes.Text);

                Cliente unCliente = new Cliente(oNombre, oCedula, oTrajeta, oTelefono, oDireccion, oFecaNac);

                LogicaCliente.Modificar(unCliente);

                this.ActivoBotonesBM();
            }
            catch (Exception ex)
            {
                LblErrorClientes.Text = ex.Message;
            }

        }

        protected void BtnEliminarClientes_Click(object sender, EventArgs e)
        {

            try
            {
                LogicaCliente.Eliminar(LogicaCliente.Buscar(Convert.ToInt32(TBInDocumento.Text)));
                LimpioFormulario();
                LblErrorClientes .ForeColor = System.Drawing.Color.Blue;
                LblErrorClientes.Text = "El Cliente se ha sido eliminado correctamente";

                
            }
            catch (Exception ex)
            {
                LblErrorClientes.ForeColor = System.Drawing.Color.Red;
                LblErrorClientes.Text = ex.Message;
            }
        }

        protected void BtnCrearClientes_Click(object sender, EventArgs e)
        {
            try
            {
                string oNombre = TBNombreClientes.Text;
                Int32 oCedula = Convert.ToInt32(TBInDocumento.Text);
                Int64 oTarjeta = Convert.ToInt64(TBTarjetaClientes.Text);
                string oTelefono = TBTelefonoClientes.Text;
                string oDireccion = TBDireccionClientes.Text;
                DateTime oFecaNac = Convert.ToDateTime(TBFechaNacClientes.Text);

                Cliente unCliente = new Cliente(oNombre,oCedula,oTarjeta,oTelefono,oDireccion,oFecaNac);


                LogicaCliente.Crear(unCliente);
                LblErrorClientes.ForeColor = System.Drawing.Color.Blue;
                LblErrorClientes.Text = "El Cliente ha sido ingresado a la base de datos correctamente.";
                BloqueoCampos();
            }

            catch (Exception ex)
            {
                LblErrorClientes.ForeColor = System.Drawing.Color.Red;
                LblErrorClientes.Text = ex.Message;
            }
        }

        }


    }