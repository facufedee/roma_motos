using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Abstraccion
{
    public interface IBitacora : IEntity
    {
        DateTime Fecha { get; set; }
        BitacoraTipo Tipo { get; set; }
        string Usuario { get; set; }
        string Mensaje { get; set; }
    }

    public enum BitacoraTipo
    {
        INFO = 1,
        ERROR = 2,
        ALL = 3
    }
}
