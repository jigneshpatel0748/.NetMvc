using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;

namespace JigneshPractical.Utilis
{
    public class MailUstils
    {
        public static string GetConfigValue(string stConfigKeyName)
        {
            string stConfigValue = System.Configuration.ConfigurationManager.AppSettings[stConfigKeyName];
            return stConfigValue;
        }
        public static string SendMail(string stSubject, string stHtmlBody, string stToEmailAddresses)
        {
            string stReturnText = string.Empty;
            string CCEmailAddress = "";
            string BCCEmailAddress = "";
            StringBuilder sbHTML = new StringBuilder();

            sbHTML.Append(stHtmlBody);

            string stFromUserName = GetConfigValue("FromEmailID");
            string stFromPassword = GetConfigValue("FromPassword");
            string FromMail = GetConfigValue("FromMail");
            int inPort = 587;
            string stHost = "smtp.gmail.com";
            bool btIsSSL = true;

            MailMessage objEmail = new MailMessage();
            MailAddress from = new MailAddress("\"" + FromMail + "\" " + stFromUserName);
            objEmail.From = from;

            if (stToEmailAddresses.Contains(","))
            {
                string[] EmailIDs = stToEmailAddresses.Split(',');
                int i;
                for (i = 0; i < EmailIDs.Length; i++)
                {
                    if (EmailIDs[i].Contains("@") == true && EmailIDs[i].Contains(".") == true)
                    {
                        objEmail.To.Add(EmailIDs[i]);
                    }
                }
            }
            else
            {
                if (stToEmailAddresses.Contains("@") == true && stToEmailAddresses.Contains(".") == true)
                {
                    objEmail.To.Add(stToEmailAddresses);
                }
            }

            objEmail.Subject = stSubject;
            objEmail.Body = sbHTML.ToString();

            if (CCEmailAddress.Contains(","))
            {
                string[] CCEmailIDs = CCEmailAddress.Split(',');
                int i;
                for (i = 0; i < CCEmailIDs.Length; i++)
                {
                    if (CCEmailIDs[i].Contains("@") == true && CCEmailIDs[i].Contains(".") == true)
                    {
                        objEmail.CC.Add(CCEmailIDs[i]);
                    }
                }
            }
            else
            {
                if (CCEmailAddress.Contains("@") == true && CCEmailAddress.Contains(".") == true)
                {
                    objEmail.CC.Add(CCEmailAddress);
                }
            }

            objEmail.IsBodyHtml = true;
            objEmail.Priority = MailPriority.High;

            if (BCCEmailAddress != "")
            {
                string[] staBCCMails = BCCEmailAddress.Split(';');
                foreach (string stBccID in staBCCMails)
                {
                    if (!string.IsNullOrEmpty(stBccID.Trim()))
                    {
                        objEmail.Bcc.Add(stBccID.Trim());
                    }
                }
            }

            SmtpClient client = new SmtpClient();
            System.Net.NetworkCredential auth = new System.Net.NetworkCredential(stFromUserName, stFromPassword);
            client.Host = stHost;
            client.Port = inPort;
            client.UseDefaultCredentials = true;
            client.Credentials = auth;
            client.EnableSsl = btIsSSL;
            ServicePointManager.ServerCertificateValidationCallback =
               delegate (object s, X509Certificate certificate,
                   X509Chain chain, SslPolicyErrors sslPolicyErrors)
               { return true; };
            client.Send(objEmail);

            return stReturnText;
        }
    }
}