namespace ItemEditor
{
    partial class Form1
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
            this.itemTypeSelector = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.worldEntityPanel = new System.Windows.Forms.Panel();
            this.weItemNameTxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.weDefaultOwner = new System.Windows.Forms.ComboBox();
            this.weIsPickupableChk = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.weInventorySpritePreview = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.weClearInventorySprite = new System.Windows.Forms.Button();
            this.weAddInventorySpriteBtn = new System.Windows.Forms.Button();
            this.weAddSpriteBtn = new System.Windows.Forms.Button();
            this.weSpritePreview = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.weItemValueNud = new System.Windows.Forms.NumericUpDown();
            this.weItemNameLabel = new System.Windows.Forms.Label();
            this.weItemIdLabel = new System.Windows.Forms.Label();
            this.weGenIdBtn = new System.Windows.Forms.Button();
            this.weItemIdTxt = new System.Windows.Forms.TextBox();
            this.weExportBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.weItemRarityCombo = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.worldEntityPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.weInventorySpritePreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weItemValueNud)).BeginInit();
            this.SuspendLayout();
            // 
            // itemTypeSelector
            // 
            this.itemTypeSelector.Enabled = false;
            this.itemTypeSelector.FormattingEnabled = true;
            this.itemTypeSelector.Items.AddRange(new object[] {
            "WorldEntity",
            "WeaponEntity",
            "PotionEntity"});
            this.itemTypeSelector.Location = new System.Drawing.Point(84, 6);
            this.itemTypeSelector.Name = "itemTypeSelector";
            this.itemTypeSelector.Size = new System.Drawing.Size(234, 21);
            this.itemTypeSelector.TabIndex = 0;
            this.itemTypeSelector.Text = "WorldEntity";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Editor mode:";
            // 
            // worldEntityPanel
            // 
            this.worldEntityPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.worldEntityPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.worldEntityPanel.Controls.Add(this.label23);
            this.worldEntityPanel.Controls.Add(this.weItemRarityCombo);
            this.worldEntityPanel.Controls.Add(this.weItemNameTxt);
            this.worldEntityPanel.Controls.Add(this.label5);
            this.worldEntityPanel.Controls.Add(this.weDefaultOwner);
            this.worldEntityPanel.Controls.Add(this.weIsPickupableChk);
            this.worldEntityPanel.Controls.Add(this.label4);
            this.worldEntityPanel.Controls.Add(this.weInventorySpritePreview);
            this.worldEntityPanel.Controls.Add(this.label3);
            this.worldEntityPanel.Controls.Add(this.weClearInventorySprite);
            this.worldEntityPanel.Controls.Add(this.weAddInventorySpriteBtn);
            this.worldEntityPanel.Controls.Add(this.weAddSpriteBtn);
            this.worldEntityPanel.Controls.Add(this.weSpritePreview);
            this.worldEntityPanel.Controls.Add(this.label2);
            this.worldEntityPanel.Controls.Add(this.weItemValueNud);
            this.worldEntityPanel.Controls.Add(this.weItemNameLabel);
            this.worldEntityPanel.Controls.Add(this.weItemIdLabel);
            this.worldEntityPanel.Controls.Add(this.weGenIdBtn);
            this.worldEntityPanel.Controls.Add(this.weItemIdTxt);
            this.worldEntityPanel.Controls.Add(this.weExportBtn);
            this.worldEntityPanel.Location = new System.Drawing.Point(15, 33);
            this.worldEntityPanel.Name = "worldEntityPanel";
            this.worldEntityPanel.Size = new System.Drawing.Size(901, 495);
            this.worldEntityPanel.TabIndex = 7;
            // 
            // weItemNameTxt
            // 
            this.weItemNameTxt.Location = new System.Drawing.Point(68, 38);
            this.weItemNameTxt.Name = "weItemNameTxt";
            this.weItemNameTxt.Size = new System.Drawing.Size(357, 20);
            this.weItemNameTxt.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Default owner:";
            // 
            // weDefaultOwner
            // 
            this.weDefaultOwner.FormattingEnabled = true;
            this.weDefaultOwner.Items.AddRange(new object[] {
            "world"});
            this.weDefaultOwner.Location = new System.Drawing.Point(86, 90);
            this.weDefaultOwner.Name = "weDefaultOwner";
            this.weDefaultOwner.Size = new System.Drawing.Size(339, 21);
            this.weDefaultOwner.TabIndex = 12;
            this.weDefaultOwner.Text = "world";
            // 
            // weIsPickupableChk
            // 
            this.weIsPickupableChk.AutoSize = true;
            this.weIsPickupableChk.Location = new System.Drawing.Point(7, 144);
            this.weIsPickupableChk.Name = "weIsPickupableChk";
            this.weIsPickupableChk.Size = new System.Drawing.Size(87, 17);
            this.weIsPickupableChk.TabIndex = 11;
            this.weIsPickupableChk.Text = "IsPickupable";
            this.weIsPickupableChk.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(446, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Inventory sprite:";
            // 
            // weInventorySpritePreview
            // 
            this.weInventorySpritePreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.weInventorySpritePreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.weInventorySpritePreview.Location = new System.Drawing.Point(792, 10);
            this.weInventorySpritePreview.Name = "weInventorySpritePreview";
            this.weInventorySpritePreview.Size = new System.Drawing.Size(96, 96);
            this.weInventorySpritePreview.TabIndex = 9;
            this.weInventorySpritePreview.TabStop = false;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(466, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Sprites";
            // 
            // weClearInventorySprite
            // 
            this.weClearInventorySprite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.weClearInventorySprite.Location = new System.Drawing.Point(711, 35);
            this.weClearInventorySprite.Name = "weClearInventorySprite";
            this.weClearInventorySprite.Size = new System.Drawing.Size(75, 23);
            this.weClearInventorySprite.TabIndex = 7;
            this.weClearInventorySprite.Text = "Clear";
            this.weClearInventorySprite.UseVisualStyleBackColor = true;
            this.weClearInventorySprite.Click += new System.EventHandler(this.weClearInventorySprite_Click);
            // 
            // weAddInventorySpriteBtn
            // 
            this.weAddInventorySpriteBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.weAddInventorySpriteBtn.Location = new System.Drawing.Point(711, 10);
            this.weAddInventorySpriteBtn.Name = "weAddInventorySpriteBtn";
            this.weAddInventorySpriteBtn.Size = new System.Drawing.Size(75, 23);
            this.weAddInventorySpriteBtn.TabIndex = 7;
            this.weAddInventorySpriteBtn.Text = "Add sprite";
            this.weAddInventorySpriteBtn.UseVisualStyleBackColor = true;
            this.weAddInventorySpriteBtn.Click += new System.EventHandler(this.weAddInventorySpriteBtn_Click);
            // 
            // weAddSpriteBtn
            // 
            this.weAddSpriteBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.weAddSpriteBtn.Location = new System.Drawing.Point(813, 112);
            this.weAddSpriteBtn.Name = "weAddSpriteBtn";
            this.weAddSpriteBtn.Size = new System.Drawing.Size(75, 20);
            this.weAddSpriteBtn.TabIndex = 7;
            this.weAddSpriteBtn.Text = "Add sprite";
            this.weAddSpriteBtn.UseVisualStyleBackColor = true;
            this.weAddSpriteBtn.Click += new System.EventHandler(this.weAddSpriteBtn_Click);
            // 
            // weSpritePreview
            // 
            this.weSpritePreview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.weSpritePreview.AutoScroll = true;
            this.weSpritePreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.weSpritePreview.Location = new System.Drawing.Point(469, 134);
            this.weSpritePreview.Name = "weSpritePreview";
            this.weSpritePreview.Size = new System.Drawing.Size(419, 324);
            this.weSpritePreview.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Item value:";
            // 
            // weItemValueNud
            // 
            this.weItemValueNud.DecimalPlaces = 2;
            this.weItemValueNud.Location = new System.Drawing.Point(68, 64);
            this.weItemValueNud.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.weItemValueNud.Name = "weItemValueNud";
            this.weItemValueNud.Size = new System.Drawing.Size(357, 20);
            this.weItemValueNud.TabIndex = 4;
            // 
            // weItemNameLabel
            // 
            this.weItemNameLabel.AutoSize = true;
            this.weItemNameLabel.Location = new System.Drawing.Point(4, 41);
            this.weItemNameLabel.Name = "weItemNameLabel";
            this.weItemNameLabel.Size = new System.Drawing.Size(59, 13);
            this.weItemNameLabel.TabIndex = 3;
            this.weItemNameLabel.Text = "Item name:";
            // 
            // weItemIdLabel
            // 
            this.weItemIdLabel.AutoSize = true;
            this.weItemIdLabel.Location = new System.Drawing.Point(4, 15);
            this.weItemIdLabel.Name = "weItemIdLabel";
            this.weItemIdLabel.Size = new System.Drawing.Size(44, 13);
            this.weItemIdLabel.TabIndex = 3;
            this.weItemIdLabel.Text = "Item ID:";
            // 
            // weGenIdBtn
            // 
            this.weGenIdBtn.Location = new System.Drawing.Point(350, 12);
            this.weGenIdBtn.Name = "weGenIdBtn";
            this.weGenIdBtn.Size = new System.Drawing.Size(75, 20);
            this.weGenIdBtn.TabIndex = 2;
            this.weGenIdBtn.Text = "Generate";
            this.weGenIdBtn.UseVisualStyleBackColor = true;
            this.weGenIdBtn.Click += new System.EventHandler(this.weGenIdBtn_Click);
            // 
            // weItemIdTxt
            // 
            this.weItemIdTxt.Location = new System.Drawing.Point(68, 12);
            this.weItemIdTxt.Name = "weItemIdTxt";
            this.weItemIdTxt.ReadOnly = true;
            this.weItemIdTxt.Size = new System.Drawing.Size(276, 20);
            this.weItemIdTxt.TabIndex = 1;
            // 
            // weExportBtn
            // 
            this.weExportBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.weExportBtn.Location = new System.Drawing.Point(774, 464);
            this.weExportBtn.Name = "weExportBtn";
            this.weExportBtn.Size = new System.Drawing.Size(114, 23);
            this.weExportBtn.TabIndex = 0;
            this.weExportBtn.Text = "Export";
            this.weExportBtn.UseVisualStyleBackColor = true;
            this.weExportBtn.Click += new System.EventHandler(this.weExportBtn_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(739, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(177, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Generate dummy game folder";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // weItemRarityCombo
            // 
            this.weItemRarityCombo.FormattingEnabled = true;
            this.weItemRarityCombo.Location = new System.Drawing.Point(86, 117);
            this.weItemRarityCombo.Name = "weItemRarityCombo";
            this.weItemRarityCombo.Size = new System.Drawing.Size(339, 21);
            this.weItemRarityCombo.TabIndex = 15;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(4, 120);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(55, 13);
            this.label23.TabIndex = 16;
            this.label23.Text = "Item rarity:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 540);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.worldEntityPanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.itemTypeSelector);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.worldEntityPanel.ResumeLayout(false);
            this.worldEntityPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.weInventorySpritePreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weItemValueNud)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox itemTypeSelector;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel worldEntityPanel;
        private System.Windows.Forms.Button weExportBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown weItemValueNud;
        private System.Windows.Forms.Label weItemIdLabel;
        private System.Windows.Forms.Button weGenIdBtn;
        private System.Windows.Forms.TextBox weItemIdTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox weInventorySpritePreview;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button weAddInventorySpriteBtn;
        private System.Windows.Forms.Button weAddSpriteBtn;
        private System.Windows.Forms.Panel weSpritePreview;
        private System.Windows.Forms.Button weClearInventorySprite;
        private System.Windows.Forms.CheckBox weIsPickupableChk;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox weDefaultOwner;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox weItemNameTxt;
        private System.Windows.Forms.Label weItemNameLabel;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox weItemRarityCombo;
    }
}

