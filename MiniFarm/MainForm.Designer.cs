namespace MiniFarm
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.topPanel = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.moneyPanel = new System.Windows.Forms.Panel();
            this.moneyIconLabel = new System.Windows.Forms.Label();
            this.moneyLabel = new System.Windows.Forms.Label();
            this.sidePanel = new System.Windows.Forms.Panel();
            this.infoGroupBox = new System.Windows.Forms.GroupBox();
            this.richInfo = new System.Windows.Forms.RichTextBox();
            this.toolsGroupBox = new System.Windows.Forms.GroupBox();
            this.toolStatusPanel = new System.Windows.Forms.Panel();
            this.toolStatusLabel = new System.Windows.Forms.Label();
            this.toolLabel = new System.Windows.Forms.Label();
            this.harvestButton = new System.Windows.Forms.Button();
            this.waterButton = new System.Windows.Forms.Button();
            this.seedButton = new System.Windows.Forms.Button();
            this.seedGroupBox = new System.Windows.Forms.GroupBox();
            this.seedSelector = new System.Windows.Forms.ComboBox();
            this.seedLabel = new System.Windows.Forms.Label();
            this.shadowPanel = new System.Windows.Forms.Panel();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.gridPanel = new System.Windows.Forms.Panel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.topPanel.SuspendLayout();
            this.moneyPanel.SuspendLayout();
            this.sidePanel.SuspendLayout();
            this.infoGroupBox.SuspendLayout();
            this.toolsGroupBox.SuspendLayout();
            this.toolStatusPanel.SuspendLayout();
            this.seedGroupBox.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.topPanel.Controls.Add(this.titleLabel);
            this.topPanel.Controls.Add(this.moneyPanel);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1305, 75);
            this.topPanel.TabIndex = 0;
            // 
            // titleLabel
            // 
            this.titleLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(19, 19);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(211, 41);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "🌱 Mini Farm";
            // 
            // moneyPanel
            // 
            this.moneyPanel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.moneyPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.moneyPanel.Controls.Add(this.moneyIconLabel);
            this.moneyPanel.Controls.Add(this.moneyLabel);
            this.moneyPanel.Location = new System.Drawing.Point(1080, 12);
            this.moneyPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.moneyPanel.Name = "moneyPanel";
            this.moneyPanel.Size = new System.Drawing.Size(200, 50);
            this.moneyPanel.TabIndex = 1;
            // 
            // moneyIconLabel
            // 
            this.moneyIconLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moneyIconLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.moneyIconLabel.Location = new System.Drawing.Point(10, 10);
            this.moneyIconLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.moneyIconLabel.Name = "moneyIconLabel";
            this.moneyIconLabel.Size = new System.Drawing.Size(38, 30);
            this.moneyIconLabel.TabIndex = 1;
            this.moneyIconLabel.Text = "💰";
            this.moneyIconLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // moneyLabel
            // 
            this.moneyLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moneyLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.moneyLabel.Location = new System.Drawing.Point(50, 10);
            this.moneyLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.moneyLabel.Name = "moneyLabel";
            this.moneyLabel.Size = new System.Drawing.Size(138, 30);
            this.moneyLabel.TabIndex = 0;
            this.moneyLabel.Text = "$100";
            this.moneyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sidePanel
            // 
            this.sidePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.sidePanel.Controls.Add(this.infoGroupBox);
            this.sidePanel.Controls.Add(this.toolsGroupBox);
            this.sidePanel.Controls.Add(this.seedGroupBox);
            this.sidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidePanel.Location = new System.Drawing.Point(0, 75);
            this.sidePanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Padding = new System.Windows.Forms.Padding(12, 12, 12, 12);
            this.sidePanel.Size = new System.Drawing.Size(325, 739);
            this.sidePanel.TabIndex = 1;
            // 
            // infoGroupBox
            // 
            this.infoGroupBox.Controls.Add(this.richInfo);
            this.infoGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infoGroupBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoGroupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.infoGroupBox.Location = new System.Drawing.Point(12, 350);
            this.infoGroupBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.infoGroupBox.Name = "infoGroupBox";
            this.infoGroupBox.Padding = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.infoGroupBox.Size = new System.Drawing.Size(301, 377);
            this.infoGroupBox.TabIndex = 2;
            this.infoGroupBox.TabStop = false;
            this.infoGroupBox.Text = "📊 Farm Information";
            // 
            // richInfo
            // 
            this.richInfo.BackColor = System.Drawing.Color.White;
            this.richInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.richInfo.Location = new System.Drawing.Point(10, 30);
            this.richInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.richInfo.Name = "richInfo";
            this.richInfo.ReadOnly = true;
            this.richInfo.Size = new System.Drawing.Size(281, 337);
            this.richInfo.TabIndex = 0;
            this.richInfo.Text = "Welcome to Mini Farm!\n\nSelect a tool and click on the farm grid to interact with " +
    "your crops.\n\n🌱 Plant seeds to start growing\n💧 Water plants to help them grow\n🌾" +
    " Harvest mature crops for money";
            // 
            // toolsGroupBox
            // 
            this.toolsGroupBox.Controls.Add(this.toolStatusPanel);
            this.toolsGroupBox.Controls.Add(this.harvestButton);
            this.toolsGroupBox.Controls.Add(this.waterButton);
            this.toolsGroupBox.Controls.Add(this.seedButton);
            this.toolsGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolsGroupBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolsGroupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.toolsGroupBox.Location = new System.Drawing.Point(12, 112);
            this.toolsGroupBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.toolsGroupBox.Name = "toolsGroupBox";
            this.toolsGroupBox.Padding = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.toolsGroupBox.Size = new System.Drawing.Size(301, 238);
            this.toolsGroupBox.TabIndex = 1;
            this.toolsGroupBox.TabStop = false;
            this.toolsGroupBox.Text = "🛠️ Farm Tools";
            // 
            // toolStatusPanel
            // 
            this.toolStatusPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.toolStatusPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStatusPanel.Controls.Add(this.toolStatusLabel);
            this.toolStatusPanel.Controls.Add(this.toolLabel);
            this.toolStatusPanel.Location = new System.Drawing.Point(19, 175);
            this.toolStatusPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.toolStatusPanel.Name = "toolStatusPanel";
            this.toolStatusPanel.Size = new System.Drawing.Size(262, 50);
            this.toolStatusPanel.TabIndex = 3;
            // 
            // toolStatusLabel
            // 
            this.toolStatusLabel.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStatusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.toolStatusLabel.Location = new System.Drawing.Point(6, 25);
            this.toolStatusLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.toolStatusLabel.Name = "toolStatusLabel";
            this.toolStatusLabel.Size = new System.Drawing.Size(250, 19);
            this.toolStatusLabel.TabIndex = 1;
            this.toolStatusLabel.Text = "Click a tool to select it";
            this.toolStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toolLabel
            // 
            this.toolLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.toolLabel.Location = new System.Drawing.Point(6, 4);
            this.toolLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.toolLabel.Name = "toolLabel";
            this.toolLabel.Size = new System.Drawing.Size(250, 25);
            this.toolLabel.TabIndex = 0;
            this.toolLabel.Text = "Selected: None";
            this.toolLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // harvestButton
            // 
            this.harvestButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.harvestButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.harvestButton.FlatAppearance.BorderSize = 0;
            this.harvestButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(137)))), ((int)(((byte)(0)))));
            this.harvestButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(167)))), ((int)(((byte)(38)))));
            this.harvestButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.harvestButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.harvestButton.ForeColor = System.Drawing.Color.White;
            this.harvestButton.Location = new System.Drawing.Point(19, 125);
            this.harvestButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.harvestButton.Name = "harvestButton";
            this.harvestButton.Size = new System.Drawing.Size(262, 44);
            this.harvestButton.TabIndex = 2;
            this.harvestButton.Text = "🌾 Harvest";
            this.harvestButton.UseVisualStyleBackColor = false;
            // 
            // waterButton
            // 
            this.waterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.waterButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.waterButton.FlatAppearance.BorderSize = 0;
            this.waterButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.waterButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(165)))), ((int)(((byte)(245)))));
            this.waterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.waterButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.waterButton.ForeColor = System.Drawing.Color.White;
            this.waterButton.Location = new System.Drawing.Point(19, 75);
            this.waterButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.waterButton.Name = "waterButton";
            this.waterButton.Size = new System.Drawing.Size(262, 44);
            this.waterButton.TabIndex = 1;
            this.waterButton.Text = "💧 Water";
            this.waterButton.UseVisualStyleBackColor = false;
            // 
            // seedButton
            // 
            this.seedButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.seedButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.seedButton.FlatAppearance.BorderSize = 0;
            this.seedButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(142)))), ((int)(((byte)(60)))));
            this.seedButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(187)))), ((int)(((byte)(106)))));
            this.seedButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.seedButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seedButton.ForeColor = System.Drawing.Color.White;
            this.seedButton.Location = new System.Drawing.Point(19, 25);
            this.seedButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.seedButton.Name = "seedButton";
            this.seedButton.Size = new System.Drawing.Size(262, 44);
            this.seedButton.TabIndex = 0;
            this.seedButton.Text = "🌱 Plant Seed";
            this.seedButton.UseVisualStyleBackColor = false;
            // 
            // seedGroupBox
            // 
            this.seedGroupBox.Controls.Add(this.seedSelector);
            this.seedGroupBox.Controls.Add(this.seedLabel);
            this.seedGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.seedGroupBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seedGroupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.seedGroupBox.Location = new System.Drawing.Point(12, 12);
            this.seedGroupBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.seedGroupBox.Name = "seedGroupBox";
            this.seedGroupBox.Padding = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.seedGroupBox.Size = new System.Drawing.Size(301, 100);
            this.seedGroupBox.TabIndex = 0;
            this.seedGroupBox.TabStop = false;
            this.seedGroupBox.Text = "🌰 Seed Selection";
            // 
            // seedSelector
            // 
            this.seedSelector.BackColor = System.Drawing.Color.White;
            this.seedSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.seedSelector.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seedSelector.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.seedSelector.FormattingEnabled = true;
            this.seedSelector.Location = new System.Drawing.Point(19, 56);
            this.seedSelector.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.seedSelector.Name = "seedSelector";
            this.seedSelector.Size = new System.Drawing.Size(262, 28);
            this.seedSelector.TabIndex = 1;
            // 
            // seedLabel
            // 
            this.seedLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seedLabel.Location = new System.Drawing.Point(19, 31);
            this.seedLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.seedLabel.Name = "seedLabel";
            this.seedLabel.Size = new System.Drawing.Size(262, 25);
            this.seedLabel.TabIndex = 0;
            this.seedLabel.Text = "Choose seed type:";
            // 
            // shadowPanel
            // 
            this.shadowPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.shadowPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.shadowPanel.Location = new System.Drawing.Point(325, 75);
            this.shadowPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.shadowPanel.Name = "shadowPanel";
            this.shadowPanel.Size = new System.Drawing.Size(2, 739);
            this.shadowPanel.TabIndex = 2;
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.mainPanel.Controls.Add(this.gridPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(327, 75);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Padding = new System.Windows.Forms.Padding(12, 12, 12, 12);
            this.mainPanel.Size = new System.Drawing.Size(978, 739);
            this.mainPanel.TabIndex = 3;
            // 
            // gridPanel
            // 
            this.gridPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(195)))), ((int)(((byte)(74)))));
            this.gridPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gridPanel.Cursor = System.Windows.Forms.Cursors.Cross;
            this.gridPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPanel.Location = new System.Drawing.Point(12, 12);
            this.gridPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridPanel.Name = "gridPanel";
            this.gridPanel.Size = new System.Drawing.Size(954, 715);
            this.gridPanel.TabIndex = 0;
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.progressBar});
            this.statusStrip.Location = new System.Drawing.Point(0, 814);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 18, 0);
            this.statusStrip.Size = new System.Drawing.Size(1305, 26);
            this.statusStrip.TabIndex = 4;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(50, 20);
            this.statusLabel.Text = "Ready";
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(125, 18);
            this.progressBar.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1305, 840);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.shadowPanel);
            this.Controls.Add(this.sidePanel);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.statusStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mini Farm - Farming Simulator";
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.moneyPanel.ResumeLayout(false);
            this.sidePanel.ResumeLayout(false);
            this.infoGroupBox.ResumeLayout(false);
            this.toolsGroupBox.ResumeLayout(false);
            this.toolStatusPanel.ResumeLayout(false);
            this.seedGroupBox.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Panel moneyPanel;
        private System.Windows.Forms.Label moneyIconLabel;
        private System.Windows.Forms.Label moneyLabel;
        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.GroupBox seedGroupBox;
        private System.Windows.Forms.ComboBox seedSelector;
        private System.Windows.Forms.Label seedLabel;
        private System.Windows.Forms.GroupBox toolsGroupBox;
        private System.Windows.Forms.Button harvestButton;
        private System.Windows.Forms.Button waterButton;
        private System.Windows.Forms.Button seedButton;
        private System.Windows.Forms.Panel toolStatusPanel;
        private System.Windows.Forms.Label toolStatusLabel;
        private System.Windows.Forms.Label toolLabel;
        private System.Windows.Forms.GroupBox infoGroupBox;
        private System.Windows.Forms.RichTextBox richInfo;
        private System.Windows.Forms.Panel shadowPanel;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel gridPanel;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
    }
}