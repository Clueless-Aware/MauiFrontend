using CommunityToolkit.Mvvm.ComponentModel;
using ProjectWork.Data.Services;
using ProjectWork.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWork.Data.ViewModels
{
    public class AccountViewModel : ObservableRecipient  
    {
        private readonly AccountService _accountService = new(url: "http://localhost:8000/api/accounts/");
        private List<AccountDownload> _items;
        private Account _account;

        public Account Account
        {
            get => _account;
            set => SetProperty(ref _account, value);
        }
        public List<AccountDownload> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }

        public async Task ReadItems()
        {
            Debug.WriteLine("READ");
            Items = await _accountService.GetItems();
        }

        public async Task DeleteItem(Account account)
        {
            Debug.WriteLine("DELETE");
            var response = await _accountService.DeleteItem(account.OwnerId);
            Debug.WriteLine(response.message);
            if (response.status)
            {
                await ReadItems();
            }

        }
        public async Task CreateItem(AccountUpload account)
        {
            Debug.WriteLine("CREATE");
            var response = await _accountService.AddItem(account);
            Debug.WriteLine(response.message);
            if (response.status)
            {
                await ReadItems();
            }
        }



        public Task UpdateItem(Account item)
        {
            Debug.WriteLine("UPDATE");
            throw new NotImplementedException();
        }

    }
}
