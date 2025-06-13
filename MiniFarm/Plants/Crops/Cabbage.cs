using System.Drawing;
using System.Drawing.Drawing2D;
using MiniFarm.Plants.Base;

namespace MiniFarm.Plants.Crops
{
    public class Cabbage : PlantBase
    {
        public override string PlantName { get; set; } = "Bắp cải";

        public override void Render(Graphics g, int x, int y, int size)
        {
            // 1. Shadow (ellipse đổ bóng)
            using (var shadowBrush = new SolidBrush(Color.FromArgb(50, 0, 0, 0)))
            {
                int shadowHeight = 6;
                int shadowOffsetY = 2;
                g.FillEllipse(shadowBrush, x + 2, y + size - shadowOffsetY, size - 4, shadowHeight);
            }

            // 2. Gradient circle (vòng tròn nền lá bắp cải)
            using (var path = new GraphicsPath())
            {
                var bounds = new Rectangle(x, y, size, size);
                path.AddEllipse(bounds);
                using (var gradientBrush = new PathGradientBrush(path))
                {
                    gradientBrush.CenterColor = Color.FromArgb(144, 238, 144); // màu sáng giữa
                    gradientBrush.SurroundColors = new[] { Color.FromArgb(34, 139, 34) }; // màu đậm viền
                    g.FillPath(gradientBrush, path);
                }
            }

            // 3. Inner spiral (vòng cung đồng tâm)
            using (var pen = new Pen(Color.FromArgb(100, 0, 100, 0), 2))
            {
                int cx = x + size / 2;
                int cy = y + size / 2;
                int count = 4;
                int maxRadius = size / 2;

                for (int i = 0; i < count; i++)
                {
                    int radius = maxRadius - i * 6;
                    if (radius <= 0) break;

                    g.DrawArc(pen, cx - radius, cy - radius, radius * 2, radius * 2, i * 60, 180);
                }
            }

            // 4. Highlight (ánh sáng nhẹ)
            float alpha = 0.4f;
            int alpha255 = (int)(alpha * 255);
            using (var highlightBrush = new SolidBrush(Color.FromArgb(alpha255, 255, 255, 255)))
            {
                int hSize = size / 4;
                g.FillEllipse(highlightBrush, x + size / 3, y + size / 3, hSize, hSize);
            }

            // 5. Outer border
            using (var outlinePen = new Pen(Color.FromArgb(120, 0, 100, 0), 1))
            {
                g.DrawEllipse(outlinePen, new Rectangle(x, y, size, size));
            }
        }
    }
}