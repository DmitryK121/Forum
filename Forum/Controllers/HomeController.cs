using Forum.Models;
using Forum.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using System;

namespace Forum.Controllers {
    public class HomeController : Controller {
        private IThemeRepository repository;
        public HomeController(IThemeRepository tRepo) => repository = tRepo;
        public IActionResult Index() => View(repository.Themes.OrderBy(p => p.Id));
        public IActionResult ThemePosts() {
            return View(repository.Themes.FirstOrDefault().Posts);
        }
        public IActionResult AddPosts() {
            for (int i = 0; i < 100; i++) {
                repository.AddPost(
                    new Post { Content = "Generated content" + i, CreatedTime = DateTime.Now, UserId = i},
                        new Random().Next(repository.Themes.OrderBy(p => p.Id).FirstOrDefault().Id, 
                            repository.Themes.OrderByDescending(p => p.Id).FirstOrDefault().Id + 1));
            }
            return RedirectToAction("Index");
        }
        public IActionResult CleanPage() => View();
        public IActionResult DropThemes() {
            repository.DropThemes();
            return RedirectToAction("Index");
        }
    }
}
