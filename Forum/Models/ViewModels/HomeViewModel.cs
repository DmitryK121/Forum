using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Models.ViewModels {
    public class HomeViewModel {
        public IQueryable<Theme> themes{ get; set; }
        public Post post { get; set; }
    }
}
