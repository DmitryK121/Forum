using System;
using System.Linq;

namespace Forum.Models {
    public class EFMessageRepository : IMessageRepository {
        private ApplicationDbContext context;
        public EFMessageRepository(ApplicationDbContext ctx) => context = ctx;
        public IQueryable<Message> Messages => context.Messages;
        public void AddMessage(Message message) {
            Message dbmes = new Message { content = message.content, createdTime = DateTime.Now, userId = 0, theme = message.theme };
            context.Messages.Add(dbmes);
            context.SaveChanges();
        }
        public void DeleteMessage(int messageId) {
            context.Messages.Remove(context.Messages.FirstOrDefault(m => m.messageId == messageId));
            context.SaveChanges();
        }
    }
}
