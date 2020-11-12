using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Controllers {
    public class ErrorController : Controller {
        public IActionResult Index(string Error) {
            return View(Error);
        }
    }
}
