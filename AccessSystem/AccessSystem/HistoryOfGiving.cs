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
    class HistoryOfGiving : Form
    {
        public HistoryOfGiving()
        {
            this.Size = new Size(800, 700);
            ListView listOfHistory = new ListView();
            listOfHistory.Bounds = new Rectangle(new Point(10, 10), new Size(500, 650));

            listOfHistory.View = View.Details;
            listOfHistory.LabelEdit = true;
            listOfHistory.AllowColumnReorder = true;
            listOfHistory.FullRowSelect = true;
            listOfHistory.GridLines = true;
            listOfHistory.Sorting = SortOrder.Ascending;

            listOfHistory.Columns.Add("NumberOfKey", -2, HorizontalAlignment.Left);
            listOfHistory.Columns.Add("TeacherCardID", -2, HorizontalAlignment.Left);
            listOfHistory.Columns.Add("DataOfGiving", -2, HorizontalAlignment.Left);
            listOfHistory.Columns.Add("Returned", -2, HorizontalAlignment.Left);

            Controls.Add(listOfHistory);

            string[] csvOfHistory = File.ReadAllLines("HistoryOfGiving.csv");

            for (int i = 0; i < csvOfHistory.Count(); i++)
            {
                ListViewItem recordOfHistory = new ListViewItem(csvOfHistory[i].Split(';')[0]);
                recordOfHistory.SubItems.Add(csvOfHistory[i].Split(';')[1]);
                recordOfHistory.SubItems.Add(csvOfHistory[i].Split(';')[2]);
                recordOfHistory.SubItems.Add(csvOfHistory[i].Split(';')[3]);
                listOfHistory.Items.Add(recordOfHistory);

            }


            var IDKeyBox = new TextBox();
            IDKeyBox.Location = new Point(listOfHistory.Right + 15, 20);
            IDKeyBox.Size = new Size(250, 30);
            Controls.Add(IDKeyBox);

            var IDTeacherCardBox = new TextBox();
            IDTeacherCardBox.Location = new Point(listOfHistory.Right + 15, IDKeyBox.Bottom);
            IDTeacherCardBox.Size = new Size(250, 30);
            Controls.Add(IDTeacherCardBox);

            var DataOfGivingBox = new TextBox();
            DataOfGivingBox.Location = new Point(listOfHistory.Right + 15, IDTeacherCardBox.Bottom);
            DataOfGivingBox.Size = new Size(250, 30);
            Controls.Add(DataOfGivingBox);

            var DataOfReturnedBox = new TextBox();
            DataOfReturnedBox.Location = new Point(listOfHistory.Right + 15, DataOfGivingBox.Bottom);
            DataOfReturnedBox.Size = new Size(250, 30);
            Controls.Add(DataOfReturnedBox);


            var AddButton = new Button
            {
                Location = new Point(listOfHistory.Right + 15, DataOfReturnedBox.Bottom),
                Size = new Size(250, 100),
                Text = "Press to add."
            };
            Controls.Add(AddButton);

            AddButton.Click += (sender, args) =>
            {

                    ListViewItem recordOfHistory = new ListViewItem(IDKeyBox.Text);
                    recordOfHistory.SubItems.Add(IDTeacherCardBox.Text);
                    recordOfHistory.SubItems.Add(DataOfGivingBox.Text);
                    recordOfHistory.SubItems.Add(DataOfReturnedBox.Text);
                    listOfHistory.Items.Add(recordOfHistory);

                using (var sw = new StreamWriter("HistoryOfGiving.csv", true, Encoding.UTF8))
                {
                    //sw.WriteLine("Ячейка1;Ячейка2;Ячейка3");
                    sw.WriteLine(IDKeyBox.Text + ";" + IDTeacherCardBox.Text + ";" + DataOfGivingBox.Text + ";" + DataOfReturnedBox.Text);
                }

            };


            var BackButton = new Button
            {
                Location = new Point(listOfHistory.Right + 15, 500),
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
