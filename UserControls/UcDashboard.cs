using SistemaAsistenciaPorVoz.Entity;
using SistemaAsistenciaPorVoz.UI.ControlesPersonalizados;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SistemaAsistenciaPorVoz.UI.UserControls
{
    public partial class UcDashboard : UserControl
    {
        private UsuarioEntity _usuario;

        private readonly Color ColorFondoGlobal = Color.FromArgb(20, 24, 36);
        private readonly Color ColorPanelTarjetas = Color.FromArgb(30, 35, 50);
        private readonly Color ColorTextoPrimario = Color.FromArgb(240, 240, 245);
        private readonly Color ColorTextoSecundario = Color.FromArgb(130, 140, 160);
        private readonly Color ColorAzul = Color.FromArgb(65, 125, 255);
        private readonly Color ColorAzulHover = Color.FromArgb(85, 145, 255); // Azul más claro para el hover

        // Variables para rastrear el hover del mouse en la tabla
        private int hoveredRow = -1;
        private int hoveredCol = -1;

        public UcDashboard(UsuarioEntity usuario)
        {
            _usuario = usuario;
            this.DoubleBuffered = true;
            InicializarComponentes();
        }

        private void InicializarComponentes()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = ColorFondoGlobal;
            this.Padding = new Padding(30, 55, 30, 20);

            // 1. CABECERA
            Panel pnlHeader = new Panel { Dock = DockStyle.Top, Height = 90 };
            Label lblTitulo = new Label { Text = "Panel de Control", Font = new Font("Segoe UI", 22, FontStyle.Bold), ForeColor = ColorTextoPrimario, AutoSize = true, Location = new Point(0, 0) };

            string fechaActual = DateTime.Now.ToString("dddd, dd MMM yyyy");
            fechaActual = char.ToUpper(fechaActual[0]) + fechaActual.Substring(1);

            Label lblBienvenida = new Label { Text = $"Bienvenido, Prof. {_usuario.NombreCompleto}  •  {fechaActual}", Font = new Font("Segoe UI", 11), ForeColor = ColorTextoSecundario, AutoSize = true, Location = new Point(5, 45) };

            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Controls.Add(lblBienvenida);
            this.Controls.Add(pnlHeader);

            // 2. TARJETAS
            TableLayoutPanel tlpCards = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 170,
                ColumnCount = 3,
                RowCount = 1,
                Padding = new Padding(0, 0, 0, 20)
            };
            tlpCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33f));
            tlpCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33f));
            tlpCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33f));

            tlpCards.Controls.Add(CrearTarjeta("Clases de Hoy", "3", "Programadas en total", ColorAzul, "📅"), 0, 0);
            tlpCards.Controls.Add(CrearTarjeta("Asistencia Promedio", "85%", "Por encima de meta (80%)", Color.FromArgb(45, 185, 115), "📊"), 1, 0);
            tlpCards.Controls.Add(CrearTarjeta("Alertas Críticas", "2", "Estudiantes en riesgo", Color.FromArgb(235, 85, 95), "❗"), 2, 0);

            pnlHeader.SendToBack();
            this.Controls.Add(tlpCards);
            tlpCards.BringToFront();

            // 3. TÍTULO TABLA
            Panel pnlTableTitle = new Panel { Dock = DockStyle.Top, Height = 50 };
            Label lblProximas = new Label { Text = "Programación de Clases para Hoy", Font = new Font("Segoe UI", 14, FontStyle.Bold), ForeColor = ColorTextoPrimario, AutoSize = true, Location = new Point(0, 10) };
            pnlTableTitle.Controls.Add(lblProximas);

            this.Controls.Add(pnlTableTitle);
            pnlTableTitle.BringToFront();

            // 4. TABLA
            PanelRedondeado fondoTabla = new PanelRedondeado
            {
                Dock = DockStyle.Fill,
                ColorFondo = ColorPanelTarjetas,
                RadioBorde = 20,
                Padding = new Padding(15)
            };

            fondoTabla.Controls.Add(CrearTablaClases());
            this.Controls.Add(fondoTabla);
            fondoTabla.BringToFront();
        }

        private PanelRedondeado CrearTarjeta(string titulo, string valor, string subtitulo, Color colorAcento, string iconoTexto)
        {
            PanelRedondeado card = new PanelRedondeado { Dock = DockStyle.Fill, Margin = new Padding(0, 0, 15, 0), ColorFondo = ColorPanelTarjetas, RadioBorde = 15 };

            PanelRedondeado pnlIcono = new PanelRedondeado { Location = new Point(20, 35), Size = new Size(60, 60), ColorFondo = Color.FromArgb(30, colorAcento), RadioBorde = 15 };
            Label lblIcono = new Label { Text = iconoTexto, Font = new Font("Segoe UI Emoji", 20), ForeColor = colorAcento, Size = new Size(60, 60), TextAlign = ContentAlignment.MiddleCenter, BackColor = Color.Transparent };
            pnlIcono.Controls.Add(lblIcono);
            card.Controls.Add(pnlIcono);

            FlowLayoutPanel pnlTextos = new FlowLayoutPanel { Location = new Point(95, 20), Size = new Size(220, 110), FlowDirection = FlowDirection.TopDown, WrapContents = false, BackColor = Color.Transparent };

            Label lblTitulo = new Label { Text = titulo, ForeColor = ColorTextoSecundario, Font = new Font("Segoe UI Semibold", 10), AutoSize = true, Margin = new Padding(0, 0, 0, 0) };
            Label lblValor = new Label { Text = valor, ForeColor = colorAcento, Font = new Font("Segoe UI", 26, FontStyle.Bold), AutoSize = true, Margin = new Padding(-4, 0, 0, 0) };
            Label lblSub = new Label { Text = subtitulo, ForeColor = ColorTextoSecundario, Font = new Font("Segoe UI", 9), AutoSize = true, Margin = new Padding(0, 0, 0, 0) };

            pnlTextos.Controls.Add(lblTitulo); pnlTextos.Controls.Add(lblValor); pnlTextos.Controls.Add(lblSub);
            card.Controls.Add(pnlTextos);
            return card;
        }

        private DataGridView CrearTablaClases()
        {
            DataGridView tabla = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = ColorPanelTarjetas,
                BorderStyle = BorderStyle.None,
                CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
                GridColor = Color.FromArgb(45, 52, 70),
                RowHeadersVisible = false,
                AllowUserToAddRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                EnableHeadersVisualStyles = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                Cursor = Cursors.Default
            };

            // DANDO RESPIRACIÓN A LAS FILAS
            tabla.RowTemplate.Height = 70; // Filas mucho más altas
            tabla.DefaultCellStyle.Padding = new Padding(10, 0, 10, 0); // Espacio interno izquierdo y derecho

            tabla.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            tabla.ColumnHeadersDefaultCellStyle.BackColor = ColorPanelTarjetas;
            tabla.ColumnHeadersDefaultCellStyle.ForeColor = ColorTextoSecundario;
            tabla.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10);
            tabla.ColumnHeadersDefaultCellStyle.SelectionBackColor = ColorPanelTarjetas;
            tabla.ColumnHeadersHeight = 50;

            tabla.DefaultCellStyle.BackColor = ColorPanelTarjetas;
            tabla.DefaultCellStyle.ForeColor = ColorTextoPrimario;
            tabla.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            tabla.DefaultCellStyle.SelectionBackColor = Color.FromArgb(40, 45, 60); // Selección ultra suave
            tabla.DefaultCellStyle.SelectionForeColor = ColorTextoPrimario;

            tabla.DataBindingComplete += (s, e) => tabla.ClearSelection();

            // Columnas
            tabla.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Hora", HeaderText = "Hora", FillWeight = 15 });
            tabla.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Codigo", HeaderText = "Código", FillWeight = 15 });
            tabla.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Asignatura", HeaderText = "Asignatura", FillWeight = 30 });
            tabla.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Seccion", HeaderText = "Sección", FillWeight = 15 });
            tabla.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Aula", HeaderText = "Aula", FillWeight = 15 });
            tabla.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Accion", HeaderText = "", FillWeight = 20 }); // Ya no es botón nativo, es texto vacío

            tabla.Rows.Add("08:00 AM", "ISI-302", "Programación II", "Sec. 01", "Aula 204");
            tabla.Rows.Add("10:00 AM", "ISI-405", "Base de Datos", "Sec. 02", "Lab 301");
            tabla.Rows.Add("02:00 PM", "ISI-201", "Algoritmos", "Sec. 01", "Aula 105");

            foreach (DataGridViewRow row in tabla.Rows)
                row.Cells["Codigo"].Style.ForeColor = ColorAzul;

            // --- EVENTOS MÁGICOS PARA EL BOTÓN PREMIUM ---
            tabla.CellPainting += Tabla_CellPainting;
            tabla.CellMouseMove += Tabla_CellMouseMove;
            tabla.CellMouseLeave += Tabla_CellMouseLeave;
            tabla.CellClick += Tabla_CellClick;

            return tabla;
        }

        // ==============================================================
        // RENDERIZADO PERSONALIZADO DEL BOTÓN Y HOVER
        // ==============================================================

        private void Tabla_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Solo secuestramos el pintado de la columna "Accion" en las filas de datos
            if (e.RowIndex >= 0 && e.ColumnIndex == 5)
            {
                e.Handled = true; // Decimos a Windows: "Yo me encargo"

                // Pintar el fondo de la celda normal
                e.PaintBackground(e.CellBounds, true);

                // Calcular el área del botón (más pequeño que la celda para que tenga padding)
                Rectangle rectBoton = e.CellBounds;
                rectBoton.Inflate(-15, -15); // Márgenes internos del botón (arriba, abajo, izq, der)

                // Saber si el ratón está encima para cambiar el color
                bool isHovered = (hoveredRow == e.RowIndex && hoveredCol == e.ColumnIndex);
                Color colorActual = isHovered ? ColorAzulHover : ColorAzul;

                // Dibujar el botón redondeado
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (GraphicsPath path = ObtenerBordeRedondeado(rectBoton, 10)) // Radio de 10px
                using (SolidBrush brush = new SolidBrush(colorActual))
                {
                    e.Graphics.FillPath(brush, path);
                }

                // Dibujar el texto centrado
                TextRenderer.DrawText(e.Graphics, "Iniciar Clase", new Font("Segoe UI Semibold", 9.5f),
                    rectBoton, Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }

        private void Tabla_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView grid = sender as DataGridView;
            if (e.RowIndex >= 0 && e.ColumnIndex == 5) // Si el ratón está en la columna del botón
            {
                if (hoveredRow != e.RowIndex || hoveredCol != e.ColumnIndex)
                {
                    hoveredRow = e.RowIndex;
                    hoveredCol = e.ColumnIndex;
                    grid.Cursor = Cursors.Hand; // Cambiar el cursor a la manito
                    grid.InvalidateCell(e.ColumnIndex, e.RowIndex); // Forzar repintado
                }
            }
            else
            {
                LimpiarHover(grid);
            }
        }

        private void Tabla_CellMouseLeave(object sender, EventArgs e)
        {
            LimpiarHover(sender as DataGridView);
        }

        private void LimpiarHover(DataGridView grid)
        {
            if (hoveredRow >= 0 && hoveredCol >= 0)
            {
                int r = hoveredRow, c = hoveredCol;
                hoveredRow = -1;
                hoveredCol = -1;
                if (grid != null)
                {
                    grid.Cursor = Cursors.Default;
                    grid.InvalidateCell(c, r);
                }
            }
        }

        private void Tabla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Detectar clic en nuestro "botón" falso
            if (e.RowIndex >= 0 && e.ColumnIndex == 5)
            {
                MessageBox.Show("Iniciando reconocimiento de voz para la clase...", "Asistencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Utilidad para crear bordes redondeados al vuelo
        private GraphicsPath ObtenerBordeRedondeado(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}