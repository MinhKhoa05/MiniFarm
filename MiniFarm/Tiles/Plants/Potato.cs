using System.Drawing;

namespace MiniFarm.Tiles.Plants
{
    public class Potato : PlantDecorator
    {
        protected override string PlantName { get; set; } = "Khoai tây";

        public Potato(ITile baseTile) : base(baseTile) { }

        public override void RenderPlant(Graphics g, int x, int y, int size)
        {
            int centerX = x + size / 2;
            int baseY = y + size - 8;
            Rectangle bounds = new Rectangle(x, y, size, size);

            // Vẽ bóng củ khoai
            PlantDrawingHelper.DrawShadow(g, new Rectangle(x + 3, baseY - 2, size - 6, 6));

            // Vẽ các củ khoai tây (3 củ)
            for (int i = 0; i < 3; i++)
            {
                int offsetX = (i - 1) * 10;
                Rectangle oval = new Rectangle(centerX + offsetX - 5, baseY - 12, 10, 14);
                PlantDrawingHelper.DrawFilledEllipseWithBorder(
                    g, oval,
                    Color.FromArgb(222, 184, 135),      // BurlyWood
                    Color.FromArgb(160, 120, 80));      // Brown
            }

            // Vẽ các lá khoai
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

                PlantDrawingHelper.DrawLeaf(
                    g, leaf,
                    Color.FromArgb(34, 139, 34), // ForestGreen
                    Color.DarkGreen              // Border
                );
            }
        }
    }
}
