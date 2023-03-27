using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using TTObjectClasses;
using System.ComponentModel;
using ReportClasses.ReportUtils;
using TTInstanceManagement;

namespace AtlasDataSource.Controllers
{
    public class RadyolojiSonucRaporu
    {
        public static RadiologyResultReportData GetReportData(string parameters)
        {
            return ApiCaller.CallAnyApiWithParams<RadiologyResultReportData>(parameters, "GetRadiologyResultReportData");
        }
        public static RadiologyResultReportData GetRadiologyResultReportData(string parameters)
        {
            RadiologyResultReportData data = new RadiologyResultReportData();
            if (parameters != null)
            {
                var param = Newtonsoft.Json.JsonConvert.DeserializeObject<RadiologyResultReportParameters>(parameters.ToString());
                using (var objectContext = new TTObjectContext(false))
                {
                   
                    RadiologyTest radiologyTest = objectContext.GetObject<RadiologyTest>(param.ObjectID);
                    Episode episode = radiologyTest.Episode;
                    Patient patient = episode.Patient;

                    data.HastahaneAdi = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    data.HastaTC = patient.UniqueRefNo.ToString();
                    data.HastaAdiSoyadi = patient.Name.ToString() + " " + patient.Surname.ToString();
                    data.HastaDogumTarihi = patient.BirthDate;
                    data.HastaDogumYeri = patient.TownOfBirth == null ? "" : patient.TownOfBirth.Name;
                    data.Cinsiyeti = patient.Sex == null ?"" :patient.Sex.ADI;
                    data.IsteyenDoktorAdi = radiologyTest.Radiology.RequestDoctor == null ? "" : radiologyTest.Radiology.RequestDoctor.Name;
                    data.IsteyenBolum = radiologyTest.FromResource == null ? "" : radiologyTest.FromResource.Name;
                    data.ProtokolNo = radiologyTest.SubEpisode.ProtocolNo == null ? "" : radiologyTest.SubEpisode.ProtocolNo.ToString();
                    data.HastaNo = patient.ID.ToString();
                    data.AccessionNo = radiologyTest.AccessionNo == null ? "" : radiologyTest.AccessionNo.ToString();
                    data.IstekTarihi = radiologyTest.RequestDate;
               
                    data.TetkikIstemNedeniDegerlendirme = radiologyTest.RequestReasonAssesment == null ? "" : Common.GetDisplayTextOfEnumValue("RequestReasonAssesment", Convert.ToInt32(radiologyTest.RequestReasonAssesment.Value));
                    data.CekimKalitesiDegerlendirme = radiologyTest.ImageQualityAssesment == null ? "" : Common.GetDisplayTextOfEnumValue("ImageQualityAssesmentEnum", Convert.ToInt32(radiologyTest.ImageQualityAssesment.Value));
                    data.CekimTeknigi = radiologyTest.RadiographyTechnique == null ? "": radiologyTest.RadiographyTechnique.ToString();
                    data.Bulgular = radiologyTest.Results == null ? "" : radiologyTest.Results.ToString();
                    data.KarsilastirmaBilgisi = radiologyTest.ComparisonInfo == null ? "" : radiologyTest.ComparisonInfo.ToString();
                    data.LoincKodu = radiologyTest.RadiologyTestDefinition.SKRSLoincKodu == null ?"": radiologyTest.RadiologyTestDefinition.SKRSLoincKodu.LOINCNUMARASI;
                    data.TetkikIstemAciklamasi = radiologyTest.Description == null ? "" : radiologyTest.Description;

                    foreach (TTObjectState objectState in radiologyTest.GetStateHistory())
                    {
                        if (objectState.StateDefID == RadiologyTest.States.Completed)
                        {
                            data.CekimTarihi = objectState.BranchDate;
                        }
                    }

                    if(data.CekimTarihi is null)
                    {
                        data.CekimTarihi = radiologyTest.TestDate;
                    }

                    data.RaporTarihi = radiologyTest.ReportDate;

                    var diagnosisList = DiagnosisGrid.GetBySubEpisode(objectContext, radiologyTest.SubEpisode.ObjectID.ToString());
                    data.Tanilar = new List<RadiologyDiagnosisData>();
                    foreach (DiagnosisGrid d in diagnosisList)
                    {
                        RadiologyDiagnosisData tani = new RadiologyDiagnosisData();
                        tani.TaniKodu = d.Diagnose.Code;
                        tani.TaniAdi = d.Diagnose.Name;
                        data.Tanilar.Add(tani);
                    }

                    data.TetkikAdi = radiologyTest.ProcedureObject.Name;
                    data.Rapor = radiologyTest.Report.ToString();
                    if (radiologyTest.RadiologyAdditionalReport != null)
                    {
                        data.EkRaporTarihi = radiologyTest.RadiologyAdditionalReport.ReportDate;
                        data.EkRapor = radiologyTest.RadiologyAdditionalReport.AdditionalReport.ToString();
                    }
                    else
                    {
                        data.EkRapor = "";
                        data.EkRaporTarihi = null;
                    }
                    if (radiologyTest.ReportedBy != null) {
                        data.RaporYazanKullanici = radiologyTest.ReportedBy.Name;
                        data.RaporYazanKullaniciImza = radiologyTest.ReportedBy.SignatureBlock;
                    }else
                    {
                        data.RaporYazanKullanici = "";
                        data.RaporYazanKullaniciImza = "";
                    }

                    if (radiologyTest.ProcedureDoctor != null)
                    {
                        data.IslemiYapanDoktor = radiologyTest.ProcedureDoctor.Name;
                        data.IslemiYapanDoktorImza = radiologyTest.ProcedureDoctor.SignatureBlock;
                    }
                    else
                    {
                        data.IslemiYapanDoktor = "";
                        data.IslemiYapanDoktorImza = "";
                    }

                    data.IletisimBilgileri = TTObjectClasses.SystemParameter.GetParameterValue("RadiologyUnitAddressInfo", "");
                    data.RaporBasanKullanici = Common.CurrentUser.Name;

                    try
                    {
                        string ckys = "", raporTipi = "2", raporNo = radiologyTest.RadiologyRequestNo == null ? "" : radiologyTest.RadiologyRequestNo.ToString(), year = radiologyTest.PerformedDate == null ? "" : (Convert.ToDateTime(radiologyTest.PerformedDate).Date).ToString();

                        SKRSKurumlar myTesisSKRSKurumlarDefinition = SKRSKurumlar.GetMyTesisSKRSKurumlarDefinition();

                        if (myTesisSKRSKurumlarDefinition != null)
                        {
                            ckys = myTesisSKRSKurumlarDefinition.KODU.ToString();
                        }

                        data.RaporNumarasi = ckys + "." + raporTipi + "." + raporNo + "." + data.AccessionNo+"."+ year;
                    }
                    catch { }
                }

            }
            return data;
        }



    }
    [Serializable]
    public class RadiologyResultReportParameters
    {
        [DataMember]
        public Guid ObjectID { get; set; } //RadiologyTest'nin ObjectIDsi

    }

