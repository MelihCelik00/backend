using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace TicketSystem
{
    public class Machine
    {
        // Everything will be handled here and StartAutomation() will be called in Program.cs
        Database db = new Database();
        User user = new User();
        public void StartAutomation()
        {
            var con = new SQLiteConnection("Data Source= database.db; Version = 3;");
            con.Open();
            string key = null;

            while (key != "q")
            {
                Console.WriteLine("what do you want to do ? :  \n1- login \n2- register \nPress q key to exit \n");
                key = Console.ReadLine();
                if (key == "2")
                {
                    Console.WriteLine("Enter your first name:");
                    string name = Console.ReadLine();
                    Console.WriteLine("If you have please enter your middle name:");
                    string mname = Console.ReadLine();
                    Console.WriteLine("Enter your surname:");
                    string surname = Console.ReadLine();
                    Console.WriteLine("Enter your new username:");
                    string username = Console.ReadLine();
                    Console.WriteLine("Enter your new password:");
                    string password = Console.ReadLine();
                    Console.WriteLine("Enter your e-mail:");
                    string email = Console.ReadLine();
                    Console.WriteLine("Enter your birthday:");
                    string bod = Console.ReadLine();
                    user.UserRegister(name,mname,surname,username,password,email,bod);
                    Console.WriteLine("Registering stage has completed!");
                }
                else if (key == "1")
                {
                    Console.WriteLine("Welcome to the login page! Let's continue: ");
                    Console.WriteLine("Enter your username:");
                    string uname = Console.ReadLine();
                    Console.WriteLine("Enter your password:");
                    string pwd = Console.ReadLine();
                    bool check = user.UserLogin(uname, pwd, con);
                    if (check == false)
                    {
                        Console.WriteLine("Login failed!!!!!!!!\nDirecting to the main page...\n\n");
                    }
                    else
                    {
                        var _newUser = new User();
                        Console.WriteLine($"Login is successfull, Welcome {uname}\n");
                        Console.WriteLine("What do you want to do ?\n" +
                                          "1 - Write a new ticket\n" +
                                          "2 - View your tickets");
                        string key2 = Console.ReadLine();
                        if (key2 == "1")
                        {
                            _newUser.WriteTicket(uname, pwd, con);
                        }
                        else if (key2 == "2")
                        {
                            _newUser.ShowUsersTicket(uname, pwd, con);
                        }

                    }

                }
            }
        }
    }
}