using System.Net;
using System.Net.Mail;

namespace BusinessLogic.Tools
{
    public static class Tools
    {
        public static void SendMail(MailMessage mail)
        {
            SmtpClient smtpClient = new SmtpClient(ConfigurationManager.SmtpClientHost);
            smtpClient.Credentials = new NetworkCredential(ConfigurationManager.SmtpClientUserName, ConfigurationManager.SmtpClientPassword);
            smtpClient.Send(mail);
        }
    }
}