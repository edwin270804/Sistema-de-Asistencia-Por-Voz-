using SistemaAsistenciaPorVoz.BLL.Common;
using SistemaAsistenciaPorVoz.DAL;
using SistemaAsistenciaPorVoz.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;



namespace SistemaAsistenciaPorVoz.UI
{
    public partial class FrmConfigurarConexion : Form
    {
        private readonly ConexionBLL conexionBLL = new();
        private readonly ConfiguracionDAL configuracionDAL = new();
        private Panel panelLateral;
        private Panel panelPrincipal;
        private Panel panelContenido;

        private Label lblTitulo;
        private Label lblSubtitulo;

        private Label lblServidor;
        private Label lblBaseDatos;
        private Label lblUsuario;
        private Label lblPassword;

        private TextBox txtServidor;
        private TextBox txtBaseDatos;
        private TextBox txtUsuario;
        private TextBox txtPassword;

        private Button btnProbar;
        private Button btnGuardar;

        private Label lblEstado;
        private Label lblEstadoDetalle;

        public FrmConfigurarConexion()
        {
            InitializeComponent();
            CrearInterfaz();
            ConfigurarFormulario();
            this.ActiveControl = null;

        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.ActiveControl = null; 
        }


        // Configuracion del formulario
        private void ConfigurarFormulario()
        {
            Text = "Sistema de Asistencia por Voz - Configuración";
            StartPosition = FormStartPosition.CenterScreen;
            MinimumSize = new Size(1000, 620);
            MaximizeBox = false;
            MinimizeBox = false;
            BackColor = Color.FromArgb(248, 250, 252);
            Font = new Font("Segoe UI", 10, FontStyle.Regular);
        }

        // Interfaz
        private void CrearInterfaz()
        {
            CrearPanelPrincipal();
            CrearPanelLateral();
            CrearTitulo();
            CrearCampos();
            CrearBotones();
            CrearEstado();
        }

        // panel izquierdo
        private void CrearPanelLateral()
        {
            panelLateral = new Panel
            {
                Dock = DockStyle.Left,
                Width = 350,
                BackColor = Color.FromArgb(15, 23, 42)
            };
            Controls.Add(panelLateral);

            // Contenedor interno para centrar el texto del panel
            Panel panelContenidoLateral = new Panel
            {
                Width = 350,
                Height = 630
            };
            panelLateral.Controls.Add(panelContenidoLateral);

            panelLateral.Resize += (s, e) =>
            {
                panelContenidoLateral.Top = (panelLateral.Height - panelContenidoLateral.Height) / 2;
            };

            Label lblLogo = new Label
            {
                Text = "🎙",
                Font = new Font("Segoe UI Emoji", 65, FontStyle.Regular),
                ForeColor = Color.White,
                AutoSize = false,
                Width = 350,
                Height = 160,
                TextAlign = ContentAlignment.MiddleCenter,
                UseCompatibleTextRendering = true,
                Location = new Point(0, 30)
            };
            panelContenidoLateral.Controls.Add(lblLogo);

            Label lblNombre = new Label
            {
                Text = "ASISTENCIA\nPOR VOZ",
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = false,
                Width = 350,
                Height = 100,
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(0, 190)
            };
            panelContenidoLateral.Controls.Add(lblNombre);

            Label lblDescripcion = new Label
            {
                Text = "Configuración segura de\nbase de datos y servidor\npara el reconocimiento\nde voz.",
                Font = new Font("Segoe UI", 12, FontStyle.Regular),
                ForeColor = Color.FromArgb(148, 163, 184),
                AutoSize = false,
                Width = 350,
                Height = 110,
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(0, 300)
            };
            panelContenidoLateral.Controls.Add(lblDescripcion);

            Label lblVersion = new Label
            {
                Text = "Sistema de Asistencia Voz • v1.0",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.FromArgb(100, 116, 139),
                AutoSize = false,
                Width = 350,
                Height = 30,
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(0, 550)
            };
            panelContenidoLateral.Controls.Add(lblVersion);
        }

