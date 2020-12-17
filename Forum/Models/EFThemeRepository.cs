using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Forum.Models {
    public class EFThemeRepository : IThemeRepository {
        private ApplicationDbContext context;
        public EFThemeRepository(ApplicationDbContext ctx) => context = ctx;
        public IQueryable<Theme> Themes => context.Themes
            .Include(p => p.Posts);
        public void AddTheme(string themeName) {
            context.Themes.Add(new Theme { Name = themeName });
            context.SaveChanges();
        }
        public void DeleteTheme(int id) {

        }
        public void DropThemes() {
            /*foreach (Theme theme in context.Themes.Include(p => p.Posts)) {
                context.Themes.Remove(theme);
            }*/
            context.Themes.RemoveRange(Themes.Take(context.Themes.Count()));
            context.SaveChanges();
        }

        public void AddPost(Post post, int themeId) {
            Post dbPost = new Post { Content = post.Content, CreatedTime = DateTime.Now, UserId = 0 };
            context.Themes.Include(p => p.Posts).FirstOrDefault(p => p.Id == themeId).Posts.Add(dbPost);
            context.SaveChanges();
        }
        public void DeletePost(int postId, int themeId) {
            Post dbEntry = context.Themes.Include(p => p.Posts).FirstOrDefault(p => p.Id == themeId).Posts.FirstOrDefault(p => p.Id == postId);
            if (dbEntry != null) {
                context.Themes.FirstOrDefault(p => p.Id == themeId).Posts.Remove(dbEntry);
                context.SaveChanges();
            }
        }
        public void DropPosts(int themeId) {
            if (context.Themes.Any(p => p.Id == themeId)) {
                context.Themes.Include(p => p.Posts).FirstOrDefault(p => p.Id == themeId).Posts.Clear();
                context.SaveChanges();
            }
        }
    }
}
