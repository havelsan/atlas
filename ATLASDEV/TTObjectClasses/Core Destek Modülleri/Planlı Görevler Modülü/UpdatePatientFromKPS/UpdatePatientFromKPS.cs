
using System;
using System.Linq;
using System.Collections.Generic;

using TTInstanceManagement;

namespace TTObjectClasses
{
    /// <summary>
    /// KPS üserinden hasta bilgilerini düzenler
    /// </summary>
    public partial class UpdatePatientFromKPS : BaseScheduledTask
    {
        public override void TaskScript()
        {
            string logTxt = "UpdatePatientFromKPS Has Started : " + Common.RecTime();
            try
            {
                List<SubEpisode.GetPatientsIDByNullSys_Class> patients = new List<SubEpisode.GetPatientsIDByNullSys_Class>();

                int dateLimit = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("KPSUPDATEDATELMIT", "2"));
                string _filter = " AND OPENINGDATE BETWEEN TODATE('" + Convert.ToDateTime(Common.RecTime().Date.AddMonths(-dateLimit)).ToString("yyyy-MM-dd HH:mm:ss") + "') AND TODATE('" + Convert.ToDateTime(Common.RecTime().Date).ToString("yyyy-MM-dd HH:mm:ss") + "')";
                //string _filter = " AND Episode.Patient.OBJECTID IN('0160ba12-0018-4302-9d00-6b828cfd91bf','43c30272-79f0-4d57-8066-477af6a5fe62','1e94e71f-bd19-40ae-94f7-3bc2a2fb2f32')";

                patients = SubEpisode.GetPatientsIDByNullSys(_filter).ToList();

                foreach (SubEpisode.GetPatientsIDByNullSys_Class p in patients)
                {
                    try
                    {
                        using (TTObjectContext objectContext = new TTObjectContext(false))
                        {
                            if (!string.IsNullOrEmpty(p.KPSPassword) && !string.IsNullOrEmpty(p.KPSUserName) && p.UniqueRefNo.HasValue)
                            {
                                Patient _patient = objectContext.GetObject(p.ObjectID.Value, typeof(Patient)) as Patient;

                                if (_patient.UniqueRefNo.HasValue)
                                {
                                    Patient.MernisPatientModel mernisPatientModel = GetPatientandAdresInfoFromKPS(_patient, false, p.KPSPassword, p.KPSUserName, p.UniqueRefNo.Value, objectContext);

                                    /* KPS yüzünden gitmeyen 101 paketleri varsa onlar için tekrar ekle*/
                                    Add101PackageOldSE(_patient.ObjectID);//KPS yüzendek

                                    objectContext.Save();
                                    logTxt = _patient.ObjectID + " id'li ve" + _patient.UniqueRefNo + " kimlik numaralý için sorgulama yapýldý ve 101 paketi atýldý.";
                                    AddLog(logTxt);
                                }
                            }

                        }
                    }

                    catch (Exception e)
                    {
                        string _error = e.Message + (e.InnerException != null ? e.InnerException.Message : "");
                        logTxt = p.ObjectID + "id'li ve " + p.UniqueRefNo + " kimlik numaralý hasta için 101 paketi atýlamadý. Alýnan hata: " + _error;
                        AddLog(logTxt);
                    }
                }

                //objectContext.Save();

                //logTxt += " - Has Finished Succesfully : " + Common.RecTime();

            }
            catch (Exception ex)
            {
                logTxt = " - ERROR: " + ex.ToString() + ": " + Common.RecTime();
                AddLog(logTxt);
            }

            
        }

        public void Add101PackageOldSE(Guid patientID)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                List<SubEpisode> subEpisodes = SubEpisode.GetByPatient(objectContext, patientID).ToList();

                foreach (var _subepisode in subEpisodes)
                {
                    if (_subepisode.SYSTakipNo == null && _subepisode.Sent101Package.HasValue && _subepisode.Sent101Package.Value && _subepisode.PatientAdmission.IsOldAction != true)
                        new SendToENabiz(objectContext, _subepisode, _subepisode.ObjectID, _subepisode.ObjectDef.Name, "101", Common.RecTime());
                }
                objectContext.Save();
            }
        }

        public Patient.MernisPatientModel GetPatientandAdresInfoFromKPS(Patient _patient, bool _newPatient, string KPSPassword, string KPSUserName, long UniqueRefNo, TTObjectContext ctx)
        {
            #region PatientAdmissionForm_AdresBilgisisorgula
            try
            {
                if (_patient.UniqueRefNo != null)
                {
                    KPSV2.KpsServisSonucuBilesikKisiBilgisi response = BilesikKisiveAdresSorgulaSync_ServerSide(Convert.ToInt64(_patient.UniqueRefNo), KPSPassword, KPSUserName, UniqueRefNo);

                    if (response.HataBilgisi == null)
                    {
                        if (response.Sonuc.HataBilgisi == null)
                        {
                            if (response.Sonuc.MaviKartliKisiKutukleri != null)
                                return Patient.GetMaviKartliKisiKutukleriFromKPS(response.Sonuc.MaviKartliKisiKutukleri, _patient, _newPatient, ctx);
                            else if (response.Sonuc.TCVatandasiKisiKutukleri != null) //3.sýraya al
                                return Patient.GetTCVatandasiKisiKutukleriFromKPS(response.Sonuc.TCVatandasiKisiKutukleri, _patient, _newPatient, ctx);
                            else if (response.Sonuc.YabanciKisiKutukleri != null)
                                return Patient.GetYabanciKisiKutukleriFromKPS(response.Sonuc.YabanciKisiKutukleri, _patient, _newPatient, ctx);

                        }
                        else
                        {
                            //TTUtils.InfoMessageService.Instance.ShowMessage(response.Sonuc.HataBilgisi.Aciklama);
                            return null;
                        }
                    }
                    else
                    {
                        //TTUtils.InfoMessageService.Instance.ShowMessage(response.HataBilgisi.Aciklama);
                        return null;
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new TTUtils.TTException(ex.Message);
            }
            #endregion PatientAdmissionForm_AdresBilgisisorgula_Click
        }


        private KPSV2.KpsServisSonucuBilesikKisiBilgisi BilesikKisiveAdresSorgulaSync_ServerSide(long kimlikNo, string KPSPassword, string KPSUserName, long UniqueRefNo)
        {

            #region BilesikKisiveAdresSorgulaSync_Body
            TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
            header.Namespace = "TTObjectClasses.KPSV2";
            header.ServiceId = "2f15c1c6-dc24-4c65-92a6-dd5812afeffe";
            header.MethodName = "BilesikKisiveAdresSorgula";
            header.CallTimeout = 600;
            header.CallerId = UniqueRefNo;
            header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID", "");
            header.ServiceType = TTUtils.ServiceType.SOAP;
            IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                {
                    Tuple.Create("kimlikNo", (object)kimlikNo),
                };

            TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
            credential.UserName = KPSUserName;
            credential.Password = KPSPassword;
            credential.ApplicationCode = TTObjectClasses.SystemParameter.GetParameterValue("KPSAPPLICATIONCODE", "");
            credential.OrganizationCode = TTObjectClasses.SystemParameter.GetParameterValue("KPSORGANIZATIONCODE", "");

            KPSV2.KpsServisSonucuBilesikKisiBilgisi cevap = default(KPSV2.KpsServisSonucuBilesikKisiBilgisi);
            cevap = (KPSV2.KpsServisSonucuBilesikKisiBilgisi)Common.CallWebMethodWithHeader(header, credential, callParameters);
            return cevap;

            #endregion BilesikKisiveAdresSorgulaSync_Body

        }

    }
}