using System;
using System.Data.SQLite;
using System.Collections.Generic;

namespace TicketSystem
{
    public class User : Database
    {
        private Database userDB = new Database();
        private string checkUN;
        //private string checkPWD;

        //private string q;

        bool IsLoginTrue = false;
        private string ticketInput;

        public void UserRegister(string name = null,
                                 string middle = null,
                                 string surname = null,
                                 string username = null,
                                 string password = null,
                                 string mail = null,
                                 string bod = null,
                                 SQLiteConnection con=null
                                )
        {
            userDB.WriteOnTable(_name: name, _middle: middle, _surname: surname, _username: username, _password: password, _mail: mail, _bod: bod, con);
            Console.WriteLine("Registering...");
        }

        public bool UserLogin(string un, string pwd, SQLiteConnection con)// x= method, if x==true-> ticket operations
        {
            //userDB.ConnectDB();
            using (con)
            {
                using (SQLiteCommand command = new SQLiteCommand(con))
                {
                    checkUN = @"SELECT * FROM Users WHERE userName=@un AND Password = @pwd";
                    command.Parameters.AddWithValue("@un", un);
                    command.Parameters.AddWithValue("@pwd", pwd);
                    command.CommandText = checkUN;
                    command.ExecuteNonQuery();
                    //checkPWD = @"SELECT Password FROM Users WHERE Password='" + pwd + "'";
                    //command.CommandText = checkPWD;
                    //command.ExecuteNonQuery();
                    try
                    {
                        var result = command.ExecuteReader();
                        if (result.HasRows)
                        {
                            con.Close();
                            return true;
                        }
                    }
                    catch { }
                    con.Close();
                    return false;
                }

            }
        }
            //if (checkUN == un && pwd == checkPWD)
            //    return true;
            //else
            //    return false;

        public void WriteTicket(string _n, string _p, SQLiteConnection con) // INSERT INTO
        {
            IsLoginTrue = UserLogin(_n,_p, con);
            if (IsLoginTrue)
            {
                Console.WriteLine("Enter your ticket message (Don't press enter until finish!!!!): ");
                ticketInput = Console.ReadLine();
                //ConnectDB();
                using (con)
                {
                    using (SQLiteCommand command1 = new SQLiteCommand(con))
                    {
                        command1.CommandText = @"SELECT * FROM Users WHERE userName = @id and password = @password";
                        command1.Parameters.AddWithValue("@id", _n);
                        command1.Parameters.AddWithValue("@password", _p);

                        var reader = command1.ExecuteScalar();

                        var userid = reader.ToString();

                        command1.CommandText = "INSERT INTO Tickets(Ticket, adminanswered, askedUserId) VALUES(@ticket, @adminanswered, @askeduser)";

                        command1.Parameters.AddWithValue("@ticket", ticketInput);
                        command1.Parameters.AddWithValue("@adminanswered", "none");////
                        command1.Parameters.AddWithValue("@askeduser", userid);
                        command1.Prepare();

                        command1.ExecuteNonQuery();
                        con.Close();
                        Console.WriteLine("Your ticket posted to our database, admins will check immediately!!!");
                    }
                }
            }
        }

        public void ShowUsersTicket(string _n, string _p, SQLiteConnection con) // Use CheckTicket Method from Database class
        {
            userDB.CheckTicket(_n,_p, con);
        }

    }
}