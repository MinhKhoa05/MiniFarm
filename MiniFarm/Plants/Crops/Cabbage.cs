using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using MiniFarm.Plants.Base;

namespace MiniFarm.Plants.Crops
{
    public class Cabbage : PlantBase
    {
        public override string PlantName { get; set; } = "Bắp cải";
        private readonly Random random = new Random();

        public override void Render(Graphics g, int x, int y, int size)
        {
            // Thiết lập chất lượng cao
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            // Tính toán kích thước các phần
            int cabbageSize = (int)(size * 0.8f);
            int centerX = x + size / 2;
            int centerY = y + size / 2;

            // 1. Vẽ bóng đổ
            DrawShadow(g, x, y, size);

            // 2. Vẽ lá ngoài
            DrawOuterLeaves(g, centerX, centerY, cabbageSize);

            // 3. Vẽ thân bắp cải chính
            DrawMainCabbage(g, centerX, centerY, cabbageSize);

            // 4. Vẽ chi tiết lá
            DrawLeafDetails(g, centerX, centerY, cabbageSize);

            // 5. Vẽ highlight và bóng
            DrawLightingEffects(g, centerX, centerY, cabbageSize);

            // 6. Vẽ viền và hoàn thiện
            DrawBorderAndFinish(g, centerX, centerY, cabbageSize);
        }

        private void DrawShadow(Graphics g, int x, int y, int size)
        {
            // Bóng đổ ellipse tự nhiên
            using (var shadowBrush = new SolidBrush(Color.FromArgb(60, 0, 0, 0)))
            {
                int shadowWidth = (int)(size * 0.9f);
                int shadowHeight = (int)(size * 0.2f);
                int shadowX = x + (size - shadowWidth) / 2;
                int shadowY = y + size - shadowHeight - 2;

                g.FillEllipse(shadowBrush, shadowX, shadowY, shadowWidth, shadowHeight);
            }
        }

        private void DrawOuterLeaves(Graphics g, int centerX, int centerY, int cabbageSize)
        {
            // Vẽ các lá ngoài xung quanh
            int leafCount = 8;
            int outerRadius = cabbageSize / 2 + 8;

            for (int i = 0; i < leafCount; i++)
            {
                double angle = (i * 360.0 / leafCount) * Math.PI / 180.0;
                int leafX = centerX + (int)(Math.Cos(angle) * outerRadius * 0.7);
                int leafY = centerY + (int)(Math.Sin(angle) * outerRadius * 0.5);

                DrawSingleLeaf(g, leafX, leafY, cabbageSize / 4, angle,
                    Color.FromArgb(60, 150, 60), Color.FromArgb(40, 100, 40));
            }
        }

        private void DrawSingleLeaf(Graphics g, int x, int y, int size, double rotation, Color lightColor, Color darkColor)
        {
            // Tạo hình lá với gradient
            using (var path = new GraphicsPath())
            {
                // Tạo hình lá oval
                Rectangle leafRect = new Rectangle(x - size / 2, y - size / 2, size, (int)(size * 1.5));
                path.AddEllipse(leafRect);

                // Xoay lá theo góc
                Matrix matrix = new Matrix();
                matrix.RotateAt((float)(rotation * 180 / Math.PI), new PointF(x, y));
                path.Transform(matrix);

                // Vẽ gradient cho lá
                using (var brush = new PathGradientBrush(path))
                {
                    brush.CenterColor = lightColor;
                    brush.SurroundColors = new Color[] { darkColor };
                    g.FillPath(brush, path);
                }

                // Viền lá
                using (var pen = new Pen(darkColor, 1))
                {
                    g.DrawPath(pen, path);
                }
            }
        }

        private void DrawMainCabbage(Graphics g, int centerX, int centerY, int cabbageSize)
        {
            // Vẽ thân chính của bắp cải với nhiều lớp
            int mainSize = (int)(cabbageSize * 0.85f);

            // Lớp ngoài cùng
            DrawCabbageLayer(g, centerX, centerY, mainSize,
                Color.FromArgb(100, 180, 100), Color.FromArgb(60, 120, 60));

            // Lớp giữa
            int midSize = (int)(mainSize * 0.8f);
            DrawCabbageLayer(g, centerX, centerY, midSize,
                Color.FromArgb(120, 200, 120), Color.FromArgb(80, 140, 80));

            // Lớp trong
            int innerSize = (int)(mainSize * 0.6f);
            DrawCabbageLayer(g, centerX, centerY, innerSize,
                Color.FromArgb(140, 220, 140), Color.FromArgb(100, 160, 100));
        }

        private void DrawCabbageLayer(Graphics g, int centerX, int centerY, int size, Color lightColor, Color darkColor)
        {
            using (var path = new GraphicsPath())
            {
                // Tạo hình tròn hơi méo để trông tự nhiên
                Rectangle bounds = new Rectangle(centerX - size / 2, centerY - size / 2, size, size);
                path.AddEllipse(bounds);

                using (var brush = new PathGradientBrush(path))
                {
                    brush.CenterColor = lightColor;
                    brush.SurroundColors = new Color[] { darkColor };

                    // Điều chỉnh focus để tạo hiệu ứng 3D
                    brush.FocusScales = new PointF(0.3f, 0.3f);

                    g.FillPath(brush, path);
                }
            }
        }

