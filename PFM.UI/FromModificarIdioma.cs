using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ABSTRACCION;
using BLL;

namespace UI
{
    public partial class FromModificarIdioma : Form, ITraducible
    {
        public delegate void DelIdioma();
        public event DelIdioma EvIdioma;
        private List<BEPalabra> Palabras;
        private BEIdioma IdiomaSeleccionado;
        public FromModificarIdioma()
        {
            InitializeComponent();
            Registrarse();
            Actualizar();
            CargarIdiomas();
            CargarPalabras();
        }

        private void CargarIdiomas()
        {
            BLLTraductor bllTraductor = new BLLTraductor();
            List<BEIdioma> Idiomas = bllTraductor.ObtenerIdiomas();
            comboBox1.DataSource = null;
            comboBox1.DataSource = Idiomas;
        }

        private void CargarPalabras()
        {
            if (IdiomaSeleccionado == null) { return; }
            BLLTraductor bllTraductor = new BLLTraductor();
            Palabras = bllTraductor.ObtenerPalabras(IdiomaSeleccionado.Id);

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Palabras;
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["Tag"].ReadOnly = true;
        }


        private void metroButton1_Click_1(object sender, EventArgs e)
        {
            List<BEPalabra> Palabras = (List<BEPalabra>)dataGridView1.DataSource;

            BLLTraductor bllTraductor = new BLLTraductor();
            bllTraductor.ModificarIdioma(Palabras);
            //EvIdioma();
            Actualizar();
            CargarIdiomas();
            CargarPalabras();
        }


        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            IdiomaSeleccionado = (BEIdioma)comboBox1.SelectedItem;
            CargarPalabras();
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
    }

}

