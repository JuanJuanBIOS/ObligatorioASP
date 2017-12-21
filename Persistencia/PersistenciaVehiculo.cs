using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using System.Data.SqlClient;
using System.Web;

namespace Persistencia
{
    public class PersistenciaVehiculo
    {
        public static Vehiculo Buscar(string matricula)
        {
            //Propiedades
            string oMatricula;
            string oMarca;
            string oModelo;
            int oAnio;
            int oCantPuertas;
            int oCostoDiario;
            string oCateogria;


            Vehiculo V = null;

            //Variables de conexión
            SqlDataReader oReader;
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("Exec Buscar_Vehiculo " + matricula, oConexion);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.Read())
                {

                    oMatricula = (string)oReader["matricula"];
                    oMarca = (string)oReader["marca"];
                    oModelo = (string)oReader["modelo"];
                    oAnio = (int)oReader["anio"];
                    oCantPuertas = (int)oReader["cant_puertas"];
                    oCostoDiario = (int)oReader["costodiario"];
                    oCateogria = (string)oReader["categoria"];

                    V = new Vehiculo(oMatricula, oMarca, oModelo, oAnio, oCantPuertas, oCostoDiario, oCateogria);
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

            return V;
        }
    }
}
