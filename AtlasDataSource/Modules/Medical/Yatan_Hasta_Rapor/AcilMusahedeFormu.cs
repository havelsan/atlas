using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReportClasses.Controllers.ReportModels;
using System.Runtime.Serialization;
using TTObjectClasses;
using System.ComponentModel;
using TTInstanceManagement;
using ReportClasses.ReportUtils;

namespace AtlasDataSource.Modules.Medical.Yatan_Hasta_Rapor
{
    public class AcilMusahedeFormu 
    {
        public static AcilMusahedeFormuData GetReportData(string parameters)
        {
            return ApiCaller.CallAnyApiWithParams<AcilMusahedeFormuData>(parameters, "GetAcilMusahedeFormuData");
        }

        public static AcilMusahedeFormuData GetAcilMusahedeFormuData(string parameters)
        {
            AcilMusahedeFormuData returnData = new AcilMusahedeFormuData();

            if (parameters != null)
            {
                using (var objectContext = new TTObjectContext(false)) //RTF alanların texti nqlde alınamadığı için eklendi.
                {
                    var param = Newtonsoft.Json.JsonConvert.DeserializeObject<AcilMusahedeFormuParam>(parameters.ToString());

                    BindingList<EmergencyIntervention.GetEmergencyInterventionForm_Class> staticReport = EmergencyIntervention.GetEmergencyInterventionForm(param.ObjectID);
                    if (staticReport.Count > 0)
                    {
                        EmergencyIntervention.GetEmergencyInterventionForm_Class _tempList = staticReport[0];

                        returnData.HastaAdi = _tempList.Name + ' ' + _tempList.Surname;
                        returnData.TC = (_tempList.Foreign.HasValue && _tempList.Foreign.Value) ? (_tempList.ForeignUniqueRefNo.HasValue ? _tempList.ForeignUniqueRefNo.Value.ToString() : "") : (_tempList.UniqueRefNo.HasValue ? _tempList.UniqueRefNo.Value.ToString() : "");
                        returnData.Yas = _tempList.BirthDate.HasValue ? Common.CalculateAge(_tempList.BirthDate.Value).Years.ToString() : "";
                        returnData.Cinsiyet = _tempList.ADI;

                        returnData.KabulNo = _tempList.ProtocolNo;
                        returnData.Adres = _tempList.HomeAddress;
                        returnData.MusahedeBaslangic = _tempList.EnteranceTime;
                        returnData.Kurum = _tempList.Payer;
                        returnData.Doktor = _tempList.Doctor;

                        //TTBinaryData.GetBinaryData(new Guid(_tempList.Complaint.ToString()));
                        returnData.Sikayet = Common.BinaryToString(new Guid(_tempList.Complaint.ToString()));
                        returnData.Hikayesi = Common.BinaryToString(new Guid(_tempList.PatientHistory.ToString()));

                        #region Hikaye ve Şikayeti
                        //InPatientPhysicianApplication physicianApplication = objectContext.GetObject<InPatientPhysicianApplication>(_tempList.Inpphyappid.Value);

                        //if (physicianApplication != null)
                        //{
                        //    if (physicianApplication.Complaint != null)
                        //        returnData.Sikayet = Common.GetTextOfRTFString(physicianApplication.Complaint.ToString());
                        //    else
                        //        returnData.Sikayet = "";

                        //    if (physicianApplication.PatientHistory != null)
                        //        returnData.Hikayesi = Common.GetTextOfRTFString(physicianApplication.PatientHistory.ToString());
                        //    else
                        //        returnData.Hikayesi = "";
                        //}
                        #endregion

                        #region TANILAR
                        returnData.Tanilar = DiagnosisGrid.GetBySubEpisode(objectContext, _tempList.Subepisode.ToString()).ToList<DiagnosisGrid>();
                        #endregion

                        #region KONSULTASYOn
                        List<Consultation> consultations = Consultation.GetAllConsultationsOfEpisode(objectContext, _tempList.Episode.ToString()).ToList<Consultation>();
                        returnData.konsultasyons = new List<Konsultasyon>();

                        foreach (Consultation item in consultations)
                        {
                            Konsultasyon konsultasyon = new Konsultasyon();

                            konsultasyon.IstekTarihi = item.RequestDate;
                            konsultasyon.IsteyenDoktor = item.RequesterDoctor.Name;
                            konsultasyon.UygulayanDoktor = item.ProcedureDoctor == null ? "" : item.ProcedureDoctor.Name;
                            konsultasyon.IsteyenBirim = item.RequesterResource == null ? "" : item.RequesterResource.Name;
                            konsultasyon.IstenenBirim = item.MasterResource == null ? "" : item.MasterResource.Name;
                            konsultasyon.Sonuc = item.ConsultationResultAndOffers == null ? "" : Common.BinaryToString(new Guid(item.ConsultationResultAndOffers.ToString()));

                            returnData.konsultasyons.Add(konsultasyon);
                        }
                        #endregion

                        #region İŞLMELEr
                        List<SubActionProcedure.GetSubactionProceduresBySubepisode_Class> subactionProcedures = SubActionProcedure.GetSubactionProceduresBySubepisode(_tempList.Subepisode.Value).ToList<SubActionProcedure.GetSubactionProceduresBySubepisode_Class>();
                        returnData.islems = new List<Islem>();

                        foreach (SubActionProcedure.GetSubactionProceduresBySubepisode_Class item in subactionProcedures)
                        {
                            Islem islem = new Islem();

                            islem.Adi = item.Procedurename;
                            islem.Kodu = item.Procedurecode;
                            islem.UygulamaZamani = item.PerformedDate;
                            islem.Uygulayan = item.Proceduredoctorname;

                            returnData.islems.Add(islem);

                        }
                        #endregion

                        #region VITALSIGNS
                        #endregion
                    }
                }

            }
            return returnData;
        }
    }

