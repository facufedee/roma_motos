using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEHijo:BEPermiso
    {
        public override IList<BEPermiso> SubComponentes
        {

            get { return new List<BEPermiso>(); }
        }
        public override string ToString()
        {
            return NombrePermiso;
        }

        public override void AgregarSubcomponente(BEPermiso c)
        {
            throw new NotImplementedException();
        }

        public override void VaciarSubcomponente()
        {
            throw new NotImplementedException();
        }
    }
}
