
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
    /// Aşı Randevuları İçin Hastaya SMS Gönderme İşlemi
    /// </summary>
    public partial class SendSMSForVaccineApp : BaseScheduledTask
    {
        public override void TaskScript()
        {
            string smsVaccineActive = TTObjectClasses.SystemParameter.GetParameterValue("SMSVACCINEACTIVE", "FALSE");

            if (smsVaccineActive == "TRUE")
            {
                TTObjectContext objectContext = new TTObjectContext(false);
                //Queryye tarih eklenecek
                DateTime startDate = Convert.ToDateTime(DateTime.Now.AddDays(1).ToString("yyyy/MM/dd 00:00:00"));
                DateTime endDate = Convert.ToDateTime(startDate.AddDays(1).ToString("yyyy/MM/dd 00:00:00"));

                BindingList<VaccineSmsInfo> smsList = VaccineSmsInfo.GetSendToBeSmsInfo(objectContext, startDate, endDate); //Sms gönderilecek aşılar

                foreach (VaccineSmsInfo smsInfo in smsList)
                {
                    try
                    {

                        UserMessage userMessage = new UserMessage();
                        Patient patient = smsInfo.VaccineDetail.Patient;
                        string messageText = "Yeni doğan ailesi " + patient.UniqueRefNo + " kimlik numaralı " + patient.Name + " " + patient.Surname + " bebeğinizin " + Convert.ToDateTime(smsInfo.VaccineDetail.AppointmentDate).ToString("dd.MM.yyyy") + " tarihli " + smsInfo.VaccineDetail.SKRSAsiKodu.ADI + " aşısı yapılacaktır. ";
                        List<Patient> patients = new List<Patient> { patient };
                        userMessage.SendSMSPatient(patients, messageText,SMSTypeEnum.VaccineActiveSMSForPatient);
                        smsInfo.CompletedFlag = true;
                        objectContext.Save();

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