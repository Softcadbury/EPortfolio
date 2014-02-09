using BusinessLogic.Tools;
using EPortfolio.Models;
using System.Net.Mail;
using System.Web.Mvc;

namespace EPortfolio.Controllers
{
    public class ToolsController : Controller
    {
        [HttpPost]
        public void SendContactMail(MailModel model)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("softox@rparage.fr");
            mail.To.Add("romain.parage@gmail.com");
            mail.Subject = "Prise de contact : " + model.Email;
            mail.Body = model.Message;

            EmailSender.SendMail(mail);
        }
    }
}