using ReportClasses.ReportUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TTObjectClasses;

namespace AtlasDataSource.Modules.Medical.Yatan_Hasta_Rapor
{
    class PatientVacationForm
    {
        public static PatientVacationFormData GetReportData(string parameters)
        {
            return ApiCaller.CallAnyApiWithParams<PatientVacationFormData>(parameters, "GetPatientVacationFormData");
        }

        public static PatientVacationFormData GetPatientVacationFormData(string parameters)
        {
            PatientVacationFormData data = new PatientVacationFormData();

            if (parameters != null)
            {
                var param = Newtonsoft.Json.JsonConvert.DeserializeObject<PatientVacationReportParameters>(parameters.ToString());

                BindingList<PatientOnVacation.GetVacationInfoByID_Class> MedicalReport = PatientOnVacation.GetVacationInfoByID(param.ObjectID);
                if (MedicalReport.Count > 0)
                {
                    PatientOnVacation.GetVacationInfoByID_Class report = MedicalReport[0];
                    data.HastahaneAdi = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALSHORTNAME", "");
                    data.HastaAdi = report.Name;
                    data.Cinsiyet = report.Cinsiyet;
                    data.DogumTarihi = report.BirthDate;
                    data.KimlikNo = report.UniqueRefNo == null ? "" : report.UniqueRefNo.ToString();
                    data.KabulNo = report.ProtocolNo;
                    data.TedaviGorduguServis = report.Tedavigordugu;
                    data.YattigiServis = report.Yattigiklinik;
                    data.Doktor = report.Doktor;
                    data.IzinBaslangic = report.StartDate;
                    data.IzinBitis = report.EndDate;
                    data.Adres = report.VacationAdress;
                    data.Telefon = report.MobilePhone;
                    data.YakinAdi = report.RelativesName;
                    data.YakinTelefon = report.RelativesPhoneNumber;

                }
            }
            return data;

        }

        [Serializable]
        public class PatientVacationReportParameters
        {
            [DataMember]
            public Guid ObjectID { get; set; } //ForensicMedicalReport'un ObjectIDsi

        }

        [Serializable]
        public class PatientVacationFormData
        {
            [DataMember]
            public string HastaAdi { get; set; }
            [DataMember]
            public string Cinsiyet { get; set; }
            [DataMember]
            public DateTime? DogumTarihi { get; set; }
            [DataMember]
            public string KimlikNo { get; set; }
            [DataMember]
            public string KabulNo { get; set; }
            [DataMember]
            public string TedaviGorduguServis { get; set; }
            [DataMember]
            public string YattigiServis { get; set; }
            [DataMember]
            public string Doktor { get; set; }
            [DataMember]
            public DateTime? IzinBaslangic { get; set; }
            [DataMember]
            public DateTime? IzinBitis { get; set; }
            [DataMember]
            public string Adres { get; set; }
            [DataMember]
            public string Telefon { get; set; }
            [DataMember]
            public string YakinAdi { get; set; }
            [DataMember]
            public string YakinTelefon { get; set; }
            [DataMember]
            public string HastahaneAdi { get; set; }

        }

        }
}
