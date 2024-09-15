using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Xml.Linq;
using BE;
using static System.Net.Mime.MediaTypeNames;

namespace DAL
{
    public class DalAccesoDatos
    {
        DalAccesoDatos accesoDatos;

        private SqlConnection oConexionDB = new SqlConnection(ConfigurationManager.ConnectionStrings["tallerWest"].ToString());

        SqlCommand oCommand;

        public List<BEPadre> ObtenerPadres()
        {
            var padres = new List<BEPadre>();

            try
            {
                oCommand = new SqlCommand("Sp_Padres_Obtener", oConexionDB);
                oCommand.CommandType = CommandType.StoredProcedure;

                // Abrir la conexión
                oConexionDB.Open();

                using (SqlDataReader reader = oCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        BEPadre padre = new BEPadre();



                        padre.Id = Convert.ToInt32(reader["IdPermiso"]);
                        padre.NombrePermiso = reader["NombrePermiso"].ToString();

                        padres.Add(padre);


                    }

                }
            }
            catch (SqlException excepcion)
            {
                throw excepcion;
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
            finally
            {
                // Cerrar la conexión
                oConexionDB.Close();
            }

            return padres;
        }

        public List<BEHijo> ObtenerHijos()
        {
            var hijos = new List<BEHijo>();

            try
            {
                oCommand = new SqlCommand("Sp_Hijos_Obtener", oConexionDB);
                oCommand.CommandType = CommandType.StoredProcedure;

                // Abrir la conexión
                oConexionDB.Open();
                using (SqlDataReader reader = oCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        BEHijo hijo = new BEHijo();


                        hijo.Id = Convert.ToInt32(reader["IdPermiso"]);
                        hijo.NombrePermiso = reader["NombrePermiso"].ToString();

                        hijos.Add(hijo);

                    }

                }
            }
            catch (SqlException excepcion)
            {
                throw excepcion;
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
            finally
            {
                // Cerrar la conexión
                oConexionDB.Close();
            }

            return hijos;
        }

        public BEPermiso GuardarPermiso(BEPermiso permiso, bool esPadre)
        {

            ArrayList ListaParametros = new ArrayList();

            SqlParameter Parametro1 = new SqlParameter();
            Parametro1.ParameterName = "@permiso";
            Parametro1.Value = permiso.NombrePermiso;
            Parametro1.SqlDbType = SqlDbType.VarChar;
            ListaParametros.Add(Parametro1);


            SqlParameter Parametro2 = new SqlParameter();
            Parametro2.ParameterName = "@tipopermiso";
            Parametro2.Value = esPadre;
            Parametro2.SqlDbType = SqlDbType.VarChar;
            ListaParametros.Add(Parametro2);

            accesoDatos = new DalAccesoDatos();
            accesoDatos.EscribirBaseDatos("Sp_Permiso_Alta", ListaParametros);


            return permiso;

        }

        public bool EscribirBaseDatos(string consultaParaBase, ArrayList ParametrosSQL)
        {
            oConexionDB.Open();

            SqlCommand oCommand = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                Connection = oConexionDB,
                CommandText = consultaParaBase,
                Transaction = oConexionDB.BeginTransaction()
            };

            try
            {
                if (ParametrosSQL != null)
                {
                    foreach (SqlParameter item in ParametrosSQL)
                    {
                        oCommand.Parameters.AddWithValue(item.ParameterName, item.Value);
                    }
                }

                oCommand.ExecuteNonQuery();
                oCommand.Transaction.Commit();
                return true;
            }
            catch (SqlException excepcion)
            {
                throw excepcion;
            }
            finally
            {
                oConexionDB.Close();
            }
        }

        public IList<BEPadre> ObtenerMenus()
        {
            var padres = new List<BEPadre>();

            try
            {
                oCommand = new SqlCommand("Sp_Padres_Obtener", oConexionDB);
                oCommand.CommandType = CommandType.StoredProcedure;

                oConexionDB.Open();

                using (SqlDataReader reader = oCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        BEPadre padre = new BEPadre();

                        padre.Id = Convert.ToInt32(reader["IdPermiso"]);
                        padre.NombrePermiso = reader["NombrePermiso"].ToString();

                        padres.Add(padre);

                    }

                }
            }
            catch (SqlException excepcion)
            {
                throw excepcion;
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
            finally
            {
                oConexionDB.Close();
            }

            return padres;
        }

