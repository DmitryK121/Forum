using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Forum.Models;
using Forum.Models.ViewModels;

namespace Forum.Controllers {
    public class ThreadController : Controller {
        public IThemeRepository repository;
        public ThreadController(IThemeRepository repo) => repository = repo;
        public IActionResult Posts(int Id) => View(new PostsViewModel { Theme = repository.Themes.First(p => p.Id == Id) });

        public IActionResult AddPost(Post newPost, int themeId) {
            repository.AddPost(newPost, themeId);
            //return RedirectToAction(nameof(Posts), new PostsViewModel { Theme = themeRepository.Themes.First(p => p.Id == themeId) });
            return View(nameof(Posts), new PostsViewModel { Theme = repository.Themes.First(p => p.Id == themeId) });
        }
        public IActionResult DeletePost(int postId, int themeId) {
            repository.DeletePost(postId, themeId);
            return View(nameof(Posts), new PostsViewModel { Theme = repository.Themes.First(p => p.Id == themeId) });
        }
        public IActionResult DropPosts(int themeId) {
            repository.DropPosts(themeId);
            return View(nameof(Posts), new PostsViewModel { Theme = repository.Themes.First(p => p.Id == themeId) });
        }
    }
}
