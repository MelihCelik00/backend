using System;
using System.Collections.Generic;

namespace RegisterLogin
{
    public class Database
    {
        private List<Register> db = new List<Register>();

       
        public List<Register> GetList() => db;

        public void RegisterFunc(string username, // Function is working! // Addlist
                            string pwd,
                            string e_mail,
                            string birthday)
        {
            db.Add(new Register(username, pwd, e_mail, birthday));
            
            Console.WriteLine("You are now registered to our system!");
        }

        public bool Login(string _usenam, string _password) // Checkuser
        {
            //bool isOk = db.Contains(new Register(_usenam, _password));
            Register isOk = db.Find(x => x._userName == _usenam);
            //Console.WriteLine(isOk==null);
            if (isOk==null)
            {
                //Console.WriteLine("Invalid input, try again..");
                return false;
            }
            if(isOk._password == _password)
            {
                //Console.WriteLine("Giris yaptiniz!");
                return true;
            }
            //if (isOk == true) { return true; }
            //else if (isOk == false) { return false; }
            return false;
        }
    }
}
