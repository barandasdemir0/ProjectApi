using HotelProject.WebUI.Models.Mail;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace HotelProject.WebUI.Controllers
{
    public class AdminMailController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index( AdminMailViewModel adminMail)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("Yazılım Hotel", "ebtuyou1@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", adminMail.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);


            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = adminMail.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();



            mimeMessage.Subject = adminMail.Subject;
            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("ebtuyou1@gmail.com", "kurzpwyuuaybvfzf");
            client.Send(mimeMessage);
            client.Disconnect(true);
            return View();
        }
    }
}