    [Serializable]
    public class RadiologyResultReportData
    {
        [DataMember]
        public string HastahaneAdi { get; set; }

        //Hasta Bilgileri
        [DataMember]
        public string HastaTC { get; set; }
        [DataMember]
        public string HastaAdiSoyadi { get; set; }
        [DataMember]
        public DateTime? HastaDogumTarihi { get; set; }
        [DataMember]
        public string HastaDogumYeri { get; set; }
        [DataMember]
        public string Cinsiyeti { get; set; }

        //İstek Bilgileri
        [DataMember]
        public string IsteyenDoktorAdi { get; set; }
        [DataMember]
        public string IsteyenBolum { get; set; }
        [DataMember]
        public string ProtokolNo { get; set; }
        [DataMember]
        public string HastaNo { get; set; }
        [DataMember]
        public string AccessionNo { get; set; }
        [DataMember]
        public DateTime? IstekTarihi { get; set; }
        [DataMember]
        public DateTime? CekimTarihi { get; set; }
        [DataMember]
        public DateTime? RaporTarihi { get; set; }
        [DataMember]
        public string RaporNumarasi { get; set; }
      
        [DataMember]
        public string LoincKodu { get; set; }
        
        [DataMember]
        public string TetkikIstemAciklamasi { get; set; }

        //Rapor Bilgileri
        [DataMember]
        public string TetkikAdi { get; set; }
        [DataMember]
        public string Rapor { get; set; }
        [DataMember]
        public DateTime? EkRaporTarihi { get; set; }
        [DataMember]
        public string EkRapor { get; set; }

        [DataMember]
        public string TetkikIstemNedeniDegerlendirme { get; set; }
        [DataMember]
        public string CekimKalitesiDegerlendirme { get; set; }
        [DataMember]
        public string CekimTeknigi { get; set; }
        [DataMember]
        public string Bulgular { get; set; }
        [DataMember]
        public string KarsilastirmaBilgisi { get; set; }

        //Doktor Bilgileri
        [DataMember]
        public string RaporYazanKullanici { get; set; }
        [DataMember]
        public string RaporYazanKullaniciImza { get; set; }
        [DataMember]
        public string IslemiYapanDoktor { get; set; }
        [DataMember]
        public string IslemiYapanDoktorImza { get; set; }
        [DataMember]
        public string IletisimBilgileri { get; set; }
        [DataMember]
        public string RaporBasanKullanici { get; set; }

        //Tanılar
        [DataMember]
        public List<RadiologyDiagnosisData> Tanilar { get; set; }

    }

    [Serializable]
    public class RadiologyDiagnosisData
    {
        [DataMember]
        public string TaniKodu { get; set; }
        [DataMember]
        public string TaniAdi { get; set; }
    }
}
