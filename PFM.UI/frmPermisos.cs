using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ABSTRACCION;
using SERVICIOS;

namespace UI
{
    public partial class frmPermisos : Form, ITraducible
    {
        public frmPermisos()
        {
            InitializeComponent();
            bllPadre = new BLLPadre();
            bllHijo = new BLLHijo();
            Registrarse();
            Actualizar();
            cmbBoxMenuLista.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBoxNombreSubMenu.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        BLLPadre bllPadre;
        BLLHijo bllHijo;

        BEPadre padre;
        BEPadre oPadre;
        BEPadre oPadreEliminado;
        BEPadre oPadreAnterior;
        BEPadre oPadrePrincipal;
        BEHijo hijo;

        BLLPermiso bllPermiso;
        IList<BEPermiso> lPermiso;
        IList<BEPermiso> lPermisoAnteriores;
        IList<BEPermiso> lPermisosEliminados;

        List<(int IdPadre, int IdHijo)> relacionesPatentesEliminadas;

        public void Registrarse()
        {
            BLLTraductor BllTraductor = new BLLTraductor();
            BllTraductor.RegistrarForm(this);
        }

        public void Actualizar()
        {
            BLLTraductor bllTraductor = new BLLTraductor();
            List<BEPalabra> Palabras = bllTraductor.ObtenerPalabras();

            try
            {
                if (this.Tag != null && (string)this.Tag != "")
                {
                    this.Text = Palabras.Find(pal => pal.Tag.Equals(Tag)).Texto;
                }
                foreach (Control control in Controls)
                {
                    if (this.Tag != null && (string)this.Tag != "")
                    {
                        control.Text = Palabras.Find(pal => pal.Tag.Equals(control.Tag)).Texto;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Faltan traducciones");
            }
        }
        private void frmPermisos_Load(object sender, EventArgs e)
        {
            LlenarComboMenu();
            LlenarComboSubmenu();
        }

        private void LlenarComboSubmenu()
        {
            this.cmbBoxNombreSubMenu.DataSource = bllHijo.ObtenerHijos();
        }

        private void LlenarComboMenu()
        {
            this.cmbBoxMenuLista.DataSource = null;
            cmbBoxMenuLista.DataSource = bllPadre.ObtenerMenus();
        }

        private void btnMenuEditar_Click(object sender, EventArgs e)
        {
            oPadre = (BEPadre)cmbBoxMenuLista.SelectedItem;

            recuperarObjetoPadre();

            llenarPadreTreeView(lPermiso);
            lPermisoAnteriores = lPermiso;
            oPadrePrincipal = oPadre;
            cmbBoxMenuLista.SelectedItem = null;
            LlenarComboMenu();
        }

        private void llenarPadreTreeView(IList<BEPermiso> l)
        {
            lPermiso = l;

            treeView1.Nodes.Clear();// limpio el tree view 

            TreeNode root = new TreeNode(oPadre.NombrePermiso);
            root.Tag = oPadre;
            treeView1.Nodes.Add(root);

            foreach (var item in lPermiso)
            {
                LlenarTreeNode(root, item);
            }

            treeView1.ExpandAll();
        }

        private void LlenarTreeNode(TreeNode tree, BEPermiso permiso)
        {
            TreeNode treenode = new TreeNode(permiso.NombrePermiso);

            treenode.Tag = permiso;
            tree.Nodes.Add(treenode);
            if (permiso.SubComponentes != null)
                foreach (var item in permiso.SubComponentes)
                {
                    LlenarTreeNode(treenode, item);
                }
        }

        private void recuperarObjetoPadre()
        {
            lPermiso = bllPadre.ObtenerArbolMenu(oPadre); //aplico recursividad desde la base de datos
            foreach (var item in lPermiso)
            {
                oPadre.AgregarSubcomponente(item);// agrego los hijos
            }
        }

    

        private void btnMenuSeleccionar_Click(object sender, EventArgs e)
        {
            if (oPadre != null)// evito que si presionan seleccionar sin haber hecho clic en modificar primero , no rompa 
            {
                oPadrePrincipal = oPadre;
                oPadre = null;
                oPadre = new BEPadre();
                oPadre.VaciarSubcomponente();

                oPadre = (BEPadre)cmbBoxMenuLista.SelectedItem;
                if (bllPadre.RevisarArbolMenu(oPadrePrincipal, oPadre.Id) == false)
                {


                    recuperarObjetoPadre();


                    oPadrePrincipal.AgregarSubcomponente(oPadre);
                    oPadre = oPadrePrincipal;
                    lPermiso = oPadre.SubComponentes;

                    llenarPadreTreeView(lPermiso);
                }
                else
                {

                    oPadre = oPadrePrincipal;
                    MessageBox.Show("Permiso ya existente");
                }

            }
            cmbBoxMenuLista.SelectedItem = null;
            LlenarComboMenu();
        }

        private void btnMenuNuevoGuardar_Click(object sender, EventArgs e)
        {
            txtBoxNombreMenu.Visible = false;
            btnMenuNuevoGuardar.Visible = false;
            lblNombreNuevoMenu.Visible = false;



            lblMenuLista.Visible = true;
            cmbBoxMenuLista.Visible = true;

            // Nuevo menu

            padre = new BEPadre();
            padre.NombrePermiso = this.txtBoxNombreMenu.Text;
            bllPadre.GuardarPermiso(padre);

            LlenarComboMenu();
            MessageBox.Show("Padre guardado correctamente");
            txtBoxNombreMenu.Text = "";
        }

        private void btnSubMenuSeleccionar_Click(object sender, EventArgs e)
        {
            if (oPadre != null)
            {
                oPadrePrincipal = oPadre;
                BEHijo oHijo;
                oHijo = (BEHijo)cmbBoxNombreSubMenu.SelectedItem;
                if (bllPadre.RevisarArbolMenu(oPadrePrincipal, oHijo.Id) == false)
                {
                    if (oHijo != null)
                    {
                        oPadrePrincipal = oPadre;
                        oPadre.AgregarSubcomponente(oHijo);
                        lPermiso = oPadre.SubComponentes;
                        oPadre = oPadrePrincipal;
                        llenarPadreTreeView(lPermiso);

                    }
                }
                else
                {
                    oPadre = oPadrePrincipal;
                    MessageBox.Show("Permiso ya existente");
                }

            }
        }

        private void btnGuardarConfig_Click(object sender, EventArgs e)
        {
            bllPadre.ActualizarPermisos(oPadrePrincipal, lPermisoAnteriores, lPermiso, relacionesPatentesEliminadas);



            MessageBox.Show("Estructura de permisos guardada correctamente");
            padre = null;
            oPadre = null;
            oPadreAnterior = null;
            oPadrePrincipal = null;
            hijo = null;


            LlenarComboMenu();
            treeView1.Nodes.Clear();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            TreeNode nodoSeleccionado = treeView1.SelectedNode;
            if (nodoSeleccionado != null)
            {
                if (EsPadre(nodoSeleccionado))
                {
                    BEPadre padreEliminar = (BEPadre)nodoSeleccionado.Tag;

                    int idPadre = padreEliminar.Id;
                    int idPadree = ObtenerIdPadreRaizAnterior(treeView1.SelectedNode, idPadre);



                    lPermisosEliminados = lPermiso;
                    BEPadre oPadreliminado = oPadre;
                    oPadreEliminado.VaciarSubcomponente();




                    if (idPadre != oPadrePrincipal.Id)
                    {
                        foreach (var item in lPermisosEliminados)
                        {
                            if (item.Id != idPadre)
                            {
                                oPadreEliminado.AgregarSubcomponente(item);
                            }

                        }

                    }

                    lPermiso = oPadreEliminado.SubComponentes;
                    llenarPadreTreeView(lPermiso);



                }
                else if (EsHijo(nodoSeleccionado))
                {
                    BEHijo HijoEliminar = (BEHijo)nodoSeleccionado.Tag;
                    int idHijo = HijoEliminar.Id;
                    int idPadre = ObtenerIdPadreDesdeHijo(treeView1.Nodes[0], idHijo);

                    lPermisosEliminados = lPermiso;
                    BEHijo oHijoEliminado = new BEHijo();

                    BEPadre oPadreEliminado = oPadre;
                    oPadreEliminado.VaciarSubcomponente();
                    relacionesPatentesEliminadas = new List<(int IdPadre, int IdHijo)>();
                    relacionesPatentesEliminadas.Add((idPadre, idHijo));
                    foreach (var item in lPermisosEliminados)
                    {
                        if (item.Id == idPadre) 
                        {
                            BEPadre oPadreEliminadoJerarquia = new BEPadre(); 
                            oPadreEliminadoJerarquia.Id = item.Id;
                            oPadreEliminadoJerarquia.NombrePermiso = item.NombrePermiso;
                            oPadreEliminadoJerarquia.VaciarSubcomponente();

                            foreach (var subItem in item.SubComponentes)
                            {
                                if (subItem.Id != idHijo)
                                {
                                    BEHijo nuevoHijo = new BEHijo(); 
                                    nuevoHijo.Id = subItem.Id;
                                    nuevoHijo.NombrePermiso = subItem.NombrePermiso;


                                    oPadreEliminadoJerarquia.AgregarSubcomponente(nuevoHijo);
                                }
                            }

                            oPadreEliminado.AgregarSubcomponente(oPadreEliminadoJerarquia);
                        }
                        else
                        {
                            oPadreEliminado.AgregarSubcomponente(item);
                        }
                    }

                    lPermiso = oPadreEliminado.SubComponentes;


                    if (nodoSeleccionado != null) 
                    {
                        treeView1.Nodes.Remove(nodoSeleccionado);
                    }



                }


            }
            cmbBoxMenuLista.SelectedItem = null;
            LlenarComboMenu();

        }

        private bool EsPadre(TreeNode nodo)
        {

            BEPadre padre = nodo.Tag as BEPadre;
            return padre != null;
        }

        private int ObtenerIdPadreRaizAnterior(TreeNode nodo, int idPadre)
        {
            if (nodo == null)
                return -1;

            if (nodo.Tag is BEPadre)
            {
                BEPadre padre = (BEPadre)nodo.Tag;
                if (padre.Id == idPadre)
                {
                    TreeNode nodoPadre = nodo.Parent;
                    if (nodoPadre != null && nodoPadre.Tag is BEPadre)
                    {
                        BEPadre menuPadre = (BEPadre)nodoPadre.Tag;
                        return menuPadre.Id;
                    }
                }
            }

            return ObtenerIdPadreRaizAnterior(nodo.Parent, idPadre);
        }

        private bool EsHijo(TreeNode nodo)
        {
            BEHijo hijo = nodo.Tag as BEHijo;
            return hijo != null;
        }

        private int ObtenerIdPadreDesdeHijo(TreeNode nodo, int idHijo)
        {
            if (nodo == null)
                return -1;

            if (nodo.Tag is BEHijo)
            {
                BEHijo hijo = (BEHijo)nodo.Tag;
                if (hijo.Id == idHijo)
                {
                    TreeNode nodoPadre = nodo.Parent;
                    if (nodoPadre != null && nodoPadre.Tag is BEPadre)
                    {
                        BEPadre menuPadre = (BEPadre)nodoPadre.Tag;
                        return menuPadre.Id;
                    }
                }
            }

            foreach (TreeNode hijo in nodo.Nodes)
            {
                int idPadre = ObtenerIdPadreDesdeHijo(hijo, idHijo);
                if (idPadre != -1)
                    return idHijo;
            }

            return -1;
        }
        private void btnMenuNuevoGuardar_Click_1(object sender, EventArgs e)
        {
            try
            {
                string nombrePermiso = this.txtBoxNombreMenu.Text.Trim();

                if (string.IsNullOrEmpty(nombrePermiso))
                {
                    MessageBox.Show("El nombre del menú no puede estar vacío.");
                    return;
                }

                if (nombrePermiso.Length < 6)
                {
                    MessageBox.Show("El nombre del menú debe tener al menos 6 caracteres sin contar espacios en blanco.");
                    return;
                }

                ValidarRegex valido = new ValidarRegex();

                bool nombreOK = valido.validarNombrePermiso(nombrePermiso);

                if (!nombreOK)
                {
                    MessageBox.Show("El nombre del menú solo puede contener caracteres alfanuméricos.");
                    return;
                }

                // Crear y guardar el permiso
                padre = new BEPadre();
                padre.NombrePermiso = nombrePermiso;
                bllPadre.GuardarPermiso(padre);

                // Actualizar UI
                LlenarComboMenu();
                MessageBox.Show("Menú guardado correctamente");
                txtBoxNombreMenu.Text = "";
            }
            catch (Exception ex)
            {
                // Manejo de errores inesperados
                MessageBox.Show($"Ocurrió un error al guardar el menú: {ex.Message}");
            }
        }

    }
}
