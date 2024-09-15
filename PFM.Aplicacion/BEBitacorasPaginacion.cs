using Abstraccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEBitacorasPaginacion : IBitacorasPaginacion
    {
        public int Pagina { get; set; }
        public int PorPagina { get; set; }
        public int Total { get; set; }
        public int TotalPorPagina { get; set; }
        public IList<IBitacoraFiltrada> Bitacoras { get; set; } = new List<IBitacoraFiltrada>();
    }
}
