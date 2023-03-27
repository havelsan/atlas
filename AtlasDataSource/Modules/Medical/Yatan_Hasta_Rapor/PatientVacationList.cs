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
    class PatientVacationList
    {
        public static List<PatientVacationListData> GetReportData(string parameters)
        {
            return ApiCaller.CallAnyApiWithParams<List<PatientVacationListData>>(parameters, "GetPatientVacationListData");
        }

        public static List<PatientVacationListData> GetPatientVacationListData(string parameters)
        {
            List<PatientVacationListData> list = new List<PatientVacationListData>();

            if (parameters == null)
            {
                YatanHastaListesiParam aa = new YatanHastaListesiParam();
                aa.AllClinics = true;
                aa.SelectedClinicList = new List<string>();
                aa.BaslangicTarihi = DateTime.Now;
                aa.BitisTarihi = DateTime.Now.AddDays(-50);

                parameters = Newtonsoft.Json.JsonConvert.SerializeObject(aa);
            }

            if (parameters != null)
            {
                var param = Newtonsoft.Json.JsonConvert.DeserializeObject<PatientVacationReportParameters>(parameters.ToString());

                string filter = " WHERE THIS.STARTDATE >= TODATE('" + Convert.ToDateTime(param.BaslangicTarihi.ToShortDateString() + " 00:00:00").ToString("yyyy-MM-dd HH:mm:ss") + "')";
                filter += "  AND THIS.STARTDATE <= TODATE('" + Convert.ToDateTime(param.BitisTarihi.AddDays(1).ToShortDateString() + " 00:00:00").ToString("yyyy-MM-dd HH:mm:ss") + "')";
                filter += " AND THIS.CURRENTSTATEDEFID = '" + PatientOnVacation.States.OnVacation + "'";

                if (param.AllClinics != true)
                {
                    filter += " AND THIS.INPATIENTPHYSICIAN.INPATIENTTREATMENTCLINICAPP.BASEINPATIENTADMISSION.PHYSICALSTATECLINIC IN ( '1'";

                    foreach (var item in param.SelectedClinicList)
                    {
                        filter += ",'" + item + "'";
                    }
                    filter += ")";
                }
                
                BindingList<PatientOnVacation.GetVacationInfoList_Class> MedicalReport = PatientOnVacation.GetVacationInfoList(filter);
                if (MedicalReport.Count > 0)
                {
                    foreach (PatientOnVacation.GetVacationInfoList_Class report in MedicalReport)
                    {
                        PatientVacationListData data = new PatientVacationListData();

                        data.HastahaneAdi = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALSHORTNAME", "");
                        data.HastaAdi = report.Name;
                        data.Cinsiyet = report.Cinsiyet;
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
                        data.Yatak = report.Bed;
                        data.Oda = report.Room;

                        list.Add(data);
                    }
                    //PatientOnVacation.GetVacationInfoList_Class report = MedicalReport[0];


                }
            }
            return list;

        }

        [Serializable]
        public class PatientVacationReportParameters
        {
            [DataMember]
            public bool AllClinics { get; set; }
            [DataMember]
            public List<string> SelectedClinicList { get; set; }
            [DataMember]
            public DateTime BaslangicTarihi { get; set; }
            [DataMember]
            public DateTime BitisTarihi { get; set; }

        }

        [Serializable]
        public class PatientVacationListData
        {
            [DataMember]
            public string HastaAdi { get; set; }
            [DataMember]
            public string Cinsiyet { get; set; }
            [DataMember]
            public string KimlikNo { get; set; }
            [DataMember]
            public string KabulNo { get; set; }
            [DataMember]
            public string TedaviGorduguServis { get; set; }
            [DataMember]
            public string YattigiServis { get; set; }
            [DataMember]
            public string Oda { get; set; }
            [DataMember]
            public string Yatak { get; set; }
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
