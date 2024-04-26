using Microsoft.AspNetCore.Mvc;
using MyPortfolioProject.DAL.Context;

namespace MyPortfolioProject.ViewComponents
{
    public class UnreadMessageList:ViewComponent
    {
        private readonly AppDbContext _context;

        public UnreadMessageList(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            // Okunmamis mesajlar bildirim kisminda listelenecek.
            var unreadMessages=_context.Messages.Where(x => x.IsRead == false).ToList();
            ViewBag.UnreadMessagesCount=unreadMessages.Count;
            return View(unreadMessages);
        }
    }
}
