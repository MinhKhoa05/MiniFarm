using System;
using System.Drawing;
using System.Windows.Forms;

namespace MiniFarm
{
    public partial class ToolPanel : UserControl
    {
        public event Action<string> SeedSelected;
        //public event Action<ToolType> ToolSelected;

        public ToolPanel()
        {
            InitializeComponent();
            InitEvents();
        }

        private void InitEvents()
        {
            seedSelector.Items.AddRange(new string[] { "Tomato", "Carrot", "Potato" });
            seedSelector.SelectedIndex = 0;

            seedButton.Click += (s, e) => SeedSelected?.Invoke(seedSelector.SelectedItem?.ToString() ?? "");
            //waterButton.Click += (s, e) => ToolSelected?.Invoke(ToolType.Water);
            //harvestButton.Click += (s, e) => ToolSelected?.Invoke(ToolType.Harvest);
        }

        //public void UpdateUI(string moneyText, ToolType selectedTool, string selectedSeed)
        //{
        //    moneyLabel.Text = moneyText;
        //    switch (selectedTool)
        //    {
        //        case ToolType.Seed:
        //            toolLabel.Text = "Tool: Plant " + selectedSeed;
        //            break;

        //        case ToolType.Water:
        //            toolLabel.Text = "Tool: Water";
        //            break;


        //        case ToolType.Harvest:
        //            toolLabel.Text = "Tool: Harvest";
        //            break;

        //        default:
        //            toolLabel.Text = "Tool: None";
        //            break;
        //    }

        //    HighlightSelectedTool(selectedTool);
        //}

        //private void HighlightSelectedTool(ToolType selectedTool)
        //{
        //    seedButton.BackColor = Color.FromArgb(92, 184, 92);
        //    waterButton.BackColor = Color.FromArgb(91, 192, 222);
        //    harvestButton.BackColor = Color.FromArgb(240, 173, 78);

        //    switch (selectedTool)
        //    {
        //        case ToolType.Seed:
        //            seedButton.BackColor = Color.FromArgb(76, 174, 76); break;
        //        case ToolType.Water:
        //            waterButton.BackColor = Color.FromArgb(51, 181, 229); break;
        //        case ToolType.Harvest:
        //            harvestButton.BackColor = Color.FromArgb(237, 156, 40); break;
        //    }
        //}
    }
}
