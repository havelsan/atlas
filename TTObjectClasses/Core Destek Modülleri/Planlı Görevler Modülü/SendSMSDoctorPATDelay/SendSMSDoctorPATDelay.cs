
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
    /// Patoloji Gecikmeleri için Doktora SMS Gönderme İşlemi
    /// </summary>
    public partial class SendSMSDoctorPATDelay : BaseScheduledTask
    {
        public override void TaskScript() //Eklenme tarihinden itibaren 10 gün geçen patolojiler için sms gönderme
        {
            string smsPathologyActive = TTObjectClasses.SystemParameter.GetParameterValue("SMSPATHOLOGYACTIVE", "FALSE");

            if (smsPathologyActive == "TRUE")
            {
                TTObjectContext objectContext = new TTObjectContext(false);

                BindingList<EpisodeActionSMSInfo> smsList = EpisodeActionSMSInfo.GetSendToBeSmsInfo(objectContext, 10, "PATHOLOGY", " AND SMSNUMBERFORDOCTOR=0 "); //Sms gönderilecek patolojiler

                foreach (EpisodeActionSMSInfo smsInfo in smsList)
                {
                    try
                    {
                        Pathology pathology = smsInfo.EpisodeAction as Pathology;
                        ResUser user;
                        if (pathology.ProcedureDoctor != null)
                        {
                            user = pathology.ProcedureDoctor;
                        }
                        else //Raporun doktoru yoksa parametreden kullanıcı alınacak
                        {
                            var sysParameter = TTObjectClasses.SystemParameter.GetParameterValue("DOCTORIDFORPATHOLOGYSMS", "");
                            if (String.IsNullOrEmpty(sysParameter))
                                return;
                            var doctorInfo = (ResUser)objectContext.GetObject(new Guid(sysParameter), "RESUSER", false);
                            if (doctorInfo == null)
                                return;
                            user = doctorInfo;


                        }

                        if (user.PhoneNumber != "")
                        {

                            UserMessage userMessage = new UserMessage();
                            Patient patient = pathology.SubEpisode.Episode.Patient;
                            string tc = patient.UniqueRefNo == null ? "" : patient.UniqueRefNo.ToString();
                            string messageText = pathology.MatPrtNoString + " protokol numaralı, " + patient.Name + " " + patient.Surname + " isimli," + tc + " kimlik numaralı hastanın rapor yazımı için belirlenen süre aşılmıştır. Bilgilerinize.";
                            List<ResUser> users = new List<ResUser> { user };
                            userMessage.SendSMSPerson(users, messageText, SMSTypeEnum.PathologyReportDelaySMSForForDoctor);
                            smsInfo.SMSNumberForDoctor++;
                            smsInfo.DoctorUserID = user.ObjectID;
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