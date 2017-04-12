using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccessSystem
{
    class TempCardCreation : Form
    {
        public TempCardCreation(User user)
        {
            var button = new Button
            {
                Location = new Point(0, 0),
                Size = new Size(ClientSize.Width, ClientSize.Height),
                Text = "Make an application for a temporary pass"
            };
            Controls.Add(button);

            //Adapted)))
            SizeChanged += (sender, args) =>
            {
                button.Location = new Point(0, 0);
                button.Size = new Size(ClientSize.Width, ClientSize.Height);

            };

            Load += (sender, args) => OnSizeChanged(EventArgs.Empty);

            
            button.Click += (sender, args) =>
            {
                MessageBox.Show("Order is accessed");
                this.Hide();
                var Usersystem = new UserSystem();
                Usersystem.MakeTempCard(user);
            };
        }


    }
}
