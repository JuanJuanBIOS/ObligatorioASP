using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using System.Data.SqlClient;

namespace Persistencia
{
    public class PersistenciaCliente
    {
        public static Cliente Buscar(string cedula)
        {
            int oCedula;
            string oNombre;
            int oTarjeta;
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
                    //oCedula = (int)oReader["documento"];
                    oNombre = (string)oReader["nombre"];
                   // oTarjeta = (int)oReader["tarjeta"];
                   // oTelefono = (string)oReader["telefono"];
                   // oDireccion = (string)oReader["calle"];
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
