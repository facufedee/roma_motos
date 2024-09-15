namespace UI
{
    partial class frmAltaUsuario
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Email = new System.Windows.Forms.Label();
            this.Apellido = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMailAlta = new System.Windows.Forms.TextBox();
            this.txtApellidoAlta = new System.Windows.Forms.TextBox();
            this.txtNombreAlta = new System.Windows.Forms.TextBox();
            this.txtConfirm = new System.Windows.Forms.TextBox();
            this.txtUserAlta = new System.Windows.Forms.TextBox();
            this.txtPassAlta = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(848, 39);
            this.panel1.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 12.2F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(669, 9);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(166, 25);
            this.label7.TabIndex = 1;
            this.label7.Tag = "alta_usuario";
            this.label7.Text = "Alta de usuario";
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSalir.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Arial Narrow", 11F, System.Drawing.FontStyle.Bold);
            this.btnSalir.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSalir.Location = new System.Drawing.Point(322, 257);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(188, 43);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Tag = "salir";
            this.btnSalir.Text = "Cancelar";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLogin.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Arial Narrow", 11F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLogin.Location = new System.Drawing.Point(107, 257);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(188, 43);
            this.btnLogin.TabIndex = 6;
            this.btnLogin.Tag = "crear_usuario";
            this.btnLogin.Text = "Crear Usuario";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click_1);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 10.2F);
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(318, 107);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 22);
            this.label2.TabIndex = 51;
            this.label2.Tag = "contraseña";
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 10.2F);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(318, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 22);
            this.label1.TabIndex = 52;
            this.label1.Tag = "usuario";
            this.label1.Text = "Username";
            // 
            // Email
            // 
            this.Email.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Email.AutoSize = true;
            this.Email.Font = new System.Drawing.Font("Arial Narrow", 10.2F);
            this.Email.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Email.Location = new System.Drawing.Point(68, 172);
            this.Email.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(37, 22);
            this.Email.TabIndex = 50;
            this.Email.Tag = "mail";
            this.Email.Text = "Mail";
            // 
            // Apellido
            // 
            this.Apellido.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Apellido.AutoSize = true;
            this.Apellido.Font = new System.Drawing.Font("Arial Narrow", 10.2F);
            this.Apellido.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Apellido.Location = new System.Drawing.Point(65, 112);
            this.Apellido.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Apellido.Name = "Apellido";
            this.Apellido.Size = new System.Drawing.Size(60, 22);
            this.Apellido.TabIndex = 49;
            this.Apellido.Tag = "apellido";
            this.Apellido.Text = "Apellido";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Narrow", 10.2F);
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(65, 51);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 22);
            this.label9.TabIndex = 48;
            this.label9.Tag = "nombre";
            this.label9.Text = "Nombre";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 10.2F);
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(318, 172);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 22);
            this.label5.TabIndex = 40;
            this.label5.Tag = "confirmar_contraseña";
            this.label5.Text = "Confirm password";
            // 
            // txtMailAlta
            // 
            this.txtMailAlta.AcceptsReturn = true;
            this.txtMailAlta.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtMailAlta.BackColor = System.Drawing.SystemColors.Window;
            this.txtMailAlta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMailAlta.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMailAlta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMailAlta.ForeColor = System.Drawing.Color.Black;
            this.txtMailAlta.Location = new System.Drawing.Point(72, 197);
            this.txtMailAlta.MaxLength = 30;
            this.txtMailAlta.Name = "txtMailAlta";
            this.txtMailAlta.Size = new System.Drawing.Size(223, 27);
            this.txtMailAlta.TabIndex = 2;
            // 
            // txtApellidoAlta
            // 
            this.txtApellidoAlta.AcceptsReturn = true;
            this.txtApellidoAlta.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtApellidoAlta.BackColor = System.Drawing.SystemColors.Window;
            this.txtApellidoAlta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApellidoAlta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellidoAlta.ForeColor = System.Drawing.Color.Black;
            this.txtApellidoAlta.Location = new System.Drawing.Point(69, 137);
            this.txtApellidoAlta.MaxLength = 20;
            this.txtApellidoAlta.Name = "txtApellidoAlta";
            this.txtApellidoAlta.Size = new System.Drawing.Size(224, 27);
            this.txtApellidoAlta.TabIndex = 1;
            // 
            // txtNombreAlta
            // 
            this.txtNombreAlta.AcceptsReturn = true;
            this.txtNombreAlta.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNombreAlta.BackColor = System.Drawing.SystemColors.Window;
            this.txtNombreAlta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombreAlta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreAlta.ForeColor = System.Drawing.Color.Black;
            this.txtNombreAlta.Location = new System.Drawing.Point(69, 76);
            this.txtNombreAlta.MaxLength = 20;
            this.txtNombreAlta.Name = "txtNombreAlta";
            this.txtNombreAlta.Size = new System.Drawing.Size(224, 27);
            this.txtNombreAlta.TabIndex = 0;
            // 
            // txtConfirm
            // 
            this.txtConfirm.AcceptsReturn = true;
            this.txtConfirm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtConfirm.BackColor = System.Drawing.SystemColors.Window;
            this.txtConfirm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirm.ForeColor = System.Drawing.Color.Black;
            this.txtConfirm.Location = new System.Drawing.Point(322, 197);
            this.txtConfirm.MaxLength = 20;
            this.txtConfirm.Name = "txtConfirm";
            this.txtConfirm.PasswordChar = '*';
            this.txtConfirm.Size = new System.Drawing.Size(223, 27);
            this.txtConfirm.TabIndex = 5;
            // 
            // txtUserAlta
            // 
            this.txtUserAlta.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtUserAlta.BackColor = System.Drawing.SystemColors.Window;
            this.txtUserAlta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserAlta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserAlta.ForeColor = System.Drawing.Color.Black;
            this.txtUserAlta.Location = new System.Drawing.Point(322, 76);
            this.txtUserAlta.MaxLength = 20;
            this.txtUserAlta.Name = "txtUserAlta";
            this.txtUserAlta.Size = new System.Drawing.Size(223, 28);
            this.txtUserAlta.TabIndex = 3;
            // 
            // txtPassAlta
            // 
            this.txtPassAlta.AcceptsReturn = true;
            this.txtPassAlta.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPassAlta.BackColor = System.Drawing.SystemColors.Window;
            this.txtPassAlta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassAlta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassAlta.ForeColor = System.Drawing.Color.Black;
            this.txtPassAlta.Location = new System.Drawing.Point(324, 135);
            this.txtPassAlta.MaxLength = 20;
            this.txtPassAlta.Name = "txtPassAlta";
            this.txtPassAlta.PasswordChar = '*';
            this.txtPassAlta.Size = new System.Drawing.Size(221, 27);
            this.txtPassAlta.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.txtMailAlta);
            this.groupBox1.Controls.Add(this.btnSalir);
            this.groupBox1.Controls.Add(this.txtConfirm);
            this.groupBox1.Controls.Add(this.btnLogin);
            this.groupBox1.Controls.Add(this.txtUserAlta);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtPassAlta);
            this.groupBox1.Controls.Add(this.txtApellidoAlta);
            this.groupBox1.Controls.Add(this.Apellido);
            this.groupBox1.Controls.Add(this.txtNombreAlta);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Email);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Font = new System.Drawing.Font("Arial Narrow", 12.2F);
            this.groupBox1.Location = new System.Drawing.Point(143, 99);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(610, 330);
            this.groupBox1.TabIndex = 53;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "alta_usuario";
            this.groupBox1.Text = "Alta de Usuario";
            // 
            // frmAltaUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(848, 481);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmAltaUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "    Alta de Usuario";
            this.Load += new System.EventHandler(this.frmAltaUsuario_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Email;
        private System.Windows.Forms.Label Apellido;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMailAlta;
        private System.Windows.Forms.TextBox txtApellidoAlta;
        private System.Windows.Forms.TextBox txtNombreAlta;
        private System.Windows.Forms.TextBox txtConfirm;
        private System.Windows.Forms.TextBox txtUserAlta;
        private System.Windows.Forms.TextBox txtPassAlta;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}