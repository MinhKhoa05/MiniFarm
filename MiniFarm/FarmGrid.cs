using System;
using System.Drawing;
using System.Windows.Forms;
using MiniFarm.Tiles;

namespace MiniFarm
{
    public class FarmGrid : UserControl
    {
        private readonly int columns;
        private readonly int rows;
        private const int CellSize = 64;
        private readonly ITile[,] tiles;

        private bool isDragging = false;
        private Point lastHandled = new Point(-1, -1);

        public event EventHandler<CellClickedEventArgs> CellClicked;

        public FarmGrid(int totalCells)
        {
            DoubleBuffered = true;
            columns = 12;
            rows = (int)Math.Ceiling(totalCells / (double)columns);
            Size = new Size(columns * CellSize, rows * CellSize);

            tiles = new ITile[rows, columns];

            int remaining = totalCells;
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    if (remaining > 0)
                    {
                        tiles[r, c] = new SoilTile();
                        remaining--;
                    }
                    else
                    {
                        tiles[r, c] = new EmptyTile();
                    }
                }
            }

            MouseDown += OnMouseDown;
            MouseUp += OnMouseUp;
            MouseMove += OnMouseMove;
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
            HandleTileClickAt(e.Location);
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
            lastHandled = new Point(-1, -1);
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                HandleTileClickAt(e.Location);
            }
        }

        private void HandleTileClickAt(Point location)
        {
            int col = location.X / CellSize;
            int row = location.Y / CellSize;

            if (row >= 0 && row < rows && col >= 0 && col < columns)
            {
                Point cell = new Point(col, row);
                if (lastHandled != cell)
                {
                    // Chỉ cập nhật nếu khác
                    if (tiles[row, col].OnClick())
                    {
                        Invalidate(new Rectangle(col * CellSize, row * CellSize, CellSize, CellSize));
                    }

                    CellClicked?.Invoke(this, new CellClickedEventArgs(row, col));
                    lastHandled = cell;
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(Color.FromArgb(255, 245, 245, 220)); // Beige

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    tiles[r, c].Render(g, c * CellSize, r * CellSize, CellSize);
                }
            }

            DrawGridLines(g);
        }

        private void DrawGridLines(Graphics g)
        {
            using (var pen = new Pen(Color.FromArgb(30, 139, 69, 19), 1))
            {
                for (int c = 0; c <= columns; c++)
                    g.DrawLine(pen, c * CellSize, 0, c * CellSize, rows * CellSize);

                for (int r = 0; r <= rows; r++)
                    g.DrawLine(pen, 0, r * CellSize, columns * CellSize, r * CellSize);
            }
        }
    }

    public class CellClickedEventArgs : EventArgs
    {
        public int Row { get; }
        public int Column { get; }

        public CellClickedEventArgs(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}
