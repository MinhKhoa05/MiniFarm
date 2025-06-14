using System.Drawing;

namespace MiniFarm.Tiles
{
    public class EmptyTile : ITile
    {
        public void Render(Graphics g, int x, int y, int size) { }

        public bool OnClick() => false;
        public string GetInfo()
        {
            return "Ô trống, không có gì ở đây.";
        }
    }
}