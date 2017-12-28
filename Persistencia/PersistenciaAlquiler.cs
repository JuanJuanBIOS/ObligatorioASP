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
    public class PersistenciaAlquiler
    {
        public static void Consultar_Alquiler(Alquiler unAl)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("Consultar_Alquiler ", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@matricula", unAl.Vehiculo.Matricula);
            oComando.Parameters.AddWithValue("@cedula", unAl.Cliente.Cedula);
            oComando.Parameters.AddWithValue("@fechainicio", unAl.FechaInicio.Date);
            oComando.Parameters.AddWithValue("@fechafin", unAl.FechaFin.Date);
            oComando.Parameters.AddWithValue("@costo", unAl.Costo);

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
                    throw new Exception("La matrícula ingresada no existe en la base de datos");
                }
                else if (oAfectados == -2)
                {
                    throw new Exception("El cliente ingresado no existe en la base de datos");
                }
                else if (oAfectados == -3)
                {
                    throw new Exception("La fecha de inicio no puede ser anterior al día de hoy");
                }
                else if (oAfectados == -4)
                {
                    throw new Exception("La fecha de fin debe ser mayor a la fecha de inicio");
                }
                else if (oAfectados == -5)
                {
                    throw new Exception("El vehículo ya se encuentra alquilado en esas fechas");
                }
                else if (oAfectados == -6)
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

        public static void Confirmar_Alquiler(Alquiler unAl)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("Confirmar_Alquiler ", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@matricula", unAl.Vehiculo.Matricula);
            oComando.Parameters.AddWithValue("@cedula", unAl.Cliente.Cedula);
            oComando.Parameters.AddWithValue("@fechainicio", unAl.FechaInicio.Date);
            oComando.Parameters.AddWithValue("@fechafin", unAl.FechaFin.Date);
            oComando.Parameters.AddWithValue("@costo", unAl.Costo);

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
                    throw new Exception("La matrícula ingresada no existe en la base de datos");
                }
                else if (oAfectados == -2)
                {
                    throw new Exception("El cliente ingresado no existe en la base de datos");
                }
                else if (oAfectados == -3)
                {
                    throw new Exception("La fecha de inicio no puede ser anterior al día de hoy");
                }
                else if (oAfectados == -4)
                {
                    throw new Exception("La fecha de fin debe ser mayor a la fecha de inicio");
                }
                else if (oAfectados == -5)
                {
                    throw new Exception("El vehículo ya se encuentra alquilado en esas fechas");
                }
                else if (oAfectados == -6)
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


        public static List<Alquiler> Listar_Alquileres_Por_Vehiculo(Vehiculo V)
        {
            List<Alquiler> Listado = new List<Alquiler>(); ;
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("Listado_Alquileres_Por_Vehiculo", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;
            oComando.Parameters.AddWithValue("@vehiculo", V.Matricula);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        Alquiler A = new Alquiler(PersistenciaCliente.Buscar(Convert.ToInt32(oReader["cliente"])),
                            PersistenciaVehiculo.Buscar(oReader["vehiculo"].ToString()),
                            Convert.ToDateTime(oReader["fechainicio"]),
                            Convert.ToDateTime(oReader["fechafin"]),
                            Convert.ToInt32(oReader["costo"]),false);

                        Listado.Add(A);
                    }
                }

                oReader.Close();
            }

            catch (Exception ex)
            {
                throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
            }
            finally
            {
                oConexion.Close();
            }

            return Listado;
        }

        public static Int32 Total_Vehiculo(Vehiculo V)
        {
            Int32 Resultado = 0;
            SqlDataReader Reader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("Total_Vehiculo", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@vehiculo", V.Matricula.ToString());

            SqlParameter oRetorno = new SqlParameter("@Tot", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.Output;
            oComando.Parameters.Add(oRetorno);
            
            try
            {
                oConexion.Open();
                Reader = oComando.ExecuteReader();
                
                //obtengo valor
                Resultado = Convert.ToInt32(oRetorno.Value);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }

            return Resultado;
        }
    }
}
