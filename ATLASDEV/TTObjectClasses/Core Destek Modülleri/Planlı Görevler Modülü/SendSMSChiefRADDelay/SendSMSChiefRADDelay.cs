
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
    /// Radyoloji Gecikmeleri için Başhekim Yardımcısına SMS Gönderme İşlemi
    /// </summary>
    public partial class SendSMSChiefRADDelay : BaseScheduledTask
    {
        public override void TaskScript()
        {
            string smsRadiologyActive = TTObjectClasses.SystemParameter.GetParameterValue("SMSRADIOLOGYACTIVE", "FALSE");

            if (smsRadiologyActive == "TRUE")
            {

                string dayLimit = TTObjectClasses.SystemParameter.GetParameterValue("RADIOLOGYSMSDAYLIMIT", "");

                if (dayLimit != "")
                {
                    TTObjectContext objectContext = new TTObjectContext(false);

                    BindingList<SubactionProcedureSMSInfo> smsList = SubactionProcedureSMSInfo.GetSPSendToBeSMSInfo(objectContext, "RADIOLOGYTEST", Convert.ToInt32(dayLimit) + 2, " AND SMSNUMBERFORCHIEF = 0"); //Sms gönderilecek radyolojiler

                    foreach (SubactionProcedureSMSInfo smsInfo in smsList)
                    {
                        try
                        {
                            var sysParameter = TTObjectClasses.SystemParameter.GetParameterValue("CHIEFIDFORRADIOLOGYSMS", "");
                            if (String.IsNullOrEmpty(sysParameter))
                                return;
                            var doctorInfo = (ResUser)objectContext.GetObject(new Guid(sysParameter), "RESUSER", false);
                            if (doctorInfo == null)
                                return;
                            ResUser user = doctorInfo;

                            var radiologyTest = (RadiologyTest)objectContext.GetObject(new Guid(smsInfo.SubactionProcedureID.ToString()), "RADIOLOGYTEST", false);

                            Patient patient = radiologyTest.SubEpisode.Episode.Patient;
                            if (user.PhoneNumber != "")
                            {

                                UserMessage userMessage = new UserMessage();
                                string day = (Convert.ToInt32(dayLimit) + 2).ToString();
                                string messageText = patient.Name + " " + patient.Surname + " isimli hastanın " + radiologyTest.ProcedureObject.Name + " çekimi yapılmıştır. Rapor yazımı " + day + " gün içerisinde sonuçlandırılmamıştır.Bilgilerinize.";
                                List<ResUser> users = new List<ResUser> { user };
                                userMessage.SendSMSPerson(users, messageText, SMSTypeEnum.RadiologyReportDelaySMSForChief);
                                smsInfo.SMSNumberForChief++;
                                smsInfo.ChiefUserID = user.ObjectID;
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
}