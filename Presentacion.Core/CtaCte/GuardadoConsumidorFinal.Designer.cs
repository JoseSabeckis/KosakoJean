
namespace Presentacion.Core.CtaCte
{
    partial class GuardadoConsumidorFinal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GuardadoConsumidorFinal));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.ptbImagen = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panelGrilla = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbImagen)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnEliminar);
            this.panel1.Controls.Add(this.btnActualizar);
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Controls.Add(this.ptbImagen);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(985, 92);
            this.panel1.TabIndex = 0;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(261, 20);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(230, 50);
            this.btnEliminar.TabIndex = 8;
            this.btnEliminar.Text = "Eliminar Permanente";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Visible = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.Aqua;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnActualizar.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.Location = new System.Drawing.Point(516, 20);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(202, 50);
            this.btnActualizar.TabIndex = 7;
            this.btnActualizar.Text = "Actualizar Datos";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(40, 32);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(197, 26);
            this.lblTitulo.TabIndex = 2;
            this.lblTitulo.Text = "Prendas Guardadas";
            // 
            // ptbImagen
            // 
            this.ptbImagen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptbImagen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptbImagen.Image = global::Presentacion.Core.Properties.Resources.prendas_armario_look_crop1608776690890_jpg_242310155;
            this.ptbImagen.Location = new System.Drawing.Point(0, 0);
            this.ptbImagen.Name = "ptbImagen";
            this.ptbImagen.Size = new System.Drawing.Size(863, 88);
            this.ptbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.ptbImagen.TabIndex = 1;
            this.ptbImagen.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(863, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 88);
            this.button1.TabIndex = 0;
            this.button1.Text = "Volver";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panelGrilla
            // 
            this.panelGrilla.AutoScroll = true;
            this.panelGrilla.AutoSize = true;
            this.panelGrilla.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panelGrilla.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGrilla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGrilla.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelGrilla.Location = new System.Drawing.Point(0, 92);
            this.panelGrilla.Name = "panelGrilla";
            this.panelGrilla.Size = new System.Drawing.Size(985, 397);
            this.panelGrilla.TabIndex = 1;
            // 
            // GuardadoConsumidorFinal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(985, 489);
            this.Controls.Add(this.panelGrilla);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1001, 528);
            this.Name = "GuardadoConsumidorFinal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Prendas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbImagen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.PictureBox ptbImagen;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panelGrilla;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnEliminar;
    }
}