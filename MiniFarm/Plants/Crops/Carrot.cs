using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using MiniFarm.Plants.Base;

namespace MiniFarm.Plants.Crops
{
    public class Carrot : PlantBase
    {
        public override string PlantName { get; set; } = "Cà rốt";

        public override void Render(Graphics g, int x, int y, int size)
        {
            int centerX = x + size / 2;
            int centerY = y + size / 2;
            Rectangle bounds = new Rectangle(x, y, size, size);

            // 1. Vẽ bóng
            using (var shadowBrush = new SolidBrush(Color.FromArgb(40, 0, 0, 0)))
            {
                int shadowHeight = 6;
                int offsetY = 2;
                g.FillEllipse(shadowBrush, bounds.X + 2, bounds.Y + bounds.Height - offsetY, bounds.Width - 4, shadowHeight);
            }

            // 2. Vẽ củ cà rốt (Bezier + Ellipse)
            using (var carrotPath = new GraphicsPath())
            {
                carrotPath.AddBezier(
                    centerX - 5, centerY,
                    centerX - 8, centerY + 10,
                    centerX + 8, centerY + 10,
                    centerX + 5, centerY
                );
                carrotPath.AddEllipse(centerX - 5, centerY - 6, 10, 8);

                using (var gradient = new PathGradientBrush(carrotPath))
                {
                    gradient.CenterColor = Color.Orange;
                    gradient.SurroundColors = new[] { Color.DarkOrange };
                    g.FillPath(gradient, carrotPath);
                }
            }

            // 3. Highlight (ánh sáng nhỏ)
            float alpha = 0.4f;
            int alpha255 = (int)(alpha * 255);
            if (alpha255 >= 0 && alpha255 <= 255)
            {
                using (var highlightBrush = new SolidBrush(Color.FromArgb(alpha255, 255, 255, 255)))
                {
                    int hSize = size / 4;
                    g.FillEllipse(highlightBrush, x + size / 3, y + size / 3, hSize, hSize);
                }
            }

            // 4. Vẽ lá cà rốt (Bezier nhiều nhánh)
            using (var leafPen = new Pen(Color.FromArgb(255, 34, 139, 34), 2))
            {
                for (int i = -2; i <= 2; i++)
                {
                    Point start = new Point(centerX, centerY - 5);
                    Point control1 = new Point(centerX + i * 2, centerY - 10 - Math.Abs(i) * 2);
                    Point control2 = new Point(centerX + i * 4, centerY - 14);
                    Point end = new Point(centerX + i * 5, centerY - 16);

                    using (var path = new GraphicsPath())
                    {
                        path.AddBezier(start, control1, control2, end);
                        g.DrawPath(leafPen, path);
                    }
                }
            }

            // 5. Viền củ cà rốt
            using (var outlinePen = new Pen(Color.FromArgb(120, 255, 140, 0)))
            {
                Rectangle rect = new Rectangle(centerX - 6, centerY - 6, 12, 14);
                g.DrawEllipse(outlinePen, rect);
            }
        }
    }
}