using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using BE;

namespace AccesoDatos
{
    public class DALUsuario
    {
        
        // Método que verifica si el usuario existe en la base de datos.
        public bool ExisteUsuario(BEUser user)
        {
            bool UserOK = false;
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["tallerWest"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand command = new SqlCommand("SP_USER_VALIDAR_USUARIO", cnn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Usuario", user.Username);
                    int count = (int)command.ExecuteScalar();
                    UserOK = count > 0;
                }
            }
            return UserOK;
        }

        public bool ModificarUsuario(BEUser user)
        {
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["tallerWest"].ConnectionString))
            {
                try
                {
                    cnn.Open();
                    using (SqlCommand command = new SqlCommand("SP_USER_MODIFICAR_Datos", cnn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Agregar parámetros requeridos por el SP
                        command.Parameters.AddWithValue("@Usuario", user.Username);
                        command.Parameters.AddWithValue("@dvv", user.DVV);  // DVV calculado
                        command.Parameters.AddWithValue("@Nombre", user.Nombre);
                        command.Parameters.AddWithValue("@Apellido", user.Apellido);
                        command.Parameters.AddWithValue("@Mail", user.Mail);

                        // Ejecutar el procedimiento almacenado
                        int rowsAffected = command.ExecuteNonQuery();

                        // Si el número de filas afectadas es mayor que 0, la operación fue exitosa
                        return rowsAffected > 0;
                    }
                }
                catch (Exception)
                {
                    // Aquí puedes loguear el error si lo necesitas
                    return false;
                }
            }
        }


        public List<BEUser> ObtenerUsuarios()
        {
            var usuarios = new List<BEUser>();

            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["tallerWest"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Sp_Usuario_Listar", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cnn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var usuario = new BEUser
                            {
                                Username = reader["Username"].ToString(),
                            };
                            usuarios.Add(usuario);
                        }
                    }
                }
            }

            return usuarios;
        }
    

    public void AltaUser(BEUser user)
        {
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["tallerWest"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand command = new SqlCommand("SP_USER_ALTA", cnn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Usuario", user.Username);
                    command.Parameters.AddWithValue("@Password", user.Password);
                    command.Parameters.AddWithValue("@DW", user.DVV); 
                    command.Parameters.AddWithValue("@Nombre", user.Nombre);
                    command.Parameters.AddWithValue("@Apellido", user.Apellido);
                    command.Parameters.AddWithValue("@Mail", user.Mail);

                    command.ExecuteNonQuery();
                }
            }
        }

        // Método que valida la contraseña del usuario.
        public bool ValidarPass(BEUser user)
        {
            bool PasswordOK = false;
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["tallerWest"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand command = new SqlCommand("SP_USER_VALIDAR_PASS", cnn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Usuario", user.Username);
                    command.Parameters.AddWithValue("@Password", user.Password);
                    int count = (int)command.ExecuteScalar();
                    PasswordOK = count > 0;
                }
            }
            return PasswordOK;
        }

        // Método para verificar la integridad de la base de datos con DVV.
        public bool ValidarDVV(string dVVCalculado)
        {
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["tallerWest"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand command = new SqlCommand("SP_VALIDAR_DVV", cnn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@dvv", dVVCalculado);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        // Método para obtener los permisos del usuario desde la base de datos.
        public List<BEPermiso> ObtenerPermisosUsuario(BEUser user)
        {
            var permisos = new List<BEPermiso>();
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["tallerWest"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand command = new SqlCommand("Sp_PermisosUsuario_Obtener", cnn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@userName", user.Username);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var permiso = new BEPermisoConcreto
                            {
                                NombrePermiso = reader["NombrePermiso"].ToString() // Aquí asignas el valor al objeto PermisoConcreto
                            };
                            permisos.Add(permiso);
                        }
                    }
                }
            }
            return permisos;
        }



        // Método para obtener todos los usuarios de la base de datos para el cálculo de DVV.
        //public List<BEUser> ObtenerUsuarios()
        //{
        //    var usuarios = new List<BEUser>();
        //    using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["tallerWest"].ConnectionString))
        //    {
        //        cnn.Open();
        //        using (SqlCommand command = new SqlCommand("SP_OBTENER_USUARIOS", cnn))
        //        {
        //            command.CommandType = CommandType.StoredProcedure;
        //            using (SqlDataReader reader = command.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    var user = new BEUser
        //                    {
        //                        Username = reader["Usuario"].ToString(),
        //                        DVV = reader["DVV"].ToString(),
        //                        Nombre = reader["Nombre"].ToString(),
        //                        Apellido = reader["Apellido"].ToString(),
        //                        Mail = reader["Mail"].ToString()
        //                    };
        //                    usuarios.Add(user);
        //                }
        //            }
        //        }
        //    }
        //    return usuarios;
        //}
    }
}
