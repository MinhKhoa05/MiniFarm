using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MiniFarm.Tiles.Plants
{
    /// <summary>
    /// Lớp hỗ trợ các phương thức vẽ cho cây trồng, như bóng, lá, thân, v.v.
    /// </summary>
    public static class PlantDrawingHelper
    {
        /// <summary>
        /// Vẽ bóng hình elip phía dưới để tạo cảm giác đổ bóng cho cây.
        /// </summary>
        /// <param name="g">Đối tượng Graphics để vẽ.</param>
        /// <param name="bounds">Hình chữ nhật bao quanh đối tượng cần đổ bóng.</param>
        /// <param name="alpha">Độ trong suốt của bóng (từ 0 đến 255).</param>
        /// <param name="offsetY">Khoảng cách từ đáy của bounds đến vị trí bóng.</param>
        /// <param name="height">Chiều cao của bóng.</param>
        public static void DrawShadow(Graphics g, Rectangle bounds, int alpha = 40, int offsetY = 2, int height = 6)
        {
            using (var shadowBrush = new SolidBrush(Color.FromArgb(alpha, 0, 0, 0)))
            {
                g.FillEllipse(shadowBrush, bounds.X + 2, bounds.Y + bounds.Height - offsetY, bounds.Width - 4, height);
            }
        }

        /// <summary>
        /// Vẽ điểm sáng nhỏ để tạo hiệu ứng ánh sáng.
        /// </summary>
        /// <param name="g">Graphics để vẽ.</param>
        /// <param name="x">Vị trí X của ô.</param>
        /// <param name="y">Vị trí Y của ô.</param>
        /// <param name="size">Kích thước tổng thể của vùng cần vẽ highlight.</param>
        /// <param name="alpha">Độ trong suốt của highlight (giá trị từ 0.0 đến 1.0).</param>
        public static void DrawHighlight(Graphics g, int x, int y, int size, float alpha = 0.4f)
        {
            int alpha255 = (int)(alpha * 255); // Đảm bảo alpha nằm trong khoảng hợp lệ
            if (alpha255 < 0 || alpha255 > 255)
            {
                return;
            }

            using (var highlightBrush = new SolidBrush(Color.FromArgb(alpha255, 255, 255, 255)))
            {
                int hSize = size / 4;
                g.FillEllipse(highlightBrush, x + size / 3, y + size / 3, hSize, hSize);
            }
        }

        /// <summary>
        /// Vẽ một vòng tròn gradient từ màu tâm ra viền.
        /// </summary>
        public static void DrawGradientCircle(Graphics g, Rectangle bounds, Color centerColor, Color surroundColor)
        {
            using (var path = new GraphicsPath())
            {
                path.AddEllipse(bounds);
                using (var gradientBrush = new PathGradientBrush(path))
                {
                    gradientBrush.CenterColor = centerColor;
                    gradientBrush.SurroundColors = new[] { surroundColor };
                    g.FillPath(gradientBrush, path);
                }
            }
        }

        /// <summary>
        /// Vẽ một đoạn thân cây bằng đường cong Bezier.
        /// </summary>
        public static void DrawStem(Graphics g, Point start, Point control1, Point control2, Point end, Pen pen)
        {
            using (var path = new GraphicsPath())
            {
                path.AddBezier(start, control1, control2, end);
                g.DrawPath(pen, path);
            }
        }

        /// <summary>
        /// Vẽ chiếc lá bằng một đa giác được tô màu và có viền.
        /// </summary>
        public static void DrawLeaf(Graphics g, Point[] points, Color fillColor, Color borderColor)
        {
            using (var brush = new SolidBrush(fillColor))
            using (var pen = new Pen(borderColor))
            {
                g.FillPolygon(brush, points);
                g.DrawPolygon(pen, points);
            }
        }

        /// <summary>
        /// Vẽ viền hình elip.
        /// </summary>
        public static void DrawOutline(Graphics g, Rectangle rect, Pen pen)
        {
            g.DrawEllipse(pen, rect);
        }

        /// <summary>
        /// Vẽ nhiều vòng cung đồng tâm lặp lại với bán kính giảm dần.
        /// </summary>
        public static void DrawArcLoops(Graphics g, int centerX, int centerY, int maxRadius, int count, Pen pen)
        {
            for (int i = 0; i < count; i++)
            {
                int radius = Math.Max(maxRadius - i * 6, 1); // Tránh bán kính âm hoặc 0
                g.DrawArc(pen, centerX - radius, centerY - radius, radius * 2, radius * 2, i * 60, 180);
            }
        }

        /// <summary>
        /// Vẽ hình elip với màu nền và viền ngoài.
        /// </summary>
        public static void DrawFilledEllipseWithBorder(Graphics g, Rectangle rect, Color fillColor, Color borderColor)
        {
            using (var brush = new SolidBrush(fillColor))
            using (var pen = new Pen(borderColor))
            {
                g.FillEllipse(brush, rect);
                g.DrawEllipse(pen, rect);
            }
        }
    }
}