    [Serializable]
    public class AcilMusahedeFormuParam
    {
        [DataMember]
        public Guid ObjectID { get; set; }

    }

    //[Serializable]
    //public class AcilMusahedeIstatistikListesi
    //{
    //    [DataMember]
    //    public  List<AcilMusahedeIstatistikInfo> AcilMusahedeIstatistikInfo { get; set; }

    //    [DataMember]
    //    public string Deneme { get; set; }
    //}

    [Serializable]
    public class AcilMusahedeFormuData
    {
        #region PATIENT
        [DataMember]
        public string HastaAdi { get; set; }
        [DataMember]
        public string TC { get; set; }
        [DataMember]
        public string Yas { get; set; }
        [DataMember]
        public string Cinsiyet { get; set; }
        #endregion

        #region SUBEPISODE
        [DataMember]
        public string KabulNo { get; set; }
        [DataMember]
        public string Adres { get; set; }
        [DataMember]
        public DateTime? MusahedeBaslangic { get; set; }
        [DataMember]
        public string Kurum { get; set; }
        #endregion

        #region YATIŞ BİLGİSİ
        [DataMember]
        public string Doktor { get; set; }
        [DataMember]
        public string Hikayesi { get; set; }
        [DataMember]
        public string Sikayet { get; set; }
        [DataMember]
        public List<DiagnosisGrid> Tanilar { get; set; }
        #endregion

        #region KONS
        public List<Konsultasyon> konsultasyons { get; set; }
        #endregion

        #region ISLEM
        public List<Islem> islems { get; set; }
        #endregion


    }

    public class Konsultasyon
    {
        public string IsteyenDoktor { get; set; }
        public string UygulayanDoktor { get; set; }
        public string IsteyenBirim { get; set; }
        public string IstenenBirim { get; set; }
        public string Sonuc { get; set; }
        public DateTime? IstekTarihi { get; set; }
    }

    public class Islem
    {
        public DateTime? UygulamaZamani { get; set; }
        public string Kodu { get; set; }
        public string Adi { get; set; }
        public string Uygulayan { get; set; }
    }
}


