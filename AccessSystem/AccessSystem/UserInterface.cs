using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccessSystem
{
    class UserInterface : Form
    {

        public UserInterface()
        {   

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

            var passLabel = new Label
            {
                Location = new Point(0, loginBox.Bottom),
                Size = loginLabel.Size,
                Text = "Pass:"
            };
            Controls.Add(passLabel);

            var passBox = new TextBox();
            passBox.Location = new Point(0, passLabel.Bottom);
            passBox.Size = loginLabel.Size;
            Controls.Add(passBox);


            var studentCheckBox = new CheckBox();
            studentCheckBox.Location = new Point(0, passBox.Bottom);
            studentCheckBox.Size = loginLabel.Size;
            studentCheckBox.Text = "Student?";
            Controls.Add(studentCheckBox);

            var loginButton = new Button
            {
                Location = new Point(0, studentCheckBox.Bottom),
                Size = passBox.Size,
                Text = "Enter"
            };
            Controls.Add(loginButton);

            var regButton = new Button
            {
                Location = new Point(0, loginButton.Bottom + 15),
                Size = passBox.Size,
                Text = "Registration"
            };
            Controls.Add(regButton);

            
            var watchManButton = new Button
            {
                Location = new Point(0, regButton.Bottom + 15),
                Size = passBox.Size,
                Text = "WatchMan"
            };
            Controls.Add(watchManButton);


            watchManButton.Click += (sender, args) =>
            {
                var watchMan = new WatchMan();
                this.Hide();
                watchMan.ShowDialog();
                this.Close();
            };


            regButton.Click += (sender, args) =>
            {       
                var RegWindow = new RegistrationShow();
                RegWindow.Show();
            };

            loginButton.Click += (sender, args) =>
            {
                 
                var SystemUse = new UserSystem();
                if (loginBox.Text == "" || passBox.Text == "")
                {
                    MessageBox.Show("Entered incorrect data.");
                    this.Close();
                }
                else if (UserSystem.Autorisation(loginBox.Text, passBox.Text))
                {

                    var user = new User(loginBox.Text, passBox.Text, studentCheckBox.Checked);
                    var CardCreation = new TempCardCreation(user);
                    this.Hide();
                    CardCreation.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Entered incorrect data.");
                }
                
            };

            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
        }

    }
}