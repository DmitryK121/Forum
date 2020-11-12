using Forum.Models;
using Forum.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Forum.Infrastructure;
using System.Collections.Generic;
using System;

namespace Forum.Controllers {
    public class HomeController : Controller {
        private IMessageRepository repository;
        private IThemeRepository themeRepository;
        public HomeController(IMessageRepository repo, IThemeRepository tRepo) {
            repository = repo;
            themeRepository = tRepo;
        }
        public IActionResult Index() => View(new HomeViewModel { 
            themes = themeRepository.Themes.OrderBy(p => p.Id)/*,
            post = themeRepository.Themes.OrderBy(p => p.Id).FirstOrDefault().Posts.OrderByDescending(p => p.CreatedTime).FirstOrDefault()*/ });
        public IActionResult ThemePosts() {
            //themeRepository.Themes.FirstOrDefault().Posts.Add(new Post { content = "content", createdTime = DateTime.Now, userId = 0 });
            //return View(themeRepository.Themes.FirstOrDefault().Posts);
            return View(themeRepository.Themes.FirstOrDefault().Posts);
        }
        public IActionResult AddPost(Post post) {
            themeRepository.AddPost(post, themeRepository.Themes.FirstOrDefault().Id);
            return RedirectToAction("Index");
        }
        public IActionResult CleanPage() => View();
        public IActionResult DropPosts() {
            themeRepository.DropPosts();
            return RedirectToAction("Index");
        }
    }
}

//repository.Messages.Select(p => p.Theme).Where(p => p.Length > 0).Distinct()
//Themes = repository.Messages.Select(p => p.Theme).Where(p => p.Length > 0).Distinct(),