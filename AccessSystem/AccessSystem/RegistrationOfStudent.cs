using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccessSystem
{
    class RegistrationOfStudent : Form
    {
        public RegistrationOfStudent()
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

            var nameBox = new TextBox();
            nameBox.Location = new Point(0, nameLabel.Bottom);
            nameBox.Size = loginLabel.Size;
            Controls.Add(nameBox);

            var specialityLabel = new Label
            {
                Location = new Point(0, nameBox.Bottom),
                Size = loginLabel.Size,
                Text = "Speciality:",
            };
            Controls.Add(specialityLabel);

            var specialityBox = new TextBox();
            specialityBox.Location = new Point(0, specialityLabel.Bottom);
            specialityBox.Size = loginLabel.Size;
            Controls.Add(specialityBox);

            var numberOfGroupLabel = new Label
            {
                Location = new Point(0, specialityBox.Bottom),
                Size = loginLabel.Size,
                Text = "Number Of Group:",
            };
            Controls.Add(numberOfGroupLabel);

            var numberOfGroupBox = new TextBox();
            numberOfGroupBox.Location = new Point(0, numberOfGroupLabel.Bottom);
            numberOfGroupBox.Size = loginLabel.Size;
            Controls.Add(numberOfGroupBox);

            var passwordLabel = new Label
            {
                Location = new Point(0, numberOfGroupBox.Bottom),
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

            var dateOfEndLabel = new Label
            {
                Location = new Point(0, dateOfGettingBox.Bottom),
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
                var PassCard = new StudentCard(Convert.ToInt32(identifierBox.Text), Convert.ToDateTime(dateOfGettingBox.Text), Convert.ToDateTime(dateOfEndBox.Text));
                var UserInfo = new User(loginBox.Text, passwordBox.Text, true);
                var SystemUse = new UserSystem();
                SystemUse.RegistrationOfStudent(nameBox.Text, PassCard, specialityBox.Text, numberOfGroupBox.Text, UserInfo);
                this.Close();
            };

            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
        }
    }
}
