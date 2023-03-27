using System;
using System.Runtime.Serialization;
using TTObjectClasses;
using System.ComponentModel;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using ReportClasses.Controllers.DynamicReporting;
using ReportClasses.ReportUtils;

namespace AtlasDataSource.Controllers
{

    public class J11TanisiGirilenHastaRaporu
    {
        public static J11TanisiGirilenHastaRaporuListesi GetReportData(string parameters)
        {
            return ApiCaller.CallAnyApiWithParams<J11TanisiGirilenHastaRaporuListesi>(parameters, "GetJ11TanisiGirilenHastaRaporuListesi");
        }

        public static J11TanisiGirilenHastaRaporuListesi GetJ11TanisiGirilenHastaRaporuListesi(string parameters)
        {
            J11TanisiGirilenHastaRaporuListesi list = new J11TanisiGirilenHastaRaporuListesi();

            if (parameters != null)
            {
                var param = Newtonsoft.Json.JsonConvert.DeserializeObject<J11TanisiGirilenHastaRaporuParam>(parameters.ToString());

                BindingList<DiagnosisGrid.GetAllJ11DiagnoseByDate_Class> reportDataList = DiagnosisGrid.GetAllJ11DiagnoseByDate(param.BaslangicTarihi, param.BitisTarihi);

                list.J11TanisiGirilenHastaRaporuData = new List<J11TanisiGirilenHastaRaporuData>();
                int siraNo = 1;
                foreach (DiagnosisGrid.GetAllJ11DiagnoseByDate_Class item in reportDataList)
                {
                    J11TanisiGirilenHastaRaporuData _data = new J11TanisiGirilenHastaRaporuData();

                    _data.SiraNo = siraNo.ToString();
                    _data.HastaAdiSoyadi = item.Patientname + " " + item.Patientsurname;
                    _data.Cinsiyet = item.Sex;
                    _data.Yas = item.BirthDate.HasValue ? Common.DateDiff(Common.DateIntervalEnum.Year, TTDefinitionManagement.TTObjectDefManager.ServerTime, item.BirthDate.Value).ToString() : "";
                    _data.Telefonu = item.MobilePhone;

                    _data.TaniAdi = item.Diagnosename;
                    _data.TaniKodu = item.Diagnosecode;

                    _data.KabulNo = item.ProtocolNo;
                    _data.KabulTarihi = item.OpeningDate.HasValue ? item.OpeningDate : null;
                    _data.Birimi = item.Ressectionname;

                    _data.YatisTarihi = item.ClinicInpatientDate.HasValue ? item.ClinicInpatientDate : null;
                    _data.CikisTarihi = item.ClinicDischargeDate.HasValue ? item.ClinicDischargeDate : null;

                    list.J11TanisiGirilenHastaRaporuData.Add(_data);

                    siraNo++;

                }

            }
            return list;

        }

    }

    [Serializable]
    public class J11TanisiGirilenHastaRaporuParam
    {
        [DataMember]
        public DateTime BaslangicTarihi { get; set; }
        [DataMember]
        public DateTime BitisTarihi { get; set; }

    }

    [Serializable]
    public class J11TanisiGirilenHastaRaporuListesi
    {
        [DataMember]
        public List<J11TanisiGirilenHastaRaporuData> J11TanisiGirilenHastaRaporuData { get; set; }
    }

    [Serializable]
    public class J11TanisiGirilenHastaRaporuData
    {
        [DataMember]
        public string SiraNo { get; set; }
        [DataMember]
        public string HastaAdiSoyadi { get; set; }
        [DataMember]
        public string Cinsiyet { get; set; }
        [DataMember]
        public string Yas { get; set; }
        [DataMember]
        public string KabulNo { get; set; }
        [DataMember]
        public DateTime? KabulTarihi { get; set; }

        [DataMember]
        public string TaniAdi { get; set; }
        [DataMember]
        public string TaniKodu { get; set; }
        [DataMember]
        public string Birimi { get; set; }
        [DataMember]
        public string Telefonu { get; set; }
        [DataMember]
        public DateTime? YatisTarihi { get; set; }
        [DataMember]
        public DateTime? CikisTarihi { get; set; }
    }

}
