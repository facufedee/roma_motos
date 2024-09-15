using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABSTRACCION
{
    public interface ITraducible
    {

        void Registrarse(); //registro a las notificaciones de cuando cambio un idioma seleccionado en cualquier momento
        void Actualizar(); //pide actualizar el idioma seleccionado
    }
}
