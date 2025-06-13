using System.Drawing;

namespace MiniFarm.Plants.Base
{
    public interface IPlant
    {
        string PlantName { get; set; }
        void Render(Graphics g, int x, int y, int size);
    }
}