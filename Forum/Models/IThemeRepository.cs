﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Models {
    public interface IThemeRepository {
        IQueryable<Theme> Themes { get; }
        public void AddTheme(string name);
        public void DeleteTheme(int themeId);
        public void DropThemes();

        public void AddPost(Post post, int themeId);
        public void DeletePost(int postId, int themeId);
        public void DropPosts(int themeId);
    }
}
