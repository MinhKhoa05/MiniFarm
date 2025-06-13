using System.Drawing;
using System.Drawing.Drawing2D;
using MiniFarm.Plants.Base;

namespace MiniFarm.Plants.Crops
{
    public class ChiliPepper : PlantBase
    {
        public override string PlantName { get; set; } = "Ớt";

        public override void Render(Graphics g, int x, int y, int size)
        {
            int centerX = x + size / 2;
            int baseY = y + size - 6;

            // Bóng đổ
            using (var shadowBrush = new SolidBrush(Color.FromArgb(40, 0, 0, 0)))
            {
                g.FillEllipse(shadowBrush, x + 3, baseY - 2, size - 6, 6);
            }

            // Vẽ 3 quả ớt
            for (int i = 0; i < 3; i++)
            {
                int offsetX = (i - 1) * 8;
                int chiliX = centerX + offsetX - 3;
                int chiliY = baseY - 18 - (i % 2) * 3;

                DrawChili(g, chiliX, chiliY);
            }

            // Vẽ lá ớt
            for (int i = 0; i < 4; i++)
            {
                int leafX = centerX + (i - 2) * 5;
                int leafY = baseY - 22;

                DrawLeaf(g, leafX, leafY);
            }
        }

        private void DrawChili(Graphics g, int x, int y)
        {
            Rectangle chiliBody = new Rectangle(x, y, 6, 14);

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddBezier(
                    new Point(x, y),
                    new Point(x + 2, y + 2),
                    new Point(x + 2, y + 12),
                    new Point(x + 3, y + 14)
                );
                path.AddBezier(
                    new Point(x + 3, y + 14),
                    new Point(x + 4, y + 12),
                    new Point(x + 4, y + 2),
                    new Point(x + 6, y)
                );
                path.CloseFigure();

                using (var pepperBrush = new LinearGradientBrush(
                    chiliBody,
                    Color.Red,
                    Color.DarkRed,
                    LinearGradientMode.Vertical))
                {
                    g.FillPath(pepperBrush, path);
                }

                using (var border = new Pen(Color.Maroon, 1))
                {
                    g.DrawPath(border, path);
                }
            }

            // Cuống quả ớt
            using (var stemBrush = new SolidBrush(Color.FromArgb(34, 139, 34))) // ForestGreen
            {
                g.FillRectangle(stemBrush, x + 2, y - 4, 2, 5);
            }
        }

        private void DrawLeaf(Graphics g, int x, int y)
        {
            Point[] leaf = new Point[]
            {
                new Point(x, y),
                new Point(x - 3, y - 6),
                new Point(x, y - 10),
                new Point(x + 3, y - 6)
            };

            using (var brush = new SolidBrush(Color.FromArgb(60, 179, 113))) // MediumSeaGreen
            using (var pen = new Pen(Color.DarkGreen))
            {
                g.FillPolygon(brush, leaf);
                g.DrawPolygon(pen, leaf);
            }
        }
    }
}
