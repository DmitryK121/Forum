using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Models {
    public class FakeAccountRepository : IAccountRepository{
        public IQueryable<Account> Accounts => new List<Account> {
            new Account { AccountName = "Name1", Password = "1" },
            new Account { AccountName = "Name2", Password = "2" },
            new Account { AccountName = "Name3", Password = "3" },
            new Account { AccountName = "Name4", Password = "4" }
        }.AsQueryable<Account>();
    }
}
