using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using DAL;

namespace BLL
{
    public class BLLPadre:BLLPermiso
    {
        public BEPadre padre;

        DalAccesoDatos accesoDatos;
        public BEPermiso GuardarPermiso(BEPermiso permiso)
        {

            accesoDatos = new DalAccesoDatos();
            return accesoDatos.GuardarPermiso(permiso, true);
        }


        public IList<BEPadre> ObtenerMenus()
        {
            accesoDatos = new DalAccesoDatos();

            return accesoDatos.ObtenerMenus();
        }
        public IList<BEPermiso> ObtenerArbolMenu(BEPadre padre)
        {
            accesoDatos = new DalAccesoDatos();

            return accesoDatos.ObtenerArbolMenu(padre);
        }
        public void SeleccionarMenu(BEPadre padre)
        {
            accesoDatos = new DalAccesoDatos();

            accesoDatos.SeleccionarPadre(padre);
        }

        //int idsEliminados, int idsAgregados
        public void ActualizarPermisos(BEPadre menuPadre, IList<BEPermiso> LpermisosAnteriores, IList<BEPermiso> LpermisosEditados, List<(int IdPadre, int IdHijo)> relacionesPatentesEliminadas)

        {
            // Obtener las relaciones eliminadas
            var relacionesEliminadas = ObtenerRelacionesEliminadas(LpermisosAnteriores, LpermisosEditados);
            List<(int IdPadre, int IdHijo)> relacionesEliminadasLista = ConvertirLista(relacionesEliminadas);

            // Obtener las relaciones agregadas
            var relacionesAgregadas = ObtenerRelacionesAgregadas(LpermisosAnteriores, LpermisosEditados);
            List<(int IdPadre, int IdHijo)> relacionesAgregadasLista = ConvertirLista(relacionesAgregadas);


            accesoDatos = new DalAccesoDatos();

            accesoDatos.ActualizarPErmisos(menuPadre, relacionesEliminadasLista, relacionesAgregadasLista, relacionesPatentesEliminadas);


        }

        public void ActualizarPermisosUsuario(BEUser usuario, IList<BEPermiso> LpermisosAnteriores, IList<BEPermiso> LpermisosEditados)

        {
            // Obtener las relaciones eliminadas
            var relacionesEliminadas = ObtenerRelacionesEliminadas(LpermisosAnteriores, LpermisosEditados);
            List<(int IdPadre, int IdHijo)> relacionesEliminadasLista = ConvertirLista(relacionesEliminadas);

            // Obtener las relaciones agregadas
            var relacionesAgregadas = ObtenerRelacionesAgregadas(LpermisosAnteriores, LpermisosEditados);
            List<(int IdPadre, int IdHijo)> relacionesAgregadasLista = ConvertirLista(relacionesAgregadas);


            accesoDatos = new DalAccesoDatos();

            accesoDatos.ActualizarPErmisosUsuario(usuario, relacionesEliminadasLista, relacionesAgregadasLista);


        }


        public IEnumerable<(int IdPadre, int? IdHijo)> ObtenerRelacionesEliminadas(IList<BEPermiso> LpermisosAnteriores, IList<BEPermiso> LpermisosEditados)
        {
            var relacionesEliminadas = LpermisosAnteriores
                .Where(pa => pa is BEPadre || pa is BEHijo)
                .Select(pa => (IdPadre: pa.Id, IdHijo: pa.SubComponentes.FirstOrDefault()?.Id))
                .Except(LpermisosEditados
                    .Where(pe => pe is BEPadre || pe is BEHijo)
                    .Select(pe => (IdPadre: pe.Id, IdHijo: pe.SubComponentes.FirstOrDefault()?.Id)));

            return relacionesEliminadas;
        }

        //linQ 
        public IEnumerable<(int IdPadre, int? IdHijo)> ObtenerRelacionesAgregadas(IList<BEPermiso> LpermisosAnteriores, IList<BEPermiso> LpermisosEditados)
        {
            var relacionesAgregadas = LpermisosEditados
                .Where(pe => pe is BEPadre || pe is BEHijo)
                .Select(pe => (IdPadre: pe.Id, IdHijo: pe.SubComponentes.FirstOrDefault()?.Id))
                .Except(LpermisosAnteriores
                    .Where(pa => pa is BEPadre || pa is BEHijo)
                    .Select(pa => (IdPadre: pa.Id, IdHijo: pa.SubComponentes.FirstOrDefault()?.Id)));

            return relacionesAgregadas;
        }

        public List<(int IdPadre, int IdHijo)> ConvertirLista(IEnumerable<(int IdPadre, int? IdHijo)> relaciones)
        {
            List<(int IdPadre, int IdHijo)> listaRelaciones = relaciones
                .Select(r => (IdPadre: r.IdPadre, IdHijo: r.IdHijo ?? 0))
                .ToList();

            return listaRelaciones;
        }

        public bool RevisarArbolMenu(BEPermiso permiso, int IdPermiso)
        {

            if (permiso.Id == IdPermiso)
                return true;

            return permiso.SubComponentes.Any(item => RevisarArbolMenu(item, IdPermiso));


        }

        public bool ValidarIdPermiso(List<BEPermiso> permisos, int IdPermiso)
        {
            return !permisos.Any(permiso => RevisarArbolMenu(permiso, IdPermiso));
        }



        public bool ValidarPermisoNoExistente(List<BEPermiso> permisos, BEPermiso permiso)
        {
            foreach (var p in permisos)
            {
                if (RevisarArbolMenuCompleto(p, permiso))
                {
                    return false; // Retorna falso si encuentra coincidencia en algún permiso existente
                }
            }

            return true; // Retorna verdadero si no se encontró ninguna coincidencia en los permisos existentes
        }

        public bool RevisarArbolMenuCompleto(BEPermiso permiso, BEPermiso permisoBuscar)
        {
            if (permiso.Id == permisoBuscar.Id)
            {
                return true;
            }

            foreach (var subComponente in permiso.SubComponentes)
            {
                if (RevisarArbolMenuCompleto(subComponente, permisoBuscar))
                {
                    return true;
                }
            }

            return false;
        }
    }
}