        private void CrearPanelPrincipal()
        {
            panelPrincipal = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(248, 250, 252)
            };
            Controls.Add(panelPrincipal);

            panelContenido = new Panel
            {
                Width = 580,
                Height = 548
            };
            panelPrincipal.Controls.Add(panelContenido);

            panelPrincipal.Resize += (s, e) =>
            {
                panelContenido.Left = (panelPrincipal.Width - panelContenido.Width) / 2;
                panelContenido.Top = (panelPrincipal.Height - panelContenido.Height) / 2;
            };
        }

        private void CrearTitulo()
        {
            lblTitulo = new Label
            {
                Text = "Configuración de conexión",
                Font = new Font("Segoe UI", 26, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 41, 59),
                AutoSize = true,
                UseCompatibleTextRendering = true,
                Location = new Point(0, 0)
            };
            panelContenido.Controls.Add(lblTitulo);

            lblSubtitulo = new Label
            {
                Text = "Ingresa las credenciales de tu servidor SQL Server para enlazar el sistema.",
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                ForeColor = Color.FromArgb(100, 116, 139),
                AutoSize = true,
                UseCompatibleTextRendering = true,
                MaximumSize = new Size(600, 0),
                Location = new Point(4, 65)
            };
            panelContenido.Controls.Add(lblSubtitulo);
        }

        private void CrearCampos()
        {
            lblServidor = CrearEtiqueta("Servidor", 0, 100);
            txtServidor = CrearTextBox(0, 125);
            txtServidor.PlaceholderText = " Ingresa tu Servidor de SQL";

            lblBaseDatos = CrearEtiqueta("Base de datos", 0, 180);
            txtBaseDatos = CrearTextBox(0, 205);
            txtBaseDatos.PlaceholderText = " Ingresa el nombre de tu base de datos";

            lblUsuario = CrearEtiqueta("Usuario SQL", 0, 260);
            txtUsuario = CrearTextBox(0, 285);
            txtUsuario.PlaceholderText = " Ingresa tu usuario de SQL";

            lblPassword = CrearEtiqueta("Contraseña", 0, 340);
            txtPassword = CrearTextBox(0, 365);
            txtPassword.PlaceholderText = " Ingresa tu contraseña";
            txtPassword.UseSystemPasswordChar = true;
        }
        private Label CrearEtiqueta(
            string texto,
            int x,
            int y)
        {
            Label label = new Label
            {
                Text = texto.ToUpper(),
                Font = new Font("Segoe UI", 8.5f, FontStyle.Bold),
                ForeColor = Color.FromArgb(71, 85, 105),
                AutoSize = true,
                Location = new Point(x, y)
            };
            panelContenido.Controls.Add(label);
            return label;
        }

        private TextBox CrearTextBox(
            int x,
            int y)
        {
            TextBox textBox = new TextBox
            {
                Width = 530,
                Font = new Font("Segoe UI", 12),
                Location = new Point(x, y),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
                ForeColor = Color.FromArgb(15, 23, 42)
            };
            panelContenido.Controls.Add(textBox);
            return textBox;
        }

        private void CrearBotones()
        {
            btnProbar = new Button
            {
                Text = "Probar Conexión",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(37, 99, 235),
                FlatStyle = FlatStyle.Flat,
                Size = new Size(255, 48),
                Location = new Point(0, 430),
                Cursor = Cursors.Hand
            };
            btnProbar.FlatAppearance.BorderSize = 0;
            btnProbar.MouseEnter += (s, e) => btnProbar.BackColor = Color.FromArgb(29, 78, 216);
            btnProbar.MouseLeave += (s, e) => btnProbar.BackColor = Color.FromArgb(37, 99, 235);
            btnProbar.Click += BtnProbar_Click;
            panelContenido.Controls.Add(btnProbar);

            btnGuardar = new Button
            {
                Text = "Guardar y Continuar",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(16, 185, 129),
                FlatStyle = FlatStyle.Flat,
                Size = new Size(255, 48),
                Location = new Point(275, 430),
                Cursor = Cursors.Hand,
                Enabled = false
            };
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.MouseEnter += (s, e) => { if (btnGuardar.Enabled) btnGuardar.BackColor = Color.FromArgb(5, 150, 105); };
            btnGuardar.MouseLeave += (s, e) => { if (btnGuardar.Enabled) btnGuardar.BackColor = Color.FromArgb(16, 185, 129); };
            btnGuardar.EnabledChanged += (s, e) =>
            {
                btnGuardar.BackColor = btnGuardar.Enabled ? Color.FromArgb(16, 185, 129) : Color.FromArgb(148, 163, 184);
            };
            btnGuardar.Click += BtnGuardar_Click;
            panelContenido.Controls.Add(btnGuardar);
        }

