using System;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Threading;

namespace sendMail
{
    #region send mail
    class sendAnEmail
    {
        /*the thread that from it we send the mail*/
        public void mailThread()
        {
            Thread th = new Thread(checkAndSend);
            th.Start();
        }

        /*sends ping to google & if it succed sends the email*/
        public void checkAndSend()
        {
            while (true)
            {
                Thread.Sleep(2000);

                try
                {
                    if (new System.Net.NetworkInformation.Ping().Send("google.com").Status == IPStatus.Success)
                    {
                        sendingTheMail();
                        break;
                    }
                }
                /*exceptions*/
                catch (ArgumentNullException ex)
                {
                    throw ex;
                }
                catch (ArgumentException ex)
                {
                    throw ex;
                }

                catch (SmtpFailedRecipientsException ex)
                {
                    throw ex;
                }
                catch (InvalidOperationException ex)
                {
                    throw ex;
                }

                catch (SmtpException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
       
        /*send the email*/
        public void sendingTheMail()
        {

                var client = new SmtpClient("smtp.gmail.com", 587)
                {
                    /*here you nees to enter your mail address and password*/
                    Credentials = new NetworkCredential("zimmerisrael123@gmail.com", "Aa12345678910"),
                    EnableSsl = true
                };

                 /*here you nees to enter your mail address and the destination mail address*/
            using (var message = new MailMessage("zimmerisrael123@gmail.com", "josef.gedalyahu@gmail.com")
                {
                    Subject = textSubject,
                    Body = textBody
                })
                {
                    {
                        client.Send(message);
                    }
                }
        }

        /*here you need to type the mail body:*/
        public string textBody = "Hellow world! \n this is an email from C#!! ";
      
        /*here you need to type the mail subject:*/
        public string textSubject = @"mail from c#";

        #endregion

        static void Main(string[] args)
        {
            sendAnEmail SE = new sendAnEmail();
            SE.mailThread();
        }
    }
}
