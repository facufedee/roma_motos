using ABSTRACCION;
using BE;
using SERVICIOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FRAMEWORK;
using DAL;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace BLL
{
    public class BLLTraductor
    {
        private DalAccesoDatos accesoDatos;

        public BLLTraductor()
        {
            accesoDatos = new DalAccesoDatos();
        }

        public void RegistrarForm(ITraducible FormTraducible)
        {
            Traductor trad = Sesion.Instance.Traductor;
            trad.AgregarSuscriptor(FormTraducible);
        }

        public void CambiarIdioma(int Idioma)
        {
            Traductor trad = Sesion.Instance.Traductor;
            trad.IdIdiomaSeleccionado = Idioma;
        }

        public List<BEIdioma> ObtenerIdiomas()
        {
            List<BEIdioma> Idiomas = accesoDatos.ObtenerIdiomas();
            foreach (BEIdioma Idioma in Idiomas)
            {
                Idioma.Palabras = accesoDatos.ObtenerPalabrasXIdioma(Idioma.Id);
            }
            return Idiomas;
        }

        public List<BEIdioma> ObtenerIdiomasHabilitados()
        {
            List<BEIdioma> Idiomas = ObtenerIdiomas().FindAll(idioma => idioma.EsValido());
            return Idiomas;
        }

        public List<BEPalabra> ObtenerPalabras(int? idIdioma = null)
        {
            int id = idIdioma ?? ObtenerIdIdiomaElegido();
            List<BEPalabra> Palabras = accesoDatos.ObtenerPalabrasXIdioma(id);
            return Palabras;
        }

        private int ObtenerIdIdiomaElegido()
        {
            return Sesion.Instance.Traductor.IdIdiomaSeleccionado;
        }

        public List<BEPalabra> ObtenerPalabrasTag()
        {
            List<BEPalabra> Palabras = ObtenerPalabras();
            List<BEPalabra> PalabrasTag = new List<BEPalabra>();

            foreach (BEPalabra Palabra in Palabras)
            {
                BEPalabra PalabraTag = new BEPalabra(Palabra.Tag);
                PalabrasTag.Add(PalabraTag);
            }
            return PalabrasTag;
        }

        public bool ExisteIdioma(BEIdioma idioma)
        {
            return accesoDatos.ExisteIdioma(idioma.Nombre);
        }

        private BEIdioma ObtenerIdioma(string nombreIdioma)
        {
            return accesoDatos.ObtenerIdiomaCompleto(nombreIdioma);
        }

        public void AgregarIdioma(BEIdioma idioma)
        {
            accesoDatos.AltaIdioma(idioma.Nombre);

            idioma.Id = ObtenerIdioma(idioma.Nombre).Id;

            foreach (BEPalabra Palabra in idioma.Palabras)
            {
                accesoDatos.AgregarPalabra(idioma.Id, Palabra);
            }
        }

        public void ModificarIdioma(List<BEPalabra> Palabras)
        {

                accesoDatos.ModificarPalabras(Palabras);
            
        }
    }
}
