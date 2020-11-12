using System;
using System.Collections.Generic;

namespace Forum.Models {
    public class Message {
        public int messageId { get; set; }
        public string content { get; set; }
        public int userId { get; set; }
        public DateTime createdTime { get; set; }
        public string theme { get; set; }
    }
}
