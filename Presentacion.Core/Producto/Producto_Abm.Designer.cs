namespace Presentacion.Core.Producto
{
    partial class Producto_Abm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtExtras = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nudPrecio = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbColegio = new System.Windows.Forms.ComboBox();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblCodBarraVerdadero = new System.Windows.Forms.Label();
            this.btnNuevoTipo = new System.Windows.Forms.Button();
            this.btnNuevoColegio = new System.Windows.Forms.Button();
            this.nudCodBarraCreado = new System.Windows.Forms.NumericUpDown();
            this.ckbCodBarraCreado = new System.Windows.Forms.CheckBox();
            this.btnVerCodBarra = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.nudCodigoBarra = new System.Windows.Forms.NumericUpDown();
            this.imgCodigoBarras = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ckbFabricacion = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.nudStock = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlFoto = new System.Windows.Forms.Panel();
            this.btnAgregarImagen = new System.Windows.Forms.Button();
            this.lblTituloFoto = new System.Windows.Forms.Label();
            this.imgFotoEmpleado = new System.Windows.Forms.PictureBox();
            this.archivo = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecio)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCodBarraCreado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCodigoBarra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCodigoBarras)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStock)).BeginInit();
            this.pnlFoto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgFotoEmpleado)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Size = new System.Drawing.Size(1032, 411);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(85, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Descripcion";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BackColor = System.Drawing.SystemColors.Info;
            this.txtDescripcion.Location = new System.Drawing.Point(213, 76);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(254, 33);
            this.txtDescripcion.TabIndex = 1;
            this.txtDescripcion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescripcion_KeyPress);
            // 
            // txtExtras
            // 
            this.txtExtras.BackColor = System.Drawing.SystemColors.Info;
            this.txtExtras.Location = new System.Drawing.Point(213, 125);
            this.txtExtras.Name = "txtExtras";
            this.txtExtras.Size = new System.Drawing.Size(254, 33);
            this.txtExtras.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(80, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Extra de Info";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Precio";
            // 
            // nudPrecio
            // 
            this.nudPrecio.BackColor = System.Drawing.SystemColors.Info;
            this.nudPrecio.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudPrecio.Location = new System.Drawing.Point(87, 10);
            this.nudPrecio.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudPrecio.Name = "nudPrecio";
            this.nudPrecio.Size = new System.Drawing.Size(134, 33);
            this.nudPrecio.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(91, 275);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Colegio";
            // 
            // cmbColegio
            // 
            this.cmbColegio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColegio.FormattingEnabled = true;
            this.cmbColegio.Location = new System.Drawing.Point(182, 272);
            this.cmbColegio.Name = "cmbColegio";
            this.cmbColegio.Size = new System.Drawing.Size(254, 33);
            this.cmbColegio.TabIndex = 5;
            // 
            // cmbTipo
            // 
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(182, 322);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(254, 33);
            this.cmbTipo.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(121, 325);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "Tipo";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.lblCodBarraVerdadero);
            this.panel2.Controls.Add(this.btnNuevoTipo);
            this.panel2.Controls.Add(this.btnNuevoColegio);
            this.panel2.Controls.Add(this.nudCodBarraCreado);
            this.panel2.Controls.Add(this.ckbCodBarraCreado);
            this.panel2.Controls.Add(this.btnVerCodBarra);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.nudCodigoBarra);
            this.panel2.Controls.Add(this.imgCodigoBarras);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.ckbFabricacion);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.pnlFoto);
            this.panel2.Controls.Add(this.txtDescripcion);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cmbTipo);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cmbColegio);
            this.panel2.Controls.Add(this.txtExtras);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(24, 18);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(994, 379);
            this.panel2.TabIndex = 10;
            // 
            // lblCodBarraVerdadero
            // 
            this.lblCodBarraVerdadero.AutoSize = true;
            this.lblCodBarraVerdadero.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblCodBarraVerdadero.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodBarraVerdadero.Location = new System.Drawing.Point(501, 12);
            this.lblCodBarraVerdadero.Name = "lblCodBarraVerdadero";
            this.lblCodBarraVerdadero.Size = new System.Drawing.Size(30, 19);
            this.lblCodBarraVerdadero.TabIndex = 78;
            this.lblCodBarraVerdadero.Text = "---";
            // 
            // btnNuevoTipo
            // 
            this.btnNuevoTipo.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoTipo.Location = new System.Drawing.Point(442, 321);
            this.btnNuevoTipo.Name = "btnNuevoTipo";
            this.btnNuevoTipo.Size = new System.Drawing.Size(36, 33);
            this.btnNuevoTipo.TabIndex = 13;
            this.btnNuevoTipo.Text = "...";
            this.btnNuevoTipo.UseVisualStyleBackColor = true;
            this.btnNuevoTipo.Click += new System.EventHandler(this.btnNuevoTipo_Click);
            // 
            // btnNuevoColegio
            // 
            this.btnNuevoColegio.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoColegio.Location = new System.Drawing.Point(442, 272);
            this.btnNuevoColegio.Name = "btnNuevoColegio";
            this.btnNuevoColegio.Size = new System.Drawing.Size(36, 33);
            this.btnNuevoColegio.TabIndex = 12;
            this.btnNuevoColegio.Text = "...";
            this.btnNuevoColegio.UseVisualStyleBackColor = true;
            this.btnNuevoColegio.Click += new System.EventHandler(this.btnNuevoColegio_Click);
            // 
            // nudCodBarraCreado
            // 
            this.nudCodBarraCreado.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.nudCodBarraCreado.Enabled = false;
            this.nudCodBarraCreado.Location = new System.Drawing.Point(778, 308);
            this.nudCodBarraCreado.Maximum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            0});
            this.nudCodBarraCreado.Minimum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.nudCodBarraCreado.Name = "nudCodBarraCreado";
            this.nudCodBarraCreado.Size = new System.Drawing.Size(171, 33);
            this.nudCodBarraCreado.TabIndex = 9;
            this.nudCodBarraCreado.Value = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.nudCodBarraCreado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudCodBarraCreado_KeyPress);
            // 
            // ckbCodBarraCreado
            // 
            this.ckbCodBarraCreado.AutoSize = true;
            this.ckbCodBarraCreado.Location = new System.Drawing.Point(731, 273);
            this.ckbCodBarraCreado.Name = "ckbCodBarraCreado";
            this.ckbCodBarraCreado.Size = new System.Drawing.Size(241, 29);
            this.ckbCodBarraCreado.TabIndex = 8;
            this.ckbCodBarraCreado.Text = "Usar Cod Barra Creado";
            this.ckbCodBarraCreado.UseVisualStyleBackColor = true;
            this.ckbCodBarraCreado.CheckedChanged += new System.EventHandler(this.ckbCodBarraCreado_CheckedChanged);
            // 
            // btnVerCodBarra
            // 
            this.btnVerCodBarra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnVerCodBarra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerCodBarra.Location = new System.Drawing.Point(731, 215);
            this.btnVerCodBarra.Name = "btnVerCodBarra";
            this.btnVerCodBarra.Size = new System.Drawing.Size(242, 42);
            this.btnVerCodBarra.TabIndex = 10;
            this.btnVerCodBarra.Text = "Ver Codigo Barra";
            this.btnVerCodBarra.UseVisualStyleBackColor = false;
            this.btnVerCodBarra.Click += new System.EventHandler(this.btnVerCodBarra_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(67, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(349, 16);
            this.label9.TabIndex = 77;
            this.label9.Text = "Seleccionando El Codigo Presionar Enter Para Ver El Codigo Barra";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.label8.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(726, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(138, 26);
            this.label8.TabIndex = 76;
            this.label8.Text = "Codigo Barra";
            // 
            // nudCodigoBarra
            // 
            this.nudCodigoBarra.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.nudCodigoBarra.Location = new System.Drawing.Point(277, 31);
            this.nudCodigoBarra.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.nudCodigoBarra.Minimum = new decimal(new int[] {
            -1943132160,
            209,
            0,
            0});
            this.nudCodigoBarra.Name = "nudCodigoBarra";
            this.nudCodigoBarra.Size = new System.Drawing.Size(159, 33);
            this.nudCodigoBarra.TabIndex = 0;
            this.nudCodigoBarra.Value = new decimal(new int[] {
            -1943132160,
            209,
            0,
            0});
            this.nudCodigoBarra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudCodigoBarra_KeyPress);
            // 
            // imgCodigoBarras
            // 
            this.imgCodigoBarras.BackColor = System.Drawing.Color.White;
            this.imgCodigoBarras.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imgCodigoBarras.Image = global::Presentacion.Core.Properties.Resources._4_tipos_clientes;
            this.imgCodigoBarras.Location = new System.Drawing.Point(731, 76);
            this.imgCodigoBarras.Name = "imgCodigoBarras";
            this.imgCodigoBarras.Size = new System.Drawing.Size(242, 133);
            this.imgCodigoBarras.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgCodigoBarras.TabIndex = 74;
            this.imgCodigoBarras.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(65, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(206, 26);
            this.label7.TabIndex = 73;
            this.label7.Text = "Nuevo Codigo Barra";
            // 
            // ckbFabricacion
            // 
            this.ckbFabricacion.AutoSize = true;
            this.ckbFabricacion.Location = new System.Drawing.Point(500, 45);
            this.ckbFabricacion.Name = "ckbFabricacion";
            this.ckbFabricacion.Size = new System.Drawing.Size(151, 29);
            this.ckbFabricacion.TabIndex = 11;
            this.ckbFabricacion.Text = "Para Fabricar";
            this.ckbFabricacion.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.nudStock);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.nudPrecio);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(127, 164);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(340, 93);
            this.panel3.TabIndex = 4;
            // 
            // nudStock
            // 
            this.nudStock.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.nudStock.Location = new System.Drawing.Point(87, 49);
            this.nudStock.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nudStock.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.nudStock.Name = "nudStock";
            this.nudStock.Size = new System.Drawing.Size(66, 33);
            this.nudStock.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 25);
            this.label6.TabIndex = 72;
            this.label6.Text = "Stock";
            // 
            // pnlFoto
            // 
            this.pnlFoto.BackColor = System.Drawing.Color.Silver;
            this.pnlFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFoto.Controls.Add(this.btnAgregarImagen);
            this.pnlFoto.Controls.Add(this.lblTituloFoto);
            this.pnlFoto.Controls.Add(this.imgFotoEmpleado);
            this.pnlFoto.Location = new System.Drawing.Point(500, 76);
            this.pnlFoto.Name = "pnlFoto";
            this.pnlFoto.Size = new System.Drawing.Size(201, 239);
            this.pnlFoto.TabIndex = 10;
            // 
            // btnAgregarImagen
            // 
            this.btnAgregarImagen.BackColor = System.Drawing.Color.Gray;
            this.btnAgregarImagen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgregarImagen.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAgregarImagen.Location = new System.Drawing.Point(8, 185);
            this.btnAgregarImagen.Name = "btnAgregarImagen";
            this.btnAgregarImagen.Size = new System.Drawing.Size(183, 49);
            this.btnAgregarImagen.TabIndex = 7;
            this.btnAgregarImagen.Text = "Agregar";
            this.btnAgregarImagen.UseVisualStyleBackColor = false;
            this.btnAgregarImagen.Click += new System.EventHandler(this.btnAgregarImagen_Click);
            // 
            // lblTituloFoto
            // 
            this.lblTituloFoto.BackColor = System.Drawing.Color.CadetBlue;
            this.lblTituloFoto.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloFoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloFoto.ForeColor = System.Drawing.Color.Black;
            this.lblTituloFoto.Location = new System.Drawing.Point(0, 0);
            this.lblTituloFoto.Name = "lblTituloFoto";
            this.lblTituloFoto.Size = new System.Drawing.Size(199, 31);
            this.lblTituloFoto.TabIndex = 57;
            this.lblTituloFoto.Text = "Foto";
            this.lblTituloFoto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imgFotoEmpleado
            // 
            this.imgFotoEmpleado.BackColor = System.Drawing.Color.White;
            this.imgFotoEmpleado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imgFotoEmpleado.Image = global::Presentacion.Core.Properties.Resources.iPhoto_photo_picture_camera_2661;
            this.imgFotoEmpleado.Location = new System.Drawing.Point(8, 38);
            this.imgFotoEmpleado.Name = "imgFotoEmpleado";
            this.imgFotoEmpleado.Size = new System.Drawing.Size(183, 141);
            this.imgFotoEmpleado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgFotoEmpleado.TabIndex = 0;
            this.imgFotoEmpleado.TabStop = false;
            // 
            // archivo
            // 
            this.archivo.FileName = "archivo";
            // 
            // Producto_Abm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 450);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1048, 489);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1048, 489);
            this.Name = "Producto_Abm";
            this.Text = "Producto_Abm";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecio)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCodBarraCreado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCodigoBarra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCodigoBarras)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStock)).EndInit();
            this.pnlFoto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgFotoEmpleado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.ComboBox cmbColegio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudPrecio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtExtras;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlFoto;
        private System.Windows.Forms.Button btnAgregarImagen;
        private System.Windows.Forms.Label lblTituloFoto;
        private System.Windows.Forms.PictureBox imgFotoEmpleado;
        private System.Windows.Forms.OpenFileDialog archivo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudStock;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox ckbFabricacion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox imgCodigoBarras;
        private System.Windows.Forms.NumericUpDown nudCodigoBarra;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnVerCodBarra;
        private System.Windows.Forms.CheckBox ckbCodBarraCreado;
        private System.Windows.Forms.NumericUpDown nudCodBarraCreado;
        private System.Windows.Forms.Button btnNuevoTipo;
        private System.Windows.Forms.Button btnNuevoColegio;
        private System.Windows.Forms.Label lblCodBarraVerdadero;
    }
}