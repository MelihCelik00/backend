using System;
namespace RegisterLogin
{
    public class Users : IEquatable<Users>
    {
        public string registerUserName { get; set; }
        public string psswd { get; set; }
        public int registerId { get; set; }

        public bool Equals(Users other) => throw new NotImplementedException();
    }
}