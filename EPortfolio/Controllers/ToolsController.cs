using System.Net.Mail;
using System.Web.Mvc;
using EPortfolio.Models;

namespace EPortfolio.Controllers
{
    using System.Net;

    public class ToolsController : Controller
    {
        [HttpPost]
        public void SendContactMail(MailModel model)
        {
            var mail = new MailMessage();
            mail.From = new MailAddress("softox@rparage.fr");
            mail.To.Add("romain.parage@gmail.com");
            mail.Subject = "Prise de contact : " + model.Email;
            mail.Body = model.Message;

            SendMail(mail);
        }

        public static void SendMail(MailMessage mail)
        {
            var smtpClient = new SmtpClient("");
            smtpClient.Credentials = new NetworkCredential("", "");
            smtpClient.Send(mail);
        }
    }
}