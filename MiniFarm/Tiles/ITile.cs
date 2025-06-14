using System.Drawing;

namespace MiniFarm.Tiles
{
    public interface ITile
    {
        void Render(Graphics g, int x, int y, int size);
        bool OnClick();
        string GetInfo();
    }
}
