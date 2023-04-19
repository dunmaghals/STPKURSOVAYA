using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;
using System.Globalization;
using System.Text.RegularExpressions;

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
                MessageBox.Show("Отправка прошла успешно!");
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
        public static void SendFile(string userName, string adressTo, string messageSubject, string messageText, params string[] file)
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
                for (int i = 0; i < file.Length; i++)
                {
                    if (file[i]!=null)
                    mess.Attachments.Add(new Attachment(file[i]));
                }
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
                MessageBox.Show("Отправка прошла успешно!");
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
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
    }
}
