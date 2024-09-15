// Archivo: BEPermiso.cs
using System.Collections.Generic;

namespace BE
{
    public abstract class BEPermiso
    {
        public int Id { get; set; }
        public string NombrePermiso { get; set; }
        public abstract IList<BEPermiso> SubComponentes { get; }
        public abstract void AgregarSubcomponente(BEPermiso c);
        public abstract void VaciarSubcomponente();
        public override string ToString()
        {
            return NombrePermiso;
        }
    }

    public class PermisoConcreto : BEPermiso
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
