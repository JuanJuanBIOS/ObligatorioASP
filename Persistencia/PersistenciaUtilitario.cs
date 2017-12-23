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

        public static void Crear(Utilitario unU)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("Crear_Utilitario ", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@matricula", unU.Matricula);
            oComando.Parameters.AddWithValue("@marca", unU.Marca);
            oComando.Parameters.AddWithValue("@modelo", unU.Modelo);
            oComando.Parameters.AddWithValue("@anio", unU.Año);
            oComando.Parameters.AddWithValue("@cant_puertas", unU.CantPuertas);
            oComando.Parameters.AddWithValue("@costodiario", unU.CostoAlquiler);
            oComando.Parameters.AddWithValue("@categoria", unU.Categoria);
            oComando.Parameters.AddWithValue("@capacidad", unU.CapCarga);
            oComando.Parameters.AddWithValue("@tipo", unU.Tipo);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int oAfectados = (int)oComando.Parameters["@Retorno"].Value;

                if (oAfectados == -1)
                {
                    throw new Exception("Ya existe el Utilitario con la matrícula ingresada");
                }
                else if (oAfectados == -2)
                {
                    throw new Exception("Error en la base de datos");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }
        }

        public static void Modificar(Utilitario unU)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("Modificar_Utilitario ", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@matricula", unU.Matricula);
            oComando.Parameters.AddWithValue("@marca", unU.Marca);
            oComando.Parameters.AddWithValue("@modelo", unU.Modelo);
            oComando.Parameters.AddWithValue("@anio", unU.Año);
            oComando.Parameters.AddWithValue("@cant_puertas", unU.CantPuertas);
            oComando.Parameters.AddWithValue("@costodiario", unU.CostoAlquiler);
            oComando.Parameters.AddWithValue("@categoria", unU.Categoria);
            oComando.Parameters.AddWithValue("@capacidad", unU.CapCarga);
            oComando.Parameters.AddWithValue("@tipo", unU.Tipo);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int oAfectados = (int)oComando.Parameters["@Retorno"].Value;

                if (oAfectados == -1)
                {
                    throw new Exception("El Utilitario no existe en la base de datos");
                }
                else if (oAfectados == -2)
                {
                    throw new Exception("El Utilitario no existe en la base de datos");
                }
                else if (oAfectados == -3)
                {
                    throw new Exception("Error en la base de datos");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }
        }
    }
}
