using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ModernUI.Helpers;

namespace ModernUI.Controls
{
    public class ModernCard : Panel
    {
        private int _borderRadius = 12;
        private Color _borderColor = Color.LightGray;
        private int _borderThickness = 1;
        private string _headerText = "Card Header";
        private Font _headerFont = new Font("Segoe UI", 12f, FontStyle.Bold);
        private Color _headerForeColor = Color.Black;
        private Color? _headerBackColor;
        private int _headerHeight = 40;
        private bool _showHeader = true;
        private bool _enableShadow = true;
        private Color _shadowColor = Color.FromArgb(30, 0, 0, 0);
        private int _shadowDepth = 4;

        public ModernCard()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
        }

        [Category("Modern UI"), DefaultValue(12)]
        public int BorderRadius { get => _borderRadius; set { _borderRadius = value; UpdateRegion(); Invalidate(); } }
        [Category("Modern UI")]
        public Color BorderColor { get => _borderColor; set { _borderColor = value; Invalidate(); } }
        [Category("Modern UI"), DefaultValue(1)]
        public int BorderThickness { get => _borderThickness; set { _borderThickness = value; Invalidate(); } }
        [Category("Modern UI"), DefaultValue("Card Header")]
        public string HeaderText { get => _headerText; set { _headerText = value; Invalidate(); } }
        [Category("Modern UI")]
        public Font HeaderFont { get => _headerFont; set { _headerFont = value; Invalidate(); } }
        [Category("Modern UI")]
        public Color HeaderForeColor { get => _headerForeColor; set { _headerForeColor = value; Invalidate(); } }
        [Category("Modern UI")]
        public Color? HeaderBackColor { get => _headerBackColor; set { _headerBackColor = value; Invalidate(); } }
        [Category("Modern UI"), DefaultValue(40)]
        public int HeaderHeight { get => _headerHeight; set { _headerHeight = value; Invalidate(); } }
        [Category("Modern UI"), DefaultValue(true)]
        public bool ShowHeader { get => _showHeader; set { _showHeader = value; Invalidate(); } }
        [Category("Modern UI"), DefaultValue(true)]
        public bool EnableShadow { get => _enableShadow; set { _enableShadow = value; Invalidate(); } }
        [Category("Modern UI")]
        public Color ShadowColor { get => _shadowColor; set { _shadowColor = value; Invalidate(); } }
        [Category("Modern UI"), DefaultValue(4)]
        public int ShadowDepth { get => _shadowDepth; set { _shadowDepth = value; Invalidate(); } }

        protected override void OnResize(EventArgs eventargs)
        {
            base.OnResize(eventargs);
            UpdateRegion();
            Invalidate();
        }

        private void UpdateRegion()
        {
            if (_borderRadius > 0)
            {
                using (var path = GraphicsHelper.RoundedRect(ClientRectangle, _borderRadius))
                {
                    Region = new Region(path);
                }
            }
            else
            {
                Region = new Region(ClientRectangle);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = ClientRectangle;
            if (_enableShadow)
            {
                rect.Inflate(-_shadowDepth, -_shadowDepth);
            }
            rect.Width -= 1;
            rect.Height -= 1;

            if (_enableShadow)
            {
                GraphicsHelper.DrawShadow(g, ClientRectangle, _borderRadius, _shadowDepth, _shadowColor);
            }

            using (var brush = new SolidBrush(BackColor))
            {
                if (_borderRadius > 0)
                {
                    GraphicsHelper.FillRoundedRect(g, brush, rect, _borderRadius);
                }
                else
                {
                    g.FillRectangle(brush, rect);
                }
            }

            if (_showHeader)
            {
                Rectangle headerRect = new Rectangle(rect.X, rect.Y, rect.Width, _headerHeight);
                if (_headerBackColor.HasValue)
                {
                    using (var headerBrush = new SolidBrush(_headerBackColor.Value))
                    {
                        if (_borderRadius > 0)
                        {
                            // A quick clip to keep the top rounded
                            using (var headerPath = GraphicsHelper.RoundedRect(headerRect, _borderRadius))
                            {
                                g.SetClip(headerPath);
                                g.FillRectangle(headerBrush, headerRect);
                                g.ResetClip();
                            }
                        }
                        else
                        {
                            g.FillRectangle(headerBrush, headerRect);
                        }
                    }
                }

                Rectangle textRect = new Rectangle(headerRect.X + 10, headerRect.Y, headerRect.Width - 20, headerRect.Height);
                TextFormatFlags flags = TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine | TextFormatFlags.Left | TextFormatFlags.EndEllipsis;
                TextRenderer.DrawText(g, _headerText, _headerFont, textRect, _headerForeColor, flags);
            }

            if (_borderThickness > 0)
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
        }
    }
}
