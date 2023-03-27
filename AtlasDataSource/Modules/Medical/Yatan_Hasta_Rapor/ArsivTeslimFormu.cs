using System;
using System.Runtime.Serialization;
using TTObjectClasses;
using System.ComponentModel;
using TTInstanceManagement;
using TTStorageManager.Security;
using ReportClasses.ReportUtils;
using System.Collections.Generic;

namespace AtlasDataSource.Controllers
{
    public class ArsivTeslimFormu
    {
        public static ArsivTeslimFormuData GetReportData(string parameters)
        {
            return ApiCaller.CallAnyApiWithParams<ArsivTeslimFormuData>(parameters, "GetArsivTeslimFormuData");
        }
        public static ArsivTeslimFormuData GetArsivTeslimFormuData(string parameters)
        {
            ArsivTeslimFormuData data = new ArsivTeslimFormuData();
            data.HastahaneAdi = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
            if (parameters != null)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    var param = Newtonsoft.Json.JsonConvert.DeserializeObject<ArsivTeslimFormuParameters>(parameters.ToString());

                    SubEpisode subepisode = objectContext.GetObject<SubEpisode>(new Guid(param.SubepisodeID));
                  
                    //Hasta Bilgileri
                    data.HastaAdiSoyadi = subepisode.Episode.Patient.Name + " " + subepisode.Episode.Patient.Surname;
                    data.KabulNo = subepisode.ProtocolNo;
                    data.TCKimlikNo = subepisode.Episode.Patient.UniqueRefNo == null ? "" : subepisode.Episode.Patient.UniqueRefNo.ToString();
                    EpisodeAction starterEpisodeAction = subepisode.StarterEpisodeAction;
                    if (starterEpisodeAction is InPatientTreatmentClinicApplication)
                    {
                        var TreatmentClinicApp = (InPatientTreatmentClinicApplication)starterEpisodeAction;


                        data.YatisTarihi = TreatmentClinicApp.ClinicInpatientDate;
                        data.CikisTarihi = TreatmentClinicApp.ClinicDischargeDate;
                        data.DoktorAdi = TreatmentClinicApp.ProcedureDoctor == null?"": TreatmentClinicApp.ProcedureDoctor.Name;
                        data.KlinikAdi = starterEpisodeAction.FromResource.Name;

                    }

                    BindingList<ArchiveDeliveryForm> form = ArchiveDeliveryForm.GetArchiveDeliveryFormBySubepisodeID(objectContext, new Guid(param.SubepisodeID));
                    if (form.Count > 0)
                    {
                        data.Aciklama = form[0].Description;
                        data.TeslimAlan = form[0].Recipient.Name;
                        data.TeslimEden = form[0].Deliverer.Name;
                        data.EvrakListesi = new List<EvrakBilgisi>();
                        foreach (ArchiveDeliveryFormDetails detail in form[0].ArchiveDeliveryFormDetails)
                        {
                            EvrakBilgisi i = new EvrakBilgisi();
                           
                            i.EvrakAdi = detail.FolderContent.FileName;
                            i.SayfaSayisi = detail.PageNumber;
                            data.EvrakListesi.Add(i);
                        }
                    }

                }
            }
            return data;
        }
    }

    [Serializable]
    public class ArsivTeslimFormuParameters
    {
        [DataMember]
        public string SubepisodeID { get; set; }
    }

    [Serializable]
    public class ArsivTeslimFormuData
    {
        [DataMember]
        public string HastahaneAdi { get; set; }

        //Hasta Bilgileri
        [DataMember]
        public string HastaAdiSoyadi { get; set; }
        [DataMember]
        public string TCKimlikNo { get; set; }
        [DataMember]
        public string KabulNo { get; set; }
        [DataMember]
        public string KlinikAdi { get; set; }
        [DataMember]
        public string DoktorAdi { get; set; }
        [DataMember]
        public DateTime? YatisTarihi { get; set; }
        [DataMember]
        public DateTime? CikisTarihi { get; set; }
       
        //Evrak Listesi
        [DataMember]
        public List<EvrakBilgisi> EvrakListesi { get; set; }

        //Rapor Bilgileri
        [DataMember]
        public string Aciklama { get; set; }
        [DataMember]
        public string TeslimAlan { get; set; }

        [DataMember]
        public string TeslimEden { get; set; }

    }

    [Serializable]
    public class EvrakBilgisi
    {
        [DataMember]
        public string EvrakAdi { get; set; }
        [DataMember]
        public string SayfaSayisi { get; set; }
    }
}
