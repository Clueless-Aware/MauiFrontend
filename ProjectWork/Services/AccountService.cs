using ProjectWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWork.Services
{
    public class AccountService : Service<AccountUpload, AccountDownload>
    {
        public AccountService(string url) : base(url)
        {
        }
    }
}
