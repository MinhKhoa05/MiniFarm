using System.Drawing;
using MiniFarm.Plants.Base;
using MiniFarm.Tiles;
using MiniFarm.Tiles.Decorators;

namespace MiniFarm
{
    public class TileManager
    {
        private readonly ITile[,] tiles;
        private readonly int rows;
        private readonly int cols;

        public TileManager(int rows, int cols, int totalTiles)
        {
            this.rows = rows;
            this.cols = cols;
            tiles = new ITile[rows, cols];

            int remaining = totalTiles;
            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++)
                {
                    remaining--;
                    if (remaining > 0)
                    {
                        tiles[r, c] = new SoilTile();
                    }
                    else
                    {
                        tiles[r, c] = new EmptyTile();
                    }
                }
        }
        
        public ITile GetTile(int row, int col)
        {
            if (row < 0 || row >= rows || col < 0 || col >= cols)
                return null;
            return tiles[row, col];
        }

        public bool TryPlantAt(int row, int col)
        {
            if (tiles[row, col] is TileWithPlant)
                return false;

            if (tiles[row, col].OnClick())
            {
                tiles[row, col] = new TileWithPlant(tiles[row, col], PlantFactory.CreatePlant());
                return true;
            }

            return false;
        }

        public void RenderAll(Graphics g, int cellSize)
        {
            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++)
                    tiles[r, c].Render(g, c * cellSize, r * cellSize, cellSize);
        }

        public string GetInfoAt(int row, int col)
        {
            if (row < 0 || row >= tiles.GetLength(0) || col < 0 || col >= tiles.GetLength(1))
                return "";

            return tiles[row, col]?.GetInfo() ?? "";
        }

    }
}
