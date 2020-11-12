using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Forum.Models {
    public static class SeedData {
        public static void EnsurePopulated(IApplicationBuilder app) {
            ApplicationDbContext context = app.ApplicationServices
                .GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Messages.Any()) {
                context.Messages.AddRange(
                new Message { content = "SomeContent1", createdTime = DateTime.Now, userId = 0 },
                new Message { content = "SomeContent2", createdTime = DateTime.Now, userId = 1 },
                new Message { content = "SomeContent3", createdTime = DateTime.Now, userId = 2 },
                new Message { content = "SomeContent4", createdTime = DateTime.Now, userId = 3 }
                );
                context.SaveChanges();
            }

            if (!context.Themes.Any()) {
/*                context.Themes.AddRange(
                    new Theme { Name = "ThemeName1", Posts = new List<Post>()},
                    new Theme { Name = "ThemeName2" },
                    new Theme { Name = "ThemeName3" },
                    new Theme { Name = "ThemeName4" },
                    new Theme { Name = "ThemeName4" });*/
                for (int i = 0; i < new Random().Next(7,10); i++) {
                    context.Themes.Add(new Theme { Name = $"Theme №{i}" });
                }
                context.SaveChanges();
                foreach (Theme theme in context.Themes.Include(p => p.Posts)) {
                    for (int i = 0; i < new Random().Next(0, 7); i++) {
                        theme.Posts.Add(new Post { Content = $"Post content №{i}", CreatedTime = DateTime.Now, UserId = i });
                    }
                }
                context.SaveChanges();
            }
        }
    }
}
