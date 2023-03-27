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
    /// Poliklinik Muayeneleri Gecikmesi için Doktora SMS Gönderme İşlemi
    /// </summary>
    public partial class SendSMSDoctorForExamDelay : BaseScheduledTask
    {
        public override void TaskScript()
        {

            TTObjectContext objectContext = new TTObjectContext(false);

            DateTime dateNow = Common.RecTime();

            BindingList<PatientExaminationDoctorInfo> doctorList = PatientExaminationDoctorInfo.GetNotSMSsendDoctorList(objectContext);
            foreach (var doctorInfo in doctorList)
            {
                if (doctorInfo.ResUser != null && doctorInfo.ResUser.PhoneNumber != null)
                {
                    var poliklinic = (ResPoliclinic)doctorInfo.PatientExamination.MasterResource;
                    if (poliklinic.ResourceStartTime.HasValue) // Poliklinik başlama saati varsa
                    {
                        TimeSpan resourceStartTime = poliklinic.ResourceStartTime.Value.TimeOfDay;
                        if (poliklinic.OptionalDelayMinute.HasValue && poliklinic.OptionalDelayMinute.Value > 0)
                            resourceStartTime = poliklinic.ResourceStartTime.Value.AddMinutes(poliklinic.OptionalDelayMinute.Value).TimeOfDay;

                        if (resourceStartTime < dateNow.TimeOfDay) //poliklinik başlama saati geçmişse
                        {
                            try
                            {
                                UserMessage userMessage = new UserMessage();

                                string messageText = "Bugün saat " + dateNow + " itibariyle " + (poliklinic.Department != null ? poliklinic.Department.Building.Name : "") + " " + poliklinic.Name + " polikliniğinde hasta muayene işlemleri başlamamıştır.Poliklinik başlama saati " + resourceStartTime.ToString() + " Bilgilerinize.";

                                if (!string.IsNullOrEmpty(messageText))
                                {
                                    List<ResUser> users = new List<ResUser> { doctorInfo.ResUser };
                                    userMessage.SendSMSPerson(users, messageText, SMSTypeEnum.ExamDelaySMSForDoctor);
                                    doctorInfo.IsSMSsendForDoctor = true;
                                }
                                objectContext.Save();
                                //Doktorun işlemi güncelleniyor
                                //BindingList<PatientExaminationDoctorInfo> doctorRecordForToday = PatientExaminationDoctorInfo.GetDoctorRecordForToday(ObjectContext, doctorInfo.ResUser.ObjectID);

                                //if (doctorRecordForToday.Count > 0)
                                //{
                                //    doctorRecordForToday.FirstOrDefault().IsSMSsendForDoctor = true;
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
    }
}