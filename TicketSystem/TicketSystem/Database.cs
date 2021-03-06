﻿using System;
using System.Data.SQLite;
//using System.Text;
using System.Data;
using System.Collections.Generic;

namespace TicketSystem
{
    public class Database
    {
        //Methods for Admin and User

        //private string name = "ticketDB";
        private string query;
        private string query2;
        //public SQLiteConnection con;
        private string checkTicket;
        private string checkTicket1;
        DataTable dt = new DataTable();
        //DataTable dtU = new DataTable();


        //StringBuilder listSB = new StringBuilder();
        //int lineNumber = 0;
        //var con = new SQLiteConnection("Data Source= database.db; Version = 3;");

        //public void ConnectDB()
        //{
        //var con = new SQLiteConnection(@"Data Source=database.db;Version=3;");
        //con.Open();
        //}

        public void CreateTable(SQLiteConnection con)
        {
            //ConnectDB();
            using (con)
            {
                using (SQLiteCommand cmd = new SQLiteCommand(con))
                {
                    cmd.CommandText = @"CREATE TABLE IF NOT EXISTS Users (
                    UserID INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name char(30),
                    MiddleName char(30),
                    Surname char(30),
                    userName char(30),
                    Password TEXT,
                    Email TEXT,
                    Birthday DATE,
                    UserType char(5)
                    )";
                    cmd.ExecuteNonQuery();
                    // TICKET BLOCK
                    cmd.CommandText = @"CREATE TABLE IF NOT EXISTS Tickets (
                    TicketID INTEGER PRIMARY KEY AUTOINCREMENT,
                    Ticket TEXT,
                    Answer TEXT,
                    askedUserId TEXT,
                    adminAnswered TEXT,
                    CONSTRAINT fk_departments
                        FOREIGN KEY (UserID, UserName)
                        REFERENCES Users(UserID, UserName)
                    )";// LOOK HERE!!!!!!
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        public void SetAdmin(SQLiteConnection con)
        {
            //ConnectDB();
            using (con)
            {
                using (SQLiteCommand cmd1 = new SQLiteCommand(con))
                {
                    query = @"INSERT INTO Users (UserID, Name, MiddleName, Surname, userName, Password, Email, Birthday, UserType) values (NULL,admin1,NULL,NULL,admin1, admin123, admin@admin.com, NULL, admin)";
                    query2 = @"INSERT INTO Users (UserID, Name, MiddleName, Surname, userName, Password, Email, Birthday, UserType) values (NULL,admin2,NULL,NULL,admin2, admin123, admin2@admin.com, NULL, admin)";
                    cmd1.CommandText = query;
                    cmd1.CommandText = query2;
                    cmd1.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        public void WriteOnTable(string _name, string _middle, string _surname, string _username, string _password, string _mail, string _bod, SQLiteConnection con)
        {
            //ConnectDB();
            using (con)
            {
                using (SQLiteCommand cmd1 = new SQLiteCommand(con))
                {
                    query = @"INSERT INTO Users (UserID, Name, MiddleName, Surname, userName, Password, Email, Birthday, UserType) values (NULL," + _name + "," + _middle + "," + _surname + "," + _username + "," + _password + "," + _mail + "," + _bod + "user";
                    cmd1.CommandText = query;
                    cmd1.ExecuteNonQuery();
                    con.Close();
                }
            }
            //string sql1 = "insert into uyeler (id,name, yas) values (NULL,'Şerif GÜNGÖR', 22)";
            //SQLiteCommand command1 = new SQLiteCommand(sql1, conn);
            //command1.ExecuteNonQuery();
        }
        // User ID kısmına bak!

        public void CheckTicket(string un, string pwd, SQLiteConnection con) // User's Method!
        {
            //ConnectDB();
            using (con)
            {
                using (SQLiteCommand command = new SQLiteCommand(con))
                {
                    command.Parameters.AddWithValue("@un", un);
                    command.Parameters.AddWithValue("@pwd", pwd);
                    checkTicket = @"SELECT * FROM Users WHERE userName = @un AND Password = @pwd";
                    //7/7/7/7/7/7//
                    var reader = command.ExecuteScalar();
                    var userid = reader.ToString();
                    command.Parameters.AddWithValue("@userid",userid);

                    command.CommandText = @"SELECT * FROM Tickets WHERE Tickets.userName = @userid";

                    var rdr = command.ExecuteReader();

                    while (rdr.Read())
                    {
                        Console.WriteLine($"{rdr.GetString(1)} {rdr.GetString(2)} \n");
                    }

                    //command.CommandText = checkTicket;
                    //command.ExecuteNonQuery();

                    /*
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(checkTicket,con);
                    adapter.Fill(dtU);
                    con.Close();
                    foreach (DataRow item2 in dtU.Rows)
                    {
                        string row2 = String.Format($"Ticket: {item2[1]} Answer: {item2[2]} UserID: {item2[3]}");
                        Console.WriteLine(row2);
                    }
                    */
                }
            }
        }

        public void CheckAllTicket(SQLiteConnection con) // Admin's Method!
        {
            //ConnectDB();
            using (con)
            {
                using (SQLiteCommand command1 = new SQLiteCommand(con))
                {
                    checkTicket1 = @"SELECT * FROM Tickets";
                    //command1.CommandText = checkTicket;
                    //command1.ExecuteNonQuery();

                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(checkTicket1,con);
                    adapter.Fill(dt);
                    con.Close();
                    foreach (DataRow item in dt.Rows)
                    {
                        string row = String.Format($"Ticket: {item[1]} Answer: {item[2]} UserID: {item[3]}");
                        Console.WriteLine(row);
                    }
                }
            }
        }
    }
}