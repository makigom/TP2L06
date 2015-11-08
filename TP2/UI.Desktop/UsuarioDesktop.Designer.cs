namespace UI.Desktop
{
    partial class UsuarioDesktop
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
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.lblClave = new System.Windows.Forms.Label();
            this.txtNombreUsuario = new System.Windows.Forms.TextBox();
            this.txtConfirmarClave = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblConfirmarClave = new System.Windows.Forms.Label();
            this.chkHabilitado = new System.Windows.Forms.CheckBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblIDPersona = new System.Windows.Forms.Label();
            this.cbIDPersona = new System.Windows.Forms.ComboBox();
            this.chkCambiarClave = new System.Windows.Forms.CheckBox();
            this.lblClaveNueva = new System.Windows.Forms.Label();
            this.txtNuevaClave = new System.Windows.Forms.TextBox();
            this.txtConfirmarNuevaClave = new System.Windows.Forms.TextBox();
            this.lblConfirmarClaveNueva = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(92, 32);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(155, 20);
            this.txtID.TabIndex = 1;
            this.txtID.Tag = "ID";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(28, 32);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(18, 13);
            this.lblID.TabIndex = 1;
            this.lblID.Text = "ID";
            // 
            // txtClave
            // 
            this.txtClave.Location = new System.Drawing.Point(412, 57);
            this.txtClave.Name = "txtClave";
            this.txtClave.PasswordChar = '*';
            this.txtClave.Size = new System.Drawing.Size(155, 20);
            this.txtClave.TabIndex = 6;
            this.txtClave.Tag = "Clave";
            // 
            // lblClave
            // 
            this.lblClave.AutoSize = true;
            this.lblClave.Location = new System.Drawing.Point(282, 65);
            this.lblClave.Name = "lblClave";
            this.lblClave.Size = new System.Drawing.Size(34, 13);
            this.lblClave.TabIndex = 7;
            this.lblClave.Text = "Clave";
            // 
            // txtNombreUsuario
            // 
            this.txtNombreUsuario.Location = new System.Drawing.Point(412, 31);
            this.txtNombreUsuario.Name = "txtNombreUsuario";
            this.txtNombreUsuario.Size = new System.Drawing.Size(155, 20);
            this.txtNombreUsuario.TabIndex = 5;
            this.txtNombreUsuario.Tag = "NombreUsuario";
            // 
            // txtConfirmarClave
            // 
            this.txtConfirmarClave.Location = new System.Drawing.Point(412, 83);
            this.txtConfirmarClave.Name = "txtConfirmarClave";
            this.txtConfirmarClave.PasswordChar = '*';
            this.txtConfirmarClave.Size = new System.Drawing.Size(155, 20);
            this.txtConfirmarClave.TabIndex = 7;
            this.txtConfirmarClave.Tag = "ConfirmarClave";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(282, 39);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(43, 13);
            this.lblUsuario.TabIndex = 12;
            this.lblUsuario.Text = "Usuario";
            // 
            // lblConfirmarClave
            // 
            this.lblConfirmarClave.AutoSize = true;
            this.lblConfirmarClave.Location = new System.Drawing.Point(282, 91);
            this.lblConfirmarClave.Name = "lblConfirmarClave";
            this.lblConfirmarClave.Size = new System.Drawing.Size(78, 13);
            this.lblConfirmarClave.TabIndex = 13;
            this.lblConfirmarClave.Text = "ConfirmarClave";
            // 
            // chkHabilitado
            // 
            this.chkHabilitado.AutoSize = true;
            this.chkHabilitado.Location = new System.Drawing.Point(31, 90);
            this.chkHabilitado.Name = "chkHabilitado";
            this.chkHabilitado.Size = new System.Drawing.Size(73, 17);
            this.chkHabilitado.TabIndex = 3;
            this.chkHabilitado.Tag = "Habilitado";
            this.chkHabilitado.Text = "Habilitado";
            this.chkHabilitado.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(172, 184);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 10;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            this.btnAceptar.Enter += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancelar.Location = new System.Drawing.Point(285, 184);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 16;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblIDPersona
            // 
            this.lblIDPersona.AutoSize = true;
            this.lblIDPersona.Location = new System.Drawing.Point(28, 64);
            this.lblIDPersona.Name = "lblIDPersona";
            this.lblIDPersona.Size = new System.Drawing.Size(60, 13);
            this.lblIDPersona.TabIndex = 17;
            this.lblIDPersona.Text = "ID Persona";
            // 
            // cbIDPersona
            // 
            this.cbIDPersona.DisplayMember = "id_persona";
            this.cbIDPersona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIDPersona.Location = new System.Drawing.Point(92, 57);
            this.cbIDPersona.Name = "cbIDPersona";
            this.cbIDPersona.Size = new System.Drawing.Size(155, 21);
            this.cbIDPersona.TabIndex = 2;
            this.cbIDPersona.Tag = "IDPersona";
            this.cbIDPersona.ValueMember = "id_persona";
            // 
            // chkCambiarClave
            // 
            this.chkCambiarClave.AutoSize = true;
            this.chkCambiarClave.Location = new System.Drawing.Point(31, 123);
            this.chkCambiarClave.Name = "chkCambiarClave";
            this.chkCambiarClave.Size = new System.Drawing.Size(94, 17);
            this.chkCambiarClave.TabIndex = 4;
            this.chkCambiarClave.Tag = "CambiarClave";
            this.chkCambiarClave.Text = "Cambiar Clave";
            this.chkCambiarClave.UseVisualStyleBackColor = true;
            // 
            // lblClaveNueva
            // 
            this.lblClaveNueva.AutoSize = true;
            this.lblClaveNueva.Location = new System.Drawing.Point(282, 117);
            this.lblClaveNueva.Name = "lblClaveNueva";
            this.lblClaveNueva.Size = new System.Drawing.Size(69, 13);
            this.lblClaveNueva.TabIndex = 19;
            this.lblClaveNueva.Text = "Clave Nueva";
            // 
            // txtNuevaClave
            // 
            this.txtNuevaClave.Location = new System.Drawing.Point(412, 109);
            this.txtNuevaClave.Name = "txtNuevaClave";
            this.txtNuevaClave.ReadOnly = true;
            this.txtNuevaClave.Size = new System.Drawing.Size(155, 20);
            this.txtNuevaClave.TabIndex = 8;
            this.txtNuevaClave.Tag = "NuevaClave";
            // 
            // txtConfirmarNuevaClave
            // 
            this.txtConfirmarNuevaClave.Location = new System.Drawing.Point(412, 135);
            this.txtConfirmarNuevaClave.Name = "txtConfirmarNuevaClave";
            this.txtConfirmarNuevaClave.ReadOnly = true;
            this.txtConfirmarNuevaClave.Size = new System.Drawing.Size(155, 20);
            this.txtConfirmarNuevaClave.TabIndex = 9;
            this.txtConfirmarNuevaClave.Tag = "ConfirmarNuevaClave";
            // 
            // lblConfirmarClaveNueva
            // 
            this.lblConfirmarClaveNueva.AutoSize = true;
            this.lblConfirmarClaveNueva.Location = new System.Drawing.Point(282, 142);
            this.lblConfirmarClaveNueva.Name = "lblConfirmarClaveNueva";
            this.lblConfirmarClaveNueva.Size = new System.Drawing.Size(116, 13);
            this.lblConfirmarClaveNueva.TabIndex = 22;
            this.lblConfirmarClaveNueva.Text = "Confirmar Clave Nueva";
            // 
            // UsuarioDesktop
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 219);
            this.Controls.Add(this.lblConfirmarClaveNueva);
            this.Controls.Add(this.txtConfirmarNuevaClave);
            this.Controls.Add(this.txtNuevaClave);
            this.Controls.Add(this.lblClaveNueva);
            this.Controls.Add(this.chkCambiarClave);
            this.Controls.Add(this.cbIDPersona);
            this.Controls.Add(this.lblIDPersona);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.chkHabilitado);
            this.Controls.Add(this.lblConfirmarClave);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.txtConfirmarClave);
            this.Controls.Add(this.txtNombreUsuario);
            this.Controls.Add(this.lblClave);
            this.Controls.Add(this.txtClave);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.txtID);
            this.Name = "UsuarioDesktop";
            this.Text = "UsuarioDesktop";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.TextBox txtNombreUsuario;
        private System.Windows.Forms.TextBox txtConfirmarClave;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblConfirmarClave;
        private System.Windows.Forms.CheckBox chkHabilitado;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblIDPersona;
        private System.Windows.Forms.ComboBox cbIDPersona;
        private System.Windows.Forms.CheckBox chkCambiarClave;
        private System.Windows.Forms.Label lblClaveNueva;
        private System.Windows.Forms.TextBox txtNuevaClave;
        private System.Windows.Forms.TextBox txtConfirmarNuevaClave;
        private System.Windows.Forms.Label lblConfirmarClaveNueva;

    }
}