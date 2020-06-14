/*
using System;
using System.Collections.Generic;

namespace RegisterLogin
{
    public class Login : Register
    {
        Register checkUser = new Register();
        public bool CheckUser(string _username, string _password)
        {
            List<Register> pullList = checkUser.GetList();
            bool isOk = pullList.Contains(new Register { _userName = _username, _password = _password });

            if (isOk == true) { return true; }
            else if (isOk==false) {return false; }
            return false;
        }
    }
}
*/