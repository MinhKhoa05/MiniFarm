using System;
using System.Drawing;
using System.Windows.Forms;

namespace MiniFarm
{
    public class FarmGrid : UserControl
    {
        private const int CellSize = 64;
        private readonly TileManager tileManager;
        private readonly int rows, columns;
        private bool isDragging = false;
        private Point lastHandled = new Point(-1, -1);

        private Point mouseDownPos = Point.Empty;
        private DateTime mouseDownTime;
        private const int CLICK_THRESHOLD = 200;

        public event EventHandler<CellClickedEventArgs> CellClicked;
        public event EventHandler<CellHoveredEventArgs> CellHovered;

        public FarmGrid(int totalCells)
        {
            DoubleBuffered = true;
            columns = 12;
            rows = (int)Math.Ceiling(totalCells / (double)columns);

            tileManager = new TileManager(rows, columns, totalCells);

            MouseDown += OnMouseDown;
            MouseUp += OnMouseUp;
            MouseMove += OnMouseMove;
            MouseLeave += OnMouseLeave;
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            mouseDownPos = e.Location;
            mouseDownTime = DateTime.Now;
            isDragging = true;

            HandleMouseAt(e.Location);
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            var clickDuration = DateTime.Now - mouseDownTime;
            var moveDistance = Distance(mouseDownPos, e.Location);

            if (clickDuration.TotalMilliseconds < CLICK_THRESHOLD && moveDistance <= 5)
            {
                var cell = GetCellAt(e.Location);
                if (cell.X >= 0 && cell.Y >= 0)
                {
                    CellClicked?.Invoke(this, new CellClickedEventArgs(cell.Y, cell.X));
                }
            }

            isDragging = false;
            lastHandled = new Point(-1, -1);
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            var cell = GetCellAt(e.Location);
            if (cell.X >= 0 && cell.Y >= 0)
            {
                var tile = tileManager.GetTile(cell.Y, cell.X);
                string tileInfo = tile?.GetInfo() ?? "";

                CellHovered?.Invoke(this, new CellHoveredEventArgs(cell.Y, cell.X, tileInfo));
            }

            if (isDragging)
            {
                HandleMouseAt(e.Location);
            }
        }


        private void OnMouseLeave(object sender, EventArgs e)
        {
            // Không cần làm gì khi không dùng tooltip
        }

        private void HandleMouseAt(Point location)
        {
            int col = location.X / CellSize;
            int row = location.Y / CellSize;

            if (row < 0 || row >= rows || col < 0 || col >= columns) return;

            var cell = new Point(col, row);
            if (cell != lastHandled)
            {
                if (tileManager.TryPlantAt(row, col))
                    Invalidate(new Rectangle(col * CellSize, row * CellSize, CellSize, CellSize));

                CellClicked?.Invoke(this, new CellClickedEventArgs(row, col));
                lastHandled = cell;
            }
        }

        private Point GetCellAt(Point location)
        {
            int col = location.X / CellSize;
            int row = location.Y / CellSize;

            if (row < 0 || row >= rows || col < 0 || col >= columns)
                return new Point(-1, -1);

            return new Point(col, row);
        }

        private int Distance(Point p1, Point p2)
        {
            int dx = p1.X - p2.X;
            int dy = p1.Y - p2.Y;
            return (int)Math.Sqrt(dx * dx + dy * dy);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(Color.FromArgb(255, 245, 245, 220));
            tileManager.RenderAll(e.Graphics, CellSize);
            DrawGridLines(e.Graphics);
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

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
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

    public class CellHoveredEventArgs : EventArgs
    {
        public int Row { get; }
        public int Column { get; }
        public string TileInfo { get; }

        public CellHoveredEventArgs(int row, int column, string tileInfo)
        {
            Row = row;
            Column = column;
            TileInfo = tileInfo;
        }
    }

}
