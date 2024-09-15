namespace UI
{
    partial class frmCrearIdioma
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCrearIdioma));
            this.dgvIdioma = new System.Windows.Forms.DataGridView();
            this.lblNombreIdioma = new System.Windows.Forms.Label();
            this.txtCrearIdioma = new System.Windows.Forms.TextBox();
            this.printForm1 = new Microsoft.VisualBasic.PowerPacks.Printing.PrintForm(this.components);
            this.btnCrearIdioma = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTituloCrearIdioma = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIdioma)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvIdioma
            // 
            this.dgvIdioma.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvIdioma.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIdioma.Location = new System.Drawing.Point(52, 135);
            this.dgvIdioma.Margin = new System.Windows.Forms.Padding(4);
            this.dgvIdioma.Name = "dgvIdioma";
            this.dgvIdioma.RowHeadersWidth = 51;
            this.dgvIdioma.Size = new System.Drawing.Size(415, 540);
            this.dgvIdioma.TabIndex = 3;
            // 
            // lblNombreIdioma
            // 
            this.lblNombreIdioma.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNombreIdioma.AutoSize = true;
            this.lblNombreIdioma.Font = new System.Drawing.Font("Arial Narrow", 10.2F);
            this.lblNombreIdioma.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblNombreIdioma.Location = new System.Drawing.Point(206, 77);
            this.lblNombreIdioma.Name = "lblNombreIdioma";
            this.lblNombreIdioma.Size = new System.Drawing.Size(62, 22);
            this.lblNombreIdioma.TabIndex = 4;
            this.lblNombreIdioma.Tag = "nombre";
            this.lblNombreIdioma.Text = "Nombre";
            // 
            // txtCrearIdioma
            // 
            this.txtCrearIdioma.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCrearIdioma.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCrearIdioma.Location = new System.Drawing.Point(210, 97);
            this.txtCrearIdioma.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCrearIdioma.Name = "txtCrearIdioma";
            this.txtCrearIdioma.Size = new System.Drawing.Size(256, 22);
            this.txtCrearIdioma.TabIndex = 5;
            // 
            // printForm1
            // 
            this.printForm1.DocumentName = "document";
            this.printForm1.Form = this;
            this.printForm1.PrintAction = System.Drawing.Printing.PrintAction.PrintToPrinter;
            this.printForm1.PrinterSettings = ((System.Drawing.Printing.PrinterSettings)(resources.GetObject("printForm1.PrinterSettings")));
            this.printForm1.PrintFileName = null;
            // 
            // btnCrearIdioma
            // 
            this.btnCrearIdioma.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCrearIdioma.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnCrearIdioma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearIdioma.Font = new System.Drawing.Font("Arial Narrow", 11F, System.Drawing.FontStyle.Bold);
            this.btnCrearIdioma.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCrearIdioma.Location = new System.Drawing.Point(50, 78);
            this.btnCrearIdioma.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCrearIdioma.Name = "btnCrearIdioma";
            this.btnCrearIdioma.Size = new System.Drawing.Size(149, 41);
            this.btnCrearIdioma.TabIndex = 6;
            this.btnCrearIdioma.Tag = "crear_idioma";
            this.btnCrearIdioma.Text = "Crear Idioma";
            this.btnCrearIdioma.UseVisualStyleBackColor = false;
            this.btnCrearIdioma.Click += new System.EventHandler(this.btnCrearIdioma_Click_1);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel1.Controls.Add(this.lblTituloCrearIdioma);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(512, 46);
            this.panel1.TabIndex = 10;
            // 
            // lblTituloCrearIdioma
            // 
            this.lblTituloCrearIdioma.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblTituloCrearIdioma.AutoSize = true;
            this.lblTituloCrearIdioma.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloCrearIdioma.ForeColor = System.Drawing.Color.White;
            this.lblTituloCrearIdioma.Location = new System.Drawing.Point(348, 11);
            this.lblTituloCrearIdioma.Name = "lblTituloCrearIdioma";
            this.lblTituloCrearIdioma.Size = new System.Drawing.Size(139, 23);
            this.lblTituloCrearIdioma.TabIndex = 5;
            this.lblTituloCrearIdioma.Tag = "crear_idioma";
            this.lblTituloCrearIdioma.Text = "Crear Idioma";
            // 
            // frmCrearIdioma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(512, 688);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCrearIdioma);
            this.Controls.Add(this.txtCrearIdioma);
            this.Controls.Add(this.lblNombreIdioma);
            this.Controls.Add(this.dgvIdioma);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmCrearIdioma";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Crear Idioma";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCrearIdioma_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIdioma)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvIdioma;
        private System.Windows.Forms.Label lblNombreIdioma;
        private System.Windows.Forms.TextBox txtCrearIdioma;
        private Microsoft.VisualBasic.PowerPacks.Printing.PrintForm printForm1;
        private System.Windows.Forms.Button btnCrearIdioma;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTituloCrearIdioma;
    }
}