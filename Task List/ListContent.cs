using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_List
{
    internal class ListContent
    {
        public static int ID;
        List<String> listItems= new List<String>();

        LogInConnection logIn;
        String sql;
        MySqlCommand command;
        MySqlDataReader datareader;

        public void addID(int id) {
            ID = id;
        }

        public void callListItems(){

            listItems.Clear();
            logIn = new LogInConnection();
            logIn.Connection();
            sql = "select title from Task where id_user= @ID;";
            command = new MySqlCommand(sql, logIn.conn);
            command.Parameters.AddWithValue("@ID",ID);
            datareader= command.ExecuteReader();

            while (datareader.Read()) {
                listItems.Add(datareader.GetString(0));
            }
            datareader.Close();
        }

        public void cleanList(CheckedListBox listBox)
        {
            sql = "delete from Task where id_user= @ID;";
            command = new MySqlCommand(sql, logIn.conn);
            command.Parameters.AddWithValue("@ID", ID);
            command.ExecuteNonQuery();
            listItems.Clear();
            listBox.Items.Clear();
        }

            public void removeElementOfList(CheckedListBox listBox,int index)
        {           
            sql = "delete from Task where title= @title and id_user= @ID;";
            command = new MySqlCommand(sql, logIn.conn);
            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@title", listItems[index]);
            command.ExecuteNonQuery();
           
            listItems.RemoveAt(index);
            listBox.Items.RemoveAt(index);
        }

        public void addElementsList(CheckedListBox listBox) {
            foreach (string i in listItems)
            {
                listBox.Items.Add(i);
            }
        }

        public void addElementsList(CheckedListBox listBox, String texts)
        {            
            sql = "insert into Task(title,id_user)values(@texts,@ID);";
            command = new MySqlCommand(sql, logIn.conn);
            command.Parameters.AddWithValue("@texts",texts);
            command.Parameters.AddWithValue("@ID", ID);
            command.ExecuteNonQuery();

            listBox.Items.Add(texts);
        }

        public void isChecked(CheckedListBox listBox, int index) {
            if (listBox.GetItemChecked(index)) {
                sql = "update task Set task_completed=true where title= @title and id_user= @ID;";
                command = new MySqlCommand(sql, logIn.conn);
                command.Parameters.AddWithValue("@ID", ID);
                command.Parameters.AddWithValue("@title", listItems[index]);
                command.ExecuteNonQuery();
                MessageBox.Show("Task completed");
            }
            else
            {
                sql = "update task Set task_completed=false where title= @title and id_user= @ID;";
                command = new MySqlCommand(sql, logIn.conn);
                command.Parameters.AddWithValue("@ID", ID);
                command.Parameters.AddWithValue("@title", listItems[index]);
                command.ExecuteNonQuery();
                MessageBox.Show("Pending task again");
            }
        }
    }
}
