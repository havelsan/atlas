using Newtonsoft.Json;
using ReportClasses.ReportUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using TTDataDictionary;
using TTInstanceManagement;
using TTObjectClasses;
using TTUtils;

namespace AtlasDataSource.Controllers
{
    public class MedulaTransferredPayerReport
    {
        public static MedulaTransferredPayerData GetReportData(string parameters)
        {
            return ApiCaller.CallAnyApiWithParams<MedulaTransferredPayerData>(parameters, "GetReceiptDetailedReport");
        }

        public static MedulaTransferredPayerData GetReceiptDetailedReport(string parameters)
        {

            MedulaTransferredPayerData data = new MedulaTransferredPayerData();

            if (parameters == null)
            {
                //AtlasDev veri tabanından alınmış test objectidsi
                var testParam = new MedulaTransferredPayerParamters() { PAOBJECTID = new Guid("bbf7e372-c5c3-4fc3-98e1-a63d1e49bf19") };
                parameters = JsonConvert.SerializeObject(testParam);
            }
            if (parameters != null)
            {
                var param = Newtonsoft.Json.JsonConvert.DeserializeObject<MedulaTransferredPayerParamters>(parameters.ToString());
                using (TTObjectContext objectContext = new TTObjectContext(true))
                {
                    PatientAdmission patientAdmission = objectContext.GetObject<PatientAdmission>(param.PAOBJECTID);
                    var sep = patientAdmission.SEP;
                    var patient = patientAdmission.Episode.Patient;

                    data.Cinsiyet = patient.Sex.ADI;
                    data.DogumTarihi = patient.BirthDate;
                    data.HastaAdi = patient.Name;
                    data.HastaSoyadi = patient.Surname;
                    data.HastaAdiSoyadi = data.HastaAdi + " " + data.HastaSoyadi;
                    data.BasvuruNo = sep.MedulaBasvuruNo;
                    data.TakipNo = sep.MedulaTakipNo;
                    data.HastaAdiSoyadi = patient.Name + " " + patient.Surname;
                    data.XXXXXXAdi = SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    data.DevredilenKurum = sep.Payer.MedulaDevredilenKurum.devredilenKurumAdi;
                    data.MedulaSonucMesaji = sep.MedulaSonucMesaji;
                    data.TCNo = patient.UniqueRefNo;

                }
            }
            return data;
        }

        [Serializable]
        public class MedulaTransferredPayerParamters
        {
            [DataMember]
            public Guid PAOBJECTID { get; set; } //ForensicMedicalReport'un ObjectIDsi
        }

        [Serializable]
        public class MedulaTransferredPayerData
        {
            /// <summary>
            /// Hatane Adı. HospitalName sistem parametresi
            /// </summary>
            [DataMember]
            public string XXXXXXAdi { get; set; }
            /// <summary>
            /// UniqueRefNo
            /// </summary>
            [DataMember]
            public long? TCNo { get; set; }
            [DataMember]
            public string HastaAdi { get; set; }
            [DataMember]
            public string HastaSoyadi { get; set; }
            [DataMember]
            public string HastaAdiSoyadi { get; set; }
            [DataMember]
            public string Cinsiyet { get; set; }
            [DataMember]
            public string DevredilenKurum { get; set; }
            [DataMember]
            public DateTime? DogumTarihi { get; set; }
            [DataMember]
            public string TakipNo { get; set; }
            [DataMember]
            public string BasvuruNo { get; set; }
            [DataMember]
            public string MedulaSonucMesaji { get; set; }
        }
    }
}