        public IList<BEPermiso> ObtenerArbolMenu(BEPadre padre)
        {
            var lPermisos = new List<BEPermiso>();



            try
            {
                oCommand = new SqlCommand("Sp_Obtener_Arbol_Menu", oConexionDB);
                oCommand.CommandType = CommandType.StoredProcedure;

                oCommand.Parameters.AddWithValue("@IdPadre", padre.Id);
                if (oConexionDB.State != ConnectionState.Open)
                {
                    oConexionDB.Open();
                }

                using (SqlDataReader reader = oCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        BEPermiso permiso;

                        if (Convert.ToInt32(reader["TipoPermiso"]) == 1)


                        {
                            permiso = new BEPadre();
                        }
                        else
                        {
                            permiso = new BEHijo();
                        }


                        permiso.Id = Convert.ToInt32(reader["IdPermiso"]);
                        permiso.NombrePermiso = reader["NombrePermiso"].ToString();

                        // necesitamos ver si ese permiso tiene un padre, para buscar los hijos o no 

                        int IdPadre = 0;
                        if (reader["IdPadre"] != DBNull.Value)
                        {
                            IdPadre = reader.GetInt32(reader.GetOrdinal("IdPadre"));
                        }
                        var menuPadre = ObtenerPermisos(IdPadre, lPermisos);

                        if (menuPadre == null)
                        {
                            lPermisos.Add(permiso);// si es un hijo lo agrego 
                        }
                        else
                        {
                            menuPadre.AgregarSubcomponente(permiso);
                        }



                    }
                    reader.Close();


                }


            }
            catch (SqlException excepcion)
            {
                throw excepcion;
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
            finally
            {
                // Cerrar la conexión
                if (oConexionDB.State == ConnectionState.Open)
                {
                    oConexionDB.Close();
                }
            }
            return lPermisos;
        }


        private BEPermiso ObtenerPermisos(int IdPadre, IList<BEPermiso> lPermiso)
        {

            BEPermiso Permiso = lPermiso != null ? lPermiso.Where(i => i.Id.Equals(IdPadre)).FirstOrDefault() : null;

            if (Permiso == null && lPermiso != null)
            {
                foreach (var c in lPermiso)
                {

                    var l = ObtenerPermisos(IdPadre, c.SubComponentes);
                    if (l != null && l.Id == IdPadre) return l;
                    else
                    if (l != null)
                        return ObtenerPermisos(IdPadre, l.SubComponentes);

                }
            }



            return Permiso;

        }

        public void SeleccionarPadre(BEPadre padre)
        {
            padre.VaciarSubcomponente();
            foreach (var item in ObtenerArbolMenu(padre))
            {
                padre.AgregarSubcomponente(item);
            }
        }

