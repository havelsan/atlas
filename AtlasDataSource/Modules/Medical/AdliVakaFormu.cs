using System;
using System.Runtime.Serialization;
using TTObjectClasses;
using System.ComponentModel;
using TTInstanceManagement;
using TTStorageManager.Security;
using ReportClasses.ReportUtils;

namespace AtlasDataSource.Controllers
{
    public class AdliVakaFormu
    {
        public static AdliVakaFormuData GetReportData(string parameters)
        {
            return ApiCaller.CallAnyApiWithParams<AdliVakaFormuData>(parameters, "GetAdliVakaFormuData");
        }

        public static AdliVakaFormuData GetAdliVakaFormuData(string parameters)
        {
            AdliVakaFormuData data = new AdliVakaFormuData();

            if (parameters != null)
            {
                var param = Newtonsoft.Json.JsonConvert.DeserializeObject<AdliVakaReportParameters>(parameters.ToString());

                BindingList<ForensicMedicalReport.GetForensicMedicalReportNew_Class> MedicalReport = ForensicMedicalReport.GetForensicMedicalReportNew(param.ObjectID);
                if (MedicalReport.Count > 0)
                {
                    ForensicMedicalReport.GetForensicMedicalReportNew_Class report = MedicalReport[0];
                    data.HastahaneAdi = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    data.IstekTarihi = report.RequestDate;
                    data.RaporTarihi = report.ActionDate;
                    data.RaporNo = report.ReportNo == null ? "" : report.ReportNo.ToString();
                    data.ProtokolNo = report.ProtocolNo == null ? "" : report.ProtocolNo.ToString();
                    data.RaporunIstendigiMakam = report.Permdepartment == null ? "" : Common.GetDisplayTextOfEnumValue("PemissionDepartmentEnum", Convert.ToInt32(report.Permdepartment.Value));
                    data.GonderenMakam = report.Senderchairname == null ? "" : report.Senderchairname.ToString();
                    data.EvrakTarihi = report.DocumentDate;
                    data.EvrakSayisi = report.DocumentNumber == null ? "" : report.DocumentNumber.ToString();
                    data.EslikEdenGorevliAdSoyad = report.Resusername == null ? "" : report.Resusername.ToString();
                    data.EslikEdenGorevliSicilNo = report.Resusersicilno == null ? "" : report.Resusersicilno.ToString();
                    data.SorumluKisi = report.Proceduredoctorname == null ? "" : report.Proceduredoctorname.ToString();
                    data.MuayeneSebebi = report.Examinationreason == null ? "" : Common.GetDisplayTextOfEnumValue("ReasonExaminationTypeEnum", Convert.ToInt32(report.Examinationreason.Value));
                    data.DigerMuayeneSebebi = report.OtherReasonExamination == null ? "" : report.OtherReasonExamination.ToString();
                    data.MuayeneEdileninTibbiKimligi = report.PatientIdentity == null ? "" : report.PatientIdentity.ToString();
                    data.UygunOrtamEvet = report.SuitableEnvironment1 == null ? false : Convert.ToBoolean(report.SuitableEnvironment1);
                    data.UygunOrtamHayir = report.SuitableEnvironment2 == null ? false : Convert.ToBoolean(report.SuitableEnvironment2);
                    data.UygunOrtamAciklama = report.Suitableenvexplanation == null ? "" : report.Suitableenvexplanation.ToString();
                    data.MuayeneSirasi_TabipVeMuayeneEdilen = report.PeopleInExamination1 == null ? false : Convert.ToBoolean(report.PeopleInExamination1);
                    data.MuayeneSirasi_GuvenlikGorevlisi = report.PeopleInExamination2 == null ? false : Convert.ToBoolean(report.PeopleInExamination2);
                    data.MuayeneSirasi_SaglikMeslegiMensubu = report.PeopleInExamination3 == null ? false : Convert.ToBoolean(report.PeopleInExamination3);
                    data.MuayeneSirasi_MuayeneEdileninMudafii = report.PeopleInExamination4 == null ? false : Convert.ToBoolean(report.PeopleInExamination4);
                    data.MuayeneEdileninGiysileri_TamamenCikartildi = report.ClothesOfPatient1 == null ? false : Convert.ToBoolean(report.ClothesOfPatient1);
                    data.MuayeneEdileninGiysileri_KismenCikartildi = report.ClothesOfPatient2 == null ? false : Convert.ToBoolean(report.ClothesOfPatient2);
                    data.MuayeneEdileninGiysileri_Cikartilmadi = report.ClothesOfPatient3 == null ? false : Convert.ToBoolean(report.ClothesOfPatient3);
                    data.MuayeneEdileninGiysileri_Aciklama = report.Clothesofpatientexplanation == null ? "" : report.Clothesofpatientexplanation.ToString();
                    data.OlayinOykusu = report.HistoryOfEvent == null ? "" : report.HistoryOfEvent.ToString();
                    data.MuayeneTarihi = report.ExaminationDate;
                    data.BasBoyun = report.HeadNeck == null ? false : Convert.ToBoolean(report.HeadNeck);
                    data.Gogus = report.Chest == null ? false : Convert.ToBoolean(report.Chest);
                    data.Batin = report.Abdominal == null ? false : Convert.ToBoolean(report.Abdominal);
                    data.SirtBel = report.Back == null ? false : Convert.ToBoolean(report.Back);
                    data.UstEkstremite = report.UpperExtrimity == null ? false : Convert.ToBoolean(report.UpperExtrimity);
                    data.AltEkstremite = report.LowerExtremity == null ? false : Convert.ToBoolean(report.LowerExtremity);
                    data.GenitalBolge = report.GenitalArea == null ? false : Convert.ToBoolean(report.GenitalArea);
                    data.LezyonlarAciklama = report.PropertiesOfLesions == null ? "" : report.PropertiesOfLesions.ToString();
                    data.MerkeziSinirS = report.CentralNervousSystem == null ? false : Convert.ToBoolean(report.CentralNervousSystem);
                    data.KalpDamarS = report.CardiovascularSystem == null ? false : Convert.ToBoolean(report.CardiovascularSystem);
                    data.SindirimS = report.DigestiveSys == null ? false : Convert.ToBoolean(report.DigestiveSys);
                    data.SolunumS = report.RespiratorySys == null ? false : Convert.ToBoolean(report.RespiratorySys);
                    data.KasIskeletS = report.SkeletalSys == null ? false : Convert.ToBoolean(report.SkeletalSys);
                    data.UrogenitalS = report.UrogenitalSys == null ? false : Convert.ToBoolean(report.UrogenitalSys);
                    data.DuyuOrganlariS = report.SensoryOrgansSys == null ? false : Convert.ToBoolean(report.SensoryOrgansSys);
                    data.GenelDurumu = report.Generalconditionofpatienttext == null ? "" : Common.GetDisplayTextOfEnumValue("GeneralConditionOfPatientEnum", Convert.ToInt32(report.Generalconditionofpatienttext.Value));
                    data.Bilinci = report.Awarenesstext == null ? "" : Common.GetDisplayTextOfEnumValue("AwarenessEnum", Convert.ToInt32(report.Awarenesstext.Value));
                    data.Solunum = report.Respitorytext == null ? "" : Common.GetDisplayTextOfEnumValue("RespitoryEnum", Convert.ToInt32(report.Respitorytext.Value));
                    data.Pupiller = report.Pupilpropertiestext == null ? "" : Common.GetDisplayTextOfEnumValue("PupilPropertiesEnum", Convert.ToInt32(report.Pupilpropertiestext.Value));
                    data.IsikRefleksi = report.Lightreflextext == null ? "" : Common.GetDisplayTextOfEnumValue("LightReflexEnum", Convert.ToInt32(report.Lightreflextext.Value));
                    data.TendonRefleksi = report.Tendonreflexestext == null ? "" : Common.GetDisplayTextOfEnumValue("TendonReflexesEnum", Convert.ToInt32(report.Tendonreflexestext.Value));
                    data.TansiyonArteryel = report.ArterialBloodPresure == null ? "" : report.ArterialBloodPresure.ToString();
                    data.Nabiz = report.Pulse == null ? "" : report.Pulse.ToString();
                    data.SistemMuayenesiAciklama = report.SystemFindings == null ? "" : report.SystemFindings.ToString();
                    data.BelirginPsikopatolojikBulguSaptanmadi = report.NoEvidancePsycho == null ? false : Convert.ToBoolean(report.NoEvidancePsycho);
                    data.AyrintiliPsikiatrikMuayeneyeGerekDuyuldu = report.PyschiatricExamination == null ? false : Convert.ToBoolean(report.PyschiatricExamination);
                    data.Laboratuvar = report.ChkLabProcedures == null ? false : Convert.ToBoolean(report.ChkLabProcedures);
                    data.DirektGrafi = report.ChkDirectGraph == null ? false : Convert.ToBoolean(report.ChkDirectGraph);
                    data.BT_MR = report.ChkBTMR == null ? false : Convert.ToBoolean(report.ChkBTMR);
                    data.Ultrasonografi = report.ChkUltrasonography == null ? false : Convert.ToBoolean(report.ChkUltrasonography);
                    data.Biyopsi = report.ChkBiopsy == null ? false : Convert.ToBoolean(report.ChkBiopsy);
                    data.Diger = report.ChkOther == null ? false : Convert.ToBoolean(report.ChkOther);
                    data.VucutDiyagramiChk = report.Attaches1 == null ? false : Convert.ToBoolean(report.Attaches1);
                    data.PsikiyatrikMuayeneKonsRaporu = report.Attaches2 == null ? false : Convert.ToBoolean(report.Attaches2);
                    data.PsikiyatrikMuayeneKonsRaporuAciklama = report.Attaches2Text == null ? "" : report.Attaches2Text.ToString();
                    data.KonsultasyonRaporuChk = report.Attaches3 == null ? false : Convert.ToBoolean(report.Attaches3);
                    data.KonsRaporuAciklama1 = report.Attaches3Text1 == null ? "" : report.Attaches3Text1.ToString();
                    data.KonsRaporuAciklama2 = report.Attaches3Text2 == null ? "" : report.Attaches3Text2.ToString();
                    data.DigerChk = report.Attaches4 == null ? false : Convert.ToBoolean(report.Attaches4);
                    data.TibbiBelgeOrnekleriAciklama = report.Attaches5 == null ? "" : report.Attaches5.ToString();
                    data.GerekGorulmedi = report.NoNeed == null ? false : Convert.ToBoolean(report.NoNeed);
                    data.GerekGoruldu = report.Need == null ? false : Convert.ToBoolean(report.Need);
                    data.KesinRapor = report.CertainReport == null ? false : Convert.ToBoolean(report.CertainReport);
                    data.DurumBildirirGeciciRapor = report.UncertainReport == null ? false : Convert.ToBoolean(report.UncertainReport);
                    data.SevkNedeni = report.ResonOfDispatch == null ? "" : report.ResonOfDispatch.ToString();
                    data.TCKimlikNo = report.UniqueRefNo == null ? "" : report.UniqueRefNo.ToString();
                    data.AdSoyad = report.Patientname == null ? "" : report.Patientname.ToString() + ' ' + report.Patientsurname.ToString();
                    data.BabaAdi = report.FatherName == null ? "" : report.FatherName.ToString();
                    data.DogumYeri = report.CityOfBirth == null ? "" : report.CityOfBirth.ToString();
                    data.DogumTarihi = report.BirthDate;
                    if (Convert.ToInt32(report.Cinsiyetkodu) == 1)
                    {
                        //ImagePath
                        data.Cinsiyet_E = true;
                        data.Cinsiyet_K = false;
                    }
                    else if (Convert.ToInt32(report.Cinsiyetkodu) == 2)
                    {
                        //ImagePath
                        data.Cinsiyet_K = true;
                        data.Cinsiyet_E = false;
                    }
                    data.Meslegi = report.Occupation == null ? "" : report.Occupation.ToString();
                    data.DoktorAdSoyad = report.Proceduredoctorname == null ? "" : report.Proceduredoctorname.ToString();
                    data.DiplomaNo = report.Dipno == null ? "" : report.Dipno.ToString();

                    using (var objectContext = new TTObjectContext(false)) //RTF alanların texti nqlde alınamadığı için eklendi.
                    {
                        ForensicMedicalReport forensicReport = objectContext.GetObject<ForensicMedicalReport>(param.ObjectID);
                        if (forensicReport.Episode.Complaint != null)
                            data.MuayeneEdileninSikayetleri = Common.GetTextOfRTFString(forensicReport.Episode.Complaint.ToString());
                        else
                            data.MuayeneEdileninSikayetleri = "";

                        if (forensicReport.Episode.PatientHistory != null)
                            data.HastaninTibbiOzgecmisi = Common.GetTextOfRTFString(forensicReport.Episode.PatientHistory.ToString());
                        else
                            data.HastaninTibbiOzgecmisi = "";

                        if (forensicReport.LaboratoryProcedures != null)
                            data.TetkiklerAciklama = Common.GetTextOfRTFString(forensicReport.LaboratoryProcedures.ToString());
                        else
                            data.TetkiklerAciklama = "";

                        if (forensicReport.Report != null)
                            data.SonucRaporu = Common.GetTextOfRTFString(forensicReport.Report.ToString());
                        else
                            data.SonucRaporu = "";
                    }

                    //data.MuayeneEdileninSikayetleri = report.Complaint == null ? "" : report.Complaint.ToString();
                    //data.HastaninTibbiOzgecmisi = report.PatientHistory == null ? "" : report.PatientHistory.ToString();
                    //data.TetkiklerAciklama = report.LaboratoryProcedures == null ? "" : report.LaboratoryProcedures.ToString();
                    //data.SonucRaporu = report.Report == null ? "" : report.Report.ToString();
                }
            }
            return data;

        }

    }

