using SistemaAsistenciaPorVoz.BLL;
using SistemaAsistenciaPorVoz.BLL.Common;
using SistemaAsistenciaPorVoz.Entity;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaAsistenciaPorVoz.UI.Forms
{
    public partial class FrmLogin : Form
    {
        // ── Paleta de colores ──
        private readonly Color ColorAzul = Color.FromArgb(8, 123, 255);
        private readonly Color ColorAzulHover = Color.FromArgb(45, 145, 255);
        private readonly Color ColorTexto = Color.FromArgb(244, 247, 255);
        private readonly Color ColorSecundario = Color.FromArgb(145, 164, 199);

        private static readonly Color ColorTransparente = Color.FromArgb(255, 0, 255);

        private const int FormRadius = 28;

        // Evita doble clic / Enter repetido mientras se verifica el login
        private bool _iniciandoSesion = false;

        public FrmLogin()
        {
            InitializeComponent();
            ConfigurarFormulario();
            ConfigurarEventos();

            txtPassword.PlaceholderText = " Ingrese su Contraseña";

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

            this.TransparencyKey = ColorTransparente;
            this.BackColor = ColorTransparente;
        }

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

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            var rect = new Rectangle(0, 0, Width - 1, Height - 1);
            using var path = ObtenerPathRedondeado(rect, FormRadius);

            using (var clearBrush = new SolidBrush(ColorTransparente))
            {
                e.Graphics.FillRectangle(clearBrush, this.ClientRectangle);
            }

            using (var brush = new LinearGradientBrush(
                rect,
                Color.FromArgb(12, 20, 40),
                Color.FromArgb(8, 13, 28),
                LinearGradientMode.Vertical))
            {
                e.Graphics.FillPath(brush, path);
            }

            using var borderPen = new Pen(Color.FromArgb(120, 100, 140, 220), 1.5f);
            e.Graphics.DrawPath(borderPen, path);
        }

        private GraphicsPath ObtenerPathRedondeado(Rectangle rect, int radius)
        {
            var path = new GraphicsPath();
            int d = radius * 2;

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
            this.ActiveControl = lblTitulo1;
        }

        private void ConfigurarFormulario()
        {
            pnlFondo.BackColor = Color.Transparent;

            txtPassword.PasswordChar = true;
            chkMostrarPassword.Checked = false;

            lblrecordatorio.ForeColor = ColorSecundario;

            btnIniciarSesion.BackColor = ColorAzul;
            btnIniciarSesion.ForeColor = Color.White;
            btnIniciarSesion.FlatStyle = FlatStyle.Flat;
            btnIniciarSesion.FlatAppearance.BorderSize = 0;
            btnIniciarSesion.Cursor = Cursors.Hand;

            lnkConfiguracion.Cursor = Cursors.Hand;
        }

       
        // EVENTOS
        private void ConfigurarEventos()
        {
            this.Resize += FrmLogin_Resize;

            chkMostrarPassword.CheckedChanged += ChkMostrarPassword_CheckedChanged;
            btnIniciarSesion.Click += BtnIniciarSesion_Click;
            btnIniciarSesion.MouseEnter += BtnIniciarSesion_MouseEnter;
            btnIniciarSesion.MouseLeave += BtnIniciarSesion_MouseLeave;

            lnkConfiguracion.LinkClicked += LnkConfiguracion_LinkClicked;
            lnkCrearCuenta.LinkClicked += LnkCrearCuenta_LinkClicked;

            txtUsuario.KeyDown += Txt_KeyDown;
            txtPassword.KeyDown += Txt_KeyDown;
        }

        private void FrmLogin_Resize(object? sender, EventArgs e)
        {
            this.Invalidate(); // forzar repintado al redimensionar
        }

       
        // MOSTRAR / OCULTAR CONTRASEÑA
        private void ChkMostrarPassword_CheckedChanged(
            object? sender,
            EventArgs e)
        {
            txtPassword.PasswordChar = !chkMostrarPassword.Checked;
            txtPassword.Focus();
            txtPassword.SelectionStart = txtPassword.Texts.Length;
        }

        
        // BOTÓN INICIAR SESIÓN
        private async void BtnIniciarSesion_Click(
            object? sender,
            EventArgs e)
        {
            await IniciarSesionAsync();
        }

        private async Task IniciarSesionAsync()
        {
            if (_iniciandoSesion) return;

            string usuario = txtUsuario.Texts.Trim();
            string password = txtPassword.Texts;

            lblrecordatorio.ForeColor = ColorSecundario;

            try
            {
                UsuarioEntity usuarioLogin = new UsuarioEntity(usuario, password);

                _iniciandoSesion = true;
                lblrecordatorio.Text = "Verificando...";

                UsuarioBLL usuarioBLL = new UsuarioBLL();

                // Hash + consulta a la BD en segundo plano: la ventana no se congela
                UsuarioEntity? usuarioLogueado =
                    await Task.Run(() => usuarioBLL.IniciarSesion(usuarioLogin));

                if (usuarioLogueado == null)
                {
                    MostrarError("Usuario o contraseña incorrectos.");
                    txtPassword.Texts = "";
                    txtPassword.Focus();
                    return;
                }

                lblrecordatorio.ForeColor = Color.FromArgb(0, 220, 150);
                lblrecordatorio.Text = $"Bienvenido, {usuarioLogueado.NombreCompleto}";

                int idProfesorLogueado = usuarioLogueado.IdProfesor;
                string nombreReal = usuarioLogueado.NombreCompleto;

                // Precarga en segundo plano mientras se construye y abre el FrmPrincipal
                DashboardCache.Precargar(idProfesorLogueado);
                new CursoBLL().Precargar(idProfesorLogueado);

                // LE PASO EL NOMBRE AL FRM
                FrmPrincipal frmPrincipal = new FrmPrincipal(idProfesorLogueado, nombreReal);

                this.Hide();

                frmPrincipal.FormClosed += (s, e) =>
                {
                    this.Close();
                };

                frmPrincipal.Show();
            }
            catch (ArgumentException ex)
            {
                MostrarError(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ocurrió un error al iniciar sesión:\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                _iniciandoSesion = false;
            }
        }

        private void Txt_KeyDown(
            object? sender,
            KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                _ = IniciarSesionAsync();
            }
        }

        private void BtnIniciarSesion_MouseEnter(
            object? sender,
            EventArgs e)
        {
            btnIniciarSesion.BackColor = ColorAzulHover;
        }

        private void BtnIniciarSesion_MouseLeave(
            object? sender,
            EventArgs e)
        {
            btnIniciarSesion.BackColor = ColorAzul;
        }

        private void MostrarError(string mensaje)
        {
            lblrecordatorio.ForeColor = Color.FromArgb(255, 105, 110);
            lblrecordatorio.Text = mensaje;
        }

        private void LnkConfiguracion_LinkClicked(
            object? sender,
            LinkLabelLinkClickedEventArgs e)
        {
            using FrmConfigurarConexion frm = new FrmConfigurarConexion();
            frm.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void picMicrofono_Click(object sender, EventArgs e)
        {
        }

        private void LnkCrearCuenta_LinkClicked(
            object? sender,
            LinkLabelLinkClickedEventArgs e)
        {
            FrmRegistro frm = new FrmRegistro();

            this.Hide();

            frm.FormClosed += (s, args) =>
            {
                this.Show();
            };

            frm.Show();
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

            using (var brush = new LinearGradientBrush(
                rect,
                Color.FromArgb(70, 40, 70, 130),
                Color.FromArgb(35, 20, 30, 70),
                LinearGradientMode.Vertical))
            {
                e.Graphics.FillPath(brush, path);
            }

            using (var hlBrush = new LinearGradientBrush(
                new Rectangle(rect.X, rect.Y, rect.Width, 70),
                Color.FromArgb(60, 255, 255, 255),
                Color.FromArgb(0, 255, 255, 255),
                LinearGradientMode.Vertical))
            {
                using var hlPath = new GraphicsPath();
                int hd = radius * 2;
                var hlRect = new Rectangle(rect.X, rect.Y, rect.Width, 70);

                hlPath.AddArc(hlRect.X, hlRect.Y, hd, hd, 180, 90);
                hlPath.AddArc(hlRect.Right - hd, hlRect.Y, hd, hd, 270, 90);
                hlPath.AddLine(hlRect.Right, hlRect.Bottom, hlRect.X, hlRect.Bottom);
                hlPath.CloseFigure();

                e.Graphics.FillPath(hlBrush, hlPath);
            }

            using (var pen = new Pen(Color.FromArgb(100, 120, 160, 230), 1.3f))
            {
                e.Graphics.DrawPath(pen, path);
            }
        }
    }
}