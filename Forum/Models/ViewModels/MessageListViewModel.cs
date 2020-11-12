using System.Linq;

namespace Forum.Models.ViewModels {
    public class MessageListViewModel {
        public Message Message { get; set; }
        public IQueryable<Message> Messages { get; set; }
    }
}