    [Serializable]
    public class AdliVakaReportParameters
    {
        [DataMember]
        public Guid ObjectID { get; set; } //ForensicMedicalReport'un ObjectIDsi

    }

    [Serializable]
    public class AdliVakaFormuData
    {
        [DataMember]
        public DateTime? IstekTarihi { get; set; }
        [DataMember]
        public DateTime? RaporTarihi { get; set; }
        [DataMember]
        public string RaporNo { get; set; }
        [DataMember]
        public string HastahaneAdi { get; set; }
        [DataMember]
        public string ProtokolNo { get; set; }
        [DataMember]
        public string EslikEdenGorevliAdSoyad { get; set; }
        [DataMember]
        public string EslikEdenGorevliSicilNo { get; set; }
        [DataMember]
        public string RaporunIstendigiMakam { get; set; } //PemissionDepartmentEnum

        [DataMember]
        public string GonderenMakam { get; set; } //SENDERCHAIR

        [DataMember]
        public DateTime? EvrakTarihi { get; set; }

        [DataMember]
        public string EvrakSayisi { get; set; }

        [DataMember]
        public string SorumluKisi { get; set; }//ProcedureDoctor

        [DataMember]
        public string MuayeneSebebi { get; set; }//ReasonExaminationTypeEnum

        [DataMember]
        public string DigerMuayeneSebebi { get; set; }//OTHERREASONEXAMINATION

