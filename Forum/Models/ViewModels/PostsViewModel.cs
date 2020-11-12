using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Models.ViewModels {
    public class PostsViewModel {
        public Theme Theme { get; set; }
        public Post newPost { get; set; }
    }
}
