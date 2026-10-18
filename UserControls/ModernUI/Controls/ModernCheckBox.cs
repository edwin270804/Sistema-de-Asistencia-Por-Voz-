using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ModernUI.Helpers;

namespace ModernUI.Controls
{
    public enum CheckStyle
    {
        Checkmark,
        Fill,
        Cross
    }

    [DefaultEvent("CheckedChanged")]
    public class ModernCheckBox : Control
    {
        private bool _checked = false;
        private int _checkBoxSize = 20;
        private int _borderRadius = 4;
        private Color _checkedColor = Color.DodgerBlue;
        private Color _uncheckedColor = Color.White;
        private Color _uncheckedBorderColor = Color.Gray;
        private Color _checkMarkColor = Color.White;
        private Color _textColor = Color.Black;
        private int _spacing = 8;
        private CheckStyle _checkStyle = CheckStyle.Checkmark;
        private bool _isHovered = false;

        public ModernCheckBox()
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
        public int CheckBoxSize
        {
            get => _checkBoxSize;
            set { _checkBoxSize = value; this.Invalidate(); }
        }

        [Category("Modern UI")]
        public int BorderRadius
        {
            get => _borderRadius;
            set { _borderRadius = value; this.Invalidate(); }
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
        public Color CheckMarkColor
        {
            get => _checkMarkColor;
            set { _checkMarkColor = value; this.Invalidate(); }
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

        [Category("Modern UI")]
        public CheckStyle CheckStyle
        {
            get => _checkStyle;
            set { _checkStyle = value; this.Invalidate(); }
        }

        public event EventHandler CheckedChanged;

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            Checked = !Checked;
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

            int yOffset = (this.Height - _checkBoxSize) / 2;
            Rectangle boxRect = new Rectangle(0, yOffset, _checkBoxSize, _checkBoxSize);

            // Draw Checkbox
            if (_checked)
            {
                using (Brush brush = new SolidBrush(_checkedColor))
                {
                    if (_borderRadius > 0)
                        GraphicsHelper.FillRoundedRect(g, brush, boxRect, _borderRadius);
                    else
                        g.FillRectangle(brush, boxRect);
                }

                // Draw checkmark/fill/cross
                using (Pen pen = new Pen(_checkMarkColor, 2f))
                {
                    pen.StartCap = LineCap.Round;
                    pen.EndCap = LineCap.Round;

                    if (_checkStyle == CheckStyle.Checkmark)
                    {
                        int padding = _checkBoxSize / 4;
                        Point p1 = new Point(boxRect.X + padding, boxRect.Y + _checkBoxSize / 2);
                        Point p2 = new Point(boxRect.X + _checkBoxSize / 2 - 2, boxRect.Y + _checkBoxSize - padding - 2);
                        Point p3 = new Point(boxRect.Right - padding, boxRect.Y + padding + 1);

                        g.DrawLine(pen, p1, p2);
                        g.DrawLine(pen, p2, p3);
                    }
                    else if (_checkStyle == CheckStyle.Fill)
                    {
                        int padding = 4;
                        Rectangle fillRect = new Rectangle(boxRect.X + padding, boxRect.Y + padding, _checkBoxSize - padding * 2, _checkBoxSize - padding * 2);
                        using (Brush fillBrush = new SolidBrush(_checkMarkColor))
                        {
                            if (_borderRadius > 0)
                                GraphicsHelper.FillRoundedRect(g, fillBrush, fillRect, Math.Max(1, _borderRadius - 1));
                            else
                                g.FillRectangle(fillBrush, fillRect);
                        }
                    }
                    else if (_checkStyle == CheckStyle.Cross)
                    {
                        int padding = _checkBoxSize / 4;
                        g.DrawLine(pen, boxRect.X + padding, boxRect.Y + padding, boxRect.Right - padding, boxRect.Bottom - padding);
                        g.DrawLine(pen, boxRect.Right - padding, boxRect.Y + padding, boxRect.X + padding, boxRect.Bottom - padding);
                    }
                }
            }
            else
            {
                using (Brush brush = new SolidBrush(_isHovered ? ControlPaint.LightLight(_uncheckedColor) : _uncheckedColor))
                using (Pen pen = new Pen(_uncheckedBorderColor, 1.5f))
                {
                    if (_borderRadius > 0)
                    {
                        GraphicsHelper.FillRoundedRect(g, brush, boxRect, _borderRadius);
                        GraphicsHelper.DrawRoundedRect(g, pen, boxRect, _borderRadius);
                    }
                    else
                    {
                        g.FillRectangle(brush, boxRect);
                        g.DrawRectangle(pen, boxRect);
                    }
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
                    Rectangle textRect = new Rectangle(_checkBoxSize + _spacing, 0, this.Width - _checkBoxSize - _spacing, this.Height);
                    g.DrawString(this.Text, this.Font, textBrush, textRect, sf);
                }
            }
        }
    }
}
