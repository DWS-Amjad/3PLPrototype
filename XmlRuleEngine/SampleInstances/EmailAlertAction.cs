using System;
using System.Net.Mail;
using System.Xml.Serialization;
using ValidationRuleEngine;
using ValidationRuleEngine.Interfaces;

namespace SampleInstances
{
    [Serializable]
    [XmlRoot(ElementName = "action")]
    public class EmailAlertAction : IAction
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("executeOn")]
        public string executeOn { get; set; }

        #region Custom Properties
        [XmlElement("to")]
        public string To { get; set; }
        
        [XmlElement("from")]
        public string From { get; set; }

        [XmlElement("from_password")]
        public string From_password { get; set; }

        [XmlElement("subject")]
        public string Subject { get; set; }

        [XmlElement("successMessage")]
        public string SuccessMessage { get; set; }

        [XmlElement("failureMessage")]
        public string FailureMessage { get; set; }

        [XmlElement("smtp_host")]
        public string smtp_host { get; set; }

        [XmlElement("smtp_port")]
        public int smtp_port { get; set; }

        #endregion

        public bool Execute(Object obj)
        {
            IValidationContext context = (IValidationContext)obj;
            Console.WriteLine("Name of actionMethod : {0}", Name);
            SendEmail();
            return true;
        }

        public bool SendEmail()
        {
            bool retVal = true;
            try
            {
                String userName = this.From;//fromAddressUserName;
                String password = this.From_password;// setting.fromPassword;
                MailMessage msg = new MailMessage(this.From/*setting.fromAddress*/, this.To/*setting.toAddress*/);
                msg.Subject = this.Subject/*setting.Subject*/;
                msg.IsBodyHtml = true;
                msg.Body = this.executeOn.Equals(Constants.ExecuteOn.success) 
                    ? this.SuccessMessage
                    : this.FailureMessage/*setting.body*/;

                SmtpClient SmtpClient = new SmtpClient();
                SmtpClient.UseDefaultCredentials = false;
                SmtpClient.Credentials = new System.Net.NetworkCredential(userName, password);
                SmtpClient.Host = this.smtp_host/*setting.SMTP_Host*/;
                SmtpClient.Port = this.smtp_port/*setting.SMTP_Port*/;
                
                SmtpClient.EnableSsl = true;
                
                SmtpClient.Send(msg);
            }
            catch (Exception)
            {
                retVal = false;
                throw;
                //Logger.Instance.GetLogInstance().Error(JsonConvert.SerializeObject(ex));
            }
            return retVal;
        }
    }
}