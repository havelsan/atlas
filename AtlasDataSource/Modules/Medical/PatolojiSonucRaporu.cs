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

    public class PatolojiSonucRaporu 
    {
        public static PathologyResultReportData GetReportData(string parameters)
        {
            return ApiCaller.CallAnyApiWithParams<PathologyResultReportData>(parameters, "GetPathologyResultReportData");
        }
        public static PathologyResultReportData GetPathologyResultReportData(string parameters)
        {
            PathologyResultReportData data = new PathologyResultReportData();

            SKRSKurumlar myTesisSKRSKurumlarDefinition = SKRSKurumlar.GetMyTesisSKRSKurumlarDefinition();

            if (myTesisSKRSKurumlarDefinition != null)
            {
                data.KurumCKYSKodu = myTesisSKRSKurumlarDefinition.KODU.ToString();
            }

            

            if (parameters != null)
            {
               var param = Newtonsoft.Json.JsonConvert.DeserializeObject<PathologyResultReportParameters>(parameters.ToString());
                using (var objectContext = new TTObjectContext(false))
                {
                    Pathology pathology = objectContext.GetObject<Pathology>(param.ObjectID);  //RTF alanların texti nqlde alınamadığı için 
                    Episode episode = pathology.Episode;
                    Patient patient = episode.Patient;
                    PathologyRequest pathologyRequest = pathology.PathologyRequest;
                    data.HastaAdiSoyadi = patient.Name + " " + patient.Surname;
                    data.HastaDogumTarihi = patient.BirthDate;
                    data.HastaCinsiyet = patient.Sex.ADI;
                    data.HastaTC = patient.UniqueRefNo.ToString();

                    data.ProtokolNumarasi = pathology.MatPrtNoString;
                    data.IstekTarihi = pathologyRequest.RequestDate;
                    data.MateryalKabulTarihi = pathologyRequest.AcceptionDate;
                    data.OnayTarihi = pathology.ApproveDate;
                    data.RaporTarihi = pathology.ReportDate;
                    data.IstekYapanDoktor = pathologyRequest.RequestDoctor.Name;
                    data.IstekYapanBolum = pathologyRequest.FromResource.Name;
                    data.IslemiYapanDoktor = pathology.ProcedureDoctor == null?"": pathology.ProcedureDoctor.Name;
                    if (pathology.ProcedureDoctor != null)
                    {
                        data.IslemiYapanDoktor = pathology.ProcedureDoctor.Name;
                        data.IslemiYapanDoktorImza = pathology.ProcedureDoctor.SignatureBlock == null ? "" : pathology.ProcedureDoctor.SignatureBlock;
                    }else
                    {
                        data.IslemiYapanDoktor = "";
                        data.IslemiYapanDoktorImza = "";
                    }
                    data.UzmanDoktor = pathology.SpecialDoctor == null ? "": pathology.SpecialDoctor.Name;
                    data.AsistanDoktor = pathology.AssistantDoctor == null ? "" : pathology.AssistantDoctor.Name;
                    data.MateryalKabulNotu = pathologyRequest.AcceptionNote == null? "": pathologyRequest.AcceptionNote;
                    data.TeknisyenNotu = pathology.TechnicianNote == null ? "" : pathology.TechnicianNote;
                    data.PatolojiDefterNumarasi = pathology.PathologyArchiveNo == null ? "" : pathology.PathologyArchiveNo;

                    if (pathology.PathologyAdditionalReport != null)
                    {
                        data.PatolojiEkRapor = Common.GetTextOfRTFString(pathology.PathologyAdditionalReport.AdditionalReport.ToString());
                        data.PatolojiEkRaporTarihi = pathology.PathologyAdditionalReport.ReportDate;
                        data.PatolojiEkRaporOnayTarihi = pathology.PathologyAdditionalReport.ApproveDate;
                    }

                    data.PatolojiMateryaller = new List<PathologyMaterialData>();
                    foreach(PathologyMaterial material in pathology.PathologyMaterial)
                    {
                        PathologyMaterialData m = new PathologyMaterialData();
                        m.MateryalNumarasi = material.MaterialNumber == null ? "" : material.MaterialNumber;
                        m.NumuneAlinmaTarihi = material.DateOfSampleTaken;
                        m.AlindigiOrgan = material.YerlesimYeri == null?"": material.YerlesimYeri.TOPOGRAFIKODU+"-"+ material.YerlesimYeri.KODTANIMI;
                        m.AlindigiDokununTemelOzelligi = material.AlindigiDokununTemelOzelligi == null ? "":material.AlindigiDokununTemelOzelligi.ADI;
                        m.NumuneAlinmaSekli = material.NumuneAlinmaSekli == null? "":material.NumuneAlinmaSekli.ADI;
                        m.PreparatDurumu = material.PatolojiPreparatiDurumu == null?"":material.PatolojiPreparatiDurumu.ADI;
                        m.MorfolojiKodu = material.MorfolojiKodu == null?"":material.MorfolojiKodu.MORFOLOJIKOD +"-"+ material.MorfolojiKodu.MORFOLOJIKODTANIM;
                        m.KlinikBulgular = material.ClinicalFindings == null ? "" : material.ClinicalFindings;
                        m.Aciklama = material.Description == null ? "" : material.Description;
                        m.Makroskopi = material.Macroscopy == null ? "" : material.Macroscopy.ToString();
                        m.Mikroskopi = material.Microscopy == null ? "" : material.Microscopy.ToString();
                        m.NotYorum = material.Note == null ? "" : material.Note.ToString();
                        m.Tani = material.PathologicDiagnosis == null ? "" : material.PathologicDiagnosis.ToString();
                        m.Bening = material.Benign == null ? false : Convert.ToBoolean(material.Benign);
                        m.Malign = material.Malign == null ? false : Convert.ToBoolean(material.Malign);
                        m.SupheliMalign = material.SuspiciousMalign == null ? false : Convert.ToBoolean(material.SuspiciousMalign);
                        m.Frozen = material.Frozen == null ? false : Convert.ToBoolean(material.Frozen);

                        m.PatolojiTetkikler = new List<PathologyProcedureData>();
                        foreach(PathologyTestProcedure procedure in material.PathologyTestProcedure)
                        {
                            PathologyProcedureData p = new PathologyProcedureData();
                            p.TetkikKodu = procedure.ProcedureObject.Code;
                            p.TetkikAdi = procedure.ProcedureObject.Name;
                            p.TetkikAdeti = procedure.Amount.ToString();
                            p.TetkikIstemTarihi = procedure.CreationDate;
                            p.TetkikTamamlanmaTarihi = procedure.PerformedDate;
                            p.IslemiYapanDoktor = procedure.ProcedureDoctor== null?"": procedure.ProcedureDoctor.Name;

                            p.TetkikIsteyenDoktor =   procedure.RequestedByUser.Name;
                            p.TetkikIsteyenDoktorBirim = procedure.RequestedByUser.Brans == null ? "": procedure.RequestedByUser.Brans.Name;
                            m.PatolojiTetkikler.Add(p);
                        }
                        data.PatolojiMateryaller.Add(m);
                    }

                    //BindingList<DiagnosisGrid.getDiagnosisJustBySubepisode_Class> diagnosis = DiagnosisGrid.getDiagnosisJustBySubepisode(pathology.SubEpisode.ObjectID.ToString());

                    var diagnosisList = DiagnosisGrid.GetBySubEpisode(objectContext, pathology.SubEpisode.ObjectID.ToString());
                    data.Tanilar = new List<PathologyDiagnosisData>();
                    foreach (DiagnosisGrid d in diagnosisList)
                    {
                        PathologyDiagnosisData tani = new PathologyDiagnosisData();
                        tani.TaniKodu = d.Diagnose.Code;
                        tani.TaniAdi = d.Diagnose.Name;
                        data.Tanilar.Add(tani);
                    }

                    TTObjectClasses.SpecialityDefinition Speciality;
                    string resBrans = pathology.GetBranchCodeForMedula();
                    data.SKRSKlinikBransKodu = "";
                    if (resBrans != null)
                    {
                        IBindingList specialtyList = SpecialityDefinition.GetSpecialityByCode(objectContext, resBrans);
                        if (specialtyList.Count > 0)
                        {
                            Speciality = (SpecialityDefinition)specialtyList[0];

                            if (Speciality.SKRSKlinik != null)
                                data.SKRSKlinikBransKodu = Speciality.SKRSKlinik.KODU.ToString();
                        }


                    }
                }
            }
            return data;

         }
    }

    [Serializable]
    public class PathologyResultReportParameters
    {
        [DataMember]
        public Guid ObjectID { get; set; } //Patoloji'nin ObjectIDsi

    }
    [Serializable]
    public class PathologyResultReportData
    {
        //Hasta Bilgileri
        [DataMember]
        public string HastaAdiSoyadi { get; set; }
        [DataMember]
        public DateTime? HastaDogumTarihi { get; set; }
        [DataMember]
        public string HastaCinsiyet { get; set; }
        [DataMember]
        public string HastaTC { get; set; }
       
        //Patoloji Bilgileri
        [DataMember]
        public string ProtokolNumarasi { get; set; }
        [DataMember]
        public DateTime? IstekTarihi { get; set; }
        [DataMember]
        public DateTime? MateryalKabulTarihi { get; set; }
        [DataMember]
        public DateTime? OnayTarihi { get; set; }
        [DataMember]
        public DateTime? RaporTarihi { get; set; }
        [DataMember]
        public string IstekYapanDoktor { get; set; }

        [DataMember]
        public string IstekYapanBolum { get; set; }
        [DataMember]
        public string IslemiYapanDoktor { get; set; }

        [DataMember]
        public string IslemiYapanDoktorImza { get; set; }
        [DataMember]
        public string UzmanDoktor { get; set; }
        [DataMember]
        public string AsistanDoktor { get; set; }
        [DataMember]
        public string MateryalKabulNotu { get; set; }
        [DataMember]
        public string TeknisyenNotu { get; set; }
        [DataMember]
        public string PatolojiEkRapor { get; set; }
        [DataMember]
        public DateTime? PatolojiEkRaporTarihi { get; set; }
        [DataMember]
        public DateTime? PatolojiEkRaporOnayTarihi { get; set; }
        [DataMember]
        public string PatolojiDefterNumarasi { get; set; }

        //Patoloji Materyal Bilgileri
        [DataMember]
        public List<PathologyMaterialData> PatolojiMateryaller { get; set; }

        //Tanılar
        [DataMember]
        public List<PathologyDiagnosisData> Tanilar { get; set; }

        [DataMember]
        public string KurumCKYSKodu { get; set; }
        [DataMember]
        public string SKRSKlinikBransKodu { get; set; }


    }
    [Serializable]
    public class PathologyMaterialData
    {
        [DataMember]
        public string MateryalNumarasi { get; set; }
        [DataMember]
        public DateTime? NumuneAlinmaTarihi { get; set; }
        [DataMember]
        public string AlindigiOrgan { get; set; }
        [DataMember]
        public string AlindigiDokununTemelOzelligi { get; set; }
        [DataMember]
        public string NumuneAlinmaSekli { get; set; }
        [DataMember]
        public string PreparatDurumu { get; set; }
        [DataMember]
        public string MorfolojiKodu { get; set; }
        [DataMember]
        public string KlinikBulgular { get; set; }
        [DataMember]
        public string Aciklama { get; set; }
        [DataMember]
        public string Makroskopi { get; set; }
        [DataMember]
        public string Mikroskopi { get; set; }
        [DataMember]
        public string NotYorum { get; set; }
        [DataMember]
        public string Tani { get; set; }
        [DataMember]
        public bool Bening { get; set; }
        [DataMember]
        public bool Malign { get; set; }
        [DataMember]
        public bool SupheliMalign { get; set; }
        [DataMember]
        public bool Frozen { get; set; }
        [DataMember]
        public List<PathologyProcedureData> PatolojiTetkikler { get; set; }
    }

    [Serializable]
    public class PathologyProcedureData
    {
        [DataMember]
        public string TetkikKodu { get; set; }
        [DataMember]
        public string TetkikAdi { get; set; }
        [DataMember]
        public string TetkikAdeti { get; set; }
        [DataMember]
        public DateTime? TetkikIstemTarihi { get; set; }
        [DataMember]
        public DateTime? TetkikTamamlanmaTarihi { get; set; }
        [DataMember]
        public string IslemiYapanDoktor { get; set; }
        [DataMember]
        public string TetkikIsteyenDoktor { get; set; }
        [DataMember]
        public string TetkikIsteyenDoktorBirim { get; set; }
    }

    [Serializable]
    public class PathologyDiagnosisData
    {
        [DataMember]
        public string TaniKodu { get; set; }
        [DataMember]
        public string TaniAdi { get; set; }
    }

}
