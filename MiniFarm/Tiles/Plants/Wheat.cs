using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MiniFarm.Tiles.Plants
{
    public class Wheat : PlantDecorator
    {
        private readonly Random random = new Random();

        protected override string PlantName { get; set; } = "Lúa";

        public Wheat(ITile baseTile) : base(baseTile)
        {
        }

        public override void RenderPlant(Graphics g, int x, int y, int size)
        {
            int centerX = x + size / 2;
            int baseY = y + size - 4;

            // Vẽ bóng đổ nhẹ cho cây lúa
            using (var shadowBrush = new SolidBrush(Color.FromArgb(30, 0, 0, 0)))
            {
                g.FillEllipse(shadowBrush, x + 2, baseY - 2, size - 4, 6);
            }

            // Vẽ các thân lúa (4-5 thân)
            DrawRiceStems(g, centerX, baseY, size);

            // Vẽ lá lúa
            DrawRiceLeaves(g, centerX, baseY, size);

            // Vẽ bông lúa chín (màu vàng)
            DrawRiceGrains(g, centerX, baseY, size);

            // Vẽ một vài hạt lúa rơi
            DrawFallenGrains(g, x, y, size);
        }

        private void DrawRiceStems(Graphics g, int centerX, int baseY, int size)
        {
            using (var stemPen = new Pen(Color.FromArgb(255, 107, 142, 35), 2)) // Olive drab
            {
                for (int i = 0; i < 4; i++)
                {
                    int stemX = (int)(centerX + (i - 1.5f) * 3);
                    int stemHeight = 18 + random.Next(-2, 3);
                    int bendX = stemX + (i % 2 == 0 ? 3 : -3); // Nghiêng do nặng hạt

                    // Vẽ thân cong bằng Bezier curve
                    using (var path = new GraphicsPath())
                    {
                        path.AddBezier(
                            (int)stemX, baseY,
                            (int)stemX, baseY - stemHeight / 2,
                            bendX, baseY - stemHeight + 4,
                            bendX, baseY - stemHeight
                        );
                        g.DrawPath(stemPen, path);
                    }
                }
            }
        }

        private void DrawRiceLeaves(Graphics g, int centerX, int baseY, int size)
        {
            // Màu lá lúa (xanh với chút vàng)
            using (var leafBrush = new SolidBrush(Color.FromArgb(255, 154, 205, 50))) // Yellow green
            using (var leafOutline = new Pen(Color.FromArgb(255, 107, 142, 35), 1))
            {
                for (int i = 0; i < 6; i++)
                {
                    int leafX = (int)(centerX + (i - 2.5f) * 2);
                    int leafY = baseY - 8 - (i % 3);

                    int leafTip = random.Next(-2, 3);

                    // Vẽ lá dài và nhọn
                    Point[] leaf = {
                        new Point((int)leafX, leafY),
                        new Point((int)leafX - 2, leafY - 6),
                        new Point((int)leafX + leafTip, leafY - 12),
                        new Point((int)leafX + 2, leafY - 6)
                    };

                    g.FillPolygon(leafBrush, leaf);
                    g.DrawPolygon(leafOutline, leaf);
                }
            }
        }

        private void DrawRiceGrains(Graphics g, int centerX, int baseY, int size)
        {
            // Màu hạt lúa chín
            using (var riceBrush = new SolidBrush(Color.FromArgb(255, 255, 215, 0))) // Gold
            using (var riceOutline = new Pen(Color.FromArgb(255, 218, 165, 32), 1)) // Goldenrod
            using (var highlightBrush = new SolidBrush(Color.FromArgb(100, 255, 255, 255)))
            {
                // Vẽ 3 cụm bông lúa
                for (int cluster = 0; cluster < 3; cluster++)
                {
                    int clusterX = centerX + (cluster - 1) * 4;
                    int clusterY = baseY - 20;
                    int bend = cluster % 2 == 0 ? 2 : -2;

                    // Vẽ nhiều hạt lúa trong mỗi cụm
                    for (int grain = 0; grain < 8; grain++)
                    {
                        int grainX = clusterX + bend + random.Next(-1, 2);
                        int grainY = clusterY + grain * 2;

                        // Hạt lúa hình oval
                        g.FillEllipse(riceBrush, grainX - 1, grainY, 3, 4);
                        g.DrawEllipse(riceOutline, grainX - 1, grainY, 3, 4);

                        // Highlight nhỏ trên hạt
                        g.FillEllipse(highlightBrush, grainX, grainY + 1, 1, 1);
                    }
                }
            }

            // Vẽ cọng lúa (awn) - những sợi nhỏ trên hạt
            using (var awnPen = new Pen(Color.FromArgb(255, 218, 165, 32), 1))
            {
                for (int cluster = 0; cluster < 3; cluster++)
                {
                    int clusterX = centerX + (cluster - 1) * 4;
                    int clusterY = baseY - 20;
                    int bend = cluster % 2 == 0 ? 2 : -2;

                    for (int i = 0; i < 4; i++)
                    {
                        int awnX = clusterX + bend;
                        int awnY = clusterY + i * 4;
                        g.DrawLine(awnPen, awnX, awnY, awnX + 2, awnY - 3);
                    }
                }
            }
        }

        private void DrawFallenGrains(Graphics g, int x, int y, int size)
        {
            using (var fallenGrainBrush = new SolidBrush(Color.FromArgb(255, 255, 215, 0)))
            {
                // Vẽ 2-3 hạt lúa rơi xuống đất
                for (int i = 0; i < 3; i++)
                {
                    int grainX = x + random.Next(3, size - 5);
                    int grainY = y + size - 5 + random.Next(-1, 2);
                    g.FillEllipse(fallenGrainBrush, grainX, grainY, 2, 3);
                }
            }
        }
    }
}