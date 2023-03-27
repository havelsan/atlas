using System;
using System.Runtime.Serialization;
using TTObjectClasses;
using System.ComponentModel;
using TTInstanceManagement;
using TTStorageManager.Security;
using ReportClasses.ReportUtils;
using System.Linq;

namespace AtlasDataSource.Controllers
{
    public class MasrafIadeFormu
    {
        public static MasrafIadeFormuData GetReportData(string parameters)
        {
            return ApiCaller.CallAnyApiWithParams<MasrafIadeFormuData>(parameters, "GetMasrafIadeFormu");
        }

        public static MasrafIadeFormuData GetMasrafIadeFormu(string parameters)
        {
            MasrafIadeFormuData data = new MasrafIadeFormuData();

            if (parameters != null)
            {
                var param = Newtonsoft.Json.JsonConvert.DeserializeObject<MasrafIadeFormuParamters>(parameters.ToString());
                using (TTObjectContext objectContext = new TTObjectContext(true))
                {
                    PatientAdmission patientAdmission = objectContext.GetObject<PatientAdmission>(param.PAOBJECTID);
                    Patient patient = patientAdmission.Episode.Patient;
                    Episode episode = patientAdmission.Episode;

                    data.Address = patient.PatientAddress.HomeAddress;
                    data.BirthDate = patient.BirthDate;
                    data.ExaminationDate = patientAdmission.CreationDate;
                    data.FatherName = patient.FatherName;
                    data.KabulNo = episode.ID.Value.ToString();
                    data.PatientFullName = patient.FullName;
                    data.PayerName = patientAdmission.Payer.Name;
                    data.PhoneNumber = patient.MobilePhone;

                    SubEpisode subEpisode = episode.SubEpisodes.OrderBy(x => x.OpeningDate).FirstOrDefault();
                    if (subEpisode != null)
                    {
                        data.PoliclinicName = subEpisode.ResSection.Name;

                        SubEpisodeProtocol sep = subEpisode.SGKSEPWithProvisionNo;
                        if(sep != null)
                        {
                            data.GSSNo = sep.MedulaTakipNo;
                            data.ProvizyonNo = sep.MedulaTakipNo;
                        }
                    }

                    foreach (var item in episode.EpisodeActions)
                    {
                        if (item is Receipt)
                        {
                            if (((Receipt)item).CurrentStateDefID == Receipt.States.Paid)
                            {
                                data.ReceiptNo = ((Receipt)item).ReceiptDocument.DocumentNo;
                                data.ReturnPrice = ((Receipt)item).TotalPayment.Value.ToString();
                                break;
                            }
                        }
                    }
                    data.UniqueRefNo = patient.UniqueRefNo.ToString();
                }
            }
            return data;
        }

        [Serializable]
        public class MasrafIadeFormuParamters
        {
            [DataMember]
            public Guid PAOBJECTID { get; set; } //ForensicMedicalReport'un ObjectIDsi
        }

        [Serializable]
        public class MasrafIadeFormuData
        {
            [DataMember]
            public string ProvizyonNo { get; set; }
            [DataMember]
            public string PatientFullName { get; set; }
            [DataMember]
            public string FatherName { get; set; }
            [DataMember]
            public DateTime? BirthDate { get; set; }
            [DataMember]
            public string PayerName { get; set; }
            [DataMember]
            public string SicilNo { get; set; }
            [DataMember]
            public string PhoneNumber { get; set; }
            [DataMember]
            public string Address { get; set; }
            [DataMember]
            public string UniqueRefNo { get; set; }
            [DataMember]
            public DateTime? ExaminationDate { get; set; }
            [DataMember]
            public string PoliclinicName { get; set; }
            [DataMember]
            public string OnlineProtokolNo { get; set; }
            [DataMember]
            public string KabulNo { get; set; }
            [DataMember]
            public string GSSNo { get; set; }
            [DataMember]
            public string ReturnPrice { get; set; }
            [DataMember]
            public string ReceiptNo { get; set; }
        }
    }
}
