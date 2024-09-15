using ABSTRACCION;
using Abstraccion;
using System;
using BLL;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using BE;
using SERVICIOS;

namespace UI
{
    public partial class frmBitacora : Form,ITraducible
    {
        private BLLBitacora _bllBitacora = new BLLBitacora();
        private int pagina = 1;
        private int porPagina = 6;
        private int totalPorPagina = 0;
        private string filtroBusqueda = "";
        BLLUsuario _bllUsuario = new BLLUsuario();
        BEBitacora _beBitacora;
        public frmBitacora()
        {
            InitializeComponent();
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
        private void Bitacora_Load(object sender, EventArgs e)
        {
            dtpDesde.MaxDate = DateTime.Today;
            cbBitacoraTipo.DataSource = Enum.GetValues(typeof(BitacoraTipo));
            labelUser.Text = "Bienvenido "+Sesion.Instance.ObtenerUsername().ToUpper();
            ActualizarGrilla();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            filtroBusqueda = txtTexto.Text;
            ActualizarGrilla();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (pagina > 1)
            {
                pagina--;
                ActualizarGrilla();
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (pagina < totalPorPagina)
            {
                pagina++;
                ActualizarGrilla();
            }
        }

        private void ActualizarGrilla()
        {
            try
            {
                if(dtpDesde.Value > dtpHasta.Value)
                {
                    MessageBox.Show("La fecha \"Desde\" tiene que ser menor a la fecha \"Hasta\"");
                    return;
                }

                var filtros = new BEBitacoraFiltros(){Desde = dtpDesde.Value,Hasta = dtpHasta.Value,Tipo = (BitacoraTipo)cbBitacoraTipo.SelectedItem, Buscar = filtroBusqueda};

                var bitacora = _bllBitacora.ObtenerFiltrado(pagina, porPagina, filtros);
                totalPorPagina = bitacora.TotalPorPagina;

                dgvBitacora.DataSource = null;
                dgvBitacora.DataSource = bitacora.Bitacoras;
                dgvBitacora.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                btnAnterior.Enabled = (pagina > 1);
                btnSiguiente.Enabled = (pagina < totalPorPagina);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error al actualizar la grilla: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {

            registrarCierreDeSesion();
            this.Hide();
            frmLogin ofrmLog = new frmLogin();
            ofrmLog.Show();
        }

        private void btnSalirSistema_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Está seguro de que desea salir?", "Confirmar salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                this.Close();
            }
        }

        void registrarCierreDeSesion()
        {
            _beBitacora = new BEBitacora();
            _beBitacora.Tipo = BitacoraTipo.INFO;
            _beBitacora.Usuario = Sesion.Instance.ObtenerUsername();
            _beBitacora.Mensaje = "Cierre de sesion";
            _bllBitacora.Add(_beBitacora);
        }
    }

}
