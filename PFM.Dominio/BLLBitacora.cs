using System;
using AccesoDatos;
using BE;
using Abstraccion;

namespace BLL
{
    public class BLLBitacora
    {
        private readonly DALBitacora _dalBitacora;

        public BLLBitacora()
        {
            _dalBitacora = new DALBitacora();
        }

        /// <summary>
        /// Agrega un registro en la bitácora.
        /// </summary>
        /// <param name="bitacora">Objeto BEBitacora que contiene la información a registrar.</param>
        public void Add(BEBitacora bitacora)
        {
            try
            {
                _dalBitacora.Agregar(bitacora);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar registro en la bitácora.", ex);
            }
        }

        /// <summary>
        /// Obtiene registros de la bitácora con filtros y paginación.
        /// </summary>
        /// <param name="pagina">Número de la página solicitada.</param>
        /// <param name="porPagina">Cantidad de registros por página.</param>
        /// <param name="filtros">Filtros aplicados a la búsqueda de registros.</param>
        /// <returns>Un objeto que contiene la lista de bitácoras filtradas y la paginación.</returns>
        public IBitacorasPaginacion ObtenerFiltrado(int pagina, int porPagina, IBitacoraFiltros filtros)
        {
            try
            {
                return _dalBitacora.ObtenerFiltrado(pagina, porPagina, filtros);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los registros filtrados de la bitácora.", ex);
            }
        }


        public void RegistrarInicioSesion(string username)
        {
            try
            {
                var bitacora = new BEBitacora
                {
                    Usuario = username,
                    Fecha = DateTime.Now,
                    Mensaje = "Inicio de sesión exitoso"
                };
                Add(bitacora);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar el inicio de sesión en la bitácora.", ex);
            }
        }

        /// <summary>
        /// Registra un error en la bitácora.
        /// </summary>
        /// <param name="username">Nombre de usuario que experimentó el error (puede ser nulo si no se ha iniciado sesión).</param>
        /// <param name="mensajeError">Mensaje de error.</param>
        public void RegistrarError(string username, string mensajeError)
        {
            try
            {
                var bitacora = new BEBitacora
                {
                    Usuario = username,
                    Fecha = DateTime.Now,
                    Mensaje = "Error: " + mensajeError
                };
                Add(bitacora);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar un error en la bitácora.", ex);
            }
        }
    }
}
