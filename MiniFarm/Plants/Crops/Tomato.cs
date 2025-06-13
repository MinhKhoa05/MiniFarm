using System.Drawing;
using System.Drawing.Drawing2D;
using MiniFarm.Plants.Base;

namespace MiniFarm.Plants.Crops
{
    public class Tomato : PlantBase
    {
        public override string PlantName { get; set; } = "Cà chua";

        public override void Render(Graphics g, int x, int y, int size)
        {
            int centerX = x + size / 2;
            int centerY = y + size / 2;

            // Bóng dưới quả cà
            using (var shadowBrush = new SolidBrush(Color.FromArgb(50, 0, 0, 0)))
            {
                g.FillEllipse(shadowBrush, new Rectangle(x + 2, y + 2, size, size));
            }

            // Gradient đỏ từ trung tâm ra ngoài (cà chua)
            using (var path = new GraphicsPath())
            {
                path.AddEllipse(new Rectangle(x, y, size, size));
                using (var pgb = new PathGradientBrush(path))
                {
                    pgb.CenterColor = Color.FromArgb(255, 255, 99, 71);       // Tomato
                    pgb.SurroundColors = new[] { Color.FromArgb(255, 178, 34, 34) }; // Firebrick
                    g.FillEllipse(pgb, x, y, size, size);
                }
            }

            // Highlight (vệt sáng nhỏ màu trắng mờ)
            int highlightSize = size / 3;
            using (var highlightBrush = new SolidBrush(Color.FromArgb(100, 255, 255, 255)))
            {
                g.FillEllipse(highlightBrush, x + size / 4, y + size / 4, highlightSize, highlightSize);
            }

            // Cuống chính (hình chữ nhật màu xanh sẫm)
            int stemY = y - 2;
            using (var stemBrush = new SolidBrush(Color.FromArgb(34, 139, 34))) // ForestGreen
            {
                g.FillRectangle(stemBrush, new Rectangle(centerX - 2, stemY - 6, 4, 8));
            }

            // Lá nhỏ quanh cuống
            Color leafColor = Color.FromArgb(50, 205, 50); // LimeGreen
            Point[][] leaves = {
                new[] { new Point(centerX - 4, stemY - 2), new Point(centerX - 6, stemY - 4), new Point(centerX - 2, stemY - 1) },
                new[] { new Point(centerX + 4, stemY - 2), new Point(centerX + 6, stemY - 4), new Point(centerX + 2, stemY - 1) },
                new[] { new Point(centerX - 1, stemY - 3), new Point(centerX - 2, stemY - 6), new Point(centerX + 1, stemY - 4) },
                new[] { new Point(centerX + 1, stemY - 3), new Point(centerX + 2, stemY - 6), new Point(centerX - 1, stemY - 4) }
            };

            using (var leafBrush = new SolidBrush(leafColor))
            {
                foreach (var leaf in leaves)
                    g.FillPolygon(leafBrush, leaf);
            }

            // Viền quả cà chua (màu nâu nhẹ, trong suốt)
            using (var outlinePen = new Pen(Color.FromArgb(100, 139, 69, 19), 1))
            {
                g.DrawEllipse(outlinePen, x, y, size, size);
            }
        }
    }
}
