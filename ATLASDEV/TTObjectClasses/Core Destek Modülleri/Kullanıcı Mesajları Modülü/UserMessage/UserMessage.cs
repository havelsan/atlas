
using System;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

using TTUtils;
using TTObjectClasses;
using TTDataDictionary;
using TTCoreDefinitions;
using TTConnectionManager;
using TTInstanceManagement;
using TTDefinitionManagement;
using TTStorageManager.Security;



using TTStorageManager;
using System.Runtime.Versioning;


using SmsApi.Types;
using SmsApi;
using RestSharp;
using AtlasSmsManager;
using System.Text.RegularExpressions;

namespace TTObjectClasses
{
    /// <summary>
    /// Kullanıcı Mesajları
    /// </summary>
    public partial class UserMessage : TTObject
    {
        public partial class GetUserInboxMessages_Class : TTReportNqlObject
        {
        }

        public partial class GetNewUserMessages_Class : TTReportNqlObject
        {
        }

        public partial class GetDraftUserMessages_Class : TTReportNqlObject
        {
        }

        public partial class GetSentItemsUserMessages_Class : TTReportNqlObject
        {
        }

        public partial class GetUnreadSysMessages_Class : TTReportNqlObject
        {
        }

        public partial class GetSentGroupItemsUserMessages_Class : TTReportNqlObject
        {
        }

        public partial class GetSentGroupMessage_Class : TTReportNqlObject
        {
        }

        public partial class GetUnreadMessages_Class : TTReportNqlObject
        {
        }

        public partial class GetSentGroupMessageDate_Class : TTReportNqlObject
        {
        }

        public partial class GetDeletedItemsUserMessages_Class : TTReportNqlObject
        {
        }


        public class Credential
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public int ResellerID { get; set; }
        }

        public class ToMsisdn
        {
            public long Msisdn { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public string CustomField1 { get; set; }
            public string CustomField2 { get; set; }
            public string CustomField3 { get; set; }
        }

        public class Sms
        {
            public IList<UserMessage.ToMsisdn> ToMsisdns { get; set; }
            public IList<long> ToGroups { get; set; }
            public IList<int> EjectedGroups { get; set; }
            public bool IsCreateFromTeplate { get; set; }
            public string SmsTitle { get; set; }
            public string SmsContent { get; set; }
            public string RequestGuid { get; set; }
            public bool CanSendSmsToDuplicateMsisdn { get; set; }
            public string SmsSendingType { get; set; }
            public string SmsCoding { get; set; }
            public string SenderName { get; set; }
            public int Route { get; set; }
            public int ValidityPeriod { get; set; }
            public string DataCoding { get; set; }
        }

        public class SmsClass
        {
            public UserMessage.Credential Credential { get; set; }
            public UserMessage.Sms Sms { get; set; }
        }


        #region Methods
        #region SendMessageInternal and SendMessage overloaded methods
        public static void SendMessageInternalWithResUserV3(TTObjectContext context, IList<ResUser> toUsers, string subject, object pBody, bool? isSystemMessage, Patient patient)
        {
            if (toUsers == null)
                return;

            foreach (ResUser user in toUsers)
            {
                UserMessage newMessage = new UserMessage(context);
                newMessage.InitializeSentMessage();
                newMessage.ToUser = user;
                newMessage.Subject = subject;
                newMessage.MessageBody = pBody;
                newMessage.IsSystemMessage = isSystemMessage;
                newMessage.Patient = patient;
                newMessage.ValidateFields();
                newMessage.CheckErrorsEx();
            }
        }

        public static void SendMessageInternalWithResUserV2(TTObjectContext context, IList<ResUser> toUsers, string subject, object pBody, bool? isSystemMessage)
        {
            SendMessageInternalWithResUserV3(context, toUsers, subject, pBody, isSystemMessage, null);
        }