        [DataMember]
        public string MuayeneEdileninTibbiKimligi { get; set; }//PATIENTIDENTITY

        #region Muayene Koşulları

        [DataMember]
        public bool UygunOrtamEvet { get; set; } //SUITABLEENVIRONMENT1

        [DataMember]
        public bool UygunOrtamHayir { get; set; } //SUITABLEENVIRONMENT2

        [DataMember]
        public string UygunOrtamAciklama { get; set; } //EXPLANATION1

        [DataMember]
        public bool MuayeneSirasi_TabipVeMuayeneEdilen { get; set; } //PEOPLEINEXAMINATION1
        [DataMember]
        public bool MuayeneSirasi_GuvenlikGorevlisi { get; set; } //PEOPLEINEXAMINATION2
        [DataMember]
        public bool MuayeneSirasi_SaglikMeslegiMensubu { get; set; } //PEOPLEINEXAMINATION3
        [DataMember]
        public bool MuayeneSirasi_MuayeneEdileninMudafii { get; set; } //PEOPLEINEXAMINATION4
        [DataMember]
        public bool MuayeneEdileninGiysileri_TamamenCikartildi { get; set; } //CLOTHESOFPATIENT1
        [DataMember]
        public bool MuayeneEdileninGiysileri_KismenCikartildi { get; set; } //CLOTHESOFPATIENT2
        [DataMember]
        public bool MuayeneEdileninGiysileri_Cikartilmadi { get; set; } //CLOTHESOFPATIENT3
        [DataMember]
        public string MuayeneEdileninGiysileri_Aciklama { get; set; } //EXPLANATION2

