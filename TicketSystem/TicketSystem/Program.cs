using System;

namespace TicketSystem
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            /*
                Temel işlemler şöyle user:
                Login
                Register
                Show my tickets
                Open ticket
                Admin:
                Login
                Show all tickets
                Answer and close ticket
             */

            // Create database from the method in database
            Machine mach = new Machine();
            mach.StartAutomation();
        }
    }
}
