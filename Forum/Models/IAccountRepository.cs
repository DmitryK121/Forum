﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Models {
    public interface IAccountRepository {
        IQueryable<Account> Accounts { get; }
    }
}