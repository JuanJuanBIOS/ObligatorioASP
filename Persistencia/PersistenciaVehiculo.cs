using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using System.Data.SqlClient;
using System.Web;
using System.Data;

namespace Persistencia
{
    public class PersistenciaVehiculo
    {
        public static List<Vehiculo> Disponibles_por_periodo(DateTime FechaIni, DateTime FechaFin)
        {
            List<Vehiculo> Disponibles = new List<Vehiculo>();
            SqlDataReader oReader;            
            
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("Disponibles_por_periodo ", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@fechainicio", FechaIni.Date);
            oComando.Parameters.AddWithValue("@fechafin", FechaFin.Date);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        Vehiculo V = new Vehiculo(oReader["matricula"].ToString(), oReader["marca"].ToString(), oReader["modelo"].ToString(), Convert.ToInt32(oReader["anio"]), Convert.ToInt32(oReader["cant_puertas"]), Convert.ToInt32(oReader["costo diario"]), oReader["categoria"].ToString());
                        Disponibles.Add(V);
                    }
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

            return Disponibles;
        }
    }
}
