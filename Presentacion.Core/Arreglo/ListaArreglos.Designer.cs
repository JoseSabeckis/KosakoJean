
namespace Presentacion.Core.Arreglo
{
    partial class ListaArreglos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListaArreglos));
            this.panel2 = new System.Windows.Forms.Panel();
            this.imgArreglos = new System.Windows.Forms.Panel();
            this.btnVolver = new System.Windows.Forms.Button();
            this.dgvGrilla = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.ckbEnEspera = new System.Windows.Forms.CheckBox();
            this.ckbRetirados = new System.Windows.Forms.CheckBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            this.panel2.SuspendLayout();
            this.imgArreglos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.dgvGrilla);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 125);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(862, 354);
            this.panel2.TabIndex = 1;
            // 
            // imgArreglos
            // 
            this.imgArreglos.BackgroundImage = global::Presentacion.Core.Properties.Resources.categorias_de_producto;
            this.imgArreglos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imgArreglos.Controls.Add(this.btnAgregar);
            this.imgArreglos.Controls.Add(this.btnVolver);
            this.imgArreglos.Controls.Add(this.ckbRetirados);
            this.imgArreglos.Controls.Add(this.ckbEnEspera);
            this.imgArreglos.Controls.Add(this.label1);
            this.imgArreglos.Dock = System.Windows.Forms.DockStyle.Top;
            this.imgArreglos.Location = new System.Drawing.Point(0, 0);
            this.imgArreglos.Name = "imgArreglos";
            this.imgArreglos.Size = new System.Drawing.Size(862, 125);
            this.imgArreglos.TabIndex = 0;
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnVolver.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVolver.Location = new System.Drawing.Point(743, 0);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(115, 121);
            this.btnVolver.TabIndex = 0;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // dgvGrilla
            // 
            this.dgvGrilla.AllowUserToAddRows = false;
            this.dgvGrilla.AllowUserToDeleteRows = false;
            this.dgvGrilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrilla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGrilla.Location = new System.Drawing.Point(0, 0);
            this.dgvGrilla.MultiSelect = false;
            this.dgvGrilla.Name = "dgvGrilla";
            this.dgvGrilla.ReadOnly = true;
            this.dgvGrilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGrilla.Size = new System.Drawing.Size(858, 350);
            this.dgvGrilla.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Lista de Arreglos";
            // 
            // ckbEnEspera
            // 
            this.ckbEnEspera.AutoSize = true;
            this.ckbEnEspera.Checked = true;
            this.ckbEnEspera.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbEnEspera.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ckbEnEspera.Location = new System.Drawing.Point(10, 44);
            this.ckbEnEspera.Name = "ckbEnEspera";
            this.ckbEnEspera.Size = new System.Drawing.Size(125, 30);
            this.ckbEnEspera.TabIndex = 2;
            this.ckbEnEspera.Text = "En Espera";
            this.ckbEnEspera.UseVisualStyleBackColor = true;
            this.ckbEnEspera.CheckedChanged += new System.EventHandler(this.ckbEnEspera_CheckedChanged);
            // 
            // ckbRetirados
            // 
            this.ckbRetirados.AutoSize = true;
            this.ckbRetirados.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ckbRetirados.Location = new System.Drawing.Point(10, 80);
            this.ckbRetirados.Name = "ckbRetirados";
            this.ckbRetirados.Size = new System.Drawing.Size(145, 30);
            this.ckbRetirados.TabIndex = 3;
            this.ckbRetirados.Text = "Terminados";
            this.ckbRetirados.UseVisualStyleBackColor = true;
            this.ckbRetirados.CheckedChanged += new System.EventHandler(this.ckbRetirados_CheckedChanged);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAgregar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Location = new System.Drawing.Point(599, 0);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(144, 121);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.Text = "Nuevo Arreglo";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // ListaArreglos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(862, 479);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.imgArreglos);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(878, 518);
            this.Name = "ListaArreglos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lista Arreglos";
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            this.panel2.ResumeLayout(false);
            this.imgArreglos.ResumeLayout(false);
            this.imgArreglos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel imgArreglos;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnVolver;
        protected System.Windows.Forms.DataGridView dgvGrilla;
        private System.Windows.Forms.CheckBox ckbRetirados;
        private System.Windows.Forms.CheckBox ckbEnEspera;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAgregar;
    }
}