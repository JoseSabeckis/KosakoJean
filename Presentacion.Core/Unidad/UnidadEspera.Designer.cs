
namespace Presentacion.Core.Unidad
{
    partial class UnidadEspera
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblIdPedido = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.btnVista = new System.Windows.Forms.Button();
            this.txtProductos = new System.Windows.Forms.TextBox();
            this.lblFechaHastaRetiro = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lblFecha);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(185, 23);
            this.panel1.TabIndex = 11;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.Color.Red;
            this.lblFecha.Location = new System.Drawing.Point(1, 0);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(69, 24);
            this.lblFecha.TabIndex = 2;
            this.lblFecha.Text = "Fecha";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.BackColor = System.Drawing.SystemColors.GrayText;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.White;
            this.lblNombre.Location = new System.Drawing.Point(2, 26);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(93, 25);
            this.lblNombre.TabIndex = 12;
            this.lblNombre.Text = "Nombre";
            // 
            // lblIdPedido
            // 
            this.lblIdPedido.AutoSize = true;
            this.lblIdPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdPedido.Location = new System.Drawing.Point(166, 140);
            this.lblIdPedido.Name = "lblIdPedido";
            this.lblIdPedido.Size = new System.Drawing.Size(16, 24);
            this.lblIdPedido.TabIndex = 15;
            this.lblIdPedido.Text = ".";
            this.lblIdPedido.Visible = false;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblId.Location = new System.Drawing.Point(3, 140);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(16, 24);
            this.lblId.TabIndex = 14;
            this.lblId.Text = ".";
            this.lblId.Visible = false;
            // 
            // btnVista
            // 
            this.btnVista.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVista.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVista.Location = new System.Drawing.Point(28, 101);
            this.btnVista.Name = "btnVista";
            this.btnVista.Size = new System.Drawing.Size(99, 29);
            this.btnVista.TabIndex = 16;
            this.btnVista.Text = "Vista";
            this.btnVista.UseVisualStyleBackColor = true;
            this.btnVista.Click += new System.EventHandler(this.btnVista_Click);
            // 
            // txtProductos
            // 
            this.txtProductos.BackColor = System.Drawing.SystemColors.Info;
            this.txtProductos.Enabled = false;
            this.txtProductos.Location = new System.Drawing.Point(3, 54);
            this.txtProductos.Multiline = true;
            this.txtProductos.Name = "txtProductos";
            this.txtProductos.Size = new System.Drawing.Size(157, 30);
            this.txtProductos.TabIndex = 17;
            // 
            // lblFechaHastaRetiro
            // 
            this.lblFechaHastaRetiro.AutoSize = true;
            this.lblFechaHastaRetiro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaHastaRetiro.ForeColor = System.Drawing.Color.Black;
            this.lblFechaHastaRetiro.Location = new System.Drawing.Point(0, 87);
            this.lblFechaHastaRetiro.Name = "lblFechaHastaRetiro";
            this.lblFechaHastaRetiro.Size = new System.Drawing.Size(11, 13);
            this.lblFechaHastaRetiro.TabIndex = 18;
            this.lblFechaHastaRetiro.Text = "-";
            // 
            // UnidadEspera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Controls.Add(this.lblFechaHastaRetiro);
            this.Controls.Add(this.txtProductos);
            this.Controls.Add(this.btnVista);
            this.Controls.Add(this.lblIdPedido);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.panel1);
            this.Name = "UnidadEspera";
            this.Size = new System.Drawing.Size(185, 164);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblIdPedido;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Button btnVista;
        private System.Windows.Forms.TextBox txtProductos;
        private System.Windows.Forms.Label lblFechaHastaRetiro;
    }
}
