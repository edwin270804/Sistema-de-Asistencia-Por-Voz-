using FontAwesome.Sharp;
using ModernUI.Controls;
using SistemaAsistenciaPorVoz.BLL;
using SistemaAsistenciaPorVoz.Entity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaAsistenciaPorVoz.UI.Forms
{
    public partial class FrmPrincipal : Form
    {
        private readonly int _idProfesorActual;
        private readonly string _nombreProfesor;
        private Form? _formularioActivo = null;

        // ---------- Fuentes e imágenes -------------------------
        private static readonly Font FuenteNormal = new Font("Segoe UI", 10F, FontStyle.Regular);
        private static readonly Font FuenteBold = new Font("Segoe UI", 10F, FontStyle.Bold);
        private static readonly Font FuenteEncabezado = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
        private static readonly Font FuenteMensaje = new Font("Segoe UI", 11F, FontStyle.Regular);
        private static readonly Font FuenteTituloVacio = new Font("Segoe UI Semibold", 15F, FontStyle.Bold);
        private static Image? _imgEmptyClases;

        // ---------- Congelar / descongelar el dibujo de un control ----------
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int msg, bool wParam, int lParam);
        private const int WM_SETREDRAW = 0x000B;

        private static void Congelar(Control c)
        {
            if (c.IsHandleCreated) SendMessage(c.Handle, WM_SETREDRAW, false, 0);
        }

        private static void Descongelar(Control c)
        {
            if (!c.IsHandleCreated) return;
            SendMessage(c.Handle, WM_SETREDRAW, true, 0);
            c.Invalidate(true);
        }

        // ---------- Doble  real para el formulario y todos sus hijos ----------
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; 
                return cp;
            }
        }

        private static void HabilitarDobleBufer(Control control)
        {
            typeof(Control).GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.SetValue(control, true);
        }

        public FrmPrincipal(int idProfesor, string nombreProfesor)
        {
            InitializeComponent();
            _idProfesorActual = idProfesor;
            _nombreProfesor = nombreProfesor;

            this.DoubleBuffered = true;

            HabilitarDobleBufer(pnlContenedorClases);
            HabilitarDobleBufer(pnlDashboard);
            HabilitarDobleBufer(pnlContenedorPrincipal);
        }
        

        private async void FrmPrincipal_Load_1(object sender, EventArgs e)
        {
            ResaltarBotonMenu(btnInicio);

            lblBienvenido.Text = $"Bienvenido, Prof. {_nombreProfesor}";

            string fecha = DateTime.Now.ToString("dddd, dd MMM yyyy");
            lblFecha.Text = char.ToUpper(fecha[0]) + fecha.Substring(1);

            // Precarga los cursos en segundo plano mientras el usuario ve el dashboard
            new CursoBLL().Precargar(_idProfesorActual);

            await CargarDatosDashboardAsync();
        }

        private async Task CargarDatosDashboardAsync()
        {
            try
            {
                // Usa el caché: instantáneo si ya hay datos frescos, consulta la BD si no
                var tareaMetricas = DashboardCache.ObtenerMetricasAsync(_idProfesorActual);
                var tareaClases = DashboardCache.ListarClasesHoyAsync(_idProfesorActual);

                await Task.WhenAll(tareaMetricas, tareaClases);

                // El formulario pudo cerrarse mientras se consultaba la BD
                if (IsDisposed) return;

                DashboardMetricasEntity metricas = await tareaMetricas;
                List<ClaseHoyEntity> listaClases = await tareaClases;

                lblTitulo.Text = "Clases de Hoy";
                modernLabel4.Text = "Asistencia Promedio";
                modernLabel5.Text = "Alertas Criticas";

                lblNúmero.Text = metricas.ClasesHoy.ToString();
                lblNumAsistencia.Text = metricas.PorcentajeAsistencias.ToString("0.##") + "%";
                lblNumAlertas.Text = metricas.AlertaFaltas.ToString();

                decimal porcentaje = metricas.PorcentajeAsistencias;
                string porcentajeTexto = porcentaje.ToString("0.##") + "%";

                if (porcentaje >= 80m)
                {
                    lblEstadoAsistencia.Text = $"Por encima de la meta ({porcentajeTexto})";
                    lblEstadoAsistencia.ForeColor = Color.FromArgb(0, 220, 150);
                }
                else if (porcentaje >= 50m)
                {
                    lblEstadoAsistencia.Text = $"En rango aceptable ({porcentajeTexto})";
                    lblEstadoAsistencia.ForeColor = Color.FromArgb(250, 200, 50);
                }
                else
                {
                    lblEstadoAsistencia.Text = $"Por debajo de la meta ({porcentajeTexto})";
                    lblEstadoAsistencia.ForeColor = Color.FromArgb(255, 105, 110);
                }

                CargarClasesEnPanel(listaClases);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el panel principal: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarPanel(Control panel)
        {
            // Clear() NO libera los controles; hay que hacer Dispose uno por uno
            foreach (Control c in panel.Controls.Cast<Control>().ToList())
            {
                panel.Controls.Remove(c);
                c.Dispose();
            }
        }

        private void CargarClasesEnPanel(List<ClaseHoyEntity> listaClases)
        {
            Congelar(pnlContenedorClases);
            pnlContenedorClases.SuspendLayout();

            try
            {
                LimpiarPanel(pnlContenedorClases);

                int posY = 65;
                int anchoContenido = pnlContenedorClases.Width - 60;

                Panel pnlEncabezado = new Panel
                {
                    Size = new Size(anchoContenido, 40),
                    Location = new Point(30, posY),
                    BackColor = Color.Transparent
                };

                AgregarEtiquetaEncabezado(pnlEncabezado, "Hora", 10);
                AgregarEtiquetaEncabezado(pnlEncabezado, "Código", 150);
                AgregarEtiquetaEncabezado(pnlEncabezado, "Asignatura", 300);
                AgregarEtiquetaEncabezado(pnlEncabezado, "Sección", 600);
                AgregarEtiquetaEncabezado(pnlEncabezado, "Aula", 750);
                AgregarEtiquetaEncabezado(pnlEncabezado, "Acción", pnlEncabezado.Width - 120);

                pnlContenedorClases.Controls.Add(pnlEncabezado);
                posY += 45;

                Panel lineaHeader = new Panel
                {
                    Size = new Size(anchoContenido, 1),
                    Location = new Point(30, posY),
                    BackColor = Color.FromArgb(35, 48, 80)
                };
                pnlContenedorClases.Controls.Add(lineaHeader);
                posY += 10;

                if (listaClases.Count == 0)
                {
                    MostrarEstadoVacio(posY);
                    return;
                }

                foreach (var clase in listaClases)
                {
                    Panel pnlFila = new Panel
                    {
                        Size = new Size(anchoContenido, 55),
                        Location = new Point(30, posY),
                        BackColor = Color.Transparent
                    };

                    pnlFila.Controls.Add(CrearLabelFila(clase.Hora, 10, FuenteBold, Color.WhiteSmoke));
                    pnlFila.Controls.Add(CrearLabelFila(clase.Codigo, 150, FuenteBold, Color.DodgerBlue));
                    pnlFila.Controls.Add(CrearLabelFila(clase.Asignatura, 300, FuenteNormal, Color.WhiteSmoke));
                    pnlFila.Controls.Add(CrearLabelFila(clase.Seccion, 600, FuenteNormal, Color.DarkGray));
                    pnlFila.Controls.Add(CrearLabelFila(clase.Aula, 750, FuenteNormal, Color.DarkGray));

                    IconButton btnIniciar = new IconButton
                    {
                        Text = " Iniciar Clase",
                        IconChar = IconChar.Microphone,
                        IconColor = Color.White,
                        IconSize = 13,
                        TextImageRelation = TextImageRelation.ImageBeforeText,
                        ForeColor = Color.White,
                        BackColor = Color.DodgerBlue,
                        FlatStyle = FlatStyle.Flat,
                        Cursor = Cursors.Hand,
                        Size = new Size(165, 38),
                        Location = new Point(pnlFila.Width - 180, 9)
                    };
                    btnIniciar.FlatAppearance.BorderSize = 0;
                    btnIniciar.Tag = clase.IdCurso;

                    btnIniciar.Click += (s, e) =>
                    {
                        int idCursoSeleccionado = (int)((IconButton)s!).Tag!;
                        MessageBox.Show($"Iniciando asistencia por voz para el curso ID: {idCursoSeleccionado}",
                                        "Iniciar Clase", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    };

                    pnlFila.Controls.Add(btnIniciar);
                    pnlContenedorClases.Controls.Add(pnlFila);

                    posY += 60;

                    Panel lineaDivisoria = new Panel
                    {
                        Size = new Size(anchoContenido, 1),
                        Location = new Point(30, posY),
                        BackColor = Color.FromArgb(25, 35, 55)
                    };
                    pnlContenedorClases.Controls.Add(lineaDivisoria);

                    posY += 10;
                }
            }
            finally
            {
                pnlContenedorClases.ResumeLayout(true);
                Descongelar(pnlContenedorClases);
            }
        }

        private void MostrarEstadoVacio(int posY)
        {
            // Se carga una sola vez; Properties.Resources crea un Bitmap nuevo en cada acceso
            _imgEmptyClases ??= Properties.Resources.img_empty_clases;

            Panel pnlEmptyState = new Panel
            {
                Size = new Size(400, 320),
                BackColor = Color.Transparent
            };
            pnlEmptyState.Location = new Point(
                (pnlContenedorClases.Width - pnlEmptyState.Width) / 2,
                posY + 30);

            PictureBox picEmpty = new PictureBox
            {
                Size = new Size(200, 150),
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.Transparent,
                Image = _imgEmptyClases,
                Location = new Point((pnlEmptyState.Width - 200) / 2, 10)
            };
            pnlEmptyState.Controls.Add(picEmpty);

            IconPictureBox icoCheck = new IconPictureBox
            {
                IconChar = IconChar.CircleCheck,
                IconColor = Color.FromArgb(0, 220, 150),
                IconSize = 44,
                BackColor = Color.Transparent,
                Size = new Size(44, 44),
                Location = new Point((pnlEmptyState.Width - 44) / 2, picEmpty.Bottom + 12)
            };
            pnlEmptyState.Controls.Add(icoCheck);

            Label lblTitulo = new Label
            {
                Text = "¡Tienes el día libre!",
                ForeColor = Color.WhiteSmoke,
                Font = FuenteTituloVacio,
                AutoSize = false,
                Size = new Size(pnlEmptyState.Width, 32),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(0, icoCheck.Bottom + 8)
            };
            pnlEmptyState.Controls.Add(lblTitulo);

            Label lblMensaje = new Label
            {
                Text = "No hay clases programadas para hoy.",
                ForeColor = Color.FromArgb(180, 190, 210),
                Font = FuenteMensaje,
                AutoSize = false,
                Size = new Size(pnlEmptyState.Width, 26),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(0, lblTitulo.Bottom + 2)
            };
            pnlEmptyState.Controls.Add(lblMensaje);
            pnlContenedorClases.Controls.Add(pnlEmptyState);
        }

        private Label CrearLabelFila(string texto, int x, Font fuente, Color color)
        {
            return new Label
            {
                Text = texto,
                ForeColor = color,
                Font = fuente,
                Location = new Point(x, 16),
                AutoSize = true
            };
        }

        private void AgregarEtiquetaEncabezado(Panel contenedor, string texto, int coordenadaX)
        {
            Label lbl = new Label
            {
                Text = texto,
                ForeColor = Color.FromArgb(180, 190, 210),
                Font = FuenteEncabezado,
                Location = new Point(coordenadaX, 10),
                AutoSize = true
            };
            contenedor.Controls.Add(lbl);
        }

        private void CerrarFormularioActivo()
        {
            if (_formularioActivo != null)
            {
                Form formACerrar = _formularioActivo;
                _formularioActivo = null;
                formACerrar.Close();
                formACerrar.Dispose();
            }
        }

        private void AbrirFormularioEnPanel(Form frmHijo)
        {
            CerrarFormularioActivo();

            _formularioActivo = frmHijo;
            frmHijo.TopLevel = false;
            frmHijo.FormBorderStyle = FormBorderStyle.None;

            frmHijo.FormClosed += (s, e) =>
            {
                if (_formularioActivo == frmHijo)
                {
                    _formularioActivo = null;
                    MostrarDashboard();
                }
            };

            // Primero se agrega y se muestra el hijo; después se oculta el dashboard
            // (así nunca se ve un instante de fondo vacío).
            pnlContenedorPrincipal.Controls.Add(frmHijo);
            pnlContenedorPrincipal.Tag = frmHijo;
            frmHijo.Dock = DockStyle.Fill;
            frmHijo.Show();
            frmHijo.BringToFront();
            pnlDashboard.Visible = false;
        }

        private void MostrarDashboard()
        {
            CerrarFormularioActivo();

            pnlDashboard.Visible = true;
            pnlDashboard.BringToFront();
            ResaltarBotonMenu(btnInicio);
            _ = CargarDatosDashboardAsync();
        }

        private void ResaltarBotonMenu(IconButton botonActivo)
        {
            IconButton[] botones = { btnInicio, btnCursos, btnEstudiantes, btnReportes };
            foreach (var btn in botones)
            {
                if (btn == botonActivo)
                {
                    btn.BackColor = Color.FromArgb(26, 42, 74);
                    btn.IconColor = Color.DodgerBlue;
                }
                else
                {
                    btn.BackColor = Color.Transparent;
                    btn.IconColor = Color.WhiteSmoke;
                }
            }
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            MostrarDashboard();
        }

        private void btnCursos_Click_1(object sender, EventArgs e)
        {
            ResaltarBotonMenu(btnCursos);
            FrmCursos frmCursos = new FrmCursos(_idProfesorActual, _nombreProfesor);
            AbrirFormularioEnPanel(frmCursos);
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            ResaltarBotonMenu(btnEstudiantes);
            MessageBox.Show("El módulo de Reportes estará disponible próximamente.", "Reportes", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAjustes_Click(object sender, EventArgs e)
        {
            ResaltarBotonMenu(btnReportes);
            MessageBox.Show("El módulo de Ajustes estará disponible próximamente.", "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnExit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
        private void modernPanel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void pnlSideBar_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}