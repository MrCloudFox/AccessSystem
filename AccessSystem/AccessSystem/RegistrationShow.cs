using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccessSystem
{
    class RegistrationShow : Form
    {
        public RegistrationShow()
        {
            this.Size = new Size(ClientSize.Width, 158);

            var regStudent = new Button
            {
                Location = new Point(0, 0),
                Size = new Size(ClientSize.Width , 60),
                Text = "I'm student."
            };
            Controls.Add(regStudent);


            var regTeacher = new Button
            {
                Location = new Point(0, regStudent.Bottom),
                Size = regStudent.Size,
                Text = "I'm teacher."
            };
            Controls.Add(regTeacher);

            regStudent.Click += (sender, args) =>
            {
                var regStudents = new RegistrationOfStudent();
                regStudents.Show();
                this.Close();
            };

            regTeacher.Click += (sender, args) =>
            {
                var regTeachers = new RegistrationOfTeachers();
                regTeachers.Show();
                this.Close();
            };


            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;

        }
    }
}
