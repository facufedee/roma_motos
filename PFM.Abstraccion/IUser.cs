using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraccion
{
    public interface IUser
    {
        string Username { get; set; }
        string Password { get; set; }
        string Nombre { get; set; }
        string Apellido { get; set; }
        string Mail { get; set; }
        string DVV { get; set; }
    }
}
