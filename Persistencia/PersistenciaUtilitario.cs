using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using System.Data.SqlClient;
using System.Web;

namespace Persistencia
{
    public class PersistenciaUtilitario
    {
        public static Utilitario Buscar(string matricula)
        {
            //Propiedades
            string oMatricula;
            string oMarca;
            string oModelo;
            int oAnio;
            int oCantPuertas;
            int oCostoDiario;
            string oCateogria;
            int oCapCarga;
            string oTipo;


            Utilitario U = null;

            //Variables de conexión
            SqlDataReader oReader;
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("Exec Buscar_Utilitario " + matricula, oConexion);

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
                    oCapCarga = (int)oReader["capacidad"];
                    oTipo = (string)oReader["tipo"];

                    U = new Utilitario(oMatricula, oMarca, oModelo, oAnio, oCantPuertas, oCostoDiario, oCateogria, oCapCarga, oTipo);
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

            return U;
        }
    }
}
