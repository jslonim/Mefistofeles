using Mefistofeles.PageObjects.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Mefistofeles.Config
{
    static class MefistofelesUtils
    {
        public static DateTime ConvertToArgentinaTime(DateTime matchDttm)
        {
            matchDttm = TimeZoneInfo.ConvertTimeToUtc(matchDttm, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));
            TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Argentina Standard Time");
            return TimeZoneInfo.ConvertTimeFromUtc(matchDttm, cstZone);
        }

        public static void SendExceptionEmail(string error, SportsEnum sport)
        {
            MailMessage mail = new MailMessage("mefisto.betting@gmail.com","slonim.julian@gmail.com");
            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "smtp.gmail.com";
            mail.Subject = "Error in the process.";
            mail.Body = "The error is: " + error + "In the sport: " + sport.ToString();
            client.Send(mail);
        }
    }
}
