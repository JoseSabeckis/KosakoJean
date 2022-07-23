
namespace Presentacion.Core.Producto_Dato
{
    partial class EstadoProducto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EstadoProducto));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvGrilla = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnTerminado = new System.Windows.Forms.Button();
            this.btnEnEspera = new System.Windows.Forms.Button();
            this.btnCancelado = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblColegio = new System.Windows.Forms.Label();
            this.lblTalle = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(556, 304);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.dgvGrilla);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 73);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(554, 229);
            this.panel3.TabIndex = 1;
            // 
            // dgvGrilla
            // 
            this.dgvGrilla.AllowUserToAddRows = false;
            this.dgvGrilla.AllowUserToDeleteRows = false;
            this.dgvGrilla.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dgvGrilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrilla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGrilla.Location = new System.Drawing.Point(0, 48);
            this.dgvGrilla.Margin = new System.Windows.Forms.Padding(4);
            this.dgvGrilla.MultiSelect = false;
            this.dgvGrilla.Name = "dgvGrilla";
            this.dgvGrilla.ReadOnly = true;
            this.dgvGrilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGrilla.Size = new System.Drawing.Size(552, 179);
            this.dgvGrilla.TabIndex = 12;
            this.dgvGrilla.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGrilla_RowEnter);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.btnTerminado);
            this.panel4.Controls.Add(this.btnEnEspera);
            this.panel4.Controls.Add(this.btnCancelado);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(552, 48);
            this.panel4.TabIndex = 0;
            // 
            // btnTerminado
            // 
            this.btnTerminado.BackColor = System.Drawing.Color.Aqua;
            this.btnTerminado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTerminado.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTerminado.Location = new System.Drawing.Point(175, 0);
            this.btnTerminado.Name = "btnTerminado";
            this.btnTerminado.Size = new System.Drawing.Size(207, 46);
            this.btnTerminado.TabIndex = 2;
            this.btnTerminado.Text = "Terminado";
            this.btnTerminado.UseVisualStyleBackColor = false;
            this.btnTerminado.Click += new System.EventHandler(this.btnTerminado_Click);
            // 
            // btnEnEspera
            // 
            this.btnEnEspera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnEnEspera.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnEnEspera.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEnEspera.Location = new System.Drawing.Point(0, 0);
            this.btnEnEspera.Name = "btnEnEspera";
            this.btnEnEspera.Size = new System.Drawing.Size(175, 46);
            this.btnEnEspera.TabIndex = 1;
            this.btnEnEspera.Text = "En Espera";
            this.btnEnEspera.UseVisualStyleBackColor = false;
            this.btnEnEspera.Click += new System.EventHandler(this.btnEnEspera_Click);
            // 
            // btnCancelado
            // 
            this.btnCancelado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnCancelado.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancelado.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelado.Location = new System.Drawing.Point(382, 0);
            this.btnCancelado.Name = "btnCancelado";
            this.btnCancelado.Size = new System.Drawing.Size(168, 46);
            this.btnCancelado.TabIndex = 3;
            this.btnCancelado.Text = "Cancelar";
            this.btnCancelado.UseVisualStyleBackColor = false;
            this.btnCancelado.Click += new System.EventHandler(this.btnCancelado_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblColegio);
            this.panel2.Controls.Add(this.lblTalle);
            this.panel2.Controls.Add(this.lblNombre);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(554, 73);
            this.panel2.TabIndex = 0;
            // 
            // lblColegio
            // 
            this.lblColegio.AutoSize = true;
            this.lblColegio.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColegio.ForeColor = System.Drawing.Color.Red;
            this.lblColegio.Location = new System.Drawing.Point(2, 45);
            this.lblColegio.Name = "lblColegio";
            this.lblColegio.Size = new System.Drawing.Size(85, 26);
            this.lblColegio.TabIndex = 3;
            this.lblColegio.Text = "Colegio";
            // 
            // lblTalle
            // 
            this.lblTalle.AutoSize = true;
            this.lblTalle.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTalle.ForeColor = System.Drawing.Color.Blue;
            this.lblTalle.Location = new System.Drawing.Point(2, 23);
            this.lblTalle.Name = "lblTalle";
            this.lblTalle.Size = new System.Drawing.Size(63, 26);
            this.lblTalle.TabIndex = 2;
            this.lblTalle.Text = "Talle:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(2, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(91, 26);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(439, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 71);
            this.button1.TabIndex = 0;
            this.button1.Text = "Volver";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // EstadoProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(580, 328);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(596, 367);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(596, 367);
            this.Name = "EstadoProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Estado";
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancelado;
        private System.Windows.Forms.Button btnTerminado;
        private System.Windows.Forms.Button btnEnEspera;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTalle;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        protected System.Windows.Forms.DataGridView dgvGrilla;
        private System.Windows.Forms.Label lblColegio;
    }
}