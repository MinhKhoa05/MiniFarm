namespace MiniFarm
{
    partial class ToolPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.moneyLabel = new System.Windows.Forms.Label();
            this.seedLabel = new System.Windows.Forms.Label();
            this.seedSelector = new System.Windows.Forms.ComboBox();
            this.toolLabel = new System.Windows.Forms.Label();
            this.seedButton = new System.Windows.Forms.Button();
            this.waterButton = new System.Windows.Forms.Button();
            this.harvestButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // moneyLabel
            // 
            this.moneyLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moneyLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.moneyLabel.Location = new System.Drawing.Point(10, 15);
            this.moneyLabel.Name = "moneyLabel";
            this.moneyLabel.Size = new System.Drawing.Size(180, 25);
            this.moneyLabel.TabIndex = 0;
            this.moneyLabel.Text = "Money: 100$";
            this.moneyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // seedLabel
            // 
            this.seedLabel.Location = new System.Drawing.Point(10, 50);
            this.seedLabel.Name = "seedLabel";
            this.seedLabel.Size = new System.Drawing.Size(180, 20);
            this.seedLabel.TabIndex = 1;
            this.seedLabel.Text = "Select seed:";
            // 
            // seedSelector
            // 
            this.seedSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.seedSelector.FormattingEnabled = true;
            this.seedSelector.Location = new System.Drawing.Point(10, 75);
            this.seedSelector.Name = "seedSelector";
            this.seedSelector.Size = new System.Drawing.Size(180, 23);
            this.seedSelector.TabIndex = 2;
            // 
            // toolLabel
            // 
            this.toolLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.toolLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.toolLabel.Location = new System.Drawing.Point(10, 240);
            this.toolLabel.Name = "toolLabel";
            this.toolLabel.Size = new System.Drawing.Size(180, 40);
            this.toolLabel.TabIndex = 3;
            this.toolLabel.Text = "Tool: none";
            this.toolLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // seedButton
            // 
            this.seedButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(184)))), ((int)(((byte)(92)))));
            this.seedButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.seedButton.FlatAppearance.BorderSize = 0;
            this.seedButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.seedButton.ForeColor = System.Drawing.Color.White;
            this.seedButton.Location = new System.Drawing.Point(10, 110);
            this.seedButton.Name = "seedButton";
            this.seedButton.Size = new System.Drawing.Size(180, 35);
            this.seedButton.TabIndex = 5;
            this.seedButton.Text = "Plant Seed";
            this.seedButton.UseVisualStyleBackColor = false;
            // 
            // waterButton
            // 
            this.waterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(192)))), ((int)(((byte)(222)))));
            this.waterButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.waterButton.FlatAppearance.BorderSize = 0;
            this.waterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.waterButton.ForeColor = System.Drawing.Color.White;
            this.waterButton.Location = new System.Drawing.Point(10, 150);
            this.waterButton.Name = "waterButton";
            this.waterButton.Size = new System.Drawing.Size(180, 35);
            this.waterButton.TabIndex = 6;
            this.waterButton.Text = "Water";
            this.waterButton.UseVisualStyleBackColor = false;
            // 
            // harvestButton
            // 
            this.harvestButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(173)))), ((int)(((byte)(78)))));
            this.harvestButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.harvestButton.FlatAppearance.BorderSize = 0;
            this.harvestButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.harvestButton.ForeColor = System.Drawing.Color.White;
            this.harvestButton.Location = new System.Drawing.Point(10, 190);
            this.harvestButton.Name = "harvestButton";
            this.harvestButton.Size = new System.Drawing.Size(180, 35);
            this.harvestButton.TabIndex = 7;
            this.harvestButton.Text = "Harvest";
            this.harvestButton.UseVisualStyleBackColor = false;
            // 
            // ToolPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.harvestButton);
            this.Controls.Add(this.waterButton);
            this.Controls.Add(this.seedButton);
            this.Controls.Add(this.toolLabel);
            this.Controls.Add(this.seedSelector);
            this.Controls.Add(this.seedLabel);
            this.Controls.Add(this.moneyLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ToolPanel";
            this.Size = new System.Drawing.Size(200, 700);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label moneyLabel;
        private System.Windows.Forms.Label seedLabel;
        private System.Windows.Forms.ComboBox seedSelector;
        private System.Windows.Forms.Label toolLabel;
        private System.Windows.Forms.Button seedButton;
        private System.Windows.Forms.Button waterButton;
        private System.Windows.Forms.Button harvestButton;
    }
}
