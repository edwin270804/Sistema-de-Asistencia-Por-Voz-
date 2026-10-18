using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Windows.Forms;
using ModernUI.Helpers;

namespace ModernUI.Controls
{
    public class ModernDataGridView : DataGridView
    {
        private Color _headerBackColor = Color.DarkBlue;
        private Color _headerForeColor = Color.White;
        private Font _headerFont = new Font("Segoe UI", 10F, FontStyle.Bold);
        private Color _rowBackColor = Color.White;
        private Color _alternateRowBackColor = Color.FromArgb(245, 245, 245);
        private Color _rowForeColor = Color.Black;
        private Color _rowHoverBackColor = Color.LightBlue;
        private Color _selectedRowBackColor = Color.Blue;
        private Color _selectedRowForeColor = Color.White;
        private Color _gridLineColor = Color.LightGray;
        private int _borderRadius = 0;
        private bool _showGridLines = false;
        private int _rowHeight = 35;
        private int _headerHeight = 40;
        private bool _enableRowHover = true;

        private int _hoveredRowIndex = -1;

        public ModernDataGridView()
        {
            // Enable double buffering via reflection
            typeof(DataGridView).InvokeMember("DoubleBuffered", 
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, 
                null, this, new object[] { true });

            this.EnableHeadersVisualStyles = false;
            this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.RowHeadersVisible = false;
            this.AllowUserToAddRows = false;
            this.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.BackgroundColor = Color.White;
            this.BorderStyle = BorderStyle.None;
            this.CellBorderStyle = DataGridViewCellBorderStyle.None;
            this.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            
            this.CellMouseEnter += ModernDataGridView_CellMouseEnter;
            this.CellMouseLeave += ModernDataGridView_CellMouseLeave;
            
            ApplyModernStyle();
        }

        [Category("Modern UI"), DefaultValue(typeof(Color), "DarkBlue")]
        public Color HeaderBackColor
        {
            get => _headerBackColor;
            set { _headerBackColor = value; ApplyModernStyle(); }
        }

        [Category("Modern UI"), DefaultValue(typeof(Color), "White")]
        public Color HeaderForeColor
        {
            get => _headerForeColor;
            set { _headerForeColor = value; ApplyModernStyle(); }
        }

        [Category("Modern UI")]
        public Font HeaderFont
        {
            get => _headerFont;
            set { _headerFont = value; ApplyModernStyle(); }
        }

        [Category("Modern UI"), DefaultValue(typeof(Color), "White")]
        public Color RowBackColor
        {
            get => _rowBackColor;
            set { _rowBackColor = value; ApplyModernStyle(); }
        }

        [Category("Modern UI")]
        public Color AlternateRowBackColor
        {
            get => _alternateRowBackColor;
            set { _alternateRowBackColor = value; ApplyModernStyle(); }
        }

        [Category("Modern UI"), DefaultValue(typeof(Color), "Black")]
        public Color RowForeColor
        {
            get => _rowForeColor;
            set { _rowForeColor = value; ApplyModernStyle(); }
        }

        [Category("Modern UI"), DefaultValue(typeof(Color), "LightBlue")]
        public Color RowHoverBackColor
        {
            get => _rowHoverBackColor;
            set { _rowHoverBackColor = value; ApplyModernStyle(); }
        }

        [Category("Modern UI"), DefaultValue(typeof(Color), "Blue")]
        public Color SelectedRowBackColor
        {
            get => _selectedRowBackColor;
            set { _selectedRowBackColor = value; ApplyModernStyle(); }
        }

        [Category("Modern UI"), DefaultValue(typeof(Color), "White")]
        public Color SelectedRowForeColor
        {
            get => _selectedRowForeColor;
            set { _selectedRowForeColor = value; ApplyModernStyle(); }
        }

        [Category("Modern UI"), DefaultValue(typeof(Color), "LightGray")]
        public Color GridLineColor
        {
            get => _gridLineColor;
            set { _gridLineColor = value; ApplyModernStyle(); }
        }

