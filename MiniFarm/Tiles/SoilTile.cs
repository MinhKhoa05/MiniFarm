using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using MiniFarm.Plants.Base;

namespace MiniFarm.Tiles
{
    public class SoilTile : ITile
    {
        private readonly Random random = new Random();
        public IPlant CurrentPlant { get; set; } = null;

        public void Render(Graphics g, int x, int y, int size)
        {
            // Vẽ nền đất
            using (SolidBrush baseBrush = new SolidBrush(Color.FromArgb(139, 94, 60)))
            {
                g.FillRectangle(baseBrush, x, y, size - 1, size - 1);
            }

            CreateSoilTexture(g, x, y, size);
            DrawSoilParticles(g, x, y, size);
            DrawSoilLines(g, x, y, size);
            AddDepthEffect(g, x, y, size);

            // Viền ngoài
            using (Pen borderPen = new Pen(Color.FromArgb(100, 101, 67, 33)))
            {
                g.DrawRectangle(borderPen, x, y, size - 1, size - 1);
            }

            if (CurrentPlant != null)
            {
                // Vẽ cây nếu có
                int plantSize = Math.Min(size - 2, 24); // Kích thước tối đa 24px
                int plantX = x + (size - plantSize) / 2;
                int plantY = y + (size - plantSize) / 2;
                CurrentPlant?.Render(g, plantX, plantY, plantSize);
            }
        }

        private void CreateSoilTexture(Graphics g, int x, int y, int size)
        {
            Color[] soilColors = {
                Color.FromArgb(80, 120, 80, 50),
                Color.FromArgb(60, 160, 110, 70),
                Color.FromArgb(70, 101, 67, 33),
                Color.FromArgb(50, 139, 90, 43)
            };

            for (int i = 0; i < 15; i++)
            {
                int patchX = x + random.Next(0, size - 4);
                int patchY = y + random.Next(0, size - 4);
                int patchSize = random.Next(2, 6);

                Color color = soilColors[random.Next(soilColors.Length)];
                using (SolidBrush patchBrush = new SolidBrush(color))
                {
                    g.FillRectangle(patchBrush, patchX, patchY, patchSize, patchSize);
                }
            }
        }

        private void DrawSoilParticles(Graphics g, int x, int y, int size)
        {
            Color[] particleColors = {
                Color.FromArgb(150, 160, 160, 160),
                Color.FromArgb(120, 205, 133, 63),
                Color.FromArgb(100, 101, 67, 33)
            };

            for (int i = 0; i < 8; i++)
            {
                int particleX = x + random.Next(2, size - 4);
                int particleY = y + random.Next(2, size - 4);
                int particleSize = random.Next(1, 3);

                Color color = particleColors[random.Next(particleColors.Length)];
                using (SolidBrush particleBrush = new SolidBrush(color))
                {
                    g.FillEllipse(particleBrush, particleX, particleY, particleSize, particleSize);
                }
            }
        }

        private void DrawSoilLines(Graphics g, int x, int y, int size)
        {
            using (Pen linePen = new Pen(Color.FromArgb(60, 101, 67, 33), 1))
            {
                for (int i = 0; i < 3; i++)
                {
                    int startX = x + random.Next(0, size / 2);
                    int startY = y + random.Next(0, size);
                    int endX = startX + random.Next(size / 4, size / 2);
                    int endY = startY + random.Next(-5, 5);

                    endX = Math.Min(endX, x + size - 1);
                    endY = Math.Max(y, Math.Min(endY, y + size - 1));

                    g.DrawLine(linePen, startX, startY, endX, endY);
                }
            }
        }

        private void AddDepthEffect(Graphics g, int x, int y, int size)
        {
            using (Pen highlightPen = new Pen(Color.FromArgb(40, 255, 255, 255), 1))
            {
                g.DrawLine(highlightPen, x, y, x + size - 1, y);
                g.DrawLine(highlightPen, x, y, x, y + size - 1);
            }

            using (Pen shadowPen = new Pen(Color.FromArgb(40, 0, 0, 0), 1))
            {
                g.DrawLine(shadowPen, x, y + size - 1, x + size - 1, y + size - 1);
                g.DrawLine(shadowPen, x + size - 1, y, x + size - 1, y + size - 1);
            }

            using (LinearGradientBrush gradientBrush = new LinearGradientBrush(
                new Point(x, y),
                new Point(x + size, y),
                Color.FromArgb(20, 255, 255, 255),
                Color.FromArgb(20, 0, 0, 0)))
            {
                g.FillRectangle(gradientBrush, x, y, size - 1, size - 1);
            }
        }

        public bool OnClick()
        {
            // Hành động khi người dùng click vào ô đất
            if (CurrentPlant == null)
            {
                CurrentPlant = PlantFactory.CreatePlant(); // Giả sử có một factory để tạo cây trồng
                return true; // Trả về true nếu đã trồng cây mới
            }
            else
            {
                // Nếu đã có cây trồng, có thể thu hoạch hoặc tương tác với cây
                Console.WriteLine($"Interacting with {CurrentPlant.PlantName}.");
                return false; // Trả về false nếu không trồng cây mới
            }
        }
    }
}
