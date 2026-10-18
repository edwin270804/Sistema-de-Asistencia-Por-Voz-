using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ModernUI.Helpers;

namespace ModernUI.Controls
{
    public class ModernPanel : Panel
    {
        private int _borderRadius = 10;
        private Color _borderColor = Color.LightGray;
        private int _borderThickness = 1;
        private Color? _gradientStartColor;
        private Color? _gradientEndColor;
        private float _gradientAngle = 45f;
        private bool _enableShadow = false;
        private Color _shadowColor = Color.FromArgb(50, 0, 0, 0);
        private int _shadowDepth = 5;

        public ModernPanel()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
        }

        [Category("Modern UI"), DefaultValue(10)]
        public int BorderRadius { get => _borderRadius; set { _borderRadius = value; UpdateRegion(); Invalidate(); } }
        [Category("Modern UI")]
        public Color BorderColor { get => _borderColor; set { _borderColor = value; Invalidate(); } }
        [Category("Modern UI"), DefaultValue(1)]
        public int BorderThickness { get => _borderThickness; set { _borderThickness = value; Invalidate(); } }
        [Category("Modern UI")]
        public Color? GradientStartColor { get => _gradientStartColor; set { _gradientStartColor = value; Invalidate(); } }
        [Category("Modern UI")]
        public Color? GradientEndColor { get => _gradientEndColor; set { _gradientEndColor = value; Invalidate(); } }
        [Category("Modern UI"), DefaultValue(45f)]
        public float GradientAngle { get => _gradientAngle; set { _gradientAngle = value; Invalidate(); } }
        [Category("Modern UI"), DefaultValue(false)]
        public bool EnableShadow { get => _enableShadow; set { _enableShadow = value; Invalidate(); } }
        [Category("Modern UI")]
        public Color ShadowColor { get => _shadowColor; set { _shadowColor = value; Invalidate(); } }
        [Category("Modern UI"), DefaultValue(5)]
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

            if (_gradientStartColor.HasValue && _gradientEndColor.HasValue)
            {
                using (var brush = new LinearGradientBrush(rect, _gradientStartColor.Value, _gradientEndColor.Value, _gradientAngle))
                {
                    if (_borderRadius > 0)
                    {
                        using (var path = GraphicsHelper.RoundedRect(rect, _borderRadius))
                        {
                            g.FillPath(brush, path);
                        }
                    }
                    else
                    {
                        g.FillRectangle(brush, rect);
                    }
                }
            }
            else
            {
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
