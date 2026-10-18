using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SistemaAsistenciaPorVoz.UI.BotonesPersonalizados_y_Textbox
{
    [DefaultEvent("_TextChanged")]
    public partial class TxtPersonalizada : UserControl
    {
        // ==============================
        // CAMPOS
        // ==============================

        private Color borderColor = Color.MediumSlateBlue;
        private Color borderFocusColor = Color.HotPink;
        private int borderSize = 2;
        private bool underlinedStyle = false;
        private bool isFocused = false;

        private int borderRadius = 0;
        private Color placeholderColor = Color.DarkGray;
        private string placeholderText = "";
        private bool isPlaceholder = false;
        private bool isPasswordChar = false;

        // ==============================
        // EVENTOS
        // ==============================

        public event EventHandler _TextChanged;

        // ==============================
        // CONSTRUCTOR
        // ==============================

        public TxtPersonalizada()
        {
            InitializeComponent();

            // 1. Ocultar el borde nativo del TextBox interno
            textBox1.BorderStyle = BorderStyle.None;

            // 2. Aplicar un margen para dejar espacio donde se dibujará tu borde redondeado
            // (Izquierda, Arriba, Derecha, Abajo)
            this.Padding = new Padding(10, 7, 10, 7);

            // 3. Hacer que el TextBox ocupe el área restante respetando el Padding
            textBox1.Dock = DockStyle.Fill;

            // 4. Activar el doble búfer y el pintado manual para evitar que los estilos se pierdan
            this.SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.SupportsTransparentBackColor,
                true
            );
            this.DoubleBuffered = true;
        }

        // ==============================
        // PROPIEDADES
        // ==============================

        [Category("Textbox")]
       // [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color BorderColor
        {
            get
            {
                return borderColor;
            }
            set
            {
                borderColor = value;
                this.Invalidate();
            }
        }

        [Category("Textbox")]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color BorderFocusColor
        {
            get
            {
                return borderFocusColor;
            }
            set
            {
                borderFocusColor = value;
                this.Invalidate();
            }
        }

        [Category("Textbox")]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int BorderSize
        {
            get
            {
                return borderSize;
            }
            set
            {
                if (value >= 1)
                {
                    borderSize = value;
                    this.Invalidate();
                }
            }
        }

        [Category("Textbox")]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool UnderlinedStyle
        {
            get
            {
                return underlinedStyle;
            }
            set
            {
                underlinedStyle = value;
                this.Invalidate();
            }
        }

        [Category("Textbox")]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool PasswordChar
        {
            get
            {
                return isPasswordChar;
            }
            set
            {
                isPasswordChar = value;

                if (!isPlaceholder)
                {
                    textBox1.UseSystemPasswordChar = value;
                }
            }
        }

        [Category("Textbox")]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Multiline
        {
            get
            {
                return textBox1.Multiline;
            }
            set
            {
                textBox1.Multiline = value;
            }
        }

        [Category("Textbox")]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
                textBox1.BackColor = value;
            }
        }

        [Category("Textbox")]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
                textBox1.ForeColor = value;
            }
        }

        [Category("Textbox")]
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                textBox1.Font = value;

                if (this.DesignMode)
                {
                    UpdateControlHeight();
                }
            }
        }

        [Category("Textbox")]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Texts
        {
            get
            {
                if (isPlaceholder)
                    return "";

                return textBox1.Text;
            }
            set
            {
                textBox1.Text = value;
                SetPlaceHolder();
            }
        }

        [Category("Textbox")]
        public int SelectionStart
        {
            get { return textBox1.SelectionStart; }
            set { textBox1.SelectionStart = value; }
        }

        // ==================================
        // CORREGIDO: BorderRadius
        // ==================================

        [Category("Textbox")]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int BorderRadius
        {
            get
            {
                return borderRadius;
            }
            set
            {
                if (value >= 0)
                {
                    borderRadius = value;
                    this.Invalidate();
                }
            }
        }

        [Category("Textbox")]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color PlaceholderColor
        {
            get
            {
                return placeholderColor;
            }
            set
            {
                placeholderColor = value;

                // CORREGIDO:
                // Antes tenías isPasswordChar
                if (isPlaceholder)
                {
                    textBox1.ForeColor = value;
                }
            }
        }

        [Category("Textbox")]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string PlaceholderText
        {
            get
            {
                return placeholderText;
            }
            set
            {
                placeholderText = value;

                textBox1.Text = "";

                SetPlaceHolder();
            }
        }

        // ==============================
        // PLACEHOLDER
        // ==============================

        private void SetPlaceHolder()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) &&
                placeholderText != "")
            {
                isPlaceholder = true;

                textBox1.Text = placeholderText;
                textBox1.ForeColor = placeholderColor;

                if (isPasswordChar)
                {
                    textBox1.UseSystemPasswordChar = false;
                }
            }
        }

        private void RemovePlaceHolder()
        {
            if (isPlaceholder && placeholderText != "")
            {
                isPlaceholder = false;

                textBox1.Text = "";
                textBox1.ForeColor = this.ForeColor;

                if (isPasswordChar)
                {
                    textBox1.UseSystemPasswordChar = true;
                }
            }
        }

        // ==============================
        // ON PAINT
        // ==============================

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics graph = e.Graphics;

            graph.SmoothingMode = SmoothingMode.AntiAlias;

            // ==============================
            // TEXTBOX REDONDEADO
            // ==============================

            if (borderRadius > 1)
            {
                Rectangle rectBorderSmooth = this.ClientRectangle;

                Rectangle rectBorder = Rectangle.Inflate(
                    rectBorderSmooth,
                    -borderSize,
                    -borderSize
                );

                int smoothSize = borderSize > 0
                    ? borderSize
                    : 1;

                using (GraphicsPath pathBorderSmooth =
                    GetFigurePath(rectBorderSmooth, borderRadius))

                using (GraphicsPath pathBorder =
                    GetFigurePath(
                        rectBorder,
                        borderRadius - borderSize))

                using (Pen penBorderSmooth =
                    new Pen(this.Parent.BackColor, smoothSize))

                using (Pen penBorder =
                    new Pen(borderColor, borderSize))
                {
                    // Región redondeada del UserControl
                    this.Region = new Region(pathBorderSmooth);

                    // Región redondeada del TextBox
                    if (borderRadius > 1)
                    {
                        SetTextBoxRoundedRegion();
                    }

                    penBorder.Alignment =
                        PenAlignment.Center;

                    if (isFocused)
                    {
                        penBorder.Color = borderFocusColor;
                    }

                    if (underlinedStyle)
                    {
                        // Suavizado exterior
                        graph.DrawPath(
                            penBorderSmooth,
                            pathBorderSmooth
                        );

                        graph.SmoothingMode =
                            SmoothingMode.None;

                        // Línea inferior
                        graph.DrawLine(
                            penBorder,
                            0,
                            this.Height - 1,
                            this.Width,
                            this.Height - 1
                        );
                    }
                    else
                    {
                        // Suavizado exterior
                        graph.DrawPath(
                            penBorderSmooth,
                            pathBorderSmooth
                        );

                        // Borde
                        graph.DrawPath(
                            penBorder,
                            pathBorder
                        );
                    }
                }
            }

            // ==============================
            // TEXTBOX NORMAL
            // ==============================

            else
            {
                using (Pen penBorder =
                    new Pen(borderColor, borderSize))
                {
                    this.Region =
                        new Region(this.ClientRectangle);

                    penBorder.Alignment =
                        PenAlignment.Inset;

                    if (isFocused)
                    {
                        penBorder.Color =
                            borderFocusColor;
                    }

                    if (underlinedStyle)
                    {
                        graph.DrawLine(
                            penBorder,
                            0,
                            this.Height - 1,
                            this.Width,
                            this.Height - 1
                        );
                    }
                    else
                    {
                        graph.DrawRectangle(
                            penBorder,
                            0,
                            0,
                            this.Width - 0.5F,
                            this.Height - 0.5F
                        );
                    }
                }
            }
        }

        // ==============================
        // REGIÓN REDONDEADA DEL TEXTBOX
        // ==============================

        private void SetTextBoxRoundedRegion()
        {
            GraphicsPath pathTxt;

            if (Multiline)
            {
                pathTxt = GetFigurePath(
                    textBox1.ClientRectangle,
                    borderRadius - borderSize
                );
            }
            else
            {
                pathTxt = GetFigurePath(
                    textBox1.ClientRectangle,
                    borderSize * 2
                );
            }

            textBox1.Region =
                new Region(pathTxt);

            // CORREGIDO:
            // Liberar GraphicsPath
            pathTxt.Dispose();
        }

        // ==============================
        // CREAR FIGURA REDONDEADA
        // ==============================

        private GraphicsPath GetFigurePath(
            Rectangle rect,
            int radius)
        {
            GraphicsPath path =
                new GraphicsPath();

            float curveSize =
                radius * 2F;

            path.StartFigure();

            path.AddArc(
                rect.X,
                rect.Y,
                curveSize,
                curveSize,
                180,
                90
            );

            path.AddArc(
                rect.Right - curveSize,
                rect.Y,
                curveSize,
                curveSize,
                270,
                90
            );

            path.AddArc(
                rect.Right - curveSize,
                rect.Bottom - curveSize,
                curveSize,
                curveSize,
                0,
                90
            );

            path.AddArc(
                rect.X,
                rect.Bottom - curveSize,
                curveSize,
                curveSize,
                90,
                90
            );

            path.CloseFigure();

            return path;
        }

        // ==============================
        // RESIZE
        // ==============================

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (this.DesignMode)
            {
                UpdateControlHeight();
            }

            this.Invalidate();
        }

        // ==============================
        // LOAD
        // ==============================

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            UpdateControlHeight();
        }

        // ==============================
        // ALTURA AUTOMÁTICA
        // ==============================

        private void UpdateControlHeight()
        {
            if (textBox1.Multiline == false)
            {
                int txtHeight =
                    TextRenderer.MeasureText(
                        "Text",
                        this.Font
                    ).Height + 1;

                textBox1.Multiline = true;

                textBox1.MinimumSize =
                    new Size(0, txtHeight);

                textBox1.Multiline = false;

                this.Height =
                    textBox1.Height +
                    this.Padding.Top +
                    this.Padding.Bottom;
            }
        }

        // ==============================
        // EVENTOS DEL TEXTBOX
        // ==============================

        private void textBox1_TextChanged(
            object sender,
            EventArgs e)
        {
            if (_TextChanged != null)
            {
                _TextChanged.Invoke(sender, e);
            }
        }

        private void textBox1_Click(
            object sender,
            EventArgs e)
        {
            this.OnClick(e);
        }

        private void textBox1_MouseEnter(
            object sender,
            EventArgs e)
        {
            this.OnMouseEnter(e);
        }

        private void textBox1_MouseLeave(
            object sender,
            EventArgs e)
        {
            this.OnMouseLeave(e);
        }

        private void textBox1_KeyPress(
            object sender,
            KeyPressEventArgs e)
        {
            this.OnKeyPress(e);
        }

        private void textBox1_Enter(
            object sender,
            EventArgs e)
        {
            isFocused = true;

            this.Invalidate();

            RemovePlaceHolder();
        }

        private void textBox1_Leave(
            object sender,
            EventArgs e)
        {
            isFocused = false;

            this.Invalidate();

            SetPlaceHolder();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            this.OnKeyDown(e);
        }
    }
}