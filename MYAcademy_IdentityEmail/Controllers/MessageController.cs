using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MYAcademy_IdentityEmail.Context;
using MYAcademy_IdentityEmail.Entities;

namespace MYAcademy_IdentityEmail.Controllers
{
    public class MessageController : Controller
    {
        private readonly EmailContext _context;
        private readonly UserManager<AppUser> _userManager;
        public MessageController(EmailContext context)
        {
            _context = context;
        }

        public IActionResult Inbox()
        {
            var values = _context.Messages.ToList();
            return View(values);
        }
        public async Task<IActionResult> Sendbox()
        {
            var value = await _userManager.GetUserAsync(User);

            var messageList = _context.Messages.Where(x=> x.SenderEmail == value.Email).ToList();

            return View(messageList);
        }
        public IActionResult CreateMessage()
        {
            return View();
        }
    }
}
