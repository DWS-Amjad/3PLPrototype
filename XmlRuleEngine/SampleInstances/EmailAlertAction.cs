using System;
using System.Xml.Serialization;
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
                Console.WriteLine("Stay Tuned Folks: EmailAlertAction To be implemented soon");
                /*String userName = this.From;
                String password = this.From_password;
                MailMessage msg = new MailMessage(this.From, this.To);
                msg.Subject = this.Subject;
                msg.IsBodyHtml = true;
                msg.Body = this.executeOn.Equals(Constants.ExecuteOn.success) 
                    ? this.SuccessMessage
                    : this.FailureMessage;

                SmtpClient SmtpClient = new SmtpClient();
                SmtpClient.UseDefaultCredentials = false;
                SmtpClient.Credentials = new System.Net.NetworkCredential(userName, password);
                SmtpClient.Host = this.smtp_host;
                SmtpClient.Port = this.smtp_port;
                
                SmtpClient.EnableSsl = true;
                
                SmtpClient.Send(msg);*/
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