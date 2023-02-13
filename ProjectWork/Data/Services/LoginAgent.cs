using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWork.Data.Services
{

    public static class LoginAgent
    {
        private static bool loggedIn = false;

        static LoginAgent() { }

        public static bool isLoggedIn()
        {
            //TODO check the Token
            return loggedIn;
        }

        public static void setLoggedIn(bool b)
        {
            loggedIn = b;
        }

    }
}
