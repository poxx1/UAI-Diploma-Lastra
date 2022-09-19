namespace View
{
    partial class frmUsuarios
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
            this.grpPatentes = new System.Windows.Forms.GroupBox();
            this.resetPasswordBtn = new System.Windows.Forms.Button();
            this.guardarPermisosBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cboFamilias = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboPatentes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdConfigurar = new System.Windows.Forms.Button();
            this.cboUsuarios = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.eliminarPatenteBtn = new System.Windows.Forms.Button();
            this.eliminarFamiliaBtn = new System.Windows.Forms.Button();
            this.agregarPatenteBtn = new System.Windows.Forms.Button();
            this.agregarFamiliaBtn = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.grpPatentes.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpPatentes
            // 
            this.grpPatentes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.grpPatentes.Controls.Add(this.resetPasswordBtn);
            this.grpPatentes.Controls.Add(this.guardarPermisosBtn);
            this.grpPatentes.Controls.Add(this.label4);
            this.grpPatentes.Controls.Add(this.cboFamilias);
            this.grpPatentes.Controls.Add(this.label3);
            this.grpPatentes.Controls.Add(this.cboPatentes);
            this.grpPatentes.Controls.Add(this.label1);
            this.grpPatentes.Controls.Add(this.cmdConfigurar);
            this.grpPatentes.Controls.Add(this.cboUsuarios);
            this.grpPatentes.Controls.Add(this.label2);
            this.grpPatentes.Controls.Add(this.eliminarPatenteBtn);
            this.grpPatentes.Controls.Add(this.eliminarFamiliaBtn);
            this.grpPatentes.Controls.Add(this.agregarPatenteBtn);
            this.grpPatentes.Controls.Add(this.agregarFamiliaBtn);
            this.grpPatentes.ForeColor = System.Drawing.Color.White;
            this.grpPatentes.Location = new System.Drawing.Point(16, 19);
            this.grpPatentes.Margin = new System.Windows.Forms.Padding(2);
            this.grpPatentes.Name = "grpPatentes";
            this.grpPatentes.Padding = new System.Windows.Forms.Padding(2);
            this.grpPatentes.Size = new System.Drawing.Size(557, 286);
            this.grpPatentes.TabIndex = 5;
            this.grpPatentes.TabStop = false;
            this.grpPatentes.Tag = "1AUsuariosTitulo";
            this.grpPatentes.Text = "Usuarios";
            this.grpPatentes.Enter += new System.EventHandler(this.grpPatentes_Enter);
            // 
            // resetPasswordBtn
            // 
            this.resetPasswordBtn.BackColor = System.Drawing.Color.Black;
            this.resetPasswordBtn.Location = new System.Drawing.Point(272, 244);
            this.resetPasswordBtn.Name = "resetPasswordBtn";
            this.resetPasswordBtn.Size = new System.Drawing.Size(134, 32);
            this.resetPasswordBtn.TabIndex = 17;
            this.resetPasswordBtn.Tag = "1AReiniciarPasswordButton";
            this.resetPasswordBtn.Text = "Reset Password";
            this.resetPasswordBtn.UseVisualStyleBackColor = false;
            this.resetPasswordBtn.Click += new System.EventHandler(this.resetPasswordBtn_Click);
            // 
            // guardarPermisosBtn
            // 
            this.guardarPermisosBtn.BackColor = System.Drawing.Color.Black;
            this.guardarPermisosBtn.Location = new System.Drawing.Point(411, 244);
            this.guardarPermisosBtn.Margin = new System.Windows.Forms.Padding(2);
            this.guardarPermisosBtn.Name = "guardarPermisosBtn";
            this.guardarPermisosBtn.Size = new System.Drawing.Size(137, 32);
            this.guardarPermisosBtn.TabIndex = 7;
            this.guardarPermisosBtn.Tag = "1AGuardarButton";
            this.guardarPermisosBtn.Text = "Guardar cambios";
            this.guardarPermisosBtn.UseVisualStyleBackColor = false;
            this.guardarPermisosBtn.Click += new System.EventHandler(this.CmdGuardarFamilia_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(269, 23);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Permisos";
            // 
            // cboFamilias
            // 
            this.cboFamilias.BackColor = System.Drawing.Color.Black;
            this.cboFamilias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFamilias.ForeColor = System.Drawing.Color.White;
            this.cboFamilias.FormattingEnabled = true;
            this.cboFamilias.Location = new System.Drawing.Point(12, 213);
            this.cboFamilias.Margin = new System.Windows.Forms.Padding(2);
            this.cboFamilias.Name = "cboFamilias";
            this.cboFamilias.Size = new System.Drawing.Size(234, 21);
            this.cboFamilias.TabIndex = 12;
            this.cboFamilias.SelectedIndexChanged += new System.EventHandler(this.cboFamilias_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 197);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 11;
            this.label3.Tag = "1AAgregarFamiliasTitulo";
            this.label3.Text = "Agregar Familias";
            // 
            // cboPatentes
            // 
            this.cboPatentes.BackColor = System.Drawing.Color.Black;
            this.cboPatentes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPatentes.ForeColor = System.Drawing.Color.White;
            this.cboPatentes.FormattingEnabled = true;
            this.cboPatentes.Location = new System.Drawing.Point(11, 127);
            this.cboPatentes.Margin = new System.Windows.Forms.Padding(2);
            this.cboPatentes.Name = "cboPatentes";
            this.cboPatentes.Size = new System.Drawing.Size(234, 21);
            this.cboPatentes.TabIndex = 9;
            this.cboPatentes.SelectedIndexChanged += new System.EventHandler(this.cboPatentes_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 110);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 8;
            this.label1.Tag = "1AAgregarPatentesTitulo";
            this.label1.Text = "Agregar patentes";
            // 
            // cmdConfigurar
            // 
            this.cmdConfigurar.BackColor = System.Drawing.Color.Black;
            this.cmdConfigurar.Location = new System.Drawing.Point(11, 64);
            this.cmdConfigurar.Margin = new System.Windows.Forms.Padding(2);
            this.cmdConfigurar.Name = "cmdConfigurar";
            this.cmdConfigurar.Size = new System.Drawing.Size(234, 29);
            this.cmdConfigurar.TabIndex = 7;
            this.cmdConfigurar.Tag = "1AConfigurarButton";
            this.cmdConfigurar.Text = "Configurar";
            this.cmdConfigurar.UseVisualStyleBackColor = false;
            this.cmdConfigurar.Click += new System.EventHandler(this.CmdConfigurar_Click);
            // 
            // cboUsuarios
            // 
            this.cboUsuarios.BackColor = System.Drawing.Color.Black;
            this.cboUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUsuarios.ForeColor = System.Drawing.Color.White;
            this.cboUsuarios.FormattingEnabled = true;
            this.cboUsuarios.Location = new System.Drawing.Point(11, 39);
            this.cboUsuarios.Margin = new System.Windows.Forms.Padding(2);
            this.cboUsuarios.Name = "cboUsuarios";
            this.cboUsuarios.Size = new System.Drawing.Size(234, 21);
            this.cboUsuarios.TabIndex = 6;
            this.cboUsuarios.SelectedIndexChanged += new System.EventHandler(this.cboUsuarios_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 5;
            this.label2.Tag = "1ATodosUsuariosTitulo";
            this.label2.Text = "Todos los usuarios";
            // 
            // eliminarPatenteBtn
            // 
            this.eliminarPatenteBtn.BackColor = System.Drawing.Color.Black;
            this.eliminarPatenteBtn.Location = new System.Drawing.Point(131, 152);
            this.eliminarPatenteBtn.Margin = new System.Windows.Forms.Padding(2);
            this.eliminarPatenteBtn.Name = "eliminarPatenteBtn";
            this.eliminarPatenteBtn.Size = new System.Drawing.Size(114, 43);
            this.eliminarPatenteBtn.TabIndex = 14;
            this.eliminarPatenteBtn.Tag = "1AEliminarButton";
            this.eliminarPatenteBtn.Text = "Eliminar >>";
            this.eliminarPatenteBtn.UseVisualStyleBackColor = false;
            this.eliminarPatenteBtn.Click += new System.EventHandler(this.eliminarPatenteBtn_Click);
            // 
            // eliminarFamiliaBtn
            // 
            this.eliminarFamiliaBtn.BackColor = System.Drawing.Color.Black;
            this.eliminarFamiliaBtn.Location = new System.Drawing.Point(132, 238);
            this.eliminarFamiliaBtn.Margin = new System.Windows.Forms.Padding(2);
            this.eliminarFamiliaBtn.Name = "eliminarFamiliaBtn";
            this.eliminarFamiliaBtn.Size = new System.Drawing.Size(114, 38);
            this.eliminarFamiliaBtn.TabIndex = 15;
            this.eliminarFamiliaBtn.Tag = "1AEliminarButton2";
            this.eliminarFamiliaBtn.Text = "Eliminar >>";
            this.eliminarFamiliaBtn.UseVisualStyleBackColor = false;
            this.eliminarFamiliaBtn.Click += new System.EventHandler(this.eliminarFamiliaBtn_Click);
            // 
            // agregarPatenteBtn
            // 
            this.agregarPatenteBtn.BackColor = System.Drawing.Color.Black;
            this.agregarPatenteBtn.Location = new System.Drawing.Point(10, 152);
            this.agregarPatenteBtn.Margin = new System.Windows.Forms.Padding(2);
            this.agregarPatenteBtn.Name = "agregarPatenteBtn";
            this.agregarPatenteBtn.Size = new System.Drawing.Size(117, 43);
            this.agregarPatenteBtn.TabIndex = 10;
            this.agregarPatenteBtn.Tag = "1AAsignarButton";
            this.agregarPatenteBtn.Text = "Agregar >>";
            this.agregarPatenteBtn.UseVisualStyleBackColor = false;
            this.agregarPatenteBtn.Click += new System.EventHandler(this.AgregarPatente_Click);
            // 
            // agregarFamiliaBtn
            // 
            this.agregarFamiliaBtn.BackColor = System.Drawing.Color.Black;
            this.agregarFamiliaBtn.Location = new System.Drawing.Point(11, 238);
            this.agregarFamiliaBtn.Margin = new System.Windows.Forms.Padding(2);
            this.agregarFamiliaBtn.Name = "agregarFamiliaBtn";
            this.agregarFamiliaBtn.Size = new System.Drawing.Size(116, 38);
            this.agregarFamiliaBtn.TabIndex = 13;
            this.agregarFamiliaBtn.Tag = "1AAsignarButton2";
            this.agregarFamiliaBtn.Text = "Agregar >>";
            this.agregarFamiliaBtn.UseVisualStyleBackColor = false;
            this.agregarFamiliaBtn.Click += new System.EventHandler(this.AgregarFamilia_Click);
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.treeView1.ForeColor = System.Drawing.Color.White;
            this.treeView1.Location = new System.Drawing.Point(288, 58);
            this.treeView1.Margin = new System.Windows.Forms.Padding(2);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(276, 195);
            this.treeView1.TabIndex = 6;
            // 
            // frmUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(584, 313);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.grpPatentes);
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmUsuarios";
            this.Text = "Gestión de usuarios";
            this.Load += new System.EventHandler(this.frmUsuarios_Load);
            this.grpPatentes.ResumeLayout(false);
            this.grpPatentes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpPatentes;
        private System.Windows.Forms.ComboBox cboUsuarios;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdConfigurar;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button agregarFamiliaBtn;
        private System.Windows.Forms.ComboBox cboFamilias;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button agregarPatenteBtn;
        private System.Windows.Forms.ComboBox cboPatentes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button guardarPermisosBtn;
        private System.Windows.Forms.Button eliminarPatenteBtn;
        private System.Windows.Forms.Button eliminarFamiliaBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button resetPasswordBtn;
    }
}