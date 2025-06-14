using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using MiniFarm.Plants.Base;

namespace MiniFarm.Plants.Crops
{
    public class Potato : PlantBase
    {
        public override string PlantName { get; set; } = "Khoai tây";

        public override void Render(Graphics g, int x, int y, int size)
        {
            // Cài đặt chất lượng vẽ cao
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            int centerX = x + size / 2;
            int baseY = y + size - 8;

            // Bóng đổ tự nhiên
            DrawShadow(g, x, baseY, size);

            // Vẽ thân cây khoai tây
            DrawPotatoStem(g, centerX, baseY, size);

            // Vẽ lá khoai tây với nhiều tầng
            DrawPotatoLeaves(g, centerX, baseY, size);

            // Vẽ củ khoai tây dưới đất (một phần nhìn thấy)
            DrawPotatoTubers(g, centerX, baseY, size);

            // Vẽ hoa khoai tây
            DrawPotatoFlowers(g, centerX, baseY, size);
        }

        private void DrawShadow(Graphics g, int x, int baseY, int size)
        {
            using (var shadowBrush = new LinearGradientBrush(
                new Point(x, baseY),
                new Point(x, baseY + 8),
                Color.FromArgb(60, 0, 0, 0),
                Color.FromArgb(15, 0, 0, 0)))
            {
                g.FillEllipse(shadowBrush, x + 3, baseY - 2, size - 6, 8);
            }
        }

        private void DrawPotatoStem(Graphics g, int centerX, int baseY, int size)
        {
            // Thân chính
            using (var stemBrush = new LinearGradientBrush(
                new Point(centerX - 3, baseY),
                new Point(centerX + 3, baseY),
                Color.FromArgb(255, 85, 107, 47),    // DarkOliveGreen
                Color.FromArgb(255, 107, 142, 35)))  // OliveDrab
            {
                Rectangle stemRect = new Rectangle(centerX - 3, baseY - size / 2, 6, size / 2);
                g.FillRectangle(stemBrush, stemRect);
            }

            // Các nhánh nhỏ
            using (var branchPen = new Pen(Color.FromArgb(255, 85, 107, 47), 2))
            {
                for (int i = 0; i < 4; i++)
                {
                    int branchY = baseY - size / 3 - (i * size / 8);
                    int branchLength = 8 + (i * 2);
                    bool isLeft = i % 2 == 0;
                    int direction = isLeft ? -1 : 1;

                    g.DrawLine(branchPen, centerX, branchY,
                        centerX + direction * branchLength, branchY - 3);
                }
            }
        }

        private void DrawPotatoLeaves(Graphics g, int centerX, int baseY, int size)
        {
            // Vẽ lá kép đặc trưng của khoai tây
            for (int level = 0; level < 4; level++)
            {
                int leafY = baseY - size / 3 - (level * size / 8);
                bool isLeft = level % 2 == 0;

                DrawCompoundLeaf(g, centerX, leafY, size, isLeft, level);
            }
        }

        private void DrawCompoundLeaf(Graphics g, int centerX, int leafY, int size, bool isLeft, int level)
        {
            int direction = isLeft ? -1 : 1;
            int leafBaseX = centerX + direction * 8;

            // Thân lá chính
            using (var leafStemPen = new Pen(Color.FromArgb(255, 85, 107, 47), 1.5f))
            {
                g.DrawLine(leafStemPen, centerX, leafY, leafBaseX, leafY - 3);
            }

            // Vẽ 3-5 lá nhỏ trên mỗi thân
            Color[] leafShades = {
                Color.FromArgb(255, 34, 139, 34),   // ForestGreen
                Color.FromArgb(255, 50, 205, 50),   // LimeGreen
                Color.FromArgb(255, 60, 179, 113),  // MediumSeaGreen
                Color.FromArgb(255, 46, 139, 87)    // SeaGreen
            };

            for (int i = 0; i < 5; i++)
            {
                int leafletX = leafBaseX + direction * (i * 3);
                int leafletY = leafY - 3 - (i * 2);
                int leafletSize = 6 - i;

                DrawPotatoLeaflet(g, leafletX, leafletY, leafletSize,
                    leafShades[i % leafShades.Length], direction);
            }
        }

