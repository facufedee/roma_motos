using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Archivo: PermisoConcreto.cs
namespace BE
{
    public class BEPermisoConcreto : BEPermiso
    {
        public override IList<BEPermiso> SubComponentes { get; } = new List<BEPermiso>();

        public override void AgregarSubcomponente(BEPermiso c)
        {
            SubComponentes.Add(c);
        }

        public override void VaciarSubcomponente()
        {
            SubComponentes.Clear();
        }
    }
}
