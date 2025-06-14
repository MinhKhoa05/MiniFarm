using System;
using System.Drawing;
using MiniFarm.Plants.Base;

namespace MiniFarm.Tiles.Decorators
{
    public class TileWithPlant : ITile
    {
        private readonly ITile _tile;
        private readonly IPlant _plant;

        public TileWithPlant(ITile tile, IPlant plant)
        {
            _tile = tile ?? throw new ArgumentNullException(nameof(tile));
            _plant = plant ?? throw new ArgumentNullException(nameof(plant));
        }

        public void Render(Graphics g, int x, int y, int size)
        {
            _tile.Render(g, x, y, size);

            if (_plant == null) return;

            var plantSize = Math.Min(size - 2, 30);
            var plantX = x + (size - plantSize) / 2;
            var plantY = y + (size - plantSize) / 2;

            _plant.Render(g, plantX, plantY, plantSize);
        }

        public bool OnClick() => _tile.OnClick();

        public string GetInfo()
        {
            return $"{_tile.GetInfo()}\n🌱 Cây trồng: {_plant.PlantName}";
        }
    }
}
