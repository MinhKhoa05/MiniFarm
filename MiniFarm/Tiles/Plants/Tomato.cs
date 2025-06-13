using System.Drawing;
using System.Drawing.Drawing2D;

namespace MiniFarm.Tiles.Plants
{
    public class Tomato : PlantDecorator
    {
        protected override string PlantName { get; set; } = "Cà chua";

        public Tomato(ITile baseTile) : base(baseTile) { }

        public override void RenderPlant(Graphics g, int x, int y, int size)
        {
            // Bóng
            PlantDrawingHelper.DrawShadow(g, new Rectangle(x + 2, y + 2, size, size), 50);

            // Quả cà chua đỏ với gradient
            PlantDrawingHelper.DrawGradientCircle(
                g,
                new Rectangle(x, y, size, size),
                Color.FromArgb(255, 255, 99, 71),             // Center: Tomato
                Color.FromArgb(255, 178, 34, 34)    // Surround: Firebrick
            );

            // Highlight
            int highlightSize = size / 3;
            PlantDrawingHelper.DrawHighlight(g,
                x + size / 4,
                y + size / 4,
                highlightSize
            );

            // Cuống chính
            int centerX = x + size / 2;
            int stemY = y - 2;
            using (var stemBrush = new SolidBrush(Color.FromArgb(34, 139, 34)))
            {
                g.FillRectangle(stemBrush, new Rectangle(centerX - 2, stemY - 6, 4, 8));
            }

            // Lá xung quanh cuống
            Color leafColor = Color.FromArgb(50, 205, 50); // LimeGreen
            Point[][] leaves = {
                new[] { new Point(centerX - 4, stemY - 2), new Point(centerX - 6, stemY - 4), new Point(centerX - 2, stemY - 1) },
                new[] { new Point(centerX + 4, stemY - 2), new Point(centerX + 6, stemY - 4), new Point(centerX + 2, stemY - 1) },
                new[] { new Point(centerX - 1, stemY - 3), new Point(centerX - 2, stemY - 6), new Point(centerX + 1, stemY - 4) },
                new[] { new Point(centerX + 1, stemY - 3), new Point(centerX + 2, stemY - 6), new Point(centerX - 1, stemY - 4) }
            };
            foreach (var leaf in leaves)
            {
                using (var leafBrush = new SolidBrush(leafColor))
                {
                    g.FillPolygon(leafBrush, leaf);
                }
            }

            // Viền quả
            using (var outlinePen = new Pen(Color.FromArgb(100, 139, 69, 19), 1))
            {
                g.DrawEllipse(outlinePen, x, y, size, size);
            }
        }
    }
}
