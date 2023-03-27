
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
using Newtonsoft.Json;

namespace TTObjectClasses
{
    /// <summary>
    /// Rapor Yazılmayan Ameliyatlar İçin SMS Gönder
    /// </summary>
    public partial class SendSMSForUnReportedSurgery : BaseScheduledTask
    {
        public override void TaskScript()
        {

            using (TTObjectContext objectContext = new TTObjectContext(false))
            {

                string logInfo = string.Empty;
                DateTime dateNow = Common.RecTime();
                int dateLimit = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("SENDUNREPORTEDSURGERYSMSDAYLIMIT", "3"));

                List<PersonListDefinitionForSurgerySMS> personLists = PersonListDefinitionForSurgerySMS.GetAllPersonListForSurgery(objectContext, "").ToList();

                if (personLists == null || personLists.Count == 0)
                {
                    logInfo = " Raporlanmamış Ameliyatları Gönderecek Tanım Listesi Boş Olduğu İçin Task Çalıştırılmadı.";
                    AddLog(logInfo);
                }
                else
                {

                    BindingList<Surgery> surgeryList = Surgery.GetUnreportedSurgeryList(objectContext, dateNow.Date.AddDays(dateLimit * -1), dateNow.Date);

                    foreach (Surgery _surgery in surgeryList)
                    {
                        try
                        {
                            TimeSpan span = DateTime.Now - _surgery.PlannedSurgeryDate.Value;
                            List<string> userList = new List<string>();

                            if (span.TotalHours >= 24)
                            {
                                string messageText = DateTime.Now + " tarihinde " + _surgery.Episode.Patient.Name + " " + _surgery.Episode.Patient.Surname + " isimli hastaya ait " + _surgery.SubEpisode.ProtocolNo + " no'lu kabulüne ait ameliyatın raporu plan tarihini 24 saat geçmesine rağmen yazılmamıştır.";

                                List<ResUser> resUsers = personLists.Select(x => x.ResUser).ToList();
                                List<ResUser> personListWithPhoneNumber = resUsers.Where(x => !string.IsNullOrEmpty(x.PhoneNumber)).ToList();

                                SendSMS(personListWithPhoneNumber, _surgery, messageText, SMSTypeEnum.UnReportedSurgerySMS);

                                List<ResUser> personListWithOutPhoneNumber = resUsers.Where(x => string.IsNullOrEmpty(x.PhoneNumber)).ToList();

                                foreach (var item in personListWithOutPhoneNumber)
                                {
                                    logInfo = item.Name + " kullanıcısının telefon numarası boş olduğu için SMS atılamamıştır ";
                                    AddLog(logInfo);
                                }

                                userList.AddRange(resUsers.Select(x => x.ObjectID.ToString()));

                                SendNotification(userList, messageText);

                            }

                        }
                        catch (Exception ex)
                        {
                            logInfo = " SMS atılırken bir hata ile karşılaşıldı ";
                            AddLog(ex.Message);
                        }

                        //objectContext.Save();

                    }

                }

            }

        }

        public void SendSMS(List<ResUser> resUsers, Surgery _surgery, string messageText, SMSTypeEnum smsType)
        {
            UserMessage userMessage = new UserMessage();
            bool smsResponse = false;
            string logInfo = string.Empty;

            smsResponse = userMessage.SendSMSPerson(resUsers, messageText, smsType);
            //if (smsResponse)
            //{
            //    logInfo = "BAŞARILI:" + _surgery.Episode.Patient.ObjectID + " id 'li hasta için " + _surgery.ObjectID + "id 'li ameliyat bilgisine dair bilgi " + resUser.Name + " isimli kullnıcının " + resUser.PhoneNumber + " numaralı telefonuna  SMS olarak gönderilmiştir";
            //    AddLog(logInfo);
            //}
            //else
            //{
            //    logInfo = "HATA:" + _surgery.Episode.Patient.ObjectID + " id 'li hasta için " + _surgery.ObjectID + "id 'li ameliyat bilgisine dair bilgi " + resUser.Name + " isimli kullnıcının " + resUser.PhoneNumber + " numaralı telefonuna  SMS olarak gönderilirken hata alınmıştır";
            //    AddLog(logInfo);
            //}
        }

        public void SendNotification(List<string> userList, string messageText)
        {
            if (userList.Count > 0)
            {
                TTUtils.AtlasNotificationContainer atlasNotification = new TTUtils.AtlasNotificationContainer();
                atlasNotification.users = userList;
                atlasNotification.notificationType = TTUtils.AtlasNotificationType.Info;
                atlasNotification.contentType = TTUtils.AtlasContentType.Notification;

                atlasNotification.content = messageText;
                string notificationStr = JsonConvert.SerializeObject(atlasNotification);

                TTUtils.AtlasSignalRHubFactory.Instance.HandleUserNotification(notificationStr);
            }
        }
    }
}