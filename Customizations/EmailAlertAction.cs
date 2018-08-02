using Newtonsoft.Json;
using System;
using System.Linq;
using System.Xml.Serialization;
using ValidationRuleEngine;
using ValidationRuleEngine.Interfaces;

namespace Customizations
{
    [Serializable]
    [XmlRoot(ElementName = "action")]
    public class EmailAlertAction : ValidationRuleEngine.Implementations.Action
    {
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Execute(Object obj)
        {
            IValidationContext context = (IValidationContext)obj;
            Console.WriteLine("Name of actionMethod : {0}", base.Name);
            return SendEmail();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool SendEmail()
        {
            bool retVal = true;
            try
            {
                //Console.WriteLine("Stay Tuned Folks: EmailAlertAction To be implemented soon");

                var fromEmail = this.LocalAttributes
                    .Where(item => item.name == Constants.EmailAction_CustomFields.from)
                    .First<ValidationRuleEngine.Configuration.Attribute>().value;

                var toEmail = this.LocalAttributes
                    .Where(item => item.name == Constants.EmailAction_CustomFields.to)
                    .First<ValidationRuleEngine.Configuration.Attribute>().value;

                var subject = this.LocalAttributes
                    .Where(item => item.name == Constants.EmailAction_CustomFields.subject).First<ValidationRuleEngine.Configuration.Attribute>().value; ;

                if (String.IsNullOrEmpty(fromEmail) || String.IsNullOrEmpty(toEmail))
                {
                    retVal = false;
                }
                else
                {
                    var message = this.LocalAttributes
                                .Where(item => item.name == Constants.EmailAction_CustomFields.message)
                                .First<ValidationRuleEngine.Configuration.Attribute>().value; ;
                    //var smtp = new Smtp();
                    //var email = new SMTP.MailMessage()
                    //{
                    //    EmailFrom = fromEmail,
                    //    EmailSubject = subject,
                    //    EmailMessage = message,
                    //    DisplayName = this.LocalAttributes
                    //              .Where(item => item.name == Constants.EmailAction_CustomFields.displayName)
                    //              .First<Attribute>().value;
                    //};

                    //foreach (var emailAddress in toEmail.Split(';'))
                    //{
                    //  if (String.IsNullOrEmpty(emailAddress))
                    //  {
                    //      email.AddEmailTo(emailAddress);
                    //  } 
                    //}

                    //try
                    //{
                    //    smtp.SendEmail(email);
                    //}
                    //catch (Exception ex)
                    //{
                    //    retVal = false;
                    //    Logger.Instance.GetLogInstance().Error(JsonConvert.SerializeObject(ex));
                    //}
                }
            }
            catch (Exception ex)
            {
                retVal = false;
                Logger.Instance.GetLogInstance().Error(JsonConvert.SerializeObject(ex));
            }
            return retVal;
        }
    }
}