        public static void SendMessageInternalWithResUser(TTObjectContext context, IList<ResUser> toUsers, string subject, object pBody)
        {
            SendMessageInternalWithResUserV3(context, toUsers, subject, pBody, null, null);
        }
        //*****************V2*******************//
        public static void SendMessageInternalWithResUserV4(TTObjectContext context, IList<ResUser> toUsers, string subject, object pBody, Guid reportDefID)
        {
            if (toUsers == null)
                return;

            foreach (ResUser user in toUsers)
            {
                UserMessage newMessage = new UserMessage(context);
                newMessage.InitializeSentMessage();
                newMessage.ToUser = user;
                newMessage.Subject = subject;
                newMessage.MessageBody = pBody;
                newMessage.IsSystemMessage = false;
                newMessage.Patient = null;
                newMessage.ReportDefID = reportDefID;
                newMessage.ValidateFields();
                newMessage.CheckErrorsEx();
            }
        }

        public static void SendMessageInternalV3(TTObjectContext context, IList<string> toUsers, string subject, object pBody, bool? isSystemMessage, Patient patient)
        {
            if (toUsers == null)
                return;

            foreach (string sUserID in toUsers)
            {
                UserMessage newMessage = new UserMessage(context);
                newMessage.InitializeSentMessage();
                Guid userID = new Guid(sUserID);
                newMessage.ToUser = (ResUser)newMessage.ObjectContext.GetObject(userID, typeof(ResUser));
                newMessage.Subject = subject;
                newMessage.MessageBody = pBody;
                newMessage.IsSystemMessage = isSystemMessage;
                newMessage.Patient = patient;
                newMessage.ValidateFields();
                newMessage.CheckErrorsEx();
            }
        }

        public static void SendMessageInternalWithGroupsV3(TTObjectContext context, IList<string> toUsers, IList<string> userMessageGroups, string subject, object pBody, bool? isSystemMessage, bool? messageFeedback, Patient patient)
        {
            SendMessageInternalWithGroupsV4(context, toUsers, userMessageGroups, subject, pBody, isSystemMessage, messageFeedback, patient, null, null);
        }

        public static List<string> GetUserMessageGroupsUser(List<string> userMessageGroups, TTObjectContext context)
        {
            List<string> Users = new List<string>();
            foreach (var groupID in userMessageGroups)
            {
                Guid userMessageGroupDefID = new Guid(groupID);
                var group = (UserMessageGroupDefinition)context.GetObject(userMessageGroupDefID, typeof(UserMessageGroupDefinition));
                foreach (UserMessageGroupUsers user in group.UserMessageGroupUsers)
                {
                    Users.Add(user.ResUser.ObjectID.ToString());
                }
            }
            return Users;
        }

        public static Guid SendMessageInternalWithGroupsV4(TTObjectContext context, IList<string> toUsers, IList<string> userMessageGroups, string subject, object pBody, bool? isSystemMessage, bool? messageFeedback, Patient patient, bool? isSplashMessage, DateTime? expireDate)
        {
            Guid objectID = new Guid();

            if (toUsers.Count > 0 || userMessageGroups.Count > 0)
            {

                int index = 0;
                Guid userMessageID = Guid.NewGuid();
                foreach (var groupID in userMessageGroups)
                {
                    Guid userMessageGroupDefID = new Guid(groupID);
                    var group = (UserMessageGroupDefinition)context.GetObject(userMessageGroupDefID, typeof(UserMessageGroupDefinition));
                    foreach (UserMessageGroupUsers user in group.UserMessageGroupUsers)
                    {
                        toUsers.Add(user.ResUser.ObjectID.ToString());
                    }
                }

                foreach (string sUserID in toUsers)
                {
                    UserMessage newMessage = new UserMessage(context);
                    newMessage.InitializeSentMessage();
                    Guid userID = new Guid(sUserID);
                    newMessage.ToUser = (ResUser)newMessage.ObjectContext.GetObject(userID, typeof(ResUser));

                    newMessage.UserMessageID = userMessageID;
                    newMessage.Subject = subject;
                    newMessage.MessageBody = pBody;
                    newMessage.IsSystemMessage = isSystemMessage;
                    objectID = newMessage.ObjectID;
                    newMessage.IsSplashMessage = isSplashMessage;
                    newMessage.MessageFeedback = messageFeedback;
                    if (expireDate != null)
                        newMessage.ExpireDate = expireDate;

                    newMessage.Patient = patient;
                    newMessage.ValidateFields();
                    newMessage.CheckErrorsEx();
                    context.Save();
                }
            }
            //else if (userMessageGroups.Count > 0)
            //{
            //    Guid objectID = new Guid();
            //    int index = 0;
            //    Guid userMessageID = Guid.NewGuid();

            //    UserMessage newMessage = new UserMessage(context);
            //    newMessage.InitializeSentMessage();
            //    if (userMessageGroups.Count > 0)
            //    {
            //        Guid userMessageGroupDefID = new Guid(userMessageGroups[index]);
            //        newMessage.UserMessageGroup = (UserMessageGroupDefinition)newMessage.ObjectContext.GetObject(userMessageGroupDefID, typeof(UserMessageGroupDefinition));
            //    }
            //    foreach (var user in newMessage.UserMessageGroup.UserMessageGroupUsers)
            //    {
            //        newMessage.ToUser = user.ResUser;
            //        if (userMessageGroups.Count > 0)
            //        {
            //            Guid userMessageGroupDefID = new Guid(userMessageGroups[index]);
            //            newMessage.UserMessageGroup = (UserMessageGroupDefinition)newMessage.ObjectContext.GetObject(userMessageGroupDefID, typeof(UserMessageGroupDefinition));
            //        }
            //        newMessage.UserMessageID = userMessageID;
            //        newMessage.Subject = subject;
            //        newMessage.MessageBody = pBody;
            //        newMessage.IsSystemMessage = isSystemMessage;
            //        objectID = newMessage.ObjectID;
            //        newMessage.IsSplashMessage = isSplashMessage;
            //        newMessage.MessageFeedback = messageFeedback;
            //        if (expireDate != null)
            //            newMessage.ExpireDate = expireDate;

            //        newMessage.Patient = patient;
            //        newMessage.ValidateFields();
            //        newMessage.CheckErrorsEx();
            //        context.Save();
            //    }

            //    return objectID;
            //}
            return objectID;
        }

