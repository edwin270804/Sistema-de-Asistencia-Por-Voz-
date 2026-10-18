using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ModernUI.Helpers;

namespace ModernUI.Controls
{
    [DefaultEvent("TextChanged")]
    public class ModernTextBox : UserControl
    {
        private TextBox _textBox;
        
        // Properties
        private int _borderRadius = 8;
        private Color _borderColor = Color.Gray;
        private Color _focusBorderColor = Color.FromArgb(0, 122, 204);
        private Color _backgroundColor = Color.White;
        private Color _foregroundColor = Color.Black;
        private int _borderThickness = 2;
        private string _placeholderText = "";
        private Color _placeholderColor = Color.DarkGray;
        
        private Image _iconLeft;
        private Image _iconRight;
        
        private bool _isFocused = false;
        
        public ModernTextBox()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.SupportsTransparentBackColor, true);
            
            BackColor = Color.Transparent;
            Padding = new Padding(10, 7, 10, 7);
            Size = new Size(250, 40);
            
            _textBox = new TextBox();
            _textBox.BorderStyle = BorderStyle.None;
            _textBox.BackColor = _backgroundColor;
            _textBox.ForeColor = _foregroundColor;
            _textBox.Location = new Point(Padding.Left, Padding.Top);
            _textBox.Size = new Size(Width - Padding.Left - Padding.Right, Height - Padding.Top - Padding.Bottom);
            _textBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            
            _textBox.Enter += TextBox_Enter;
            _textBox.Leave += TextBox_Leave;
            _textBox.TextChanged += TextBox_TextChanged;
            
