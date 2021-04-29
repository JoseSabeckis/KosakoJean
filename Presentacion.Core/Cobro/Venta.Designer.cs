namespace Presentacion.Core.Cobro
{
    partial class Venta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Venta));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbTalle = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.nudPrecio = new System.Windows.Forms.NumericUpDown();
            this.btnAgregarAlaGrilla = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSeleccionProducto = new System.Windows.Forms.Button();
            this.txtProducto = new System.Windows.Forms.TextBox();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnCobrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvGrilla = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.nudPagaron = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.txtVuelto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPagaron)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.cmbTalle);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.nudPrecio);
            this.panel1.Controls.Add(this.btnAgregarAlaGrilla);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnSeleccionProducto);
            this.panel1.Controls.Add(this.txtProducto);
            this.panel1.Controls.Add(this.nudCantidad);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1017, 161);
            this.panel1.TabIndex = 0;
            // 
            // cmbTalle
            // 
            this.cmbTalle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTalle.FormattingEnabled = true;
            this.cmbTalle.Items.AddRange(new object[] {
            "16",
            "L",
            "M",
            "XL",
            "XXL",
            "XXXL"});
            this.cmbTalle.Location = new System.Drawing.Point(799, 105);
            this.cmbTalle.Name = "cmbTalle";
            this.cmbTalle.Size = new System.Drawing.Size(48, 30);
            this.cmbTalle.TabIndex = 13;
            this.cmbTalle.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(745, 107);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 22);
            this.label8.TabIndex = 12;
            this.label8.Text = "Talle";
            // 
            // nudPrecio
            // 
            this.nudPrecio.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.nudPrecio.Enabled = false;
            this.nudPrecio.Location = new System.Drawing.Point(632, 105);
            this.nudPrecio.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nudPrecio.Name = "nudPrecio";
            this.nudPrecio.Size = new System.Drawing.Size(109, 29);
            this.nudPrecio.TabIndex = 11;
            // 
            // btnAgregarAlaGrilla
            // 
            this.btnAgregarAlaGrilla.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnAgregarAlaGrilla.Location = new System.Drawing.Point(868, 102);
            this.btnAgregarAlaGrilla.Name = "btnAgregarAlaGrilla";
            this.btnAgregarAlaGrilla.Size = new System.Drawing.Size(135, 33);
            this.btnAgregarAlaGrilla.TabIndex = 10;
            this.btnAgregarAlaGrilla.Text = "Agregar";
            this.btnAgregarAlaGrilla.UseVisualStyleBackColor = false;
            this.btnAgregarAlaGrilla.Click += new System.EventHandler(this.btnAgregarAlaGrilla_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(565, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 22);
            this.label4.TabIndex = 8;
            this.label4.Text = "Precio";
            // 
            // btnSeleccionProducto
            // 
            this.btnSeleccionProducto.Location = new System.Drawing.Point(372, 103);
            this.btnSeleccionProducto.Name = "btnSeleccionProducto";
            this.btnSeleccionProducto.Size = new System.Drawing.Size(71, 32);
            this.btnSeleccionProducto.TabIndex = 7;
            this.btnSeleccionProducto.Text = "---";
            this.btnSeleccionProducto.UseVisualStyleBackColor = true;
            this.btnSeleccionProducto.Click += new System.EventHandler(this.btnSeleccionProducto_Click);
            // 
            // txtProducto
            // 
            this.txtProducto.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtProducto.Enabled = false;
            this.txtProducto.Location = new System.Drawing.Point(95, 105);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new System.Drawing.Size(271, 29);
            this.txtProducto.TabIndex = 6;
            // 
            // nudCantidad
            // 
            this.nudCantidad.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.nudCantidad.Location = new System.Drawing.Point(508, 105);
            this.nudCantidad.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudCantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(46, 29);
            this.nudCantidad.TabIndex = 5;
            this.nudCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCantidad.ValueChanged += new System.EventHandler(this.nudCantidad_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(450, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 22);
            this.label3.TabIndex = 4;
            this.label3.Text = "Cant.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "Producto";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.btnEliminar);
            this.panel3.Controls.Add(this.btnLimpiar);
            this.panel3.Controls.Add(this.btnCobrar);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.btnVolver);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1013, 76);
            this.panel3.TabIndex = 2;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnEliminar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnEliminar.Location = new System.Drawing.Point(236, 0);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(115, 72);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnLimpiar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnLimpiar.Location = new System.Drawing.Point(121, 0);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(115, 72);
            this.btnLimpiar.TabIndex = 3;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnCobrar
            // 
            this.btnCobrar.BackColor = System.Drawing.Color.Lime;
            this.btnCobrar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCobrar.Location = new System.Drawing.Point(0, 0);
            this.btnCobrar.Name = "btnCobrar";
            this.btnCobrar.Size = new System.Drawing.Size(121, 72);
            this.btnCobrar.TabIndex = 2;
            this.btnCobrar.Text = "Cobrar";
            this.btnCobrar.UseVisualStyleBackColor = false;
            this.btnCobrar.Click += new System.EventHandler(this.btnCobrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(438, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Venta";
            // 
            // btnVolver
            // 
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Location = new System.Drawing.Point(866, 10);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(135, 42);
            this.btnVolver.TabIndex = 0;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.dgvGrilla);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 161);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1017, 364);
            this.panel2.TabIndex = 1;
            // 
            // dgvGrilla
            // 
            this.dgvGrilla.AllowUserToAddRows = false;
            this.dgvGrilla.AllowUserToDeleteRows = false;
            this.dgvGrilla.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dgvGrilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrilla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGrilla.Location = new System.Drawing.Point(0, 0);
            this.dgvGrilla.Margin = new System.Windows.Forms.Padding(4);
            this.dgvGrilla.MultiSelect = false;
            this.dgvGrilla.Name = "dgvGrilla";
            this.dgvGrilla.ReadOnly = true;
            this.dgvGrilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGrilla.Size = new System.Drawing.Size(1013, 279);
            this.dgvGrilla.TabIndex = 11;
            this.dgvGrilla.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGrilla_RowEnter);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.btnCalcular);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.nudPagaron);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.txtVuelto);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 279);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1013, 81);
            this.panel4.TabIndex = 0;
            // 
            // btnCalcular
            // 
            this.btnCalcular.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnCalcular.Location = new System.Drawing.Point(549, 24);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(88, 34);
            this.btnCalcular.TabIndex = 7;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = false;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.txtTotal);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(773, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(236, 77);
            this.panel5.TabIndex = 6;
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtTotal.Enabled = false;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(91, 22);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(135, 33);
            this.txtTotal.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 22);
            this.label7.TabIndex = 4;
            this.label7.Text = "TOTAL";
            // 
            // nudPagaron
            // 
            this.nudPagaron.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudPagaron.Location = new System.Drawing.Point(174, 28);
            this.nudPagaron.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudPagaron.Name = "nudPagaron";
            this.nudPagaron.Size = new System.Drawing.Size(120, 29);
            this.nudPagaron.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(328, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 22);
            this.label6.TabIndex = 2;
            this.label6.Text = "Vuelto";
            // 
            // txtVuelto
            // 
            this.txtVuelto.Enabled = false;
            this.txtVuelto.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVuelto.Location = new System.Drawing.Point(397, 25);
            this.txtVuelto.Name = "txtVuelto";
            this.txtVuelto.Size = new System.Drawing.Size(115, 33);
            this.txtVuelto.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 22);
            this.label5.TabIndex = 0;
            this.label5.Text = "Cuanto Pagaron";
            // 
            // Venta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1017, 525);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MinimizeBox = false;
            this.Name = "Venta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Aplicacion de Venta";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPagaron)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSeleccionProducto;
        private System.Windows.Forms.TextBox txtProducto;
        private System.Windows.Forms.Button btnAgregarAlaGrilla;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudPagaron;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtVuelto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnCobrar;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.NumericUpDown nudPrecio;
        private System.Windows.Forms.ComboBox cmbTalle;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnCalcular;
        protected System.Windows.Forms.DataGridView dgvGrilla;
    }
}