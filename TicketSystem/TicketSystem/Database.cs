using System;
using System.Data.SQLite;

namespace TicketSystem
{
    public class Database
    {
        //Methods for Admin and User

        private string dbName = "ticketDB";
        private string query;
        private string query2;
        private SQLiteConnection con = null;


        public void ConnectDB(string name)
        {
            con = new SQLiteConnection($"Data Source={name};Version=3;");
            con.Open();
        }

        public void CreateTable()
        {
            ConnectDB(dbName);
            using (con)
            {
                using (SQLiteCommand cmd = new SQLiteCommand(con))
                {
                    cmd.CommandText = @"CREATE TABLE IF NOT EXISTS Users (
                    UserID INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name varchar(30),
                    MiddleName varchar(30),
                    Surname varchar(30),
                    userName varchar(30),
                    Password TEXT,
                    Email TEXT,
                    Birthday DATE,
                    UserType varchar(5)
                    )";
                    cmd.ExecuteNonQuery();
                    /*
                    cmd.CommandText = @"CREATE TABLE IF NOT EXISTS Tickets (
                    UserID INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name varchar(30),
                    MiddleName varchar(30),
                    Surname varchar(30),
                    userName varchar(30),
                    Password TEXT,
                    Email TEXT,
                    Birthday DATE,
                    UserType varchar(5)
                    )";// LOOK HERE!!!!!!
                    cmd.ExecuteNonQuery();
                    */
                    con.Close();
                }
            }
        }

        public void SetAdmin()
        {
            ConnectDB(dbName);
            using (con)
            {
                using (SQLiteCommand cmd1 = new SQLiteCommand(con))
                {
                    query = @"INSERT INTO Users (UserID, Name, MiddleName, Surname, userName, Password, Email, Birthday, UserType) values (NULL,admin1,NULL,NULL,admin1,admin@admin.com, admin)";
                    query2 = @"INSERT INTO Users (UserID, Name, MiddleName, Surname, userName, Password, Email, Birthday, UserType) values (NULL,admin2,NULL,NULL,admin2,admin2@admin.com, admin)";
                    cmd1.CommandText = query;
                    cmd1.CommandText = query2;
                    cmd1.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        public void WriteOnTable(string _name, string _middle, string _surname, string _username, string _password,string _mail, string _bod)
        {
            ConnectDB(dbName);
            using (con)
            {
                using (SQLiteCommand cmd1 = new SQLiteCommand(con))
                {
                    query = @"INSERT INTO Users (UserID, Name, MiddleName, Surname, userName, Password, Email, Birthday, UserType) values (NULL," + _name + "," + _middle + "," + _surname + "," + _username + ","+ _password + "," + _mail + "," + _bod + "user";
                    cmd1.CommandText = query;
                    cmd1.ExecuteNonQuery();
                    con.Close();
                }
            }
            //string sql1 = "insert into uyeler (id,name, yas) values (NULL,'Şerif GÜNGÖR', 22)";
            //SQLiteCommand command1 = new SQLiteCommand(sql1, conn);
            //command1.ExecuteNonQuery();
        }
    }
}