        #endregion

        #region Muayeneye Esas Olayla İlgili Bilgiler

        [DataMember]
        public string OlayinOykusu { get; set; } //HistoryOfEvent
        [DataMember]
        public string MuayeneEdileninSikayetleri { get; set; } //EPISODE.COMPLAINT
        [DataMember]
        public string HastaninTibbiOzgecmisi { get; set; } //EPISODE.PATIENTHISTORY
        #endregion

        #region Muayene Bulguları
        [DataMember]
        public DateTime? MuayeneTarihi { get; set; }

        #region Lezyonlar ile ilgili bulgular
        [DataMember]
        public bool BasBoyun { get; set; } //HEADNECK
        [DataMember]
        public bool Gogus { get; set; } //CHEST
        [DataMember]
        public bool Batin { get; set; } //ABDOMINAL
        [DataMember]
        public bool SirtBel { get; set; } //BACK
        [DataMember]
        public bool UstEkstremite { get; set; } //UPPEREXTRIMITY
        [DataMember]
        public bool AltEkstremite { get; set; } //LOWEREXTREMITY
        [DataMember]
        public bool GenitalBolge { get; set; } //GENITALAREA
        [DataMember]
        public string LezyonlarAciklama { get; set; } //PROPERTIESOFLESIONS
        #endregion