        public SendSMSMaster CreateSendSMSMaster(TTObjectContext objectContext, string SMSText, bool IsPatientSMS)
        {
            SendSMSMaster smsMaster = new SendSMSMaster(objectContext);
            smsMaster.MessageText = SMSText;
            smsMaster.IsPatientSMS = true;
            if (Common.CurrentResource != null)
                smsMaster.ResUser = Common.CurrentResource;
            else
                smsMaster.ResUser = null;
            smsMaster.CurrentStateDefID = SendSMSMaster.States.New;
            objectContext.Update();
            smsMaster.CurrentStateDefID = SendSMSMaster.States.Started;
            objectContext.Update();
            return smsMaster;
        }


        //Bu metoda dışarıdan context verildiği zaman context.Update() metodu çağırıldığında sıkıntı yaşanmaktaydı. Bu yüzden ayrı context kullanıldı.
        /// <summary>
        /// Kullanıcı ya da Kullanıcılara mesaj gönderen ve kaydını tutan metot. Bu metodun objectContext'i ayarı olduğu için context'inizi save ettikten sonra
        /// (AfterContextSave uygun bir yer) çağırılması daha doğru olacaktır.
        /// </summary>
        /// <param name="users">Kullanıcı listesi</param>
        /// <param name="message">Mesaj içeriği. (Boş geçilmemeli. Boş olursa mesaj gönderim ve kayıt işlemi gerçekleşmez.)</param>
        /// <param name="smsType">Gönderilen SMS in türü. Boş geçilmemeli. Eğer istenilen tür yoksa SMSTypeEnum a eklenmeli.</param>
        /// <returns></returns>
        public bool SendSMSPerson(List<ResUser> users, string message, SMSTypeEnum smsType)
        {
            bool result = false;
            if (string.IsNullOrEmpty(message))
                return result;
            try
            {
                if (users != null && users.Count > 0)
                {
                    using (TTObjectContext objectContext = new TTObjectContext(false))
                    {
                        var smsInstance = SmsManager.Instance;
                        if (smsInstance == null)
                            return false;

                        SendSMSMaster smsMaster = CreateSendSMSMaster(objectContext, message, false);

                        foreach (var user in users)
                        {
                            SendSMSDetail sendSMSDetail = new SendSMSDetail(objectContext);
                            sendSMSDetail.SendSMSMaster = smsMaster;
                            sendSMSDetail.FirstName = user.Person.Name;
                            sendSMSDetail.SurName = user.Person.Surname;
                            sendSMSDetail.PhoneNumber = user.PhoneNumber;
                            sendSMSDetail["RESUSER"] = user.ObjectID;
                            sendSMSDetail.CurrentStateDefID = SendSMSDetail.States.New;

                            objectContext.Update();

                            if (string.IsNullOrEmpty(user.PhoneNumber))
                            {
                                sendSMSDetail.CurrentStateDefID = SendSMSDetail.States.HasNoPhonenumber;

                                objectContext.Save();

                                continue;
                            }

                            string RegexDesen = @"^(5(\d{9}))$";
                            //Sadece cep telefonu formatına uygun olan kullanıcıları getirir. Format:5aabbbccdd 10 hane olacak şekilde kabul edildi.
                            bool isPhonenumberFormatCorrect = Regex.Match(user.PhoneNumber, RegexDesen, RegexOptions.IgnoreCase).Success;

                            if (isPhonenumberFormatCorrect)
                            {
                                AtlasSMS sms = new AtlasSMS();
                                sms.Number = sendSMSDetail.PhoneNumber;
                                sms.Text = message;

                                result = smsInstance.SendSms(sms);

                                if (result)
                                    sendSMSDetail.CurrentStateDefID = SendSMSDetail.States.Sent;
                                else
                                    sendSMSDetail.CurrentStateDefID = SendSMSDetail.States.NotSent;
                            }
                            else
                                sendSMSDetail.CurrentStateDefID = SendSMSDetail.States.IncorrectPhoneNumber;
                        }

                        smsMaster.CurrentStateDefID = SendSMSMaster.States.Sent;

                        objectContext.Save();

                        return true;
                    }
                }
                else
                    return result;
            }
            catch
            {
                return false;
            }



            //string phoneNumber = user.PhoneNumber.Replace(" ", "");
            //phoneNumber = "90" + phoneNumber.Trim();
            //return SmsManager.Instance.SendSms(new AtlasSMS()
            //{
            //    Number = phoneNumber,
            //    Text = message
            //});
            //var c1 = new SmsClass();

            //c1.Credential = new Credential();
            //c1.Credential.Username = TTObjectClasses.SystemParameter.GetParameterValue("SMSUSERNAME", "XXXXXX");
            //c1.Credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("SMSPASSWORD", "XXXXXX");
            //c1.Credential.ResellerID = Convert.ToInt16(TTObjectClasses.SystemParameter.GetParameterValue("SMSRESELLERID", "2427")); 

            //c1.Sms = new Sms();
            //c1.Sms.SmsTitle = TTObjectClasses.SystemParameter.GetParameterValue("SMSTITLE", "GAZILER FTR"); 
            //c1.Sms.SenderName = TTObjectClasses.SystemParameter.GetParameterValue("SMSTITLE", "GAZILER FTR");
            //c1.Sms.SmsContent = message; 

            //var toMsisdn = new ToMsisdn();
            //string phoneNumber = user.PhoneNumber.Replace(" ", "");
            //phoneNumber = "90" + phoneNumber.Trim();
            //toMsisdn.Msisdn = Convert.ToInt64(phoneNumber); 
            //c1.Sms.ToMsisdns = new ToMsisdn[] { toMsisdn };


            //var jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(c1);
            //var client = new RestClient("http://xxxxxx.com");
            //var request = new RestRequest("/json/syncreply/SendInstantSms", RestSharp.Method.POST);
            //request.AddHeader("Accept", "application/json");
            //request.AddParameter("application/json", jsonContent, ParameterType.RequestBody);
            //var response = client.Execute(request);
            //if (response != null && response.ResponseStatus == ResponseStatus.Completed)
            //{
            //    if (response.StatusCode == System.Net.HttpStatusCode.OK)
            //        return true;
            //    else
            //        return false;
            //}
            //else
            //    return false;
        }

