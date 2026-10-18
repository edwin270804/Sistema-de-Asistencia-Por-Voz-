namespace SistemaAsistenciaPorVoz.UI.Forms
{
    partial class FrmRegistro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRegistro));
            pnlFondo = new Panel();
            txtApellido = new SistemaAsistenciaPorVoz.UI.BotonesPersonalizados_y_Textbox.TxtPersonalizada();
            lblApellido = new Label();
            lblCerrar = new Label();
            lblMensaje = new Label();
            lnkVolverLogin = new LinkLabel();
            btnRegistrar = new SistemaAsistenciaPorVoz.UI.BotonesPersonalizados.Botones();
            chkMostrarPassword = new CheckBox();
            txtConfirmarPassword = new SistemaAsistenciaPorVoz.UI.BotonesPersonalizados_y_Textbox.TxtPersonalizada();
            lblConfirmarPassword = new Label();
            txtPassword = new SistemaAsistenciaPorVoz.UI.BotonesPersonalizados_y_Textbox.TxtPersonalizada();
            lblPassword = new Label();
            txtNombre = new SistemaAsistenciaPorVoz.UI.BotonesPersonalizados_y_Textbox.TxtPersonalizada();
            lblNombreCompleto = new Label();
            txtUsuario = new SistemaAsistenciaPorVoz.UI.BotonesPersonalizados_y_Textbox.TxtPersonalizada();
            lblUsuario = new Label();
            lblSubtitulo = new Label();
            lblTitulo = new Label();
            pnlFondo.SuspendLayout();
            SuspendLayout();
            // 
            // pnlFondo
            // 
            pnlFondo.BackColor = Color.FromArgb(8, 13, 28);
            pnlFondo.BackgroundImage = (Image)resources.GetObject("pnlFondo.BackgroundImage");
            pnlFondo.BackgroundImageLayout = ImageLayout.Stretch;
            pnlFondo.Controls.Add(txtApellido);
            pnlFondo.Controls.Add(lblApellido);
            pnlFondo.Controls.Add(lblCerrar);
            pnlFondo.Controls.Add(lblMensaje);
            pnlFondo.Controls.Add(lnkVolverLogin);
            pnlFondo.Controls.Add(btnRegistrar);
            pnlFondo.Controls.Add(chkMostrarPassword);
            pnlFondo.Controls.Add(txtConfirmarPassword);
            pnlFondo.Controls.Add(lblConfirmarPassword);
            pnlFondo.Controls.Add(txtPassword);
            pnlFondo.Controls.Add(lblPassword);
            pnlFondo.Controls.Add(txtNombre);
            pnlFondo.Controls.Add(lblNombreCompleto);
            pnlFondo.Controls.Add(txtUsuario);
            pnlFondo.Controls.Add(lblUsuario);
            pnlFondo.Controls.Add(lblSubtitulo);
            pnlFondo.Controls.Add(lblTitulo);
            pnlFondo.Dock = DockStyle.Fill;
            pnlFondo.Location = new Point(0, 0);
            pnlFondo.Name = "pnlFondo";
            pnlFondo.Size = new Size(580, 857);
            pnlFondo.TabIndex = 2;
            // 
            // txtApellido
            // 
            txtApellido.BackColor = Color.FromArgb(16, 29, 53);
            txtApellido.BorderColor = Color.MediumSlateBlue;
            txtApellido.BorderFocusColor = Color.HotPink;
            txtApellido.BorderRadius = 15;
            txtApellido.BorderSize = 2;
            txtApellido.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtApellido.ForeColor = Color.FromArgb(244, 247, 255);
            txtApellido.Location = new Point(70, 365);
            txtApellido.Multiline = false;
            txtApellido.Name = "txtApellido";
            txtApellido.Padding = new Padding(10, 7, 10, 7);
            txtApellido.PasswordChar = false;
            txtApellido.PlaceholderColor = Color.Transparent;
            txtApellido.PlaceholderText = "  Ingresa Apellido";
            txtApellido.SelectionStart = 0;
            txtApellido.Size = new Size(440, 43);
            txtApellido.TabIndex = 22;
            txtApellido.Texts = "";
            txtApellido.UnderlinedStyle = false;
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.BackColor = Color.Transparent;
            lblApellido.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblApellido.ForeColor = Color.FromArgb(244, 247, 255);
            lblApellido.Location = new Point(70, 329);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(125, 28);
            lblApellido.TabIndex = 21;
            lblApellido.Text = "📝 Apellido";
            // 
            // lblCerrar
            // 
            lblCerrar.AutoSize = true;
            lblCerrar.BackColor = Color.Transparent;
            lblCerrar.Cursor = Cursors.Hand;
            lblCerrar.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCerrar.ForeColor = Color.FromArgb(244, 247, 255);
            lblCerrar.Location = new Point(479, 15);
            lblCerrar.Name = "lblCerrar";
            lblCerrar.Size = new Size(89, 23);
            lblCerrar.TabIndex = 20;
            lblCerrar.Text = "✖️ Cerrar";
            lblCerrar.Click += lblCerrar_Click_3;
            // 
            // lblMensaje
            // 
            lblMensaje.BackColor = Color.Transparent;
            lblMensaje.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMensaje.ForeColor = Color.FromArgb(145, 164, 199);
            lblMensaje.Location = new Point(70, 794);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new Size(440, 30);
            lblMensaje.TabIndex = 13;
            lblMensaje.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lnkVolverLogin
            // 
            lnkVolverLogin.AutoSize = true;
            lnkVolverLogin.BackColor = Color.Transparent;
            lnkVolverLogin.Cursor = Cursors.Hand;
            lnkVolverLogin.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lnkVolverLogin.LinkBehavior = LinkBehavior.NeverUnderline;
            lnkVolverLogin.LinkColor = Color.FromArgb(62, 166, 255);
            lnkVolverLogin.Location = new Point(154, 711);
            lnkVolverLogin.Name = "lnkVolverLogin";
            lnkVolverLogin.Size = new Size(247, 23);
            lnkVolverLogin.TabIndex = 12;
            lnkVolverLogin.TabStop = true;
            lnkVolverLogin.Text = "¿Ya tienes cuenta? Inicia sesión";
            // 
            // btnRegistrar
            // 
            btnRegistrar.BackColor = Color.FromArgb(8, 123, 255);
            btnRegistrar.FlatAppearance.BorderSize = 0;
            btnRegistrar.FlatStyle = FlatStyle.Flat;
            btnRegistrar.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegistrar.ForeColor = Color.White;
            btnRegistrar.Location = new Point(70, 642);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(440, 55);
            btnRegistrar.TabIndex = 11;
            btnRegistrar.Text = "REGISTRARME";
            btnRegistrar.UseVisualStyleBackColor = false;
            // 
            // chkMostrarPassword
            // 
            chkMostrarPassword.AutoSize = true;
            chkMostrarPassword.BackColor = Color.Transparent;
            chkMostrarPassword.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkMostrarPassword.ForeColor = Color.FromArgb(145, 164, 199);
            chkMostrarPassword.Location = new Point(85, 602);
            chkMostrarPassword.Name = "chkMostrarPassword";
            chkMostrarPassword.Size = new Size(183, 24);
            chkMostrarPassword.TabIndex = 10;
            chkMostrarPassword.Text = "👁 Mostrar contraseña";
            chkMostrarPassword.UseVisualStyleBackColor = false;
            // 
            // txtConfirmarPassword
            // 
            txtConfirmarPassword.BackColor = Color.FromArgb(16, 29, 53);
            txtConfirmarPassword.BorderColor = Color.MediumSlateBlue;
            txtConfirmarPassword.BorderFocusColor = Color.HotPink;
            txtConfirmarPassword.BorderRadius = 15;
            txtConfirmarPassword.BorderSize = 2;
            txtConfirmarPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtConfirmarPassword.ForeColor = Color.FromArgb(244, 247, 255);
            txtConfirmarPassword.Location = new Point(70, 549);
            txtConfirmarPassword.Multiline = false;
            txtConfirmarPassword.Name = "txtConfirmarPassword";
            txtConfirmarPassword.Padding = new Padding(10, 7, 10, 7);
            txtConfirmarPassword.PasswordChar = false;
            txtConfirmarPassword.PlaceholderColor = Color.Transparent;
            txtConfirmarPassword.PlaceholderText = "  Confirma tu Contraseña";
            txtConfirmarPassword.SelectionStart = 0;
            txtConfirmarPassword.Size = new Size(440, 43);
            txtConfirmarPassword.TabIndex = 9;
            txtConfirmarPassword.Texts = "";
            txtConfirmarPassword.UnderlinedStyle = false;
            // 
            // lblConfirmarPassword
            // 
            lblConfirmarPassword.AutoSize = true;
            lblConfirmarPassword.BackColor = Color.Transparent;
            lblConfirmarPassword.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblConfirmarPassword.ForeColor = Color.FromArgb(244, 247, 255);
            lblConfirmarPassword.Location = new Point(70, 514);
            lblConfirmarPassword.Name = "lblConfirmarPassword";
            lblConfirmarPassword.Size = new Size(247, 28);
            lblConfirmarPassword.TabIndex = 8;
            lblConfirmarPassword.Text = "🔒Confirmar Contraseña";
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(16, 29, 53);
            txtPassword.BorderColor = Color.MediumSlateBlue;
            txtPassword.BorderFocusColor = Color.HotPink;
            txtPassword.BorderRadius = 15;
            txtPassword.BorderSize = 2;
            txtPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.ForeColor = Color.FromArgb(244, 247, 255);
            txtPassword.Location = new Point(70, 456);
            txtPassword.Multiline = false;
            txtPassword.Name = "txtPassword";
            txtPassword.Padding = new Padding(10, 7, 10, 7);
            txtPassword.PasswordChar = false;
            txtPassword.PlaceholderColor = Color.Transparent;
            txtPassword.PlaceholderText = "  Ingresa tu Contraseña";
            txtPassword.SelectionStart = 0;
            txtPassword.Size = new Size(440, 43);
            txtPassword.TabIndex = 7;
            txtPassword.Texts = "";
            txtPassword.UnderlinedStyle = false;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.BackColor = Color.Transparent;
            lblPassword.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPassword.ForeColor = Color.FromArgb(244, 247, 255);
            lblPassword.Location = new Point(70, 422);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(146, 28);
            lblPassword.TabIndex = 6;
            lblPassword.Text = "🔒Contraseña";
            // 
            // txtNombre
            // 
            txtNombre.BackColor = Color.FromArgb(16, 29, 53);
            txtNombre.BorderColor = Color.MediumSlateBlue;
            txtNombre.BorderFocusColor = Color.HotPink;
            txtNombre.BorderRadius = 15;
            txtNombre.BorderSize = 2;
            txtNombre.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombre.ForeColor = Color.FromArgb(244, 247, 255);
            txtNombre.Location = new Point(70, 276);
            txtNombre.Multiline = false;
            txtNombre.Name = "txtNombre";
            txtNombre.Padding = new Padding(10, 7, 10, 7);
            txtNombre.PasswordChar = false;
            txtNombre.PlaceholderColor = Color.Transparent;
            txtNombre.PlaceholderText = "  Ingresa tu Nombre";
            txtNombre.SelectionStart = 0;
            txtNombre.Size = new Size(440, 43);
            txtNombre.TabIndex = 5;
            txtNombre.Texts = "";
            txtNombre.UnderlinedStyle = false;
            // 
            // lblNombreCompleto
            // 
            lblNombreCompleto.AutoSize = true;
            lblNombreCompleto.BackColor = Color.Transparent;
            lblNombreCompleto.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNombreCompleto.ForeColor = Color.FromArgb(244, 247, 255);
            lblNombreCompleto.Location = new Point(70, 240);
            lblNombreCompleto.Name = "lblNombreCompleto";
            lblNombreCompleto.Size = new Size(123, 28);
            lblNombreCompleto.TabIndex = 4;
            lblNombreCompleto.Text = "📝 Nombre";
            // 
            // txtUsuario
            // 
            txtUsuario.BackColor = Color.FromArgb(16, 29, 53);
            txtUsuario.BorderColor = Color.MediumSlateBlue;
            txtUsuario.BorderFocusColor = Color.HotPink;
            txtUsuario.BorderRadius = 15;
            txtUsuario.BorderSize = 2;
            txtUsuario.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsuario.ForeColor = Color.FromArgb(244, 247, 255);
            txtUsuario.Location = new Point(70, 186);
            txtUsuario.Multiline = false;
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Padding = new Padding(10, 7, 10, 7);
            txtUsuario.PasswordChar = false;
            txtUsuario.PlaceholderColor = Color.Transparent;
            txtUsuario.PlaceholderText = "  Ingresa tu Usuario";
            txtUsuario.SelectionStart = 0;
            txtUsuario.Size = new Size(440, 43);
            txtUsuario.TabIndex = 3;
            txtUsuario.Texts = "";
            txtUsuario.UnderlinedStyle = false;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.BackColor = Color.Transparent;
            lblUsuario.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsuario.ForeColor = Color.FromArgb(244, 247, 255);
            lblUsuario.Location = new Point(70, 154);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(112, 28);
            lblUsuario.TabIndex = 2;
            lblUsuario.Text = "👤Usuario";
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.BackColor = Color.Transparent;
            lblSubtitulo.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSubtitulo.ForeColor = Color.FromArgb(145, 164, 199);
            lblSubtitulo.Location = new Point(70, 99);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(292, 25);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Completa los datos para registrarte";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.BackColor = Color.Transparent;
            lblTitulo.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.FromArgb(244, 247, 255);
            lblTitulo.Location = new Point(70, 30);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(310, 62);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Crear Cuenta";
            // 
            // FrmRegistro
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(580, 857);
            Controls.Add(pnlFondo);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmRegistro";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registro de Usuario";
            pnlFondo.ResumeLayout(false);
            pnlFondo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel pnlFondo;
        private BotonesPersonalizados_y_Textbox.TxtPersonalizada txtApellido;
        private Label lblApellido;
        private Label lblCerrar;
        private Label lblMensaje;
        private LinkLabel lnkVolverLogin;
        private BotonesPersonalizados.Botones btnRegistrar;
        private CheckBox chkMostrarPassword;
        private BotonesPersonalizados_y_Textbox.TxtPersonalizada txtConfirmarPassword;
        private Label lblConfirmarPassword;
        private BotonesPersonalizados_y_Textbox.TxtPersonalizada txtPassword;
        private Label lblPassword;
        private BotonesPersonalizados_y_Textbox.TxtPersonalizada txtNombre;
        private Label lblNombreCompleto;
        private BotonesPersonalizados_y_Textbox.TxtPersonalizada txtUsuario;
        private Label lblUsuario;
        private Label lblSubtitulo;
        private Label lblTitulo;
    }
}