        #region Sistem Muayeneleri

        [DataMember]
        public bool MerkeziSinirS { get; set; } //CENTRALNERVOUSSYSTEM
        [DataMember]
        public bool KalpDamarS { get; set; } //CARDIOVASCULARSYSTEM
        [DataMember]
        public bool SindirimS { get; set; } //DIGESTIVESYS
        [DataMember]
        public bool SolunumS { get; set; } //RESPIRATORYSYS
        [DataMember]
        public bool KasIskeletS { get; set; } //SKELETALSYS
        [DataMember]
        public bool UrogenitalS { get; set; } //UROGENITALSYS
        [DataMember]
        public bool DuyuOrganlariS { get; set; } //SENSORYORGANSSYS
        [DataMember]
        public string GenelDurumu { get; set; } //GENERALCONDITIONOFPATIENT - GeneralConditionOfPatientEnum
        [DataMember]
        public string Bilinci { get; set; } //AWARENESS - AwarenessEnum
        [DataMember]
        public string Solunum { get; set; } //RESPITORY - RespitoryEnum
        [DataMember]
        public string Pupiller { get; set; } //PUPILPROPERTIES - PupilPropertiesEnum
        [DataMember]
        public string IsikRefleksi { get; set; } //LIGHTREFLEX - LightReflexEnum
        [DataMember]
        public string TendonRefleksi { get; set; } //TENDONREFLEXES - TendonReflexesEnum
        [DataMember]
        public string TansiyonArteryel { get; set; } //ARTERIALBLOODPRESURE
        [DataMember]
        public string Nabiz { get; set; } //PULSE
        [DataMember]
        public string SistemMuayenesiAciklama { get; set; } //SYSTEMFINDINGS


