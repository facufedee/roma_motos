using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SERVICIOS
{
    public class Criptografia
    {
        public string Encriptador(string pass)
        {
            using (var md5 = MD5.Create())
            {
                var byteHash = md5.ComputeHash(Encoding.UTF8.GetBytes(pass));
                var PasswordEncriptada = BitConverter.ToString(byteHash).Replace("-", "").Substring(0, 14);
                    return PasswordEncriptada;

            }
        }
    }
}