        public void ActualizarPErmisos(BEPadre menuPadre, List<(int IdPadre, int IdHijo)> relacionesEliminadas, List<(int IdPadre, int IdHijo)> relacionesAgregadas, List<(int IdPadre, int IdHijo)> relacionesPatentesEliminadas)
        {
            //instancio un arraylist, para los parametros
            ArrayList ListaParametros = new ArrayList();
            if (relacionesPatentesEliminadas != null)
            {


                if (relacionesPatentesEliminadas.Count > 0)
                {

                    // Eliminar las relaciones eliminadas de la base de datos
                    foreach (var relacionPatenteEliminada in relacionesPatentesEliminadas)
                    {

                        SqlParameter Parametro1 = new SqlParameter();

                        Parametro1.ParameterName = "@IdPadre";
                        Parametro1.Value = relacionPatenteEliminada.IdPadre;
                        Parametro1.SqlDbType = SqlDbType.VarChar;
                        ListaParametros.Add(Parametro1);

                        SqlParameter Parametro2 = new SqlParameter();
                        Parametro2.ParameterName = "@IdHijo";
                        Parametro2.Value = relacionPatenteEliminada.IdHijo;

                        Parametro2.SqlDbType = SqlDbType.VarChar;
                        ListaParametros.Add(Parametro2);

                        accesoDatos = new DalAccesoDatos();
                        accesoDatos.EscribirBaseDatos("Sp_Permiso_Eliminar", ListaParametros);
                        ListaParametros = new ArrayList();

                    }
                }
            }

            if (relacionesEliminadas.Count > 0)
            {

                foreach (var relacionEliminada in relacionesEliminadas)
                {

                    SqlParameter Parametro1 = new SqlParameter();

                    Parametro1.ParameterName = "@IdPadre";
                    Parametro1.Value = menuPadre.Id;
                    Parametro1.SqlDbType = SqlDbType.VarChar;
                    ListaParametros.Add(Parametro1);

                    SqlParameter Parametro2 = new SqlParameter();
                    Parametro2.ParameterName = "@IdHijo";
                    Parametro2.Value = relacionEliminada.IdHijo;

                    Parametro2.SqlDbType = SqlDbType.VarChar;
                    ListaParametros.Add(Parametro2);

                    accesoDatos = new DalAccesoDatos();
                    accesoDatos.EscribirBaseDatos("Sp_Permiso_Eliminar", ListaParametros);
                    ListaParametros = new ArrayList();

                }
            }

            if (relacionesAgregadas.Count > 0)
            {

                // Eliminar las relaciones eliminadas de la base de datos
                foreach (var relacionAgregada in relacionesAgregadas)
                {
                  
                    SqlParameter Parametro1 = new SqlParameter();
                    Parametro1.ParameterName = "@IdPadre";
                    Parametro1.Value = menuPadre.Id;

                    Parametro1.SqlDbType = SqlDbType.VarChar;
                    ListaParametros.Add(Parametro1);

                    SqlParameter Parametro2 = new SqlParameter();
                    Parametro2.ParameterName = "@IdHijo";
                    Parametro2.Value = relacionAgregada.IdPadre;

                    Parametro2.SqlDbType = SqlDbType.VarChar;
                    ListaParametros.Add(Parametro2);

                    accesoDatos = new DalAccesoDatos();
                    accesoDatos.EscribirBaseDatos("Sp_Permiso_Agregar", ListaParametros);
                    ListaParametros = new ArrayList();

                }
            }
        }

        public void ActualizarPErmisosUsuario(BEUser usuario, List<(int IdPadre, int IdHijo)> relacionesEliminadasLista, List<(int IdPadre, int IdHijo)> relacionesAgregadasLista)
        {
            //instancio un arraylist, para los parametros
            ArrayList ListaParametros = new ArrayList();


            if (relacionesEliminadasLista.Count > 0)
            {

                foreach (var relacionEliminada in relacionesEliminadasLista)
                {
                  
                    SqlParameter Parametro1 = new SqlParameter();

                    Parametro1.ParameterName = "@IdPermiso";
                    Parametro1.Value = relacionEliminada.IdPadre;
                    Parametro1.SqlDbType = SqlDbType.VarChar;
                    ListaParametros.Add(Parametro1);

                    SqlParameter Parametro2 = new SqlParameter();
                    Parametro2.ParameterName = "@userName";
                    Parametro2.Value = usuario.Username;

                    Parametro2.SqlDbType = SqlDbType.VarChar;
                    ListaParametros.Add(Parametro2);


                    accesoDatos = new DalAccesoDatos();
                    accesoDatos.EscribirBaseDatos("Sp_Usuarios_Permiso_Eliminar", ListaParametros);
                    ListaParametros = new ArrayList();

                }
            }

            if (relacionesAgregadasLista.Count > 0)
            {

                // Eliminar las relaciones eliminadas de la base de datos
                foreach (var relacionAgregada in relacionesAgregadasLista)
                {

                    SqlParameter Parametro1 = new SqlParameter();
                    Parametro1.ParameterName = "@IdPermiso";
                    Parametro1.Value = relacionAgregada.IdPadre;

                    Parametro1.SqlDbType = SqlDbType.VarChar;
                    ListaParametros.Add(Parametro1);

                    SqlParameter Parametro2 = new SqlParameter();
                    Parametro2.ParameterName = "@userName";
                    Parametro2.Value = usuario.Username;

                    Parametro2.SqlDbType = SqlDbType.VarChar;
                    ListaParametros.Add(Parametro2);

                   
                    accesoDatos = new DalAccesoDatos();
                    accesoDatos.EscribirBaseDatos("Sp_Usuarios_Permiso_Agregar", ListaParametros);
                    ListaParametros = new ArrayList();

                }
            }

        }

