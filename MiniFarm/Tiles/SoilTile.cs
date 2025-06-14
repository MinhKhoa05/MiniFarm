using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MiniFarm.Tiles
{
    public class SoilTile : ITile
    {
        private readonly int seed;

        public SoilTile()
        {
            // Tạo seed duy nhất cho mỗi tile để có pattern ổn định
            seed = GetHashCode();
        }

        public void Render(Graphics g, int x, int y, int size)
        {
            // Thiết lập chất lượng render cao
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            // Vẽ nền đất chính
            DrawBaseLayer(g, x, y, size);

            // Vẽ các lớp texture
            DrawSoilTextureLayers(g, x, y, size);

            // Vẽ chi tiết đất
            DrawSoilDetails(g, x, y, size);

            // Hiệu ứng độ sâu và ánh sáng
            AddLightingEffects(g, x, y, size);

            // Viền và hoàn thiện
            DrawBorderAndFinish(g, x, y, size);
        }

        private void DrawBaseLayer(Graphics g, int x, int y, int size)
        {
            // Gradient nền từ nâu sáng đến nâu đậm
            using (LinearGradientBrush baseBrush = new LinearGradientBrush(
                new Point(x, y),
                new Point(x + size, y + size),
                Color.FromArgb(160, 120, 80),    // Nâu sáng
                Color.FromArgb(110, 75, 45)))    // Nâu đậm
            {
                g.FillRectangle(baseBrush, x, y, size - 1, size - 1);
            }
        }

        private void DrawSoilTextureLayers(Graphics g, int x, int y, int size)
        {
            // Reset random với seed
            Random localRandom = new Random(seed);

            // Lớp 1: Các mảng đất lớn
            DrawLargePatches(g, x, y, size, localRandom);

            // Lớp 2: Texture chi tiết
            DrawMediumTexture(g, x, y, size, localRandom);

            // Lớp 3: Texture mịn
            DrawFineTexture(g, x, y, size, localRandom);
        }

        private void DrawLargePatches(Graphics g, int x, int y, int size, Random rnd)
        {
            Color[] patchColors = {
                Color.FromArgb(90, 140, 95, 65),   // Nâu đỏ nhạt
                Color.FromArgb(85, 120, 85, 55),   // Nâu vàng
                Color.FromArgb(95, 110, 70, 40),   // Nâu đậm
                Color.FromArgb(80, 130, 90, 60)    // Nâu cam
            };

            for (int i = 0; i < 8; i++)
            {
                int patchX = x + rnd.Next(0, size - 12);
                int patchY = y + rnd.Next(0, size - 12);
                int patchW = rnd.Next(8, 16);
                int patchH = rnd.Next(6, 12);

                Color color = patchColors[rnd.Next(patchColors.Length)];

                using (SolidBrush patchBrush = new SolidBrush(color))
                {
                    // Vẽ hình elip thay vì hình chữ nhật để trông tự nhiên hơn
                    g.FillEllipse(patchBrush, patchX, patchY, patchW, patchH);
                }
            }
        }

        private void DrawMediumTexture(Graphics g, int x, int y, int size, Random rnd)
        {
            Color[] textureColors = {
                Color.FromArgb(70, 145, 100, 70),
                Color.FromArgb(60, 125, 80, 50),
                Color.FromArgb(80, 135, 90, 60),
                Color.FromArgb(65, 115, 75, 45)
            };

            for (int i = 0; i < 15; i++)
            {
                int texX = x + rnd.Next(1, size - 6);
                int texY = y + rnd.Next(1, size - 6);
                int texSize = rnd.Next(3, 7);

                Color color = textureColors[rnd.Next(textureColors.Length)];

                using (SolidBrush texBrush = new SolidBrush(color))
                {
                    // Vẽ các hình dạng không đều
                    if (rnd.Next(2) == 0)
                        g.FillEllipse(texBrush, texX, texY, texSize, texSize);
                    else
                        g.FillRectangle(texBrush, texX, texY, texSize, texSize / 2);
                }
            }
        }

        private void DrawFineTexture(Graphics g, int x, int y, int size, Random rnd)
        {
            // Các hạt đất nhỏ và sỏi
            Color[] particleColors = {
                Color.FromArgb(120, 180, 140, 100), // Sáng
                Color.FromArgb(100, 160, 120, 80),  // Trung bình
                Color.FromArgb(80, 140, 100, 60),   // Tối
                Color.FromArgb(90, 200, 160, 120)   // Highlight
            };

            for (int i = 0; i < 25; i++)
            {
                int particleX = x + rnd.Next(2, size - 3);
                int particleY = y + rnd.Next(2, size - 3);
                int particleSize = rnd.Next(1, 3);

                Color color = particleColors[rnd.Next(particleColors.Length)];

                using (SolidBrush particleBrush = new SolidBrush(color))
                {
                    g.FillEllipse(particleBrush, particleX, particleY, particleSize, particleSize);
                }
            }
        }

        private void DrawSoilDetails(Graphics g, int x, int y, int size)
        {
            Random localRandom = new Random(seed + 1);

            // Vẽ các vết nứt và đường gân
            DrawCracks(g, x, y, size, localRandom);

            // Vẽ các đốm và vệt đất
            DrawSoilStreaks(g, x, y, size, localRandom);
        }

        private void DrawCracks(Graphics g, int x, int y, int size, Random rnd)
        {
            using (Pen crackPen = new Pen(Color.FromArgb(80, 80, 50, 30), 1))
            {
                for (int i = 0; i < 4; i++)
                {
                    int startX = x + rnd.Next(size / 4, 3 * size / 4);
                    int startY = y + rnd.Next(0, size);

                    // Tạo đường nứt không đều
                    Point[] crackPoints = new Point[3];
                    crackPoints[0] = new Point(startX, startY);
                    crackPoints[1] = new Point(
                        startX + rnd.Next(-size / 4, size / 4),
                        startY + rnd.Next(-size / 6, size / 6)
                    );
                    crackPoints[2] = new Point(
                        startX + rnd.Next(-size / 3, size / 3),
                        Math.Max(y, Math.Min(y + size - 1, startY + rnd.Next(-size / 4, size / 4)))
                    );

                    if (crackPoints.Length > 1)
                        g.DrawLines(crackPen, crackPoints);
                }
            }
        }

        private void DrawSoilStreaks(Graphics g, int x, int y, int size, Random rnd)
        {
            Color[] streakColors = {
                Color.FromArgb(50, 100, 65, 35),
                Color.FromArgb(60, 120, 80, 50),
                Color.FromArgb(45, 90, 60, 30)
            };

            for (int i = 0; i < 6; i++)
            {
                int streakX = x + rnd.Next(0, size - 8);
                int streakY = y + rnd.Next(0, size - 4);
                int streakW = rnd.Next(4, 12);
                int streakH = rnd.Next(1, 3);

                Color color = streakColors[rnd.Next(streakColors.Length)];

                using (SolidBrush streakBrush = new SolidBrush(color))
                {
                    g.FillRectangle(streakBrush, streakX, streakY, streakW, streakH);
                }
            }
        }

        private void AddLightingEffects(Graphics g, int x, int y, int size)
        {
            // Hiệu ứng ánh sáng từ trên xuống
            using (LinearGradientBrush lightBrush = new LinearGradientBrush(
                new Point(x, y),
                new Point(x, y + size / 2),
                Color.FromArgb(30, 255, 255, 200),  // Ánh sáng vàng nhạt
                Color.FromArgb(0, 255, 255, 200)))
            {
                g.FillRectangle(lightBrush, x, y, size - 1, size / 2);
            }

            // Bóng đổ ở góc dưới
            using (LinearGradientBrush shadowBrush = new LinearGradientBrush(
                new Point(x, y + size / 2),
                new Point(x + size, y + size),
                Color.FromArgb(0, 0, 0, 0),
                Color.FromArgb(40, 0, 0, 0)))
            {
                g.FillRectangle(shadowBrush, x, y + size / 2, size - 1, size / 2);
            }

            // Highlight ở cạnh trên và trái
            using (Pen highlightPen = new Pen(Color.FromArgb(60, 255, 255, 255), 1))
            {
                g.DrawLine(highlightPen, x + 1, y + 1, x + size - 2, y + 1);
                g.DrawLine(highlightPen, x + 1, y + 1, x + 1, y + size - 2);
            }
        }

        private void DrawBorderAndFinish(Graphics g, int x, int y, int size)
        {
            // Viền ngoài với gradient
            using (LinearGradientBrush borderBrush = new LinearGradientBrush(
                new Point(x, y),
                new Point(x + size, y + size),
                Color.FromArgb(120, 70, 45, 25),
                Color.FromArgb(150, 90, 60, 35)))
            {
                using (Pen borderPen = new Pen(borderBrush, 1))
                {
                    g.DrawRectangle(borderPen, x, y, size - 1, size - 1);
                }
            }

            // Viền trong mờ để tạo độ sâu
            using (Pen innerPen = new Pen(Color.FromArgb(40, 0, 0, 0), 1))
            {
                g.DrawRectangle(innerPen, x + 1, y + 1, size - 3, size - 3);
            }
        }

        public bool OnClick()
        {
            return true;
        }

        public string GetInfo()
        {
            return "🌱 Đất màu mỡ";
        }
    }
}