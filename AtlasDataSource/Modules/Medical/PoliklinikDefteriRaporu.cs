using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReportClasses.Controllers.ReportModels;
using System.Runtime.Serialization;
using TTObjectClasses;
using System.ComponentModel;
using TTInstanceManagement;
using ReportClasses.ReportUtils;

namespace AtlasDataSource.Modules.Medical.Yatan_Hasta_Rapor
{
    public class PoliklinikDefteriRaporu
    {
        public static PoliklinikDefteriRaporuData GetReportData(string parameters)
        {
            return ApiCaller.CallAnyApiWithParams<PoliklinikDefteriRaporuData>(parameters, "GetPoliklinikDefteriRaporuData");
        }

        public static PoliklinikDefteriRaporuListesi GetPoliklinikDefteriRaporuData(string parameters)
        {
            var param = Newtonsoft.Json.JsonConvert.DeserializeObject<PoliklinikDefteriRaporuParam>(parameters.ToString());
            PoliklinikDefteriRaporuListesi list = new PoliklinikDefteriRaporuListesi();

            if (parameters != null)
            {
                BindingList<PatientExamination.GetPolyclinicBookByDate_Class>reportDataList = PatientExamination.GetPolyclinicBookByDate(param.BitisTarihi, param.Birim,param.BaslangicTarihi);
                list.PoliklinikDefteriRaporuData = new List<PoliklinikDefteriRaporuData>();
                int siraNo = 1;
                foreach (PatientExamination.GetPolyclinicBookByDate_Class item in reportDataList)
                {
                    PoliklinikDefteriRaporuData _data = new PoliklinikDefteriRaporuData();

                    _data.SiraNo = siraNo.ToString();
                    _data.HastaAdiSoyadi = item.Patientname + " " + item.Patientsurname;
                    _data.TcNo = item.UniqueRefNo.ToString();
                    _data.BabaAdı = item.FatherName;
                    _data.Cinsiyet = item.Sex;
                    _data.Yas = item.BirthDate.HasValue ? Common.DateDiff(Common.DateIntervalEnum.Year, TTDefinitionManagement.TTObjectDefManager.ServerTime, item.BirthDate.Value).ToString() : "";
                    _data.Adresi = item.HomeAddress;

                    _data.KabulNo = item.ProtocolNo;
                    _data.MuayeneTarihi = item.ProcessDate;
                    _data.KabulTipi = Common.GetDisplayTextOfDataTypeEnum(item.AdmissionStatus);
                    _data.Doktor = item.Doctor;
                    _data.TreatmentResult = item.Treatmentresult;

                    _data.TaniAdi = item.Diagnosename;
                    _data.TaniKodu = item.Diagnosecode;
                    _data.Birim = item.Masterresourcename;

                    list.PoliklinikDefteriRaporuData.Add(_data);

                    siraNo++;
                }
            }
            return list;
        }
    }

    [Serializable]
    public class PoliklinikDefteriRaporuParam
    {
        [DataMember]
        public DateTime BaslangicTarihi { get; set; }
        [DataMember]
        public DateTime BitisTarihi { get; set; }
        [DataMember]
        public Guid Birim { get; set; }

    }


    [Serializable]
    public class PoliklinikDefteriRaporuListesi
    {
        [DataMember]
        public List<PoliklinikDefteriRaporuData> PoliklinikDefteriRaporuData { get; set; }
    }

    [Serializable]
    public class PoliklinikDefteriRaporuData
    {
        [DataMember]
        public string SiraNo { get; set; }
        [DataMember]
        public string HastaAdiSoyadi { get; set; }
        [DataMember]
        public string TcNo { get; set; }
        [DataMember]
        public string Cinsiyet { get; set; }
        [DataMember]
        public string Yas { get; set; }
        [DataMember]
        public string BabaAdı { get; set; }
        [DataMember]
        public string Adresi { get; set; }
        [DataMember]
        public string KabulNo { get; set; }
        [DataMember]
        public DateTime? MuayeneTarihi { get; set; }
        [DataMember]
        public string KabulTipi { get; set; }
        [DataMember]
        public string TaniAdi { get; set; }
        [DataMember]
        public string TaniKodu { get; set; }
        [DataMember]
        public string Doktor { get; set; }
        [DataMember]
        public string Birim { get; set; }
        [DataMember]
        public string TreatmentResult { get; set; }
    }

}


