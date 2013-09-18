using Softox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Softox.Controllers
{
    public class ToolsController : Controller
    {
        [HttpPost]
        public void SendMail(MailModel model)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("Softox");
            mail.To.Add("romain.parage@gmail.com");
            mail.Subject = "Contact : " + model.Email;
            mail.Body = model.Message;

            SmtpServer.Send(mail);
        }
    }
}