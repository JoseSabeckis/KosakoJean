﻿namespace Presentacion.Core.Producto
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
            this.pnlFoto = new System.Windows.Forms.Panel();
            this.btnAgregarImagen = new System.Windows.Forms.Button();
            this.lblTituloFoto = new System.Windows.Forms.Label();
            this.imgFotoEmpleado = new System.Windows.Forms.PictureBox();
            this.archivo = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecio)).BeginInit();
            this.panel2.SuspendLayout();
            this.pnlFoto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgFotoEmpleado)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Size = new System.Drawing.Size(800, 411);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Descripcion";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(198, 43);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(254, 33);
            this.txtDescripcion.TabIndex = 1;
            this.txtDescripcion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescripcion_KeyPress);
            // 
            // txtExtras
            // 
            this.txtExtras.Location = new System.Drawing.Point(198, 96);
            this.txtExtras.Name = "txtExtras";
            this.txtExtras.Size = new System.Drawing.Size(254, 33);
            this.txtExtras.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(123, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Extras";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(123, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Precio";
            // 
            // nudPrecio
            // 
            this.nudPrecio.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudPrecio.Location = new System.Drawing.Point(198, 147);
            this.nudPrecio.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudPrecio.Name = "nudPrecio";
            this.nudPrecio.Size = new System.Drawing.Size(134, 33);
            this.nudPrecio.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(107, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Colegio";
            // 
            // cmbColegio
            // 
            this.cmbColegio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColegio.FormattingEnabled = true;
            this.cmbColegio.Location = new System.Drawing.Point(198, 205);
            this.cmbColegio.Name = "cmbColegio";
            this.cmbColegio.Size = new System.Drawing.Size(254, 33);
            this.cmbColegio.TabIndex = 7;
            // 
            // cmbTipo
            // 
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(198, 262);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(254, 33);
            this.cmbTipo.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(137, 265);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "Tipo";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.pnlFoto);
            this.panel2.Controls.Add(this.txtDescripcion);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cmbTipo);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cmbColegio);
            this.panel2.Controls.Add(this.txtExtras);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.nudPrecio);
            this.panel2.Location = new System.Drawing.Point(24, 22);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(762, 359);
            this.panel2.TabIndex = 10;
            // 
            // pnlFoto
            // 
            this.pnlFoto.BackColor = System.Drawing.Color.Silver;
            this.pnlFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFoto.Controls.Add(this.btnAgregarImagen);
            this.pnlFoto.Controls.Add(this.lblTituloFoto);
            this.pnlFoto.Controls.Add(this.imgFotoEmpleado);
            this.pnlFoto.Location = new System.Drawing.Point(527, 46);
            this.pnlFoto.Name = "pnlFoto";
            this.pnlFoto.Size = new System.Drawing.Size(193, 250);
            this.pnlFoto.TabIndex = 71;
            // 
            // btnAgregarImagen
            // 
            this.btnAgregarImagen.BackColor = System.Drawing.Color.Gray;
            this.btnAgregarImagen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgregarImagen.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAgregarImagen.Location = new System.Drawing.Point(8, 204);
            this.btnAgregarImagen.Name = "btnAgregarImagen";
            this.btnAgregarImagen.Size = new System.Drawing.Size(176, 38);
            this.btnAgregarImagen.TabIndex = 0;
            this.btnAgregarImagen.Text = "Agregar Imagen";
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
            this.lblTituloFoto.Size = new System.Drawing.Size(191, 31);
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
            this.imgFotoEmpleado.Size = new System.Drawing.Size(176, 158);
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
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(816, 489);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "Producto_Abm";
            this.Text = "Producto_Abm";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecio)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
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
    }
}