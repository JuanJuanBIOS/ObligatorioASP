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
    public class PersistenciaCliente
    {
        public static Cliente Buscar(int cedula)
        {
            //Propiedades
            int oCedula;
            string oNombre;
            long oTarjeta;
            string oTelefono;
            string oDireccion;
            DateTime oFechaNac;

            Cliente C = null;

            //Variables de conexión
            SqlDataReader oReader;
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("Exec Buscar_Cliente " + cedula, oConexion);

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

        public static void Crear(Cliente unCli)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("Crear_Cliente ", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@documento", unCli.Cedula);
            oComando.Parameters.AddWithValue("@tarjeta", unCli.Tarjeta);
            oComando.Parameters.AddWithValue("@nombre", unCli.Nombre);
            oComando.Parameters.AddWithValue("@direccion", unCli.Direccion);
            oComando.Parameters.AddWithValue("@telefono", unCli.Telefono);
            oComando.Parameters.AddWithValue("@fechanac", unCli.FechaNac);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int oAfectados = (int)oComando.Parameters["@Retorno"].Value;

                if (oAfectados == -2)
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

        public static void Modificar(Cliente unCli)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("Modificar_Cliente ", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@documento", unCli.Cedula);
            oComando.Parameters.AddWithValue("@tarjeta", unCli.Tarjeta);
            oComando.Parameters.AddWithValue("@nombre", unCli.Nombre);
            oComando.Parameters.AddWithValue("@direccion", unCli.Direccion);
            oComando.Parameters.AddWithValue("@telefono", unCli.Telefono);
            oComando.Parameters.AddWithValue("@fechanac", unCli.FechaNac);

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
                    throw new Exception("El Cliente no existe en la base de datos");
                }
                else if (oAfectados == 0)
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

        public static void Eliminar(Cliente unCli)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("Eliminar_Cliente ", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@documento", unCli.Cedula);

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
                    throw new Exception("El Cliente no existe en la base de datos");
                }
                else if (oAfectados == -3)
                {
                    throw new Exception("Error en la base de dator");
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
