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
