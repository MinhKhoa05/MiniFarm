using System.Windows.Forms;

namespace MiniFarm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            FarmGrid farmGrid = new FarmGrid(100);

            farmGrid.CellHovered += (s, e) =>
            {
                richInfo.Text = $"{e.TileInfo}";
            };

            LoadUserControl(gridPanel, farmGrid);
        }

        private void LoadUserControl(Panel targetPanel, UserControl control)
        {
            targetPanel.Controls.Clear();
            control.Dock = DockStyle.Fill;
            targetPanel.Controls.Add(control);
            control.BringToFront();
        }
    }
}
