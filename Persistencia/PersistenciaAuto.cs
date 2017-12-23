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
    public class PersistenciaAuto
    {
        public static Auto Buscar(string matricula)
        {
            //Propiedades
            string oMatricula;
            string oMarca;
            string oModelo;
            int oAnio;
            int oCantPuertas;
            int oCostoDiario;
            string oCateogria;
            string oTipo;


            Auto A = null;

            //Variables de conexión
            SqlDataReader oReader;
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("Exec Buscar_Auto " + matricula, oConexion);

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
                    oTipo = (string)oReader["anclaje"];

                    A = new Auto(oMatricula, oMarca, oModelo, oAnio, oCantPuertas, oCostoDiario, oCateogria, oTipo);
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

            return A;
        }

        public static void Crear(Auto unA)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("Crear_Auto ", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@matricula", unA.Matricula);
            oComando.Parameters.AddWithValue("@marca", unA.Marca);
            oComando.Parameters.AddWithValue("@modelo", unA.Modelo);
            oComando.Parameters.AddWithValue("@anio", unA.Año);
            oComando.Parameters.AddWithValue("@cant_puertas", unA.CantPuertas);
            oComando.Parameters.AddWithValue("@costodiario", unA.CostoAlquiler);
            oComando.Parameters.AddWithValue("@categoria", unA.Categoria);
            oComando.Parameters.AddWithValue("@anclaje", unA.TipoA);

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
                    throw new Exception("Ya existe el Auto con la matrícula ingresada");
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

        public static void Modificar(Auto unA)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("Modificar_Auto ", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@matricula", unA.Matricula);
            oComando.Parameters.AddWithValue("@marca", unA.Marca);
            oComando.Parameters.AddWithValue("@modelo", unA.Modelo);
            oComando.Parameters.AddWithValue("@anio", unA.Año);
            oComando.Parameters.AddWithValue("@cant_puertas", unA.CantPuertas);
            oComando.Parameters.AddWithValue("@costodiario", unA.CostoAlquiler);
            oComando.Parameters.AddWithValue("@categoria", unA.Categoria);
            oComando.Parameters.AddWithValue("@anclaje", unA.TipoA);

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
                    throw new Exception("El Auto no existe en la base de datos");
                }
                else if (oAfectados == -2)
                {
                    throw new Exception("El Auto no existe en la base de datos");
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


        public static void Eliminar(Auto unA)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("Eliminar_Auto ", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@matricula", unA.Matricula);

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
                    throw new Exception("El Auto no existe en la base de datos");
                }
                else if (oAfectados == -2)
                {
                    throw new Exception("El Auto no se puede eliminar porque posee alquileres asociados");
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
