using BE;
using BLL;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using ABSTRACCION;

namespace UI
{
    public partial class frmGestionUser : Form, ITraducible
    {
        private BEUser UsuarioLogueado;
        private BLLUsuario _bllUsuario;

        public frmGestionUser()
        {
            InitializeComponent();
            CargarUsuarioLogueado();
            Registrarse();
            Actualizar();
        }

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
        public void CargarUsuarioLogueado()
        {
            _bllUsuario = new BLLUsuario();
            UsuarioLogueado = _bllUsuario.ObtenerUsuarioLogueado();

            txtUserAlta.Text = UsuarioLogueado.Username;
            txtPassActual.Text = UsuarioLogueado.Password;
        }

        private bool ValidarNuevaContraseña(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor, ingrese una contraseña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!_bllUsuario.ValidarPassFormato(password))
            {
                MessageBox.Show("La contraseña debe contener entre 6 y 15 caracteres alfanuméricos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassNueva.Text = "";
                return false;
            }

            if (password == UsuarioLogueado.Password)
            {
                MessageBox.Show("La nueva contraseña no puede ser igual a la contraseña actual.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {

            string password = txtPassNueva.Text;

            if (!ValidarNuevaContraseña(password))
                return;

            try
            {
                string passwordEncriptada = _bllUsuario.Encriptar(password);
                UsuarioLogueado.Password = passwordEncriptada;

                bool exitoso = true;// _bllUsuario.ModificarUsuario(UsuarioLogueado);

                if (exitoso)
                {
                    MessageBox.Show("Contraseña actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al actualizar la contraseña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
