using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_List
{
    public partial class SingUp : Form
    {
        LogInConnection connectionCall = new LogInConnection();
        public SingUp()
        {
            InitializeComponent();
            connectionCall.Connection();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
       
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String usernameText = usernameTextbox.Text;
            String passwordText = passwordTextbox.Text;
            connectionCall.Connection();
            connectionCall.Register(usernameText, passwordText);
            MessageBox.Show("Data have been sent");

            Tasks tasksWindow = new Tasks();
            tasksWindow.Visible = true;
            this.Visible = false;
            this.Dispose();
        }
    }
}
