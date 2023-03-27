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
    public class NukleerTipSonucRaporu
    {
        public static NuclearResultReportData GetReportData(string parameters)
        {
            return ApiCaller.CallAnyApiWithParams<NuclearResultReportData>(parameters, "GetNuclearResultReportData");
        }
        public static NuclearResultReportData GetNuclearResultReportData(string parameters)
        {
            NuclearResultReportData data = new NuclearResultReportData();
            if (parameters != null)
            {
                var param = Newtonsoft.Json.JsonConvert.DeserializeObject<NuclearResultReportParameters>(parameters.ToString());
                using (var objectContext = new TTObjectContext(false))
                {
                    NuclearMedicine nuclearMedicine = objectContext.GetObject<NuclearMedicine>(param.ObjectID);
                    SubEpisode subepisode = nuclearMedicine.SubEpisode;
                    Episode episode = subepisode.Episode;
                    Patient patient = episode.Patient;

                    data.HastahaneAdi = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    data.HastaTC = patient.UniqueRefNo.ToString();
                    data.HastaAdiSoyadi = patient.Name.ToString() + " " + patient.Surname.ToString();
                    data.HastaDogumTarihi = patient.BirthDate;
                    data.HastaDogumYeri = patient.TownOfBirth == null ? "" : patient.TownOfBirth.Name;
                    data.Cinsiyeti = patient.Sex == null ? "" : patient.Sex.ADI;
                    data.KabulNumarasi = subepisode.ProtocolNo;
                    data.Rapor = nuclearMedicine.Report == null ? "" : nuclearMedicine.Report.ToString();
                    data.BulgularveKarsilastirmaBilgisi = nuclearMedicine.ResultsAndComparisonInfo == null ? "" : nuclearMedicine.ResultsAndComparisonInfo.ToString();
                    foreach (NuclearMedicineTest nTest in nuclearMedicine.NuclearMedicineTests)
                    {
                        //Çekim tarihi
                        foreach (TTObjectState objectState in nTest.GetStateHistory())
                        {
                            if (objectState.StateDefID == NuclearMedicineTest.States.Completed)
                                data.CekimTarihi = objectState.BranchDate;
                        }

                        if (nTest.AccessionNo != null)
                            data.AccessionNo = nTest.AccessionNo.ToString();
                        else
                            data.AccessionNo = "";

                        if (nTest.NuclearMedicineTestDef.SKRSLoincKodu != null)
                            data.LoincKodu = nTest.NuclearMedicineTestDef.SKRSLoincKodu.LOINCNUMARASI;
                        else
                            data.LoincKodu = "";

                        data.TetkikAdi = nTest.NuclearMedicineTestDef.Name;
                        data.CihazAdi = nTest.Equipment == null ? "" : nTest.Equipment.Name;

                    }
                    data.RaporOnayTarihi = nuclearMedicine.ReportDate;
                    data.TetkikIsteyenServis = nuclearMedicine.FromResource.Name;
                    data.TetkikIsteyenDoktor = nuclearMedicine.RequestDoctor.Name;
                    data.TetkikIstemNedeni = nuclearMedicine.Description == null ? "" : nuclearMedicine.Description;
                    data.RadyofarmasotikBilgisi = "";

                    if (nuclearMedicine.ProcedureDoctor != null)
                    {
                        data.IslemiYapanDoktor = nuclearMedicine.ProcedureDoctor.Name;
                        data.IslemiYapanDoktorImza = nuclearMedicine.ProcedureDoctor.SignatureBlock == null ? "" : nuclearMedicine.ProcedureDoctor.SignatureBlock;
                    }
                    else
                    {
                        data.IslemiYapanDoktor = "";
                        data.IslemiYapanDoktorImza = "";
                    }

                    var diagnosisList = DiagnosisGrid.GetBySubEpisode(objectContext, nuclearMedicine.SubEpisode.ObjectID.ToString());
                    data.Tanilar = new List<NuclearDiagnosisData>();
                    foreach (DiagnosisGrid d in diagnosisList)
                    {
                        NuclearDiagnosisData tani = new NuclearDiagnosisData();
                        tani.TaniKodu = d.Diagnose.Code;
                        tani.TaniAdi = d.Diagnose.Name;
                        data.Tanilar.Add(tani);
                    }


                }
            }
            return data;
        }
    }

    [Serializable]
    public class NuclearResultReportParameters
    {
        [DataMember]
        public Guid ObjectID { get; set; } //NUCLEARMEDICINE'nin ObjectIDsi

    }

    [Serializable]
    public class NuclearResultReportData
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
        [DataMember]
        public string KabulNumarasi { get; set; }

        [DataMember]
        public string LoincKodu { get; set; }
        [DataMember]
        public string AccessionNo { get; set; }
        [DataMember]
        public DateTime? CekimTarihi { get; set; }
        [DataMember]
        public DateTime? RaporOnayTarihi { get; set; }
        [DataMember]
        public string TetkikIsteyenServis { get; set; }
        [DataMember]
        public string TetkikIsteyenDoktor { get; set; }

        [DataMember]
        public string TetkikIstemNedeni { get; set; }
        [DataMember]
        public string TetkikAdi { get; set; }
        [DataMember]
        public string CihazAdi { get; set; }
        [DataMember]
        public string RadyofarmasotikBilgisi { get; set; }
        [DataMember]
        public string IslemiYapanDoktor { get; set; }
        [DataMember]
        public string IslemiYapanDoktorImza { get; set; }
        [DataMember]
        public string Rapor { get; set; }
        [DataMember]
        public string BulgularveKarsilastirmaBilgisi { get; set; }
        //Tanılar
        [DataMember]
        public List<NuclearDiagnosisData> Tanilar { get; set; }

    }

    [Serializable]
    public class NuclearDiagnosisData
    {
        [DataMember]
        public string TaniKodu { get; set; }
        [DataMember]
        public string TaniAdi { get; set; }
    }
}
