using Abstraccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEBitacoraFiltros : IBitacoraFiltros
    {
        public string Usuario { get; set; }
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }
        public BitacoraTipo Tipo { get; set; }
        public string Buscar { get; set; }
    }
}
