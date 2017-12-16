using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using System.Data.SqlClient;
using System.Web;

namespace Persistencia
{
    public class PersistenciaCliente
    {
        public static Cliente Buscar(int cedula)
        {
            int oCedula;
            string oNombre;
            long oTarjeta;
            string oTelefono;
            string oDireccion;
            DateTime oFechaNac;
    
            Cliente C = null;

            SqlDataReader oReader;
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("Exec Buscar_Cliente "+ cedula, oConexion);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.Read())
                {

                    oCedula = (int)oReader["documento"];
                    oNombre = (string)oReader["nombre"];
                    oTarjeta = (long)oReader["tarjeta"];
                    oTelefono = (string)oReader["telefono"];
                    oDireccion = (string)oReader["direccion"];
                    oFechaNac = (DateTime)oReader["fechanac"];

                    C = new Cliente(oNombre, oCedula, oTarjeta, oTelefono, oDireccion, oFechaNac);
                }
                oReader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }

            return C;
        }

    }
}
