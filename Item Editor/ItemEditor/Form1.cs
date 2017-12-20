using Assets.Scripts.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ItemEditor
{
    public partial class Form1 : Form
    {
        public Dictionary<string, string> selectedSprites = new Dictionary<string, string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void weGenIdBtn_Click(object sender, EventArgs e)
        {
            weItemIdTxt.Text = Guid.NewGuid().ToString();
        }

        private void weExportBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please select the game root folder...");
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult res = fbd.ShowDialog();

            if (res == DialogResult.OK && weItemIdTxt.Text != "")
            {
                if (File.Exists(fbd.SelectedPath + "/WorldEntities/" + weItemIdTxt.Text + ".json"))
                {
                    MessageBox.Show("Duplicate Item ID, did NOT export!");
                    return;
                }
                else if (Directory.Exists(fbd.SelectedPath + "/Sprites/" + weItemIdTxt.Text))
                {
                    MessageBox.Show("Duplicate Item ID? Sprites folder for item ID already exists, did NOT export!");
                    return;
                }

                if (!Directory.Exists(fbd.SelectedPath + "/WorldEntities/"))
                    Directory.CreateDirectory(fbd.SelectedPath + "/WorldEntities/");

                if (!Directory.Exists(fbd.SelectedPath + "/Sprites/"))
                    Directory.CreateDirectory(fbd.SelectedPath + "/Sprites/");

                //Let's create sprites folder for this item
                Directory.CreateDirectory(fbd.SelectedPath + "/Sprites/" + weItemIdTxt.Text);

                //Let's export class to json
                if (itemTypeSelector.Text == "WorldEntity")
                {
                    WorldEntity we = new WorldEntity();

                    we.itemId = weItemIdTxt.Text;
                    we.value = double.Parse(weItemValueNud.Value.ToString());
                    we.configPath = "/WorldEntities/" + weItemIdTxt.Text + ".json";
                    we.isPickupable = weIsPickupableChk.Checked;
                    we.instanceId = null;
                    we.inventorySprite = "/Sprites/" + weItemIdTxt.Text + "/inventory.png";
                    we.owner = weDefaultOwner.Text;
                    we.itemName = weItemNameTxt.Text;
                    we.rarity = (EntityRarity)Enum.Parse(typeof(EntityRarity), weItemRarityCombo.Text);

                    //Copy all sprites from list to file
                    foreach (KeyValuePair<string, string> s in selectedSprites)
                    {
                        File.Copy(s.Key, fbd.SelectedPath + "/Sprites/" + weItemIdTxt.Text + "/" + s.Value + ".png");
                        we.entitySprites.Add("/Sprites/" + s.Value + ".png");
                    }

                    //Serialize json to file
                    string json = JsonConvert.SerializeObject(we, Formatting.Indented);
                    File.WriteAllText(fbd.SelectedPath + "/WorldEntities/" + weItemIdTxt.Text + ".json", json);

                    //Copy inventory png to sprites folder
                    File.Copy(weInventorySpritePreview.ImageLocation, fbd.SelectedPath + "/Sprites/" + weItemIdTxt.Text + "/inventory.png");

                    MessageBox.Show("Exported to '" + fbd.SelectedPath + "'");
                    return;
                }
                else
                    throw new NotImplementedException();
            }
            else
                MessageBox.Show("Did NOT export!");
        }

        private void weAddSpriteBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();

            fileDialog.Multiselect = false;
            fileDialog.Filter = "PNG Files|*.png";

            DialogResult res = fileDialog.ShowDialog();

            if (res == DialogResult.OK)
            {
                try
                {
                    Image.FromFile(fileDialog.FileName);
                    selectedSprites.Add(fileDialog.FileName, fileDialog.SafeFileName);
                    LoadPreviewList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("File doesn't seem to be an image! Did NOT add sprite!");
                }
            }
        }

        public void LoadPreviewList()
        {
            weSpritePreview.Controls.Clear();

            int h = 0;
            foreach (KeyValuePair<string,string> s in selectedSprites)
            {
                Image img = Image.FromFile(s.Key);
                PictureBox pb = new PictureBox();

                pb.Size = new Size(96, 96);
                pb.Location = new Point(0, h);
                pb.Image = img;
                pb.SizeMode = PictureBoxSizeMode.StretchImage;

                TextBox nameText = new TextBox();

                nameText.Text = s.Value;
                nameText.Location = new Point(96, h+1);
                nameText.Size = new Size(96*2, 8);
                nameText.TextChanged += delegate {
                    selectedSprites[s.Key] = nameText.Text;
                };

                Button remBtn = new Button();

                remBtn.Text = "Remove";
                remBtn.Location = new Point(96 + (96 * 2), h);

                remBtn.Click += delegate {
                    selectedSprites.Remove(s.Key);
                    LoadPreviewList();
                };

                weSpritePreview.Controls.Add(pb);
                weSpritePreview.Controls.Add(remBtn);
                weSpritePreview.Controls.Add(nameText);

                h += 96;
            }
        }

        private void RemBtn_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void weAddInventorySpriteBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();

            fileDialog.Multiselect = false;
            fileDialog.Filter = "PNG Files|*.png";

            DialogResult res = fileDialog.ShowDialog();

            if (res == DialogResult.OK)
            {
                try
                {
                    weInventorySpritePreview.SizeMode = PictureBoxSizeMode.StretchImage;
                    weInventorySpritePreview.Image = Image.FromFile(fileDialog.FileName);
                    weInventorySpritePreview.ImageLocation = fileDialog.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("File doesn't seem to be an image! Did NOT add sprite!");
                }
            }
        }

        private void weClearInventorySprite_Click(object sender, EventArgs e)
        {
            weInventorySpritePreview.Image = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please select the game root folder...");
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult res = fbd.ShowDialog();

            if (res == DialogResult.OK)
            {
                if (!Directory.Exists(fbd.SelectedPath + "/WorldEntities/"))
                    Directory.CreateDirectory(fbd.SelectedPath + "/WorldEntities/");

                if (!Directory.Exists(fbd.SelectedPath + "/Sprites/"))
                    Directory.CreateDirectory(fbd.SelectedPath + "/Sprites/");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            weItemRarityCombo.DataSource = Enum.GetValues(typeof(EntityRarity));
        }
    }
}
