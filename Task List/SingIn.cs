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
    public partial class SingIn : Form
    {
        LogInConnection connectionCall= new LogInConnection();
        public SingIn()
        {
            InitializeComponent();
            messageError.Visible=false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {
            SingUp registrate = new SingUp();
            registrate.Visible = true;
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String usernameText = textBox1.Text;
            String passwordText = textBox2.Text;
            bool userExist=connectionCall.LogIn(usernameText,passwordText);
            if (userExist)
            {
                Tasks tasksWindow = new Tasks();
                tasksWindow.Visible = true;
                this.Visible = false;
            }
            else {
                messageError.Visible = true;
            }
          
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
