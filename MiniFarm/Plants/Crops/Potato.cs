using System.Drawing;
using MiniFarm.Plants.Base;

namespace MiniFarm.Plants.Crops
{
    public class Potato : PlantBase
    {
        public override string PlantName { get; set; } = "Khoai tây";

        public override void Render(Graphics g, int x, int y, int size)
        {
            int centerX = x + size / 2;
            int baseY = y + size - 8;

            // Vẽ bóng củ khoai (ellipse mờ dưới đáy)
            using (var shadowBrush = new SolidBrush(Color.FromArgb(50, 0, 0, 0)))
            {
                g.FillEllipse(shadowBrush, new Rectangle(x + 3, baseY - 2, size - 6, 6));
            }

            // Vẽ 3 củ khoai tây
            for (int i = 0; i < 3; i++)
            {
                int offsetX = (i - 1) * 10;
                Rectangle oval = new Rectangle(centerX + offsetX - 5, baseY - 12, 10, 14);

                // Vẽ phần thân củ
                using (var bodyBrush = new SolidBrush(Color.FromArgb(222, 184, 135))) // BurlyWood
                using (var borderPen = new Pen(Color.FromArgb(160, 120, 80), 1))      // Brown
                {
                    g.FillEllipse(bodyBrush, oval);
                    g.DrawEllipse(borderPen, oval);
                }
            }

            // Vẽ lá
            for (int i = 0; i < 4; i++)
            {
                int leafX = centerX + (i - 1) * 5;
                int leafY = baseY - 18 - (i % 2) * 3;

                Point[] leaf = {
                    new Point(leafX, leafY),
                    new Point(leafX - 3, leafY - 5),
                    new Point(leafX, leafY - 10),
                    new Point(leafX + 3, leafY - 5)
                };

                using (var leafBrush = new SolidBrush(Color.FromArgb(34, 139, 34))) // ForestGreen
                using (var leafPen = new Pen(Color.DarkGreen, 1))
                {
                    g.FillPolygon(leafBrush, leaf);
                    g.DrawPolygon(leafPen, leaf);
                }
            }
        }
    }
}
