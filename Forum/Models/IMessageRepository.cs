using System.Linq;

namespace Forum.Models {
    public interface IMessageRepository {
        IQueryable<Message> Messages { get; }
        public void AddMessage(Message message);
        public void DeleteMessage(int messageId);
    }
}
