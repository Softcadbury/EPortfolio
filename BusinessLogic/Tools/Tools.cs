using System.Net;
using System.Net.Mail;

namespace BusinessLogic.Tools
{
    public static class Tools
    {
        public static void SendMail(MailMessage mail)
        {
            SmtpClient SmtpServer = new SmtpClient("smtpClinet");
            SmtpServer.Credentials = new NetworkCredential("address", "mdp");
            SmtpServer.Send(mail);
        }
    }
}