        [Category("Modern UI"), DefaultValue(0)]
        public int BorderRadius
        {
            get => _borderRadius;
            set 
            { 
                _borderRadius = value; 
                UpdateRegion();
                this.Invalidate(); 
            }
        }

        [Category("Modern UI"), DefaultValue(false)]
        public bool ShowGridLines
        {
            get => _showGridLines;
            set { _showGridLines = value; ApplyModernStyle(); }
        }

        [Category("Modern UI"), DefaultValue(35)]
        public int RowHeight
        {
            get => _rowHeight;
            set { _rowHeight = value; ApplyModernStyle(); }
        }

        [Category("Modern UI"), DefaultValue(40)]
        public int HeaderHeight
        {
            get => _headerHeight;
            set { _headerHeight = value; ApplyModernStyle(); }
        }

        [Category("Modern UI"), DefaultValue(true)]
        public bool EnableRowHover
        {
            get => _enableRowHover;
            set { _enableRowHover = value; }
        }

        private void ApplyModernStyle()
        {
            this.ColumnHeadersDefaultCellStyle.BackColor = _headerBackColor;
            this.ColumnHeadersDefaultCellStyle.ForeColor = _headerForeColor;
            if (_headerFont != null)
                this.ColumnHeadersDefaultCellStyle.Font = _headerFont;
            
            this.ColumnHeadersHeight = _headerHeight;
            this.RowTemplate.Height = _rowHeight;

            this.DefaultCellStyle.BackColor = _rowBackColor;
            this.DefaultCellStyle.ForeColor = _rowForeColor;
            this.DefaultCellStyle.SelectionBackColor = _selectedRowBackColor;
            this.DefaultCellStyle.SelectionForeColor = _selectedRowForeColor;

            this.AlternatingRowsDefaultCellStyle.BackColor = _alternateRowBackColor;
            this.AlternatingRowsDefaultCellStyle.ForeColor = _rowForeColor;
            this.AlternatingRowsDefaultCellStyle.SelectionBackColor = _selectedRowBackColor;
            this.AlternatingRowsDefaultCellStyle.SelectionForeColor = _selectedRowForeColor;

            this.GridColor = _gridLineColor;
            this.CellBorderStyle = _showGridLines ? DataGridViewCellBorderStyle.SingleHorizontal : DataGridViewCellBorderStyle.None;
            
            UpdateRegion();
            this.Invalidate();
        }

        private void UpdateRegion()
        {
            if (_borderRadius > 0 && this.Width > 0 && this.Height > 0)
            {
                GraphicsPath path = GraphicsHelper.RoundedRect(new Rectangle(0, 0, this.Width, this.Height), _borderRadius);
                this.Region = new Region(path);
            }
            else
            {
                this.Region = new Region(new Rectangle(0, 0, this.Width, this.Height));
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UpdateRegion();
        }

        private void ModernDataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (_enableRowHover && e.RowIndex >= 0)
            {
                _hoveredRowIndex = e.RowIndex;
                this.InvalidateRow(_hoveredRowIndex);
            }
        }

        private void ModernDataGridView_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (_enableRowHover && _hoveredRowIndex >= 0)
            {
                int oldIndex = _hoveredRowIndex;
                _hoveredRowIndex = -1;
                if (oldIndex < this.RowCount)
                {
                    this.InvalidateRow(oldIndex);
                }
            }
        }

        protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e)
        {
            if (_enableRowHover && e.RowIndex >= 0 && e.RowIndex == _hoveredRowIndex)
            {
                if ((e.State & DataGridViewElementStates.Selected) != DataGridViewElementStates.Selected)
                {
                    e.Graphics.FillRectangle(new SolidBrush(_rowHoverBackColor), e.CellBounds);
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.Background);
                    e.Handled = true;
                    return;
                }
            }
            
            base.OnCellPainting(e);
        }
    }
}
