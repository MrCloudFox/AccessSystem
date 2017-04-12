using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccessSystem
{
    class ListOfAccessToKeys : Form
    {
        public ListOfAccessToKeys()
        {

            this.Size = new Size(800, 700);
            ListView listOfAccessToKeys = new ListView();
            listOfAccessToKeys.Bounds = new Rectangle(new Point(10, 10), new Size(500, 650));

            listOfAccessToKeys.View = View.Details;
            listOfAccessToKeys.LabelEdit = true;
            listOfAccessToKeys.AllowColumnReorder = true;
            listOfAccessToKeys.FullRowSelect = true;
            listOfAccessToKeys.GridLines = true;
            listOfAccessToKeys.Sorting = SortOrder.Ascending;


            listOfAccessToKeys.Columns.Add("KeyID", -2, HorizontalAlignment.Left);
            listOfAccessToKeys.Columns.Add("Purpose", -2, HorizontalAlignment.Left);
            listOfAccessToKeys.Columns.Add("IDofTeacherCard", -2, HorizontalAlignment.Left);


            Controls.Add(listOfAccessToKeys);

            string[] csvRooms = File.ReadAllLines("AccessKeysOfRooms.csv");

            for (int i = 0; i < csvRooms.Count(); i++)
            {
                ListViewItem recordOfRoom = new ListViewItem(csvRooms[i].Split(';')[0]);
                recordOfRoom.SubItems.Add("Room number of " + csvRooms[i].Split(';')[1]);
                recordOfRoom.SubItems.Add(csvRooms[i].Split(';')[2]);
                listOfAccessToKeys.Items.Add(recordOfRoom);
            }


            string[] csvEquipment = File.ReadAllLines("AccessKeysOfEquipment.csv");

            for (int i = 0; i < csvEquipment.Count(); i++)
            {
                ListViewItem recordOfEquipment = new ListViewItem(csvEquipment[i].Split(';')[0]);
                recordOfEquipment.SubItems.Add("Equipment number of " + csvEquipment[i].Split(';')[1]);
                recordOfEquipment.SubItems.Add(csvEquipment[i].Split(';')[2]);
                listOfAccessToKeys.Items.Add(recordOfEquipment);
            }


            string[] csvBoxes = File.ReadAllLines("AccessKeysOfBoxes.csv");

            for (int i = 0; i < csvBoxes.Count(); i++)
            {
                ListViewItem recordOfBox = new ListViewItem(csvBoxes[i].Split(';')[0]);
                recordOfBox.SubItems.Add("Box number of " + csvBoxes[i].Split(';')[1]);
                recordOfBox.SubItems.Add(csvBoxes[i].Split(';')[2]);
                listOfAccessToKeys.Items.Add(recordOfBox);
            }

            var FindBox = new TextBox();
            FindBox.Location = new Point(listOfAccessToKeys.Right + 15, 20);
            FindBox.Size = new Size(250, 30);
            Controls.Add(FindBox);

            var FindButton = new Button
            {
                Location = new Point(listOfAccessToKeys.Right + 15, 50),
                Size = new Size(250, 100),
                Text = "Press to find key."
            };
            Controls.Add(FindButton);


            FindButton.Click += (sender, args) =>
            {

                ListViewItem finder = listOfAccessToKeys.FindItemWithText(FindBox.Text);
                if (finder != null && FindBox.Text != "")
                {
                    MessageBox.Show(finder.SubItems[1].Text + " for teacher with card " + finder.SubItems[2].Text);
                }
                else
                {
                    MessageBox.Show("Not found.");
                }

            };

            var BackButton = new Button
            {
                Location = new Point(listOfAccessToKeys.Right + 15, FindButton.Bottom + 100),
                Size = new Size(250, 100),
                Text = "Back."
            };
            Controls.Add(BackButton);


            BackButton.Click += (sender, args) =>
            {
                this.Close();
            };


            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
        }
    }
}