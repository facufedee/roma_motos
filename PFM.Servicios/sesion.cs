using Abstraccion;
using BE;
using FRAMEWORK;
using System;

namespace SERVICIOS
{
    public class Sesion
    {
        private static Sesion _sesion;
        private static readonly object _lock = new object();

        private Traductor _traductor;
        public Traductor Traductor
        {
            get
            {
                if (_traductor == null)
                {
                    _traductor = new Traductor();
                }
                return _traductor;
            }
        }

        public IUser User { get; private set; }
        public DateTime FechaInicioSesion { get; private set; }

        private Sesion() { }

        // Propiedad para acceder a la instancia singleton
        public static Sesion Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_sesion == null)
                    {
                        _sesion = new Sesion();
                    }
                    return _sesion;
                }
            }
        }

        // Método para iniciar sesión y establecer el usuario
        public void Login(IUser user)
        {
            if (User != null)
            {
                throw new Exception("Sesión ya iniciada.");
            }

            User = user;
            FechaInicioSesion = DateTime.Now;
        }

        // Método para cerrar sesión
        public void Logout()
        {
            if (User == null)
            {
                throw new Exception("No hay sesión iniciada.");
            }

            User = null;
            FechaInicioSesion = DateTime.MinValue;
        }

        // Método para obtener el nombre de usuario de la sesión actual
        public string ObtenerUsername()
        {
            return User?.Username ?? "Sesión no iniciada";
        }

        // Método para iniciar sesión con un BEUser (adaptado a tu implementación)
        public void IniciarSesion(BEUser usuario)
        {
            Login(usuario);
        }
    }
}
