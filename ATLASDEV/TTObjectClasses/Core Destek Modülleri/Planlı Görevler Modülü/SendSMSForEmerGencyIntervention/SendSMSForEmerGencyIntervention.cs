
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
namespace TTObjectClasses
{
    /// <summary>
    /// Müşahade süresi 24 saati geçenler için Sorumlulara mesaj atar
    /// </summary>
    public partial class SendSMSForEmerGencyIntervention : BaseScheduledTask
    {
        public override void TaskScript()
        {
            TTObjectContext objectContext = new TTObjectContext(false);

            string logInfo = string.Empty;
            DateTime dateNow = Common.RecTime();
            int dateLimit = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("SENDEMERGENCYSMSDAYLIMIT", "3"));


            BindingList<EmergencyIntervention> emergencyList = EmergencyIntervention.GetEmergencyIntByObservationTime(objectContext, dateNow.Date.AddDays(dateLimit * -1), dateNow.Date);

            List<ResDepartment> departmentList = new List<ResDepartment>();

            var responsibleChief = TTObjectClasses.SystemParameter.GetParameterValue("EMERGENCYRESPONSIBLECHIEF", "");
            var responsibleDoctor = TTObjectClasses.SystemParameter.GetParameterValue("EMERGENCYRESPONSIBLEDOCTOR", "");

            if (responsibleChief != "" && responsibleDoctor != "")
            {
                var chiefInfo = (ResUser)objectContext.GetObject(new Guid(responsibleChief), "RESUSER");
                var drInfo = (ResUser)objectContext.GetObject(new Guid(responsibleDoctor), "RESUSER");

                if (chiefInfo.PhoneNumber != null || drInfo.PhoneNumber != null)
                {
                    foreach (EmergencyIntervention _emergency in emergencyList)
                    {
                        try
                        {
                            TimeSpan span = DateTime.Now - _emergency.InpatientObservationTime.Value;

                            if (span.TotalHours >= 24)
                            {

                                string messageText = DateTime.Now + " tarihinde " + _emergency.Episode.Patient.Name + " " + _emergency.Episode.Patient.Surname + " isimli hasta 24 saati aşkın bir süredir 'Acil Müşahede' servisinde bulunmaktadır.";

                                if (!string.IsNullOrEmpty(chiefInfo.PhoneNumber))
                                {
                                    SendSMS(chiefInfo, _emergency, messageText, SMSTypeEnum.EmergencyInterventionSMSForChief);
                                }
                                else
                                {
                                    logInfo = " Acil servisten sorumlu başhekim yardımcısının telefon numarası boş olduğu için SMS atılamamıştır ";
                                    AddLog(logInfo);
                                }

                                if (!string.IsNullOrEmpty(drInfo.PhoneNumber))
                                {
                                    SendSMS(drInfo, _emergency, messageText, SMSTypeEnum.EmergencyInterventionSMSForDoctor);
                                }
                                else
                                {
                                    logInfo = " Acil servisten sorumlu hekimin telefon numarası boş olduğu için SMS atılamamıştır ";
                                    AddLog(logInfo);
                                }
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
                else
                {
                    logInfo = " Acilden sorumlu Başhekim ve Doktorun telefon numaraları boş olduğu için SMS atılamamıştır";
                    AddLog(logInfo);
                }
            }
            else
            {
                logInfo = " Acil Servisten sorumlu Başhekim veya Sorumlu doktor tanımlı olmadığı için SMS gönderme işlemi başlatılamamıştır";
                AddLog(logInfo);
            }
        }

        public void SendSMS(ResUser resUser, EmergencyIntervention _emergency, string messageText, SMSTypeEnum smsType)
        {
            UserMessage userMessage = new UserMessage();
            bool smsResponse = false;
            string logInfo = string.Empty;

            List<ResUser> users = new List<ResUser> { resUser };
            smsResponse = userMessage.SendSMSPerson(users, messageText, smsType);
            //if (smsResponse)
            //{
            //    logInfo = "BAŞARILI:" + _emergency.Episode.Patient.ObjectID + " id 'li hasta için " + _emergency.ObjectID + "id 'li triaj bilgisine dair bilgi " + resUser.Name + " isimli kullnıcının " + resUser.PhoneNumber + " numaralı telefonuna  SMS olarak gönderilmiştir";
            //    AddLog(logInfo);
            //}
            //else
            //{
            //    logInfo = "HATA:" + _emergency.Episode.Patient.ObjectID + " id 'li hasta için " + _emergency.ObjectID + "id 'li triaj bilgisine dair bilgi " + resUser.Name + " isimli kullnıcının " + resUser.PhoneNumber + " numaralı telefonuna  SMS olarak gönderilirken hata alınmıştır";
            //    AddLog(logInfo);
            //}
        }
    }
}