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
    public class MuayeneSureleriRaporu
    {
        public static MuayeneSureleriRaporuData GetReportData(string parameters)
        {
            return ApiCaller.CallAnyApiWithParams<MuayeneSureleriRaporuData>(parameters, "GetMuayeneSureleriRaporuData");
        }

        public static MuayeneSureleriRaporuListesi GetMuayeneSureleriRaporuData(string parameters)
        {
            var param = Newtonsoft.Json.JsonConvert.DeserializeObject<MuayeneSureleriRaporuParam>(parameters.ToString());
            MuayeneSureleriRaporuListesi list = new MuayeneSureleriRaporuListesi();

            if (parameters != null)
            {
                BindingList<PatientExamination.GetPatientExaminationDurationByDate_Class> reportDataList = PatientExamination.GetPatientExaminationDurationByDate(param.BaslangicTarihi, param.BitisTarihi, param.Birim);
                list.MuayeneSureleriRaporuData = new List<MuayeneSureleriRaporuData>();
                int siraNo = 1;
                foreach (PatientExamination.GetPatientExaminationDurationByDate_Class item in reportDataList)
                {
                    MuayeneSureleriRaporuData _data = new MuayeneSureleriRaporuData();

                    _data.SiraNo = siraNo.ToString();
                    _data.HastaAdiSoyadi = item.Patientname + " " + item.Patientsurname;

                    _data.KabulNo = item.ProtocolNo;
                    _data.KabulTarihi = item.OpeningDate.HasValue ? item.OpeningDate : null;
                    _data.Doktor = item.Doctor;
                    _data.Birim = item.Masterresourcename;

                    _data.MuayeneBaslamaTarihi = item.Processstartdate.HasValue ? item.Processstartdate : null;
                    _data.MuayeneBitisTarihi = item.ProcessEndDate.HasValue ? item.ProcessEndDate : null;


                    list.MuayeneSureleriRaporuData.Add(_data);

                    siraNo++;
                }
            }
            return list;
        }
    }

    [Serializable]
    public class MuayeneSureleriRaporuParam
    {
        [DataMember]
        public DateTime BaslangicTarihi { get; set; }
        [DataMember]
        public DateTime BitisTarihi { get; set; }
        [DataMember]
        public Guid Birim { get; set; }

    }


    [Serializable]
    public class MuayeneSureleriRaporuListesi
    {
        [DataMember]
        public List<MuayeneSureleriRaporuData> MuayeneSureleriRaporuData { get; set; }
    }

    [Serializable]
    public class MuayeneSureleriRaporuData
    {
        [DataMember]
        public string SiraNo { get; set; }
        [DataMember]
        public string HastaAdiSoyadi { get; set; }
        [DataMember]
        public string KabulNo { get; set; }
        [DataMember]
        public DateTime? KabulTarihi { get; set; }
        [DataMember]
        public DateTime? MuayeneBaslamaTarihi { get; set; }
        [DataMember]
        public DateTime? MuayeneBitisTarihi { get; set; }
        [DataMember]
        public string Doktor { get; set; }
        [DataMember]
        public string Birim { get; set; }
    }

}


