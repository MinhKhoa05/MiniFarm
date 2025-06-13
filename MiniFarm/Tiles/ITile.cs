using System.Drawing;

namespace MiniFarm.Tiles
{
    public interface ITile
    {
        void Render(Graphics g, int x, int y, int size);

        void OnClick();
        string GetInfo(); // Thêm phương thức để lấy thông tin về tile
    }
}
