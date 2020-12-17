using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Models.ViewModels {
    public class HomeViewModel {
        public IQueryable<Theme> Themes;
        public string themeName;
    }
}
