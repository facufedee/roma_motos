using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEPadre:BEPermiso
    {
        //lista de hijos
        public IList<BEPermiso> hijos; //Hijos

        public override IList<BEPermiso> SubComponentes
        {
            get { return hijos.ToArray(); }
        }



        public BEPadre()
        {
            hijos = new List<BEPermiso>();
        }
        public override string ToString()
        {
            return NombrePermiso;
        }

        //Agrego hijos
        public override void AgregarSubcomponente(BEPermiso permiso)
        {
            hijos.Add(permiso);

        }

        public override void VaciarSubcomponente()
        {
            hijos = new List<BEPermiso>();

        }
    }
}
