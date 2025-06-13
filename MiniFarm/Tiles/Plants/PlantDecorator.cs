using System;
using System.Drawing;

namespace MiniFarm.Tiles.Plants
{
    public abstract class PlantDecorator : ITile
    {
        private readonly ITile baseTile;
        protected abstract string PlantName { get; set; }

        public PlantDecorator(ITile baseTile)
        {
            this.baseTile = baseTile;
        }

        public void Render(Graphics g, int x, int y, int size)
        {
            baseTile.Render(g, x, y, size);

            int plantSize = Math.Min(size - 2, 24); // Kích thước tối đa 24px
            int plantX = x + (size - plantSize) / 2;
            int plantY = y + (size - plantSize) / 2;
            
            RenderPlant(g, plantX, plantY, plantSize); // Call the specific plant rendering method
        }

        public void OnClick()
        {
            baseTile.OnClick(); // Call the base tile's click handler if needed
        }

        public abstract void RenderPlant(Graphics g, int x, int y, int size);

        public string GetInfo()
        {
            return baseTile.GetInfo() + "\nĐang trồng: " + PlantName;
        }
    }
}