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
    class WatchMan : Form
    {
        
        public WatchMan()
        {
            this.Size = new Size(800, 700);
            ListView listOfAccess = new ListView();
            listOfAccess.Bounds = new Rectangle(new Point(10, 10), new Size(500, 650));

            listOfAccess.View = View.Details;
            listOfAccess.LabelEdit = true;
            listOfAccess.AllowColumnReorder = true;
            listOfAccess.FullRowSelect = true;
            listOfAccess.GridLines = true;
            listOfAccess.Sorting = SortOrder.Ascending;


            listOfAccess.Columns.Add("CardID", -2, HorizontalAlignment.Left);
            listOfAccess.Columns.Add("Name", -2, HorizontalAlignment.Left);
            listOfAccess.Columns.Add("IsStudent", -2, HorizontalAlignment.Left);


            Controls.Add(listOfAccess);

            string[] csvStudents = File.ReadAllLines("Students.csv");

            for (int i = 0; i < csvStudents.Count(); i++)
            {
                ListViewItem recordOfStudent = new ListViewItem(csvStudents[i].Split(';')[3]);
                recordOfStudent.SubItems.Add(csvStudents[i].Split(';')[0]);
                recordOfStudent.SubItems.Add("Student");
                listOfAccess.Items.Add(recordOfStudent);
                    
            }

            string[] csvTeachers = File.ReadAllLines("Teachers.csv");

            for (int i = 0; i < csvTeachers.Count(); i++)
            {
                ListViewItem recordOfTeacher = new ListViewItem(csvTeachers[i].Split(';')[2]);
                recordOfTeacher.SubItems.Add(csvTeachers[i].Split(';')[0]);
                recordOfTeacher.SubItems.Add("Teacher");
                listOfAccess.Items.Add(recordOfTeacher);

            }

            var FindBox = new TextBox();
            FindBox.Location = new Point(listOfAccess.Right + 15, 20);
            FindBox.Size = new Size(250, 30);
            Controls.Add(FindBox);


            var FindButton = new Button
            {
                Location = new Point(listOfAccess.Right + 15, 50),
                Size = new Size(250, 100),
                Text = "Press to find."
            };
            Controls.Add(FindButton);

            FindButton.Click += (sender, args) =>
            {
                
                ListViewItem finder = listOfAccess.FindItemWithText(FindBox.Text);
                if (finder != null && FindBox.Text != "")
                {
                    MessageBox.Show(finder.SubItems[2].Text + " " + finder.SubItems[1].Text);
                }
                else
                {
                    MessageBox.Show("Not found.");
                }

            };


            var TempCardBox = new TextBox();
            TempCardBox.Location = new Point(listOfAccess.Right + 15, 280);
            TempCardBox.Size = new Size(250, 30);
            Controls.Add(TempCardBox);


            var TempCardsButton = new Button
            {
                Location = new Point(listOfAccess.Right + 15, TempCardBox.Bottom + 15),
                Size = new Size(250, 100),
                Text = "Enter to temp cards."
            };
            Controls.Add(TempCardsButton);


            TempCardsButton.Click += (sender, args) =>
            {
                string[] csvTempCards = File.ReadAllLines("TempCards.csv");
                bool TempIsFind = false;
                for (int i = 0; i < csvTempCards.Count(); i++)
                {
                    if (csvTempCards[i].Split(';')[0] == TempCardBox.Text)
                    {
                        MessageBox.Show("Old pass card ID is " + csvTempCards[i].Split(';')[2]);
                        TempIsFind = true;
                        break;
                    }
                }
                if (!TempIsFind) MessageBox.Show("Card not found.");

            };


            var AccessKeysButton = new Button
            {
                Location = new Point(listOfAccess.Right + 15, TempCardsButton.Bottom + 15),
                Size = new Size(250, 100),
                Text = "Access of keys list."
            };
            Controls.Add(AccessKeysButton);



            AccessKeysButton.Click += (sender, args) =>
            {
                var listOfAccessToKeys = new ListOfAccessToKeys();
                listOfAccessToKeys.Show();
            };


            var HistoryButton = new Button
            {
                Location = new Point(listOfAccess.Right + 15, AccessKeysButton.Bottom + 15),
                Size = new Size(250, 100),
                Text = "History of giving."
            };
            Controls.Add(HistoryButton);


            HistoryButton.Click += (sender, args) =>
            {
                var historyOfGiving = new HistoryOfGiving();
                historyOfGiving.Show();
            };

            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
        }


    }
}
