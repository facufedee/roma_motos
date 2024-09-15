using ABS_TRACCION;
using Abstraccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEUser : IVerificable, IUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Mail { get; set; }
        public string DVV { get; set; }

        public List<BEPermiso> LPermisos = new List<BEPermiso>();


        public override string ToString()
        {
            return Username;
        }
    }


}
