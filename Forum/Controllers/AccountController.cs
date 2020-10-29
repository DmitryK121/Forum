using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Forum.Models;

namespace Forum.Controllers {
    public class AccountController : Controller {
        private IAccountRepository repository;
        public AccountController(IAccountRepository repo) {
            repository = repo;
        }
        public IActionResult List() => View(repository.Accounts);
    }
}
