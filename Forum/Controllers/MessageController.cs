using Forum.Models;
using Forum.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Forum.Controllers {
    public class MessageController : Controller {
        private IMessageRepository repository;
        public MessageController(IMessageRepository repo) => repository = repo;
        public IActionResult List() => View(new MessageListViewModel { Messages = repository.Messages.OrderBy(o => o.createdTime) });
        public IActionResult DeleteMessage(int messageId) {
            repository.DeleteMessage(messageId);
            return RedirectToAction("List");
        }
        public IActionResult AddMessage(Message message) {
            repository.AddMessage(message);
            return RedirectToAction("List");
        }

    }
}