        private void BtnGuardar_Click(object? sender, EventArgs e)
        {
            ConexionEntity config = new()
            {
                Servidor = txtServidor.Text.Trim(),

                BaseDatos = txtBaseDatos.Text.Trim(),

                UsuarioSql = txtUsuario.Text.Trim(),

                Password = txtPassword.Text
            };

            bool resultado =
                configuracionDAL.Guardar(config);

            if (!resultado)
            {
                MessageBox.Show(
                    "No fue posible guardar la configuración.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }

            MessageBox.Show(
                "La configuración se guardó correctamente.",
                "Configuración",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            DialogResult = DialogResult.OK;

            Close();
        }

        private void CrearEstado()
        {
            lblEstado = new Label
            {
                Text = "●  SIN COMPROBAR",
                Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                ForeColor = Color.FromArgb(245, 158, 11),
                AutoSize = true,
                Location = new Point(0, 495)
            };
            panelContenido.Controls.Add(lblEstado);

            lblEstadoDetalle = new Label
            {
                Text = "Realiza una prueba de conexión para habilitar el guardado.",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.FromArgb(100, 116, 139),
                AutoSize = true,
                Location = new Point(0, 520)
            };
            panelContenido.Controls.Add(lblEstadoDetalle);
        }
        private async void BtnProbar_Click(
                    object? sender,
                    EventArgs e)
        {
            if (!ValidarCampos())
                return;

            btnProbar.Enabled = false;

            lblEstado.Text = "COMPROBANDO...";

            lblEstado.ForeColor =
                Color.FromArgb(220, 150, 40);

            lblEstadoDetalle.Text =
                "Intentando conectar con SQL Server...";

            bool conectado =
                await conexionBLL.ProbarConexion(
                    txtServidor.Text.Trim(),
                    txtBaseDatos.Text.Trim(),
                    txtUsuario.Text.Trim(),
                    txtPassword.Text
                );

            if (conectado)
            {
                lblEstado.Text = "CONEXIÓN EXITOSA";

                lblEstado.ForeColor =
                    Color.FromArgb(35, 160, 100);

                lblEstadoDetalle.Text =
                    "El sistema pudo conectarse correctamente.";

                btnGuardar.Enabled = true;
            }
            else
            {
                lblEstado.Text = "●  CONEXIÓN FALLIDA";

                lblEstado.ForeColor =
                    Color.FromArgb(210, 60, 60);

                lblEstadoDetalle.Text =
                    "No fue posible conectar con SQL Server.";

                btnGuardar.Enabled = false;
            }

            btnProbar.Enabled = true;
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtServidor.Text))
            {
                MessageBox.Show(
                    "Debe especificar el servidor.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtServidor.Focus();

                return false;
            }

            if (string.IsNullOrWhiteSpace(txtBaseDatos.Text))
            {
                MessageBox.Show(
                    "Debe especificar la base de datos.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtBaseDatos.Focus();

                return false;
            }

            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                MessageBox.Show(
                    "Debe especificar el usuario SQL.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtUsuario.Focus();

                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show(
                    "Debe especificar la contraseña.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtPassword.Focus();

                return false;
            }

            return true;
        }

        private void FrmConfigurarConexion_Load(object sender, EventArgs e)
        {
            
        }
    }
}
