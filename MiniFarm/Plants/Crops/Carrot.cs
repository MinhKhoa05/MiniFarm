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
            // Cải thiện chất lượng vẽ
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            int centerX = x + size / 2;
            int centerY = y + size / 2;
            Rectangle bounds = new Rectangle(x, y, size, size);

            // 1. Vẽ bóng mờ tự nhiên hơn
            DrawShadow(g, bounds);

            // 2. Vẽ củ cà rốt với hình dạng thực tế hơn
            DrawCarrotRoot(g, centerX, centerY, size);

            // 3. Vẽ các vân ngang trên củ cà rốt
            DrawCarrotTexture(g, centerX, centerY, size);

            // 4. Vẽ lá cà rốt với nhiều chi tiết
            DrawCarrotLeaves(g, centerX, centerY, size);

            // 5. Thêm highlight và bóng để tạo độ sâu
            DrawHighlights(g, centerX, centerY, size);
        }

        private void DrawShadow(Graphics g, Rectangle bounds)
        {
            using (var shadowBrush = new LinearGradientBrush(
                new Point(bounds.X, bounds.Y + bounds.Height - 8),
                new Point(bounds.X, bounds.Y + bounds.Height),
                Color.FromArgb(60, 0, 0, 0),
                Color.FromArgb(10, 0, 0, 0)))
            {
                int shadowHeight = 8;
                g.FillEllipse(shadowBrush, bounds.X + 4, bounds.Y + bounds.Height - 6, bounds.Width - 8, shadowHeight);
            }
        }

        private void DrawCarrotRoot(Graphics g, int centerX, int centerY, int size)
        {
            using (var carrotPath = new GraphicsPath())
            {
                // Tạo hình củ cà rốt với đỉnh nhọn và thân hình nón
                Point[] carrotPoints = new Point[]
                {
                    new Point(centerX, centerY + size/3),           // Đỉnh nhọn
                    new Point(centerX - size/6, centerY + size/6),  // Bên trái giữa
                    new Point(centerX - size/4, centerY - size/8),  // Bên trái trên
                    new Point(centerX - size/5, centerY - size/4),  // Vai trái
                    new Point(centerX + size/5, centerY - size/4),  // Vai phải
                    new Point(centerX + size/4, centerY - size/8),  // Bên phải trên
                    new Point(centerX + size/6, centerY + size/6),  // Bên phải giữa
                };

                carrotPath.AddPolygon(carrotPoints);
                carrotPath.CloseFigure();

                // Gradient màu cam tự nhiên
                using (var gradient = new PathGradientBrush(carrotPath))
                {
                    gradient.CenterColor = Color.FromArgb(255, 255, 165, 0);  // Cam nhạt ở giữa
                    gradient.SurroundColors = new[] {
                        Color.FromArgb(255, 255, 140, 0),   // Cam đậm ở viền
                        Color.FromArgb(255, 255, 140, 0),
                        Color.FromArgb(255, 255, 140, 0),
                        Color.FromArgb(255, 255, 140, 0),
                        Color.FromArgb(255, 255, 140, 0),
                        Color.FromArgb(255, 255, 140, 0),
                        Color.FromArgb(255, 255, 140, 0)
                    };
                    gradient.FocusScales = new PointF(0.3f, 0.3f);
                    g.FillPath(gradient, carrotPath);
                }

                // Viền củ cà rốt
                using (var outlinePen = new Pen(Color.FromArgb(180, 255, 120, 0), 1.5f))
                {
                    g.DrawPath(outlinePen, carrotPath);
                }
            }
        }

        private void DrawCarrotTexture(Graphics g, int centerX, int centerY, int size)
        {
            // Vẽ các vân ngang đặc trưng của cà rốt
            using (var texturePen = new Pen(Color.FromArgb(80, 255, 100, 0), 1f))
            {
                for (int i = 0; i < 4; i++)
                {
                    int yPos = centerY - size / 4 + (i * size / 8);
                    int width = size / 4 - (i * size / 20);
                    g.DrawArc(texturePen, centerX - width / 2, yPos - 2, width, 4, 0, 180);
                }
            }
        }

        private void DrawCarrotLeaves(Graphics g, int centerX, int centerY, int size)
        {
            // Vẽ thân lá chính
            using (var stemBrush = new SolidBrush(Color.FromArgb(255, 50, 150, 50)))
            {
                Rectangle stemRect = new Rectangle(centerX - 2, centerY - size / 4, 4, size / 8);
                g.FillRectangle(stemBrush, stemRect);
            }

            // Vẽ nhiều nhánh lá với các kích thước khác nhau
            DrawLeafBranch(g, centerX, centerY - size / 4, -15, size / 2, Color.FromArgb(255, 34, 139, 34));
            DrawLeafBranch(g, centerX, centerY - size / 4, -5, size / 2.2f, Color.FromArgb(255, 50, 150, 50));
            DrawLeafBranch(g, centerX, centerY - size / 4, 5, size / 2.2f, Color.FromArgb(255, 50, 150, 50));
            DrawLeafBranch(g, centerX, centerY - size / 4, 15, size / 2, Color.FromArgb(255, 34, 139, 34));

            // Thêm lá nhỏ ở giữa
            DrawLeafBranch(g, centerX, centerY - size / 4, 0, size / 1.8f, Color.FromArgb(255, 60, 160, 60));
        }

        private void DrawLeafBranch(Graphics g, int startX, int startY, int angle, float length, Color leafColor)
        {
            using (var leafPath = new GraphicsPath())
            {
                // Tính toán điểm cuối của nhánh lá
                double radians = angle * Math.PI / 180.0;
                int endX = startX + (int)(Math.Sin(radians) * length);
                int endY = startY - (int)(Math.Cos(radians) * length);

                // Vẽ thân lá
                using (var leafPen = new Pen(leafColor, 2.5f))
                {
                    leafPen.StartCap = LineCap.Round;
                    leafPen.EndCap = LineCap.Round;
                    g.DrawLine(leafPen, startX, startY, endX, endY);
                }

                // Vẽ các lá nhỏ ở hai bên thân
                for (int i = 1; i <= 3; i++)
                {
                    float ratio = i / 4.0f;
                    int leafX = startX + (int)((endX - startX) * ratio);
                    int leafY = startY + (int)((endY - startY) * ratio);

                    // Lá bên trái
                    int leftLeafX = leafX + (int)(Math.Cos(radians) * 8);
                    int leftLeafY = leafY + (int)(Math.Sin(radians) * 8);

                    // Lá bên phải
                    int rightLeafX = leafX - (int)(Math.Cos(radians) * 8);
                    int rightLeafY = leafY - (int)(Math.Sin(radians) * 8);

                    using (var smallLeafPen = new Pen(Color.FromArgb(200, leafColor.R, leafColor.G, leafColor.B), 1.5f))
                    {
                        smallLeafPen.StartCap = LineCap.Round;
                        smallLeafPen.EndCap = LineCap.Round;
                        g.DrawLine(smallLeafPen, leafX, leafY, leftLeafX, leftLeafY);
                        g.DrawLine(smallLeafPen, leafX, leafY, rightLeafX, rightLeafY);
                    }
                }
            }
        }

        private void DrawHighlights(Graphics g, int centerX, int centerY, int size)
        {
            // Highlight chính trên củ cà rốt
            using (GraphicsPath path = new GraphicsPath())
            {
                Rectangle ellipseBounds = new Rectangle(centerX - size / 4, centerY - size / 6, size / 4, size / 8);
                path.AddEllipse(ellipseBounds);

                using (PathGradientBrush pgb = new PathGradientBrush(path))
                {
                    pgb.CenterColor = Color.FromArgb(120, 255, 255, 255);
                    pgb.SurroundColors = new[] { Color.FromArgb(0, 255, 255, 255) };
                    pgb.CenterPoint = new PointF(centerX - size / 6, centerY - size / 8);
                    g.FillEllipse(pgb, ellipseBounds);
                }
            }

            // Highlight nhỏ trên lá
            using (SolidBrush leafHighlight = new SolidBrush(Color.FromArgb(60, 255, 255, 255)))
            {
                g.FillEllipse(leafHighlight, centerX - 3, centerY - size / 3, 6, 3);
            }
        }
    }
}