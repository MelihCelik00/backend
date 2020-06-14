    using System;

namespace BackendCourse
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // User Login HW
            /*
            bool nameCorrect = false;
            bool surnameCorrect = false;
            bool successfulEntry = false;

            // Our little database(!)
            string[] names = {"Melih","Safa","Ahmet","Mehmet","Veli"};
            string[] surnames = new string[] {"Celik","Yilmaz","Torun","Ozefe","Yugrum"};

            // Login Operations
            while (successfulEntry==false)
            {
                Console.WriteLine("Welcome to Login Page!\nEnter Your Name: ");
                string nameInput = Console.ReadLine();
                Console.WriteLine($"Welcome {nameInput}, Please Enter Your Surname: ");
                string surnameInput = Console.ReadLine();

                for (int i = 0; i < names.Length; i++)
                {
                    if (names[i] == nameInput)
                    {
                        nameCorrect = true;
                    }

                    if (surnames[i] == surnameInput)
                    {
                        surnameCorrect = true;
                    }
                }

                if (nameCorrect == true && surnameCorrect == true)
                {
                    Console.WriteLine($"Successful login! Welcome {nameInput} {surnameInput}");
                    successfulEntry = true;
                }
                else
                {
                    Console.WriteLine("Invalid name or surname entry please try again!");
                }
            }
            Console.WriteLine("Have fun at rest of the program!! Good day! ");
            */

            //Fibonacci HW ////////////
            Console.WriteLine(Fibonacci.Fibo(9));
        }

    }

    public class Fibonacci
    {
        public static int Fibo(int n)
        {
            if (n <= 1)
            {
                return n;
            }
            else
            {
                return Fibo(n - 1) + Fibo(n - 2);
            }
        }
    }
}
