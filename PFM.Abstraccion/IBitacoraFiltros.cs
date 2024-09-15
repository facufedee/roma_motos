using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraccion
{
    public interface IBitacoraFiltros
    {
        string Usuario { get; set; }
        DateTime Desde { get; set; }
        DateTime Hasta { get; set; }
        BitacoraTipo Tipo { get; set; }
        string Buscar { get; set; }
    }
}
