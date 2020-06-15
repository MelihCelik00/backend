using System;
using System.Data.SQLite;

namespace TicketSystem
{
    public class User : Database
    {
        private Database userDB = new Database();
        private string checkUN;
        private string checkPWD;

        private string q;

        bool IsLoginTrue = false;
        private string ticketInput;

        public void UserRegister(string name = null,
                                 string middle = null,
                                 string surname = null,
                                 string username = null,
                                 string password = null,
                                 string mail = null,
                                 string bod = null
                                )
        {
            userDB.WriteOnTable(_name: name, _middle: middle, _surname: surname, _username: username, _password: password, _mail: mail, _bod: bod);
            Console.WriteLine("Successfully registered!");
        }

        public bool UserLogin(string un, string pwd)// x= method, if x==true-> ticket operations
        {
            userDB.ConnectDB("ticketDB");
            using (con)
            {
                using (SQLiteCommand command = new SQLiteCommand(con))
                {
                    checkUN = @"SELECT * FROM Users WHERE userName='" + un + "'" +"AND Password ='"+ pwd + "'";
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
                    catch{ }
                    con.Close();
                    return false;
                }

            }
        }

            //if (checkUN == un && pwd == checkPWD)
            //    return true;
            //else
            //    return false;

        public void WriteTicket(string _n, string _p) // INSERT INTO
        {
            IsLoginTrue = UserLogin(_n,_p);
            if (IsLoginTrue)
            {
                Console.WriteLine("Enter your ticket message (Don't press enter until finish!!!!): ");
                ticketInput = Console.ReadLine();
                ConnectDB("ticketDB");
                using (con)
                {
                    using (SQLiteCommand command1 = new SQLiteCommand(con))
                    {
                        q = @"INSERT INTO Ticket (UserID, Name, MiddleName, Surname, userName, Password, Email, Birthday, UserType) values (NULL,admin1,NULL,NULL,admin1, admin123, admin@admin.com, NULL, admin)";
                        command1.CommandText = q;
                        command1.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
        }

        public void ShowUsersTicket() // Use CheckTicket Method from Database class
        {
            
        }

    }
}