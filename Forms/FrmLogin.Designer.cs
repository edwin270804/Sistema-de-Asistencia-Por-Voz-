namespace SistemaAsistenciaPorVoz.UI.Forms
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            pnlFondo = new Panel();
            txtPassword = new SistemaAsistenciaPorVoz.UI.BotonesPersonalizados_y_Textbox.TxtPersonalizada();
            txtUsuario = new SistemaAsistenciaPorVoz.UI.BotonesPersonalizados_y_Textbox.TxtPersonalizada();
            lblayuda = new Label();
            btnIniciarSesion = new SistemaAsistenciaPorVoz.UI.BotonesPersonalizados.Botones();
            lblTitulo2 = new Label();
            lblrecordatorio = new Label();
            lblIniciar = new Label();
            lblBienvenido = new Label();
            chkMostrarPassword = new CheckBox();
            lblSubtitulo = new Label();
            picOndas = new PictureBox();
            lblPassword = new Label();
            label1 = new Label();
            lblUsuario = new Label();
            lnkConfiguracion = new LinkLabel();
            lnkCrearCuenta = new LinkLabel();
            lblTitulo1 = new Label();
            picMicrofono = new PictureBox();
            pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picOndas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picMicrofono).BeginInit();
            SuspendLayout();
            // 
            // pnlFondo
            // 
            pnlFondo.BackColor = Color.FromArgb(8, 13, 28);
            pnlFondo.BackgroundImage = (Image)resources.GetObject("pnlFondo.BackgroundImage");
            pnlFondo.BackgroundImageLayout = ImageLayout.Stretch;
            pnlFondo.Controls.Add(txtPassword);
            pnlFondo.Controls.Add(txtUsuario);
            pnlFondo.Controls.Add(lblayuda);
            pnlFondo.Controls.Add(btnIniciarSesion);
            pnlFondo.Controls.Add(lblTitulo2);
            pnlFondo.Controls.Add(lblrecordatorio);
            pnlFondo.Controls.Add(lblIniciar);
            pnlFondo.Controls.Add(lblBienvenido);
            pnlFondo.Controls.Add(chkMostrarPassword);
            pnlFondo.Controls.Add(lblSubtitulo);
            pnlFondo.Controls.Add(picOndas);
            pnlFondo.Controls.Add(lblPassword);
            pnlFondo.Controls.Add(label1);
            pnlFondo.Controls.Add(lblUsuario);
            pnlFondo.Controls.Add(lnkConfiguracion);
            pnlFondo.Controls.Add(lnkCrearCuenta);
            pnlFondo.Controls.Add(lblTitulo1);
            pnlFondo.Controls.Add(picMicrofono);
            pnlFondo.Dock = DockStyle.Fill;
            pnlFondo.Location = new Point(0, 0);
            pnlFondo.Name = "pnlFondo";
            pnlFondo.Size = new Size(1558, 746);
            pnlFondo.TabIndex = 0;
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
            txtPassword.Location = new Point(985, 439);
            txtPassword.Multiline = false;
            txtPassword.Name = "txtPassword";
            txtPassword.Padding = new Padding(10, 7, 10, 7);
            txtPassword.PasswordChar = false;
            txtPassword.PlaceholderColor = Color.Transparent;
            txtPassword.PlaceholderText = "  Ingresa tu Contraseña";
            txtPassword.SelectionStart = 0;
            txtPassword.Size = new Size(440, 43);
            txtPassword.TabIndex = 12;
            txtPassword.Texts = "";
            txtPassword.UnderlinedStyle = false;
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
            txtUsuario.Location = new Point(985, 353);
            txtUsuario.Multiline = false;
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Padding = new Padding(10, 7, 10, 7);
            txtUsuario.PasswordChar = false;
            txtUsuario.PlaceholderColor = Color.Transparent;
            txtUsuario.PlaceholderText = " Ingresa tu Usuario";
            txtUsuario.SelectionStart = 0;
            txtUsuario.Size = new Size(440, 43);
            txtUsuario.TabIndex = 11;
            txtUsuario.Texts = "";
            txtUsuario.UnderlinedStyle = false;
            // 
            // lblayuda
            // 
            lblayuda.BackColor = Color.Transparent;
            lblayuda.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblayuda.ForeColor = Color.FromArgb(145, 164, 199);
            lblayuda.ImageAlign = ContentAlignment.MiddleRight;
            lblayuda.Location = new Point(985, 600);
            lblayuda.Name = "lblayuda";
            lblayuda.Size = new Size(440, 36);
            lblayuda.TabIndex = 10;
            lblayuda.Text = "                       ¿Olvidaste Tu Contraseña?";
            lblayuda.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnIniciarSesion
            // 
            btnIniciarSesion.BackColor = Color.FromArgb(8, 123, 255);
            btnIniciarSesion.FlatAppearance.BorderSize = 0;
            btnIniciarSesion.FlatStyle = FlatStyle.Flat;
            btnIniciarSesion.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnIniciarSesion.ForeColor = Color.White;
            btnIniciarSesion.Location = new Point(985, 542);
            btnIniciarSesion.Name = "btnIniciarSesion";
            btnIniciarSesion.Size = new Size(440, 55);
            btnIniciarSesion.TabIndex = 9;
            btnIniciarSesion.Text = "INICIAR SESIÓN";
            btnIniciarSesion.UseVisualStyleBackColor = false;
            // 
            // lblTitulo2
            // 
            lblTitulo2.AutoSize = true;
            lblTitulo2.BackColor = Color.Transparent;
            lblTitulo2.Font = new Font("Segoe UI", 25.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo2.ForeColor = Color.FromArgb(62, 166, 255);
            lblTitulo2.Location = new Point(370, 463);
            lblTitulo2.Name = "lblTitulo2";
            lblTitulo2.Size = new Size(176, 57);
            lblTitulo2.TabIndex = 2;
            lblTitulo2.Text = "Por Voz";
            // 
            // lblrecordatorio
            // 
            lblrecordatorio.BackColor = Color.Transparent;
            lblrecordatorio.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblrecordatorio.ForeColor = Color.FromArgb(145, 164, 199);
            lblrecordatorio.ImageAlign = ContentAlignment.MiddleRight;
            lblrecordatorio.Location = new Point(1000, 695);
            lblrecordatorio.Name = "lblrecordatorio";
            lblrecordatorio.Size = new Size(310, 42);
            lblrecordatorio.TabIndex = 6;
            // 
            // lblIniciar
            // 
            lblIniciar.AutoSize = true;
            lblIniciar.BackColor = Color.Transparent;
            lblIniciar.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblIniciar.ForeColor = Color.FromArgb(145, 164, 199);
            lblIniciar.Location = new Point(985, 254);
            lblIniciar.Name = "lblIniciar";
            lblIniciar.Size = new Size(226, 25);
            lblIniciar.TabIndex = 3;
            lblIniciar.Text = "Inicia sesión para continuar";
            // 
            // lblBienvenido
            // 
            lblBienvenido.AutoSize = true;
            lblBienvenido.BackColor = Color.Transparent;
            lblBienvenido.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBienvenido.ForeColor = Color.FromArgb(244, 247, 255);
            lblBienvenido.Location = new Point(969, 179);
            lblBienvenido.Name = "lblBienvenido";
            lblBienvenido.Size = new Size(272, 62);
            lblBienvenido.TabIndex = 2;
            lblBienvenido.Text = "Bienvenido";
            // 
            // chkMostrarPassword
            // 
            chkMostrarPassword.AutoSize = true;
            chkMostrarPassword.BackColor = Color.Transparent;
            chkMostrarPassword.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkMostrarPassword.ForeColor = Color.FromArgb(145, 164, 199);
            chkMostrarPassword.Location = new Point(1000, 496);
            chkMostrarPassword.Name = "chkMostrarPassword";
            chkMostrarPassword.Size = new Size(183, 24);
            chkMostrarPassword.TabIndex = 4;
            chkMostrarPassword.Text = "👁 Mostrar contraseña";
            chkMostrarPassword.UseVisualStyleBackColor = false;
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.BackColor = Color.Transparent;
            lblSubtitulo.Font = new Font("Segoe UI Light", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSubtitulo.ForeColor = Color.FromArgb(145, 164, 199);
            lblSubtitulo.Location = new Point(321, 530);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(280, 25);
            lblSubtitulo.TabIndex = 3;
            lblSubtitulo.Text = "Tecnología que facilita la educación";
            // 
            // picOndas
            // 
            picOndas.BackColor = Color.Transparent;
            picOndas.BackgroundImageLayout = ImageLayout.Zoom;
            picOndas.Image = (Image)resources.GetObject("picOndas.Image");
            picOndas.Location = new Point(250, 577);
            picOndas.Name = "picOndas";
            picOndas.Size = new Size(449, 100);
            picOndas.SizeMode = PictureBoxSizeMode.Zoom;
            picOndas.TabIndex = 4;
            picOndas.TabStop = false;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.BackColor = Color.Transparent;
            lblPassword.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPassword.ForeColor = Color.FromArgb(244, 247, 255);
            lblPassword.Location = new Point(985, 408);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(146, 28);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "🔒Contraseña";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Cursor = Cursors.Hand;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(244, 247, 255);
            label1.Location = new Point(1457, 9);
            label1.Name = "label1";
            label1.Size = new Size(89, 23);
            label1.TabIndex = 8;
            label1.Text = "✖️ Cerrar";
            label1.Click += label1_Click;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.BackColor = Color.Transparent;
            lblUsuario.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsuario.ForeColor = Color.FromArgb(244, 247, 255);
            lblUsuario.Location = new Point(985, 322);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(112, 28);
            lblUsuario.TabIndex = 0;
            lblUsuario.Text = "👤Usuario";
            // 
            // lnkConfiguracion
            // 
            lnkConfiguracion.AutoSize = true;
            lnkConfiguracion.BackColor = Color.Transparent;
            lnkConfiguracion.Cursor = Cursors.Hand;
            lnkConfiguracion.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lnkConfiguracion.LinkBehavior = LinkBehavior.NeverUnderline;
            lnkConfiguracion.LinkColor = Color.FromArgb(62, 166, 255);
            lnkConfiguracion.Location = new Point(1401, 704);
            lnkConfiguracion.Name = "lnkConfiguracion";
            lnkConfiguracion.Size = new Size(145, 23);
            lnkConfiguracion.TabIndex = 7;
            lnkConfiguracion.TabStop = true;
            lnkConfiguracion.Text = "⚙ Configuración";
            // 
            // lnkCrearCuenta
            // 
            lnkCrearCuenta.BackColor = Color.Transparent;
            lnkCrearCuenta.Cursor = Cursors.Hand;
            lnkCrearCuenta.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lnkCrearCuenta.LinkBehavior = LinkBehavior.NeverUnderline;
            lnkCrearCuenta.LinkColor = Color.FromArgb(62, 166, 255);
            lnkCrearCuenta.Location = new Point(985, 636);
            lnkCrearCuenta.Name = "lnkCrearCuenta";
            lnkCrearCuenta.Size = new Size(440, 46);
            lnkCrearCuenta.TabIndex = 14;
            lnkCrearCuenta.TabStop = true;
            lnkCrearCuenta.Text = "¿No tienes cuenta? Crear una";
            lnkCrearCuenta.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTitulo1
            // 
            lblTitulo1.AutoSize = true;
            lblTitulo1.BackColor = Color.Transparent;
            lblTitulo1.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            lblTitulo1.ForeColor = Color.FromArgb(244, 247, 255);
            lblTitulo1.Location = new Point(250, 385);
            lblTitulo1.Name = "lblTitulo1";
            lblTitulo1.Size = new Size(449, 57);
            lblTitulo1.TabIndex = 1;
            lblTitulo1.Text = "Sistema de Asistencia";
            // 
            // picMicrofono
            // 
            picMicrofono.BackColor = Color.Transparent;
            picMicrofono.Image = (Image)resources.GetObject("picMicrofono.Image");
            picMicrofono.Location = new Point(250, 179);
            picMicrofono.Name = "picMicrofono";
            picMicrofono.Size = new Size(449, 180);
            picMicrofono.SizeMode = PictureBoxSizeMode.Zoom;
            picMicrofono.TabIndex = 0;
            picMicrofono.TabStop = false;
            picMicrofono.Click += picMicrofono_Click;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1558, 746);
            Controls.Add(pnlFondo);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema de Asistencia Por Voz";
            pnlFondo.ResumeLayout(false);
            pnlFondo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picOndas).EndInit();
            ((System.ComponentModel.ISupportInitialize)picMicrofono).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlFondo;
        private PictureBox picMicrofono;
        private Label lblTitulo1;
        private Label lblTitulo2;
        private Label lblSubtitulo;
        private PictureBox picOndas;
        private Label lblBienvenido;
        private Label lblIniciar;
        private Label lblUsuario;
        private Label lblPassword;
        private CheckBox chkMostrarPassword;
        private LinkLabel lnkConfiguracion;
        private LinkLabel lnkCrearCuenta;
        private Label label1;
        private BotonesPersonalizados.Botones btnIniciarSesion;
        private Label lblrecordatorio;
        private Label lblayuda;
        private BotonesPersonalizados_y_Textbox.TxtPersonalizada txtUsuario;
        private BotonesPersonalizados_y_Textbox.TxtPersonalizada txtPassword;
    }
}