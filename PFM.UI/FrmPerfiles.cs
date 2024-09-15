using BE;
using BLL;
using SERVICIOS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//TIENE COMENTARIOS
namespace UI
{
    public partial class FrmPerfiles : Form
    {
        private List<BEUser> Usuarios;
        private List<BEUser> UsuariosVersionados;
        BEUser UsuarioSeleccionado;
        BEUser CambioSeleccionado;
        public FrmPerfiles()
        {
            InitializeComponent();
        }

        private void FrmPerfiles_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
        }
        //NECESITO CARGAR TODOS LOS USUARIOS? O CON EL ACTUAL NO ES SUFICIENTE? 
        private void CargarUsuarios()
        {


            BLLUsuario bllUsuario = new BLLUsuario();
            Usuarios = (List<BEUser>)bllUsuario.ObtenerUsuarios();

            listBox1.Items.Clear();

            foreach (BEUser usuario in Usuarios)
            {
                listBox1.Items.Add(usuario);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UsuarioSeleccionado = (BEUser)listBox1.SelectedItem;
            dataGridView1.DataSource = null;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CambioSeleccionado = (BEUser)dataGridView1.CurrentRow.DataBoundItem;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            if (CambioSeleccionado == null)
            {
                MessageBox.Show("Seleccione un cambio");
                return;
            }
            BLLUsuario bllUsuario = new BLLUsuario();

            UsuarioSeleccionado.Nombre = CambioSeleccionado.Nombre;
            UsuarioSeleccionado.Apellido = CambioSeleccionado.Apellido;
            UsuarioSeleccionado.Mail = CambioSeleccionado.Mail;
            UsuarioSeleccionado.DVV = bllUsuario.CalcularDVV();

            bool actualizacionExitosa = true; // bllUsuario.ModificarUsuario();
            if (!actualizacionExitosa)
            {
                MessageBox.Show("No se puedo volver a una version anterior");
                return;
            }

            //bllUsuario.ActualizarUsuario(UsuarioSeleccionado);
            CambioSeleccionado = null;
            UsuarioSeleccionado = null;

            CargarUsuarios();
            UsuariosVersionados = new List<BEUser>();
            dataGridView1.DataSource = null;
        }

        private void btnVersiones_Click(object sender, EventArgs e)
        {

            if (UsuarioSeleccionado == null)
            {
                MessageBox.Show("Seleccione un usuario");
                return;
            }

            BLLUsuario bllUsuario = new BLLUsuario();
            //UsuariosVersionados = bllUsuario.ObtenerVersiones(UsuarioSeleccionado);

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = UsuariosVersionados;
            dataGridView1.Columns["Password"].Visible = false;
            dataGridView1.Columns["DVV"].Visible = false;
        }
    }
}