        //Bu metoda dışarıdan context verildiği zaman context.Update() metodu çağırıldığında sıkıntı yaşanmaktaydı. Bu yüzden ayrı context kullanıldı.
        /// <summary>
        /// Hasta ya da Hastalara mesaj gönderen ve kaydını tutan metot. Bu metodun objectContext'i ayarı olduğu için context'inizi save ettikten sonra
        /// (AfterContextSave uygun bir yer) çağırılması daha doğru olacaktır.
        /// </summary>
        /// <param name="patients">Hasta listesi</param>
        /// <param name="message">Mesaj içeriği. (Boş geçilmemeli. Boş olursa mesaj gönderim ve kayıt işlemi gerçekleşmez.)</param>
        /// <param name="smsType">Gönderilen SMS in türü. Boş geçilmemeli. Eğer istenilen tür yoksa SMSTypeEnum a eklenmeli.</param>
        /// <returns></returns>
        public bool SendSMSPatient(List<Patient> patients, string message, SMSTypeEnum smsType)
        {
            bool result = false;
            if (string.IsNullOrEmpty(message))
                return result;

            try
            {
                if (patients != null && patients.Count > 0)
                {
                    using (TTObjectContext objectContext = new TTObjectContext(false))
                    {
                        var smsInstance = SmsManager.Instance;
                        if (smsInstance == null)
                            return false;

                        SendSMSMaster smsMaster = CreateSendSMSMaster(objectContext, message, true);

                        foreach (var patient in patients)
                        {
                            SendSMSDetail sendSMSDetail = new SendSMSDetail(objectContext);
                            sendSMSDetail.SendSMSMaster = smsMaster;
                            sendSMSDetail.FirstName = patient.Name;
                            sendSMSDetail.SurName = patient.Surname;
                            //sendSMSDetail.PhoneNumber = patient.MobilePhone;
                            sendSMSDetail.PhoneNumber = patient.PatientAddress.MobilePhone.Replace(" ", "");
                            sendSMSDetail["PATIENT"] = patient.ObjectID;
                            sendSMSDetail.CurrentStateDefID = SendSMSDetail.States.New;

                            objectContext.Update();

                            if (string.IsNullOrEmpty(sendSMSDetail.PhoneNumber))
                            {
                                sendSMSDetail.CurrentStateDefID = SendSMSDetail.States.HasNoPhonenumber;

                                objectContext.Save();

                                continue;
                            }

                            string RegexDesen = @"^(5(\d{9}))$";
                            //Sadece cep telefonu formatına uygun olan kullanıcıları getirir. Format:5aabbbccdd 10 hane olacak şekilde kabul edildi.
                            bool isPhonenumberFormatCorrect = Regex.Match(sendSMSDetail.PhoneNumber, RegexDesen, RegexOptions.IgnoreCase).Success;

                            if (isPhonenumberFormatCorrect)
                            {
                                AtlasSMS sms = new AtlasSMS();
                                sms.Number = sendSMSDetail.PhoneNumber;
                                sms.Text = message;

                                result = smsInstance.SendSms(sms);

                                if (result)
                                    sendSMSDetail.CurrentStateDefID = SendSMSDetail.States.Sent;
                                else
                                    sendSMSDetail.CurrentStateDefID = SendSMSDetail.States.NotSent;
                            }
                            else
                                sendSMSDetail.CurrentStateDefID = SendSMSDetail.States.IncorrectPhoneNumber;
                        }

                        smsMaster.CurrentStateDefID = SendSMSMaster.States.Sent;

                        objectContext.Save();

                        return true;
                    }
                }
                else
                    return result;
            }
            catch
            {
                return false;
            }

        }

