using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using MiniFarm.Plants.Base;

namespace MiniFarm.Plants.Crops
{
    public class Corn : PlantBase
    {
        public override string PlantName { get; set; } = "Bắp";
        private static readonly Random random = new Random();

        public override void Render(Graphics g, int x, int y, int size)
        {
            // Cài đặt chất lượng vẽ cao
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            int centerX = x + size / 2;
            int baseY = y + size - 4;

            // Bóng đổ gradient tự nhiên
            DrawShadow(g, x, baseY, size);

            // Vẽ thân cây bắp cao và thực tế
            DrawCornStalks(g, centerX, baseY, size);

            // Vẽ lá bắp dài và rộng
            DrawCornLeaves(g, centerX, baseY, size);

            // Vẽ bắp ngô với vỏ lá bao quanh
            DrawCornCobs(g, centerX, baseY, size);

            // Vẽ râu ngô (corn silk)
            DrawCornSilk(g, centerX, baseY, size);
        }

        private void DrawShadow(Graphics g, int x, int baseY, int size)
        {
            using (var shadowBrush = new LinearGradientBrush(
                new Point(x, baseY),
                new Point(x, baseY + 8),
                Color.FromArgb(50, 0, 0, 0),
                Color.FromArgb(10, 0, 0, 0)))
            {
                g.FillEllipse(shadowBrush, x + 2, baseY - 2, size - 4, 8);
            }
        }

        private void DrawCornStalks(Graphics g, int centerX, int baseY, int size)
        {
            // Thân chính cao và dày
            using (var stalkBrush = new LinearGradientBrush(
                new Point(centerX - 4, baseY),
                new Point(centerX + 4, baseY),
                Color.FromArgb(255, 107, 142, 35),  // OliveDrab
                Color.FromArgb(255, 85, 107, 47)))  // DarkOliveGreen
            {
                Rectangle mainStalk = new Rectangle(centerX - 4, baseY - size + 8, 8, size - 8);
                g.FillRectangle(stalkBrush, mainStalk);
            }

            // Các đốt trên thân
            using (var nodePen = new Pen(Color.FromArgb(120, 85, 107, 47), 1))
            {
                for (int i = 1; i < 6; i++)
                {
                    int nodeY = baseY - (size * i / 6);
                    g.DrawLine(nodePen, centerX - 4, nodeY, centerX + 4, nodeY);
                }
            }

            // Viền thân
            using (var stalkPen = new Pen(Color.FromArgb(255, 85, 107, 47), 1.5f))
            {
                g.DrawRectangle(stalkPen, centerX - 4, baseY - size + 8, 8, size - 8);
            }
        }

        private void DrawCornLeaves(Graphics g, int centerX, int baseY, int size)
        {
            // Vẽ nhiều lá bắp dài và rộng
            Color[] leafColors = {
                Color.FromArgb(255, 124, 252, 0),   // LawnGreen
                Color.FromArgb(255, 50, 205, 50),   // LimeGreen
                Color.FromArgb(255, 34, 139, 34),   // ForestGreen
                Color.FromArgb(255, 60, 179, 113)   // MediumSeaGreen
            };

            for (int i = 0; i < 8; i++)
            {
                int leafLevel = baseY - 10 - (i * size / 10);
                int leafWidth = 12 - (i / 2);
                int leafLength = 18 - (i / 2);
                bool isLeft = i % 2 == 0;

                DrawCornLeaf(g, centerX, leafLevel, leafWidth, leafLength, isLeft,
                    leafColors[i % leafColors.Length], i * 15);
            }
        }