        private void DrawLeafDetails(Graphics g, int centerX, int centerY, int cabbageSize)
        {
            // Vẽ các đường gân lá
            using (var pen = new Pen(Color.FromArgb(80, 50, 100, 50), 2))
            {
                int detailRadius = cabbageSize / 3;

                // Vẽ các đường gân từ tâm ra ngoài
                for (int i = 0; i < 6; i++)
                {
                    double angle = (i * 60) * Math.PI / 180.0;
                    int endX = centerX + (int)(Math.Cos(angle) * detailRadius);
                    int endY = centerY + (int)(Math.Sin(angle) * detailRadius);

                    // Vẽ đường gân cong
                    DrawCurvedVein(g, pen, centerX, centerY, endX, endY);
                }
            }

            // Vẽ các đốm và texture
            DrawTextureSpots(g, centerX, centerY, cabbageSize);
        }

        private void DrawCurvedVein(Graphics g, Pen pen, int startX, int startY, int endX, int endY)
        {
            // Tạo đường cong thay vì đường thẳng
            int controlX = (startX + endX) / 2 + random.Next(-5, 5);
            int controlY = (startY + endY) / 2 + random.Next(-5, 5);

            Point[] curvePoints = {
                new Point(startX, startY),
                new Point(controlX, controlY),
                new Point(endX, endY)
            };

            g.DrawCurve(pen, curvePoints, 0.5f);
        }

        private void DrawTextureSpots(Graphics g, int centerX, int centerY, int cabbageSize)
        {
            // Vẽ các đốm nhỏ để tạo texture
            Color[] spotColors = {
                Color.FromArgb(40, 80, 120, 80),
                Color.FromArgb(30, 60, 100, 60),
                Color.FromArgb(35, 100, 140, 100)
            };

            for (int i = 0; i < 12; i++)
            {
                int spotRadius = cabbageSize / 4;
                double angle = random.NextDouble() * 2 * Math.PI;
                double distance = random.NextDouble() * spotRadius;

                int spotX = centerX + (int)(Math.Cos(angle) * distance);
                int spotY = centerY + (int)(Math.Sin(angle) * distance);
                int spotSize = random.Next(2, 5);

                Color spotColor = spotColors[random.Next(spotColors.Length)];
                using (var brush = new SolidBrush(spotColor))
                {
                    g.FillEllipse(brush, spotX - spotSize / 2, spotY - spotSize / 2, spotSize, spotSize);
                }
            }
        }

        private void DrawLightingEffects(Graphics g, int centerX, int centerY, int cabbageSize)
        {
            // Highlight chính
            int highlightSize = cabbageSize / 3;
            int highlightX = centerX - cabbageSize / 6;
            int highlightY = centerY - cabbageSize / 6;

            using (var highlightBrush = GradientBrushHelper.CreateRadialBrush(
                new Point(highlightX, highlightY), highlightSize / 2,
                Color.FromArgb(60, 255, 255, 255), Color.FromArgb(0, 255, 255, 255)))
            {
                g.FillEllipse(highlightBrush, highlightX - highlightSize / 2, highlightY - highlightSize / 2,
                    highlightSize, highlightSize);
            }

            // Bóng tối ở phía dưới
            using (var shadowBrush = GradientBrushHelper.CreateRadialBrush(
                new Point(centerX + cabbageSize / 6, centerY + cabbageSize / 6), cabbageSize / 4,
                Color.FromArgb(30, 0, 0, 0), Color.FromArgb(0, 0, 0, 0)))
            {
                g.FillEllipse(shadowBrush, centerX, centerY, cabbageSize / 2, cabbageSize / 2);
            }
        }


        private void DrawBorderAndFinish(Graphics g, int centerX, int centerY, int cabbageSize)
        {
            // Viền ngoài
            using (var outlinePen = new Pen(Color.FromArgb(150, 40, 80, 40), 2))
            {
                g.DrawEllipse(outlinePen, centerX - cabbageSize / 2, centerY - cabbageSize / 2,
                    cabbageSize, cabbageSize);
            }

            // Viền trong mờ
            using (var innerPen = new Pen(Color.FromArgb(60, 100, 150, 100), 1))
            {
                int innerSize = (int)(cabbageSize * 0.8f);
                g.DrawEllipse(innerPen, centerX - innerSize / 2, centerY - innerSize / 2,
                    innerSize, innerSize);
            }
        }
    }

    public static class GradientBrushHelper
    {
        public static Brush CreateRadialBrush(Point center, int radius, Color centerColor, Color edgeColor)
        {
            var rect = new Rectangle(center.X - radius, center.Y - radius, radius * 2, radius * 2);
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(rect);

            var brush = new PathGradientBrush(path)
            {
                CenterColor = centerColor,
                SurroundColors = new[] { edgeColor }
            };

            return brush;
        }
    }
}