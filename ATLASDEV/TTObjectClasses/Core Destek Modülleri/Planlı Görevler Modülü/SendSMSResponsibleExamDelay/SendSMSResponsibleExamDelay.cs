
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
using AtlasDataModel;

namespace TTObjectClasses
{
    /// <summary>
    /// Poliklinik Muayeneleri Gecikmesi için Klinik/Branş İdari Sorumluşuna SMS Gönderme İşlemi
    /// </summary>
    public partial class SendSMSResponsibleExamDelay : BaseScheduledTask
    {
        public override void TaskScript()
        {

            // using (var context = AtlasDbContextFactory.Instance.CreateDbContext())
            // {
            TTObjectContext objectContext = new TTObjectContext(false);

            DateTime dateNow = Common.RecTime();

            BindingList<PatientExaminationDoctorInfo> doctorList = PatientExaminationDoctorInfo.GetNotSMSsendResponsibleList(objectContext);
            //var doctorList = context.PatientExaminationDoctorInfo.Where(p => p.ExaminationDate.Value.Date == dateNow.Date && p.IsActiveFlag == true && p.ExaminationFlag == false && p.IsSMSsendForResponsible == false);
            List<SpecialityDefinition> specialityList = new List<SpecialityDefinition>();//SMS atılan branşlara tekrar SMS atılmaması için tutulan liste
            List<ResUser> userList = new List<ResUser>();//SMS atılan branşlara tekrar SMS atılmaması için tutulan liste
            Dictionary<Guid, List<Guid>> responsibleUserResourceList = new Dictionary<Guid, List<Guid>>();
            foreach (var doctorInfo in doctorList)
            {
                //PatientExaminationDoctorInfo doctorInfo = objectContext.GetObject<PatientExaminationDoctorInfo>(dInfo.ObjectId);
                if (doctorInfo.ResUser != null)
                {
                    try
                    {
                        UserMessage userMessage = new UserMessage();
                        var poliklinic = (ResPoliclinic)doctorInfo.PatientExamination.MasterResource;
                        if (poliklinic.ResourceStartTime.HasValue) // Poliklinik başlama saati varsa
                        {
                            TimeSpan resourceStartTime = poliklinic.ResourceStartTime.Value.TimeOfDay;
                            if (poliklinic.OptionalDelayMinute.HasValue && poliklinic.OptionalDelayMinute.Value > 0)
                                resourceStartTime = poliklinic.ResourceStartTime.Value.AddMinutes(poliklinic.OptionalDelayMinute.Value).TimeOfDay;

                            if (resourceStartTime < dateNow.TimeOfDay) //poliklinik başlama saati geçmişse
                            {
                                //TODO: Burcu Biltekin - Mustafa KIZILKAYA. Düzenleme gerekebelir
                                string messageText = "Bugün saat " + dateNow + " itibariyle " + (poliklinic.Department != null ? poliklinic.Department.Building.Name : "") + " " + poliklinic.Name + " polikliniğinde hasta muayene işlemleri başlamamıştır.Poliklinik başlama saati " + resourceStartTime.ToString() + " Bilgilerinize.";
                                foreach (ResponsibleUsersGrid respUser in poliklinic.ResponsibleUsers)
                                {
                                    List<Guid> polObjIDList = new List<Guid>();
                                    if (respUser.ResUser != null && respUser.ResUser.PhoneNumber != null)
                                    {

                                        bool isKeyExists = responsibleUserResourceList.TryGetValue(respUser.ResUser.ObjectID, out polObjIDList);
                                        List<ResUser> users = new List<ResUser> { respUser.ResUser };

                                        if (isKeyExists)
                                        {
                                            if (polObjIDList.Contains(poliklinic.ObjectID) == false) //Bu kullanıcıya SMS atıldı ise tekrar SMS atılmasın
                                            {
                                                polObjIDList.Add(poliklinic.ObjectID);
                                                responsibleUserResourceList[respUser.ResUser.ObjectID] = polObjIDList;
                                                userMessage.SendSMSPerson(users, messageText, SMSTypeEnum.ExamDelaySMSForResponsible);
                                                doctorInfo.IsSMSsendForResponsible = true;
                                                //userList.Add(respUser.ResUser);
                                            }
                                        }
                                        else
                                        {
                                            polObjIDList = new List<Guid>();
                                            polObjIDList.Add(poliklinic.ObjectID);
                                            responsibleUserResourceList.Add(respUser.ResUser.ObjectID, polObjIDList);
                                            userMessage.SendSMSPerson(users, messageText, SMSTypeEnum.ExamDelaySMSForResponsible);
                                            doctorInfo.IsSMSsendForResponsible = true;
                                        }
                                    }
                                }

                                foreach (var _speciality in poliklinic.ResourceSpecialities)
                                {
                                    if (_speciality.Speciality != null && _speciality.Speciality.SpecialityResponsibleUser != null && _speciality.Speciality.SpecialityResponsibleUser.PhoneNumber != null)
                                    {
                                        List<Guid> polObjIDList = new List<Guid>();
                                        bool isKeyExists = responsibleUserResourceList.TryGetValue(_speciality.Speciality.SpecialityResponsibleUser.ObjectID, out polObjIDList);
                                        List<ResUser> users = new List<ResUser> { _speciality.Speciality.SpecialityResponsibleUser };
                                        if (isKeyExists)
                                        {
                                            if (polObjIDList.Contains(poliklinic.ObjectID) == false) //Bu kullanıcıya SMS atıldı ise tekrar SMS atılmasın
                                            {
                                                polObjIDList.Add(poliklinic.ObjectID);
                                                responsibleUserResourceList[_speciality.Speciality.SpecialityResponsibleUser.ObjectID] = polObjIDList;
                                                userMessage.SendSMSPerson(users, messageText, SMSTypeEnum.ExamDelaySMSForResponsible);
                                                doctorInfo.IsSMSsendForResponsible = true;
                                            }
                                        }
                                        else
                                        {
                                            polObjIDList = new List<Guid>();
                                            polObjIDList.Add(poliklinic.ObjectID);
                                            responsibleUserResourceList.Add(_speciality.Speciality.SpecialityResponsibleUser.ObjectID, polObjIDList);
                                            userMessage.SendSMSPerson(users, messageText, SMSTypeEnum.ExamDelaySMSForResponsible);
                                            doctorInfo.IsSMSsendForResponsible = true;
                                        }
                                    }
                                }

                                //Doktorun işlemi güncelleniyor
                                //BindingList<PatientExaminationDoctorInfo> doctorRecordForToday = PatientExaminationDoctorInfo.GetDoctorRecordForToday(ObjectContext, doctorInfo.ResUser.ObjectID);

                                //if (doctorRecordForToday.Count > 0)
                                //{
                                //    doctorRecordForToday.FirstOrDefault().IsSMSsendForResponsible = true;
                                //}
                                objectContext.Save();
                            }
                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }

                }
                //}
            }
        }
    }
}