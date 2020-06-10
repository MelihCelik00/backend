using System;
using System.Collections.Generic;

namespace RegisterLogin
{
    public class Register
    {
        private List<Register> userInfo = new List<Register>();
        private string _userName { get; set; }
        private string _password { get; set; }
        private string _email { get; set; }
        private string _bod { get; set; }
        /*
        public Register(string username,
                        string pwd,
                        string e_mail,
                        string birthday)
        {
            userInfo.Add(new Register(_userName, _password,
                                      _email, _bod)
            {
                _userName = username,
                _password = pwd,
                _email = e_mail,
                _bod = birthday,
            });
        }
        */

        public List<Register> GetList() => userInfo;

        public void AddList(string username, // Function is working!
                        string pwd,
                        string e_mail,
                        string birthday)
        {
            userInfo.Add(new Register()
            {
                _userName = username,
                _password = pwd,
                _email = e_mail,
                _bod = birthday,
            });
            Console.WriteLine("You are now registered to our system!");
        }

        public bool CheckUser(string _usenam, string _password)
        {
            string name = _usenam;
            string sifre = _password;
            bool isOk = userInfo.Contains(new Register { _userName = name, _password = sifre });

            if (isOk == true) { return true; }
            else if (isOk == false) { return false; }
            return false;
        }
    }
}