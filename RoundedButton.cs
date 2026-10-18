/*using System.Drawing.Drawing2D;

namespace SistemaDeAsistenciaPorVoz.Presentacion.Controls
{
    public class RoundedButton : Button
    {
        public int BorderRadius { get; set; } = 15;

        public Color BorderColor { get; set; } = Color.Transparent;

        public int BorderSize { get; set; } = 0;

        public Color HoverColor { get; set; } = Color.FromArgb(30, 130, 255);

        private Color colorNormal;

        public RoundedButton()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;

            BackColor = Color.FromArgb(8, 123, 255);
            ForeColor = Color.White;

            Font = new Font(
                "Segoe UI",
                10.5F,
                FontStyle.Bold
            );

            Cursor = Cursors.Hand;

            colorNormal = BackColor;

            SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw,
                true
            );
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            BackColor = HoverColor;

            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            BackColor = colorNormal;

            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode =
                SmoothingMode.AntiAlias;

            e.Graphics.PixelOffsetMode =
                PixelOffsetMode.HighQuality;

            e.Graphics.CompositingQuality =
                CompositingQuality.HighQuality;

            Rectangle rect = new Rectangle(
                BorderSize,
                BorderSize,
                Width - BorderSize * 2 - 1,
                Height - BorderSize * 2 - 1
            );

            using GraphicsPath path =
                CrearRutaRedondeada(rect, BorderRadius);

            using SolidBrush brush =
                new SolidBrush(BackColor);

            e.Graphics.FillPath(
                brush,
                path
            );

            if (BorderSize > 0)
            {
                using Pen pen = new Pen(
                    BorderColor,
                    BorderSize
                );

                e.Graphics.DrawPath(
                    pen,
                    path
                );
            }

            TextRenderer.DrawText(
                e.Graphics,
                Text,
                Font,
                rect,
                ForeColor,
                TextFormatFlags.HorizontalCenter |
                TextFormatFlags.VerticalCenter
            );
        }

        private GraphicsPath CrearRutaRedondeada(
            Rectangle rect,
            int radius)
        {
            GraphicsPath path = new GraphicsPath();

            int diameter = radius * 2;

            path.AddArc(
                rect.X,
                rect.Y,
                diameter,
                diameter,
                180,
                90
            );

            path.AddArc(
                rect.Right - diameter,
                rect.Y,
                diameter,
                diameter,
                270,
                90
            );

            path.AddArc(
                rect.Right - diameter,
                rect.Bottom - diameter,
                diameter,
                diameter,
                0,
                90
            );

            path.AddArc(
                rect.X,
                rect.Bottom - diameter,
                diameter,
                diameter,
                90,
                90
            );

            path.CloseFigure();

            return path;
        }
    }
}*/