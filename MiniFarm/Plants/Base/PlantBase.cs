using System;
using System.Drawing;

namespace MiniFarm.Plants.Base
{
    public abstract class PlantBase : IPlant
    {
        public virtual string PlantName { get; set; } = "Cây trồng cơ bản";
        public abstract void Render(Graphics g, int x, int y, int size);
    }
}