        public object ObtenerUsuarios()
        {
            List<BEUser> Usuarios = new List<BEUser>();

            try
            {
                oCommand = new SqlCommand("Sp_Usuario_Listar", oConexionDB);
                oCommand.CommandType = CommandType.StoredProcedure;

                // Abrir la conexión
                oConexionDB.Open();

                using (SqlDataReader reader = oCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        BEUser Usuario = new BEUser();


                        Usuario.Username = reader["userName"].ToString();
                        Usuario.Password = reader["password"].ToString();
                        Usuario.DVV = reader["DW"].ToString();
                        Usuario.Nombre = reader["Nombre"].ToString();
                        Usuario.Apellido = reader["Apellido"].ToString();
                        Usuario.Mail = reader["Mail"].ToString();

                        Usuarios.Add(Usuario);
                    }
                }
            }
            catch (SqlException excepcion)
            {
                throw excepcion;
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
            finally
            {
                // Cerrar la conexión
                oConexionDB.Close();
            }

            return Usuarios;
        }

        public List<BEPermiso> ObtenerPermisosUsuario(BEUser usuario)
        {
            var lPermisosUsuario = new List<BEPermiso>();
            var lPermisosMenu = new List<BEPermiso>();



            try
            {
                oCommand = new SqlCommand("Sp_PermisosUsuario_Obtener", oConexionDB);
                oCommand.CommandType = CommandType.StoredProcedure;
                // parametro

                oCommand.Parameters.AddWithValue("@userName", usuario.Username);
                // Abrir la conexión
                oConexionDB.Open();

                using (SqlDataReader reader = oCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        BEPermiso permiso;
                        BEPadre padre;
                        // Si el tipo de permiso es 1, es decir un menu(arbol)
                        if (Convert.ToInt32(reader["TipoPermiso"]) == 1)
                        {
                            // creo un menu y se lo paso al metodo de obtener arbol de ese menu.
                           padre = new BEPadre();
                           padre.Id = Convert.ToInt32(reader["IdPermiso"]);
                           padre.NombrePermiso = reader["NombrePermiso"].ToString();

                            // Guarda la conexion actual y crea una nueva conexion
                            var currentConnection = oConexionDB;
                            oConexionDB = new SqlConnection(oConexionDB.ConnectionString);


                            lPermisosMenu = (List<BEPermiso>)ObtenerArbolMenu(padre);

                            // Restaura la conexion original
                            oConexionDB = currentConnection;

                            // Creamos el menu padre
                            // Recorrer la lista lPermisosMenu y asignar el menú padre a cada elemento
                            foreach (var hijo in lPermisosMenu)
                            {
                                padre.AgregarSubcomponente(hijo);
                            }


                            lPermisosUsuario.Add(padre);
                            usuario.LPermisos.Add(padre);
                            //  lPermisosUsuario.AddRange(lPermisosMenu);


                        }
                        else
                        {
                            permiso = new BEHijo();
                            permiso.Id = Convert.ToInt32(reader["IdPermiso"]);
                            permiso.NombrePermiso = reader["NombrePermiso"].ToString();

                            lPermisosUsuario.Add(permiso);// si es submenu lo agrego 
                            usuario.LPermisos.Add(permiso);
                        }
                    }
                    reader.Close();


                }


            }
            catch (SqlException excepcion)
            {
                throw excepcion;
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
            finally
            {
                // Cerrar la conexión
                oConexionDB.Close();
            }

            return lPermisosUsuario;
        }


