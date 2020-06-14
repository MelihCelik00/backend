using System;
using System.Collections.Generic;

namespace RegisterLogin
{
    public class Register
    {

        public string _userName;
        public string _password;
        public string _email;
        public string _bod;
       
        public Register(string username,
                        string pwd,
                        string e_mail,
                        string birthday)
        {

            _userName = username;
            _password = pwd;
            _email = e_mail;
            _bod = birthday;
          
        }
        public override string ToString()
        {
            return _userName + _password + _email + _bod;
        }
        
        //public void printOut()
        //{
        //    foreach (Register i in db)
        //    {
        //        Console.WriteLine(i);
        //    }
        //}
    }
}