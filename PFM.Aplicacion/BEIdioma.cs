using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEIdioma
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<BEPalabra> Palabras { get; set; }
        public BEIdioma(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }
        public BEIdioma(string nombre)
        {
            Nombre = nombre;
        }

        public BEIdioma()
        {
        }

        public override string ToString()
        {
            return Nombre;
        }

        public bool EsValido()
        {
            return Palabras.All(pal => pal.EsValida());
        }
    }
}
