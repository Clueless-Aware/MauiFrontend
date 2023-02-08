using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWork.Models
{
    internal class LoginAgent
    {

        public LoginAgent() {
           
        }
        internal bool sendRequest()
        {
            //TODO send request to Django
            return true;
        }

        public bool validateLogin() {
            sendRequest();

            //TODO Compare the credential and login if true
            return true; 
        }




    }
}
