using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ModernUI.Helpers;

namespace ModernUI.Controls
{
    [DefaultEvent("SelectedIndexChanged")]
    public class ModernComboBox : UserControl
    {
        private Color _borderColor = Color.MediumSlateBlue;
        private Color _focusBorderColor = Color.HotPink;
        private Color _backgroundColor = Color.White;
        private Color _foregroundColor = Color.DimGray;
        private Color _arrowColor = Color.MediumSlateBlue;
        private int _borderRadius = 8;
        private int _borderThickness = 2;
        private bool _isFocused = false;

        private ComboBox _cmbList;

        public ModernComboBox()
        {
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
            this.Size = new Size(250, 40);

            _cmbList = new ComboBox();
            _cmbList.FlatStyle = FlatStyle.Flat;
            _cmbList.BackColor = _backgroundColor;
            _cmbList.ForeColor = _foregroundColor;
            _cmbList.Font = this.Font;
            
            this.SuspendLayout();
            this.Controls.Add(_cmbList);
            this.ResumeLayout();

            _cmbList.SelectedIndexChanged += (s, e) => SelectedIndexChanged?.Invoke(this, e);
            _cmbList.Enter += (s, e) => { _isFocused = true; this.Invalidate(); };
            _cmbList.Leave += (s, e) => { _isFocused = false; this.Invalidate(); };
            _cmbList.Click += (s, e) => this.OnClick(e);
            
            AdjustComboBoxDimensions();
        }

        [Category("Modern UI")]
        public int BorderRadius
        {
            get => _borderRadius;
            set
            {
                if (value < 0) value = 0;
                _borderRadius = value;
                this.Invalidate();
            }
        }

        [Category("Modern UI")]
        public Color BorderColor
        {
            get => _borderColor;
            set { _borderColor = value; this.Invalidate(); }
        }

        [Category("Modern UI")]
        public Color FocusBorderColor
        {
            get => _focusBorderColor;
            set { _focusBorderColor = value; this.Invalidate(); }
        }

        [Category("Modern UI")]
        public Color BackgroundColor
        {
            get => _backgroundColor;
            set { _backgroundColor = value; _cmbList.BackColor = value; this.Invalidate(); }
        }

        [Category("Modern UI")]
        public Color ForegroundColor
        {
            get => _foregroundColor;
            set { _foregroundColor = value; _cmbList.ForeColor = value; this.Invalidate(); }
        }

        [Category("Modern UI")]
        public Color ArrowColor
        {
            get => _arrowColor;
            set { _arrowColor = value; this.Invalidate(); }
        }

        [Category("Modern UI")]
        public int BorderThickness
        {
            get => _borderThickness;
            set
            {
                if (value < 0) value = 0;
                _borderThickness = value;
                AdjustComboBoxDimensions();
                this.Invalidate();
            }
        }

        [Category("Modern UI")]
        public ComboBox.ObjectCollection Items => _cmbList.Items;

        [Category("Modern UI")]
        public int SelectedIndex
        {
            get => _cmbList.SelectedIndex;
            set => _cmbList.SelectedIndex = value;
        }

        [Category("Modern UI")]
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object SelectedItem
        {
            get => _cmbList.SelectedItem;
            set => _cmbList.SelectedItem = value;
        }

        [Category("Modern UI")]
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object SelectedValue
        {
            get => _cmbList.SelectedValue;
            set => _cmbList.SelectedValue = value;
        }

        [Category("Modern UI")]
        public ComboBoxStyle DropDownStyle
        {
            get => _cmbList.DropDownStyle;
            set
            {
                if (_cmbList.DropDownStyle != value)
                {
                    _cmbList.DropDownStyle = value;
                }
            }
        }

        [Category("Modern UI")]
        public object DataSource
        {
            get => _cmbList.DataSource;
            set => _cmbList.DataSource = value;
        }

        [Category("Modern UI")]
        public string DisplayMember
        {
            get => _cmbList.DisplayMember;
            set => _cmbList.DisplayMember = value;
        }

        [Category("Modern UI")]
        public string ValueMember
        {
            get => _cmbList.ValueMember;
            set => _cmbList.ValueMember = value;
        }

        public event EventHandler SelectedIndexChanged;

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            AdjustComboBoxDimensions();
        }

        private void AdjustComboBoxDimensions()
        {
            _cmbList.Width = this.Width - (_borderThickness * 2) - 30; // 30 for arrow
            _cmbList.Location = new Point(_borderThickness + 5, this.Height / 2 - _cmbList.Height / 2);
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            _cmbList.Font = this.Font;
            AdjustComboBoxDimensions();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            Color borderColor = _isFocused ? _focusBorderColor : _borderColor;

            using (Brush bgBrush = new SolidBrush(_backgroundColor))
            using (Pen pen = new Pen(borderColor, _borderThickness))
            {
                pen.Alignment = PenAlignment.Inset;
                if (_borderRadius > 0)
                {
                    GraphicsHelper.FillRoundedRect(g, bgBrush, rect, _borderRadius);
                    GraphicsHelper.DrawRoundedRect(g, pen, rect, _borderRadius);
                }
                else
                {
                    g.FillRectangle(bgBrush, rect);
                    g.DrawRectangle(pen, rect);
                }
            }

            int arrowSize = 10;
            int arrowX = this.Width - arrowSize - _borderThickness - 10;
            int arrowY = this.Height / 2 - (arrowSize / 2) + 2;

            Point[] arrowPoints = new Point[]
            {
                new Point(arrowX, arrowY),
                new Point(arrowX + arrowSize, arrowY),
                new Point(arrowX + (arrowSize / 2), arrowY + (arrowSize / 2) + 2)
            };

            using (Brush arrowBrush = new SolidBrush(_arrowColor))
            {
                g.FillPolygon(arrowBrush, arrowPoints);
            }
        }
    }
}
