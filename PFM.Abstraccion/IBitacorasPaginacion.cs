using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraccion
{
    public interface IBitacorasPaginacion
    {
        int Pagina { get; set; }
        int PorPagina { get; set; }
        int Total { get; set; }
        int TotalPorPagina { get; set; }
        IList<IBitacoraFiltrada> Bitacoras { get; set; }
    }
}
