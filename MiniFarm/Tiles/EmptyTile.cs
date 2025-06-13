using System.Drawing;

namespace MiniFarm.Tiles
{
    public class EmptyTile : ITile
    {
        public void Render(Graphics g, int x, int y, int size) { }

        public void OnClick() { }
     
        public string GetInfo()
        {
            return "Ô trống";
        }
    }
}