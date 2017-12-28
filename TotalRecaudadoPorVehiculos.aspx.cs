using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;

namespace ObligatorioASPNET
{
    public partial class TotalRecaudadoPorVehiculos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnTotal_Click(object sender, EventArgs e)
        {
            try
            {

                Vehiculo unV = null;
                unV = Logica.LogicaVehiculo.Buscar(TBInMatriculaTot.Text);
                if (unV != null)
                {
                    //Obtengo los alquileres del auto
                    List<EntidadesCompartidas.Alquiler> _lista = Logica.LogicaAlquiler.Listar_Alquileres_Por_Vehiculo(unV);
                    
                    //Total del vehiculo en etiqueta
                    Int32 Resultado = Logica.LogicaAlquiler.Total_Vehiculo(unV);
                    LblTotal.Text = Resultado.ToString();


                    GVAlquileres.DataSource = _lista;
                    GVAlquileres.DataBind();
                }
                else
                {
                    TBInMatriculaTot.Text = "";
                    GVAlquileres.DataSource = null;
                    GVAlquileres.DataBind();
                    LblErrorTot.Text = "Matricula no encontrada";
                }
            }
            catch (Exception ex)
            {
                LblErrorTot.Text = ex.Message;
            }

        }
        protected void BtnVolverUtilitario_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }


    }
}