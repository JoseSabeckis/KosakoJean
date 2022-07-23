
namespace Presentacion.Core.Cliente
{
    partial class Cliente_Abm
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ckbPrincipal = new System.Windows.Forms.CheckBox();
            this.pnlFoto = new System.Windows.Forms.Panel();
            this.btnAgregarImagen = new System.Windows.Forms.Button();
            this.lblTituloFoto = new System.Windows.Forms.Label();
            this.imgFotoEmpleado = new System.Windows.Forms.PictureBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            this.panel2.SuspendLayout();
            this.pnlFoto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgFotoEmpleado)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Size = new System.Drawing.Size(661, 279);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.txtDni);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.ckbPrincipal);
            this.panel2.Controls.Add(this.pnlFoto);
            this.panel2.Controls.Add(this.txtDireccion);
            this.panel2.Controls.Add(this.txtTelefono);
            this.panel2.Controls.Add(this.txtNombre);
            this.panel2.Controls.Add(this.txtApellido);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(27, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(620, 262);
            this.panel2.TabIndex = 0;
            // 
            // txtDni
            // 
            this.txtDni.BackColor = System.Drawing.SystemColors.Info;
            this.txtDni.Location = new System.Drawing.Point(127, 114);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(133, 33);
            this.txtDni.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Cursor = System.Windows.Forms.Cursors.Default;
            this.label5.Location = new System.Drawing.Point(22, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 25);
            this.label5.TabIndex = 74;
            this.label5.Text = "Dni:";
            // 
            // ckbPrincipal
            // 
            this.ckbPrincipal.AutoSize = true;
            this.ckbPrincipal.Location = new System.Drawing.Point(445, 3);
            this.ckbPrincipal.Name = "ckbPrincipal";
            this.ckbPrincipal.Size = new System.Drawing.Size(110, 29);
            this.ckbPrincipal.TabIndex = 73;
            this.ckbPrincipal.Text = "Principal";
            this.ckbPrincipal.UseVisualStyleBackColor = true;
            // 
            // pnlFoto
            // 
            this.pnlFoto.BackColor = System.Drawing.Color.Silver;
            this.pnlFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFoto.Controls.Add(this.btnAgregarImagen);
            this.pnlFoto.Controls.Add(this.lblTituloFoto);
            this.pnlFoto.Controls.Add(this.imgFotoEmpleado);
            this.pnlFoto.Location = new System.Drawing.Point(422, 34);
            this.pnlFoto.Name = "pnlFoto";
            this.pnlFoto.Size = new System.Drawing.Size(159, 206);
            this.pnlFoto.TabIndex = 72;
            // 
            // btnAgregarImagen
            // 
            this.btnAgregarImagen.BackColor = System.Drawing.Color.Gray;
            this.btnAgregarImagen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgregarImagen.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAgregarImagen.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarImagen.Location = new System.Drawing.Point(4, 163);
            this.btnAgregarImagen.Name = "btnAgregarImagen";
            this.btnAgregarImagen.Size = new System.Drawing.Size(152, 38);
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
            this.lblTituloFoto.Size = new System.Drawing.Size(157, 31);
            this.lblTituloFoto.TabIndex = 57;
            this.lblTituloFoto.Text = "Foto";
            this.lblTituloFoto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imgFotoEmpleado
            // 
            this.imgFotoEmpleado.BackColor = System.Drawing.Color.White;
            this.imgFotoEmpleado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imgFotoEmpleado.Image = global::Presentacion.Core.Properties.Resources.iPhoto_photo_picture_camera_2661;
            this.imgFotoEmpleado.Location = new System.Drawing.Point(3, 34);
            this.imgFotoEmpleado.Name = "imgFotoEmpleado";
            this.imgFotoEmpleado.Size = new System.Drawing.Size(148, 124);
            this.imgFotoEmpleado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgFotoEmpleado.TabIndex = 0;
            this.imgFotoEmpleado.TabStop = false;
            // 
            // txtDireccion
            // 
            this.txtDireccion.BackColor = System.Drawing.SystemColors.Info;
            this.txtDireccion.Location = new System.Drawing.Point(127, 206);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(259, 33);
            this.txtDireccion.TabIndex = 12;
            // 
            // txtTelefono
            // 
            this.txtTelefono.BackColor = System.Drawing.SystemColors.Info;
            this.txtTelefono.Location = new System.Drawing.Point(127, 160);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(259, 33);
            this.txtTelefono.TabIndex = 11;
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.SystemColors.Info;
            this.txtNombre.Location = new System.Drawing.Point(127, 69);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(259, 33);
            this.txtNombre.TabIndex = 9;
            // 
            // txtApellido
            // 
            this.txtApellido.BackColor = System.Drawing.SystemColors.Info;
            this.txtApellido.Location = new System.Drawing.Point(127, 20);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(259, 33);
            this.txtApellido.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Default;
            this.label3.Location = new System.Drawing.Point(23, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "Direccion:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Default;
            this.label4.Location = new System.Drawing.Point(22, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "Telefono:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.label2.Location = new System.Drawing.Point(22, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Location = new System.Drawing.Point(22, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Apellido:";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // Cliente_Abm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 318);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(677, 357);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(677, 357);
            this.Name = "Cliente_Abm";
            this.Text = "Cliente_Abm";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlFoto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgFotoEmpleado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlFoto;
        private System.Windows.Forms.Button btnAgregarImagen;
        private System.Windows.Forms.Label lblTituloFoto;
        private System.Windows.Forms.PictureBox imgFotoEmpleado;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.CheckBox ckbPrincipal;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Label label5;
    }
}