        public List<BEIdioma> ObtenerIdiomas()
        {
            List<BEIdioma> Idiomas = new List<BEIdioma>();

            try
            {
                using (SqlCommand oCommand = new SqlCommand("Sp_Idioma_Listar", oConexionDB))
                {
                    oCommand.CommandType = CommandType.StoredProcedure;
                    oConexionDB.Open();

                    using (SqlDataReader reader = oCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BEIdioma Idioma = new BEIdioma
                            {
                                Id = Convert.ToInt32(reader["IdIdioma"]),
                                Nombre = reader["Nombre"].ToString()
                            };
                            Idiomas.Add(Idioma);
                        }
                    }
                }
            }
            catch (SqlException excepcion)
            {
                throw excepcion;
            }
            finally
            {
                oConexionDB.Close();
            }

            return Idiomas;
        }

        public List<BEPalabra> ObtenerPalabrasXIdioma(int idIdioma)
        {
            List<BEPalabra> Palabras = new List<BEPalabra>();

            try
            {
                using (SqlCommand oCommand = new SqlCommand("Sp_Palabras_Idioma_Listar", oConexionDB))
                {
                    oCommand.CommandType = CommandType.StoredProcedure;
                    oCommand.Parameters.AddWithValue("@idIdioma", idIdioma);
                    oConexionDB.Open();

                    using (SqlDataReader reader = oCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BEPalabra Palabra = new BEPalabra
                            {
                                Id = Convert.ToInt32(reader["IdPalabra"]),
                                Tag = reader["Tag"].ToString(),
                                Texto = reader["Texto"].ToString()
                            };
                            Palabras.Add(Palabra);
                        }
                    }
                }
            }
            catch (SqlException excepcion)
            {
                throw excepcion;
            }
            finally
            {
                oConexionDB.Close();
            }

            return Palabras;
        }

        public bool ExisteIdioma(string nombreIdioma)
        {
            bool existe = false;
            try
            {
                using (SqlCommand oCommand = new SqlCommand("Sp_Idioma_Verificar", oConexionDB))
                {
                    oCommand.CommandType = CommandType.StoredProcedure;
                    oCommand.Parameters.AddWithValue("@idioma", nombreIdioma);
                    oConexionDB.Open();

                    existe = Convert.ToInt32(oCommand.ExecuteScalar()) > 0;
                }
            }
            catch (SqlException excepcion)
            {
                throw excepcion;
            }
            finally
            {
                oConexionDB.Close();
            }

            return existe;
        }

        public BEIdioma ObtenerIdiomaCompleto(string nombreIdioma)
        {
            BEIdioma Idioma = new BEIdioma();

            try
            {
                using (SqlCommand oCommand = new SqlCommand("Sp_Idioma_Obtener", oConexionDB))
                {
                    oCommand.CommandType = CommandType.StoredProcedure;
                    oCommand.Parameters.AddWithValue("@idioma", nombreIdioma);
                    oConexionDB.Open();

                    using (SqlDataReader reader = oCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Idioma.Id = Convert.ToInt32(reader["IdIdioma"].ToString());
                            Idioma.Nombre = reader["Nombre"].ToString();
                        }
                    }
                }
            }
            catch (SqlException excepcion)
            {
                throw excepcion;
            }
            finally
            {
                oConexionDB.Close();
            }

            return Idioma;
        }

        public void AgregarPalabra(int idIdioma, BEPalabra palabra)
        {
            try
            {
                using (SqlCommand oCommand = new SqlCommand("Sp_Palabra_Alta", oConexionDB))
                {
                    oCommand.CommandType = CommandType.StoredProcedure;
                    oCommand.Parameters.AddWithValue("@tag", palabra.Tag);
                    if (palabra.Texto == null)
                    {
                        palabra.Texto = ""; // 
                    }
                    oCommand.Parameters.AddWithValue("@texto", palabra.Texto);
                    oCommand.Parameters.AddWithValue("@idIdioma", idIdioma);
                    oConexionDB.Open();

                    oCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException excepcion)
            {
                throw excepcion;
            }
            finally
            {
                oConexionDB.Close();
            }
        }

        public void AltaIdioma(string nombre)
        {
            try
            {
                using (SqlCommand oCommand = new SqlCommand("Sp_Idioma_Alta", oConexionDB))
                {
                    oCommand.CommandType = CommandType.StoredProcedure;
                    oCommand.Parameters.AddWithValue("@nombre", nombre);
                    oConexionDB.Open();

                    oCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException excepcion)
            {
                throw excepcion;
            }
            finally
            {
                oConexionDB.Close();
            }
        }
        public void ModificarPalabras(List<BEPalabra> palabras)
        {
            try
            {
                oConexionDB.Open();

                foreach (BEPalabra palabra in palabras)
                {
                    using (SqlCommand oCommand = new SqlCommand("Sp_Palabra_Modificar", oConexionDB))
                    {
                        oCommand.CommandType = CommandType.StoredProcedure;
                        oCommand.Parameters.AddWithValue("@idPalabra", palabra.Id);
                        oCommand.Parameters.AddWithValue("@texto", palabra.Texto == null ? "" : palabra.Texto);

                        oCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException excepcion)
            {
                throw excepcion;
            }
            finally
            {
                oConexionDB.Close();
            }
        }

        public static bool ValidarDV(string dVVCalculado)
        {

            ArrayList ListaParametros = new ArrayList();
            //Defino lo que va a contener mi parametro 
            SqlParameter Parametro = new SqlParameter();
            Parametro.ParameterName = "@verificador";
            Parametro.Value = dVVCalculado;
            Parametro.SqlDbType = SqlDbType.VarChar;
            ListaParametros.Add(Parametro);


            DalAccesoDatos accesoDatos = new DalAccesoDatos();

            return accesoDatos.VerificarExistenciaBaseDatos("Sp_Verif_Verificar", ListaParametros);
        }

        public bool VerificarExistenciaBaseDatos(string consultaParaBase, ArrayList ParametrosSql)
        {
            try
            {
                oConexionDB.Open();

                SqlCommand oCommand = new SqlCommand(consultaParaBase, oConexionDB)
                {
                    CommandType = CommandType.StoredProcedure
                };

                if (ParametrosSql != null)
                {
                    foreach (SqlParameter item in ParametrosSql)
                    {
                        oCommand.Parameters.AddWithValue(item.ParameterName, item.Value);
                    }
                }

                int r = Convert.ToInt32(oCommand.ExecuteScalar());
                oConexionDB.Close();
                return r > 0;
            }
            catch (SqlException excepcion)
            {
                throw excepcion;
            }
        }
    
        public void ActualizarDVV(string dvv)
        {
        ArrayList ListaParametros = new ArrayList
            {
                new SqlParameter
                {
                    ParameterName = "@verificador",
                    Value = dvv,
                    SqlDbType = SqlDbType.VarChar
                }
            };

        EscribirBaseDatos("Sp_Verif_Modificar", ListaParametros);
   
        }

        public List<BEUser> ObtenerVersiones(BEUser usuarioSeleccionado)
        {
            List<BEUser> Usuarios = new List<BEUser>();


            try
            {
                oCommand = new SqlCommand("Sp_Version_Listar", oConexionDB);
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.Parameters.AddWithValue("@Usuario", usuarioSeleccionado.Username);

                // Abrir la conexion
                oConexionDB.Open();

                using (SqlDataReader reader = oCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        BEUser Usuario = new BEUser();

                        Usuario.Username = reader["userName"].ToString();
                        Usuario.Password = reader["Password"].ToString();
                        Usuario.Nombre = reader["Nombre"].ToString();
                        Usuario.Apellido = reader["Apellido"].ToString();
                        Usuario.Mail = reader["Mail"].ToString();
                        

                        Usuarios.Add(Usuario);
                    }
                }
            }
            catch (SqlException excepcion)
            {
                throw excepcion;
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
            finally
            {
                // Cerrar la conexion
                oConexionDB.Close();
            }

            return Usuarios;
        }
    }
}

