using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ModernUI.Helpers;

namespace ModernUI.Controls
{
    [DefaultEvent("CheckedChanged")]
    public class ModernRadioButton : Control
    {
        private bool _checked = false;
        private int _radioSize = 20;
        private Color _checkedColor = Color.DodgerBlue;
        private Color _uncheckedColor = Color.White;
        private Color _uncheckedBorderColor = Color.Gray;
        private Color _innerDotColor = Color.White;
        private Color _textColor = Color.Black;
        private int _spacing = 8;
        private bool _isHovered = false;

        public ModernRadioButton()
        {
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
            this.Cursor = Cursors.Hand;
            this.Size = new Size(200, 30);
            this.BackColor = Color.Transparent;
            this.ForeColor = Color.Black;
        }

        [Category("Modern UI")]
        public bool Checked
        {
            get => _checked;
            set
            {
                if (_checked != value)
                {
                    _checked = value;
                    this.Invalidate();
                    if (_checked && this.Parent != null)
                    {
                        UncheckOthers();
                    }
                    CheckedChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        [Category("Modern UI"), Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public override string Text
        {
            get => base.Text;
            set { base.Text = value; this.Invalidate(); }
        }

        [Category("Modern UI")]
        public int RadioSize
        {
            get => _radioSize;
            set { _radioSize = value; this.Invalidate(); }
        }

        [Category("Modern UI")]
        public Color CheckedColor
        {
            get => _checkedColor;
            set { _checkedColor = value; this.Invalidate(); }
        }

        [Category("Modern UI")]
        public Color UncheckedColor
        {
            get => _uncheckedColor;
            set { _uncheckedColor = value; this.Invalidate(); }
        }

        [Category("Modern UI")]
        public Color UncheckedBorderColor
        {
            get => _uncheckedBorderColor;
            set { _uncheckedBorderColor = value; this.Invalidate(); }
        }

        [Category("Modern UI")]
        public Color InnerDotColor
        {
            get => _innerDotColor;
            set { _innerDotColor = value; this.Invalidate(); }
        }

        [Category("Modern UI")]
        public Color TextColor
        {
            get => _textColor;
            set { _textColor = value; this.Invalidate(); }
        }

        [Category("Modern UI")]
        public int Spacing
        {
            get => _spacing;
            set { _spacing = value; this.Invalidate(); }
        }

        public event EventHandler CheckedChanged;

        private void UncheckOthers()
        {
            foreach (Control ctrl in this.Parent.Controls)
            {
                if (ctrl != this && ctrl is ModernRadioButton radio)
                {
                    radio.Checked = false;
                }
            }
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            if (!Checked)
            {
                Checked = true;
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _isHovered = true;
            this.Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _isHovered = false;
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            int yOffset = (this.Height - _radioSize) / 2;
            Rectangle radioRect = new Rectangle(0, yOffset, _radioSize, _radioSize);

            if (_checked)
            {
                using (Brush brush = new SolidBrush(_checkedColor))
                {
                    g.FillEllipse(brush, radioRect);
                }

                int dotSize = _radioSize / 2;
                Rectangle dotRect = new Rectangle(
                    radioRect.X + (_radioSize - dotSize) / 2,
                    radioRect.Y + (_radioSize - dotSize) / 2,
                    dotSize, dotSize);

                using (Brush dotBrush = new SolidBrush(_innerDotColor))
                {
                    g.FillEllipse(dotBrush, dotRect);
                }
            }
            else
            {
                using (Brush brush = new SolidBrush(_isHovered ? ControlPaint.LightLight(_uncheckedColor) : _uncheckedColor))
                using (Pen pen = new Pen(_uncheckedBorderColor, 1.5f))
                {
                    g.FillEllipse(brush, radioRect);
                    g.DrawEllipse(pen, radioRect);
                }
            }

            // Draw Text
            if (!string.IsNullOrEmpty(this.Text))
            {
                using (Brush textBrush = new SolidBrush(_textColor))
                {
                    StringFormat sf = new StringFormat
                    {
                        LineAlignment = StringAlignment.Center,
                        Alignment = StringAlignment.Near
                    };
                    Rectangle textRect = new Rectangle(_radioSize + _spacing, 0, this.Width - _radioSize - _spacing, this.Height);
                    g.DrawString(this.Text, this.Font, textBrush, textRect, sf);
                }
            }
        }
    }
}
