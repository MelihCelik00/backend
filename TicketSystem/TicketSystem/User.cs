using System;
namespace TicketSystem
{
    public class User
    {
        private Database userDB = new Database();
        private string checkUN;
        private string checkPWD;

        public void UserRegister(int id,
                                 string name =null,
                                 string middle=null,
                                 string surname=null,
                                 string username=null,
                                 string password=null,
                                 string mail=null,
                                 string bod=null
                                )
        {
            userDB.WriteOnTable(_name:name, _middle:middle, _surname:surname, _username:username, _password:password, _mail:mail, _bod:bod);
            Console.WriteLine("Successfully registered!");
        }

        public bool UserLogin(string un, string pwd)
        {
            
            checkUN = @"SELECT userName FROM Users WHERE userName='"+un+"'";
            checkPWD = @"SELECT Password FROM Users WHERE Password='"+pwd+"'";

            if (checkUN == un && pwd == checkPWD)
                return true;
            else
                return false;
        }

        public void WriteTicket()
        {

        }

        public void ShowUsersTicket()
        {

        }


    }
}
