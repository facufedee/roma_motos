using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEPalabra
    {
        public int Id { get; set; }
        public string Tag { get; set; }
        public string Texto { get; set; }

        public BEPalabra(string tag, string texto)
        {
            Tag = tag;
            Texto = texto;
        }

        public BEPalabra(string tag)
        {
            Tag = tag;
        }

        public BEPalabra()
        {
        }

        public bool EsValida()
        {
            return Tag != "" & Tag != null & Texto != "" & Texto != null;
        }
    }
}
