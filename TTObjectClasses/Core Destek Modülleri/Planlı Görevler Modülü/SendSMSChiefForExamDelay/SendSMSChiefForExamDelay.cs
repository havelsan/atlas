
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
    /// Poliklinik Muayeneleri Gecikmesi için Başhekim Yardımcısına SMS Gönderme İşlemi
    /// </summary>
    public partial class SendSMSChiefForExamDelay : BaseScheduledTask
    {
        public override void TaskScript()
        {

            TTObjectContext objectContext = new TTObjectContext(false);

            DateTime dateNow = Common.RecTime();

            BindingList<PatientExaminationDoctorInfo> doctorList = PatientExaminationDoctorInfo.GetNotSMSsendChiefList(objectContext);
            List<Guid> polIDList = new List<Guid>();

            var sysParameter = TTObjectClasses.SystemParameter.GetParameterValue("POLICLINICRESPONSIBLECHIEF", "");
            if (String.IsNullOrEmpty(sysParameter))
                return;
            var chiefInfo = (ResUser)objectContext.GetObject(new Guid(sysParameter), "RESUSER", false);
            if (chiefInfo == null)
                return;

            if (chiefInfo.PhoneNumber != null)
            {
                foreach (var doctorInfo in doctorList)
                {
                    try
                    {
                        var poliklinic = (ResPoliclinic)doctorInfo.PatientExamination.MasterResource;
                        if (poliklinic.ResourceStartTime.HasValue) // Poliklinik başlama saati varsa
                        {
                            TimeSpan resourceStartTime = poliklinic.ResourceStartTime.Value.TimeOfDay;
                            if (poliklinic.OptionalDelayMinute.HasValue && poliklinic.OptionalDelayMinute.Value > 0)
                                resourceStartTime = poliklinic.ResourceStartTime.Value.AddMinutes(poliklinic.OptionalDelayMinute.Value).TimeOfDay;

                            if (resourceStartTime < dateNow.TimeOfDay) //poliklinik başlama saati geçmişse
                            {
                                if (polIDList.Contains(poliklinic.ObjectID) == false)//bölüm için SMS gönderildi ise tekrar gönderilmesin.
                                {
                                    UserMessage userMessage = new UserMessage();
                                    string messageText = "Bugün saat " + dateNow + " itibariyle " + (poliklinic.Department != null ? poliklinic.Department.Building.Name : "") + " " + poliklinic.Name + " polikliniğinde hasta muayene işlemleri başlamamıştır.Poliklinik başlama saati " + resourceStartTime.ToString() + " Bilgilerinize.";

                                    if (!string.IsNullOrEmpty(messageText))
                                    {
                                        List<ResUser> users = new List<ResUser> { chiefInfo };
                                        userMessage.SendSMSPerson(users, messageText, SMSTypeEnum.ExamDelaySMSForChief);
                                        polIDList.Add(poliklinic.ObjectID);
                                        doctorInfo.IsSMSsendForChief = true;
                                        objectContext.Save();
                                    }
                                }
                            }
                        }
                        //Doktorun işlemi güncelleniyor
                        //BindingList<PatientExaminationDoctorInfo> doctorRecordForToday = PatientExaminationDoctorInfo.GetDoctorRecordForToday(ObjectContext, doctorInfo.ResUser.ObjectID);

                        //if (doctorRecordForToday.Count > 0)
                        //{
                        //    doctorRecordForToday.FirstOrDefault().IsSMSsendForChief = true;
                        //}
                    }
                    catch (Exception)
                    {
                        throw;
                    }


                }
            }

        }
    }
}