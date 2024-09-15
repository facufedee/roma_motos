using ABSTRACCION;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRAMEWORK
{
    public class Traductor
    {
        private int _idIdioma;
        public int IdIdiomaSeleccionado
        {
            get { return _idIdioma; }
            set
            {
                _idIdioma = value;
                this.Notificar();
            }
        }
        private List<ITraducible> Suscriptores { get; set; }
        public Traductor()
        {
            Suscriptores = new List<ITraducible>();
            IdIdiomaSeleccionado = 0;
        }

        public void AgregarSuscriptor(ITraducible Suscriptor)
        {
            Suscriptores.Add(Suscriptor);
        }

        private void Notificar()
        {
            foreach (ITraducible Suscriptor in this.Suscriptores)
            {
                Suscriptor.Actualizar();
            };
        }

    }
}
