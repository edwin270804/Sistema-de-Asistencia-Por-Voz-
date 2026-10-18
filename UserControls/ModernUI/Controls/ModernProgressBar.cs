using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ModernUI.Helpers;

namespace ModernUI.Controls
{
    [DefaultEvent("ValueChanged")]
    public class ModernProgressBar : Control
    {
        private int _value = 0;
        private int _minimum = 0;
        private int _maximum = 100;
        private int _borderRadius = 10;
        private Color _progressColor = Color.Blue;
        private Color _backgroundBarColor = Color.LightGray;
        private Color? _gradientStartColor = null;
        private Color? _gradientEndColor = null;
        private float _gradientAngle = 0f;
        private bool _showPercentage = false;
        private Color _percentageColor = Color.Black;
        private int? _barHeight = null;
        private int _animationSpeed = 10;
        private bool _enableAnimation = true;

        private float _currentVisualValue = 0f;
        private System.Windows.Forms.Timer _animationTimer;

        public event EventHandler ValueChanged;

        public ModernProgressBar()
        {
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
            this.Size = new Size(300, 25);
            this.BackColor = Color.Transparent;

            _animationTimer = new System.Windows.Forms.Timer();
            _animationTimer.Interval = 15;
            _animationTimer.Tick += AnimationTimer_Tick;
        }

        [Category("Modern UI"), DefaultValue(0)]
        public int Value
        {
            get => _value;
            set
            {
                int val = Math.Max(_minimum, Math.Min(_maximum, value));
                if (_value != val)
                {
                    _value = val;
                    if (_enableAnimation)
                    {
                        _animationTimer.Start();
                    }
                    else
                    {
                        _currentVisualValue = _value;
                        this.Invalidate();
                    }
                    ValueChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        [Category("Modern UI"), DefaultValue(0)]
        public int Minimum
        {
            get => _minimum;
            set { _minimum = value; if (_value < _minimum) Value = _minimum; this.Invalidate(); }
        }

        [Category("Modern UI"), DefaultValue(100)]
        public int Maximum
        {
            get => _maximum;
            set { _maximum = value; if (_value > _maximum) Value = _maximum; this.Invalidate(); }
        }

        [Category("Modern UI"), DefaultValue(10)]
        public int BorderRadius
        {
            get => _borderRadius;
            set { _borderRadius = value; this.Invalidate(); }
        }

        [Category("Modern UI"), DefaultValue(typeof(Color), "Blue")]
        public Color ProgressColor
        {
            get => _progressColor;
            set { _progressColor = value; this.Invalidate(); }
        }

        [Category("Modern UI"), DefaultValue(typeof(Color), "LightGray")]
        public Color BackgroundBarColor
        {
            get => _backgroundBarColor;
            set { _backgroundBarColor = value; this.Invalidate(); }
        }

        [Category("Modern UI"), DefaultValue(null)]
        public Color? GradientStartColor
        {
            get => _gradientStartColor;
            set { _gradientStartColor = value; this.Invalidate(); }
        }

        [Category("Modern UI"), DefaultValue(null)]
        public Color? GradientEndColor
        {
            get => _gradientEndColor;
            set { _gradientEndColor = value; this.Invalidate(); }
        }

        [Category("Modern UI"), DefaultValue(0f)]
        public float GradientAngle
        {
            get => _gradientAngle;
            set { _gradientAngle = value; this.Invalidate(); }
        }

        [Category("Modern UI"), DefaultValue(false)]
        public bool ShowPercentage
        {
            get => _showPercentage;
            set { _showPercentage = value; this.Invalidate(); }
        }

        [Category("Modern UI"), DefaultValue(typeof(Color), "Black")]
        public Color PercentageColor
        {
            get => _percentageColor;
            set { _percentageColor = value; this.Invalidate(); }
        }

        [Category("Modern UI"), DefaultValue(null)]
        public int? BarHeight
        {
            get => _barHeight;
            set { _barHeight = value; this.Invalidate(); }
        }

        [Category("Modern UI"), DefaultValue(10)]
        public int AnimationSpeed
        {
            get => _animationSpeed;
            set { _animationSpeed = value; }
        }

        [Category("Modern UI"), DefaultValue(true)]
        public bool EnableAnimation
        {
            get => _enableAnimation;
            set
            {
                _enableAnimation = value;
                if (!value)
                {
                    _animationTimer.Stop();
                    _currentVisualValue = _value;
                    this.Invalidate();
                }
            }
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            float diff = _value - _currentVisualValue;
            if (Math.Abs(diff) < 0.5f)
            {
                _currentVisualValue = _value;
                _animationTimer.Stop();
            }
            else
            {
                _currentVisualValue += diff * (_animationSpeed / 100f);
            }
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int barH = _barHeight ?? this.Height;
            int barY = (this.Height - barH) / 2;
            Rectangle barRect = new Rectangle(0, barY, this.Width, barH);

            if (barRect.Width <= 0 || barRect.Height <= 0) return;

            // Draw Background
            using (GraphicsPath pathBg = GraphicsHelper.RoundedRect(barRect, _borderRadius))
            using (SolidBrush brushBg = new SolidBrush(_backgroundBarColor))
            {
                g.FillPath(brushBg, pathBg);
            }

            // Calculate progress width based on current visual value
            float range = _maximum - _minimum;
            float percent = range > 0 ? (_currentVisualValue - _minimum) / range : 0;
            int progressWidth = (int)(barRect.Width * percent);

            if (progressWidth > 0)
            {
                Rectangle progressRect = new Rectangle(barRect.X, barRect.Y, progressWidth, barRect.Height);
                using (GraphicsPath pathProgress = GraphicsHelper.RoundedRect(progressRect, _borderRadius))
                {
                    Brush progressBrush;
                    if (_gradientStartColor.HasValue && _gradientEndColor.HasValue)
                    {
                        Rectangle gradRect = new Rectangle(barRect.X, barRect.Y, barRect.Width, barRect.Height);
                        progressBrush = new LinearGradientBrush(gradRect, _gradientStartColor.Value, _gradientEndColor.Value, _gradientAngle);
                    }
                    else
                    {
                        progressBrush = new SolidBrush(_progressColor);
                    }

                    g.SetClip(pathProgress);
                    g.FillPath(progressBrush, pathProgress);
                    g.ResetClip();

                    progressBrush.Dispose();
                }
            }

            // Draw Percentage
            if (_showPercentage)
            {
                string text = $"{(int)(percent * 100)}%";
                using (SolidBrush textBrush = new SolidBrush(_percentageColor))
                {
                    StringFormat sf = new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    };
                    g.DrawString(text, this.Font, textBrush, barRect, sf);
                }
            }
        }
    }
}
