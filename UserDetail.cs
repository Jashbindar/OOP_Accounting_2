using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Accounting
{
    internal class UserDetail
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int UserId { get; set; }
        public UserDetail(string email, string password, int userid)
        {
            Email = email;
            Password = password;
            UserId = userid;
        }
        public UserDetail() { }

    }
}
