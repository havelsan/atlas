
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
    /// Patoloji Gecikmeleri için Başhekim Yardımcısına SMS Gönderme İşlemi
    /// </summary>
    public partial class SendSMSChiefPATDelay : BaseScheduledTask
    {
        public override void TaskScript() //Eklenme tarihinden itibaren 14 gün geçen patolojiler için sms gönderme
        {
            string smsPathologyActive = TTObjectClasses.SystemParameter.GetParameterValue("SMSPATHOLOGYACTIVE", "FALSE");

            if (smsPathologyActive == "TRUE")
            {
                TTObjectContext objectContext = new TTObjectContext(false);

                BindingList<EpisodeActionSMSInfo> smsList = EpisodeActionSMSInfo.GetSendToBeSmsInfo(objectContext, 14, "PATHOLOGY", " AND SMSNUMBERFORCHIEF=0 "); //Sms gönderilecek patolojiler

                foreach (EpisodeActionSMSInfo smsInfo in smsList)
                {
                    try
                    {
                        Pathology pathology = smsInfo.EpisodeAction as Pathology;

                        var sysParameter = TTObjectClasses.SystemParameter.GetParameterValue("CHIEFIDFORPATHOLOGYSMS", "");
                        if (String.IsNullOrEmpty(sysParameter))
                            return;
                        var doctorInfo = (ResUser)objectContext.GetObject(new Guid(sysParameter), "RESUSER", false);
                        if (doctorInfo == null)
                            return;


                        if (doctorInfo.PhoneNumber != "")
                        {
                            string procedureDoctorName = pathology.ProcedureDoctor == null ? "" : pathology.ProcedureDoctor.Name;
                            UserMessage userMessage = new UserMessage();
                            Patient patient = pathology.SubEpisode.Episode.Patient;
                            string tc = patient.UniqueRefNo == null ? "" : patient.UniqueRefNo.ToString();

                            string messageText = pathology.MatPrtNoString + " protokol numaralı, " + patient.Name + " " + patient.Surname + " isimli," + tc + " kimlik numaralı hastanın rapor yazımı için belirlenen süre aşılmıştır.Doktoru:" + procedureDoctorName + " Bilgilerinize.";
                            List<ResUser> users = new List<ResUser> { doctorInfo };
                            userMessage.SendSMSPerson(users, messageText, SMSTypeEnum.PathologyReportDelaySMSForChief);
                            smsInfo.SMSNumberForChief++;
                            smsInfo.ChiefUserID = doctorInfo.ObjectID;
                            objectContext.Save();
                        }
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