using ProjectWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWork.Data.Services
{
    public class AccountService : Service<Account>
    {
        public AccountService(string url) : base(url)
        {
        }
    }
}
