using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace BusinessLogic.Tools
{
    public static class Tools
    {
        public static void SendMail(MailMessage mail)
        {
            SmtpClient smtpClient = new SmtpClient(ConfigurationManager.SmtpHost);
            smtpClient.Credentials = new NetworkCredential(ConfigurationManager.CredentialsUserName, ConfigurationManager.CredentialsPassword);
            smtpClient.Send(mail);
        }

        public static string SendToWebsite(string fileToUpload)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ConfigurationManager.FtpUri);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential(ConfigurationManager.CredentialsUserName, ConfigurationManager.CredentialsPassword);

            StreamReader sourceStream = new StreamReader(fileToUpload);
            byte[] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
            sourceStream.Close();
            request.ContentLength = fileContents.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(fileContents, 0, fileContents.Length);
            requestStream.Close();

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            string statusDescription = response.StatusDescription;

            response.Close();

            return statusDescription;
        }
    }
}