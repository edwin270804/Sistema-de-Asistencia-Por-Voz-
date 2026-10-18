using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SistemaAsistenciaPorVoz.UI.UserControls;

public class SimpleGlassPanel : Panel
{
    public int CornerRadius { get; set; } = 20;

    public SimpleGlassPanel()
    {
        SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.UserPaint |
            ControlStyles.OptimizedDoubleBuffer |
            ControlStyles.ResizeRedraw,
            true
        );
        UpdateStyles();
        BackColor = Color.Transparent;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

        var parentColor = Parent?.BackColor ?? Color.Black;
        e.Graphics.Clear(parentColor);

        var rect = new Rectangle(0, 0, Width - 1, Height - 1);
        using var path = GetRoundedPath(rect, CornerRadius);

        // Relleno tipo vidrio
        using (var brush = new LinearGradientBrush(
            rect,
            Color.FromArgb(55, 255, 255, 255),
            Color.FromArgb(15, 255, 255, 255),
            LinearGradientMode.Vertical))
        {
            e.Graphics.FillPath(brush, path);
        }

        // Borde claro
        using (var pen = new Pen(Color.FromArgb(75, 255, 255, 255), 1.2f))
        {
            e.Graphics.DrawPath(pen, path);
        }

        // Línea brillante arriba
        using (var highlight = new Pen(Color.FromArgb(130, 255, 255, 255), 1.2f))
        {
            e.Graphics.DrawArc(
                highlight,
                rect.X + CornerRadius,
                rect.Y + 1,
                rect.Width - CornerRadius * 2,
                CornerRadius * 2,
                180,
                180
            );
        }

        base.OnPaint(e);
    }

    private static GraphicsPath GetRoundedPath(Rectangle rect, int radius)
    {
        var path = new GraphicsPath();
        int d = radius * 2;

        path.AddArc(rect.X, rect.Y, d, d, 180, 90);
        path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
        path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
        path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
        path.CloseFigure();

        return path;
    }
}