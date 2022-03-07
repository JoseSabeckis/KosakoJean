namespace Presentacion.Core.Unidad
{
    partial class UnidadRetiro
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
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.btnVista = new System.Windows.Forms.Button();
            this.lblIdPedido = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtProductos = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.BackColor = System.Drawing.SystemColors.GrayText;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.White;
            this.lblNombre.Location = new System.Drawing.Point(3, 47);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(93, 25);
            this.lblNombre.TabIndex = 3;
            this.lblNombre.Text = "Nombre";
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
            // btnVista
            // 
            this.btnVista.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVista.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVista.Location = new System.Drawing.Point(65, 153);
            this.btnVista.Name = "btnVista";
            this.btnVista.Size = new System.Drawing.Size(85, 38);
            this.btnVista.TabIndex = 8;
            this.btnVista.Text = "Vista";
            this.btnVista.UseVisualStyleBackColor = true;
            this.btnVista.Click += new System.EventHandler(this.btnVista_Click);
            // 
            // lblIdPedido
            // 
            this.lblIdPedido.AutoSize = true;
            this.lblIdPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdPedido.Location = new System.Drawing.Point(156, 182);
            this.lblIdPedido.Name = "lblIdPedido";
            this.lblIdPedido.Size = new System.Drawing.Size(16, 24);
            this.lblIdPedido.TabIndex = 9;
            this.lblIdPedido.Text = ".";
            this.lblIdPedido.Visible = false;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblId.Location = new System.Drawing.Point(0, 177);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(16, 24);
            this.lblId.TabIndex = 7;
            this.lblId.Text = ".";
            this.lblId.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lblFecha);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(233, 35);
            this.panel1.TabIndex = 10;
            // 
            // txtProductos
            // 
            this.txtProductos.BackColor = System.Drawing.SystemColors.Info;
            this.txtProductos.Enabled = false;
            this.txtProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductos.Location = new System.Drawing.Point(3, 96);
            this.txtProductos.Multiline = true;
            this.txtProductos.Name = "txtProductos";
            this.txtProductos.Size = new System.Drawing.Size(223, 42);
            this.txtProductos.TabIndex = 11;
            // 
            // UnidadRetiro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.txtProductos);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnVista);
            this.Controls.Add(this.lblIdPedido);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.lblNombre);
            this.Name = "UnidadRetiro";
            this.Size = new System.Drawing.Size(233, 204);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Button btnVista;
        private System.Windows.Forms.Label lblIdPedido;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtProductos;
    }
}
