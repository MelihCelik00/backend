using System;
using System.Collections.Generic;

namespace RegisterLogin
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Database db = new Database();

            //x.RegisterFunc("ahmet", "123", "melihsafa.cgmail.com", "23082000");
            //x.Login("melih", "123");
            //x.RegisterFunc("melih", "123", "melihsafa.cgmail.com", "23082000");
            //x.Login("melih","123");
            
            //ıList<Register> db = new List<Register>();

            Console.WriteLine("Welcome to our program! Let's continue.");
            while (true)
            {
                Console.WriteLine("Please enter 1 to login, enter 2 to register.\nPress 0 to exit.");
                int x = Convert.ToInt32(Console.ReadLine());
                if(x == 0 ) return;
                if(x == 1)// login => username and password
                {
                    Console.WriteLine("\nWelcome to the login page!\n\n");
                    bool Correction = false;
                    while (Correction == false)
                    {
                        Console.WriteLine("Enter your username: ");
                        string userN = Console.ReadLine();

                        Console.WriteLine("Enter your password: ");
                        string userP = Console.ReadLine();

                        
                        if (Correction=db.Login(userN, userP)==true)
                        {
                            Console.WriteLine("Successful login!!!!\n");
                            //Correction = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input, try again.");
                        }
                    }
                }
                else if (x==2)// register
                {
                    Console.WriteLine("\nWelcome to the Register Area!\n");
                    Console.WriteLine("\nPlease enter new user name: ");
                    string usName = Console.ReadLine();
                    Console.WriteLine("\nPlease enter new password: ");
                    string NewPassword = Console.ReadLine();
                    Console.WriteLine("\nPlease enter new email: ");
                    string RegisteringMail = Console.ReadLine();
                    Console.WriteLine("\nPlease enter your date of birth: ");
                    string BirthDate = Console.ReadLine();

                    db.RegisterFunc(usName, NewPassword, RegisteringMail, BirthDate);
                    
                }
                else
                {
                    Console.WriteLine("Invalid Input!!!!");
                }
            }
            
        }
    }
}