using SistemaAsistenciaPorVoz.BLL.Common;
using SistemaAsistenciaPorVoz.Entity;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SistemaAsistenciaPorVoz.UI.Forms
{
    public partial class FrmRegistro : Form
    {
        // ── Paleta de colores ──
        private readonly Color ColorAzul = Color.FromArgb(8, 123, 255);
        private readonly Color ColorAzulHover = Color.FromArgb(45, 145, 255);
        private readonly Color ColorTexto = Color.FromArgb(244, 247, 255);
        private readonly Color ColorSecundario = Color.FromArgb(145, 164, 199);

        // Radio de las esquinas del formulario
        private const int FormRadius = 30;

      

        public FrmRegistro()
        {
            InitializeComponent();
            ConfigurarFormulario();
            ConfigurarEventos();

            txtPassword.PlaceholderText = "  Ingresa tu Contraseña";
            txtConfirmarPassword.PlaceholderText = "  Confirma tu Contraseña";
            txtApellido.PlaceholderText = "  Ingresa tu Apellido";

            
            this.DoubleBuffered = true;
            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw,
                true
            );
            this.UpdateStyles();

            ActivarDobleBuffer(pnlFondo);

            pnlFondo.Paint -= pnlFondo_Paint;
            pnlFondo.Paint += pnlFondo_Paint;

            // Aplicar esquinas redondeadas al form
            AplicarRegionRedondeada();
        }



        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            AplicarRegionRedondeada();
        }

        private void AplicarRegionRedondeada()
        {
            using var path = new GraphicsPath();

            int r = FormRadius;
            int d = r * 2;
            var rect = new Rectangle(0, 0, Width, Height);

            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();

            this.Region = new Region(path);
        }

        // =========================================================
        // DOBLE BUFFER POR REFLEXIÓN
        // =========================================================

        private void ActivarDobleBuffer(Control control)
        {
            typeof(Control)
                .GetProperty(
                    "DoubleBuffered",
                    System.Reflection.BindingFlags.Instance |
                    System.Reflection.BindingFlags.NonPublic
                )
                ?.SetValue(control, true, null);
        }

     

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Pintamos SOLO el fondo degradado del form base
            using var brush = new LinearGradientBrush(
                this.ClientRectangle,
                Color.FromArgb(25, 45, 95),
                Color.FromArgb(8, 13, 28),
                LinearGradientMode.Vertical);

            e.Graphics.FillRectangle(brush, this.ClientRectangle);

            // Borde sutil alrededor del form (opcional, se ve premium)
            using var borderPen = new Pen(Color.FromArgb(80, 130, 170, 255), 1.5f);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.DrawPath(borderPen, ObtenerPathRedondeado());
        }

        private GraphicsPath ObtenerPathRedondeado()
        {
            var path = new GraphicsPath();
            int r = FormRadius;
            int d = r * 2;
            var rect = new Rectangle(0, 0, Width - 1, Height - 1);

            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();

            return path;
        }


        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.ActiveControl = lblTitulo;
        }

      

        private void ConfigurarFormulario()
        {
            pnlFondo.BackColor = Color.Transparent;

            txtPassword.PasswordChar = true;
            txtConfirmarPassword.PasswordChar = true;
            chkMostrarPassword.Checked = false;

            lblMensaje.ForeColor = ColorSecundario;

            btnRegistrar.BackColor = ColorAzul;
            btnRegistrar.ForeColor = Color.White;
            btnRegistrar.FlatStyle = FlatStyle.Flat;
            btnRegistrar.FlatAppearance.BorderSize = 0;
            btnRegistrar.Cursor = Cursors.Hand;
        }

       

        private void ConfigurarEventos()
        {
            chkMostrarPassword.CheckedChanged += ChkMostrarPassword_CheckedChanged;
            btnRegistrar.Click += BtnRegistrar_Click;
            btnRegistrar.MouseEnter += BtnRegistrar_MouseEnter;
            btnRegistrar.MouseLeave += BtnRegistrar_MouseLeave;
            lnkVolverLogin.LinkClicked += LnkVolverLogin_LinkClicked;

            txtUsuario.KeyDown += Txt_KeyDown;
            txtNombre.KeyDown += Txt_KeyDown;
            txtApellido.KeyDown += Txt_KeyDown;
            txtPassword.KeyDown += Txt_KeyDown;
            txtConfirmarPassword.KeyDown += Txt_KeyDown;
        }

        

        private void ChkMostrarPassword_CheckedChanged(
            object? sender,
            EventArgs e)
        {
            txtPassword.PasswordChar = !chkMostrarPassword.Checked;
            txtConfirmarPassword.PasswordChar = !chkMostrarPassword.Checked;
        }

      

        private void BtnRegistrar_Click(
            object? sender,
            EventArgs e)
        {
            Registrar();
        }

        private void Registrar()
        {
            string usuario = txtUsuario.Texts.Trim();
            string nombre = txtNombre.Texts.Trim();
            string apellido = txtApellido.Texts.Trim();
            string password = txtPassword.Texts;
            string confirmar = txtConfirmarPassword.Texts;

            lblMensaje.ForeColor = ColorSecundario;

            if (password != confirmar)
            {
                MostrarError("Las contraseñas no coinciden.");
                txtConfirmarPassword.Texts = "";
                txtConfirmarPassword.Focus();
                return;
            }

            try
            {
                UsuarioEntity nuevoUsuario = new UsuarioEntity(usuario, password, nombre, apellido);

                UsuarioBLL usuarioBLL = new UsuarioBLL();

                int nuevoId = usuarioBLL.RegistrarUsuario(nuevoUsuario);

                if (nuevoId > 0)
                {
                    lblMensaje.ForeColor = Color.FromArgb(0, 220, 150);
                    lblMensaje.Text = "¡Cuenta creada exitosamente!";

                    MessageBox.Show(
                        "Su cuenta ha sido creada exitosamente.\nAhora puede iniciar sesión.",
                        "Registro exitoso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    this.Close();
                }
                else
                {
                    MostrarError("No se pudo crear la cuenta. Intente de nuevo.");
                }
            }
            catch (ArgumentException ex)
            {
                MostrarError(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ocurrió un error al registrar:\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =========================================================
        // ENTER PARA REGISTRAR
        // =========================================================

        private void Txt_KeyDown(
            object? sender,
            KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Registrar();
            }
        }

       

        private void BtnRegistrar_MouseEnter(
            object? sender,
            EventArgs e)
        {
            btnRegistrar.BackColor = ColorAzulHover;
        }

        private void BtnRegistrar_MouseLeave(
            object? sender,
            EventArgs e)
        {
            btnRegistrar.BackColor = ColorAzul;
        }

       

        private void MostrarError(string mensaje)
        {
            lblMensaje.ForeColor = Color.FromArgb(255, 105, 110);
            lblMensaje.Text = mensaje;
        }



        private void LnkVolverLogin_LinkClicked(
            object? sender,
            LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void lblCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblCerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblCerrar_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPassword__TextChanged(object sender, EventArgs e)
        {
        }

    

        private void pnlFondo_Paint(object? sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            var rect = new Rectangle(0, 0, pnlFondo.Width - 1, pnlFondo.Height - 1);
            int radius = 24;
            int d = radius * 2;

            using var path = new GraphicsPath();
            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();

            // Relleno glass azulado
            using (var brush = new LinearGradientBrush(
                rect,
                Color.FromArgb(90, 100, 150, 220),
                Color.FromArgb(40, 50, 90, 160),
                LinearGradientMode.Vertical))
            {
                e.Graphics.FillPath(brush, path);
            }

            // Borde glass
            using (var pen = new Pen(Color.FromArgb(50, 130, 170, 255), 1f))
            {
                e.Graphics.DrawPath(pen, path);
            }
        }

        private void lblCerrar_Click_3(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}