using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Utility
{
    public static class Email
    {
        public static void SendMail(string to, string subject, string mailContent)
        {
            try
            {
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("managecondo.app@gmail.com", "ManageCondoApp3");
                smtp.Timeout = 30000;

                MailMessage message = new MailMessage();
                message.To.Add(to);
                message.From = new MailAddress("managecondo.app@gmail.com");
                message.Subject = subject;
                message.Body = mailContent;
                smtp.Send(message);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
