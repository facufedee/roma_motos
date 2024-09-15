using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SERVICIOS
{
    public class ValidarRegex
    {
        public bool Validar_pass_regex(string password)
        {

            Regex RE = new Regex("^(?=.*?[a-z])(?=.*?[0-9]).{6,15}$");
            bool esValido = RE.IsMatch(password);
            return esValido;

        }


        public bool validarNombrePermiso(string nombrePermiso)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(nombrePermiso, @"^[a-zA-Z0-9_-]+$");
        }



    }
}
