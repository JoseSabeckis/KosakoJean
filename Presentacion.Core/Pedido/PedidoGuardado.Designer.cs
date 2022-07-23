
namespace Presentacion.Core.Pedido
{
    partial class PedidoGuardado
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PedidoGuardado));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEliminarPedidoSeleccionado = new System.Windows.Forms.Button();
            this.lblEliminado = new System.Windows.Forms.Label();
            this.btnAgregarProductos = new System.Windows.Forms.Button();
            this.btnVolverPedidoNoRetirado = new System.Windows.Forms.Button();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblHorario = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblPersona = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.imgGuardado = new System.Windows.Forms.PictureBox();
            this.btnVolver = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvGrilla = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblNumeroOperacion = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnRestar = new System.Windows.Forms.Button();
            this.btnCobro = new System.Windows.Forms.Button();
            this.lblCobrar = new System.Windows.Forms.Label();
            this.ckbNormal = new System.Windows.Forms.CheckBox();
            this.ckbTarjeta = new System.Windows.Forms.CheckBox();
            this.nudCobro = new System.Windows.Forms.NumericUpDown();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtDebe = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDineroAdelanto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPagado = new System.Windows.Forms.Label();
            this.lblVendido = new System.Windows.Forms.Label();
            this.btnTerminar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.txtNotas = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgGuardado)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCobro)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnEliminarPedidoSeleccionado);
            this.panel1.Controls.Add(this.lblEliminado);
            this.panel1.Controls.Add(this.btnAgregarProductos);
            this.panel1.Controls.Add(this.btnVolverPedidoNoRetirado);
            this.panel1.Controls.Add(this.lblFechaInicio);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.lblHorario);
            this.panel1.Controls.Add(this.lblFecha);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lblPersona);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.imgGuardado);
            this.panel1.Controls.Add(this.btnVolver);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1172, 100);
            this.panel1.TabIndex = 0;
            // 
            // btnEliminarPedidoSeleccionado
            // 
            this.btnEliminarPedidoSeleccionado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminarPedidoSeleccionado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnEliminarPedidoSeleccionado.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEliminarPedidoSeleccionado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarPedidoSeleccionado.Location = new System.Drawing.Point(564, 56);
            this.btnEliminarPedidoSeleccionado.Name = "btnEliminarPedidoSeleccionado";
            this.btnEliminarPedidoSeleccionado.Size = new System.Drawing.Size(213, 36);
            this.btnEliminarPedidoSeleccionado.TabIndex = 20;
            this.btnEliminarPedidoSeleccionado.Text = "Eliminar Producto Seleccionado";
            this.btnEliminarPedidoSeleccionado.UseVisualStyleBackColor = false;
            this.btnEliminarPedidoSeleccionado.Click += new System.EventHandler(this.btnEliminarPedidoSeleccionado_Click);
            // 
            // lblEliminado
            // 
            this.lblEliminado.AutoSize = true;
            this.lblEliminado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblEliminado.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEliminado.ForeColor = System.Drawing.Color.Red;
            this.lblEliminado.Location = new System.Drawing.Point(563, 52);
            this.lblEliminado.Name = "lblEliminado";
            this.lblEliminado.Size = new System.Drawing.Size(205, 26);
            this.lblEliminado.TabIndex = 19;
            this.lblEliminado.Text = "| Pedido Eliminado |";
            this.lblEliminado.Visible = false;
            // 
            // btnAgregarProductos
            // 
            this.btnAgregarProductos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAgregarProductos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAgregarProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarProductos.Location = new System.Drawing.Point(143, 63);
            this.btnAgregarProductos.Name = "btnAgregarProductos";
            this.btnAgregarProductos.Size = new System.Drawing.Size(233, 29);
            this.btnAgregarProductos.TabIndex = 18;
            this.btnAgregarProductos.Text = "Agregar Productos";
            this.btnAgregarProductos.UseVisualStyleBackColor = false;
            this.btnAgregarProductos.Click += new System.EventHandler(this.btnAgregarProductos_Click);
            // 
            // btnVolverPedidoNoRetirado
            // 
            this.btnVolverPedidoNoRetirado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVolverPedidoNoRetirado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnVolverPedidoNoRetirado.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVolverPedidoNoRetirado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolverPedidoNoRetirado.Location = new System.Drawing.Point(787, 57);
            this.btnVolverPedidoNoRetirado.Name = "btnVolverPedidoNoRetirado";
            this.btnVolverPedidoNoRetirado.Size = new System.Drawing.Size(244, 35);
            this.btnVolverPedidoNoRetirado.TabIndex = 17;
            this.btnVolverPedidoNoRetirado.Text = "Volver a Proceso No Retirado";
            this.btnVolverPedidoNoRetirado.UseVisualStyleBackColor = false;
            this.btnVolverPedidoNoRetirado.Visible = false;
            this.btnVolverPedidoNoRetirado.Click += new System.EventHandler(this.btnVolverPedidoNoRetirado_Click);
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaInicio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblFechaInicio.Location = new System.Drawing.Point(783, 34);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(59, 20);
            this.lblFechaInicio.TabIndex = 16;
            this.lblFechaInicio.Text = "Fecha";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(783, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(185, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "Fecha de Pedido Creado";
            // 
            // lblHorario
            // 
            this.lblHorario.AutoSize = true;
            this.lblHorario.BackColor = System.Drawing.Color.Red;
            this.lblHorario.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHorario.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblHorario.Location = new System.Drawing.Point(564, 5);
            this.lblHorario.Name = "lblHorario";
            this.lblHorario.Size = new System.Drawing.Size(73, 22);
            this.lblHorario.TabIndex = 14;
            this.lblHorario.Text = "Horario";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.BackColor = System.Drawing.Color.Silver;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.Color.Red;
            this.lblFecha.Location = new System.Drawing.Point(307, 5);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(69, 24);
            this.lblFecha.TabIndex = 13;
            this.lblFecha.Text = "Fecha";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(139, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 24);
            this.label5.TabIndex = 12;
            this.label5.Text = "Fecha de Entrega";
            // 
            // lblPersona
            // 
            this.lblPersona.AutoSize = true;
            this.lblPersona.BackColor = System.Drawing.Color.Red;
            this.lblPersona.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersona.ForeColor = System.Drawing.Color.Black;
            this.lblPersona.Location = new System.Drawing.Point(324, 36);
            this.lblPersona.Name = "lblPersona";
            this.lblPersona.Size = new System.Drawing.Size(184, 24);
            this.lblPersona.TabIndex = 11;
            this.lblPersona.Text = "Apellido y Nombre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(139, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 24);
            this.label1.TabIndex = 10;
            this.label1.Text = "Total del Pedido de ";
            // 
            // imgGuardado
            // 
            this.imgGuardado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgGuardado.Dock = System.Windows.Forms.DockStyle.Left;
            this.imgGuardado.Image = global::Presentacion.Core.Properties.Resources._4_tipos_clientes;
            this.imgGuardado.Location = new System.Drawing.Point(0, 0);
            this.imgGuardado.Name = "imgGuardado";
            this.imgGuardado.Size = new System.Drawing.Size(133, 96);
            this.imgGuardado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgGuardado.TabIndex = 1;
            this.imgGuardado.TabStop = false;
            // 
            // btnVolver
            // 
            this.btnVolver.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVolver.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.Location = new System.Drawing.Point(1055, 0);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(113, 96);
            this.btnVolver.TabIndex = 0;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.dgvGrilla);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1176, 459);
            this.panel2.TabIndex = 1;
            // 
            // dgvGrilla
            // 
            this.dgvGrilla.AllowUserToAddRows = false;
            this.dgvGrilla.AllowUserToDeleteRows = false;
            this.dgvGrilla.BackgroundColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGrilla.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvGrilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvGrilla.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvGrilla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGrilla.Location = new System.Drawing.Point(0, 100);
            this.dgvGrilla.Margin = new System.Windows.Forms.Padding(4);
            this.dgvGrilla.MultiSelect = false;
            this.dgvGrilla.Name = "dgvGrilla";
            this.dgvGrilla.ReadOnly = true;
            this.dgvGrilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGrilla.Size = new System.Drawing.Size(1172, 245);
            this.dgvGrilla.TabIndex = 13;
            this.dgvGrilla.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGrilla_RowEnter);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Silver;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblNumeroOperacion);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.lblPagado);
            this.panel3.Controls.Add(this.lblVendido);
            this.panel3.Controls.Add(this.btnTerminar);
            this.panel3.Controls.Add(this.btnEliminar);
            this.panel3.Controls.Add(this.txtNotas);
            this.panel3.Controls.Add(this.btnGuardar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 345);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1172, 110);
            this.panel3.TabIndex = 0;
            // 
            // lblNumeroOperacion
            // 
            this.lblNumeroOperacion.AutoSize = true;
            this.lblNumeroOperacion.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroOperacion.Location = new System.Drawing.Point(516, 89);
            this.lblNumeroOperacion.Name = "lblNumeroOperacion";
            this.lblNumeroOperacion.Size = new System.Drawing.Size(164, 19);
            this.lblNumeroOperacion.TabIndex = 36;
            this.lblNumeroOperacion.Text = "#Numero Operacion";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.btnRestar);
            this.panel5.Controls.Add(this.btnCobro);
            this.panel5.Controls.Add(this.lblCobrar);
            this.panel5.Controls.Add(this.ckbNormal);
            this.panel5.Controls.Add(this.ckbTarjeta);
            this.panel5.Controls.Add(this.nudCobro);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(686, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(277, 108);
            this.panel5.TabIndex = 26;
            // 
            // btnRestar
            // 
            this.btnRestar.BackColor = System.Drawing.Color.Red;
            this.btnRestar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRestar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestar.Location = new System.Drawing.Point(120, 51);
            this.btnRestar.Name = "btnRestar";
            this.btnRestar.Size = new System.Drawing.Size(63, 45);
            this.btnRestar.TabIndex = 19;
            this.btnRestar.Text = "Restar";
            this.btnRestar.UseVisualStyleBackColor = false;
            this.btnRestar.Click += new System.EventHandler(this.btnRestar_Click);
            // 
            // btnCobro
            // 
            this.btnCobro.BackColor = System.Drawing.Color.Lime;
            this.btnCobro.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCobro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCobro.Location = new System.Drawing.Point(189, 51);
            this.btnCobro.Name = "btnCobro";
            this.btnCobro.Size = new System.Drawing.Size(81, 45);
            this.btnCobro.TabIndex = 17;
            this.btnCobro.Text = "Cobrar";
            this.btnCobro.UseVisualStyleBackColor = false;
            this.btnCobro.Click += new System.EventHandler(this.btnCobro_Click);
            // 
            // lblCobrar
            // 
            this.lblCobrar.AutoSize = true;
            this.lblCobrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCobrar.Location = new System.Drawing.Point(16, 12);
            this.lblCobrar.Name = "lblCobrar";
            this.lblCobrar.Size = new System.Drawing.Size(123, 24);
            this.lblCobrar.TabIndex = 15;
            this.lblCobrar.Text = "Adelanto de";
            // 
            // ckbNormal
            // 
            this.ckbNormal.AutoSize = true;
            this.ckbNormal.Checked = true;
            this.ckbNormal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbNormal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbNormal.Location = new System.Drawing.Point(20, 51);
            this.ckbNormal.Name = "ckbNormal";
            this.ckbNormal.Size = new System.Drawing.Size(96, 24);
            this.ckbNormal.TabIndex = 13;
            this.ckbNormal.Text = "Contado";
            this.ckbNormal.UseVisualStyleBackColor = true;
            // 
            // ckbTarjeta
            // 
            this.ckbTarjeta.AutoSize = true;
            this.ckbTarjeta.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbTarjeta.Location = new System.Drawing.Point(20, 74);
            this.ckbTarjeta.Name = "ckbTarjeta";
            this.ckbTarjeta.Size = new System.Drawing.Size(85, 26);
            this.ckbTarjeta.TabIndex = 14;
            this.ckbTarjeta.Text = "Tarjeta";
            this.ckbTarjeta.UseVisualStyleBackColor = true;
            // 
            // nudCobro
            // 
            this.nudCobro.BackColor = System.Drawing.SystemColors.Info;
            this.nudCobro.DecimalPlaces = 2;
            this.nudCobro.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudCobro.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudCobro.Location = new System.Drawing.Point(145, 9);
            this.nudCobro.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudCobro.Name = "nudCobro";
            this.nudCobro.Size = new System.Drawing.Size(120, 33);
            this.nudCobro.TabIndex = 16;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.txtDebe);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.txtTotal);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.txtDineroAdelanto);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(963, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(207, 108);
            this.panel4.TabIndex = 25;
            // 
            // txtDebe
            // 
            this.txtDebe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDebe.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtDebe.Enabled = false;
            this.txtDebe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDebe.Location = new System.Drawing.Point(113, 69);
            this.txtDebe.Name = "txtDebe";
            this.txtDebe.Size = new System.Drawing.Size(83, 26);
            this.txtDebe.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Total  $";
            // 
            // txtTotal
            // 
            this.txtTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotal.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtTotal.Enabled = false;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(113, 6);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(83, 26);
            this.txtTotal.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 22);
            this.label3.TabIndex = 4;
            this.label3.Text = "Adelanto  $";
            // 
            // txtDineroAdelanto
            // 
            this.txtDineroAdelanto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDineroAdelanto.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtDineroAdelanto.Enabled = false;
            this.txtDineroAdelanto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDineroAdelanto.Location = new System.Drawing.Point(113, 38);
            this.txtDineroAdelanto.Name = "txtDineroAdelanto";
            this.txtDineroAdelanto.Size = new System.Drawing.Size(83, 26);
            this.txtDineroAdelanto.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(37, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Debe  $";
            // 
            // lblPagado
            // 
            this.lblPagado.AutoSize = true;
            this.lblPagado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblPagado.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPagado.ForeColor = System.Drawing.Color.Red;
            this.lblPagado.Location = new System.Drawing.Point(480, 67);
            this.lblPagado.Name = "lblPagado";
            this.lblPagado.Size = new System.Drawing.Size(166, 26);
            this.lblPagado.TabIndex = 24;
            this.lblPagado.Text = "Todo Pagado !!!";
            this.lblPagado.Visible = false;
            // 
            // lblVendido
            // 
            this.lblVendido.AutoSize = true;
            this.lblVendido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblVendido.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVendido.ForeColor = System.Drawing.Color.Red;
            this.lblVendido.Location = new System.Drawing.Point(480, 17);
            this.lblVendido.Name = "lblVendido";
            this.lblVendido.Size = new System.Drawing.Size(138, 26);
            this.lblVendido.TabIndex = 23;
            this.lblVendido.Text = "Entregado !!!";
            this.lblVendido.Visible = false;
            // 
            // btnTerminar
            // 
            this.btnTerminar.BackColor = System.Drawing.Color.Lime;
            this.btnTerminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTerminar.Location = new System.Drawing.Point(478, 11);
            this.btnTerminar.Name = "btnTerminar";
            this.btnTerminar.Size = new System.Drawing.Size(185, 55);
            this.btnTerminar.TabIndex = 20;
            this.btnTerminar.Text = "Cobrar lo que Debe y Entregar";
            this.btnTerminar.UseVisualStyleBackColor = false;
            this.btnTerminar.Click += new System.EventHandler(this.btnTerminar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Red;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.Black;
            this.btnEliminar.Location = new System.Drawing.Point(369, 67);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(83, 34);
            this.btnEliminar.TabIndex = 13;
            this.btnEliminar.Text = "Eliminar Pedido";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // txtNotas
            // 
            this.txtNotas.BackColor = System.Drawing.SystemColors.Info;
            this.txtNotas.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNotas.Location = new System.Drawing.Point(3, 6);
            this.txtNotas.Multiline = true;
            this.txtNotas.Name = "txtNotas";
            this.txtNotas.Size = new System.Drawing.Size(360, 95);
            this.txtNotas.TabIndex = 12;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(369, 6);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(83, 55);
            this.btnGuardar.TabIndex = 11;
            this.btnGuardar.Text = "Guardar Extras";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // PedidoGuardado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1176, 459);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1192, 498);
            this.Name = "PedidoGuardado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pedido Guardado";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgGuardado)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCobro)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox imgGuardado;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        protected System.Windows.Forms.DataGridView dgvGrilla;
        private System.Windows.Forms.Label lblHorario;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblPersona;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.TextBox txtNotas;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnTerminar;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblVendido;
        private System.Windows.Forms.Label lblPagado;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtDebe;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDineroAdelanto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnCobro;
        private System.Windows.Forms.Label lblCobrar;
        private System.Windows.Forms.CheckBox ckbNormal;
        private System.Windows.Forms.CheckBox ckbTarjeta;
        private System.Windows.Forms.NumericUpDown nudCobro;
        private System.Windows.Forms.Button btnVolverPedidoNoRetirado;
        private System.Windows.Forms.Button btnAgregarProductos;
        private System.Windows.Forms.Label lblEliminado;
        private System.Windows.Forms.Button btnEliminarPedidoSeleccionado;
        private System.Windows.Forms.Button btnRestar;
        private System.Windows.Forms.Label lblNumeroOperacion;
    }
}