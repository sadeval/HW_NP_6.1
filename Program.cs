using System;
using System.Net;
using System.Net.Mail;

namespace SMTPMailSender
{
    class Program
    {
        static void Main()
        {
            // Настройки SMTP для Gmail
            string smtpServer = "smtp.gmail.com";
            int smtpPort = 587; // Порт для TLS
            string smtpUser = "sadeval2011@gmail.com"; // Ваша почта Gmail
            string smtpPass = "soab pnyc ilsn sgnh"; // Пароль приложения (не основной пароль)

            // Данные письма
            string fromEmail = "sadeval2011@gmail.com";
            string subject = "Test Email with Attachment";
            string body = "This is a test email with attachment sent to multiple recipients.";

            // Список получателей
            string[] recipients = new string[]
            {
                "recipient1@example.com",
                "recipient2@example.com",
                "recipient3@example.com"
            };

            // Путь к файлу для вложения
            string attachmentFilePath = @"D:\transactions.json"; // Укажите путь к вашему файлу

            try
            {
                // Создаем клиент для отправки через SMTP
                using (SmtpClient client = new SmtpClient(smtpServer, smtpPort))
                {
                    client.Credentials = new NetworkCredential(smtpUser, smtpPass);
                    client.EnableSsl = true; // Включить SSL

                    // Создаем сообщение
                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress(fromEmail);
                    mailMessage.Subject = subject;
                    mailMessage.Body = body;

                    // Добавляем получателей
                    foreach (var recipient in recipients)
                    {
                        mailMessage.To.Add(recipient);
                    }

                    // Добавляем вложение
                    Attachment attachment = new Attachment(attachmentFilePath);
                    mailMessage.Attachments.Add(attachment);

                    // Отправляем письмо
                    client.Send(mailMessage);
                    Console.WriteLine("Email successfully sent to all recipients with attachment.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.ReadLine();
        }
    }
}
