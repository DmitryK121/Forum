﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Models {
    public class Post {
        public int Id { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