        private void DrawPotatoLeaflet(Graphics g, int x, int y, int size, Color leafColor, int direction)
        {
            using (GraphicsPath leafPath = new GraphicsPath())
            {
                // Tạo hình lá oval với đỉnh nhọn
                Point[] leafPoints = new Point[]
                {
                    new Point(x, y),                                    // Gốc lá
                    new Point(x + direction * size/2, y - size/4),     // Bên dưới
                    new Point(x + direction * size, y - size/2),       // Bên giữa
                    new Point(x + direction * size/2, y - size*3/4),   // Bên trên
                    new Point(x, y - size),                            // Đỉnh lá
                    new Point(x - direction * size/4, y - size*3/4),   // Bên trong trên
                    new Point(x - direction * size/4, y - size/4)      // Bên trong dưới
                };

                leafPath.AddPolygon(leafPoints);

                // Tô màu lá
                Rectangle leafBounds = Rectangle.Round(leafPath.GetBounds());
                if (leafBounds.Width > 0 && leafBounds.Height > 0)
                {
                    using (var leafBrush = new LinearGradientBrush(
                        leafBounds,
                        Color.FromArgb(180, leafColor.R, leafColor.G, leafColor.B),
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

                // Gân lá
                using (var veinPen = new Pen(Color.FromArgb(100, 34, 139, 34), 1))
                {
                    g.DrawLine(veinPen, x, y, x, y - size);
                }
            }
        }

        private void DrawPotatoTubers(Graphics g, int centerX, int baseY, int size)
        {
            // Vẽ một vài củ khoai tây nhô lên khỏi mặt đất
            DrawPotatoTuber(g, centerX - 12, baseY - 8, 10, 12, Color.FromArgb(255, 222, 184, 135));
            DrawPotatoTuber(g, centerX + 8, baseY - 6, 8, 10, Color.FromArgb(255, 205, 175, 125));
            DrawPotatoTuber(g, centerX - 2, baseY - 4, 6, 8, Color.FromArgb(255, 210, 180, 140));
        }

        private void DrawPotatoTuber(Graphics g, int x, int y, int width, int height, Color tuberColor)
        {
            // Hình oval cho củ khoai
            using (var tuberBrush = new LinearGradientBrush(
                new Point(x, y),
                new Point(x + width, y + height),
                tuberColor,
                Color.FromArgb(tuberColor.A,
                    Math.Max(0, tuberColor.R - 40),
                    Math.Max(0, tuberColor.G - 40),
                    Math.Max(0, tuberColor.B - 40))))
            {
                g.FillEllipse(tuberBrush, x, y, width, height);
            }

            // Viền củ
            using (var tuberPen = new Pen(Color.FromArgb(255, 160, 120, 80), 1))
            {
                g.DrawEllipse(tuberPen, x, y, width, height);
            }

            // Mắt khoai tây (những chấm nhỏ)
            using (var eyeBrush = new SolidBrush(Color.FromArgb(255, 139, 69, 19)))
            {
                g.FillEllipse(eyeBrush, x + width / 3, y + height / 4, 2, 1);
                g.FillEllipse(eyeBrush, x + width * 2 / 3, y + height / 2, 2, 1);
                g.FillEllipse(eyeBrush, x + width / 4, y + height * 3 / 4, 2, 1);
            }

            // Highlight trên củ
            using (var highlightBrush = new SolidBrush(Color.FromArgb(60, 255, 255, 255)))
            {
                g.FillEllipse(highlightBrush, x + width / 4, y + height / 6, width / 3, height / 4);
            }
        }

        private void DrawPotatoFlowers(Graphics g, int centerX, int baseY, int size)
        {
            // Vẽ hoa khoai tây màu trắng/tím nhạt
            DrawPotatoFlower(g, centerX - 6, baseY - size / 2 + 2);
            DrawPotatoFlower(g, centerX + 8, baseY - size / 2 + 5);
            DrawPotatoFlower(g, centerX + 2, baseY - size / 3 + 8);
        }

        private void DrawPotatoFlower(Graphics g, int x, int y)
        {
            // Hoa 5 cánh màu trắng với tâm vàng
            using (var petalBrush = new SolidBrush(Color.FromArgb(255, 248, 248, 255))) // GhostWhite
            {
                for (int i = 0; i < 5; i++)
                {
                    double angle = i * 72 * Math.PI / 180;
                    int petalX = x + (int)(Math.Cos(angle) * 4);
                    int petalY = y + (int)(Math.Sin(angle) * 4);

                    // Cánh hoa hình oval
                    g.FillEllipse(petalBrush, petalX - 2, petalY - 3, 4, 6);
                }
            }

            // Viền cánh hoa nhạt
            using (var petalPen = new Pen(Color.FromArgb(255, 221, 160, 221), 0.5f)) // Plum
            {
                for (int i = 0; i < 5; i++)
                {
                    double angle = i * 72 * Math.PI / 180;
                    int petalX = x + (int)(Math.Cos(angle) * 4);
                    int petalY = y + (int)(Math.Sin(angle) * 4);

                    g.DrawEllipse(petalPen, petalX - 2, petalY - 3, 4, 6);
                }
            }

            // Nhị hoa màu vàng
            using (var centerBrush = new SolidBrush(Color.FromArgb(255, 255, 215, 0))) // Gold
            {
                g.FillEllipse(centerBrush, x - 2, y - 2, 4, 4);
            }

            // Chấm nhỏ ở tâm
            using (var centerDot = new SolidBrush(Color.FromArgb(255, 255, 140, 0))) // DarkOrange
            {
                g.FillEllipse(centerDot, x - 1, y - 1, 2, 2);
            }
        }
    }
}