        private void DrawCornLeaf(Graphics g, int centerX, int leafY, int width, int length,
            bool isLeft, Color leafColor, int angle)
        {
            using (GraphicsPath leafPath = new GraphicsPath())
            {
                int direction = isLeft ? -1 : 1;
                int startX = centerX + (direction * 2);

                // Tạo hình lá bắp dài và nhọn
                Point[] leafPoints = new Point[]
                {
                    new Point(startX, leafY),                                    // Gốc lá
                    new Point(startX + direction * width/2, leafY - length/4),  // Mép dưới
                    new Point(startX + direction * width, leafY - length/2),    // Mép giữa
                    new Point(startX + direction * width/2, leafY - length*3/4), // Mép trên
                    new Point(startX + direction * width/4, leafY - length),     // Đỉnh lá
                    new Point(startX, leafY - length*3/4),                       // Mép trong trên
                    new Point(startX + direction * width/4, leafY - length/2),   // Mép trong giữa
                    new Point(startX, leafY - length/4)                          // Mép trong dưới
                };

                leafPath.AddPolygon(leafPoints);

                // Xoay lá một chút để tự nhiên
                using (Matrix matrix = new Matrix())
                {
                    matrix.RotateAt(angle, new PointF(startX, leafY));
                    leafPath.Transform(matrix);
                }

                // Tô màu lá với gradient
                Rectangle leafBounds = Rectangle.Round(leafPath.GetBounds());
                if (leafBounds.Width > 0 && leafBounds.Height > 0)
                {
                    using (var leafBrush = new LinearGradientBrush(
                        leafBounds,
                        Color.FromArgb(200, leafColor.R, leafColor.G, leafColor.B),
                        leafColor,
                        LinearGradientMode.Vertical))
                    {
                        g.FillPath(leafBrush, leafPath);
                    }
                }

                // Viền lá
                using (var leafPen = new Pen(Color.FromArgb(255, 34, 139, 34), 1))
                {
                    g.DrawPath(leafPen, leafPath);
                }

                // Gân lá chính
                using (var veinPen = new Pen(Color.FromArgb(100, 34, 139, 34), 1))
                {
                    g.DrawLine(veinPen, startX, leafY,
                        startX + direction * width / 4, leafY - length);
                }
            }
        }

        private void DrawCornCobs(Graphics g, int centerX, int baseY, int size)
        {
            // Vẽ 2-3 bắp ngô ở các vị trí khác nhau
            DrawDetailedCornCob(g, centerX - 8, baseY - size / 2 + 5, 8, 16);
            DrawDetailedCornCob(g, centerX + 6, baseY - size / 2 + 8, 7, 14);
            DrawDetailedCornCob(g, centerX - 2, baseY - size / 3 + 2, 6, 12);
        }

        private void DrawDetailedCornCob(Graphics g, int x, int y, int width, int height)
        {
            // Vẽ vỏ lá bao quanh bắp
            using (var huskBrush = new LinearGradientBrush(
                new Point(x - 2, y),
                new Point(x + width + 2, y),
                Color.FromArgb(255, 240, 230, 140),  // Khaki
                Color.FromArgb(255, 189, 183, 107))) // DarkKhaki
            {
                // Vỏ lá bên trái
                Point[] leftHusk = new Point[]
                {
                    new Point(x - 2, y + height),
                    new Point(x - 4, y + height/2),
                    new Point(x - 2, y - 2),
                    new Point(x + 1, y + height/4)
                };
                g.FillPolygon(huskBrush, leftHusk);

                // Vỏ lá bên phải
                Point[] rightHusk = new Point[]
                {
                    new Point(x + width + 2, y + height),
                    new Point(x + width + 4, y + height/2),
                    new Point(x + width + 2, y - 2),
                    new Point(x + width - 1, y + height/4)
                };
                g.FillPolygon(huskBrush, rightHusk);
            }

            // Vẽ thân bắp ngô
            using (var cornBrush = new LinearGradientBrush(
                new Point(x, y),
                new Point(x, y + height),
                Color.FromArgb(255, 255, 255, 0),    // Yellow
                Color.FromArgb(255, 255, 215, 0)))   // Gold
            {
                Rectangle cornRect = new Rectangle(x, y, width, height);
                g.FillRectangle(cornBrush, cornRect);
            }

            // Vẽ các hàng hạt ngô
            using (var kernelBrush = new SolidBrush(Color.FromArgb(255, 255, 215, 0)))
            {
                for (int row = 0; row < height / 2; row++)
                {
                    for (int col = 0; col < width / 2; col++)
                    {
                        int kernelX = x + col * 2 + (row % 2);
                        int kernelY = y + row * 2;
                        g.FillEllipse(kernelBrush, kernelX, kernelY, 1, 1);
                    }
                }
            }

            // Viền bắp
            using (var cornPen = new Pen(Color.FromArgb(255, 218, 165, 32), 1))
            {
                g.DrawRectangle(cornPen, x, y, width, height);
            }
        }

        private void DrawCornSilk(Graphics g, int centerX, int baseY, int size)
        {
            // Vẽ râu ngô màu nâu vàng
            using (var silkPen = new Pen(Color.FromArgb(255, 210, 180, 140), 1)) // Tan
            {
                for (int i = 0; i < 15; i++)
                {
                    int silkX = centerX - 8 + random.Next(16);
                    int silkY = baseY - size / 2 + random.Next(8);
                    int silkLength = 6 + random.Next(4);

                    g.DrawLine(silkPen, silkX, silkY,
                        silkX + random.Next(-3, 4), silkY - silkLength);
                }
            }
        }
    }
}