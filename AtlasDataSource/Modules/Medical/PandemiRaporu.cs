using ReportClasses.ReportUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;
using TTInstanceManagement;
using TTObjectClasses;


namespace AtlasDataSource.Controllers
{
    public class PandemiRaporu
    {
        public static PandemiRaporuData GetReportData(string parameters)
        {
            return ApiCaller.CallAnyApiWithParams<PandemiRaporuData>(parameters, "GetPandemiRaporuData");
        }
        public static PandemiRaporuData GetPandemiRaporuData(string parameters)
        {
            PandemiRaporuData PandemiHastaListesi = new PandemiRaporuData();
            if (parameters != null)
            {
                var param = Newtonsoft.Json.JsonConvert.DeserializeObject<PandemiHastaListParam>(parameters.ToString());
                string filter = string.Empty;
                using (var objectContext = new TTObjectContext(false))
                {
                    if (param.Poliklinik.Length > 0)
                    {
                        filter = " AND THIS.MASTERRESOURCE IN (";

                        foreach (Guid pol in param.Poliklinik)
                        {
                            filter += "'" + pol + "', ";
                        }

                        filter = filter.Remove(filter.LastIndexOf(", ")) + ")";
                    }

                    PandemiHastaListesi.PandemiHastasiDataList = new List<PandemiHastasiData>();
                    BindingList<PatientExamination.GetPandemicPatientsData_Class> pandemicReport = PatientExamination.GetPandemicPatientsData(param.BaslangicTarihi, param.BitisTarihi,filter);
                    foreach (PatientExamination.GetPandemicPatientsData_Class item in pandemicReport)
                    {
                        PandemiHastasiData data = new PandemiHastasiData();
                        data.HastaAdiSoyadi = item.Name + " " + item.Surname;
                        data.HastaTCKimlikNo = item.UniqueRefNo;
                        data.HastaAdres = item.Address;
                        data.HastaTelefonNumarasi = item.Phone;
                        data.Doktor = item.Doctor;
                        data.KabulNo = item.ProtocolNo;

                        PandemiHastaListesi.PandemiHastasiDataList.Add(data);
                    }
                }

            }
            return PandemiHastaListesi;
        }
    }

    [Serializable]
    public class PandemiHastaListParam
    {
        [DataMember]
        public DateTime BaslangicTarihi { get; set; }
        [DataMember]
        public DateTime BitisTarihi { get; set; }
        [DataMember]
        public Guid[] Poliklinik { get; set; }

    }
    [Serializable]
    public class PandemiRaporuData
    {
        [DataMember]
        public List<PandemiHastasiData> PandemiHastasiDataList { get; set; }
    }

    [Serializable]
    public class PandemiHastasiData
    {
        [DataMember]
        public string HastaAdiSoyadi { get; set; }
        [DataMember]
        public long? HastaTCKimlikNo { get; set; }
        [DataMember]
        public string HastaAdres { get; set; } //?
        [DataMember]
        public string HastaTelefonNumarasi { get; set; }
        [DataMember]
        public string Doktor { get; set; }
        [DataMember]
        public string KabulNo { get; set; }

    }
}
