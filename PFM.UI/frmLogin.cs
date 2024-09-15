using BE;
using BLL;
using SERVICIOS;
using System;
using System.Windows.Forms;

namespace UI
{
    public partial class frmLogin : Form
    {
        private readonly BLLUsuario _bllUsuario;
        private readonly BLLBitacora _bllBitacora;

        public frmLogin()
        {
            InitializeComponent();
            _bllUsuario = new BLLUsuario();
            _bllBitacora = new BLLBitacora();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            IniciarSesion();
        }

        private void IniciarSesion()
        {
            try
            {
                // Validación básica de los campos
                if (string.IsNullOrEmpty(txtUser.Text))
                {
                    toolTip2.Show("Por favor ingresar un usuario", txtUser, 0, 0, 1200);
                    return;
                }
                if (string.IsNullOrEmpty(txtPassword.Text))
                {
                    toolTip1.Show("Por favor ingrese una contraseña", txtPassword, 0, 0, 1200);
                    return;
                }

                var resultado = _bllUsuario.IniciarSesion(txtUser.Text, txtPassword.Text);

                if (!resultado.Exito)
                {
                    MessageBox.Show(resultado.MensajeError, "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LimpiarTxt();
                    return;
                }

               //Inicio exitoso, ocultamos el formulario actual
               Sesion.Instance.Login(resultado.Usuario);

                // Registro de la bitácora
                _bllBitacora.RegistrarInicioSesion(txtUser.Text);

                this.Hide();
                frmMDI ofrmContenedor = new frmMDI();
                ofrmContenedor.Show();
            }
            catch (Exception ex)
            {
                //_bllBitacora.RegistrarError(Sesion.ObtenerUsername(), ex.Message);
                MessageBox.Show("Se produjo un error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LimpiarTxt()
        {
            txtUser.Text = "";
            txtPassword.Text = "";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Está seguro de que desea salir?", "Confirmar salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void txtPassword_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                IniciarSesion();
            }
        }

        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                IniciarSesion();
            }
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAltaUsuario ofrmAlta = new frmAltaUsuario();
            ofrmAlta.Show();
        }
    }
}
