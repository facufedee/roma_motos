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

namespace UI
{
    public partial class frmPermisosUsuarios : Form, ITraducible
    {
        public frmPermisosUsuarios()
        {
            InitializeComponent();
            Registrarse();
            Actualizar();
        }

        BLLUsuario bllUsuario;
        BLLPadre bllpadre;
        BLLHijo bllhijo;
        BEPadre oPAdre;
        BEUser oUsuario;
        BEPadre oPadreAgregar;
        //Lista para permisos usuario 
        List<BEPermiso> lPermisosUsuario;// lista de permisos de usuario , la voy actualizando a medida que agrego o elimino permisos
        IList<BEPermiso> lPermisosUsuarioOrig;// guardo los permisos que recupero de la base
        IList<BEPermiso> lPermiso;
        IList<BEPermiso> lPermisosEliminados;

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
                if (this.Tag != null)
                {
                    this.Text = Palabras.Find(pal => pal.Tag.Equals(Tag)).Texto;
                }
                foreach (Control control in Controls)
                {
                    if (control.Tag != null)
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

        List<(string userName, int IdPermiso)> permisosUsuarioEliminados;

        private void frmPermisosUsuarios_Load(object sender, EventArgs e)
        {
            bllUsuario = new BLLUsuario();
            oUsuario = new BEUser();
            bllpadre = new BLLPadre();
            bllhijo = new BLLHijo();
            LlenarComboUsuario();
            LlenarComboMenu();
            LlenarComboSubmenu();
            cmbUsuarios.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBoxMenuLista.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBoxNombreSubMenu.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void LlenarComboUsuario()
        {
            this.cmbUsuarios.DataSource = null;
            this.cmbUsuarios.DataSource = bllUsuario.ObtenerUsuarios();
            //cmbUsuarios.ValueMember = "Id";
            cmbUsuarios.DisplayMember = "NombreUsuario";
            cmbUsuarios.Refresh();
            cmbUsuarios.SelectedIndex = -1;


        }

        //Traemos los Menu de la base de datos
        private void LlenarComboMenu()
        {
            this.cmbBoxMenuLista.DataSource = null;
            this.cmbBoxMenuLista.DataSource = bllpadre.ObtenerMenus();
            cmbBoxMenuLista.SelectedIndex = -1;


        }

        //Traemos los SubMEnu de la base de datos
        private void LlenarComboSubmenu()
        {
            this.cmbBoxNombreSubMenu.DataSource = null;
            this.cmbBoxNombreSubMenu.DataSource = bllhijo.ObtenerHijos();
            cmbBoxNombreSubMenu.SelectedIndex = -1;

        }

        private void recuperarObjetoPermisosUsuario(BEUser usuario)
        {


           // lPermisosUsuario = bllUsuario.ObtenerPermisosUsuario(usuario);

            llenarMenuTreeView(lPermisosUsuario);


        }


        private void llenarMenuTreeView(IList<BEPermiso> l)
        {
            lPermiso = new List<BEPermiso>();
            lPermiso = l;

            treeView1.Nodes.Clear();// limpio el tree view 

            TreeNode root = new TreeNode(oUsuario.Username);
            // root.Tag = oMenu;
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
        //private void btnUsuarioEditar_Click(object sender, EventArgs e)
        //{

        //    lPermisosUsuario = new List<BEPermiso>();
        //    oUsuario = (BEUser)cmbUsuarios.SelectedItem;// Obtengo el usuario del ComboBox
        //    recuperarObjetoPermisosUsuario(oUsuario);

        //    lPermisosUsuarioOrig = null;

        //    lPermisosUsuarioOrig = new List<BEPermiso>(lPermisosUsuario);


        //}

        //private void btnSubMenuSeleccionar_Click(object sender, EventArgs e)
        //{

        //    //
        //    if (oUsuario != null)// evito que si presionan seleccionar sin haber hecho clic en modificar primero , no rompa 
        //    {

        //        BEHijo oHijo;
        //        oHijo = (BEHijo)cmbBoxNombreSubMenu.SelectedItem;
        //        List<BEPermiso> listaPermisosvalidar = lPermisosUsuario.ToList(); // Conversión a List<BEPermiso>

        //        if (bllpadre.ValidarIdPermiso(listaPermisosvalidar, oHijo.Id) == true)
        //        {
        //            oUsuario.LPermisos.Add(oHijo);
        //            lPermisosUsuario.Add(oHijo);
        //            llenarMenuTreeView(lPermisosUsuario);


        //        }
        //        else
        //        {


        //            MessageBox.Show("Permiso ya existente");
        //        }
        //    }
        //    //
        //}
        private void recuperarObjetoMenu()
        {

            oPadreAgregar.VaciarSubcomponente();
            lPermiso = bllpadre.ObtenerArbolMenu(oPadreAgregar);
            foreach (var item in lPermiso)
            {
                oPadreAgregar.AgregarSubcomponente(item);// agrego los hijos
            }


        }
        //private void btnMenuSeleccionar_Click(object sender, EventArgs e)
        //{
        //    if (oUsuario != null)// evito que si presionan seleccionar sin haber hecho clic en modificar primero , no rompa 
        //    {
        //        oPadreAgregar = new BEPadre();
        //        oPadreAgregar.VaciarSubcomponente();
        //        oPadreAgregar = (BEPadre)cmbBoxMenuLista.SelectedItem;

        //        List<BEPermiso> listaPermisosvalidar = lPermisosUsuario.ToList(); // Conversión a List<BEPermiso>
        //        recuperarObjetoMenu();

        //        if (bllpadre.ValidarPermisoNoExistente(listaPermisosvalidar, oPadreAgregar) == true)
        //        {



        //            oUsuario.LPermisos.Add(oPadreAgregar);
        //            lPermisosUsuario.Add(oPadreAgregar);
        //            llenarMenuTreeView(lPermisosUsuario);





        //        }
        //        else
        //        {


        //            MessageBox.Show("Permiso ya existente");
        //        }



        //    }
        //}

        private bool EsMenu(TreeNode nodo)
        {

            // Verifica si el nodo es un menu
            BEPadre padre = nodo.Tag as BEPadre;
            return padre != null;
        }

        private bool EsHijo(TreeNode nodo)
        {
            // Verifica si el nodo es un submenu
            BEHijo hijo = nodo.Tag as BEHijo;
            return hijo != null;
        }

        private int ObtenerIdMenuDesdeSubmenu(TreeNode nodo, int idHijo)
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
                int idPadre = ObtenerIdMenuDesdeSubmenu(hijo, idHijo);
                if (idPadre != -1)
                    return idPadre;
            }

            return -1;
        }

        //private void btnEliminarPermiso_Click(object sender, EventArgs e)
        //{

        //    TreeNode nodoSeleccionado = treeView1.SelectedNode;
        //    permisosUsuarioEliminados = new List<(string userName, int IdPermiso)>();

        //    if (nodoSeleccionado != null)// si tengo un nodo seleccionado
        //    {
        //        if (EsMenu (nodoSeleccionado))//Verifico si es Menu
        //        {
        //            BEPadre padreEliminar = (BEPadre)nodoSeleccionado.Tag;

        //            int idPadre = padreEliminar.Id;

        //            // Eliminar el nodo seleccionado del tree view 
        //            //
        //            lPermisosEliminados = lPermisosUsuario;

        //            permisosUsuarioEliminados.Add((oUsuario.Username, idPadre));//Añado el menu seleccionado para eliminar

        //            BEPadre oMenu = new BEPadre();
        //            oMenu.VaciarSubcomponente();





        //            foreach (var item in lPermisosEliminados)
        //            {
        //                if (item.Id != idPadre)
        //                {
        //                    oMenu.AgregarSubcomponente(item);// agrego los hijos
        //                }

        //            }

        //            lPermisosUsuario = new List<BEPermiso>();
        //            //   lPermisosUsuario.Clear();
        //            // lPermisosUsuario = oMenu.SubComponentes;//.Add(oMenu);
        //            lPermisosUsuario = new List<BEPermiso>(oMenu.SubComponentes);
        //            //lPermiso = oMenuEliminado.SubComponentes;
        //            llenarMenuTreeView(lPermisosUsuario);





        //        }
        //        else if (EsHijo(nodoSeleccionado))//Verifico si es SubMenu
        //        {

        //            BEHijo hijoEliminar = (BEHijo)nodoSeleccionado.Tag;
        //            int idHijo = hijoEliminar.Id;

        //            // si es -1 usar el idsubmenu para patentes

        //            int idPadre = ObtenerIdMenuDesdeSubmenu(treeView1.Nodes[0], idHijo);
        //            if (idPadre == -1)
        //            {
        //                idPadre = idHijo;

        //                BEHijo oHijo = new BEHijo();

        //                lPermisosEliminados = lPermisosUsuario;

        //                permisosUsuarioEliminados.Add((oUsuario.Username, idPadre));//Añado el menu seleccionado para eliminar

        //                BEPadre oPadre = new BEPadre();
        //                oPadre.VaciarSubcomponente();


        //                foreach (var item in lPermisosEliminados)
        //                {
        //                    if (item.Id != idPadre)
        //                    {
        //                        oPadre.AgregarSubcomponente(item);// agrego los hijos
        //                    }

        //                }

        //                lPermisosUsuario = new List<BEPermiso>();

        //                //lPermisosUsuario = oMenu.SubComponentes;
        //                lPermisosUsuario = new List<BEPermiso>(oPadre.SubComponentes);
        //                llenarMenuTreeView(lPermisosUsuario);


        //            }
        //            else
        //            {
        //                MessageBox.Show("Debe eliminar el arbol completo");
        //            }

        //        }


        //    }


        //}

        //private void btnGuardarConfig_Click(object sender, EventArgs e)
        //{
        //    bllpadre.ActualizarPermisosUsuario(oUsuario, lPermisosUsuarioOrig, lPermisosUsuario);
        //    BLLUsuario bllUsuario = new BLLUsuario();
        //    //bllUsuario.RegistrarEvento(oUsuario, "modificacion_permisos");

        //    MessageBox.Show("Permisos Actualizados");
        //    oUsuario = null;
        //    oPadreAgregar = null;
        //    oPadre = null;
        //    //Lista para permisos usuario 
        //    lPermisosUsuario = null;// lista de permisos de usuario , la voy actualizando a medida que agrego o elimino permisos

        //    lPermiso = null;
        //    lPermisosEliminados = null;
        //    treeView1.Nodes.Clear();
        //}

        private void btnUsuarioEditar_Click_1(object sender, EventArgs e)
        {
            lPermisosUsuario = new List<BEPermiso>();
            oUsuario = (BEUser)cmbUsuarios.SelectedItem;// Obtengo el usuario del ComboBox
            recuperarObjetoPermisosUsuario(oUsuario);

            lPermisosUsuarioOrig = null;

            lPermisosUsuarioOrig = new List<BEPermiso>(lPermisosUsuario);

        }

        private void btnGuardarConfig_Click_1(object sender, EventArgs e)
        {
           
        }

        private void btnEliminarPermiso_Click_1(object sender, EventArgs e)
        {

            TreeNode nodoSeleccionado = treeView1.SelectedNode;
            permisosUsuarioEliminados = new List<(string userName, int IdPermiso)>();

            if (nodoSeleccionado != null)// si tengo un nodo seleccionado
            {
                if (EsMenu(nodoSeleccionado))//Verifico si es Menu
                {
                    BEPadre padreEliminar = (BEPadre)nodoSeleccionado.Tag;

                    int idPadre = padreEliminar.Id;

                    // Eliminar el nodo seleccionado del tree view 
                    //
                    lPermisosEliminados = lPermisosUsuario;

                    permisosUsuarioEliminados.Add((oUsuario.Username, idPadre));//Añado el menu seleccionado para eliminar

                    BEPadre oMenu = new BEPadre();
                    oMenu.VaciarSubcomponente();





                    foreach (var item in lPermisosEliminados)
                    {
                        if (item.Id != idPadre)
                        {
                            oMenu.AgregarSubcomponente(item);// agrego los hijos
                        }

                    }

                    lPermisosUsuario = new List<BEPermiso>();
                    //   lPermisosUsuario.Clear();
                    // lPermisosUsuario = oMenu.SubComponentes;//.Add(oMenu);
                    lPermisosUsuario = new List<BEPermiso>(oMenu.SubComponentes);
                    //lPermiso = oMenuEliminado.SubComponentes;
                    llenarMenuTreeView(lPermisosUsuario);





                }
                else if (EsHijo(nodoSeleccionado))//Verifico si es SubMenu
                {

                    BEHijo hijoEliminar = (BEHijo)nodoSeleccionado.Tag;
                    int idHijo = hijoEliminar.Id;

                    // si es -1 usar el idsubmenu para patentes

                    int idPadre = ObtenerIdMenuDesdeSubmenu(treeView1.Nodes[0], idHijo);
                    if (idPadre == -1)
                    {
                        idPadre = idHijo;

                        BEHijo oHijo = new BEHijo();

                        lPermisosEliminados = lPermisosUsuario;

                        permisosUsuarioEliminados.Add((oUsuario.Username, idPadre));//Añado el menu seleccionado para eliminar

                        BEPadre oPadre = new BEPadre();
                        oPadre.VaciarSubcomponente();


                        foreach (var item in lPermisosEliminados)
                        {
                            if (item.Id != idPadre)
                            {
                                oPadre.AgregarSubcomponente(item);// agrego los hijos
                            }

                        }

                        lPermisosUsuario = new List<BEPermiso>();

                        //lPermisosUsuario = oMenu.SubComponentes;
                        lPermisosUsuario = new List<BEPermiso>(oPadre.SubComponentes);
                        llenarMenuTreeView(lPermisosUsuario);


                    }
                    else
                    {
                        MessageBox.Show("Debe eliminar el arbol completo");
                    }

                }


            }

        }

      

        private void btnMenuSeleccionar_Click(object sender, EventArgs e)
        {
            if (oUsuario != null)// evito que si presionan seleccionar sin haber hecho clic en modificar primero , no rompa 
            {
                oPadreAgregar = new BEPadre();
                oPadreAgregar.VaciarSubcomponente();
                oPadreAgregar = (BEPadre)cmbBoxMenuLista.SelectedItem;

                List<BEPermiso> listaPermisosvalidar = lPermisosUsuario.ToList(); // Conversión a List<BEPermiso>
                recuperarObjetoMenu();

                if (bllpadre.ValidarPermisoNoExistente(listaPermisosvalidar, oPadreAgregar) == true)
                {



                    oUsuario.LPermisos.Add(oPadreAgregar);
                    lPermisosUsuario.Add(oPadreAgregar);
                    llenarMenuTreeView(lPermisosUsuario);





                }
                else
                {


                    MessageBox.Show("Permiso ya existente");
                }



            }
        }

        private void btnSubMenuSeleccionar_Click(object sender, EventArgs e)
        {
            if (oUsuario != null)// evito que si presionan seleccionar sin haber hecho clic en modificar primero , no rompa 
            {

                BEHijo oHijo;
                oHijo = (BEHijo)cmbBoxNombreSubMenu.SelectedItem;
                List<BEPermiso> listaPermisosvalidar = lPermisosUsuario.ToList(); // Conversión a List<BEPermiso>

                if (bllpadre.ValidarIdPermiso(listaPermisosvalidar, oHijo.Id) == true)
                {
                    oUsuario.LPermisos.Add(oHijo);
                    lPermisosUsuario.Add(oHijo);
                    llenarMenuTreeView(lPermisosUsuario);


                }
                else
                {


                    MessageBox.Show("Permiso ya existente");
                }
            }
            //
        }

        private void btnGuardarConfig_Click(object sender, EventArgs e)
        {
            bllpadre.ActualizarPermisosUsuario(oUsuario, lPermisosUsuarioOrig, lPermisosUsuario);
            BLLUsuario bllUsuario = new BLLUsuario();
            //bllUsuario.RegistrarEvento(oUsuario, "modificacion_permisos");

            MessageBox.Show("Permisos Actualizados");
            oUsuario = null;
            oPadreAgregar = null;
            //oPadre = null;
            //Lista para permisos usuario 
            lPermisosUsuario = null;// lista de permisos de usuario , la voy actualizando a medida que agrego o elimino permisos

            lPermiso = null;
            lPermisosEliminados = null;
            treeView1.Nodes.Clear();
        }



        //public void Registrarse()
        //{
        //    BLLTraductor BllTraductor = new BLLTraductor();
        //    BllTraductor.RegistrarForm(this);
        //}

        //public void Actualizar()
        //{
        //    BLLTraductor bllTraductor = new BLLTraductor();
        //    List<BEPalabra> Palabras = bllTraductor.ObtenerPalabras();

        //    if (this.Tag != null & this.Tag != "")
        //    {
        //        this.Text = Palabras.Find(pal => pal.Tag.Equals(Tag)).Texto;
        //    }
        //    //foreach (Control control in Controls)
        //    //{
        //    //    if (control.Tag != null & control.Tag != "")
        //    //    {
        //    //            control.Text = Palabras.Find(pal => pal.Tag.Equals(control.Tag)).Texto;
        //    //    }
        //    //}
        //}


    }
}