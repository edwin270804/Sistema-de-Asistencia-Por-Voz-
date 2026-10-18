using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ModernUI.Helpers;

namespace ModernUI.Controls
{
    public class ModernLabel : Label
    {
        private int _borderRadius = 0;
        private Color _badgeBackColor = Color.DodgerBlue;
        private Color _badgeForeColor = Color.White;
        private bool _enableBorder = false;
        private Color _borderColor = Color.LightGray;
        private int _borderThickness = 1;

        public ModernLabel()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
        }

        [Category("Modern UI"), DefaultValue(0)]
        public int BorderRadius { get => _borderRadius; set { _borderRadius = value; Invalidate(); } }
        [Category("Modern UI")]
        public Color BadgeBackColor { get => _badgeBackColor; set { _badgeBackColor = value; Invalidate(); } }
        [Category("Modern UI")]
        public Color BadgeForeColor { get => _badgeForeColor; set { _badgeForeColor = value; Invalidate(); } }
        [Category("Modern UI"), DefaultValue(false)]
        public bool EnableBorder { get => _enableBorder; set { _enableBorder = value; Invalidate(); } }
        [Category("Modern UI")]
        public Color BorderColor { get => _borderColor; set { _borderColor = value; Invalidate(); } }
        [Category("Modern UI"), DefaultValue(1)]
        public int BorderThickness { get => _borderThickness; set { _borderThickness = value; Invalidate(); } }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            
            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
            
            if (_borderRadius > 0)
            {
                using (var brush = new SolidBrush(_badgeBackColor))
                {
                    GraphicsHelper.FillRoundedRect(g, brush, rect, _borderRadius);
                }
            }
            else
            {
                using (var brush = new SolidBrush(BackColor))
                {
                    g.FillRectangle(brush, ClientRectangle);
                }
            }

            if (_enableBorder && _borderThickness > 0)
            {
                using (var pen = new Pen(_borderColor, _borderThickness))
                {
                    if (_borderRadius > 0)
                    {
                        GraphicsHelper.DrawRoundedRect(g, pen, rect, _borderRadius);
                    }
                    else
                    {
                        g.DrawRectangle(pen, rect);
                    }
                }
            }

            Color textColor = _borderRadius > 0 ? _badgeForeColor : ForeColor;
            TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine;
            TextRenderer.DrawText(g, Text, Font, ClientRectangle, textColor, flags);
        }
    }
}
