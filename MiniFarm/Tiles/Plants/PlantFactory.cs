using System;

namespace MiniFarm.Tiles.Plants
{
    public static class PlantFactory
    {
        private static readonly Random random = new Random();

        public static ITile CreatePlant(ITile baseTile)
        {
            // Nếu đã là cây hoặc không phải là đất thì không trồng được
            if (baseTile is PlantDecorator || !(baseTile is SoilTile))
                return baseTile;

            int plantId = random.Next(1, 6); // 1 to 3

            switch (plantId)
            {
                case 1:
                    return new Cabbage(baseTile);
                case 2:
                    return new Tomato(baseTile);
                case 3:
                    return new Wheat(baseTile);
                case 4:
                    return new Carrot(baseTile);
                case 5:
                    return new Potato(baseTile);
                default:
                    return baseTile;
            }
        }
    }
}
