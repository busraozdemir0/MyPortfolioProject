using Microsoft.AspNetCore.Mvc;
using MyPortfolioProject.DAL.Context;

namespace MyPortfolioProject.ViewComponents
{
    public class UnreadMessageList:ViewComponent
    {
        AppDbContext _context=new AppDbContext();
        public IViewComponentResult Invoke()
        {
            // Okunmamis mesajlar bildiirm kisminda listelenecek.
            var unreadMessages=_context.Messages.Where(x => x.IsRead == false).ToList();
            ViewBag.UnreadMessagesCount=unreadMessages.Count;
            return View(unreadMessages);
        }
    }
}
