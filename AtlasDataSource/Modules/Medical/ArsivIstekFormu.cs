using ReportClasses.ReportUtils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TTInstanceManagement;
using TTObjectClasses;

namespace AtlasDataSource.Controllers
{
    class ArsivIstekFormu
    {
        public static ArchiveRequestFormData GetReportData(string parameters)
        {
            return ApiCaller.CallAnyApiWithParams<ArchiveRequestFormData>(parameters, "GetArchiveRequestFormData");
        }
        public static ArchiveRequestFormData GetArchiveRequestFormData(string parameters)
        {
            ArchiveRequestFormData data = new ArchiveRequestFormData();

            if (parameters != null)
            {
                var param = Newtonsoft.Json.JsonConvert.DeserializeObject<ArchiveRequestFormParameter>(parameters.ToString());
                using (TTObjectContext objectContext = new TTObjectContext(false))
                {
                    ArchiveRequest request = objectContext.GetObject<ArchiveRequest>(param.ArchiveRequestObjectID);
                    data.ArsivIstekAciklamasi = request.ArchiveRequestDescription;
                    data.HastaAdiSoyadi = request.EpisodeFolderRequest[0].EpisodeFolder.FileCreationAndAnalysis.Episode.Patient.Name + request.EpisodeFolderRequest[0].EpisodeFolder.FileCreationAndAnalysis.Episode.Patient.Surname;
                    data.HastaTC = request.EpisodeFolderRequest[0].EpisodeFolder.FileCreationAndAnalysis.Episode.Patient.UniqueRefNo;
                    PatientIdentityAndAddress address = request.EpisodeFolderRequest[0].EpisodeFolder.FileCreationAndAnalysis.Episode.PatientAdmissions[0].PA_Address;
                    string result = "";
                    if (address != null)
                    {
                        if (address.HomeAddress != null)
                        {
                            result += address.HomeAddress;
                        }

                        if (address.SKRSMahalleKodlari != null)
                        {
                            result += " " + address.SKRSMahalleKodlari.ADI;
                        }

                        if (address.BuildingBlockName != null)
                        {
                            result += " " + address.BuildingBlockName;
                        }
                        if (address.DisKapi != null)
                        {
                            result += " BLOK NO:" + address.DisKapi;
                        }
                        if (address.IcKapi != null)
                        {
                            result += " İÇ KAPI NO:" + address.IcKapi;
                        }
                        if (address.HomePostcode != null)
                        {
                            result += " " + address.HomePostcode;
                        }
                        if (address.HomePhone != null)
                        {
                            result += " " + address.HomePhone;
                        }

                        if (address.SKRSKoyKodlari != null)
                        {
                            result += " " + address.SKRSKoyKodlari.ADI;
                        }

                        if (address.SKRSIlceKodlari != null)
                        {
                            result += " " + address.SKRSIlceKodlari.ADI;
                        }

                        if (address.SKRSILKodlari != null)
                        {
                            result += " /" + address.SKRSILKodlari.ADI;
                        }
                    }
                    data.HastaAdres = result;
                    data.HastaTelefonNo = request.EpisodeFolderRequest[0].EpisodeFolder.FileCreationAndAnalysis.Episode.PatientAdmissions[0].PA_Address.MobilePhone;
                    Episode activeEpisode = request.EpisodeFolderRequest[0].EpisodeFolder.FileCreationAndAnalysis.Episode.Patient.Episodes.Where(episode => episode.CurrentStateDefID == Episode.States.Open).FirstOrDefault();
                    List<EpisodeAction> episodeActionList = activeEpisode.EpisodeActions.Where(ea => ea is InPatientTreatmentClinicApplication && ea.CurrentStateDefID != InPatientTreatmentClinicApplication.States.Cancelled).ToList();
                    EpisodeAction activeInpatient = episodeActionList.OrderByDescending(ea => ((InPatientTreatmentClinicApplication)ea).ClinicInpatientDate).FirstOrDefault();
                    if (activeInpatient != null)
                        data.Klinik = ((InPatientTreatmentClinicApplication)activeInpatient).MasterResource.Name;
                    data.ArsivNumarasi = request.EpisodeFolderRequest[0].EpisodeFolder.EpisodeFolderID != null ? request.EpisodeFolderRequest[0].EpisodeFolder.EpisodeFolderID : request.EpisodeFolderRequest[0].EpisodeFolder.ManuelArchiveNo;
                }
            }

            return data;
        }
        [Serializable]
        public class ArchiveRequestFormParameter
        {
            [DataMember]
            public Guid ArchiveRequestObjectID { get; set; }

        }
        [Serializable]
        public class ArchiveRequestFormData
        {
            [DataMember]
            public long? HastaTC { get; set; }
            [DataMember]
            public string HastaAdiSoyadi { get; set; }
            //İstek Bilgileri
            [DataMember]
            public string HastaAdres { get; set; }
            [DataMember]
            public string HastaTelefonNo { get; set; }
            [DataMember]
            public string ArsivNumarasi { get; set; }
            [DataMember]
            public string Klinik { get; set; }
            [DataMember]
            public string ArsivIstekAciklamasi { get; set; }


        }
    }
}
