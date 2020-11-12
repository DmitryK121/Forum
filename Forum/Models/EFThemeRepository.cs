using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Forum.Models {
    public class EFThemeRepository : IThemeRepository {
        private ApplicationDbContext context;
        public EFThemeRepository(ApplicationDbContext ctx) => context = ctx;
        public IQueryable<Theme> Themes => context.Themes
            .Include(p => p.Posts);
        public void AddTheme(string theme) {

        }
        public void DeleteTheme(int id) {

        }
        public void AddPost(Post post, int themeId) {
            Post dbPost = new Post { Content = post.Content, CreatedTime = DateTime.Now, UserId = 0 };
            //context.Themes.FirstOrDefault(p => p.Id == themeId).Posts.Add(dbPost);
            context.Themes.Include(p => p.Posts).FirstOrDefault(p => p.Id == themeId).Posts.Add(dbPost);
            context.SaveChanges();
        }
        public void DropPosts() {
            /*foreach (Theme theme in context.Themes.Include(p => p.Posts)) {
                context.Themes.Remove(theme);
            }*/
            context.Themes.RemoveRange(Themes.Take(context.Themes.Count()));
            context.SaveChanges();
        }
    }
}
