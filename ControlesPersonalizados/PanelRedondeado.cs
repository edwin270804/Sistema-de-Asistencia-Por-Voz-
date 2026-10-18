using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SistemaAsistenciaPorVoz.UI.ControlesPersonalizados
{
    public class PanelRedondeado : Panel
    {
        public int RadioBorde { get; set; } = 20;
        public Color ColorFondo { get; set; } = Color.FromArgb(30,35,50);

        public PanelRedondeado()
        {
            this.DoubleBuffered = true;
            this.BackColor = Color.Transparent;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(0,0, RadioBorde,RadioBorde,180,90);
                path.AddArc(this.Width - RadioBorde,0,RadioBorde,RadioBorde,270,90);
                path.AddArc(this.Width - RadioBorde, this.Height - RadioBorde,RadioBorde,RadioBorde,0,90);
                path.AddArc(0,this.Height - RadioBorde ,RadioBorde,RadioBorde,90,90);
                path.CloseFigure();

                using (SolidBrush brush = new SolidBrush(ColorFondo))
                {
                    e.Graphics.FillPath(brush, path);
                }
            }
        }
    }
}