            Controls.Add(_textBox);
            UpdateTextBox();
        }
        
        [Category("Modern UI")]
        public int BorderRadius
        {
            get => _borderRadius;
            set { _borderRadius = value; Invalidate(); }
        }
        
        [Category("Modern UI")]
        public Color BorderColor
        {
            get => _borderColor;
            set { _borderColor = value; Invalidate(); }
        }
        
        [Category("Modern UI")]
        public Color FocusBorderColor
        {
            get => _focusBorderColor;
            set { _focusBorderColor = value; Invalidate(); }
        }
        
        [Category("Modern UI")]
        public Color BackgroundColor
        {
            get => _backgroundColor;
            set 
            { 
                _backgroundColor = value; 
                _textBox.BackColor = value;
                Invalidate(); 
            }
        }
        
        [Category("Modern UI")]
        public Color ForegroundColor
        {
            get => _foregroundColor;
            set 
            { 
                _foregroundColor = value; 
                if (!_isFocused && string.IsNullOrEmpty(_textBox.Text) && !string.IsNullOrEmpty(_placeholderText))
                    _textBox.ForeColor = _placeholderColor;
                else
                    _textBox.ForeColor = value;
            }
        }
        
        [Category("Modern UI")]
        public int BorderThickness
        {
            get => _borderThickness;
            set { _borderThickness = value; Invalidate(); }
        }
        
        [Category("Modern UI")]
        public string PlaceholderText
        {
            get => _placeholderText;
            set 
            { 
                _placeholderText = value; 
                UpdatePlaceholder();
            }
        }
        
        [Category("Modern UI")]
        public Color PlaceholderColor
        {
            get => _placeholderColor;
            set 
            { 
                _placeholderColor = value; 
                UpdatePlaceholder();
            }
        }
        
        [Category("Modern UI")]
        public char PasswordChar
        {
            get => _textBox.PasswordChar;
            set => _textBox.PasswordChar = value;
        }
        
        [Category("Modern UI")]
        public int MaxLength
        {
            get => _textBox.MaxLength;
            set => _textBox.MaxLength = value;
        }
        
        [Category("Modern UI")]
        public bool ReadOnly
        {
            get => _textBox.ReadOnly;
            set => _textBox.ReadOnly = value;
        }
        
        [Category("Modern UI")]
        public HorizontalAlignment TextAlign
        {
            get => _textBox.TextAlign;
            set => _textBox.TextAlign = value;
        }
        
        [Category("Modern UI")]
        public bool Multiline
        {
            get => _textBox.Multiline;
            set 
            { 
                _textBox.Multiline = value; 
                UpdateTextBox();
            }
        }
        
        [Category("Modern UI")]
        public Image IconLeft
        {
            get => _iconLeft;
            set { _iconLeft = value; UpdateTextBox(); Invalidate(); }
        }
        
        [Category("Modern UI")]
        public Image IconRight
        {
            get => _iconRight;
            set { _iconRight = value; UpdateTextBox(); Invalidate(); }
        }
        
        [Category("Modern UI")]
        public override Font Font
        {
            get => base.Font;
            set
            {
                base.Font = value;
                _textBox.Font = value;
                if (DesignMode) UpdateTextBox();
            }
        }
        
        [Category("Modern UI")]
        public override string Text
        {
            get => (_isFocused || string.IsNullOrEmpty(_placeholderText)) ? _textBox.Text : 
                   (_textBox.Text == _placeholderText ? "" : _textBox.Text);
            set
            {
                _textBox.Text = value;
                UpdatePlaceholder();
            }
        }
        
        public new event EventHandler TextChanged;
        
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (_isFocused || _textBox.Text != _placeholderText)
            {
                TextChanged?.Invoke(this, e);
            }
        }
        
        private void TextBox_Enter(object sender, EventArgs e)
        {
            _isFocused = true;
            if (_textBox.Text == _placeholderText)
            {
                _textBox.Text = "";
                _textBox.ForeColor = _foregroundColor;
            }
            Invalidate();
        }
        
        private void TextBox_Leave(object sender, EventArgs e)
        {
            _isFocused = false;
            UpdatePlaceholder();
            Invalidate();
        }
        
        private void UpdatePlaceholder()
        {
            if (!_isFocused && string.IsNullOrEmpty(_textBox.Text) && !string.IsNullOrEmpty(_placeholderText))
            {
                _textBox.Text = _placeholderText;
                _textBox.ForeColor = _placeholderColor;
            }
            else if (string.IsNullOrEmpty(_textBox.Text))
            {
                _textBox.ForeColor = _foregroundColor;
            }
        }
        
        private void UpdateTextBox()
        {
            int iconLeftWidth = _iconLeft != null ? Height - 10 : 0;
            int iconRightWidth = _iconRight != null ? Height - 10 : 0;
            
            Padding = new Padding(10 + iconLeftWidth, 7, 10 + iconRightWidth, 7);
            _textBox.Location = new Point(Padding.Left, Padding.Top);
            
            if (_textBox.Multiline)
            {
                _textBox.Size = new Size(Width - Padding.Left - Padding.Right, Height - Padding.Top - Padding.Bottom);
            }
            else
            {
                int txtHeight = TextRenderer.MeasureText("Text", Font).Height;
                _textBox.Size = new Size(Width - Padding.Left - Padding.Right, txtHeight);
                _textBox.Location = new Point(Padding.Left, (Height - txtHeight) / 2);
            }
        }
        
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UpdateTextBox();
        }
        
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            
            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
            
            // Draw background
            using (SolidBrush brush = new SolidBrush(_backgroundColor))
            {
                GraphicsHelper.FillRoundedRect(g, brush, rect, _borderRadius);
            }
            
            // Draw icons
            if (_iconLeft != null)
            {
                int iconSize = Height - 20;
                g.DrawImage(_iconLeft, new Rectangle(10, 10, iconSize, iconSize));
            }
            
            if (_iconRight != null)
            {
                int iconSize = Height - 20;
                g.DrawImage(_iconRight, new Rectangle(Width - 10 - iconSize, 10, iconSize, iconSize));
            }
            
            // Draw border
            Color borderColor = _isFocused ? _focusBorderColor : _borderColor;
            if (_borderThickness > 0)
            {
                using (Pen pen = new Pen(borderColor, _borderThickness))
                {
                    pen.Alignment = PenAlignment.Inset;
                    GraphicsHelper.DrawRoundedRect(g, pen, rect, _borderRadius);
                }
            }
        }
    }
}
