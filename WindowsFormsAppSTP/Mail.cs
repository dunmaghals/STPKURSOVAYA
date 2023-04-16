using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;

namespace WindowsFormsAppSTP
{
    internal class Mail
    {
        public static void SendMessage(string userName, string adressTo, string messageSubject, string messageText)
        {
            try
            {
                string from = @"Dgecka749@mail.ru"; // адреса отправителя
                string pass = "LHc4tnxDTsgdNXn5Pmvi"; // пароль отправителя
                MailMessage mess = new MailMessage();
                mess.To.Add(adressTo); // адрес получателя
                mess.From = new MailAddress(from);
                mess.Subject = messageSubject; // тема
                mess.Body = messageText; // текст сообщения
                SmtpClient client = new SmtpClient();
                client.Host = "smtp.mail.ru"; //smtp-сервер отправителя
                client.Port = 587;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(from.Split('@')[0], pass);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(mess); // отправка пользователю
                mess.To.Remove(mess.To[0]);
                mess.To.Add(from); //для сообщения на свой адрес
                mess.Subject = "Отправлено сообщение";
                mess.Body = "Пользователю " + userName + " отправлено сообщение";
                client.Send(mess); // отправка себе
                mess.Dispose();
            }
            catch (Exception e)
            {
                try
                {
                    throw new Exception("Mail.Send: " + e.Message);
                }
                catch 
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
        public static void SendFile(string userName, string adressTo, string messageSubject, string messageText, string file)
        {
            try
            {
                string from = @"Dgecka749@mail.ru"; // адреса отправителя
                string pass = "LHc4tnxDTsgdNXn5Pmvi"; // пароль отправителя
                MailMessage mess = new MailMessage();
                mess.To.Add(adressTo); // адрес получателя
                mess.From = new MailAddress(from);
                mess.Subject = messageSubject; // тема
                mess.Body = messageText; // текст сообщения
                mess.Attachments.Add(new Attachment(file));
                SmtpClient client = new SmtpClient();
                client.Host = "smtp.mail.ru"; //smtp-сервер отправителя
                client.Port = 587;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(from.Split('@')[0], pass);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(mess); // отправка пользователю
                mess.To.Remove(mess.To[0]);
                mess.To.Add(from); //для сообщения на свой адрес
                mess.Subject = "Отправлено сообщение";
                mess.Body = "Пользователю " + userName + " отправлено сообщение";
                client.Send(mess); // отправка себе
                mess.Dispose();
            }
            catch (Exception e)
            {
                try
                {
                    throw new Exception("Mail.Send: " + e.Message);
                }
                catch
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
    }
}
