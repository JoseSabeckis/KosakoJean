namespace Presentacion.Core.Pedido
{
    partial class Pedido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pedido));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.ckbCtaCte = new System.Windows.Forms.CheckBox();
            this.ckbNormal = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dtpFechaEntrega = new System.Windows.Forms.DateTimePicker();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nudAdelanto = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnCargar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAdelanto)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.dtpFechaEntrega);
            this.panel1.Controls.Add(this.txtNombre);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.nudAdelanto);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(656, 363);
            this.panel1.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.txtApellido);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Location = new System.Drawing.Point(113, 132);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(443, 69);
            this.panel6.TabIndex = 13;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(106, 18);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(297, 29);
            this.txtApellido.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "Apellido";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.ckbCtaCte);
            this.panel5.Controls.Add(this.ckbNormal);
            this.panel5.Location = new System.Drawing.Point(445, 230);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(111, 91);
            this.panel5.TabIndex = 12;
            // 
            // ckbCtaCte
            // 
            this.ckbCtaCte.AutoSize = true;
            this.ckbCtaCte.Location = new System.Drawing.Point(9, 46);
            this.ckbCtaCte.Name = "ckbCtaCte";
            this.ckbCtaCte.Size = new System.Drawing.Size(84, 28);
            this.ckbCtaCte.TabIndex = 11;
            this.ckbCtaCte.Text = "CtaCte";
            this.ckbCtaCte.UseVisualStyleBackColor = true;
            this.ckbCtaCte.CheckedChanged += new System.EventHandler(this.ckbCtaCte_CheckedChanged);
            // 
            // ckbNormal
            // 
            this.ckbNormal.AutoSize = true;
            this.ckbNormal.Checked = true;
            this.ckbNormal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbNormal.Location = new System.Drawing.Point(9, 12);
            this.ckbNormal.Name = "ckbNormal";
            this.ckbNormal.Size = new System.Drawing.Size(90, 28);
            this.ckbNormal.TabIndex = 10;
            this.ckbNormal.Text = "Normal";
            this.ckbNormal.UseVisualStyleBackColor = true;
            this.ckbNormal.CheckedChanged += new System.EventHandler(this.ckbNormal_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Location = new System.Drawing.Point(113, 207);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(443, 10);
            this.panel3.TabIndex = 9;
            // 
            // dtpFechaEntrega
            // 
            this.dtpFechaEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaEntrega.Location = new System.Drawing.Point(288, 292);
            this.dtpFechaEntrega.Name = "dtpFechaEntrega";
            this.dtpFechaEntrega.Size = new System.Drawing.Size(139, 29);
            this.dtpFechaEntrega.TabIndex = 8;
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(288, 186);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(167, 21);
            this.txtNombre.TabIndex = 7;
            this.txtNombre.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(147, 292);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 24);
            this.label5.TabIndex = 5;
            this.label5.Text = "Fecha Entrega";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(203, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Nombre";
            this.label4.Visible = false;
            // 
            // nudAdelanto
            // 
            this.nudAdelanto.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nudAdelanto.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudAdelanto.Location = new System.Drawing.Point(288, 230);
            this.nudAdelanto.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudAdelanto.Name = "nudAdelanto";
            this.nudAdelanto.Size = new System.Drawing.Size(139, 29);
            this.nudAdelanto.TabIndex = 2;
            this.nudAdelanto.ValueChanged += new System.EventHandler(this.nudAdelanto_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(109, 235);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Adelanto de Dinero";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(652, 100);
            this.panel2.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.btnCargar);
            this.panel4.Controls.Add(this.btnVolver);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(344, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(304, 96);
            this.panel4.TabIndex = 3;
            // 
            // btnCargar
            // 
            this.btnCargar.BackColor = System.Drawing.Color.Lime;
            this.btnCargar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCargar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargar.Location = new System.Drawing.Point(0, 0);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(191, 92);
            this.btnCargar.TabIndex = 3;
            this.btnCargar.Text = "Cargar";
            this.btnCargar.UseVisualStyleBackColor = false;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btnVolver.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Location = new System.Drawing.Point(191, 0);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(109, 92);
            this.btnVolver.TabIndex = 0;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = global::Presentacion.Core.Properties.Resources.add_shop_online_ecommerce_shopping_9_icon_icons_com_61652;
            this.pictureBox1.Location = new System.Drawing.Point(18, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(91, 74);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(115, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cargue mas Informacion";
            // 
            // Pedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 363);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(672, 402);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(672, 402);
            this.Name = "Pedido";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pedido";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAdelanto)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.NumericUpDown nudAdelanto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpFechaEntrega;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.CheckBox ckbCtaCte;
        private System.Windows.Forms.CheckBox ckbNormal;
        private System.Windows.Forms.Panel panel6;
    }
}