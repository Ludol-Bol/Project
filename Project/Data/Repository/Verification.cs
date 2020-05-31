using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace Project.Data.Repository
{// класс для подтверждения почты 
    public class Verification
    {

        string email { get; set; }// почта 
        public Verification(string email)
        {
            this.email = email;
        }

        public Verification()
        {
            email = null;
        }

        public long Sendletter()// письмо для подтверждения регистрации 
        {
            Random random = new Random();
            long codeforReg = random.Next(1000, 9999);
            MailMessage mail = new MailMessage();
            MailAddress from = new MailAddress("testsystems@inbox.ru", "Школа Дистанционного образования");
            MailAddress to = new MailAddress(email);
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Регистрация";
            string strokingo = "Рады вас видеть, код регистрации:";
            m.Body = "<h2>Добро пожаловать!</h2>" + "\n" + strokingo +codeforReg.ToString();
            m.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.inbox.ru", 2525);
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("testsystems@inbox.ru", "F12r4!564");
            smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            smtp.Send(m);
            smtp.Timeout = 5000;
            return codeforReg;
        }

        public void Notification(List<string> maspupem)// письмо уведомление о добавлении нового урока
        {
            MailMessage mail = new MailMessage();
            MailAddress from = new MailAddress("testsystems@inbox.ru", "Школа Дистанционного образования");
            for (int i = 0; i < maspupem.Count; i++)
            {
                MailAddress to = new MailAddress(maspupem[i]);
                MailMessage m = new MailMessage(from, to);
                m.Subject = "Вам пришло письмо";
                string strokingo = "Открылся новый урок";
                m.Body =  strokingo;
                m.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient("smtp.inbox.ru", 2525);
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("testsystems@inbox.ru", "F12r4!564");
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.Send(m);
                smtp.Timeout = 5000;
            }
        }
    }
}
