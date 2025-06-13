using System;
using MiniFarm.Plants.Crops;

namespace MiniFarm.Plants.Base
{
    public static class PlantFactory
    {
        private static readonly Random random = new Random();

        public static IPlant CreatePlant()
        {
            int plantId = random.Next(1, 8); // 1 to 7

            switch (plantId)
            {
                case 1:
                    return new Cabbage();
                case 2:
                    return new Tomato();
                case 3:
                    return new Wheat();
                case 4:
                    return new Carrot();
                case 5:
                    return new Potato();
                case 6:
                    return new ChiliPepper();
                case 7:
                    return new Corn();
                default:
                    return new Corn();
            }
        }
    }
}
