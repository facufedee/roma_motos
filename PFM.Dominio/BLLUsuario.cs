using AccesoDatos;
using BE;
using DAL;
using FRAMEWORK;
using SERVICIOS;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;

namespace BLL
{
    public class ResultadoLogin
    {
        public bool Exito { get; set; }
        public string MensajeError { get; set; }
        public BEUser Usuario { get; set; }
    }

    public class BLLUsuario
    {
        private readonly DALUsuario _acceso;

        public BLLUsuario()
        {
            _acceso = new DALUsuario();
        }

        public bool EsValidoDVV(string dvvCalculado)
        {
            return _acceso.ValidarDVV(dvvCalculado); // Llama al método en DAL para validar el DVV
        }

        public ResultadoLogin IniciarSesion(string username, string password)
        {
            var resultado = new ResultadoLogin();

            // Validación básica del usuario
            if (!ValidarUser(username))
            {
                resultado.Exito = false;
                resultado.MensajeError = "El usuario no está registrado o es inválido.";
                return resultado;
            }

            // Validación del formato de la contraseña
            if (!ValidarPassFormato(password))
            {
                resultado.Exito = false;
                resultado.MensajeError = "La contraseña debe contener entre 6 y 15 caracteres alfanuméricos.";
                return resultado;
            }

            // Encriptar la contraseña
            string passwordEncriptada = Encriptar(password);

            // Validar la contraseña en la base de datos
            var user = new BEUser { Username = username, Password = passwordEncriptada };
            if (!_acceso.ValidarPass(user))
            {
                resultado.Exito = false;
                resultado.MensajeError = "Contraseña incorrecta.";
                return resultado;
            }



            // Verificar la integridad de la base de datos (DVV)
            //if (!EsValidoDVV())
            //{
            //    resultado.Exito = false;
            //    resultado.MensajeError = "La base de datos ha sido modificada sin autorización.";
            //    return resultado;
            //}

            // Obtener permisos del usuario
            user.LPermisos= _acceso.ObtenerPermisosUsuario(user);
           // Sesion.Login(user);

            // Si todo va bien, devolvemos éxito
            resultado.Exito = true;
            resultado.Usuario = user;
            return resultado;
        }

        public bool ValidarUser(string username)
        {
            Regex regex = new Regex("^[a-zA-Z0-9]{4,15}$");
            return regex.IsMatch(username) && _acceso.ExisteUsuario(new BEUser { Username = username });
        }

        public List<BEUser> ObtenerUsuarios()
        {
            return _acceso.ObtenerUsuarios();
        }

        public bool ModificarUsuario(BEUser user)
        {
            // Lógica para validar y actualizar el usuario
            return _acceso.ModificarUsuario(user);
        }



        public bool ValidarPassFormato(string password)
        {
            return new Regex("^[a-zA-Z0-9]{6,15}$").IsMatch(password);
        }

        public string Encriptar(string pass)
        {
            Criptografia encriptador = new Criptografia();
            return encriptador.Encriptador(pass);
        }

        public bool ValidarDVV(string dvvCalculado)
        {
            return _acceso.ValidarDVV(dvvCalculado); // Valida si el DVV calculado es correcto
        }

        public string CalcularDVV()
        {
            var usuarios = _acceso.ObtenerUsuarios();
            CreacionDV generador = new CreacionDV();
            List<string> listaDVH = generador.listasDVH();
            string dvvCalculado = generador.GenerarDVV(listaDVH); // Genera el DVV calculado
            return dvvCalculado; // Devuelve el DVV como string
        }


        public BEUser ObtenerUsuarioLogueado()
        {
            return Sesion.Instance.User as BEUser; // Asumiendo que la sesión guarda el usuario logueado.
        }

        public void AltaUsuario(BEUser user)
        {
            // Validar si el usuario ya existe
            if (_acceso.ExisteUsuario(user))
            {
                throw new Exception("El usuario ya existe.");
            }

            _acceso.AltaUser(user);

        }
    }
}
