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
    public class MedulaResultReport
    {
        public static MedulaResultReportData GetReportData(string parameters)
        {
            return ApiCaller.CallAnyApiWithParams<MedulaResultReportData>(parameters, "GetReceiptDetailedReport");
        }

        public static MedulaResultReportData GetReceiptDetailedReport(string parameters)
        {

            MedulaResultReportData data = new MedulaResultReportData();

            if (parameters == null)
            {
                //AtlasDev veri tabanından alınmış test objectidsi
                var testParam = new MedulaResultReportParamters() { PAOBJECTID = new Guid("bbf7e372-c5c3-4fc3-98e1-a63d1e49bf19") };
                parameters = JsonConvert.SerializeObject(testParam);
            }
            if (parameters != null)
            {
                var param = Newtonsoft.Json.JsonConvert.DeserializeObject<MedulaResultReportParamters>(parameters.ToString());
                using (TTObjectContext objectContext = new TTObjectContext(true))
                {
                    PatientAdmission patientAdmission = objectContext.GetObject<PatientAdmission>(param.PAOBJECTID);
                    var se = patientAdmission.SubEpisodes.OrderBy(x => x.OpeningDate).FirstOrDefault();
                    var sep = se.SubEpisodeProtocols.OrderBy(x => x.CreationDate).FirstOrDefault();
                    var patient = patientAdmission.Episode.Patient;

                    data.Adresi = patient.PatientAddress.HomeAddress;
                    data.AnneAdi = patient.MotherName;
                    data.BabaAdi = patient.FatherName;
                    data.BasvuruTarihi = patientAdmission.ActionDate;
                    data.CalismaDurumu = patientAdmission.MedulaSigortaliTuru.sigortaliTuruAdi;
                    data.CepTelefonu = patient.PatientAddress.MobilePhone;
                    data.Cinsiyet = patient.Sex.ADI;
                    data.DogumTarihi = patient.BirthDate;
                    data.DogumYeri = patient.BirthPlace;
                    data.HastaAdi = patient.Name;
                    data.HastaSoyadi = patient.Surname;
                    data.HastaAdiSoyadi = patient.Name + " " + patient.Surname;
                    data.XXXXXXAdi = SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    data.KabulTarihi = patientAdmission.ActionDate;
                    data.Kurum = sep.Payer.Name;
                    data.MedulaHataMesaji = sep.MedulaSonucMesaji;
                    data.PasaportNo = patient.PassportNo;
                    data.TCNo = patient.UniqueRefNo;
                    data.Uyruk = patient.Nationality.Adi;

                }
            }
            return data;
        }

        [Serializable]
        public class MedulaResultReportParamters
        {
            [DataMember]
            public Guid PAOBJECTID { get; set; } //ForensicMedicalReport'un ObjectIDsi
        }

        [Serializable]
        public class MedulaResultReportData
        {
            /// <summary>
            /// Hatane Adı. HospitalName sistem parametresi
            /// </summary>
            [DataMember]
            public string XXXXXXAdi { get; set; }
            [DataMember]
            public DateTime? BasvuruTarihi { get; set; }
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
            public string Kurum { get; set; }
            [DataMember]
            public string DogumYeri { get; set; }
            [DataMember]
            public DateTime? DogumTarihi { get; set; }
            [DataMember]
            public string AnneAdi { get; set; }
            [DataMember]
            public string BabaAdi { get; set; }
            [DataMember]
            public string Uyruk { get; set; }
            [DataMember]
            public string PasaportNo { get; set; }
            [DataMember]
            public string CalismaDurumu { get; set; }
            [DataMember]
            public string CepTelefonu { get; set; }
            [DataMember]
            public string Adresi { get; set; }
            [DataMember]
            public DateTime? KabulTarihi { get; set; }
            [DataMember]
            public string MedulaHataMesaji { get; set; }
        }
    }
}
