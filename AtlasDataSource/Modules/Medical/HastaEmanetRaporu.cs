using Microsoft.VisualBasic;
using ReportClasses.ReportUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using TTInstanceManagement;
using TTObjectClasses;

namespace AtlasDataSource.Modules.Medical
{
    public class HastaEmanetRaporu
    {
        public static HastaEmanetRaporuData GetReportData(string parameters)
        {
            return ApiCaller.CallAnyApiWithParams<HastaEmanetRaporuData>(parameters, "GetHastaEmanetRaporuData");
        }

        public static HastaEmanetRaporuData GetHastaEmanetRaporuData(string parameters)
        {
            HastaEmanetRaporuData data = new HastaEmanetRaporuData();
            if (parameters != null)
            {
                var param = Newtonsoft.Json.JsonConvert.DeserializeObject<HastaEmanetRaporuParameters>(parameters.ToString());                
                using (var objectContext = new TTObjectContext(true))
                {

                    Episode episode = objectContext.GetObject<Episode>(param.EpisodeID);
                    InPatientTreatmentClinicApplication treatmentClinicApplication = episode.InPatientTreatmentClinicApplications.Where(t => t.CurrentStateDefID != InPatientTreatmentClinicApplication.States.Cancelled &&
                                                                                                                                             t.CurrentStateDefID != InPatientTreatmentClinicApplication.States.PreAcception &&
                                                                                                                                             t.CurrentStateDefID != InPatientTreatmentClinicApplication.States.Acception).OrderByDescending(t => t.ClinicInpatientDate).FirstOrDefault();
                    
                    data.XXXXXXAdi = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "XXXXXX");
                    data.HastaTCkimlikNo = episode.Patient.UniqueRefNo.ToString();
                    data.HastaAdiSoyadi = episode.Patient.Name + " " + episode.Patient.Surname;
                    data.HastaAdresi = episode.Patient.PatientAddress.HomeAddress;
                    data.CepTelefonu = episode.Patient.MobilePhone.ToString();
                    if (treatmentClinicApplication != null)
                    {
                        data.Birimi = treatmentClinicApplication.MasterResource.Name;
                        data.Doktoru = treatmentClinicApplication.ProcedureDoctor.Name;
                        data.KabulNumarasi = treatmentClinicApplication.SubEpisode.ProtocolNo;
                        data.KlinikProtokolNo = treatmentClinicApplication.ProtocolNo.ToString();
                        data.YatisTarihi = treatmentClinicApplication.ClinicInpatientDate.Value.ToShortDateString().ToString();
                        data.ArsivNumarasi = episode.Patient.ID.ToString();
                    }

                    var materialList = InpatientAdmissionDepositMaterial.InpatientAdmissionDepositMaterialFormList(objectContext, param.EpisodeID).ToList();
                    foreach (var material in materialList)
                    {
                        if (data.EmanetListesi == null)
                            data.EmanetListesi = new List<EmanetData>();

                        EmanetData emanetData = new EmanetData();
                        emanetData.IslemTarihi = material.ProcessDate.Value.ToShortDateString();
                        emanetData.IslemTipi = material.Processtype != null ? Common.GetDisplayTextOfEnumValue("QuarantineProcessType",(int)material.Processtype) : "" ;
                        emanetData.IslemYapanKullanici = material.Processuser;
                        emanetData.EmanetAlinan = material.Description;
                        data.EmanetListesi.Add(emanetData);
                    }

                }
            }

            return data;
        }

    }

    [Serializable]
    public class HastaEmanetRaporuParameters
    {
        [DataMember]
        public Guid EpisodeID { get; set; }       
    }

    [Serializable]
    public class HastaEmanetRaporuData
    {
        [DataMember]
        public string XXXXXXAdi { get; set; }
        [DataMember]
        public string HastaTCkimlikNo { get; set; }
        [DataMember]
        public string HastaAdiSoyadi { get; set; }
        [DataMember]
        public string Birimi { get; set; }
        [DataMember]
        public string KabulNumarasi { get; set; }
        [DataMember]
        public string ArsivNumarasi { get; set; }
        [DataMember]
        public string Doktoru { get; set; }
        [DataMember]
        public string YatisTarihi { get; set; }
        [DataMember]
        public string KlinikProtokolNo { get; set; }
        [DataMember]
        public string CepTelefonu { get; set; }
        [DataMember]
        public string HastaAdresi { get; set; }
        [DataMember]
        public List<EmanetData> EmanetListesi { get; set; }

    }

    [Serializable]
    public class EmanetData
    {
        [DataMember]
        public string IslemTarihi { get; set; }
        [DataMember]
        public string IslemTipi { get; set; }
        [DataMember]
        public string EmanetAlinan { get; set; }
        [DataMember]
        public string IslemYapanKullanici { get; set; }

    }
}
