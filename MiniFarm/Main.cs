using System.Windows.Forms;

namespace MiniFarm
{
    public partial class Main : Form
    {
        //private FarmGrid farmGrid;
        //private GameManager gameManager;
        //private Timer gameTimer;

        public Main()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            LoadUserControl(toolPanel, new ToolPanel());
            LoadUserControl(gridPanel, new FarmGrid(100));
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
