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
    public partial class Tasks : Form
    {
        ListContent listContent = new ListContent();
        public Tasks()
        {
            InitializeComponent();
            listContent.callListItems();
            listContent.addElementsList(checkedListBox);

        }
      
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Tasks_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           int selectedIndex = checkedListBox.SelectedIndex;
            listContent.removeElementOfList(checkedListBox, selectedIndex);
  
        }

        private void textBoxTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void agregar_Click(object sender, EventArgs e)
        {
            String campusText=textBoxTitle.Text;
            listContent.addElementsList(checkedListBox,campusText);
        }

        private void limpiarlista_Click(object sender, EventArgs e)
        {
            listContent.cleanList(checkedListBox);
        }

        private void checkedListBox_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int selectedIndex = checkedListBox.SelectedIndex;
            listContent.isChecked(checkedListBox,selectedIndex);
        }
    }
}
