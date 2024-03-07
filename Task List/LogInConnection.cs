using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.Data.Common;


namespace Task_List
{
    internal class LogInConnection
    {
        String server = "localhost";
        String user = "root";
        String database = "todolist";
        String port = "3306";
        String password = "12345678";
        public MySqlConnection conn;
        
        public void Connection() {

            String connectionString =$"server={server}; " +
                $"user={user}; " +
                $"database={database}; " +
                $"port={port}; " +
                $"password={password}; " ;
            conn = new MySqlConnection();
            conn.ConnectionString = connectionString;

            try
            {
                conn.Open();
            }
            catch (Exception e)
            {

                throw e;
            }
            
        }
        public void CloseConnection() {
            if (conn!=null && conn.State == ConnectionState.Open) {
                conn.Close();
            }
        }

        public void Register(String user, string password) {
            bool UserExist = false;
            Connection();
            MySqlCommand command;
            String sql;
            MySqlDataReader dataReader;
            try
            {
                sql = "Insert into User(name,password)" +
                     "Values(@user,@password);"
                     ;

                command = new MySqlCommand(sql, conn);
                command.Parameters.AddWithValue("@user", user);
                command.Parameters.AddWithValue("@password", password);
                command.ExecuteNonQuery();

                sql = "select id_user, name, password from User where name= @user and password= @password;";
                command = new MySqlCommand(sql, conn);
                command.Parameters.AddWithValue("@user", user);
                command.Parameters.AddWithValue("@password", password);
                dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    UserExist = true;
                    ListContent idList = new ListContent();
                    idList.addID(dataReader.GetInt32(0));
                }
            }
            catch (MySqlException e)
            {
                throw e;
            }
            finally { 
                CloseConnection(); 
            }
        }

        public bool LogIn(String user, string password) {
            Connection();
            bool UserExist=false;
            MySqlCommand command;
            MySqlDataReader dataReader;
            String sql;

            String connectionString = $"server={server}; " +
                $"user={user}; " +
                $"database={database}; " +
                $"port={port}; " +
                $"password={password};";

            sql = "select id_user, name, password from User where name= @user and password= @password;";
            command = new MySqlCommand(sql,conn);
            command.Parameters.AddWithValue("@user",user);
            command.Parameters.AddWithValue("@password", password);
            dataReader= command.ExecuteReader();

            if (dataReader.Read()) {
                UserExist = true;
               ListContent idList= new ListContent();
                idList.addID(dataReader.GetInt32(0));
            }

            else {
                MessageBox.Show("This user doesn't exist");
            }

             CloseConnection();

            return UserExist;
        }
    }
}




//public void ShowTasksList() {
//    dataReader = command.ExecuteReader();

//    while (dataReader.Read())
//    {
//        output = output + dataReader.GetString(0) + "--" + dataReader.GetString(1) + "\n";
//    }
//    MessageBox.Show(output);
//}