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
            int centerX = x + size / 2;
            int baseY = y + size - 4;

            // Bóng đổ nhẹ
            using (var shadowBrush = new SolidBrush(Color.FromArgb(30, 0, 0, 0)))
            {
                g.FillEllipse(shadowBrush, x + 2, baseY - 2, size - 4, 6);
            }

            DrawCornStalks(g, centerX, baseY);
            DrawCornLeaves(g, centerX, baseY);
            DrawCornCobs(g, centerX, baseY);
        }

        private void DrawCornStalks(Graphics g, int centerX, int baseY)
        {
            using (var stalkPen = new Pen(Color.FromArgb(85, 107, 47), 2)) // OliveGreen
            {
                for (int i = 0; i < 3; i++)
                {
                    int offsetX = (i - 1) * 3;
                    int stalkX = centerX + offsetX;
                    int stalkHeight = 20 + random.Next(-2, 3);
                    int bendX = stalkX + (i % 2 == 0 ? 2 : -2);

                    using (var path = new GraphicsPath())
                    {
                        path.AddBezier(
                            stalkX, baseY,
                            stalkX, baseY - stalkHeight / 2,
                            bendX, baseY - stalkHeight + 4,
                            bendX, baseY - stalkHeight
                        );
                        g.DrawPath(stalkPen, path);
                    }
                }
            }
        }

        private void DrawCornLeaves(Graphics g, int centerX, int baseY)
        {
            using (var leafBrush = new SolidBrush(Color.FromArgb(60, 179, 113))) // MediumSeaGreen
            using (var leafPen = new Pen(Color.FromArgb(46, 139, 87), 1)) // SeaGreen
            {
                for (int i = 0; i < 4; i++)
                {
                    int leafX = centerX + (i % 2 == 0 ? -6 - i * 2 : 6 + i * 2);
                    int leafY = baseY - 10 - i * 4;
                    Point[] leaf = new Point[]
                    {
                        new Point(leafX, leafY),
                        new Point(leafX + (i % 2 == 0 ? -4 : 4), leafY - 6),
                        new Point(leafX, leafY - 12),
                        new Point(leafX + (i % 2 == 0 ? 4 : -4), leafY - 6)
                    };

                    g.FillPolygon(leafBrush, leaf);
                    g.DrawPolygon(leafPen, leaf);
                }
            }
        }

        private void DrawCornCobs(Graphics g, int centerX, int baseY)
        {
            using (var cobBrush = new SolidBrush(Color.FromArgb(255, 215, 0))) // Gold
            using (var border = new Pen(Color.FromArgb(218, 165, 32))) // GoldenRod
            {
                for (int i = 0; i < 2; i++)
                {
                    int cobX = centerX + (i == 0 ? -6 : 6);
                    int cobY = baseY - 18 + i * 2;
                    Rectangle cobRect = new Rectangle(cobX - 2, cobY, 5, 10);
                    g.FillEllipse(cobBrush, cobRect);
                    g.DrawEllipse(border, cobRect);

                    // Tua ngô
                    using (var silkPen = new Pen(Color.SaddleBrown, 1))
                    {
                        g.DrawLine(silkPen, cobX, cobY, cobX, cobY - 4);
                    }
                }
            }
        }
    }
}
