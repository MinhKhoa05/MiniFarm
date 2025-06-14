using System;
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
            // Cài đặt chất lượng vẽ cao
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.CompositingQuality = CompositingQuality.HighQuality;

            // Vẽ trái ớt 3D mượt mà
            Draw3DChili(g, x, y, size);
        }

        private void Draw3DChili(Graphics g, int x, int y, int size)
        {
            int centerX = x + size / 2;
            int centerY = y + size / 2;

            // Kích thước ớt
            int chiliWidth = size * 2 / 3;
            int chiliHeight = size * 4 / 5;

            // Vẽ bóng đổ
            DrawShadow(g, centerX + 3, centerY + 3, chiliWidth, chiliHeight);

            // Vẽ thân ớt
            DrawChiliBody(g, centerX, centerY, chiliWidth, chiliHeight);

            // Vẽ cuống
            DrawChiliStem(g, centerX, centerY - chiliHeight / 2);
        }

        private void DrawShadow(Graphics g, int centerX, int centerY, int width, int height)
        {
            using (GraphicsPath shadowPath = new GraphicsPath())
            {
                // Tạo hình ớt cho bóng
                CreateChiliShape(shadowPath, centerX, centerY, width, height);

                using (var shadowBrush = new PathGradientBrush(shadowPath))
                {
                    shadowBrush.CenterColor = Color.FromArgb(40, 0, 0, 0);
                    shadowBrush.SurroundColors = new Color[] { Color.FromArgb(0, 0, 0, 0) };
                    g.FillPath(shadowBrush, shadowPath);
                }
            }
        }

        private void DrawChiliBody(Graphics g, int centerX, int centerY, int width, int height)
        {
            using (GraphicsPath chiliPath = new GraphicsPath())
            {
                CreateChiliShape(chiliPath, centerX, centerY, width, height);

                // Gradient chính cho thân ớt
                Rectangle bounds = Rectangle.Round(chiliPath.GetBounds());
                using (var mainBrush = new LinearGradientBrush(
                    new Point(bounds.Left, bounds.Top),
                    new Point(bounds.Right, bounds.Bottom),
                    Color.FromArgb(255, 255, 100, 100), // Đỏ sáng
                    Color.FromArgb(255, 180, 0, 0)))    // Đỏ đậm
                {
                    g.FillPath(mainBrush, chiliPath);
                }

                // Highlight chính
                using (GraphicsPath highlightPath = new GraphicsPath())
                {
                    CreateChiliShape(highlightPath, centerX - width / 6, centerY - height / 8, width * 2 / 3, height * 3 / 4);

                    using (var highlightBrush = new LinearGradientBrush(
                        new Point(centerX - width / 3, centerY - height / 3),
                        new Point(centerX, centerY),
                        Color.FromArgb(120, 255, 255, 255),
                        Color.FromArgb(0, 255, 255, 255)))
                    {
                        g.FillPath(highlightBrush, highlightPath);
                    }
                }

                // Viền mỏng
                using (var outlinePen = new Pen(Color.FromArgb(150, 0, 0), 1))
                {
                    g.DrawPath(outlinePen, chiliPath);
                }
            }
        }

        private void CreateChiliShape(GraphicsPath path, int centerX, int centerY, int width, int height)
        {
            // Tạo hình ớt cong mượt mà bằng Bezier curves
            Point[] chiliPoints = new Point[]
            {
                // Phần trên (gần cuống)
                new Point(centerX, centerY - height/2),
                new Point(centerX - width/2, centerY - height/3),
                new Point(centerX - width/2, centerY - height/6),
                
                // Phần giữa (phần to nhất)
                new Point(centerX - width/2, centerY),
                new Point(centerX - width/3, centerY + height/4),
                
                // Phần dưới (cong về phải và nhọn dần)
                new Point(centerX - width/6, centerY + height/3),
                new Point(centerX + width/6, centerY + height/2),
                new Point(centerX + width/4, centerY + height/2),
                
                // Đầu nhọn
                new Point(centerX + width/3, centerY + height/2 - 5),
                
                // Bên phải trở về
                new Point(centerX + width/4, centerY + height/3),
                new Point(centerX + width/6, centerY + height/6),
                new Point(centerX + width/3, centerY - height/6),
                new Point(centerX + width/4, centerY - height/3),
                new Point(centerX, centerY - height/2)
            };

            // Tạo đường cong mượt
            path.AddCurve(chiliPoints, 0.3f);
            path.CloseFigure();
        }

        private void DrawChiliStem(Graphics g, int centerX, int topY)
        {
            // Cuống chính
            using (GraphicsPath stemPath = new GraphicsPath())
            {
                Rectangle stemRect = new Rectangle(centerX - 4, topY - 12, 8, 15);
                stemPath.AddEllipse(stemRect);

                using (var stemBrush = new LinearGradientBrush(
                    stemRect,
                    Color.FromArgb(255, 150, 255, 100), // Xanh sáng
                    Color.FromArgb(255, 50, 150, 0),    // Xanh đậm
                    LinearGradientMode.Vertical))
                {
                    g.FillPath(stemBrush, stemPath);
                }

                // Highlight cuống
                using (var stemHighlight = new SolidBrush(Color.FromArgb(80, 255, 255, 255)))
                {
                    g.FillEllipse(stemHighlight, centerX - 2, topY - 10, 4, 6);
                }

                // Viền cuống
                using (var stemPen = new Pen(Color.FromArgb(255, 50, 120, 0), 1))
                {
                    g.DrawPath(stemPen, stemPath);
                }
            }

            // Lá nhỏ ở cuống
            DrawStemLeaf(g, centerX - 6, topY - 8, -20);
            DrawStemLeaf(g, centerX + 6, topY - 8, 20);
        }

        private void DrawStemLeaf(Graphics g, int x, int y, int angle)
        {
            using (GraphicsPath leafPath = new GraphicsPath())
            {
                Point[] leafPoints = new Point[]
                {
                    new Point(x, y - 8),
                    new Point(x - 3, y - 4),
                    new Point(x - 2, y),
                    new Point(x + 2, y),
                    new Point(x + 3, y - 4)
                };

                leafPath.AddCurve(leafPoints, 0.4f);
                leafPath.CloseFigure();

                // Xoay lá
                using (Matrix matrix = new Matrix())
                {
                    matrix.RotateAt(angle, new PointF(x, y - 4));
                    leafPath.Transform(matrix);
                }

                using (var leafBrush = new LinearGradientBrush(
                    new Point(x - 4, y - 8),
                    new Point(x + 4, y),
                    Color.FromArgb(255, 100, 200, 50),
                    Color.FromArgb(255, 50, 150, 0)))
                {
                    g.FillPath(leafBrush, leafPath);
                }

                using (var leafPen = new Pen(Color.FromArgb(255, 50, 120, 0), 1))
                {
                    g.DrawPath(leafPen, leafPath);
                }
            }
        }
    }
}