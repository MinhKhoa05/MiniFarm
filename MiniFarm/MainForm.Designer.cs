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
            this.toolPanel = new System.Windows.Forms.Panel();
            this.shadowPanel = new System.Windows.Forms.Panel();
            this.gridPanel = new System.Windows.Forms.Panel();
            this.harvestButton = new System.Windows.Forms.Button();
            this.waterButton = new System.Windows.Forms.Button();
            this.seedButton = new System.Windows.Forms.Button();
            this.toolLabel = new System.Windows.Forms.Label();
            this.seedSelector = new System.Windows.Forms.ComboBox();
            this.seedLabel = new System.Windows.Forms.Label();
            this.moneyLabel = new System.Windows.Forms.Label();
            this.richInfo = new System.Windows.Forms.RichTextBox();
            this.toolPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolPanel
            // 
            this.toolPanel.Controls.Add(this.richInfo);
            this.toolPanel.Controls.Add(this.harvestButton);
            this.toolPanel.Controls.Add(this.waterButton);
            this.toolPanel.Controls.Add(this.seedButton);
            this.toolPanel.Controls.Add(this.toolLabel);
            this.toolPanel.Controls.Add(this.seedSelector);
            this.toolPanel.Controls.Add(this.seedLabel);
            this.toolPanel.Controls.Add(this.moneyLabel);
            this.toolPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolPanel.Location = new System.Drawing.Point(0, 0);
            this.toolPanel.Name = "toolPanel";
            this.toolPanel.Size = new System.Drawing.Size(200, 661);
            this.toolPanel.TabIndex = 0;
            // 
            // shadowPanel
            // 
            this.shadowPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.shadowPanel.Location = new System.Drawing.Point(200, 0);
            this.shadowPanel.Name = "shadowPanel";
            this.shadowPanel.Size = new System.Drawing.Size(10, 661);
            this.shadowPanel.TabIndex = 1;
            // 
            // gridPanel
            // 
            this.gridPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPanel.Location = new System.Drawing.Point(210, 0);
            this.gridPanel.Name = "gridPanel";
            this.gridPanel.Size = new System.Drawing.Size(774, 661);
            this.gridPanel.TabIndex = 2;
            // 
            // harvestButton
            // 
            this.harvestButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(173)))), ((int)(((byte)(78)))));
            this.harvestButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.harvestButton.FlatAppearance.BorderSize = 0;
            this.harvestButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.harvestButton.ForeColor = System.Drawing.Color.White;
            this.harvestButton.Location = new System.Drawing.Point(12, 184);
            this.harvestButton.Name = "harvestButton";
            this.harvestButton.Size = new System.Drawing.Size(180, 35);
            this.harvestButton.TabIndex = 14;
            this.harvestButton.Text = "Harvest";
            this.harvestButton.UseVisualStyleBackColor = false;
            // 
            // waterButton
            // 
            this.waterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(192)))), ((int)(((byte)(222)))));
            this.waterButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.waterButton.FlatAppearance.BorderSize = 0;
            this.waterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.waterButton.ForeColor = System.Drawing.Color.White;
            this.waterButton.Location = new System.Drawing.Point(12, 144);
            this.waterButton.Name = "waterButton";
            this.waterButton.Size = new System.Drawing.Size(180, 35);
            this.waterButton.TabIndex = 13;
            this.waterButton.Text = "Water";
            this.waterButton.UseVisualStyleBackColor = false;
            // 
            // seedButton
            // 
            this.seedButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(184)))), ((int)(((byte)(92)))));
            this.seedButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.seedButton.FlatAppearance.BorderSize = 0;
            this.seedButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.seedButton.ForeColor = System.Drawing.Color.White;
            this.seedButton.Location = new System.Drawing.Point(12, 104);
            this.seedButton.Name = "seedButton";
            this.seedButton.Size = new System.Drawing.Size(180, 35);
            this.seedButton.TabIndex = 12;
            this.seedButton.Text = "Plant Seed";
            this.seedButton.UseVisualStyleBackColor = false;
            // 
            // toolLabel
            // 
            this.toolLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.toolLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.toolLabel.Location = new System.Drawing.Point(12, 234);
            this.toolLabel.Name = "toolLabel";
            this.toolLabel.Size = new System.Drawing.Size(180, 40);
            this.toolLabel.TabIndex = 11;
            this.toolLabel.Text = "Tool: none";
            this.toolLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // seedSelector
            // 
            this.seedSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.seedSelector.FormattingEnabled = true;
            this.seedSelector.Location = new System.Drawing.Point(12, 69);
            this.seedSelector.Name = "seedSelector";
            this.seedSelector.Size = new System.Drawing.Size(180, 29);
            this.seedSelector.TabIndex = 10;
            // 
            // seedLabel
            // 
            this.seedLabel.Location = new System.Drawing.Point(12, 44);
            this.seedLabel.Name = "seedLabel";
            this.seedLabel.Size = new System.Drawing.Size(180, 20);
            this.seedLabel.TabIndex = 9;
            this.seedLabel.Text = "Select seed:";
            // 
            // moneyLabel
            // 
            this.moneyLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moneyLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.moneyLabel.Location = new System.Drawing.Point(12, 9);
            this.moneyLabel.Name = "moneyLabel";
            this.moneyLabel.Size = new System.Drawing.Size(180, 25);
            this.moneyLabel.TabIndex = 8;
            this.moneyLabel.Text = "Money: 100$";
            this.moneyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // richInfo
            // 
            this.richInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.richInfo.Enabled = false;
            this.richInfo.Location = new System.Drawing.Point(0, 291);
            this.richInfo.Name = "richInfo";
            this.richInfo.Size = new System.Drawing.Size(200, 370);
            this.richInfo.TabIndex = 0;
            this.richInfo.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.gridPanel);
            this.Controls.Add(this.shadowPanel);
            this.Controls.Add(this.toolPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mini Farm";
            this.toolPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel toolPanel;
        private System.Windows.Forms.Panel shadowPanel;
        private System.Windows.Forms.Panel gridPanel;
        private System.Windows.Forms.Button harvestButton;
        private System.Windows.Forms.Button waterButton;
        private System.Windows.Forms.Button seedButton;
        private System.Windows.Forms.Label toolLabel;
        private System.Windows.Forms.ComboBox seedSelector;
        private System.Windows.Forms.Label seedLabel;
        private System.Windows.Forms.Label moneyLabel;
        private System.Windows.Forms.RichTextBox richInfo;
    }
}