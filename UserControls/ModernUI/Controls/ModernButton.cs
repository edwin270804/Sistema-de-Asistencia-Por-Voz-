using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using ModernUI.Helpers;

namespace ModernUI.Controls
{
    public enum ButtonStyle
    {
        Solid,
        Outline,
        Flat
    }

    public class ModernButton : Control
    {
        private enum MouseState
        {
            Normal,
            Hover,
            Pressed
        }

        private MouseState _state = MouseState.Normal;

        // Properties
        private int _borderRadius = 8;
        private Color _backColor = Color.FromArgb(0, 122, 204);
        private Color _foreColor = Color.White;
        private Color _borderColor = Color.Transparent;
        
        private Color _hoverBackColor = Color.FromArgb(0, 102, 204);
        private Color _hoverForeColor = Color.White;
        private Color _hoverBorderColor = Color.Transparent;
        
        private Color _pressedBackColor = Color.FromArgb(0, 82, 184);
        private Color _pressedForeColor = Color.White;
        
        private int _borderThickness = 0;
        private Image _iconLeft;
        private Image _iconRight;
        private Size _iconSize = new Size(16, 16);
        private ContentAlignment _textAlign = ContentAlignment.MiddleCenter;
        private ButtonStyle _buttonStyle = ButtonStyle.Solid;

        public ModernButton()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.SupportsTransparentBackColor, true);
            Size = new Size(150, 40);
            Cursor = Cursors.Hand;
            DoubleBuffered = true;
        }

        [Category("Modern UI")]
        public int BorderRadius
        {
            get => _borderRadius;
            set { _borderRadius = value; Invalidate(); }
        }

        [Category("Modern UI")]
        public override Color BackColor
        {
            get => _backColor;
            set { _backColor = value; Invalidate(); }
        }

        [Category("Modern UI")]
        public override Color ForeColor
        {
            get => _foreColor;
            set { _foreColor = value; Invalidate(); }
        }

        [Category("Modern UI")]
        public Color BorderColor
        {
            get => _borderColor;
            set { _borderColor = value; Invalidate(); }
        }

        [Category("Modern UI")]
        public Color HoverBackColor
        {
            get => _hoverBackColor;
            set { _hoverBackColor = value; }
        }

        [Category("Modern UI")]
        public Color HoverForeColor
        {
            get => _hoverForeColor;
            set { _hoverForeColor = value; }
        }

        [Category("Modern UI")]
        public Color HoverBorderColor
        {
            get => _hoverBorderColor;
            set { _hoverBorderColor = value; }
        }

        [Category("Modern UI")]
        public Color PressedBackColor
        {
            get => _pressedBackColor;
            set { _pressedBackColor = value; }
        }

        [Category("Modern UI")]
        public Color PressedForeColor
        {
            get => _pressedForeColor;
            set { _pressedForeColor = value; }
        }

        [Category("Modern UI")]
        public int BorderThickness
        {
            get => _borderThickness;
            set { _borderThickness = value; Invalidate(); }
        }

        [Category("Modern UI")]
        public Image IconLeft
        {
            get => _iconLeft;
            set { _iconLeft = value; Invalidate(); }
        }

        [Category("Modern UI")]
        public Image IconRight
        {
            get => _iconRight;
            set { _iconRight = value; Invalidate(); }
        }

        [Category("Modern UI")]
        public Size IconSize
        {
            get => _iconSize;
            set { _iconSize = value; Invalidate(); }
        }

        [Category("Modern UI")]
        public ContentAlignment TextAlign
        {
            get => _textAlign;
            set { _textAlign = value; Invalidate(); }
        }

        [Category("Modern UI")]
        public ButtonStyle ButtonStyle
        {
            get => _buttonStyle;
            set { _buttonStyle = value; Invalidate(); }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _state = MouseState.Hover;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _state = MouseState.Normal;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                _state = MouseState.Pressed;
                Invalidate();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.Button == MouseButtons.Left)
            {
                _state = ClientRectangle.Contains(e.Location) ? MouseState.Hover : MouseState.Normal;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);

            Color currentBackColor = _backColor;
            Color currentForeColor = _foreColor;
            Color currentBorderColor = _borderColor;

            switch (_state)
            {
                case MouseState.Hover:
                    currentBackColor = _hoverBackColor;
                    currentForeColor = _hoverForeColor;
                    currentBorderColor = _hoverBorderColor;
                    break;
                case MouseState.Pressed:
                    currentBackColor = _pressedBackColor;
                    currentForeColor = _pressedForeColor;
                    currentBorderColor = _hoverBorderColor; // Typically reuse hover border
                    break;
            }

            // Draw Background
            if (_buttonStyle != ButtonStyle.Outline)
            {
                using (SolidBrush brush = new SolidBrush(currentBackColor))
                {
                    if (_buttonStyle == ButtonStyle.Flat && _state == MouseState.Normal)
                    {
                        // Maybe transparent backcolor for flat normal
                    }
                    else
                    {
                        GraphicsHelper.FillRoundedRect(g, brush, rect, _borderRadius);
                    }
                }
            }

            // Draw Border
            if ((_buttonStyle == ButtonStyle.Outline && _borderThickness > 0) || _borderThickness > 0)
            {
                using (Pen pen = new Pen(currentBorderColor, _borderThickness))
                {
                    pen.Alignment = PenAlignment.Inset;
                    GraphicsHelper.DrawRoundedRect(g, pen, rect, _borderRadius);
                }
            }

            // Draw Text and Icons
            int textWidth = TextRenderer.MeasureText(Text, Font).Width;
            int totalWidth = textWidth;
            if (_iconLeft != null) totalWidth += _iconSize.Width + 5;
            if (_iconRight != null) totalWidth += _iconSize.Width + 5;

            int startX = (Width - totalWidth) / 2;
            
            // Adjust alignment
            switch (_textAlign)
            {
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.TopLeft:
                case ContentAlignment.BottomLeft:
                    startX = 10;
                    break;
                case ContentAlignment.MiddleRight:
                case ContentAlignment.TopRight:
                case ContentAlignment.BottomRight:
                    startX = Width - totalWidth - 10;
                    break;
            }

            int currentX = startX;

            if (_iconLeft != null)
            {
                g.DrawImage(_iconLeft, new Rectangle(currentX, (Height - _iconSize.Height) / 2, _iconSize.Width, _iconSize.Height));
                currentX += _iconSize.Width + 5;
            }

            using (SolidBrush textBrush = new SolidBrush(currentForeColor))
            {
                StringFormat sf = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                Rectangle textRect = new Rectangle(currentX, 0, textWidth, Height);
                g.DrawString(Text, Font, textBrush, textRect, sf);
                currentX += textWidth + 5;
            }

            if (_iconRight != null)
            {
                g.DrawImage(_iconRight, new Rectangle(currentX, (Height - _iconSize.Height) / 2, _iconSize.Width, _iconSize.Height));
            }
        }
    }
}
