using Forum.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Controllers {
    public class HomeController : Controller {
        public IActionResult Index() => View(new Account { AccountName = "AName", Password = "Password" });
    }
}
