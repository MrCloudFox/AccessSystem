using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccessSystem
{
    class RegistrationOfTeachers : Form
    {
        public RegistrationOfTeachers()
        {
            this.Size = new Size(ClientSize.Width, 500);

            var loginLabel = new Label
            {
                Location = new Point(0, 0),
                Size = new Size(ClientSize.Width, 30),
                Text = "Login:",
            };
            Controls.Add(loginLabel);


            var loginBox = new TextBox();
            loginBox.Location = new Point(0, loginLabel.Bottom);
            loginBox.Size = loginLabel.Size;
            Controls.Add(loginBox);


            var nameLabel = new Label
            {
                Location = new Point(0, loginBox.Bottom),
                Size = loginLabel.Size,
                Text = "Full Name:",
            };
            Controls.Add(nameLabel);


            var fullNameBox = new TextBox();
            fullNameBox.Location = new Point(0, nameLabel.Bottom);
            fullNameBox.Size = loginLabel.Size;
            Controls.Add(fullNameBox);


            var facultyLabel = new Label
            {
                Location = new Point(0, fullNameBox.Bottom),
                Size = loginLabel.Size,
                Text = "Faculty:",
            };
            Controls.Add(facultyLabel);


            var facultyBox = new TextBox();
            facultyBox.Location = new Point(0, facultyLabel.Bottom);
            facultyBox.Size = loginLabel.Size;
            Controls.Add(facultyBox);


            var passwordLabel = new Label
            {
                Location = new Point(0, facultyBox.Bottom),
                Size = loginLabel.Size,
                Text = "Password:",
            };
            Controls.Add(passwordLabel);


            var passwordBox = new TextBox();
            passwordBox.Location = new Point(0, passwordLabel.Bottom);
            passwordBox.Size = loginLabel.Size;
            Controls.Add(passwordBox);


            var identifierLabel = new Label
            {
                Location = new Point(0, passwordBox.Bottom),
                Size = loginLabel.Size,
                Text = "PassCard ID:",
            };
            Controls.Add(identifierLabel);


            var identifierBox = new TextBox();
            identifierBox.Location = new Point(0, identifierLabel.Bottom);
            identifierBox.Size = loginLabel.Size;
            Controls.Add(identifierBox);


            var dateOfGettingLabel = new Label
            {
                Location = new Point(0, identifierBox.Bottom),
                Size = loginLabel.Size,
                Text = "Getting Date:",
            };
            Controls.Add(dateOfGettingLabel);


            var dateOfGettingBox = new TextBox();
            dateOfGettingBox.Location = new Point(0, dateOfGettingLabel.Bottom);
            dateOfGettingBox.Size = loginLabel.Size;
            Controls.Add(dateOfGettingBox);

            var specialityLabel = new Label
            {
                Location = new Point(0, dateOfGettingBox.Bottom),
                Size = loginLabel.Size,
                Text = "Enter your speciality:",
            };
            Controls.Add(specialityLabel);

            var specialityBox = new TextBox();
            specialityBox.Location = new Point(0, specialityLabel.Bottom);
            specialityBox.Size = loginLabel.Size;
            Controls.Add(specialityBox);

            var dateOfEndLabel = new Label
            {
                Location = new Point(0, specialityBox.Bottom),
                Size = loginLabel.Size,
                Text = "End Date:",
            };
            Controls.Add(dateOfEndLabel);


            var dateOfEndBox = new TextBox();
            dateOfEndBox.Location = new Point(0, dateOfEndLabel.Bottom);
            dateOfEndBox.Size = loginLabel.Size;
            Controls.Add(dateOfEndBox);


            var button = new Button
            {
                Location = new Point(0, dateOfEndBox.Bottom + 15),
                Size = dateOfEndBox.Size,
                Text = "Sign In!"
            };
            Controls.Add(button);


            button.Click += (sender, args) =>
            {
                var PassCard = new TeacherCard(Convert.ToInt32(identifierBox.Text), Convert.ToDateTime(dateOfGettingBox.Text), specialityLabel.Text);
                var UserInfo = new User(loginBox.Text, passwordBox.Text, false);
                var SystemUse = new UserSystem();
                SystemUse.RegistrationOfTeacher(fullNameBox.Text, PassCard, specialityBox.Text, UserInfo);
                this.Close();
            };

            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
        }
    }
}