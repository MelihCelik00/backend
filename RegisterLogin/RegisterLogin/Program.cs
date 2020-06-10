using System;
using System.Collections.Generic;

namespace RegisterLogin
{
    class MainClass : Register
    {
        public static void Main(string[] args)
        {
            //List<Users> userInfo = new List<Users>();
            /* 
            Ödevimiz 
            Register Login sistemi class yapısı ile

            Programdan beklenti
            kullanıcı register olacak
            Register da kullanıcı adı şifre email doğum tarihi alınacak
            Login ile kullanıcı adı ve şifre ile giriş yapacak
            Sonsuz loop içinde yapabilirsiniz bu ekranı
            Console da 1 e tıkladığımda login e gidecek
            2 ye tıklarsam register a gidecek

            Login olduktan sonra tekrar ana ekrana dönsün,register içinde aynı şekilde 
            */

            Console.WriteLine("Welcome to our program! Let's continue.");
            while (true)
            {
                Console.WriteLine("Please enter 1 to login, enter 2 to register.");
                int x = Convert.ToInt32(Console.ReadLine());
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

                        Register log = new Register();
                        if (log.CheckUser(userN, userP) == true)
                        {
                            Console.WriteLine($"Welcome {userN}, you are good to go!");
                            Correction = true;
                        }
                        else
                        {
                            Console.WriteLine("Your username or password is wrong, please enter again!");
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

                    Register reg = new Register();
                    reg.AddList(usName, NewPassword, RegisteringMail, BirthDate);
                }
                else
                {
                    Console.WriteLine("Invalid Input!!!!");
                }
            }
        }
    }
}
