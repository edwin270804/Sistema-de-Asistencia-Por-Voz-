using System.Drawing;
using System.Drawing.Drawing2D;

namespace ModernUI.Helpers;

public static class GraphicsHelper
{
    public static GraphicsPath RoundedRect(Rectangle bounds, int radius)
    {
        var path = new GraphicsPath();
        if (radius <= 0)
        {
            path.AddRectangle(bounds);
            return path;
        }

        int d = radius * 2;
        var arc = new Rectangle(bounds.X, bounds.Y, d, d);

        path.AddArc(arc, 180, 90);
        arc.X = bounds.Right - d;
        path.AddArc(arc, 270, 90);
        arc.Y = bounds.Bottom - d;
        path.AddArc(arc, 0, 90);
        arc.X = bounds.Left;
        path.AddArc(arc, 90, 90);
        path.CloseFigure();

        return path;
    }

    public static void DrawRoundedRect(Graphics g, Pen pen, Rectangle bounds, int radius)
    {
        using (var path = RoundedRect(bounds, radius))
        {
            g.DrawPath(pen, path);
        }
    }

    public static void FillRoundedRect(Graphics g, Brush brush, Rectangle bounds, int radius)
    {
        using (var path = RoundedRect(bounds, radius))
        {
            g.FillPath(brush, path);
        }
    }

    public static void DrawShadow(Graphics g, Rectangle bounds, int radius, int shadowDepth, Color shadowColor)
    {
        if (shadowDepth <= 0) return;

        for (int i = 0; i < shadowDepth; i++)
        {
            // Reduce alpha as it goes further down/out
            int alpha = (int)((shadowDepth - i) * (50.0f / shadowDepth));
            if (alpha > 255) alpha = 255;
            if (alpha < 0) alpha = 0;
            using (var brush = new SolidBrush(Color.FromArgb(alpha, shadowColor)))
            {
                var shadowRect = new Rectangle(bounds.X + i, bounds.Y + i, bounds.Width, bounds.Height);
                FillRoundedRect(g, brush, shadowRect, radius);
            }
        }
    }
}
