using FontAwesome.Sharp;
using SistemaAsistenciaPorVoz.BLL;
using SistemaAsistenciaPorVoz.Entity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaAsistenciaPorVoz.UI.Forms
{
    public partial class FrmCursos : Form
    {
        private readonly int _idProfesorActual;
        private readonly string _nombreProfesor;
        private readonly CursoBLL _cursoBLL = new CursoBLL();

        public class CursoVisualItem
        {
            public int IdCurso { get; set; }
            public string Codigo { get; set; } = string.Empty;
            public string Nombre { get; set; } = string.Empty;
            public string Descripcion { get; set; } = string.Empty;
            public int Estudiantes { get; set; }
        }

        // Fila reutilizable: se crea una vez y solo se cambia el texto
        private class FilaCurso
        {
            public Panel Panel = null!;
            public Label Codigo = null!;
            public Label Nombre = null!;
            public Label Descripcion = null!;
            public Label Estudiantes = null!;
            public Panel Divisor = null!;
        }

        private List<CursoVisualItem> _todosLosCursos = new List<CursoVisualItem>();
        private readonly List<FilaCurso> _filas = new List<FilaCurso>();
        private int _paginaActual = 1;
        private const int _elementosPorPagina = 7;
        private const int _alturaFila = 54;
        private int _totalPaginas = 1;

        // Colores y fuentes 
        private static readonly Color ColorHover = Color.FromArgb(18, 28, 54);
        private static readonly Font FuenteCodigo = new Font("Segoe UI", 10.2f, FontStyle.Bold);
        private static readonly Font FuenteNormal = new Font("Segoe UI", 10f, FontStyle.Regular);
        private static readonly Font FuenteHeader = new Font("Segoe UI Semibold", 10.5f, FontStyle.Bold);
        private static readonly Font FuentePagina = new Font("Segoe UI", 9.5f);
        private static readonly Font FuentePaginaBold = new Font("Segoe UI Semibold", 9.5f, FontStyle.Bold);

        // Controles de estructura
        private Panel pnlHeaderTabla = null!;
        private Panel lineaHeader = null!;
        private Panel pnlFilasCursos = null!;
        private Panel pnlPaginacion = null!;

        // Controles de paginación
        private IconButton btnPaginaAnterior = null!;
        private IconButton btnPaginaSiguiente = null!;
        private Label lblNumeroPaginaBadge = null!;
        private Label lblTotalPaginasTexto = null!;
        private Label lblPaginaTexto = null!;

        // Doble búfer : Windows pinta el formulario y todos sus hijos en un búfer
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; 
                return cp;
            }
        }

        public FrmCursos(int idProfesor, string nombreProfesor)
        {
            InitializeComponent();
            _idProfesorActual = idProfesor;
            _nombreProfesor = nombreProfesor;

            lblBienvenidoCurso.Text = $"Bienvenido, Prof. {_nombreProfesor}";

            string fecha = DateTime.Now.ToString("dddd, dd MMM yyyy");
            lblFecha.Text = char.ToUpper(fecha[0]) + fecha.Substring(1);

            this.BackColor = Color.FromArgb(10, 17, 40);
            this.DoubleBuffered = true;

            InicializarEstructuraTabla();

            this.Load += FrmCursos_Load;
        }

        private async void FrmCursos_Load(object? sender, EventArgs e)
        {
            await CargarCursosAsync();
        }

        private void InicializarEstructuraTabla()
        {
            pnlContedorTabla.Controls.Clear();
            HabilitarDobleBufer(pnlContedorTabla);

            pnlContedorTabla.BackColor = Color.FromArgb(22, 32, 54);

            pnlContedorTabla.SuspendLayout();

            pnlHeaderTabla = new Panel
            {
                Dock = DockStyle.Top,
                Height = 48,
                BackColor = Color.Transparent
            };
            ConstruirColumnasHeader(); 

            lineaHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 1,
                BackColor = Color.FromArgb(28, 40, 68)
            };

            pnlPaginacion = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 52,
                BackColor = Color.Transparent
            };
            ConstruirPaginador();
            pnlPaginacion.Resize += (s, e) => AlinearControlesPaginacion();

            pnlFilasCursos = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent,
                AutoScroll = false
            };
            HabilitarDobleBufer(pnlFilasCursos);
            pnlFilasCursos.Resize += (s, e) => AjustarAnchoFilas();

            CrearFilas();

            
            pnlContedorTabla.Controls.Add(pnlFilasCursos);
            pnlContedorTabla.Controls.Add(pnlPaginacion);
            pnlContedorTabla.Controls.Add(lineaHeader);
            pnlContedorTabla.Controls.Add(pnlHeaderTabla);

            pnlContedorTabla.ResumeLayout(true);
        }

        private void ConstruirColumnasHeader()
        {
            AgregarColumnaLabel(pnlHeaderTabla, "Código", 35);
            AgregarColumnaLabel(pnlHeaderTabla, "Nombre del Curso", 175);
            AgregarColumnaLabel(pnlHeaderTabla, "Descripción", 490);
            AgregarColumnaLabel(pnlHeaderTabla, "Estudiantes", 1000);
        }

        private void AgregarColumnaLabel(Panel contenedor, string texto, int x)
        {
            Label lbl = new Label
            {
                Text = texto,
                ForeColor = Color.FromArgb(160, 175, 205),
                Font = FuenteHeader,
                Location = new Point(x, 14),
                AutoSize = true,
                BackColor = Color.Transparent
            };
            contenedor.Controls.Add(lbl);
        }

        
        // FILAS REUTILIZABLES
        private void CrearFilas()
        {
            int ancho = pnlFilasCursos.Width > 0 ? pnlFilasCursos.Width : 1000;

            for (int i = 0; i < _elementosPorPagina; i++)
            {
                var fila = new FilaCurso();

                fila.Panel = new Panel
                {
                    Size = new Size(ancho, _alturaFila),
                    Location = new Point(0, i * _alturaFila),
                    BackColor = Color.Transparent,
                    Visible = false
                };

                fila.Codigo = CrearLabel(35, FuenteCodigo, Color.FromArgb(59, 130, 246));
                fila.Nombre = CrearLabel(175, FuenteNormal, Color.WhiteSmoke);
                fila.Descripcion = CrearLabel(490, FuenteNormal, Color.FromArgb(148, 163, 184));
                fila.Estudiantes = CrearLabel(1035, FuenteNormal, Color.FromArgb(203, 213, 225));

                fila.Divisor = new Panel
                {
                    Size = new Size(Math.Max(100, ancho - 50), 1),
                    Location = new Point(25, _alturaFila - 1),
                    BackColor = Color.FromArgb(22, 34, 58)
                };

                fila.Panel.Controls.AddRange(new Control[]
                {
                    fila.Codigo, fila.Nombre, fila.Descripcion, fila.Estudiantes, fila.Divisor
                });

                
                var panelFila = fila.Panel;
                void Entrar(object? s, EventArgs e) => panelFila.BackColor = ColorHover;
                void Salir(object? s, EventArgs e)
                {
                    Point p = panelFila.PointToClient(Cursor.Position);
                    if (!panelFila.ClientRectangle.Contains(p))
                        panelFila.BackColor = Color.Transparent;
                }

                foreach (Control c in new Control[] { panelFila, fila.Codigo, fila.Nombre, fila.Descripcion, fila.Estudiantes })
                {
                    c.MouseEnter += Entrar;
                    c.MouseLeave += Salir;
                }

                pnlFilasCursos.Controls.Add(fila.Panel);
                _filas.Add(fila);
            }
        }

        private Label CrearLabel(int x, Font fuente, Color color)
        {
            return new Label
            {
                Font = fuente,
                ForeColor = color,
                Location = new Point(x, 16),
                AutoSize = true,
                BackColor = Color.Transparent
            };
        }

        // PAGINADOR
        private void ConstruirPaginador()
        {
            pnlPaginacion.Controls.Clear();

            btnPaginaAnterior = new IconButton
            {
                IconChar = IconChar.ChevronLeft,
                IconSize = 13,
                IconColor = Color.FromArgb(110, 130, 170),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Size = new Size(30, 30),
                BackColor = Color.Transparent
            };
            btnPaginaAnterior.FlatAppearance.BorderSize = 0;
            btnPaginaAnterior.FlatAppearance.MouseOverBackColor = Color.FromArgb(28, 42, 75);
            btnPaginaAnterior.Click += (s, e) =>
            {
                if (_paginaActual > 1)
                {
                    _paginaActual--;
                    RenderizarPagina();
                }
            };

            lblPaginaTexto = new Label
            {
                Text = "Página",
                ForeColor = Color.FromArgb(140, 160, 195),
                Font = FuentePagina,
                AutoSize = true,
                BackColor = Color.Transparent
            };

            lblNumeroPaginaBadge = new Label
            {
                Text = "1",
                ForeColor = Color.White,
                Font = FuentePaginaBold,
                BackColor = Color.FromArgb(26, 42, 76),
                Size = new Size(34, 26),
                TextAlign = ContentAlignment.MiddleCenter
            };

            lblTotalPaginasTexto = new Label
            {
                Text = "de 1",
                ForeColor = Color.FromArgb(140, 160, 195),
                Font = FuentePagina,
                AutoSize = true,
                BackColor = Color.Transparent
            };

            btnPaginaSiguiente = new IconButton
            {
                IconChar = IconChar.ChevronRight,
                IconSize = 13,
                IconColor = Color.FromArgb(150, 175, 220),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Size = new Size(30, 30),
                BackColor = Color.Transparent
            };
            btnPaginaSiguiente.FlatAppearance.BorderSize = 0;
            btnPaginaSiguiente.FlatAppearance.MouseOverBackColor = Color.FromArgb(28, 42, 75);
            btnPaginaSiguiente.Click += (s, e) =>
            {
                if (_paginaActual < _totalPaginas)
                {
                    _paginaActual++;
                    RenderizarPagina();
                }
            };

            pnlPaginacion.Controls.Add(btnPaginaAnterior);
            pnlPaginacion.Controls.Add(lblPaginaTexto);
            pnlPaginacion.Controls.Add(lblNumeroPaginaBadge);
            pnlPaginacion.Controls.Add(lblTotalPaginasTexto);
            pnlPaginacion.Controls.Add(btnPaginaSiguiente);

            AlinearControlesPaginacion();
        }

        private void AlinearControlesPaginacion()
        {
            if (pnlPaginacion == null || btnPaginaAnterior == null) return;

            int totalAncho = 30 + 10 + lblPaginaTexto.Width + 8 + 34 + 8 + lblTotalPaginasTexto.Width + 10 + 30;
            int startX = Math.Max(10, (pnlPaginacion.Width - totalAncho) / 2);
            int y = (pnlPaginacion.Height - 30) / 2;

            btnPaginaAnterior.Location = new Point(startX, y);
            startX += 30 + 10;

            lblPaginaTexto.Location = new Point(startX, y + 5);
            startX += lblPaginaTexto.Width + 8;

            lblNumeroPaginaBadge.Location = new Point(startX, y + 2);
            startX += lblNumeroPaginaBadge.Width + 8;

            lblTotalPaginasTexto.Location = new Point(startX, y + 5);
            startX += lblTotalPaginasTexto.Width + 10;

            btnPaginaSiguiente.Location = new Point(startX, y);
        }

        
        // CARGA DE DATOS síncrona: no bloquea el pintado del formulario
        private async Task CargarCursosAsync(bool forzar = false)
        {
            try
            {
                var cursosBD = await _cursoBLL.ListarPorProfesorAsync(_idProfesorActual, forzar);

                // El formulario pudo cerrarse mientras se consultaba la BD
                if (IsDisposed) return;

                _todosLosCursos = (cursosBD ?? new List<CursoEntity>())
                    .Select(c => new CursoVisualItem
                    {
                        IdCurso = c.IdCurso,
                        Codigo = c.CodigoCurso,
                        Nombre = c.NombreCurso,
                        Descripcion = c.Descripcion,
                        Estudiantes = c.CantidadEstudiantes
                    }).ToList();

                _paginaActual = 1;
                AjustarAnchoFilas();
                RenderizarPagina();
            }
            catch (Exception ex)
            {
                if (!IsDisposed)
                    MessageBox.Show($"Error al cargar los cursos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      
        // RENDER: solo actualiza textos de las filas existente
        private void RenderizarPagina()
        {
            pnlFilasCursos.SuspendLayout();

            try
            {
                _totalPaginas = (int)Math.Ceiling(_todosLosCursos.Count / (double)_elementosPorPagina);
                if (_totalPaginas < 1) _totalPaginas = 1;

                if (_paginaActual > _totalPaginas) _paginaActual = _totalPaginas;
                if (_paginaActual < 1) _paginaActual = 1;

                lblNumeroPaginaBadge.Text = _paginaActual.ToString();
                lblTotalPaginasTexto.Text = $"de {_totalPaginas}";

                btnPaginaAnterior.IconColor = _paginaActual > 1 ? Color.FromArgb(160, 185, 230) : Color.FromArgb(70, 85, 115);
                btnPaginaSiguiente.IconColor = _paginaActual < _totalPaginas ? Color.FromArgb(160, 185, 230) : Color.FromArgb(70, 85, 115);

                var cursosPagina = _todosLosCursos
                    .Skip((_paginaActual - 1) * _elementosPorPagina)
                    .Take(_elementosPorPagina)
                    .ToList();

                for (int i = 0; i < _filas.Count; i++)
                {
                    var fila = _filas[i];

                    if (i < cursosPagina.Count)
                    {
                        var curso = cursosPagina[i];
                        fila.Panel.Tag = curso;
                        fila.Panel.BackColor = Color.Transparent;
                        fila.Codigo.Text = curso.Codigo;
                        fila.Nombre.Text = curso.Nombre;
                        fila.Descripcion.Text = curso.Descripcion;
                        fila.Estudiantes.Text = curso.Estudiantes.ToString();
                        fila.Panel.Visible = true;
                    }
                    else
                    {
                        fila.Panel.Visible = false;
                    }
                }

                AlinearControlesPaginacion();
            }
            finally
            {
                pnlFilasCursos.ResumeLayout(true);
            }
        }

        // Solo ajusta anchos; el header ya no se reconstruye en cada Resize
        private void AjustarAnchoFilas()
        {
            if (pnlFilasCursos == null || _filas.Count == 0) return;

            int ancho = pnlFilasCursos.Width;

            foreach (var fila in _filas)
            {
                if (fila.Panel.Width != ancho)
                    fila.Panel.Width = ancho;

                int anchoDivisor = Math.Max(100, ancho - 50);
                if (fila.Divisor.Width != anchoDivisor)
                    fila.Divisor.Width = anchoDivisor;
            }
        }

        private static void HabilitarDobleBufer(Control control)
        {
            typeof(Control).GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.SetValue(control, true);
        }

        private void btnNuevoCurso_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Formulario para registrar un nuevo curso activo.", "Nuevo Curso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}