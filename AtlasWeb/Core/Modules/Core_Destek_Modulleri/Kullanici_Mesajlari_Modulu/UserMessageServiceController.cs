//$E802F646
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using System.Collections.Generic;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using System.Text;
using System.Net;
using System.IO;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using Core.Security;
using TTUtils;
using Infrastructure.Helpers;
using System.Threading.Tasks;
using SmsApi.Types;
using SmsApi;
using AtlasSmsManager;
using Microsoft.AspNetCore.Http;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public partial class UserMessageServiceController : Controller
    {
        public class SendMessageInternalWithResUserV3_Input
        {
            public System.Collections.Generic.IList<TTObjectClasses.ResUser> toUsers
            {
                get;
                set;
            }

            public string subject
            {
                get;
                set;
            }

            public object pBody
            {
                get;
                set;
            }

            public bool? isSystemMessage
            {
                get;
                set;
            }

            public TTObjectClasses.Patient patient
            {
                get;
                set;
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public void SendMessageInternalWithResUserV3(SendMessageInternalWithResUserV3_Input input)
        {
            using (var context = new TTObjectContext(false))
            {
                if (input.patient != null)
                    input.patient = (TTObjectClasses.Patient)context.AddObject(input.patient);
                UserMessage.SendMessageInternalWithResUserV3(context, input.toUsers, input.subject, input.pBody, input.isSystemMessage, input.patient);
                context.FullPartialllyLoadedObjects();
            }
        }

        public class SendSMSInternalforCustom
        {
            public System.Collections.Generic.IList<string> numbers
            {
                get;
                set;
            }

            public string text
            {
                get;
                set;
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public void SendSMSCustom(SendSMSInternalforCustom input)
        {
            for (int i = 0; i < input.numbers.Count; i++)
            {
                SendSMSInternal sms = new SendSMSInternal();
                sms.text = input.text;
                sms.number = input.numbers[i];
                SendSMS(sms);
            }
        }

        public class SendSMSInternalforPatients
        {
            public System.Collections.Generic.IList<TTObjectClasses.Patient> patients
            {
                get;
                set;
            }

            public string text
            {
                get;
                set;
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public bool SendSMSPerson(ResUser user, string message)
        {
            // SUBMIT
            // Birden çok numraya aynı mesaj içeriği gönderilmesini sağlar.
            // Birden çok numaraya farklı içerik göndermek için SUBMITMULTI kullanmanız gerekir. 

            // messenger objesi
            var messenger = new Messenger(TTObjectClasses.SystemParameter.GetParameterValue("SMSUSERNAME", "XXXXXX"),
                TTObjectClasses.SystemParameter.GetParameterValue("SMSPASSWORD", "XXXXXX"));

            /////////////////////////////////////////
            // değişkenleri tanımlayalım.
            /////////////////////////////////////////

            // gönderilecek mesaj içeriği
            // [ZORUNLU]
            var mesaj = message;
            // telefon numaraları
            // [ZORUNLU]
            var list = new List<string>();
            list.Add(user.PhoneNumber);

            // başlık, ileri tarihli gönderim, geçerlilik süresi
            var header = new Header
            {
                //Gönderen Adı / Başlık 
                //[ZORUNLU]
                From = TTObjectClasses.SystemParameter.GetParameterValue("SMSTITLE", "GAZİLER FTR"),

            };


            // Mesajı gönderip değişkene atayalım.
            var msgObj = messenger.Submit(mesaj, list, header, DataCoding.Default);

            /////////////////////////////////////////
            // gelen cevaplar ve anlamları.
            /////////////////////////////////////////

            // Status.
            // Code ve Desc alanları yer alır. Mesajın sisteme başarılı şekilde gönderilip gönderilmediği bilgisini verir.
            // Code = 200 ve Description = OK ise mesaj sisteme başarılı şekilde ulaşmıştır. Bu mesajın iletim durumu değildir.
            // Alabileceği değerler için dokümana bakınız.
            var statusCode = msgObj.Response.Status.Code;
            var statusDesc = msgObj.Response.Status.Description;
            if (statusCode == 200 && statusDesc == "OK")
            {
                return true;
            }
            else
                return false;

            // MessageId
            // Sistemden rapor alınması için geri dönen mesaj numarasıdır.
            var msgId = msgObj.Response.MessageId;

        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public void SendSMSPatients(SendSMSInternalforPatients input)
        {
            for (int i = 0; i < input.patients.Count; i++)
            {
                SendSMSInternal sms = new SendSMSInternal();
                sms.text = input.text;
                sms.number = input.patients[i].PatientAddress.MobilePhone;
                SendSMS(sms);
            }
        }

        public class SendSMSInternalforPersons
        {
            public System.Collections.Generic.IList<TTObjectClasses.ResUser> persons
            {
                get;
                set;
            }

            public string text
            {
                get;
                set;
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public void SendSMSPersons(SendSMSInternalforPersons input)
        {
            for (int i = 0; i < input.persons.Count; i++)
            {
                SendSMSInternal sms = new SendSMSInternal();
                sms.text = input.text;
                sms.number = input.persons[i].PhoneNumber;
                SendSMS(sms);
            }
        }

        private class SendSMSInternal
        {
            public string number
            {
                get;
                set;
            }

            public string text
            {
                get;
                set;
            }
        }

        private void SendSMS(SendSMSInternal input)
        {
            SmsManager.Instance.SendSms(new AtlasSMS() { Number = input.number, Text = input.text });
        }
        public class SendMailInternalforCustom
        {
            public System.Collections.Generic.IList<string> mail
            {
                get;
                set;
            }

            public string body
            {
                get;
                set;
            }

            public string subject
            {
                get;
                set;
            }
        }

        [HttpPost]
        public void SendMailCustom(SendMailInternalforCustom input)
        {
            for (int i = 0; i < input.mail.Count; i++)
            {
                SendMailInternal mail = new SendMailInternal();
                mail.mail = input.mail[i];
                mail.body = input.body;
                mail.subject = input.subject;
                SendMail(mail);
            }
        }

        public class SendMailInternalforPatients
        {
            public System.Collections.Generic.IList<TTObjectClasses.Patient> patients
            {
                get;
                set;
            }

            public string body
            {
                get;
                set;
            }

            public string subject
            {
                get;
                set;
            }
        }

        [HttpPost]
        public void SendMailForPatients(SendMailInternalforPatients input)
        {
            for (int i = 0; i < input.patients.Count; i++)
            {
                SendMailInternal mail = new SendMailInternal();
                mail.mail = input.patients[i].EMail;
                mail.body = input.body;
                mail.subject = input.subject;
                SendMail(mail);
            }
        }

        public class SendMailInternalforPersons
        {
            public System.Collections.Generic.IList<TTObjectClasses.ResUser> persons
            {
                get;
                set;
            }

            public string body
            {
                get;
                set;
            }

            public string subject
            {
                get;
                set;
            }
        }

        [HttpPost]
        public void SendMailForPersons(SendMailInternalforPersons input)
        {
            for (int i = 0; i < input.persons.Count; i++)
            {
                SendMailInternal mail = new SendMailInternal();
                mail.mail = input.persons[i].EMail;
                mail.body = input.body;
                mail.subject = input.subject;
                SendMail(mail);
            }
        }

        private class SendMailInternal
        {
            public string mail
            {
                get;
                set;
            }

            public string body
            {
                get;
                set;
            }

            public string subject
            {
                get;
                set;
            }
        }

        private void SendMail(SendMailInternal input)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(TTObjectClasses.SystemParameter.GetParameterValue("MAILSMTP", "smtp.gmail.com"));
                mail.From = new MailAddress(TTObjectClasses.SystemParameter.GetParameterValue("MAILADDRESS", ""));
                mail.To.Add(input.mail);
                mail.Subject = input.subject;
                mail.Body = input.body;
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(TTObjectClasses.SystemParameter.GetParameterValue("MAILUSERNAME", "XXXXXX"), TTObjectClasses.SystemParameter.GetParameterValue("MAILPASSWORD", "XXXXXX"));
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
            }
            catch
            {
            }
        }

        public class SendMessageInternalWithResUserV2_Input
        {
            public System.Collections.Generic.IList<TTObjectClasses.ResUser> toUsers
            {
                get;
                set;
            }

            public string subject
            {
                get;
                set;
            }

            public object pBody
            {
                get;
                set;
            }

            public bool? isSystemMessage
            {
                get;
                set;
            }
        }

        [HttpPost]
        public void SendMessageInternalWithResUserV2(SendMessageInternalWithResUserV2_Input input)
        {
            using (var context = new TTObjectContext(false))
            {
                UserMessage.SendMessageInternalWithResUserV2(context, input.toUsers, input.subject, input.pBody, input.isSystemMessage);
                context.FullPartialllyLoadedObjects();
            }
        }

        public class SendMessageInternalWithResUser_Input
        {
            public System.Collections.Generic.IList<TTObjectClasses.ResUser> toUsers
            {
                get;
                set;
            }

            public string subject
            {
                get;
                set;
            }

            public object pBody
            {
                get;
                set;
            }
        }

        [HttpPost]
        public void SendMessageInternalWithResUser(SendMessageInternalWithResUser_Input input)
        {
            using (var context = new TTObjectContext(false))
            {
                UserMessage.SendMessageInternalWithResUser(context, input.toUsers, input.subject, input.pBody);
                context.FullPartialllyLoadedObjects();
            }
        }

        public class SendMessageInternalWithResUserV4_Input
        {
            public System.Collections.Generic.IList<TTObjectClasses.ResUser> toUsers
            {
                get;
                set;
            }

            public string subject
            {
                get;
                set;
            }

            public object pBody
            {
                get;
                set;
            }

            public System.Guid reportDefID
            {
                get;
                set;
            }
            public object attachments
            {
                get;
                set;
            }
        }

        [HttpPost]
        public void SendMessageInternalWithResUserV4(SendMessageInternalWithResUserV4_Input input)
        {
            using (var context = new TTObjectContext(false))
            {
                UserMessage.SendMessageInternalWithResUserV4(context, input.toUsers, input.subject, input.pBody, input.reportDefID);
                context.FullPartialllyLoadedObjects();
            }
        }

        public class SendMessageInternalV3_Input
        {
            public System.Collections.Generic.IList<string> toUsers
            {
                get;
                set;
            }

            public string subject
            {
                get;
                set;
            }

            public object pBody
            {
                get;
                set;
            }

            public bool? isSystemMessage
            {
                get;
                set;
            }

            public TTObjectClasses.Patient patient
            {
                get;
                set;
            }
        }

        [HttpPost]
        public void SendMessageInternalV3(SendMessageInternalV3_Input input)
        {
            using (var context = new TTObjectContext(false))
            {
                if (input.patient != null)
                    input.patient = (TTObjectClasses.Patient)context.AddObject(input.patient);
                UserMessage.SendMessageInternalV3(context, input.toUsers, input.subject, input.pBody, input.isSystemMessage, input.patient);
                context.FullPartialllyLoadedObjects();
            }
        }

        public class SendMessageInternalWithGroupsV3_Input
        {
            public System.Collections.Generic.IList<string> toUsers
            {
                get;
                set;
            }

            public System.Collections.Generic.IList<string> userMessageGroups
            {
                get;
                set;
            }

            public string subject
            {
                get;
                set;
            }

            public object pBody
            {
                get;
                set;
            }

            public bool? isSystemMessage
            {
                get;
                set;
            }

            public bool? messageFeedback
            {
                get;
                set;
            }

            public TTObjectClasses.Patient patient
            {
                get;
                set;
            }
        }

        [HttpPost]
        public void SendMessageInternalWithGroupsV3(SendMessageInternalWithGroupsV3_Input input)
        {
            using (var context = new TTObjectContext(false))
            {
                if (input.patient != null)
                    input.patient = (TTObjectClasses.Patient)context.AddObject(input.patient);
                UserMessage.SendMessageInternalWithGroupsV3(context, input.toUsers, input.userMessageGroups, input.subject, input.pBody, input.isSystemMessage, input.messageFeedback, input.patient);
                context.FullPartialllyLoadedObjects();
            }
        }

        public class SendMessageInternalWithGroupsV4_Input
        {
            public IList<FormFile> Attachments { get; set; }

            public System.Collections.Generic.IList<string> toUsers
            {
                get;
                set;
            }

            public System.Collections.Generic.IList<string> userMessageGroups
            {
                get;
                set;
            }

            public string subject
            {
                get;
                set;
            }

            public object pBody
            {
                get;
                set;
            }

            public bool? isSystemMessage
            {
                get;
                set;
            }

            public bool? messageFeedback
            {
                get;
                set;
            }

            public Guid? ObjectID
            {
                get;
                set;
            }

            public TTObjectClasses.Patient patient
            {
                get;
                set;
            }

            public bool? isSplashMessage
            {
                get;
                set;
            }

            public System.DateTime? expireDate
            {
                get;
                set;
            }
        }

        [HttpPost]
        public Guid OnOKClickInternal(SendMessageInternalWithGroupsV4_Input input)
        {
            UserMessage theMessage = null;
            using (var context = new TTObjectContext(false))
            {
                Guid savePoint = context.BeginSavePoint();
                //if (this.m_savedMessageID == null)
                theMessage = new UserMessage(context);
                //else
                //    theMessage = (UserMessage)context.GetObject(this.m_savedMessageID.Value, "UserMessage");
                theMessage.InitializeUnSentMessage();
                Guid userID = new Guid(input.toUsers[0]);
                theMessage.ToUser = (ResUser)theMessage.ObjectContext.GetObject(userID, typeof(ResUser));
                //theMessage.ToUser = theMessage.Sender;//not implemented...YY
                theMessage.Subject = input.subject;
                theMessage.MessageBody = input.pBody;
                theMessage.IsSystemMessage = input.isSystemMessage;
                theMessage.MessageFeedback = input.messageFeedback;
                theMessage.Patient = input.patient;
                theMessage.ExpireDate = input.expireDate;

                theMessage.ValidateFields();
                theMessage.CheckErrorsEx();
                context.Save();
            }
            return theMessage.ObjectID;
        }

        [HttpPost]
        public Guid OnOKClickInternalV2(SendMessageInternalWithGroupsV4_Input input)
        {
            UserMessage theMessage;
            using (var context = new TTObjectContext(false))
            {
                Guid savePoint = context.BeginSavePoint();
                theMessage = context.GetObject<UserMessage>(input.ObjectID.Value);
                //if (this.m_savedMessageID == null)
                //theMessage = new UserMessage(context);
                //else
                //    theMessage = (UserMessage)context.GetObject(this.m_savedMessageID.Value, "UserMessage");
                //theMessage.InitializeUnSentMessage();
                Guid userID = new Guid(input.toUsers[0]);
                theMessage.ToUser = (ResUser)theMessage.ObjectContext.GetObject(userID, typeof(ResUser));
                //theMessage.ToUser = theMessage.Sender;//not implemented...YY
                theMessage.Subject = input.subject;
                theMessage.MessageBody = input.pBody;
                theMessage.MessageDate = Common.RecTime();
                theMessage.SenderStatus = MessageStatusEnum.NotSent;
                theMessage.ReceiverStatus = MessageStatusEnum.NotSent;
                theMessage.IsSystemMessage = input.isSystemMessage;
                theMessage.MessageFeedback = input.messageFeedback;
                theMessage.Patient = input.patient;
                theMessage.ExpireDate = input.expireDate;
                //List<UserMessageAttachment> att = new List<UserMessageAttachment>();

                theMessage.ValidateFields();
                theMessage.CheckErrorsEx();
                context.Save();
            }
            return theMessage.ObjectID;
        }

        [HttpPost]
        [DisableFormValueModelBinding]
        public Guid SendMessageInternalWithGroupsV4(SendMessageInternalWithGroupsV4_Input input)
        {
            Guid messageID = new Guid();
            using (var context = new TTObjectContext(false))
            {
                if (input.patient != null)
                    input.patient = (TTObjectClasses.Patient)context.AddObject(input.patient);
                List<UserMessageAttachment> att = new List<UserMessageAttachment>();

                messageID = UserMessage.SendMessageInternalWithGroupsV4(context, input.toUsers, input.userMessageGroups, input.subject, input.pBody, input.isSystemMessage, input.messageFeedback, input.patient, input.isSplashMessage, input.expireDate);
                context.FullPartialllyLoadedObjects();
            }
            return messageID;
        }
        public class GetUserMessageGroupsUser_Input
        {
            public List<string> Groups
            {
                get;
                set;
            }
        }

        [HttpPost]
        [DisableFormValueModelBinding]
        public List<string> GetUserMessageGroupsUser(GetUserMessageGroupsUser_Input input)
        {
            List<string> users = new List<string>();
            using (var context = new TTObjectContext(false))
            {
                users = UserMessage.GetUserMessageGroupsUser( input.Groups, context);
                context.FullPartialllyLoadedObjects();
            }
            return users;
        }


        [HttpPost]
        public Guid SendMessageInternalWithGroupsV5(SendMessageInternalWithGroupsV4_Input input)
        {
            Guid messageID;
            using (var context = new TTObjectContext(false))
            {
                if (input.patient != null)
                    input.patient = (TTObjectClasses.Patient)context.AddObject(input.patient);
                List<UserMessageAttachment> att = new List<UserMessageAttachment>();

                messageID = UserMessage.SendMessageInternalWithGroupsV5(context, input.toUsers, input.userMessageGroups, input.subject, input.pBody, input.isSystemMessage, input.messageFeedback, input.patient, input.isSplashMessage, input.expireDate, input.ObjectID);
                context.FullPartialllyLoadedObjects();
            }
            return messageID;
        }

        public class InputParam
        {
            public Guid ObjectID
            {
                get;
                set;
            }
            public string CurrentBox
            {
                get;
                set;
            }
        }

        [HttpPost]
        public void IsMessageRead(InputParam input)
        {
            using (var context = new TTObjectContext(false))
            {
                if (input != null)
                {
                    UserMessage.IsMessageRead(context, input.ObjectID);
                }
                context.FullPartialllyLoadedObjects();
            }
        }

        [HttpPost]
        public void DeleteMessage(InputParam input)
        {
            using (var context = new TTObjectContext(false))
            {
                UserMessage.DeleteMessage(context, input.ObjectID, input.CurrentBox);
                context.FullPartialllyLoadedObjects();
            }
        }

        public class SendMessageInternalV2_Input
        {
            public System.Collections.Generic.IList<string> toUsers
            {
                get;
                set;
            }

            public string subject
            {
                get;
                set;
            }

            public object pBody
            {
                get;
                set;
            }

            public bool? isSystemMessage
            {
                get;
                set;
            }
        }

        [HttpPost]
        public void SendMessageInternalV2(SendMessageInternalV2_Input input)
        {
            using (var context = new TTObjectContext(false))
            {
                UserMessage.SendMessageInternalV2(context, input.toUsers, input.subject, input.pBody, input.isSystemMessage);
                context.FullPartialllyLoadedObjects();
            }
        }

        public class SendMessageInternal_Input
        {
            public System.Collections.Generic.IList<string> toUsers
            {
                get;
                set;
            }

            public string subject
            {
                get;
                set;
            }

            public object pBody
            {
                get;
                set;
            }
        }

        [HttpPost]
        public void SendMessageInternal(SendMessageInternal_Input input)
        {
            using (var context = new TTObjectContext(false))
            {
                UserMessage.SendMessageInternal(context, input.toUsers, input.subject, input.pBody);
                context.FullPartialllyLoadedObjects();
            }
        }

        public class SendMessageInternalWithGroupsV2_Input
        {
            public System.Collections.Generic.IList<string> toUsers
            {
                get;
                set;
            }

            public System.Collections.Generic.IList<string> userMessageGroups
            {
                get;
                set;
            }

            public string subject
            {
                get;
                set;
            }

            public object pBody
            {
                get;
                set;
            }

            public bool? isSystemMessage
            {
                get;
                set;
            }

            public bool? messageFeedback
            {
                get;
                set;
            }
        }

        [HttpPost]
        public void SendMessageInternalWithGroupsV2(SendMessageInternalWithGroupsV2_Input input)
        {
            using (var context = new TTObjectContext(false))
            {
                UserMessage.SendMessageInternalWithGroupsV2(context, input.toUsers, input.userMessageGroups, input.subject, input.pBody, input.isSystemMessage, input.messageFeedback);
                context.FullPartialllyLoadedObjects();
            }
        }

        public class SendMessageInternalWithGroups_Input
        {
            public System.Collections.Generic.IList<string> toUsers
            {
                get;
                set;
            }

            public System.Collections.Generic.IList<string> userMessageGroups
            {
                get;
                set;
            }

            public string subject
            {
                get;
                set;
            }

            public object pBody
            {
                get;
                set;
            }
        }

        [HttpPost]
        public void SendMessageInternalWithGroups(SendMessageInternalWithGroups_Input input)
        {
            using (var context = new TTObjectContext(false))
            {
                UserMessage.SendMessageInternalWithGroups(context, input.toUsers, input.userMessageGroups, input.subject, input.pBody);
                context.FullPartialllyLoadedObjects();
            }
        }

        public class SendMessage_Input
        {
            public System.Collections.Generic.IList<TTObjectClasses.ResUser> toUsers
            {
                get;
                set;
            }

            public string subject
            {
                get;
                set;
            }

            public string bodyText
            {
                get;
                set;
            }

            public bool? isSystemMessage
            {
                get;
                set;
            }

            public TTObjectClasses.Patient patient
            {
                get;
                set;
            }
        }

        [HttpPost]
        public void SendMessage(SendMessage_Input input)
        {
            using (var context = new TTObjectContext(false))
            {
                if (input.patient != null)
                    input.patient = (TTObjectClasses.Patient)context.AddObject(input.patient);
                UserMessage.SendMessage(context, input.toUsers, input.subject, input.bodyText, input.isSystemMessage, input.patient);
                context.FullPartialllyLoadedObjects();
            }
        }

        public class SendMessageV2_Input
        {
            public System.Collections.Generic.IList<TTObjectClasses.ResUser> toUsers
            {
                get;
                set;
            }

            public string subject
            {
                get;
                set;
            }

            public string bodyText
            {
                get;
                set;
            }

            public bool? isSystemMessage
            {
                get;
                set;
            }
        }

        [HttpPost]
        public void SendMessageV2(SendMessageV2_Input input)
        {
            using (var context = new TTObjectContext(false))
            {
                UserMessage.SendMessageV2(context, input.toUsers, input.subject, input.bodyText, input.isSystemMessage);
                context.FullPartialllyLoadedObjects();
            }
        }

        public class SendMessageV3_Input
        {
            public System.Collections.Generic.IList<TTObjectClasses.ResUser> toUsers
            {
                get;
                set;
            }

            public string subject
            {
                get;
                set;
            }

            public string bodyText
            {
                get;
                set;
            }
        }

        [HttpPost]
        public void SendMessageV3(SendMessageV3_Input input)
        {
            using (var context = new TTObjectContext(false))
            {
                UserMessage.SendMessageV3(context, input.toUsers, input.subject, input.bodyText);
                context.FullPartialllyLoadedObjects();
            }
        }

        public class GetUserMessageByUserID_Input
        {
            public System.Guid userID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public System.Collections.Generic.List<TTObjectClasses.UserMessage> GetUserMessageByUserID(GetUserMessageByUserID_Input input)
        {
            var ret = UserMessage.GetUserMessageByUserID(input.userID);
            return ret;
        }

        public class GetUserInboxMessages_Input
        {
            public string TOUSER
            {
                get;
                set;
            }
            public DateTime StartDate
            {
                get;
                set;
            }
            public DateTime EndDate
            {
                get;
                set;
            }
            public string Mode
            {
                get;
                set;
            }

        }

        [HttpPost]
        public BindingList<UserMessage.GetUserInboxMessages_Class> GetUserInboxMessages(GetUserInboxMessages_Input input)
        {
            DateTime startDate = new DateTime();
            DateTime endDate = new DateTime();

            if (input.Mode == "Today")
            {
                startDate = Common.RecTime().Date;
                endDate = Common.RecTime().Date.AddHours(23).AddMinutes(59);
            }

            else if (input.Mode == "Yesterday")
            {
                startDate = Common.RecTime().Date.AddDays(-1);
                endDate = Common.RecTime().Date.AddDays(-1).AddHours(23).AddMinutes(59);
            }

            else if (input.Mode == "ThisWeek")
            {
                startDate = Common.RecTime().Date.AddDays(-7);
                endDate = Common.RecTime().Date.AddDays(-2).AddHours(23).AddMinutes(59);
            }

            else if (input.Mode == "Older")
            {
                startDate = Common.RecTime().AddYears(-3);
                endDate = Common.RecTime().Date.AddDays(-8).AddHours(23).AddMinutes(59);
            }

            var ret = UserMessage.GetUserInboxMessages(Common.CurrentResource.ObjectID.ToString(), startDate, endDate);
            //using (var objectContext = new TTObjectContext(true))
            //{
            //    foreach(var message in ret)
            //    {
            //        //if(message.Mesajgrubu != null)
            //        //{
            //        //    var userMessageGroup = objectContext.GetObject<UserMessageGroupDefinition>(message.Mesajgrubu.Value);
            //        //    message.
            //        //}
            //    }
            //}
            return ret;
        }

        public class GetNewUserMessages_Input
        {
            public string TOUSER
            {
                get;
                set;
            }
        }

        [HttpPost]
        public int GetUnredMessage()
        {
            var ret = UserMessage.GetUnreadMessagesCount(Common.CurrentResource.ObjectID.ToString());
            return int.Parse(ret[0].Mesajsayisi.ToString());
        }

        [HttpPost]
        public BindingList<UserMessage.GetNewUserMessages_Class> GetNewUserMessages(GetNewUserMessages_Input input)
        {
            var ret = UserMessage.GetNewUserMessages(input.TOUSER);
            return ret;
        }

        public class GetDraftUserMessages_Input
        {
            public string SENDER
            {
                get;
                set;
            }

            public DateTime StartDate
            {
                get;
                set;
            }
            public DateTime EndDate
            {
                get;
                set;
            }
            public string Mode
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<UserMessage.GetDraftUserMessages_Class> GetDraftUserMessages(GetDraftUserMessages_Input input)
        {
            DateTime startDate = new DateTime();
            DateTime endDate = new DateTime();


            if (input.Mode == "Today")
            {
                startDate = Common.RecTime().Date;
                endDate = Common.RecTime().Date.AddHours(23).AddMinutes(59);
            }

            else if (input.Mode == "Yesterday")
            {
                startDate = Common.RecTime().Date.AddDays(-1);
                endDate = Common.RecTime().Date.AddDays(-1).AddHours(23).AddMinutes(59);
            }

            else if (input.Mode == "ThisWeek")
            {
                startDate = Common.RecTime().Date.AddDays(-7);
                endDate = Common.RecTime().Date.AddDays(-2).AddHours(23).AddMinutes(59);
            }

            else if (input.Mode == "Older")
            {
                startDate = Common.RecTime().AddYears(-3);
                endDate = Common.RecTime().Date.AddDays(-8).AddHours(23).AddMinutes(59);
            }

            var ret = UserMessage.GetDraftUserMessages(Common.CurrentResource.ObjectID.ToString(), startDate, endDate);
            return ret;
        }

        public class GetSentItemsUserMessages_Input
        {
            public string SENDER
            {
                get;
                set;
            }

            public DateTime StartDate
            {
                get;
                set;
            }
            public DateTime EndDate
            {
                get;
                set;
            }
            public string Mode
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<UserMessage.GetSentItemsUserMessages_Class> GetSentItemsUserMessages(GetSentItemsUserMessages_Input input)
        {
            DateTime startDate = new DateTime();
            DateTime endDate = new DateTime();

            if (input.Mode == "Today")
            {
                startDate = Common.RecTime().Date;
                endDate = Common.RecTime().Date.AddHours(23).AddMinutes(59);
            }

            else if (input.Mode == "Yesterday")
            {
                startDate = Common.RecTime().Date.AddDays(-1);
                endDate = Common.RecTime().Date.AddDays(-1).AddHours(23).AddMinutes(59);
            }

            else if (input.Mode == "ThisWeek")
            {
                startDate = Common.RecTime().Date.AddDays(-7);
                endDate = Common.RecTime().Date.AddDays(-2).AddHours(23).AddMinutes(59);
            }

            else if (input.Mode == "Older")
            {
                startDate = Common.RecTime().AddYears(-3);
                endDate = Common.RecTime().Date.AddDays(-8).AddHours(23).AddMinutes(59);
            }

            var ret = UserMessage.GetSentItemsUserMessages(Common.CurrentResource.ObjectID.ToString(), startDate, endDate);
            //foreach (var item in ret)
            //{

            //    item.Ek = item.Ek.
            //}
            return ret;
        }

        public class GetDeletedItemsUserMessages_Input
        {
            public string USER
            {
                get;
                set;
            }

            public DateTime StartDate
            {
                get;
                set;
            }
            public DateTime EndDate
            {
                get;
                set;
            }
            public string Mode
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<UserMessage.GetDeletedItemsUserMessages_Class> GetDeletedItemsUserMessages(GetDeletedItemsUserMessages_Input input)
        {
            DateTime startDate = new DateTime();
            DateTime endDate = new DateTime();

            if (input.Mode == "Today")
            {
                startDate = Common.RecTime().Date;
                endDate = Common.RecTime().Date.AddHours(23).AddMinutes(59);
            }

            else if (input.Mode == "Yesterday")
            {
                startDate = Common.RecTime().Date.AddDays(-1);
                endDate = Common.RecTime().Date.AddDays(-1).AddHours(23).AddMinutes(59);
            }

            else if (input.Mode == "ThisWeek")
            {
                startDate = Common.RecTime().Date.AddDays(-7);
                endDate = Common.RecTime().Date.AddDays(-2).AddHours(23).AddMinutes(59);
            }

            else if (input.Mode == "Older")
            {
                startDate = Common.RecTime().AddYears(-3);
                endDate = Common.RecTime().Date.AddDays(-8).AddHours(23).AddMinutes(59);
            }

            var ret = UserMessage.GetDeletedItemsUserMessages(Common.CurrentResource.ObjectID.ToString(), startDate, endDate);
            return ret;
        }


        public class GetUnreadSysMessages_Input
        {
            public string TOUSER
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<UserMessage.GetUnreadSysMessages_Class> GetUnreadSysMessages()
        {
            var ret = UserMessage.GetUnreadSysMessages(Common.CurrentResource.ObjectID.ToString());
            return ret;
        }

        public class GetUserMessageByID_Input
        {
            public string OBJECTID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<UserMessage> GetUserMessageByID(GetUserMessageByID_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = UserMessage.GetUserMessageByID(objectContext, input.OBJECTID);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetSentGroupItemsUserMessages_Input
        {
            public string SENDER
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<UserMessage.GetSentGroupItemsUserMessages_Class> GetSentGroupItemsUserMessages(GetSentGroupItemsUserMessages_Input input)
        {
            var ret = UserMessage.GetSentGroupItemsUserMessages(input.SENDER);
            return ret;
        }

        public class GetSentGroupMessage_Input
        {
            public string SENDER
            {
                get;
                set;
            }

            public string USERMESSAGEGROUP
            {
                get;
                set;
            }

            public string USERMESSAGEID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<UserMessage.GetSentGroupMessage_Class> GetSentGroupMessage(GetSentGroupMessage_Input input)
        {
            var ret = UserMessage.GetSentGroupMessage(input.SENDER, input.USERMESSAGEGROUP, input.USERMESSAGEID);
            return ret;
        }

        public class GetUserMessageByToUser_Input
        {
            public string TOUSER
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<UserMessage> GetUserMessageByToUser(GetUserMessageByToUser_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = UserMessage.GetUserMessageByToUser(objectContext, input.TOUSER);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetUnreadMessages_Input
        {
            public string TOUSER
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<UserMessage.GetUnreadMessages_Class> GetUnreadMessages(GetUnreadMessages_Input input)
        {
            var ret = UserMessage.GetUnreadMessages(input.TOUSER);
            return ret;
        }

        public class GetSentGroupMessageDate_Input
        {
            public string SENDER
            {
                get;
                set;
            }

            public string USERMESSAGEGROUP
            {
                get;
                set;
            }

            public string USERMESSAGEID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<UserMessage.GetSentGroupMessageDate_Class> GetSentGroupMessageDate(GetSentGroupMessageDate_Input input)
        {
            var ret = UserMessage.GetSentGroupMessageDate(input.SENDER, input.USERMESSAGEGROUP, input.USERMESSAGEID);
            return ret;
        }

        [HttpGet]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public TTObjectClasses.ResUser.GetResUser_Class[] GetUsers()
        {
            using (var objectContext = new TTObjectContext(false))
            {
                TTObjectClasses.ResUser.GetResUser_Class[] users = ResUser.GetResUser(" AND ISACTIVE = 1").ToArray();
                return users;
            }
        }

        public class SendBinaryInput
        {
            public string UserMessageObjectID { get; set; }
            public IList<FormFile> Attachments { get; set; }
            public string FileName { get; set; }
        }

        public class GetMessageAttachment_Input
        {
            public Guid messageID
            {
                get; set;
            }
        }
        [HttpPost]
        public IList<UserMessageAttachment.GetAttachments_Class> GetMessageAttachment(GetMessageAttachment_Input input)
        {
            var ret = UserMessageAttachment.GetAttachments(input.messageID).ToArray();
            return ret;
        }

        [HttpPost]
        [DisableFormValueModelBinding]
        public async Task<IActionResult> SendUserMessageAttachment()
        {

            var result = await MultipartRequestHelper.BindMultiPartFormDataToViewModel<SendBinaryInput>(this);
            var objectResult = result as ObjectResult;
            var viewModel = objectResult.Value as SendBinaryInput;

            using (var context = new TTObjectContext(false))
            {
                Guid savePoint = context.BeginSavePoint();
                if (viewModel != null)
                {
                    UserMessage theMessage = context.GetObject<UserMessage>(new Guid(viewModel.UserMessageObjectID));
                    Console.WriteLine(viewModel.FileName);
                    if (viewModel.Attachments != null)
                    {
                        UserMessageAttachment attachment = new UserMessageAttachment(context);
                        var formFile = viewModel.Attachments.FirstOrDefault();
                        if (StreamHelpers.ToByteArray(formFile.OpenReadStream()).Length <= 10000000)
                        {
                            if (FileTypeCheck.fileTypeCheck(StreamHelpers.ToByteArray(formFile.OpenReadStream()), viewModel.FileName))
                            {
                                attachment.Attachment = StreamHelpers.ToByteArray(formFile.OpenReadStream());
                                attachment.Name = viewModel.FileName;
                                attachment.UserMessage = theMessage;
                                context.Save();
                            }
                            else
                                throw new TTException(TTUtils.CultureService.GetText("M25690", "Geçersiz dosya tipi!"));
                        }
                        else
                        {
                            throw new TTException(TTUtils.CultureService.GetText("M25077", "10 Mb'dan büyük dosya yükleyemezsiniz!"));
                        } 
                    }
                }
            }

            return Ok();
        }
        public class DeleteAttachment_Input
        {
            public Guid attachmentid {
                get; set;
            }
        }
        [HttpPost]
        public void DeleteAttachment(DeleteAttachment_Input input)
        {
            using (var context = new TTObjectContext(false))
            {
                UserMessageAttachment attachment = context.GetObject<UserMessageAttachment>(input.attachmentid);
                ((ITTObject)attachment).Delete();
                context.Save();
            }

        }

    }
    [Route("api/[controller]/[action]/{id?}")]
    public partial class UserMessageDownloadServiceController : Controller
    {

        public class DownloadFileInput
        {
            public Guid id { get; set; }
        }

        [HttpPost]
        public IActionResult DownloadFile(DownloadFileInput input)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                UserMessageAttachment att = (UserMessageAttachment)objectContext.GetObject(input.id, typeof(UserMessageAttachment));
                Byte[] memoryStream = (byte[])att.Attachment;
                System.IO.Stream myInputStream = new System.IO.MemoryStream(memoryStream);
                myInputStream.Position = 0;
                var contentType = "" ;
                if (att.Name.Substring(att.Name.IndexOf('.')).ToUpper() == ".DOCX")
                {
                    contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                }
                else if (att.Name.Substring(att.Name.IndexOf('.')).ToUpper() == ".PNG")
                {
                    contentType = "image/png";
                }
                else if (att.Name.Substring(att.Name.IndexOf('.')).ToUpper() == ".JPG"
                    || att.Name.Substring(att.Name.IndexOf('.')).ToUpper() == ".JPEG")
                {
                    contentType = "image/jpeg";
                }
                else if (att.Name.Substring(att.Name.IndexOf('.')).ToUpper() == ".DOC")
                {
                    contentType = "application/msword";
                }
                else if (att.Name.Substring(att.Name.IndexOf('.')).ToUpper() == ".PPT")
                {
                    contentType = "application/vnd.ms-powerpoint";
                }
                else if (att.Name.Substring(att.Name.IndexOf('.')).ToUpper() == ".PPTX")
                {
                    contentType = " application/vnd.openxmlformats-officedocument.presentationml.presentation";
                }
                else if (att.Name.Substring(att.Name.IndexOf('.')).ToUpper() == ".PDF")
                {
                    contentType = "application/pdf";
                }
                else if (att.Name.Substring(att.Name.IndexOf('.')).ToUpper() == ".XLS")
                {
                    contentType = "application/vnd.ms-excel";
                }
                else if (att.Name.Substring(att.Name.IndexOf('.')).ToUpper() == ".XLSX")
                {
                    contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                }
                else if (att.Name.Substring(att.Name.IndexOf('.')).ToUpper() == ".XLSM")
                {
                    contentType = "application/vnd.ms-excel.sheet.macroEnabled.12";
                }
                else
                    return null;
                var response = new FileStreamResult(myInputStream, contentType);

                objectContext.FullPartialllyLoadedObjects();
                return response;
            }
        }
    }
}