        //public bool SendSMSPatient(Patient user, string message)
        //{
        //    string phoneNumber = user.PatientAddress.MobilePhone.Replace(" ", "");
        //    phoneNumber = "90" + phoneNumber.Trim();
        //    return SmsManager.Instance.SendSms(new AtlasSMS()
        //    {
        //        Number = phoneNumber,
        //        Text = message
        //    });
        //    //var c1 = new SmsClass();

        //    //c1.Credential = new Credential();
        //    //c1.Credential.Username = TTObjectClasses.SystemParameter.GetParameterValue("SMSUSERNAME", "XXXXXX");
        //    //c1.Credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("SMSPASSWORD", "XXXXXX");
        //    //c1.Credential.ResellerID = Convert.ToInt16(TTObjectClasses.SystemParameter.GetParameterValue("SMSRESELLERID", "2427"));

        //    //c1.Sms = new Sms();
        //    //c1.Sms.SmsTitle = TTObjectClasses.SystemParameter.GetParameterValue("SMSTITLE", "GAZILER FTR");
        //    //c1.Sms.SenderName = TTObjectClasses.SystemParameter.GetParameterValue("SMSTITLE", "GAZILER FTR");
        //    //c1.Sms.SmsContent = message;

        //    //var toMsisdn = new ToMsisdn();
        //    //string phoneNumber = user.PatientAddress.MobilePhone.Replace(" ", "");
        //    //phoneNumber = "90" + phoneNumber.Trim();
        //    //toMsisdn.Msisdn = Convert.ToInt64(phoneNumber);
        //    //c1.Sms.ToMsisdns = new ToMsisdn[] { toMsisdn };


