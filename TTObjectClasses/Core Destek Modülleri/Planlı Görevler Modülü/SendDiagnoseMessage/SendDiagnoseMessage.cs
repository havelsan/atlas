
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
    /// Hastaya belirlenmiş bir tanı konulduğunda belirlenmiş bir kullanıcıya sms atmak için oluşturuldu.
    /// </summary>
    public partial class SendDiagnoseMessage : BaseScheduledTask
    {
        public override void TaskScript()
        {
            Dictionary<Guid, List<Patient>> OutPatientList = new Dictionary<Guid, List<Patient>>();
            Dictionary<Guid, List<Patient>> InPatientList = new Dictionary<Guid, List<Patient>>();
            Dictionary<Guid, int> dictionaryForOutPatient = new Dictionary<Guid, int>();
            Dictionary<Guid, int> dictionaryForInPatient = new Dictionary<Guid, int>();

            try
            {
                //AddLog("SendDiagnoseSMS has started");
                TTObjectContext objectcontext = new TTObjectContext(true);
                UserMessage message = new UserMessage();
                List<TaniyaBagliSMSGonderim> diagnoseUserList = TaniyaBagliSMSGonderim.GetDataForTaniyaBagliSMS(objectcontext, "").ToList();

                foreach (TaniyaBagliSMSGonderim item in diagnoseUserList)
                {
                    var inDiagnoseExist = InPatientList.ContainsKey(item.Diagnosis.ObjectID);
                    var outDiagnoseExist = OutPatientList.ContainsKey(item.Diagnosis.ObjectID);

                    if (inDiagnoseExist == false)
                    {
                        dictionaryForInPatient.Add(item.Diagnosis.ObjectID, 0);
                        InPatientList.Add(item.Diagnosis.ObjectID, new List<Patient>());
                    }
                    if (outDiagnoseExist == false)
                    {
                        dictionaryForOutPatient.Add(item.Diagnosis.ObjectID, 0);
                        OutPatientList.Add(item.Diagnosis.ObjectID, new List<Patient>());
                    }
                    var date = Common.RecTime().Date;
                    List<DiagnosisSubEpisode> diagnosisSubepisodeList = DiagnosisSubEpisode.GetDataForDiagnoseSMS(objectcontext, date, item.Diagnosis.ObjectID, date.AddDays(1).AddSeconds(-1)).ToList();
                    foreach (DiagnosisSubEpisode data in diagnosisSubepisodeList)
                    {

                        if (data.SubEpisode.PatientStatus == SubEpisodeStatusEnum.Inpatient || data.SubEpisode.PatientStatus == SubEpisodeStatusEnum.Daily)
                        {
                            //hasta aynı gun icerisinde farkli polikliniklere gelmisse ve aynı tanı konulmussa farklı subepisode'ları 2 kez saymamak icin hastaları say
                            var patientExist = InPatientList[item.Diagnosis.ObjectID].Where(patient => patient.ObjectID == data.SubEpisode.Episode.Patient.ObjectID).FirstOrDefault();
                            if (patientExist == null)
                            {
                                Patient patient = data.SubEpisode.Episode.Patient;
                                InPatientList[item.Diagnosis.ObjectID].Add(patient);
                                dictionaryForInPatient[item.Diagnosis.ObjectID]++;
                            }
                        }

                        if (data.SubEpisode.PatientStatus == SubEpisodeStatusEnum.Outpatient)
                        {
                            var patientExist = OutPatientList[item.Diagnosis.ObjectID].Where(patient => patient.ObjectID == data.SubEpisode.Episode.Patient.ObjectID).FirstOrDefault();
                            if (patientExist == null)
                            {
                                Patient patient = data.SubEpisode.Episode.Patient;
                                OutPatientList[item.Diagnosis.ObjectID].Add(patient);
                                dictionaryForOutPatient[item.Diagnosis.ObjectID]++;
                            }
                        }
                    }

                }
                foreach (TaniyaBagliSMSGonderim item in diagnoseUserList)
                {
                    List<ResUser> users = new List<ResUser>();
                    users.Add(item.ResUser);
                    try
                    {
                        string smsText = string.Empty;
                        if (item.Outpatient == true && item.Inpatient == true)
                        {
                            var exist = InPatientList[item.Diagnosis.ObjectID].Where(patient => OutPatientList[item.Diagnosis.ObjectID].Where(outPatient => patient.ObjectID == outPatient.ObjectID).FirstOrDefault() != null).Count();
                            // var commonDictionaryItems = dictionaryForOutPatient.Where(d => dictionaryForInPatient.ContainsKey(item.Diagnosis.ObjectID)).ToList();
                            var outPatientNumber = dictionaryForOutPatient[item.Diagnosis.ObjectID] - exist;
                            smsText = "Sayın Yetkili, " + "\"" + item.Diagnosis.Code + "\"" + " tanı kodu " + Common.RecTime().Date + " tarihinde toplam " + outPatientNumber + " sayıda ayaktan hastaya ve "
                                + dictionaryForInPatient[item.Diagnosis.ObjectID] + " sayıda yatan hastaya girilmiştir.";


                        }
                        else if (item.Outpatient == true)
                        {
                            smsText = "Sayın Yetkili, " + "\"" + item.Diagnosis.Code + "\"" + " tanı kodu " + Common.RecTime().Date + " tarihinde toplam " + dictionaryForOutPatient[item.Diagnosis.ObjectID] + " sayıda ayaktan hastaya girilmiştir.";
                        }
                        else if (item.Inpatient == true)
                        {
                            smsText = "Sayın Yetkili, " + "\"" + item.Diagnosis.Code + "\"" + " tanı kodu " + Common.RecTime().Date + " tarihinde toplam " + dictionaryForInPatient[item.Diagnosis.ObjectID] + " sayıda yatan hastaya girilmiştir.";
                        }

                        message.SendSMSPerson(users, smsText, SMSTypeEnum.DiagnosisCountInfoSMS);
                    }
                    catch (Exception e)
                    {
                        continue;
                    }
                }
                objectcontext.Save();

            }
            catch (Exception ex)
            {
                //   AddLog("ERROR: " + ex.ToString());
            }
        }
    }
}
