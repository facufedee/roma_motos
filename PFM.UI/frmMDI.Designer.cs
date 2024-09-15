namespace UI
{
    partial class frmMDI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.bitacoraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listarBitacoraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionUser = new System.Windows.Forms.ToolStripMenuItem();
            this.altaUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambioDeContraseñaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.permisoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.permisosUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionarIdiomaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearIdiomaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarIdiomaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlDeVersionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.motoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administracionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tallerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ingresarClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventasPorVendedorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inspeccionarMotoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ingresarMotoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ingresarDocumentacionClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entregarMotoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entregarMotoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bitacoraToolStripMenuItem,
            this.gestionUser,
            this.gestionarIdiomaToolStripMenuItem,
            this.controlDeVersionesToolStripMenuItem,
            this.motoToolStripMenuItem,
            this.tallerToolStripMenuItem,
            this.administracionToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1028, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // bitacoraToolStripMenuItem
            // 
            this.bitacoraToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listarBitacoraToolStripMenuItem});
            this.bitacoraToolStripMenuItem.Name = "bitacoraToolStripMenuItem";
            this.bitacoraToolStripMenuItem.Size = new System.Drawing.Size(78, 24);
            this.bitacoraToolStripMenuItem.Tag = "bitacora";
            this.bitacoraToolStripMenuItem.Text = "Bitacora";
            this.bitacoraToolStripMenuItem.Click += new System.EventHandler(this.bitacoraToolStripMenuItem_Click);
            // 
            // listarBitacoraToolStripMenuItem
            // 
            this.listarBitacoraToolStripMenuItem.Name = "listarBitacoraToolStripMenuItem";
            this.listarBitacoraToolStripMenuItem.Size = new System.Drawing.Size(186, 26);
            this.listarBitacoraToolStripMenuItem.Tag = "listar_bitacora";
            this.listarBitacoraToolStripMenuItem.Text = "Listar Bitacora";
            this.listarBitacoraToolStripMenuItem.Click += new System.EventHandler(this.listarBitacoraToolStripMenuItem_Click);
            // 
            // gestionUser
            // 
            this.gestionUser.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altaUsuarioToolStripMenuItem,
            this.modificarUsuarioToolStripMenuItem,
            this.cambioDeContraseñaToolStripMenuItem,
            this.permisoToolStripMenuItem,
            this.permisosUsuariosToolStripMenuItem});
            this.gestionUser.Name = "gestionUser";
            this.gestionUser.Size = new System.Drawing.Size(131, 24);
            this.gestionUser.Tag = "gestion_de_perfil";
            this.gestionUser.Text = "Gestion de Perfil";
            this.gestionUser.Click += new System.EventHandler(this.gestionDeUsuariosToolStripMenuItem_Click);
            // 
            // altaUsuarioToolStripMenuItem
            // 
            this.altaUsuarioToolStripMenuItem.Name = "altaUsuarioToolStripMenuItem";
            this.altaUsuarioToolStripMenuItem.Size = new System.Drawing.Size(241, 26);
            this.altaUsuarioToolStripMenuItem.Tag = "alta_usuario";
            this.altaUsuarioToolStripMenuItem.Text = "Alta usuario";
            this.altaUsuarioToolStripMenuItem.Click += new System.EventHandler(this.altaUsuarioToolStripMenuItem_Click);
            // 
            // modificarUsuarioToolStripMenuItem
            // 
            this.modificarUsuarioToolStripMenuItem.Name = "modificarUsuarioToolStripMenuItem";
            this.modificarUsuarioToolStripMenuItem.Size = new System.Drawing.Size(241, 26);
            this.modificarUsuarioToolStripMenuItem.Tag = "modificar_usuario";
            this.modificarUsuarioToolStripMenuItem.Text = "Modificar Usuario";
            this.modificarUsuarioToolStripMenuItem.Click += new System.EventHandler(this.modificarUsuarioToolStripMenuItem_Click);
            // 
            // cambioDeContraseñaToolStripMenuItem
            // 
            this.cambioDeContraseñaToolStripMenuItem.Name = "cambioDeContraseñaToolStripMenuItem";
            this.cambioDeContraseñaToolStripMenuItem.Size = new System.Drawing.Size(241, 26);
            this.cambioDeContraseñaToolStripMenuItem.Tag = "cambio_contraseña";
            this.cambioDeContraseñaToolStripMenuItem.Text = "Cambio de contraseña";
            this.cambioDeContraseñaToolStripMenuItem.Click += new System.EventHandler(this.cambioDeContraseñaToolStripMenuItem_Click);
            // 
            // permisoToolStripMenuItem
            // 
            this.permisoToolStripMenuItem.Name = "permisoToolStripMenuItem";
            this.permisoToolStripMenuItem.Size = new System.Drawing.Size(241, 26);
            this.permisoToolStripMenuItem.Tag = "permisos";
            this.permisoToolStripMenuItem.Text = "Permisos";
            this.permisoToolStripMenuItem.Click += new System.EventHandler(this.permisoToolStripMenuItem_Click);
            // 
            // permisosUsuariosToolStripMenuItem
            // 
            this.permisosUsuariosToolStripMenuItem.Name = "permisosUsuariosToolStripMenuItem";
            this.permisosUsuariosToolStripMenuItem.Size = new System.Drawing.Size(241, 26);
            this.permisosUsuariosToolStripMenuItem.Tag = "permisos_usuarios";
            this.permisosUsuariosToolStripMenuItem.Text = "Permisos Usuarios";
            this.permisosUsuariosToolStripMenuItem.Click += new System.EventHandler(this.permisosUsuariosToolStripMenuItem_Click);
            // 
            // gestionarIdiomaToolStripMenuItem
            // 
            this.gestionarIdiomaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crearIdiomaToolStripMenuItem,
            this.modificarIdiomaToolStripMenuItem});
            this.gestionarIdiomaToolStripMenuItem.Name = "gestionarIdiomaToolStripMenuItem";
            this.gestionarIdiomaToolStripMenuItem.Size = new System.Drawing.Size(137, 24);
            this.gestionarIdiomaToolStripMenuItem.Tag = "gestionar_idioma";
            this.gestionarIdiomaToolStripMenuItem.Text = "Gestionar Idioma";
            // 
            // crearIdiomaToolStripMenuItem
            // 
            this.crearIdiomaToolStripMenuItem.Name = "crearIdiomaToolStripMenuItem";
            this.crearIdiomaToolStripMenuItem.Size = new System.Drawing.Size(207, 26);
            this.crearIdiomaToolStripMenuItem.Tag = "crear_idioma";
            this.crearIdiomaToolStripMenuItem.Text = "Crear Idioma";
            this.crearIdiomaToolStripMenuItem.Click += new System.EventHandler(this.crearIdiomaToolStripMenuItem_Click);
            // 
            // modificarIdiomaToolStripMenuItem
            // 
            this.modificarIdiomaToolStripMenuItem.Name = "modificarIdiomaToolStripMenuItem";
            this.modificarIdiomaToolStripMenuItem.Size = new System.Drawing.Size(207, 26);
            this.modificarIdiomaToolStripMenuItem.Tag = "modificar_idioma";
            this.modificarIdiomaToolStripMenuItem.Text = "Modificar Idioma";
            this.modificarIdiomaToolStripMenuItem.Click += new System.EventHandler(this.modificarIdiomaToolStripMenuItem_Click);
            // 
            // controlDeVersionesToolStripMenuItem
            // 
            this.controlDeVersionesToolStripMenuItem.Name = "controlDeVersionesToolStripMenuItem";
            this.controlDeVersionesToolStripMenuItem.Size = new System.Drawing.Size(159, 24);
            this.controlDeVersionesToolStripMenuItem.Tag = "control_de_versiones";
            this.controlDeVersionesToolStripMenuItem.Text = "Control de Versiones";
            this.controlDeVersionesToolStripMenuItem.Click += new System.EventHandler(this.controlDeVersionesToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.salirToolStripMenuItem.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salirToolStripMenuItem.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(129, 24);
            this.salirToolStripMenuItem.Tag = "cerrar_sistema";
            this.salirToolStripMenuItem.Text = "Cerrar Sistema";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(895, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // motoToolStripMenuItem
            // 
            this.motoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ingresarClienteToolStripMenuItem,
            this.ventasPorVendedorToolStripMenuItem});
            this.motoToolStripMenuItem.Name = "motoToolStripMenuItem";
            this.motoToolStripMenuItem.Size = new System.Drawing.Size(66, 24);
            this.motoToolStripMenuItem.Text = "Ventas";
            this.motoToolStripMenuItem.Click += new System.EventHandler(this.motoToolStripMenuItem_Click);
            // 
            // administracionToolStripMenuItem
            // 
            this.administracionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ingresarMotoToolStripMenuItem,
            this.ingresarDocumentacionClienteToolStripMenuItem,
            this.entregarMotoToolStripMenuItem});
            this.administracionToolStripMenuItem.Name = "administracionToolStripMenuItem";
            this.administracionToolStripMenuItem.Size = new System.Drawing.Size(123, 24);
            this.administracionToolStripMenuItem.Text = "Administracion";
            // 
            // tallerToolStripMenuItem
            // 
            this.tallerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inspeccionarMotoToolStripMenuItem,
            this.entregarMotoToolStripMenuItem1});
            this.tallerToolStripMenuItem.Name = "tallerToolStripMenuItem";
            this.tallerToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
            this.tallerToolStripMenuItem.Text = "Taller";
            // 
            // ingresarClienteToolStripMenuItem
            // 
            this.ingresarClienteToolStripMenuItem.Name = "ingresarClienteToolStripMenuItem";
            this.ingresarClienteToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
            this.ingresarClienteToolStripMenuItem.Text = "Ingresar Cliente";
            // 
            // ventasPorVendedorToolStripMenuItem
            // 
            this.ventasPorVendedorToolStripMenuItem.Name = "ventasPorVendedorToolStripMenuItem";
            this.ventasPorVendedorToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
            this.ventasPorVendedorToolStripMenuItem.Text = "Ventas por vendedor";
            // 
            // inspeccionarMotoToolStripMenuItem
            // 
            this.inspeccionarMotoToolStripMenuItem.Name = "inspeccionarMotoToolStripMenuItem";
            this.inspeccionarMotoToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.inspeccionarMotoToolStripMenuItem.Text = "Inspeccionar Moto";
            // 
            // ingresarMotoToolStripMenuItem
            // 
            this.ingresarMotoToolStripMenuItem.Name = "ingresarMotoToolStripMenuItem";
            this.ingresarMotoToolStripMenuItem.Size = new System.Drawing.Size(302, 26);
            this.ingresarMotoToolStripMenuItem.Text = "Ingresar Moto";
            // 
            // ingresarDocumentacionClienteToolStripMenuItem
            // 
            this.ingresarDocumentacionClienteToolStripMenuItem.Name = "ingresarDocumentacionClienteToolStripMenuItem";
            this.ingresarDocumentacionClienteToolStripMenuItem.Size = new System.Drawing.Size(302, 26);
            this.ingresarDocumentacionClienteToolStripMenuItem.Text = "Ingresar Documentacion cliente";
            // 
            // entregarMotoToolStripMenuItem
            // 
            this.entregarMotoToolStripMenuItem.Name = "entregarMotoToolStripMenuItem";
            this.entregarMotoToolStripMenuItem.Size = new System.Drawing.Size(302, 26);
            this.entregarMotoToolStripMenuItem.Text = "Entregar Moto";
            // 
            // entregarMotoToolStripMenuItem1
            // 
            this.entregarMotoToolStripMenuItem1.Name = "entregarMotoToolStripMenuItem1";
            this.entregarMotoToolStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.entregarMotoToolStripMenuItem1.Text = "Entregar Moto";
            // 
            // frmMDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1028, 596);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMDI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administracion";
            this.TransparencyKey = System.Drawing.Color.Black;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem bitacoraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionUser;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem altaUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambioDeContraseñaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listarBitacoraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionarIdiomaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crearIdiomaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarIdiomaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controlDeVersionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem permisoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem permisosUsuariosToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ToolStripMenuItem motoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ingresarClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventasPorVendedorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tallerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inspeccionarMotoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem entregarMotoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem administracionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ingresarMotoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ingresarDocumentacionClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem entregarMotoToolStripMenuItem;
    }
}