        //    //var jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(c1);
        //    //var client = new RestClient("http://xxxxxx.com");
        //    //var request = new RestRequest("/json/syncreply/SendInstantSms", RestSharp.Method.POST);
        //    //request.AddHeader("Accept", "application/json");
        //    //request.AddParameter("application/json", jsonContent, ParameterType.RequestBody);
        //    //var response = client.Execute(request);
        //    //if (response != null && response.ResponseStatus == ResponseStatus.Completed)
        //    //{
        //    //    if (response.StatusCode == System.Net.HttpStatusCode.OK)
        //    //        return true;
        //    //    else
        //    //        return false;
        //    //}
        //    //else
        //    //    return false;

        //}

        public static Guid SendMessageInternalWithGroupsV5(TTObjectContext context, IList<string> toUsers, IList<string> userMessageGroups, string subject, object pBody, bool? isSystemMessage, bool? messageFeedback, Patient patient, bool? isSplashMessage, DateTime? expireDate, Guid? UserMessageObjectID)
        {
            if (toUsers == null)
                return new Guid();

            Guid objectID = new Guid();
            int index = 0;
            UserMessage newMessage = context.GetObject<UserMessage>(UserMessageObjectID.Value);
            foreach (string sUserID in toUsers)
            {

                newMessage.InitializeSentMessage();
                Guid userID = new Guid(sUserID);
                newMessage.ToUser = (ResUser)newMessage.ObjectContext.GetObject(userID, typeof(ResUser));
                if (userMessageGroups.Count > 0)
                {
                    Guid userMessageGroupDefID = new Guid(userMessageGroups[index]);
                    newMessage.UserMessageGroup = (UserMessageGroupDefinition)newMessage.ObjectContext.GetObject(userMessageGroupDefID, typeof(UserMessageGroupDefinition));
                }
                newMessage.UserMessageID = UserMessageObjectID.Value;
                newMessage.Subject = subject;
                newMessage.MessageBody = pBody;
                newMessage.IsSystemMessage = isSystemMessage;
                objectID = newMessage.ObjectID;
                newMessage.SenderStatus = MessageStatusEnum.Sent;
                newMessage.ReceiverStatus = MessageStatusEnum.UnRead;
                newMessage.IsSplashMessage = isSplashMessage;
                newMessage.MessageFeedback = messageFeedback;
                if (expireDate != null)
                    newMessage.ExpireDate = expireDate;

                newMessage.Patient = patient;
                newMessage.ValidateFields();
                newMessage.CheckErrorsEx();
                context.Save();
            }
            return objectID;
        }

        public static void SendMessageInternalV2(TTObjectContext context, IList<string> toUsers, string subject, object pBody, bool? isSystemMessage)
        {
            SendMessageInternalV3(context, toUsers, subject, pBody, isSystemMessage, null);
        }

        public static void SendMessageInternal(TTObjectContext context, IList<string> toUsers, string subject, object pBody)
        {
            SendMessageInternalV3(context, toUsers, subject, pBody, null, null);
        }

        public static void SendMessageInternalWithGroupsV2(TTObjectContext context, IList<string> toUsers, IList<string> userMessageGroups, string subject, object pBody, bool? isSystemMessage, bool? messageFeedback)
        {
            SendMessageInternalWithGroupsV4(context, toUsers, userMessageGroups, subject, pBody, isSystemMessage, messageFeedback, null, null, null);
        }

        public static void SendMessageInternalWithGroups(TTObjectContext context, IList<string> toUsers, IList<string> userMessageGroups, string subject, object pBody)
        {
            SendMessageInternalWithGroupsV4(context, toUsers, userMessageGroups, subject, pBody, null, null, null, null, null);
        }

