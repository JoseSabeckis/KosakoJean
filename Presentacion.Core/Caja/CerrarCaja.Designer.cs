namespace Presentacion.Core.Caja
{
    partial class CerrarCaja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CerrarCaja));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btmVolver = new System.Windows.Forms.Button();
            this.btnCerrarCaja = new System.Windows.Forms.Button();
            this.txtCobrado = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvGrilla = new System.Windows.Forms.DataGridView();
            this.lblApertura = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lblApertura);
            this.panel1.Controls.Add(this.btnQuitar);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.btnCerrarCaja);
            this.panel1.Controls.Add(this.txtCobrado);
            this.panel1.Controls.Add(this.txtTotal);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(946, 130);
            this.panel1.TabIndex = 0;
            // 
            // btnQuitar
            // 
            this.btnQuitar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnQuitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitar.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitar.Location = new System.Drawing.Point(10, 89);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(244, 33);
            this.btnQuitar.TabIndex = 8;
            this.btnQuitar.Text = "Quitar Venta Seleccionada";
            this.btnQuitar.UseVisualStyleBackColor = false;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.btmVolver);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(770, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(172, 126);
            this.panel3.TabIndex = 7;
            // 
            // btmVolver
            // 
            this.btmVolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btmVolver.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btmVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btmVolver.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btmVolver.Location = new System.Drawing.Point(0, 0);
            this.btmVolver.Name = "btmVolver";
            this.btmVolver.Size = new System.Drawing.Size(168, 122);
            this.btmVolver.TabIndex = 1;
            this.btmVolver.Text = "Volver";
            this.btmVolver.UseVisualStyleBackColor = false;
            this.btmVolver.Click += new System.EventHandler(this.btmVolver_Click);
            // 
            // btnCerrarCaja
            // 
            this.btnCerrarCaja.BackColor = System.Drawing.Color.Red;
            this.btnCerrarCaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarCaja.Location = new System.Drawing.Point(53, 53);
            this.btnCerrarCaja.Name = "btnCerrarCaja";
            this.btnCerrarCaja.Size = new System.Drawing.Size(147, 33);
            this.btnCerrarCaja.TabIndex = 6;
            this.btnCerrarCaja.Text = "Cerrar Caja";
            this.btnCerrarCaja.UseVisualStyleBackColor = false;
            this.btnCerrarCaja.Click += new System.EventHandler(this.btnCerrarCaja_Click);
            // 
            // txtCobrado
            // 
            this.txtCobrado.BackColor = System.Drawing.SystemColors.Info;
            this.txtCobrado.Enabled = false;
            this.txtCobrado.Location = new System.Drawing.Point(470, 16);
            this.txtCobrado.Name = "txtCobrado";
            this.txtCobrado.Size = new System.Drawing.Size(195, 33);
            this.txtCobrado.TabIndex = 5;
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.SystemColors.Info;
            this.txtTotal.Enabled = false;
            this.txtTotal.Location = new System.Drawing.Point(470, 63);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(195, 33);
            this.txtTotal.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(373, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Cobrado";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(406, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Total";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(48, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Datos de Caja";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.dgvGrilla);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 130);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(946, 351);
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
            this.dgvGrilla.Size = new System.Drawing.Size(942, 347);
            this.dgvGrilla.TabIndex = 11;
            this.dgvGrilla.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGrilla_RowEnter);
            // 
            // lblApertura
            // 
            this.lblApertura.AutoSize = true;
            this.lblApertura.Font = new System.Drawing.Font("Microsoft Yi Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApertura.Location = new System.Drawing.Point(408, 99);
            this.lblApertura.Name = "lblApertura";
            this.lblApertura.Size = new System.Drawing.Size(113, 16);
            this.lblApertura.TabIndex = 9;
            this.lblApertura.Text = "Monto Apertura:";
            // 
            // CerrarCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(946, 481);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(829, 520);
            this.Name = "CerrarCaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cerrar Caja";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CerrarCaja_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        protected System.Windows.Forms.DataGridView dgvGrilla;
        private System.Windows.Forms.TextBox txtCobrado;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btmVolver;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCerrarCaja;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Label lblApertura;
    }
}