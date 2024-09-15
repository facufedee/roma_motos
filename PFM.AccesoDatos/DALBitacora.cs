using Abstraccion;
using BE;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class DALBitacora
    {
        public void Agregar(BEBitacora bitacora)
        {
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["tallerWest"].ConnectionString))
            {
                cnn.Open();
                SqlTransaction transaction = cnn.BeginTransaction();

                try
                {
                    using (SqlCommand command = new SqlCommand("SP_BITACORA_AGREGAR", cnn))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Transaction = transaction;

                        command.Parameters.AddWithValue("@tipo", bitacora.Tipo);
                        command.Parameters.AddWithValue("@usuario", bitacora.Usuario);
                        command.Parameters.AddWithValue("@mensaje", bitacora.Mensaje);

                        command.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }


        public IBitacorasPaginacion ObtenerFiltrado(int pagina, int porPagina, IBitacoraFiltros filtros)
        {
       
            BEBitacorasPaginacion _BitacorasPaginacion = new BEBitacorasPaginacion();

            try
            {
                using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["tallerWest"].ConnectionString))
                {
                    cnn.Open();

                    // consulta para obtener información de paginación
                    using (SqlCommand command = new SqlCommand("SP_BITACORA_OBTENERFILTRADO", cnn))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("total", true);
                        command.Parameters.AddWithValue("pagina", pagina);
                        command.Parameters.AddWithValue("porPagina", porPagina);
                        command.Parameters.AddWithValue("Usuario", filtros.Usuario == null ? (object)DBNull.Value : filtros.Usuario.Trim());
                        command.Parameters.AddWithValue("Desde", filtros.Desde.ToString() == "" ? (object)DBNull.Value : filtros.Desde);
                        command.Parameters.AddWithValue("Hasta", filtros.Hasta.ToString() == "" ? (object)DBNull.Value : filtros.Hasta);
                        command.Parameters.AddWithValue("Tipo", filtros.Tipo.ToString() == null ? (object)DBNull.Value : filtros.Tipo);
                        command.Parameters.AddWithValue("buscar", filtros.Buscar == null ? (object)DBNull.Value : filtros.Buscar.Trim());

                        var reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            _BitacorasPaginacion.Pagina = Convert.ToInt32(reader["pagina"].ToString());
                            _BitacorasPaginacion.PorPagina = Convert.ToInt32(reader["porPagina"].ToString());
                            _BitacorasPaginacion.Total = Convert.ToInt32(reader["total"].ToString());
                            _BitacorasPaginacion.TotalPorPagina = Convert.ToInt32(reader["totalPorPagina"].ToString());
                        }

                        reader.Close();
                    }

                    // consulta para obtener datos filtrados
                    using (SqlCommand commandFilter = new SqlCommand("SP_BITACORA_OBTENERFILTRADO", cnn))
                    {
                        commandFilter.CommandType = System.Data.CommandType.StoredProcedure;
                        commandFilter.Parameters.AddWithValue("total", false);
                        commandFilter.Parameters.AddWithValue("pagina", pagina);
                        commandFilter.Parameters.AddWithValue("porPagina", porPagina);
                        commandFilter.Parameters.AddWithValue("Usuario", filtros.Usuario == null ? (object)DBNull.Value : filtros.Usuario.Trim());
                        commandFilter.Parameters.AddWithValue("Desde", filtros.Desde.ToString() == "" ? (object)DBNull.Value : filtros.Desde);
                        commandFilter.Parameters.AddWithValue("Hasta", filtros.Hasta.ToString() == "" ? (object)DBNull.Value : filtros.Hasta);
                        commandFilter.Parameters.AddWithValue("Tipo", filtros.Tipo.ToString() == null ? (object)DBNull.Value : filtros.Tipo);
                        commandFilter.Parameters.AddWithValue("buscar", filtros.Buscar == null ? (object)DBNull.Value : filtros.Buscar.Trim());

                        var readerBitacora = commandFilter.ExecuteReader();

                        while (readerBitacora.Read())
                        {
                            BEBitacoraFiltrada bitacoraFiltered = new BEBitacoraFiltrada();
                            bitacoraFiltered.Id = Convert.ToInt32(readerBitacora["Id"].ToString());
                            bitacoraFiltered.Usuario = readerBitacora["Usuario"].ToString();
                            bitacoraFiltered.Fecha = Convert.ToDateTime(readerBitacora["Fecha"].ToString());
                            bitacoraFiltered.Tipo = (BitacoraTipo)Enum.ToObject(typeof(BitacoraTipo), Convert.ToInt32(readerBitacora["Tipo"].ToString()));
                            bitacoraFiltered.Mensaje = readerBitacora["Mensaje"].ToString();
                            _BitacorasPaginacion.Bitacoras.Add(bitacoraFiltered);
                        }

                        readerBitacora.Close();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return _BitacorasPaginacion;
        }

    }
}