        //**********************In script external use*****************************/
        public static void SendMessage(TTObjectContext context, IList<ResUser> toUsers, string subject, string bodyText, bool? isSystemMessage, Patient patient)
        {
            if (toUsers == null)
                return;

            string bodyRTF = Globals.StringToRTF(bodyText);

            foreach (ResUser user in toUsers)
            {
                UserMessage newMessage = new UserMessage(context);
                newMessage.InitializeSentMessage();
                newMessage.ToUser = user;
                newMessage.Subject = subject;
                newMessage.MessageBody = bodyRTF;
                newMessage.IsSystemMessage = isSystemMessage;
                newMessage.Patient = patient;
                newMessage.ValidateFields();
                newMessage.CheckErrorsEx();
            }
        }

        public static void SendMessageV2(TTObjectContext context, IList<ResUser> toUsers, string subject, string bodyText, bool? isSystemMessage)
        {
            SendMessage(context, toUsers, subject, bodyText, isSystemMessage, null);
        }

        public static void SendMessageV3(TTObjectContext context, IList<ResUser> toUsers, string subject, string bodyText)
        {
            SendMessage(context, toUsers, subject, bodyText, null, null);
        }

        #endregion

        public void InitializeSentMessage()
        {
            Sender = Common.CurrentResource;
            SenderStatus = MessageStatusEnum.Sent;
            ReceiverStatus = MessageStatusEnum.UnRead;
        }

        public void InitializeUnSentMessage()
        {
            Sender = Common.CurrentResource;
            SenderStatus = MessageStatusEnum.NotSent;
            ReceiverStatus = MessageStatusEnum.NotSent;
        }

        public bool CheckErrorsEx()
        {
            if (((ITTObject)this).HasErrors)
            {
                throw new Exception(((ITTObject)this).GetErrors());
            }

            return false;
        }

        public void ValidateFields()
        {
            if (ToUser == null && IsSplashMessage.Value == false)
                throw new Exception(SystemMessage.GetMessage(978));
            if (Subject == null)
                throw new Exception(SystemMessage.GetMessage(979));
            if (MessageBody == null)
                throw new Exception(SystemMessage.GetMessage(980));
        }

        public void ValidateGroupMessageFields()
        {
            if (UserMessageGroup == null && IsSplashMessage.Value == false)
                throw new Exception(SystemMessage.GetMessage(978));
            if (Subject == null)
                throw new Exception(SystemMessage.GetMessage(979));
            if (MessageBody == null)
                throw new Exception(SystemMessage.GetMessage(980));
        }

        public void SetRTFBody(string textBody)
        {
            string bodyRTF = Globals.StringToRTF(textBody);
            MessageBody = bodyRTF;
        }

        public static List<UserMessage> GetUserMessageByUserID(Guid userID)
        {
            TTObjectContext ctx = new TTObjectContext(true);

            BindingList<UserMessage> userMessageList = UserMessage.GetUserMessageByToUser(ctx, TTUser.GetUser(userID).TTObjectID.ToString());
            List<UserMessage> umList = new List<UserMessage>();
            foreach (UserMessage um in userMessageList)
                umList.Add(um);

            return umList;
        }

        public static void IsMessageRead(TTObjectContext context, Guid? objectID)
        {
            UserMessage newMessage = context.GetObject<UserMessage>(objectID.Value);
            newMessage.ReceiverStatus = MessageStatusEnum.Read;
            newMessage.ValidateFields();
            newMessage.CheckErrorsEx();
            context.Save();

        }

        public static void DeleteMessage(TTObjectContext context, Guid? objectID, String CurrentBox)
        {
            UserMessage newMessage = context.GetObject<UserMessage>(objectID.Value);
            if (CurrentBox == "inbox")
            {
                newMessage.ReceiverStatus = MessageStatusEnum.Deleted;
            }
            else if (CurrentBox == "deleted")
            {
                if (newMessage.SenderStatus == MessageStatusEnum.Deleted)
                {
                    newMessage.SenderStatus = MessageStatusEnum.SavedDeleted;
                }
                else
                {
                    newMessage.ReceiverStatus = MessageStatusEnum.SavedDeleted;
                }
            }
            else
            {
                newMessage.SenderStatus = MessageStatusEnum.Deleted;
            }
            newMessage.ValidateFields();
            newMessage.CheckErrorsEx();
            context.Save();
        }



        #endregion Methods

    }
}