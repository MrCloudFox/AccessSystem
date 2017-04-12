using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessSystem
{
    class User
    {
        public readonly String login;
        public readonly String pass;
        public readonly bool isStudent;

        public User(String login, String pass, bool isStudent)
        {
            this.login = login;
            this.pass = pass;
            this.isStudent = isStudent;
        }
    }
}