        #endregion

        #region Psikiyatrik Muayene
        [DataMember]
        public bool BelirginPsikopatolojikBulguSaptanmadi { get; set; }//NOEVIDANCEPSYCHO
        [DataMember]
        public bool AyrintiliPsikiatrikMuayeneyeGerekDuyuldu { get; set; }//PYSCHIATRICEXAMINATION
        [DataMember]
        public bool PsikiyatrikKonsIstendi { get; set; } //PSYCHIATRICCONSULTATION
        #endregion

        #endregion

        #region Tetkikler

        [DataMember]
        public bool Laboratuvar { get; set; } //CHKLABPROCEDURES
        [DataMember]
        public bool DirektGrafi { get; set; } //CHKDIRECTGRAPH
        [DataMember]
        public bool BT_MR { get; set; } //CHKBTMR
        [DataMember]
        public bool Ultrasonografi { get; set; } //CHKULTRASONOGRAPHY
        [DataMember]
        public bool Biyopsi { get; set; } //CHKBIOPSY
        [DataMember]
        public bool Diger { get; set; } //CHKOTHER
        [DataMember]
        public string TetkiklerAciklama { get; set; } //LABORATORYPROCEDURES
        #endregion

        #region Eklenen Kons Raporları ve Tıbbi Belge Örnekleri

        [DataMember]
        public bool VucutDiyagramiChk { get; set; } //ATTACHES1
        [DataMember]
        public bool PsikiyatrikMuayeneKonsRaporu { get; set; } //ATTACHES2
        [DataMember]
        public string PsikiyatrikMuayeneKonsRaporuAciklama { get; set; } //ATTACHES2TEXT
        [DataMember]
        public bool KonsultasyonRaporuChk { get; set; } //ATTACHES3
        [DataMember]
        public string KonsRaporuAciklama1 { get; set; } //ATTACHES3TEXT1
        [DataMember]
        public string KonsRaporuAciklama2 { get; set; } //ATTACHES3TEXT2
        [DataMember]
        public bool DigerChk { get; set; } //ATTACHES4
        [DataMember]
        public string TibbiBelgeOrnekleriAciklama { get; set; } //ATTACHES5
        #endregion

        #region Sonuc
        [DataMember]
        public bool GerekGorulmedi { get; set; } //NONEED
        [DataMember]
        public bool GerekGoruldu { get; set; } //NEED
        [DataMember]
        public bool KesinRapor { get; set; } //CERTAINREPORT
        [DataMember]
        public bool DurumBildirirGeciciRapor { get; set; } //UNCERTAINREPORT
        [DataMember]
        public string SevkNedeni { get; set; } //RESONOFDISPATCH
        [DataMember]
        public string SonucRaporu { get; set; } //REPORT
        #endregion

        #region Hasta Bilgileri
        [DataMember]
        public string TCKimlikNo { get; set; }
        [DataMember]
        public string AdSoyad { get; set; }
        [DataMember]
        public string BabaAdi { get; set; }
        [DataMember]
        public string DogumYeri { get; set; }
        [DataMember]
        public DateTime? DogumTarihi { get; set; }
        [DataMember]
        public bool Cinsiyet_K { get; set; }
        [DataMember]
        public bool Cinsiyet_E { get; set; }
        [DataMember]
        public string Meslegi { get; set; }
        #endregion

        #region Muayeneyi Yapan ve Raporu Düzenleyen 
        [DataMember]
        public string DoktorAdSoyad { get; set; }
        [DataMember]
        public string DiplomaNo { get; set; }
        #endregion

        [DataMember]
        public string ImagePath { get; set; }
    }

}
